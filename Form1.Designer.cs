
namespace mytest
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.marcEditor1 = new DigitalPlatform.Marc.MarcEditor();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_recordid = new System.Windows.Forms.TextBox();
            this.btn_fetch_record = new System.Windows.Forms.Button();
            this.btn_save_record = new System.Windows.Forms.Button();
            this.btn_200f_2_7xx = new System.Windows.Forms.Button();
            this.btn_200g_2_702 = new System.Windows.Forms.Button();
            this.comboBox_use = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_queryWord = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_search = new System.Windows.Forms.Button();
            this.textBox_database = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_serverAddr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_serverPort = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.radioButton_authenStyleIdpass = new System.Windows.Forms.RadioButton();
            this.radioButton_authenStyleOpen = new System.Windows.Forms.RadioButton();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_userName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_groupID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.listView3 = new System.Windows.Forms.ListView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // marcEditor1
            // 
            this.marcEditor1.CaptionFont = new System.Drawing.Font("宋体", 9F);
            this.marcEditor1.ContentBackColor = System.Drawing.SystemColors.Window;
            this.marcEditor1.ContentTextColor = System.Drawing.SystemColors.WindowText;
            this.marcEditor1.CurrentImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.marcEditor1.DocumentOrgX = 0;
            this.marcEditor1.DocumentOrgY = 0;
            this.marcEditor1.FixedSizeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold);
            this.marcEditor1.FocusedField = null;
            this.marcEditor1.FocusedFieldIndex = 0;
            this.marcEditor1.HorzGridColor = System.Drawing.Color.LightGray;
            this.marcEditor1.IndicatorBackColor = System.Drawing.SystemColors.Window;
            this.marcEditor1.IndicatorBackColorDisabled = System.Drawing.SystemColors.Control;
            this.marcEditor1.IndicatorTextColor = System.Drawing.Color.Green;
            this.marcEditor1.Lang = "zh";
            this.marcEditor1.Location = new System.Drawing.Point(12, 83);
            this.marcEditor1.Marc = "";
            this.marcEditor1.MarcDefDom = null;
            this.marcEditor1.Name = "marcEditor1";
            this.marcEditor1.NameBackColor = System.Drawing.SystemColors.Window;
            this.marcEditor1.NameCaptionBackColor = System.Drawing.SystemColors.Info;
            this.marcEditor1.NameCaptionTextColor = System.Drawing.SystemColors.InfoText;
            this.marcEditor1.NameTextColor = System.Drawing.Color.Blue;
            this.marcEditor1.ReadOnly = false;
            this.marcEditor1.SelectionStart = -1;
            this.marcEditor1.Size = new System.Drawing.Size(580, 585);
            this.marcEditor1.TabIndex = 0;
            this.marcEditor1.UiState = "{\"FieldNameCaptionWidth\":100}";
            this.marcEditor1.VertGridColor = System.Drawing.Color.LightGray;
            this.marcEditor1.GetConfigDom += new DigitalPlatform.Marc.GetConfigDomEventHandle(this.marcEditor1_GetConfigDom);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(256, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "从磁盘加载记录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "任务ID";
            // 
            // txt_recordid
            // 
            this.txt_recordid.BackColor = System.Drawing.Color.Black;
            this.txt_recordid.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_recordid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txt_recordid.Location = new System.Drawing.Point(74, 9);
            this.txt_recordid.Name = "txt_recordid";
            this.txt_recordid.Size = new System.Drawing.Size(518, 26);
            this.txt_recordid.TabIndex = 9;
            this.txt_recordid.Text = "55f335f9-d795-42d8-afbf-d80c1c0bb46c";
            // 
            // btn_fetch_record
            // 
            this.btn_fetch_record.ForeColor = System.Drawing.Color.Blue;
            this.btn_fetch_record.Location = new System.Drawing.Point(15, 41);
            this.btn_fetch_record.Name = "btn_fetch_record";
            this.btn_fetch_record.Size = new System.Drawing.Size(118, 28);
            this.btn_fetch_record.TabIndex = 15;
            this.btn_fetch_record.Text = "加载Folio记录";
            this.btn_fetch_record.UseVisualStyleBackColor = true;
            this.btn_fetch_record.Click += new System.EventHandler(this.btn_fetch_record_Click);
            // 
            // btn_save_record
            // 
            this.btn_save_record.ForeColor = System.Drawing.Color.Red;
            this.btn_save_record.Location = new System.Drawing.Point(139, 41);
            this.btn_save_record.Name = "btn_save_record";
            this.btn_save_record.Size = new System.Drawing.Size(111, 28);
            this.btn_save_record.TabIndex = 16;
            this.btn_save_record.Text = "保存到Folio";
            this.btn_save_record.UseVisualStyleBackColor = true;
            this.btn_save_record.Click += new System.EventHandler(this.btn_save_record_Click);
            // 
            // btn_200f_2_7xx
            // 
            this.btn_200f_2_7xx.Location = new System.Drawing.Point(598, 83);
            this.btn_200f_2_7xx.Name = "btn_200f_2_7xx";
            this.btn_200f_2_7xx.Size = new System.Drawing.Size(109, 28);
            this.btn_200f_2_7xx.TabIndex = 19;
            this.btn_200f_2_7xx.Text = "200f->701";
            this.btn_200f_2_7xx.UseVisualStyleBackColor = true;
            this.btn_200f_2_7xx.Click += new System.EventHandler(this.btn_200f_2_7xx_Click);
            // 
            // btn_200g_2_702
            // 
            this.btn_200g_2_702.Location = new System.Drawing.Point(598, 117);
            this.btn_200g_2_702.Name = "btn_200g_2_702";
            this.btn_200g_2_702.Size = new System.Drawing.Size(109, 28);
            this.btn_200g_2_702.TabIndex = 20;
            this.btn_200g_2_702.Text = "200g->702";
            this.btn_200g_2_702.UseVisualStyleBackColor = true;
            this.btn_200g_2_702.Click += new System.EventHandler(this.btn_200g_2_702_Click);
            // 
            // comboBox_use
            // 
            this.comboBox_use.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_use.FormattingEnabled = true;
            this.comboBox_use.Location = new System.Drawing.Point(704, 267);
            this.comboBox_use.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox_use.Name = "comboBox_use";
            this.comboBox_use.Size = new System.Drawing.Size(219, 20);
            this.comboBox_use.TabIndex = 21;
            this.comboBox_use.Text = "ISBN -";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(628, 270);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 24;
            this.label5.Text = "检索途径:";
            // 
            // textBox_queryWord
            // 
            this.textBox_queryWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_queryWord.Location = new System.Drawing.Point(704, 231);
            this.textBox_queryWord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_queryWord.Name = "textBox_queryWord";
            this.textBox_queryWord.Size = new System.Drawing.Size(219, 21);
            this.textBox_queryWord.TabIndex = 23;
            this.textBox_queryWord.Text = "978-7-80218-517-3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(640, 234);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "检索词:";
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(694, 307);
            this.button_search.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(133, 40);
            this.button_search.TabIndex = 25;
            this.button_search.Text = "检索";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // textBox_database
            // 
            this.textBox_database.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_database.Location = new System.Drawing.Point(809, 54);
            this.textBox_database.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_database.Name = "textBox_database";
            this.textBox_database.Size = new System.Drawing.Size(114, 21);
            this.textBox_database.TabIndex = 31;
            this.textBox_database.Text = "UCS01U";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(766, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "地址:";
            // 
            // textBox_serverAddr
            // 
            this.textBox_serverAddr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_serverAddr.Location = new System.Drawing.Point(809, 4);
            this.textBox_serverAddr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_serverAddr.Name = "textBox_serverAddr";
            this.textBox_serverAddr.Size = new System.Drawing.Size(114, 21);
            this.textBox_serverAddr.TabIndex = 27;
            this.textBox_serverAddr.Text = "202.96.31.28";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(754, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 28;
            this.label3.Text = "端口号:";
            // 
            // textBox_serverPort
            // 
            this.textBox_serverPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_serverPort.Location = new System.Drawing.Point(809, 31);
            this.textBox_serverPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_serverPort.Name = "textBox_serverPort";
            this.textBox_serverPort.Size = new System.Drawing.Size(114, 21);
            this.textBox_serverPort.TabIndex = 29;
            this.textBox_serverPort.Text = "9991";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(742, 63);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 30;
            this.label6.Text = "数据库名:";
            // 
            // radioButton_authenStyleIdpass
            // 
            this.radioButton_authenStyleIdpass.AutoSize = true;
            this.radioButton_authenStyleIdpass.Checked = true;
            this.radioButton_authenStyleIdpass.Location = new System.Drawing.Point(837, 89);
            this.radioButton_authenStyleIdpass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton_authenStyleIdpass.Name = "radioButton_authenStyleIdpass";
            this.radioButton_authenStyleIdpass.Size = new System.Drawing.Size(65, 16);
            this.radioButton_authenStyleIdpass.TabIndex = 33;
            this.radioButton_authenStyleIdpass.TabStop = true;
            this.radioButton_authenStyleIdpass.Text = "&ID/Pass";
            this.radioButton_authenStyleIdpass.UseVisualStyleBackColor = true;
            // 
            // radioButton_authenStyleOpen
            // 
            this.radioButton_authenStyleOpen.AutoSize = true;
            this.radioButton_authenStyleOpen.Location = new System.Drawing.Point(768, 89);
            this.radioButton_authenStyleOpen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton_authenStyleOpen.Name = "radioButton_authenStyleOpen";
            this.radioButton_authenStyleOpen.Size = new System.Drawing.Size(47, 16);
            this.radioButton_authenStyleOpen.TabIndex = 32;
            this.radioButton_authenStyleOpen.Text = "&Open";
            this.radioButton_authenStyleOpen.UseVisualStyleBackColor = true;
            // 
            // textBox_password
            // 
            this.textBox_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_password.Location = new System.Drawing.Point(809, 185);
            this.textBox_password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(114, 21);
            this.textBox_password.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(748, 185);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 38;
            this.label7.Text = "密码(&P):";
            // 
            // textBox_userName
            // 
            this.textBox_userName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_userName.Location = new System.Drawing.Point(809, 152);
            this.textBox_userName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_userName.Name = "textBox_userName";
            this.textBox_userName.Size = new System.Drawing.Size(114, 21);
            this.textBox_userName.TabIndex = 37;
            this.textBox_userName.Text = "A110000CLC";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(736, 152);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 36;
            this.label8.Text = "用户名(&U):";
            // 
            // textBox_groupID
            // 
            this.textBox_groupID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_groupID.Location = new System.Drawing.Point(809, 117);
            this.textBox_groupID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_groupID.Name = "textBox_groupID";
            this.textBox_groupID.Size = new System.Drawing.Size(114, 21);
            this.textBox_groupID.TabIndex = 35;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(742, 125);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 34;
            this.label9.Text = "&Group ID:";
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.HoverSelection = true;
            this.listView1.Location = new System.Drawing.Point(598, 369);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(430, 299);
            this.listView1.TabIndex = 40;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // listView2
            // 
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(1034, 6);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(389, 306);
            this.listView2.TabIndex = 41;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // listView3
            // 
            this.listView3.FullRowSelect = true;
            this.listView3.GridLines = true;
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(1040, 370);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(382, 297);
            this.listView3.TabIndex = 42;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1055, 325);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 39);
            this.button2.TabIndex = 43;
            this.button2.Text = "刷新抢单列表";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1235, 325);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(124, 38);
            this.button3.TabIndex = 44;
            this.button3.Text = "刷新派单列表";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1435, 698);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listView3);
            this.Controls.Add(this.listView2);
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
            this.Controls.Add(this.btn_200g_2_702);
            this.Controls.Add(this.btn_200f_2_7xx);
            this.Controls.Add(this.btn_save_record);
            this.Controls.Add(this.btn_fetch_record);
            this.Controls.Add(this.txt_recordid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.marcEditor1);
            this.Name = "Form1";
            this.Text = "数据加工";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DigitalPlatform.Marc.MarcEditor marcEditor1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_recordid;
        private System.Windows.Forms.Button btn_fetch_record;
        private System.Windows.Forms.Button btn_save_record;
        private System.Windows.Forms.Button btn_200f_2_7xx;
        private System.Windows.Forms.Button btn_200g_2_702;
        private System.Windows.Forms.ComboBox comboBox_use;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_queryWord;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.TextBox textBox_database;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_serverAddr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_serverPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioButton_authenStyleIdpass;
        private System.Windows.Forms.RadioButton radioButton_authenStyleOpen;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_userName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_groupID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

