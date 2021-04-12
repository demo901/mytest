using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mytest
{
    public partial class LoginForm : Form
    {
        const int max_try_times = 5;
        int cur_try_time = 0;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void btn_login_failure_Click(object sender, EventArgs e)
        {
            if (cur_try_time < max_try_times)
            {
                cur_try_time++;
                MessageBox.Show("用户名或密码错误，重试第 " + cur_try_time + " 次");
            }
            else
            {
                MessageBox.Show("验证错误次数太多，程序退出。");
                this.DialogResult = DialogResult.No;
                this.Dispose();
            }
        }
    }
}
