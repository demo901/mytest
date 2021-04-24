using System;
using System.Windows.Forms;
using System.IO;
using System.Xml;

using DigitalPlatform.Marc;

namespace mytest
{
    public partial class EditForm : Form
    {
        string marcType = "unimarc";
        marc2folio m2f = null;

        public EditForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            m2f = new marc2folio();
        }

        //从磁盘加载记录
        private void btn_loadrecord_from_disk_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ISO2709格式文件|*.mrc;*.iso;*.out|所有文件(*.*)|*.*";
            ofd.ValidateNames = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
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
            if (Z39_Record.Rec_Type != null)
                marcType = Z39_Record.Rec_Type;

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
            string json_str = m2f.marc2json_folio(Folio_record.catalog_id, Folio_record.catalog_instanceId, marc_str);

            string result = m2f.data_update_folio(json_str);
            if (result.Equals("OK"))
            {
                MessageBox.Show("更新成功");
            }
            else
            {
                MessageBox.Show("保存记录失败");
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

        private void EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true; //取消关闭操作
        }

        private void EditForm_Activated(object sender, EventArgs e)
        {
            if (Z39_Record.Rec_Status == false && Folio_record.Rec_Status == false)
                return;

            marcEditor1.MarcDefDom = null;
            if (Z39_Record.Rec_Status == true)
            {
                marcEditor1.Marc = Z39_Record.Rec_Data;
                Z39_Record.Rec_Status = false;
            }
            if(Folio_record.Rec_Status == true)
            {
                marcEditor1.Marc = Folio_record.Rec_Data;
                Folio_record.Rec_Status = false;
            }
            
        }

    }
}
