using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

using static DigitalPlatform.Z3950.ZClient;
using DigitalPlatform.Text;
using DigitalPlatform.Z3950;
using DigitalPlatform.Marc;
using DigitalPlatform.Net;
using DigitalPlatform.Script;

namespace mytest
{
    public partial class SearchForm : Form
    {
        static int MAX_RECORD = 10;//一次最多取10条记录

        ZClient _zclient = new ZClient();
        public IsbnSplitter _isbnSplitter = null;
        public UseCollection _useList = new UseCollection();
        
        TargetInfo _targetInfo = new TargetInfo();
        long _resultCount = 0;   // 检索命中条数
        int _fetched = 0;   // 已经 Present 获取的条数

        private string[] z39_record_data = null;
        private string[] z39_record_type = null;

        public SearchForm()
        {
            InitializeComponent();
            z39_record_data = new string[MAX_RECORD];
            z39_record_type = new string[MAX_RECORD];
        }
        Result LoadEnvironment()
        {
            try
            {
                this._isbnSplitter = new IsbnSplitter(Path.Combine(Environment.CurrentDirectory, "rangemessage.xml"));  // "\\isbn.xml"
            }
            catch (FileNotFoundException ex)
            {
                return new Result { Value = -1, ErrorInfo = "装载本地 isbn 规则文件 rangemessage.xml 发生错误 :" + ex.Message };
            }
            catch (Exception ex)
            {
                return new Result { Value = -1, ErrorInfo = "装载本地 isbn 规则文件发生错误 :" + ex.Message };
            }

            Result result = _useList.Load(Path.Combine(Environment.CurrentDirectory, "bib1use.xml"));
            if (result.Value == -1)
                return result;

            string[] fromlist = this._useList.GetDropDownList();
            this.comboBox_use.Items.AddRange(fromlist);

            return new Result();
        }
        // 创建只包含一个检索词的简单 XML 检索式
        // 注：这种 XML 检索式不是 Z39.50 函数库必需的。只是用它来方便构造 API 检索式的过程
        public string BuildQueryXml()
        {
            XmlDocument dom = new XmlDocument();
            dom.LoadXml("<root />");
            {
                XmlElement node = dom.CreateElement("line");
                dom.DocumentElement.AppendChild(node);

                string strLogic = "OR";
                string strFrom = this.comboBox_use.Text;

                node.SetAttribute("logic", strLogic);
                node.SetAttribute("word", this.textBox_queryWord.Text);
                node.SetAttribute("from", strFrom);
            }

            return dom.OuterXml;
        }
        int GetAuthentcationMethod()
        {
            return (this.radioButton_authenStyleIdpass.Checked ? 1 : 0);
        }
        private async void button_search_Click(object sender, EventArgs e)
        {
            listView1.Clear();

            this.listView1.Columns.Add("序号");
            this.listView1.Columns.Add("ISBN");
            this.listView1.Columns.Add("出版年");
            this.listView1.Columns.Add("题名");
            this.listView1.Columns.Add("作者");
            this.listView1.Columns.Add("出版社");

            string strError = "";

            _resultCount = 0;
            _fetched = 0;

            try
            {
                // 如果 _targetInfo 涉及到的信息字段对比环境没有变化，就持续使用
                if (_targetInfo.HostName != this.textBox_serverAddr.Text
                    || _targetInfo.Port != Convert.ToInt32(this.textBox_serverPort.Text)
                    || string.Join(",", _targetInfo.DbNames) != this.textBox_database.Text
                    || _targetInfo.AuthenticationMethod != GetAuthentcationMethod()
                    || _targetInfo.UserName != this.textBox_userName.Text
                    || _targetInfo.Password != this.textBox_password.Text)
                {
                    _targetInfo = new TargetInfo
                    {
                        HostName = this.textBox_serverAddr.Text,
                        Port = Convert.ToInt32(this.textBox_serverPort.Text),
                        DbNames = StringUtil.SplitList(this.textBox_database.Text).ToArray(),
                        AuthenticationMethod = GetAuthentcationMethod(),
                        GroupID = this.textBox_groupID.Text,
                        UserName = this.textBox_userName.Text,
                        Password = this.textBox_password.Text,
                        DefaultRecordsEncoding = Encoding.GetEncoding("UTF-8"),
                    };
                    _zclient.CloseConnection();
                }

                IsbnConvertInfo isbnconvertinfo = new IsbnConvertInfo
                {
                    IsbnSplitter = this._isbnSplitter,
                    ConvertStyle =
                    (_targetInfo.IsbnAddHyphen == true ? "addhyphen," : "")
                    + (_targetInfo.IsbnRemoveHyphen == true ? "removehyphen," : "")
                    + (_targetInfo.IsbnForce10 == true ? "force10," : "")
                    + (_targetInfo.IsbnForce13 == true ? "force13," : "")
                    + (_targetInfo.IsbnWild == true ? "wild," : "")
                };

                string strQueryString = "";

                if (true)
                {
                    // 创建只包含一个检索词的简单 XML 检索式
                    // 注：这种 XML 检索式不是 Z39.50 函数库必需的。只是用它来方便构造 API 检索式的过程
                    string strQueryXml = BuildQueryXml();
                    // 将 XML 检索式变化为 API 检索式
                    Result result = ZClient.ConvertQueryString(this._useList, strQueryXml, isbnconvertinfo, out strQueryString);
                    if (result.Value == -1)
                    {
                        strError = result.ErrorInfo;
                        goto ERROR1;
                    }
                }

            REDO_SEARCH:
                {
                    // return Value:
                    //      -1  出错
                    //      0   成功
                    //      1   调用前已经是初始化过的状态，本次没有进行初始化

                    InitialResult result = await _zclient.TryInitialize(_targetInfo);
                    if (result.Value == -1)
                    {
                        strError = "Initialize error: " + result.ErrorInfo;
                        goto ERROR1;
                    }
                }

                // result.Value:
                //		-1	error
                //		0	fail
                //		1	succeed
                // result.ResultCount:
                //      命中结果集内记录条数 (当 result.Value 为 1 时)
                SearchResult search_result = await _zclient.Search(strQueryString, _targetInfo.DefaultQueryTermEncoding, _targetInfo.DbNames, _targetInfo.PreferredRecordSyntax, "default");
                if (search_result.Value == -1 || search_result.Value == 0)
                {
                    MessageBox.Show(" 检索出错 " + search_result.ErrorInfo);
                    if (search_result.ErrorCode == "ConnectionAborted")
                    {
                        MessageBox.Show(" 自动重试检索 ...");
                        goto REDO_SEARCH;
                    }
                }
                //else
                //    MessageBox.Show(" 检索共命中记录 " + search_result.ResultCount);

                _resultCount = search_result.ResultCount;


                await FetchRecords(_targetInfo);

                return;
            }
            finally
            {

            }

        ERROR1:
            MessageBox.Show(this, strError);
        }
        async Task FetchRecords(TargetInfo targetinfo)
        {
            try
            {
                if (_resultCount - _fetched > 0)
                {
                    PresentResult present_result = await _zclient.Present(
                        "default",
                        _fetched,
                        Math.Min((int)_resultCount - _fetched, 10),
                        10,
                        "F",
                        targetinfo.PreferredRecordSyntax);
                    if (present_result.Value == -1)
                    {
                        this.Invoke((Action)(() => MessageBox.Show(this, present_result.ToString())));
                    }
                    else
                    {
                        // 把 MARC 记录显示出来
                        AppendMarcRecords(present_result.Records,
                            _zclient.ForcedRecordsEncoding == null ? targetinfo.DefaultRecordsEncoding : _zclient.ForcedRecordsEncoding,
                            _fetched);
                        _fetched += present_result.Records.Count;
                    }
                }
            }
            finally
            {

            }
        }
        void AppendMarcRecords(RecordCollection records, Encoding encoding, int start_index)
        {
            if (records == null)
                return;
            int i = start_index;

            listView1.BeginUpdate();
            foreach (DigitalPlatform.Z3950.Record record in records)
            {
                if (string.IsNullOrEmpty(record.m_strDiagSetID) == false)
                {
                    // 这是诊断记录
                    i++;
                    continue;
                }
                int nRet = MarcLoader.ConvertIso2709ToMarcString(record.m_baRecord,
                    encoding == null ? Encoding.GetEncoding(936) : encoding,
                    true,
                    out string strMARC,
                    out string strError);
                if (nRet == -1)
                {
                    i++;
                    continue;
                }

                z39_record_data[i] = strMARC;
                z39_record_type[i] = "unimarc";

                MarcRecord marc_record = new MarcRecord(strMARC);
                string content = marc_record.select("field[@name='200']/subfield[@name='a']").FirstContent;
                string isbn = "";
                string year = "";
                string author = "";
                string publish = "";
                if (content == null)
                {
                    content = marc_record.select("field[@name='245']/subfield[@name='a']").FirstContent;
                    z39_record_type[i] = "usmarc";
                    isbn = marc_record.select("field[@name='020']/subfield[@name='a']").FirstContent;
                    year = marc_record.select("field[@name='260']/subfield[@name='c']").FirstContent;
                    author = marc_record.select("field[@name='245']/subfield[@name='c']").FirstContent;
                    publish = marc_record.select("field[@name='260']/subfield[@name='b']").FirstContent;
                }
                else
                {
                    isbn = marc_record.select("field[@name='010']/subfield[@name='a']").FirstContent;
                    year = marc_record.select("field[@name='210']/subfield[@name='d']").FirstContent;
                    author = marc_record.select("field[@name='200']/subfield[@name='f']").FirstContent;
                    publish = marc_record.select("field[@name='210']/subfield[@name='c']").FirstContent;
                }

                ListViewItem lvi = new ListViewItem();
                lvi.Text = i.ToString();
                lvi.SubItems.Add(isbn);
                lvi.SubItems.Add(year);
                lvi.SubItems.Add(content);
                lvi.SubItems.Add(author);
                lvi.SubItems.Add(publish);
                listView1.Items.Add(lvi);

                i++;
            }
            listView1.EndUpdate();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int selectCount = listView1.SelectedItems.Count;
            if (selectCount == 0)
                return; //没选中，不做响应

            int rec_id = Convert.ToInt32(listView1.SelectedItems[0].Text);

            //将要加载到编辑器的数据保存到全局变量
            Z39_Record.rec_status = true;
            Z39_Record.rec_data = z39_record_data[rec_id];
            Z39_Record.rec_type = z39_record_type[rec_id];

            Program.EditForm.Show();
            Program.EditForm.Activate();
        }
        private void SearchForm_Load(object sender, EventArgs e)
        {
            Result result = LoadEnvironment();
            if (result.Value == -1)
                MessageBox.Show(this, result.ErrorInfo);
        }
        private void SearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true; //取消关闭操作
        }
    }
}
