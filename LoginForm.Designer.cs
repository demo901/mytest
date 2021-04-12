
namespace mytest
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_login = new System.Windows.Forms.Button();
            this.txt_dataurl = new System.Windows.Forms.TextBox();
            this.txt_loginurl = new System.Windows.Forms.TextBox();
            this.txt_tenant = new System.Windows.Forms.TextBox();
            this.txt_userpass = new System.Windows.Forms.TextBox();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_login_failure = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(106, 246);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(135, 28);
            this.btn_login.TabIndex = 28;
            this.btn_login.Text = "登录Folio成功";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // txt_dataurl
            // 
            this.txt_dataurl.Location = new System.Drawing.Point(158, 193);
            this.txt_dataurl.Name = "txt_dataurl";
            this.txt_dataurl.Size = new System.Drawing.Size(312, 21);
            this.txt_dataurl.TabIndex = 27;
            this.txt_dataurl.Text = "https://fsjdev.jiatu.info:8130/source-storage/records";
            // 
            // txt_loginurl
            // 
            this.txt_loginurl.Location = new System.Drawing.Point(158, 153);
            this.txt_loginurl.Name = "txt_loginurl";
            this.txt_loginurl.Size = new System.Drawing.Size(312, 21);
            this.txt_loginurl.TabIndex = 26;
            this.txt_loginurl.Text = "https://fsjdev.jiatu.info:8130/authn/login";
            // 
            // txt_tenant
            // 
            this.txt_tenant.Location = new System.Drawing.Point(158, 113);
            this.txt_tenant.Name = "txt_tenant";
            this.txt_tenant.Size = new System.Drawing.Size(312, 21);
            this.txt_tenant.TabIndex = 25;
            this.txt_tenant.Text = "t00001";
            // 
            // txt_userpass
            // 
            this.txt_userpass.Location = new System.Drawing.Point(158, 73);
            this.txt_userpass.Name = "txt_userpass";
            this.txt_userpass.PasswordChar = '*';
            this.txt_userpass.Size = new System.Drawing.Size(312, 21);
            this.txt_userpass.TabIndex = 24;
            this.txt_userpass.Text = "";
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(158, 33);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(312, 21);
            this.txt_username.TabIndex = 23;
            this.txt_username.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(98, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 22;
            this.label6.Text = "数据URL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(98, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "登录URL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "租户ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "密码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "用户名";
            // 
            // btn_login_failure
            // 
            this.btn_login_failure.Location = new System.Drawing.Point(286, 246);
            this.btn_login_failure.Name = "btn_login_failure";
            this.btn_login_failure.Size = new System.Drawing.Size(135, 28);
            this.btn_login_failure.TabIndex = 29;
            this.btn_login_failure.Text = "登录Folio失败";
            this.btn_login_failure.UseVisualStyleBackColor = true;
            this.btn_login_failure.Click += new System.EventHandler(this.btn_login_failure_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 315);
            this.Controls.Add(this.btn_login_failure);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.txt_dataurl);
            this.Controls.Add(this.txt_loginurl);
            this.Controls.Add(this.txt_tenant);
            this.Controls.Add(this.txt_userpass);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.TextBox txt_dataurl;
        private System.Windows.Forms.TextBox txt_loginurl;
        private System.Windows.Forms.TextBox txt_tenant;
        private System.Windows.Forms.TextBox txt_userpass;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_login_failure;
    }
}