using System;
using System.Windows.Forms;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DigitalPlatform.Marc;

namespace mytest
{
    public partial class TaskForm : Form
    {
        const int MAX_RECORD = 20;//定义一次获取的最大记录数量
        string[] _catalog_id = null;
        string[] _catalog_instanceId = null;
        marc2folio m2f = null;
        Encoding _encoding = Encoding.GetEncoding("UTF-8");

        public TaskForm()
        {
            InitializeComponent();
        }
        private void TaskForm_Load(object sender, EventArgs e)
        {
            _catalog_id = new string[MAX_RECORD];
            _catalog_instanceId = new string[MAX_RECORD];
            m2f = new marc2folio();
        }
        //获取待编目数据列表
        private void btn_catalog_waiting_Click(object sender, EventArgs e)
        {
            tool_check_failer.BackColor = DefaultBackColor;
            tool_catalog_ing.BackColor = DefaultBackColor;
            fetch_data_from_api("PENDING_CATALOG");
            tool_catalog_waiting.BackColor = System.Drawing.SystemColors.Highlight;
        }
        //获取编目中数据列表
        private void btn_catalog_ing_Click(object sender, EventArgs e)
        {
            tool_check_failer.BackColor = DefaultBackColor;
            tool_catalog_waiting.BackColor = DefaultBackColor;
            fetch_data_from_api("PROCESS_CATALOG");
            tool_catalog_ing.BackColor = System.Drawing.SystemColors.Highlight;
        }
        //获取审核未通过的列表
        private void btn_check_failer_Click(object sender, EventArgs e)
        {
            tool_catalog_ing.BackColor = DefaultBackColor;
            tool_catalog_waiting.BackColor = DefaultBackColor;
            fetch_data_from_api("FAILED_REVIEW");
            tool_check_failer.BackColor = System.Drawing.SystemColors.Highlight;
        }
        //通过API获取记录列表，并填充到ListView中
        private void fetch_data_from_api(string code)
        {
            string jsonText = m2f.task_fetch(code, 1, MAX_RECORD);

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
        private void listView2_Click(object sender, EventArgs e)
        {
            int selectCount = listView2.SelectedItems.Count; //选中的行数目
            if (selectCount == 0)
                return; //没选中，不做响应

            int rec_id = Convert.ToInt32(listView2.SelectedItems[0].Text) - 1;

            //保存记录ID到全局变量，编目窗口激活时使用
            Folio_Record.instanceId = _catalog_instanceId[rec_id];
            Folio_Record.id = _catalog_id[rec_id];
            Folio_Record.jsonText = m2f.fetch_json_from_folio(_catalog_instanceId[rec_id]);

            bool bFound = true;
            if (Folio_Record.jsonText.IndexOf("Couldn't find Record with INSTANCE id") != -1)
            {
                MessageBox.Show("获取MARC数据失败");
                bFound = false;
            }
            if (Folio_Record.jsonText.IndexOf("code\":200,\"message\":\"SUCCESS\",\"success\":true}") != -1)
            {
                MessageBox.Show("未找到MARC数据");
                bFound = false;
            }

            if (bFound == true)
            {
                try
                {
                    m2f.get_data_from_json(Folio_Record.jsonText);
                    byte[] str_bytes = _encoding.GetBytes(Folio_Record.rawContent);
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

                    Folio_Record.rec_type = "unimarc";
                    MarcRecord marc_record = new MarcRecord(strMARC);
                    string content = marc_record.select("field[@name='200']/subfield[@name='a']").FirstContent;
                    if (content == null)
                    {
                        Folio_Record.rec_type = "usmarc";
                    }
                    Folio_Record.rec_data = strMARC;
                    Folio_Record.rec_status = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("加载MARC数据异常");
                    ex.ToString();
                }
            }

            //加载图片
            string jsonText = m2f.image_fetch(_catalog_instanceId[rec_id]);
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
