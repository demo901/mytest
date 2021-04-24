using System;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Text;

using DigitalPlatform.Marc;

namespace mytest
{
    public partial class EditForm : Form
    {
        marc2folio m2f = null;//提供数据转换功能的类
        Encoding _encoding = Encoding.GetEncoding("UTF-8");

        public EditForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            m2f = new marc2folio();
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

                marcEditor1.MarcDefDom = null;
                marcEditor1.Marc = strMARC;

                Z39_Record.rec_status = false;
                Folio_Record.rec_status = false;
            }
        }

        private void marcEditor1_GetConfigDom(object sender, DigitalPlatform.Marc.GetConfigDomEventArgs e)
        {
            // e.Path 中可能是 "marcdef" 或 "marcvaluelist"
            string marcType = "unimarc";
            string filename = "";

            if (Z39_Record.rec_status == true && Z39_Record.rec_type != null)
                marcType = Z39_Record.rec_type;
            if (Folio_Record.rec_status == true && Folio_Record.rec_type != null)
                marcType = Folio_Record.rec_type;
            
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
        //功能测试
        private void btn_fetch_record_Click(object sender, EventArgs e)
        {
            string jsonText = m2f.fetch_json_from_folio(txt_recordid.Text);
            m2f.get_data_from_json(jsonText);

            byte[] str_bytes = _encoding.GetBytes(Folio_Record.rawContent);

            int nRet = MarcLoader.ConvertIso2709ToMarcString(str_bytes,
                _encoding,
                true,
                out string strMARC,
                out string strError);
            if (nRet == -1)
            {
                MessageBox.Show("转换记录失败: " + strError);
                return;
            }

            Z39_Record.rec_type = "unimarc";
            MarcRecord marc_record = new MarcRecord(strMARC);
            string content = marc_record.select("field[@name='200']/subfield[@name='a']").FirstContent;
            if (content == null)
            {
                Z39_Record.rec_type = "usmarc";
            }
            marcEditor1.MarcDefDom = null;
            marcEditor1.Marc = strMARC;
            Z39_Record.rec_status = false;
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
        //禁止直接关闭当前窗口
        private void EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true; //取消关闭操作
        }

        //窗口激活时刷新编辑器里的数据
        private void EditForm_Activated(object sender, EventArgs e)
        {
            if (Z39_Record.rec_status == false && Folio_Record.rec_status == false)
                return;

            marcEditor1.MarcDefDom = null;
            if (Z39_Record.rec_status == true)
            {
                marcEditor1.Marc = Z39_Record.rec_data;
                Z39_Record.rec_status = false;
            }
            if(Folio_Record.rec_status == true)
            {
                marcEditor1.Marc = Folio_Record.rec_data;
                Folio_Record.rec_status = false;
            }
        }
    }
}
