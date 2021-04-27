using System;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Text;
using System.Threading.Tasks;

using DigitalPlatform.Marc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static DigitalPlatform.Z3950.ZClient;
using DigitalPlatform.Text;
using DigitalPlatform.Z3950;
using DigitalPlatform.Net;
using DigitalPlatform.Script;

namespace mytest
{
    public partial class EditForm : Form
    {
        const int MAX_RECORD_Z39 = 10;//一次最多取10条z39记录
        ZClient _zclient = new ZClient();
        IsbnSplitter _isbnSplitter = null;
        UseCollection _useList = new UseCollection();
        TargetInfo _targetInfo = new TargetInfo();
        long _resultCount = 0;   // 检索命中条数
        int _fetched = 0;   // 已经 Present 获取的条数
        string[] _z39_record_data = null;
        string[] _z39_record_type = null;

        const int MAX_RECORD_FOLIO = 20;//定义一次获取的最大记录数量
        string[] _catalog_id = null;
        string[] _catalog_instanceId = null;
        int _saved_Field_Index = 0;

        marc2folio m2f = null;//提供数据转换功能的类
        Encoding _encoding = Encoding.GetEncoding("UTF-8");
        string marcType = "unimarc";
        string jsonText = "";

        public EditForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            m2f = new marc2folio();
            _catalog_id = new string[MAX_RECORD_FOLIO];
            _catalog_instanceId = new string[MAX_RECORD_FOLIO];
            _z39_record_data = new string[MAX_RECORD_Z39];
            _z39_record_type = new string[MAX_RECORD_Z39];

            Result result = LoadEnvironment();
            if (result.Value == -1)
                MessageBox.Show(this, result.ErrorInfo);
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

                _z39_record_data[i] = strMARC;
                _z39_record_type[i] = "unimarc";

                MarcRecord marc_record = new MarcRecord(strMARC);
                string content = marc_record.select("field[@name='200']/subfield[@name='a']").FirstContent;
                string isbn = "";
                string year = "";
                string author = "";
                string publish = "";
                if (content == null)
                {
                    content = marc_record.select("field[@name='245']/subfield[@name='a']").FirstContent;
                    _z39_record_type[i] = "usmarc";
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

            marcEditor1.MarcDefDom = null;
            marcEditor1.Marc = _z39_record_data[rec_id];
        }

        //功能测试
        private void btn_loadrecord_from_disk_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ISO2709格式文件|*.mrc;*.iso;*.out|所有文件(*.*)|*.*";
            ofd.ValidateNames = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK) //用户点击确认按钮，发送确认消息
            {
                string str_data = File.ReadAllText(ofd.FileName);
                byte[] str_bytes = _encoding.GetBytes(str_data);

                int nRet = MarcLoader.ConvertIso2709ToMarcString(str_bytes,
                    _encoding,
                    true,
                    out string strMARC,
                    out string strError);
                if (nRet == -1)
                {
                    MessageBox.Show("加载本地记录失败: " + strError);
                    return;
                }
                //在这里合并版本馆记录
                marcEditor1.MarcDefDom = null;
                marcEditor1.Marc = strMARC;
            }
        }

        private void marcEditor1_GetConfigDom(object sender, DigitalPlatform.Marc.GetConfigDomEventArgs e)
        {
            // e.Path 中可能是 "marcdef" 或 "marcvaluelist"
            string filename = "";            
            if (marcType.Equals("unimarc"))
            {
                filename = "1_2_840_10003_5_1\\marcvaluelist";
                if (e.Path.IndexOf("marcvaluelist") == -1)
                    filename = "1_2_840_10003_5_1\\marcdef";
            }
            else
            {
                filename = "1_2_840_10003_5_10\\marcvaluelist";
                if (e.Path.IndexOf("marcvaluelist") == -1)
                    filename = "1_2_840_10003_5_10\\marcdef";
            }

            filename = Path.Combine(Environment.CurrentDirectory, filename);
            XmlDocument dom = new XmlDocument();
            dom.Load(filename);
            e.XmlDocument = dom;
        }
        
        //保存数据到服务器
        private void btn_save_record_Click(object sender, EventArgs e)
        {
            byte[] in_bytes = _encoding.GetBytes(marcEditor1.Marc);
            int nRet = MarcUtil.BuildISO2709Record(in_bytes, out byte[] out_bytes);
            if(nRet != 0)
            {
                MessageBox.Show("转换ISO2709格式失败，未能保存数据到服务器。");
                return;
            }

            string marc_str = _encoding.GetString(out_bytes);
            string json_str = m2f.marc2json_for_folio(Folio_Record.id, Folio_Record.instanceId, marc_str);
            string result = m2f.update_folio(json_str);

            if (result.Equals("OK"))
                MessageBox.Show("更新成功");
            else
                MessageBox.Show("保存记录失败：" + result);
        }
        //整理例程
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

        //获取待编目数据列表
        private void btn_catalog_waiting_Click(object sender, EventArgs e)
        {
            fetch_data_from_api("PENDING_CATALOG");
        }
        //获取编目中数据列表
        private void btn_catalog_ing_Click(object sender, EventArgs e)
        {
            fetch_data_from_api("PROCESS_CATALOG");
        }
        //获取审核未通过的列表
        private void btn_check_failure_Click(object sender, EventArgs e)
        {
            fetch_data_from_api("FAILED_REVIEW");
        }
        private void fetch_data_from_api(string code)
        {
            string jsonText = m2f.task_fetch(code, 1, MAX_RECORD_FOLIO);
            if(jsonText == "")
            {
                MessageBox.Show("获取任务数据失败");
                return;
            }

            JObject jo = (JObject)JsonConvert.DeserializeObject(jsonText);

            string res_code = jo["code"].ToString();
            string res_mess = jo["message"].ToString();
            string res_succ = jo["success"].ToString();

            if (!res_code.Equals("200") || !res_mess.Equals("SUCCESS") || !res_succ.Equals("True"))
            {
                MessageBox.Show("获取数据失败");
                return;
            }
            var page_Num = jo["data"]["pageNum"];
            var page_Size = jo["data"]["pageSize"];
            var pages = jo["data"]["pages"];
            var total = jo["data"]["total"];
            var content = jo["data"]["content"];

            listView2.Clear();
            listView2.Columns.Add("序号", 50);
            listView2.Columns.Add("NAME", 50);
            listView2.Columns.Add("ISBN", 100);
            listView2.Columns.Add("CIP", 100);
            listView2.Columns.Add("endTaskTime", 100);
            listView2.Columns.Add("出版社", 150);
            listView2.Columns.Add("题名", 300);

            if (content == null)
            {
                MessageBox.Show("未找到数据");
                return;
            }

            listView2.BeginUpdate();
            int i = 0;
            foreach (var t in content)
            {
                string name = t["name"].ToString();
                string isbn = t["isbn"].ToString();
                string cip = t["cip"].ToString();
                string pub = t["publisher"].ToString();
                string title = t["title"].ToString();
                string endtime = t["endTaskTime"].ToString();

                _catalog_instanceId[i] = t["instanceId"].ToString();//将instanceId保存到全局变量
                _catalog_id[i] = t["id"].ToString();//将id保存到全局变量

                ListViewItem lvi = new ListViewItem();
                lvi.Text = (i + 1).ToString();
                lvi.SubItems.Add(name);
                lvi.SubItems.Add(isbn);
                lvi.SubItems.Add(cip);
                lvi.SubItems.Add(endtime);
                lvi.SubItems.Add(pub);
                lvi.SubItems.Add(title);
                listView2.Items.Add(lvi);
                i++;
            }
            listView2.EndUpdate();
        }
        //双击列表行，加载MARC数据和编目时使用的图片
        private void listView2_DoubleClick(object sender, EventArgs e)
        {
            int selectCount = listView2.SelectedItems.Count; //选中的行数目
            if (selectCount == 0)
                return; //没选中，不做响应

            int rec_id = Convert.ToInt32(listView2.SelectedItems[0].Text) - 1;

            //这里的全局变量应该都可以改为内部变量
            Folio_Record.instanceId = _catalog_instanceId[rec_id];
            Folio_Record.id = _catalog_id[rec_id];
            jsonText = m2f.fetch_json_from_folio(_catalog_instanceId[rec_id]);

            bool bFound = true;
            if (jsonText == "")
            {
                MessageBox.Show("未找到MARC数据");
                bFound = false;
            }
            else
            {
                if (jsonText.IndexOf("Couldn't find Record with INSTANCE id") != -1)
                {
                    MessageBox.Show("获取MARC数据失败");
                    bFound = false;
                }
                if (jsonText.IndexOf("code\":200,\"message\":\"SUCCESS\",\"success\":true}") != -1)
                {
                    MessageBox.Show("未找到MARC数据");
                    bFound = false;
                }
            }

            if (bFound == true)
            {
                m2f.get_data_from_json(jsonText);
                byte[] str_bytes = _encoding.GetBytes(Folio_Record.rawContent);
                int nRet = MarcLoader.ConvertIso2709ToMarcString(str_bytes,
                    _encoding,
                    true,
                    out string strMARC,
                    out string strError);
                if (nRet == -1)
                {
                    MessageBox.Show("转换ISO2709记录到MARC编辑器失败: " + strError);
                    bFound = false;
                }
                if (strMARC == "")
                {
                    MessageBox.Show("转换ISO2709记录到MARC编辑器失败: 记录格式错误");
                    bFound = false;
                }

                if (bFound == true)
                {
                    marcType = "unimarc";
                    MarcRecord marc_record = new MarcRecord(strMARC);
                    string content = marc_record.select("field[@name='200']/subfield[@name='a']").FirstContent;
                    if (content == null)
                    {
                        marcType = "usmarc";
                    }
                    Folio_Record.rec_data = strMARC;
                    Folio_Record.rec_status = true;

                    marcEditor1.MarcDefDom = null;
                    marcEditor1.Marc = Folio_Record.rec_data;
                }
            }

            //加载图片
            jsonText = "";
            jsonText = m2f.image_fetch(_catalog_instanceId[rec_id]);
            if (jsonText == "")
            {
                MessageBox.Show("未找到图片数据");
                return;
            }
            JObject jo = (JObject)JsonConvert.DeserializeObject(jsonText);

            string res_code = jo["code"].ToString();
            string res_mess = jo["message"].ToString();
            string res_succ = jo["success"].ToString();

            if (!res_code.Equals("200") || !res_mess.Equals("SUCCESS") || !res_succ.Equals("True"))
            {
                MessageBox.Show("获取图片数据失败");
                return;
            }

            string html = "<html><head><title>图片自动适应</title>";
            html += "<style>.ShaShiDi{width:500px;height:400px;display:flex;align-items:center;justify-content:center;border:1px solid black;}";
            html += ".ShaShiDi img{width:100%;height:auto;}</style></head><body>";
            foreach (var t in jo["data"])
            {
                string img_title = t["imageCaption"].ToString();
                string img_url = t["imageUrl"].ToString();
                html += img_title + "<div class=\"ShaShiDi\"><img src=" + img_url + "></div>";
            }
            webBrowser1.DocumentText = html;
        }

        private void btn_z39_search_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 5; ;
        }

        private void marcEditor1_Click(object sender, EventArgs e)
        {
            int i = marcEditor1.FocusedFieldIndex;
            if (i == _saved_Field_Index)
                return;
                       
            _saved_Field_Index = i;
            string cur_field_name = marcEditor1.FocusedField.Name;
            if (cur_field_name.Equals("###"))
                cur_field_name = "ldr";
            string url = Folio_Config_Info.Folio_field_info_url + cur_field_name + "_xx_chi.html";
            webBrowser_field_info.Navigate(url);
        }

        private void EditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
