using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace mytest
{
    public partial class LoginForm : Form
    {
        const int max_try_times = 5;
        int cur_try_time = 0;
        marc2folio m2f = null;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if(Folio_Config_Read() == false)
            {
                MessageBox.Show("未找到配置文件 folio.config ");
                return;
            }
            Folio_info.Folio_uname = txt_username.Text.Trim();
            Folio_info.Folio_upass = txt_userpass.Text.Trim();

            m2f = new marc2folio(
               Folio_info.Folio_uname,
               Folio_info.Folio_upass,
               Folio_info.Folio_tenant,
               Folio_info.Folio_token_url,
               Folio_info.Folio_data_url,
               Folio_info.Folio_catalog_url,
               Folio_info.Folio_image_url);
            m2f.token_fetch();
            if(m2f.cur_Token == "")
            {
                if (cur_try_time < max_try_times)
                {
                    cur_try_time++;
                    MessageBox.Show("用户名或密码错误，重试第 " + cur_try_time + " 次");
                    return;
                }
                else
                {
                    MessageBox.Show("验证错误次数太多，程序退出。");
                    this.DialogResult = DialogResult.No;
                    this.Dispose();
                    Environment.Exit(0);
                }
            }
            Folio_info.Folio_token = m2f.cur_Token;//将获取的Token保存到全局变量
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void btn_login_failure_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private bool Folio_Config_Read()
        {
            if (!File.Exists("folio.config")) //读取保存的folio配置文件
            {   
                return false;
            }
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

                    key = line.Substring(0, pos).Trim();
                    val = line.Substring(pos + 1).Trim();

                    if (key.Equals("FOLIO_TENANT"))
                        Folio_info.Folio_tenant = val;
                    if (key.Equals("FOLIO_TOKEN_URL"))
                        Folio_info.Folio_token_url = val;
                    if (key.Equals("FOLIO_DATA_URL"))
                        Folio_info.Folio_data_url = val;
                    if (key.Equals("FOLIO_DATA_URL"))
                        Folio_info.Folio_catalog_url = val;
                    if (key.Equals("FOLIO_IMAGE_URL"))
                        Folio_info.Folio_image_url = val;
                    if (key.Equals("FOLIO_TENANT_CATALOG"))
                        Folio_info.Folio_catalog_url = val;
                }
            }
            return true;
        }
    }
}
