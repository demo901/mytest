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
                MessageBox.Show("未找到配置文件 folio.config，确认配置正确后再重新运行程序。");
                return;
            }
            Folio_Config_Info.Folio_uname = txt_username.Text.Trim();
            Folio_Config_Info.Folio_upass = txt_userpass.Text.Trim();
            Folio_Config_Info.Folio_token = "";

            m2f = new marc2folio();
            m2f.token_fetch();
            if(Folio_Config_Info.Folio_token == "")
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
                        Folio_Config_Info.Folio_tenant = val;
                    if (key.Equals("FOLIO_TOKEN_URL"))
                        Folio_Config_Info.Folio_token_url = val;
                    if (key.Equals("FOLIO_DATA_GET_URL"))
                        Folio_Config_Info.Folio_data_get_url = val;
                    if (key.Equals("FOLIO_DATA_ADD_URL"))
                        Folio_Config_Info.Folio_data_add_url = val;
                    if (key.Equals("FOLIO_DATA_UPDATE_URL"))
                        Folio_Config_Info.Folio_data_update_url = val;
                    if (key.Equals("FOLIO_TASK_URL"))
                        Folio_Config_Info.Folio_task_url = val;
                    if (key.Equals("FOLIO_IMAGE_URL"))
                        Folio_Config_Info.Folio_image_url = val;
                }
            }
            return true;
        }
    }
}
