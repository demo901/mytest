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
    public partial class EditForm : Form
    {
        private SearchForm sf = Program.SearchForm;

        marc2folio m2f = null;
        string folio_uname = null;
        string folio_upass = null;
        string folio_tenant = null;
        string folio_token_url = null;
        string folio_data_url = null;

        public EditForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
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
            string marcType = Z39_Record.Rec_Type;

            MessageBox.Show("marcType:" + marcType + ",e.path=" + e.Path);

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
            
            marcEditor1.GetConfigDom -= new GetConfigDomEventHandle(marcEditor1_GetConfigDom);
            marcEditor1.GetConfigDom += new GetConfigDomEventHandle(marcEditor1_GetConfigDom);
            marcEditor1.Marc = Z39_Record.Rec_Data;
        }
    }
}
