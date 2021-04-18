
namespace mytest
{
    partial class SearchForm
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_userName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_groupID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.radioButton_authenStyleIdpass = new System.Windows.Forms.RadioButton();
            this.radioButton_authenStyleOpen = new System.Windows.Forms.RadioButton();
            this.textBox_database = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_serverAddr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_serverPort = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button_search = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_queryWord = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_use = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.HoverSelection = true;
            this.listView1.Location = new System.Drawing.Point(25, 368);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(995, 299);
            this.listView1.TabIndex = 60;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // textBox_password
            // 
            this.textBox_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_password.Location = new System.Drawing.Point(393, 183);
            this.textBox_password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(114, 21);
            this.textBox_password.TabIndex = 59;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(332, 183);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 58;
            this.label7.Text = "密码(&P):";
            // 
            // textBox_userName
            // 
            this.textBox_userName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_userName.Location = new System.Drawing.Point(393, 150);
            this.textBox_userName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_userName.Name = "textBox_userName";
            this.textBox_userName.Size = new System.Drawing.Size(114, 21);
            this.textBox_userName.TabIndex = 57;
            this.textBox_userName.Text = "A110000CLC";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(320, 150);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 56;
            this.label8.Text = "用户名(&U):";
            // 
            // textBox_groupID
            // 
            this.textBox_groupID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_groupID.Location = new System.Drawing.Point(393, 115);
            this.textBox_groupID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_groupID.Name = "textBox_groupID";
            this.textBox_groupID.Size = new System.Drawing.Size(114, 21);
            this.textBox_groupID.TabIndex = 55;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(326, 123);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 54;
            this.label9.Text = "&Group ID:";
            // 
            // radioButton_authenStyleIdpass
            // 
            this.radioButton_authenStyleIdpass.AutoSize = true;
            this.radioButton_authenStyleIdpass.Checked = true;
            this.radioButton_authenStyleIdpass.Location = new System.Drawing.Point(421, 87);
            this.radioButton_authenStyleIdpass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton_authenStyleIdpass.Name = "radioButton_authenStyleIdpass";
            this.radioButton_authenStyleIdpass.Size = new System.Drawing.Size(65, 16);
            this.radioButton_authenStyleIdpass.TabIndex = 53;
            this.radioButton_authenStyleIdpass.TabStop = true;
            this.radioButton_authenStyleIdpass.Text = "&ID/Pass";
            this.radioButton_authenStyleIdpass.UseVisualStyleBackColor = true;
            // 
            // radioButton_authenStyleOpen
            // 
            this.radioButton_authenStyleOpen.AutoSize = true;
            this.radioButton_authenStyleOpen.Location = new System.Drawing.Point(352, 87);
            this.radioButton_authenStyleOpen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton_authenStyleOpen.Name = "radioButton_authenStyleOpen";
            this.radioButton_authenStyleOpen.Size = new System.Drawing.Size(47, 16);
            this.radioButton_authenStyleOpen.TabIndex = 52;
            this.radioButton_authenStyleOpen.Text = "&Open";
            this.radioButton_authenStyleOpen.UseVisualStyleBackColor = true;
            // 
            // textBox_database
            // 
            this.textBox_database.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_database.Location = new System.Drawing.Point(393, 52);
            this.textBox_database.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_database.Name = "textBox_database";
            this.textBox_database.Size = new System.Drawing.Size(384, 21);
            this.textBox_database.TabIndex = 51;
            this.textBox_database.Text = "UCS01U";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(350, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 46;
            this.label2.Text = "地址:";
            // 
            // textBox_serverAddr
            // 
            this.textBox_serverAddr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_serverAddr.Location = new System.Drawing.Point(393, 2);
            this.textBox_serverAddr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_serverAddr.Name = "textBox_serverAddr";
            this.textBox_serverAddr.Size = new System.Drawing.Size(384, 21);
            this.textBox_serverAddr.TabIndex = 47;
            this.textBox_serverAddr.Text = "202.96.31.28";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(338, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 48;
            this.label3.Text = "端口号:";
            // 
            // textBox_serverPort
            // 
            this.textBox_serverPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_serverPort.Location = new System.Drawing.Point(393, 29);
            this.textBox_serverPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_serverPort.Name = "textBox_serverPort";
            this.textBox_serverPort.Size = new System.Drawing.Size(384, 21);
            this.textBox_serverPort.TabIndex = 49;
            this.textBox_serverPort.Text = "9991";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(326, 61);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 50;
            this.label6.Text = "数据库名:";
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(278, 305);
            this.button_search.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(133, 40);
            this.button_search.TabIndex = 45;
            this.button_search.Text = "检索";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(212, 268);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 44;
            this.label5.Text = "检索途径:";
            // 
            // textBox_queryWord
            // 
            this.textBox_queryWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_queryWord.Location = new System.Drawing.Point(288, 229);
            this.textBox_queryWord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_queryWord.Name = "textBox_queryWord";
            this.textBox_queryWord.Size = new System.Drawing.Size(489, 21);
            this.textBox_queryWord.TabIndex = 43;
            this.textBox_queryWord.Text = "978-7-80218-517-3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(224, 232);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 42;
            this.label4.Text = "检索词:";
            // 
            // comboBox_use
            // 
            this.comboBox_use.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_use.FormattingEnabled = true;
            this.comboBox_use.Location = new System.Drawing.Point(288, 265);
            this.comboBox_use.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox_use.Name = "comboBox_use";
            this.comboBox_use.Size = new System.Drawing.Size(489, 20);
            this.comboBox_use.TabIndex = 41;
            this.comboBox_use.Text = "ISBN -";
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 698);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_userName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_groupID);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.radioButton_authenStyleIdpass);
            this.Controls.Add(this.radioButton_authenStyleOpen);
            this.Controls.Add(this.textBox_database);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_serverAddr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_serverPort);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_queryWord);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_use);
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchForm_FormClosing);
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_userName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_groupID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton radioButton_authenStyleIdpass;
        private System.Windows.Forms.RadioButton radioButton_authenStyleOpen;
        private System.Windows.Forms.TextBox textBox_database;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_serverAddr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_serverPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_queryWord;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_use;
    }
}