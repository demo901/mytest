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
        const int MAX_RECORD_Z39 = 10;//一次最多取10条Z39记录
        const int MAX_RECORD_FOLIO = 100;//定义一次获取的最大记录数量

        ZClient _zclient = new ZClient();
        IsbnSplitter _isbnSplitter = null;
        UseCollection _useList = new UseCollection();
        TargetInfo _targetInfo = new TargetInfo();
        long _resultCount = 0;   // Z39检索命中条数
        int _fetched = 0;   // 已经 Present 获取的条数
        string[] _z39_record_data = new string[MAX_RECORD_Z39];
        string[] _z39_record_type = new string[MAX_RECORD_Z39];

        string[] _catalog_id = new string[MAX_RECORD_FOLIO];
        string[] _catalog_instanceId = new string[MAX_RECORD_FOLIO];
        int _saved_Field_Index = 0;//编辑框里上一次被选中的字段索引值

        marc2folio m2f = new marc2folio();//提供数据转换功能
        Encoding _encoding = Encoding.GetEncoding("UTF-8");
        string marcType = "unimarc";
        string jsonText = "";

        Folio_Record[] folio_record = new Folio_Record[MAX_RECORD_FOLIO];

        public EditForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Result result = LoadEnvironment();
            if (result.Value == -1)
                MessageBox.Show(this, result.ErrorInfo);

            for (int i = 0; i < MAX_RECORD_FOLIO; i++)
            {
                folio_record[i] = new Folio_Record();
                folio_record[i].saved = true;
                folio_record[i].used = false;
            }
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
        public string BuildQueryXml()
        {
            XmlDocument dom = new XmlDocument();
            dom.LoadXml("<root />");
            {
                XmlElement node = dom.CreateElement("line");
                dom.DocumentElement.AppendChild(node);

                node.SetAttribute("logic", "OR");
                node.SetAttribute("word", this.textBox_queryWord.Text);
                node.SetAttribute("from", this.comboBox_use.Text);
            }

            return dom.OuterXml;
        }
        int GetAuthentcationMethod()
        {
            return (this.radioButton_authenStyleIdpass.Checked ? 1 : 0);
        }
        //执行Z39检索
        private async void button_search_Click(object sender, EventArgs e)
        {
            listView_Z39_Result.Clear();

            this.listView_Z39_Result.Columns.Add("序号");
            this.listView_Z39_Result.Columns.Add("ISBN");
            this.listView_Z39_Result.Columns.Add("出版年");
            this.listView_Z39_Result.Columns.Add("题名");
            this.listView_Z39_Result.Columns.Add("作者");
            this.listView_Z39_Result.Columns.Add("出版社");

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
        //下载Z39记录
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
        //将下载的Z39记录填充到列表里
        void AppendMarcRecords(RecordCollection records, Encoding encoding, int start_index)
        {
            if (records == null)
                return;
            int i = start_index;

            listView_Z39_Result.BeginUpdate();
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
                listView_Z39_Result.Items.Add(lvi);

                i++;
            }
            listView_Z39_Result.EndUpdate();
        }
        //双击当前Z39记录加载到Marc编辑器
        private void listView_Z39_Result_DoubleClick(object sender, EventArgs e)
        {
            int selectCount = listView_Z39_Result.SelectedItems.Count;
            if (selectCount == 0)
                return; //没选中，不做响应
            if (selectCount > 1)//不允许选中多条
                return;

            int rec_id = Convert.ToInt32(listView_Z39_Result.SelectedItems[0].Text);

            marcType = _z39_record_type[rec_id];
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
                //需要判断记录类型
                //在这里合并版本馆记录
                marcEditor1.MarcDefDom = null;
                marcEditor1.Marc = strMARC;
            }
        }
        //根据Marc记录类型加载不同的字段提示信息
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
        
        //保存所有已更改数据到服务器
        private void btn_save_record_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MAX_RECORD_FOLIO; i++)
            {
                if (folio_record[i].used == false || folio_record[i].saved == true)
                    continue;

                byte[] in_bytes = _encoding.GetBytes(folio_record[i].dp2marcStr);
                int nRet = MarcUtil.BuildISO2709Record(in_bytes, out byte[] out_bytes);
                if (nRet != 0)
                {
                    MessageBox.Show("转换ISO2709格式失败，未能保存数据到服务器。");
                    return;
                }

                string marc_str = _encoding.GetString(out_bytes);
                string json_str = m2f.marc2json_for_folio(folio_record[i].folio_id, folio_record[i].instanceId, marc_str);
                string result = m2f.update_folio(json_str);
                
                //需要检查返回值，判断是否写入成功

            }
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

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl2.SelectedIndex)
            {
                case 0:
                    if (listView_Folio_catalog_waiting.Items.Count == 0)
                    {
                        //获取待编目数据列表
                        fetch_data_from_folio_api("PENDING_CATALOG", listView_Folio_catalog_waiting);
                    }
                    break;
                case 1:
                    if (listView_Folio_cataloging.Items.Count == 0)
                    {
                        //获取编目中数据列表
                        fetch_data_from_folio_api("PROCESS_CATALOG", listView_Folio_cataloging);
                    }
                    break;
                case 2:
                    if (listView_Folio_failed_review.Items.Count == 0)
                    {
                        //获取审核未通过的列表
                        fetch_data_from_folio_api("FAILED_REVIEW", listView_Folio_failed_review);
                    }
                    break;
                case 3:
                    break;
                default:
                    break;
            }

        }
        private void fetch_data_from_folio_api(string code,ListView lstview)
        {
            string jsonTMP = m2f.task_fetch(code, 1, MAX_RECORD_FOLIO);
            if(jsonTMP == "")
            {
                MessageBox.Show("获取任务数据失败");
                return;
            }

            JObject jo = (JObject)JsonConvert.DeserializeObject(jsonTMP);

            string res_code = jo["code"].ToString();
            string res_mess = jo["message"].ToString();
            string res_succ = jo["success"].ToString();
            if (!res_code.Equals("200") || !res_mess.Equals("SUCCESS") || !res_succ.Equals("True"))
            {
                MessageBox.Show("未获取到数据");
                return;
            }

            var page_Num = jo["data"]["pageNum"];
            var page_Size = jo["data"]["pageSize"];
            var pages = jo["data"]["pages"];
            var total = jo["data"]["total"];
            var content = jo["data"]["content"];
            if (content == null)
            {
                MessageBox.Show("未找到数据");
                return;
            }

            lstview.Clear();
            lstview.Columns.Add("序号", 50);
            lstview.Columns.Add("NAME", 50);
            lstview.Columns.Add("ISBN", 100);
            lstview.Columns.Add("CIP", 100);
            lstview.Columns.Add("endTaskTime", 100);
            lstview.Columns.Add("出版社", 150);
            lstview.Columns.Add("题名", 300);

            lstview.BeginUpdate();
            int i = 0;
            int index_unused_obj = -1;
            foreach (var t in content)
            {
                //找一个未使用的对象保存数据
                for(int j = 0; j < MAX_RECORD_FOLIO; j++)
                {
                    if (folio_record[j].used == false)
                    {
                        index_unused_obj = j;
                        break;
                    }
                }
                if(index_unused_obj == -1)
                {
                    MessageBox.Show("编辑记录数量超过最大值，请关闭部分记录后重试。");
                    lstview.EndUpdate();
                    return;
                }
                string name = t["name"].ToString();
                string isbn = t["isbn"].ToString();
                string cip = t["cip"].ToString();
                string pub = t["publisher"].ToString();
                string title = t["title"].ToString();
                string endtime = t["endTaskTime"].ToString();

                folio_record[index_unused_obj].instanceId = t["instanceId"].ToString();//将instanceId保存到全局变量
                folio_record[index_unused_obj].folio_id = t["id"].ToString();//将id保存到全局变量
                folio_record[index_unused_obj].used = true;
                folio_record[index_unused_obj].id = i;

                ListViewItem lvi = new ListViewItem();
                lvi.Text = (i + 1).ToString();
                lvi.SubItems.Add(name);
                lvi.SubItems.Add(isbn);
                lvi.SubItems.Add(cip);
                lvi.SubItems.Add(endtime);
                lvi.SubItems.Add(pub);
                lvi.SubItems.Add(title);
                lstview.Items.Add(lvi);
                i++;
            }
            lstview.EndUpdate();
        }
        //双击列表行，加载MARC数据和编目时使用的图片
        private void listView_Folio_Result_DoubleClick(object sender, EventArgs e)
        {
            int selectCount = listView_Folio_catalog_waiting.SelectedItems.Count; //选中的行数目
            if (selectCount != 1)
                return; //没选中或多选，不做响应

            int rec_id = Convert.ToInt32(listView_Folio_catalog_waiting.SelectedItems[0].Text) - 1;

            load_marc_from_folio(rec_id);
            load_image_from_folio(rec_id);
        }
        //加载Folio数据
        private void load_marc_from_folio(int rec_id)
        {
            int index_cur_obj = 0;//当前记录保存的对象索引
            for (int i = 0; i < MAX_RECORD_FOLIO; i++)
            {
                if(folio_record[i].id == rec_id)
                {
                    index_cur_obj = i;
                    break;
                }
            }
            string jsonText = m2f.fetch_json_from_folio(folio_record[index_cur_obj].instanceId);
            
            if (jsonText == "")
            {
                MessageBox.Show("未找到MARC数据");
                return;
            }
            if (jsonText.IndexOf("Couldn't find Record with INSTANCE id") != -1)
            {
                MessageBox.Show("获取MARC数据失败");
                return;
            }
            if (jsonText.IndexOf("code\":200,\"message\":\"SUCCESS\",\"success\":true}") != -1)
            {
                MessageBox.Show("未找到MARC数据");
                return;
            }

            m2f.get_data_from_json(jsonText,
                out folio_record[index_cur_obj].code,
                out folio_record[index_cur_obj].message,
                out folio_record[index_cur_obj].success,
                out folio_record[index_cur_obj].folio_id,
                out folio_record[index_cur_obj].rawContent,
                out folio_record[index_cur_obj].marcContent);

            byte[] str_bytes = _encoding.GetBytes(folio_record[index_cur_obj].rawContent);
            int nRet = MarcLoader.ConvertIso2709ToMarcString(str_bytes,
                _encoding,
                true,
                out string strMARC,
                out string strError);
            if (nRet == -1)
            {
                MessageBox.Show("转换ISO2709记录到MARC编辑器失败: " + strError);
                return;
            }
            if (strMARC == "")
            {
                MessageBox.Show("转换ISO2709记录到MARC编辑器失败: 记录格式错误");
                return;
            }

            marcType = "unimarc";
            MarcRecord marc_record = new MarcRecord(strMARC);
            string content = marc_record.select("field[@name='200']/subfield[@name='a']").FirstContent;
            if (content == null)
                marcType = "usmarc";

            marcEditor1.MarcDefDom = null;
            marcEditor1.Marc = strMARC;
        }
        //加载图片
        private void load_image_from_folio(int rec_id)
        {
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
            webBrowser_images.DocumentText = html;
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
