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
        static int max_record_count = 20;//定义一次获取的最大记录数量
        string marcType = "unimarc";
        private SearchForm sf = Program.SearchForm;
        marc2folio m2f = null;
        string[] pending_catalog_id = null;
        string[] pending_catalog_instanceId = null;
        string cur_id = "";
        string cur_instanceId = "";

        public EditForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pending_catalog_id = new string[max_record_count];
            pending_catalog_instanceId = new string[max_record_count];

            m2f = new marc2folio();
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
                marcEditor1.MarcDefDom = null;
                marcEditor1.Marc = m2f.dcmarcText;
                Z39_Record.Rec_Status = false;
            }
        }
        
        private void marcEditor1_GetConfigDom(object sender, DigitalPlatform.Marc.GetConfigDomEventArgs e)
        {
            // e.Path 中可能是 "marcdef" 或 "marcvaluelist"
            if(Z39_Record.Rec_Type != null)
                marcType = Z39_Record.Rec_Type;

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
            string json_str = m2f.marc2json_folio(cur_id, cur_instanceId, marc_str);

            string result = m2f.data_update_folio(json_str);
            Console.WriteLine(result);
            if (result.Equals("OK"))
            {
                MessageBox.Show("更新成功");
            }
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
            string jsonText = "";
            jsonText = m2f.task_fetch("PENDING_CATALOG", 1, 20);

            JObject jo = (JObject)JsonConvert.DeserializeObject(jsonText);

            string res_code = jo["code"].ToString();
            string res_mess = jo["message"].ToString();
            string res_succ = jo["success"].ToString();

            if(!res_code.Equals("200") || !res_mess.Equals("SUCCESS") || !res_succ.Equals("True"))
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
            this.listView2.Columns.Add("NAME", 50);
            this.listView2.Columns.Add("ISBN",100);
            this.listView2.Columns.Add("CIP", 100);
            this.listView2.Columns.Add("出版社",150);
            this.listView2.Columns.Add("题名",500);
            this.listView2.Columns.Add("endTaskTime", 100);

            this.listView2.BeginUpdate();
            int i = 0;
            foreach (var t in content)
            {
                string name = t["name"].ToString();
                string isbn = t["isbn"].ToString();
                string cip = t["cip"].ToString();
                string pub = t["publisher"].ToString();
                string title = t["title"].ToString();
                string endtime = t["endTaskTime"].ToString();

                pending_catalog_instanceId[i] = t["instanceId"].ToString();//将instanceId保存到全局变显数组中
                pending_catalog_id[i] = t["id"].ToString();//将id保存到全局变显数组中

                ListViewItem lvi = new ListViewItem();
                lvi.Text = (i+1).ToString();
                lvi.SubItems.Add(name);
                lvi.SubItems.Add(isbn);
                lvi.SubItems.Add(cip);
                lvi.SubItems.Add(pub);
                lvi.SubItems.Add(title);
                lvi.SubItems.Add(endtime);
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
            marcEditor1.Marc = "";

            //加载记录到编辑器
            cur_instanceId = pending_catalog_instanceId[rec_id];
            cur_id = pending_catalog_id[rec_id];

            m2f.data_fetch(pending_catalog_instanceId[rec_id]);
            bool bFound = true;
            if (m2f.jsonText.IndexOf("Couldn't find Record with INSTANCE id") != -1)
            {
                MessageBox.Show("获取MARC数据失败");
                bFound = false;
            }
            if (m2f.jsonText.IndexOf("code\":200,\"message\":\"SUCCESS\",\"success\":true}") != -1)
            {
                MessageBox.Show("未找到MARC数据");
                bFound = false;
            }
            
            if(bFound == true)
            {
                try
                {
                    m2f.json_data_folio_process();
                    m2f.marc2dc_folio();

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
                catch(Exception ex)
                {
                    MessageBox.Show("加载MARC数据异常");
                    ex.ToString();
                }
            }

            //加载图片
            string jsonText = "";
            jsonText = m2f.image_fetch(pending_catalog_instanceId[rec_id]);
            JObject jo = (JObject)JsonConvert.DeserializeObject(jsonText);

            string res_code = jo["code"].ToString();
            string res_mess = jo["message"].ToString();
            string res_succ = jo["success"].ToString();

            if (!res_code.Equals("200") || !res_mess.Equals("SUCCESS") || !res_succ.Equals("True"))
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
