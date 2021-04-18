using System;
using System.Windows.Forms;
using System.IO;
using System.Xml;

using DigitalPlatform.Marc;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace mytest
{
    public partial class EditForm : Form
    {
        static int max_record_count = 10;//定义一次获取的最大记录数量

        private SearchForm sf = Program.SearchForm;
        marc2folio m2f = null;
        string[] pending_catalog_array = null;

        public EditForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pending_catalog_array = new string[max_record_count];

            m2f = new marc2folio(
                Folio_info.Folio_uname, 
                Folio_info.Folio_upass, 
                Folio_info.Folio_tenant,
                Folio_info.Folio_token_url,
                Folio_info.Folio_data_url,
                Folio_info.Folio_catalog_url,
                Folio_info.Folio_image_url);
            m2f.token_fetch();
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
                Z39_Record.Rec_Status = false;
            }
        }
        
        private void marcEditor1_GetConfigDom(object sender, DigitalPlatform.Marc.GetConfigDomEventArgs e)
        {
            // e.Path 中可能是 "marcdef" 或 "marcvaluelist"
            string marcType = Z39_Record.Rec_Type;

            //MessageBox.Show("marcType:" + marcType + ",e.path=" + e.Path);

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
        private void btn_fetch_record_Click(object sender, EventArgs e)
        {
            m2f.data_fetch(txt_recordid.Text);
            m2f.json_data_process();
            m2f.marc2dc();

            Z39_Record.Rec_Type = "unimarc";
            MarcRecord marc_record = new MarcRecord(m2f.dcmarcText);
            string content = marc_record.select("field[@name='200']/subfield[@name='a']").FirstContent;
            if (content == null)
            {
                Z39_Record.Rec_Type = "usmarc";
            }
            marcEditor1.MarcDefDom = null;
            marcEditor1.Marc = m2f.dcmarcText;
            Z39_Record.Rec_Status = false;
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
        private void btn_search_Click(object sender, EventArgs e)
        {
            if (sf.Visible == true)
            {
                sf.Activate();
                return;
            }

            sf.MdiParent = Program.MainForm;
            sf.Show();
        }

        private void EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true; //取消关闭操作
        }

        private void EditForm_Activated(object sender, EventArgs e)
        {
            //MessageBox.Show("显示");
            try
            {
                if (Z39_Record.Rec_Type == null)
                    return;
                if (Z39_Record.Rec_Data == null)
                    return;
            }catch(Exception ex)
            {
                ex.ToString();
                return;
            }
            if (Z39_Record.Rec_Status == false)
                return;

            marcEditor1.MarcDefDom = null;
            marcEditor1.Marc = Z39_Record.Rec_Data;
            Z39_Record.Rec_Status = false;
        }

        private void btn_catalog_waiting_Click(object sender, EventArgs e)
        {
            string jsonText = "";//m2f.catalog_fetch("PENDING_CATALOG", 1, 10);
            jsonText = "{\"code\":200,\"message\":\"SUCCESS\",\"data\":{\"pageNum\":1,\"pageSize\":10,\"pages\":1,\"total\":1,\"content\":[{\"id\":\"7d2a8497-2d29-42fa-a25b-1f8cd68c1cd2\",\"name\":\"C16841\",\"title\":\"中国史\",\"cip\":\"2019010108\",\"publisher\":\"云南人民出版社\",\"status\":\"PENDING_CATALOG\",\"endTaskTime\":\"2021-04-19 13:25:52\",\"cataUserId\":\"刘梦洁1\",\"orgId\":\"北京总馆1\",\"isbn\":\"9787222180093\",\"instanceId\":\"e0c31bf3-a2da-4f34-9918-853e002abd35\"},{\"id\":\"7d2a8497-2d29-42fa-a25b-1f8cd68c1cd3\",\"name\":\"C16842\",\"title\":\"中国史2\",\"cip\":\"2019010109\",\"publisher\":\"云南人民出版社2\",\"status\":\"PENDING_CATALOG\",\"endTaskTime\":\"2021-04-20 13:25:52\",\"cataUserId\":\"刘梦洁2\",\"orgId\":\"北京总馆2\",\"isbn\":\"9787222180094\",\"instanceId\":\"e0c31bf3-a2da-4f34-9918-853e002abd36\"}]},\"success\":true}";

            JObject jo = (JObject)JsonConvert.DeserializeObject(jsonText);

            string res_code = jo["code"].ToString();
            string res_mess = jo["message"].ToString();
            string res_succ = jo["success"].ToString();

            if(!res_code.Equals("200") || !res_mess.Equals("SUCCESS"))
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
            this.listView2.Columns.Add("序号",50);
            this.listView2.Columns.Add("ISBN",100);
            this.listView2.Columns.Add("出版社",150);
            this.listView2.Columns.Add("题名",500);

            this.listView2.BeginUpdate();
            int i = 0;
            foreach (var t in content)
            {
                string title = t["title"].ToString();
                string pub = t["publisher"].ToString();
                string isbn = t["isbn"].ToString();

                pending_catalog_array[i] = t["instanceId"].ToString();//将ID保存到全局变显数组中

                ListViewItem lvi = new ListViewItem();
                lvi.Text = (i+1).ToString();
                lvi.SubItems.Add(isbn);
                lvi.SubItems.Add(pub);
                lvi.SubItems.Add(title);
                listView2.Items.Add(lvi);
                i++;
            }
            this.listView2.EndUpdate();
        }

        private void listView2_Click(object sender, EventArgs e)
        {
            int selectCount = listView2.SelectedItems.Count; //选中的行数目
            if (selectCount == 0)
                return; //没选中，不做响应

            int rec_id = Convert.ToInt32(listView2.SelectedItems[0].Text) - 1;
            //MessageBox.Show(rec_id.ToString() + "->" + pending_catalog_array[rec_id]);
            string jsonText = "{\"code\":200,\"message\":\"SUCCESS\",\"data\":[{\"id\":\"6b331104-6922-4faa-abff-b4111273d83d\",\"imageName\":\"C16841_A01.jpg\",\"imageCaption\":\"COVER\",\"imageUrl\":\"http://dev.jiatu.info:8777/M00/00/2F/wKgBwGB1XhGEVrmcAAAAAFKylDQ936.jpg?token=2c2171a98e62a7c52c8d7e9582c47131&ts=1618756785\"},{\"id\":\"a9cce472-fba3-4889-878d-4f1c54285e7b\",\"imageName\":\"C16841_A02.jpg\",\"imageCaption\":\"COVER\",\"imageUrl\":\"http://dev.jiatu.info:8777/M00/00/2F/wKgBwGB1XhGECWwYAAAAAN4NTwY510.jpg?token=8da5a157e857148f424950ed8c59f3a5&ts=1618756785\"},{\"id\":\"7e624627-d6d5-49d4-8827-eefaad9f7903\",\"imageName\":\"C16841_B01.jpg\",\"imageCaption\":\"SPINE\",\"imageUrl\":\"http://dev.jiatu.info:8777/M00/00/2F/wKgBwGB1XhGEaidcAAAAALd276o323.jpg?token=b840e913b5d7363e13ba2ab0de7d28a4&ts=1618756785\"},{\"id\":\"857f0e6c-971e-42d3-9816-9750f3e8b00b\",\"imageName\":\"C16841_C01.jpg\",\"imageCaption\":\"FRONT_PAGE\",\"imageUrl\":\"http://dev.jiatu.info:8777/M00/00/2F/wKgBwGB1XhGEee9rAAAAABHW06A394.jpg?token=4e927af0d6925498afaeb0bdc8b861d4&ts=1618756785\"}],\"success\":true}";
            JObject jo = (JObject)JsonConvert.DeserializeObject(jsonText);

            string res_code = jo["code"].ToString();
            string res_mess = jo["message"].ToString();
            string res_succ = jo["success"].ToString();

            if (!res_code.Equals("200") || !res_mess.Equals("SUCCESS"))
            {
                MessageBox.Show("获取图片数据失败");
                return;
            }

            string html = "";
            foreach(var t in jo["data"])
            {
                string img_title = t["imageCaption"].ToString();
                string img_url = t["imageUrl"].ToString();
                html += img_title + "<img src=" + img_url + "><br>";
            }
            webBrowser1.DocumentText = html;
        }
    }
}
