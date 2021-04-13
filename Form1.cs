using System;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Text;
using System.Threading.Tasks;

using static DigitalPlatform.Z3950.ZClient;
using DigitalPlatform.Text;
using DigitalPlatform.Z3950;
using DigitalPlatform.Marc;
using DigitalPlatform.Net;
using DigitalPlatform.Script;

namespace mytest
{
    public partial class Form1 : Form
    {
        marc2folio m2f = null;
        string folio_uname = null;
        string folio_upass = null;
        string folio_tenant = null;
        string folio_token_url = null;
        string folio_data_url = null;

        ZClient _zclient = new ZClient();
        public IsbnSplitter _isbnSplitter = null;
        public UseCollection _useList = new UseCollection();

        TargetInfo _targetInfo = new TargetInfo();
        long _resultCount = 0;   // 检索命中条数
        int _fetched = 0;   // 已经 Present 获取的条数
        string[] z39_records_marc;
        string marcType = "unimarc";

        public Form1()
        {
            InitializeComponent();
            z39_records_marc = new string[10];
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSettings();
            Result result = LoadEnvironment();
            if (result.Value == -1)
                MessageBox.Show(this, result.ErrorInfo);

            if (File.Exists("folio.config")) //读取保存的folio配置文件
            {
                using (StreamReader sr = new StreamReader("folio.config", Encoding.Default))
                {
                    String line = null;
                    int pos = 0;
                    string key, val;
                    while ((line = sr.ReadLine()) != null)
                    {
                        pos = line.IndexOf('=');
                        if (pos < 0)
                            continue;

                        key = line.Substring(0, pos);
                        val = line.Substring(pos + 1);
                        if (key.Equals("FOLIO_UNAME"))
                            folio_uname = val;
                        if (key.Equals("FOLIO_UPASS"))
                            folio_upass = val;
                        if (key.Equals("FOLIO_TENANT"))
                            folio_tenant = val;
                        if (key.Equals("FOLIO_TOKEN_URL"))
                            folio_token_url = val;
                        if (key.Equals("FOLIO_DATA_URL"))
                            folio_data_url = val;
                    }
                }
            }
            else
            {
                MessageBox.Show("未找到配置文件 folio.config ");
                return;
            }

            m2f = new marc2folio(folio_uname, folio_upass, folio_tenant, folio_token_url, folio_data_url);
            m2f.token_fetch();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();

            if (_zclient != null)
            {
                _zclient.CloseConnection();
                _zclient.Dispose();
            }
        }
        void LoadSettings()
        {

        }
        void SaveSettings()
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ISO2709格式文件|*.mrc;*.iso;*.out|所有文件(*.*)|*.*";
            ofd.ValidateNames = true; // 验证用户输入是否是一个有效的Windows文件名
            ofd.CheckFileExists = true; //验证路径的有效性
            ofd.CheckPathExists = true;//验证路径的有效性
            if (ofd.ShowDialog() == DialogResult.OK) //用户点击确认按钮，发送确认消息
            {
                m2f.json_record.rawRecordContent = File.ReadAllText(ofd.FileName);
                m2f.marc2dc();
                marcEditor1.Marc = m2f.dcmarcText;
            }
        }

        private void marcEditor1_GetConfigDom(object sender, DigitalPlatform.Marc.GetConfigDomEventArgs e)
        {
            // e.Path 中可能是 "marcdef" 或 "marcvaluelist"
            string filename = "";

            if (e.Path.IndexOf("marcvaluelist") == -1)
            {
                filename = "1_2_840_10003_5_10\\marcdef";
                if (marcType.Equals("unimarc"))
                {
                    filename = "1_2_840_10003_5_1\\marcdef";
                }
            }
            else
            {
                filename = "1_2_840_10003_5_10\\marcvaluelist";
                if (marcType.Equals("unimarc"))
                {
                    filename = "1_2_840_10003_5_1\\marcvaluelist";
                }
            }
            filename = Path.Combine(Environment.CurrentDirectory, filename);
            XmlDocument dom = new XmlDocument();
            dom.Load(filename);

            e.XmlDocument = dom;
        }

        private void btn_fetch_record_Click(object sender, EventArgs e)
        {
            m2f.data_fetch(txt_recordid.Text);
            m2f.json_data_process();
            m2f.marc2dc();
            marcEditor1.Marc = m2f.dcmarcText;
        }

        private void btn_save_record_Click(object sender, EventArgs e)
        {
            string marc_str = m2f.dc2marc(marcEditor1.Marc);
            string json_str = m2f.marc2json(marc_str);

            m2f.data_post(json_str);
        }

        void Copy200gfTo7xxa(string strFromSubfield, string strToField)
        {
            Field field_200 = marcEditor1.Record.Fields.GetOneField("200", 0);
            if (field_200 == null)
            {
                MessageBox.Show(this, "200字段不存在");
                return;
            }

            SubfieldCollection subfields_200 = field_200.Subfields;

            Subfield subfield_f = subfields_200[strFromSubfield];

            if (subfield_f == null)
            {
                MessageBox.Show(this, "200$" + strFromSubfield + "不存在");
                return;
            }

            string strContent = subfield_f.Value;

            // 看看当前活动字段是不是701
            Field field_701 = null;

            field_701 = marcEditor1.FocusedField;
            if (field_701 != null)
            {
                if (field_701.Name != strToField)
                    field_701 = null;
            }

            if (field_701 == null)
            {
                field_701 = marcEditor1.Record.Fields.GetOneField(strToField, 0);

                if (field_701 == null)
                {
                    field_701 = marcEditor1.Record.Fields.Add(strToField, "  ", "", true);
                }
            }

            if (field_701 == null)
                throw (new Exception("error ..."));

            Subfield subfield_701a = field_701.Subfields["a"];
            if (subfield_701a == null)
            {
                subfield_701a = new Subfield();
                subfield_701a.Name = "a";
            }

            subfield_701a.Value = strContent;
            field_701.Subfields["a"] = subfield_701a;
        }

        private void btn_200f_2_7xx_Click(object sender, EventArgs e)
        {
            Copy200gfTo7xxa("f", "701");
        }

        private void btn_200g_2_702_Click(object sender, EventArgs e)
        {
            Copy200gfTo7xxa("g", "702");
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
        void AppendMarcRecords(RecordCollection records,Encoding encoding,int start_index)
        {
            if (records == null)
                return;

            int i = start_index;
            this.listView1.BeginUpdate();
            foreach (DigitalPlatform.Z3950.Record record in records)
            {
                if (string.IsNullOrEmpty(record.m_strDiagSetID) == false)
                {
                    // 这是诊断记录
                    i++;
                    continue;
                }

                // 把byte[]类型的MARC记录转换为机内格式
                // return:
                //		-2	MARC格式错
                //		-1	一般错误
                //		0	正常
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

                z39_records_marc[i] = strMARC;//临时保存

                MarcRecord marc_record = new MarcRecord(strMARC);
                string content = marc_record.select("field[@name='200']/subfield[@name='a']").FirstContent;
                marcType = "unimarc";
                string isbn = "";
                string year = "";
                string author = "";
                string publish = "";
                if (content == null)
                {
                    content = marc_record.select("field[@name='245']/subfield[@name='a']").FirstContent;
                    marcType = "usmarc";
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
            this.listView1.EndUpdate();            
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int selectCount = listView1.SelectedItems.Count; //选中的行数目，listview1是控件名。
            if (selectCount == 0)
                return; //没选中，不做响应

            string rec_id = listView1.SelectedItems[0].Text;
            marcEditor1.Marc = z39_records_marc[Convert.ToInt32(rec_id)];
        }
    }
}
