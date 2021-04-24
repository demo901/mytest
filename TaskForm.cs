using System;
using System.Windows.Forms;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DigitalPlatform.Marc;

namespace mytest
{
    public partial class TaskForm : Form
    {
        static int MAX_RECORD = 20;//定义一次获取的最大记录数量
        string[] pending_catalog_id = null;
        string[] pending_catalog_instanceId = null;
        marc2folio m2f = null;

        string cur_id = "";
        string cur_instanceId = "";

        public TaskForm()
        {
            InitializeComponent();
        }
        private void TaskForm_Load(object sender, EventArgs e)
        {
            pending_catalog_id = new string[MAX_RECORD];
            pending_catalog_instanceId = new string[MAX_RECORD];
            m2f = new marc2folio();
        }
        private void btn_catalog_waiting_Click(object sender, EventArgs e)
        {
            string jsonText = "";
            jsonText = m2f.task_fetch("PENDING_CATALOG", 1, 20);

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
            this.listView2.Columns.Add("序号", 50);
            this.listView2.Columns.Add("NAME", 50);
            this.listView2.Columns.Add("ISBN", 100);
            this.listView2.Columns.Add("CIP", 100);
            this.listView2.Columns.Add("出版社", 150);
            this.listView2.Columns.Add("题名", 500);
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
                lvi.Text = (i + 1).ToString();
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

            //Folio_record.Rec_Status = true;
            //Folio_record.catalog_id = pending_catalog_id[rec_id];
            //Folio_record.catalog_instanceId = pending_catalog_instanceId[rec_id];

            //Program.EditForm.Show();
            //Program.EditForm.Activate();

            //下载记录
            Folio_record.catalog_instanceId = pending_catalog_instanceId[rec_id];
            Folio_record.catalog_id = pending_catalog_id[rec_id];

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

            if (bFound == true)
            {
                try
                {
                    m2f.json_data_folio_process();
                    m2f.marc2dc_folio();

                    Folio_record.Rec_Type = "unimarc";
                    MarcRecord marc_record = new MarcRecord(m2f.dcmarcText);
                    string content = marc_record.select("field[@name='200']/subfield[@name='a']").FirstContent;
                    if (content == null)
                    {
                        Folio_record.Rec_Type = "usmarc";
                    }
                    Folio_record.Rec_Data = m2f.dcmarcText;
                    Folio_record.Rec_Status = true;
                }
                catch (Exception ex)
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

        private void TaskForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true; //取消关闭操作
        }
    }
}
