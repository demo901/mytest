
namespace mytest
{
    partial class EditForm
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
            this.btn_loadrecord_from_disk = new System.Windows.Forms.Button();
            this.btn_save_record = new System.Windows.Forms.Button();
            this.btn_200f_2_7xx = new System.Windows.Forms.Button();
            this.btn_200g_2_702 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_task = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.btn_catalog_waiting = new System.Windows.Forms.Button();
            this.btn_check_waiting = new System.Windows.Forms.Button();
            this.btn_catalog_ing = new System.Windows.Forms.Button();
            this.btn_check_failure = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.tabPage_images = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tabPage_fix = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabPage_info = new System.Windows.Forms.TabPage();
            this.webBrowser_field_info = new System.Windows.Forms.WebBrowser();
            this.tabPage_chk_info = new System.Windows.Forms.TabPage();
            this.tabPage_z39 = new System.Windows.Forms.TabPage();
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btn_z39_search = new System.Windows.Forms.Button();
            this.btn_check = new System.Windows.Forms.Button();
            this.btn_save_and_check = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_task.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tabPage_images.SuspendLayout();
            this.tabPage_fix.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage_info.SuspendLayout();
            this.tabPage_z39.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // marcEditor1
            // 
            this.marcEditor1.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.marcEditor1.ContentBackColor = System.Drawing.SystemColors.Window;
            this.marcEditor1.ContentTextColor = System.Drawing.SystemColors.WindowText;
            this.marcEditor1.CurrentImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.marcEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.marcEditor1.Location = new System.Drawing.Point(0, 0);
            this.marcEditor1.MarcDefDom = null;
            this.marcEditor1.Name = "marcEditor1";
            this.marcEditor1.NameBackColor = System.Drawing.SystemColors.Window;
            this.marcEditor1.NameCaptionBackColor = System.Drawing.SystemColors.Info;
            this.marcEditor1.NameCaptionTextColor = System.Drawing.SystemColors.InfoText;
            this.marcEditor1.NameTextColor = System.Drawing.Color.Blue;
            this.marcEditor1.ReadOnly = false;
            this.marcEditor1.SelectionStart = -1;
            this.marcEditor1.Size = new System.Drawing.Size(801, 681);
            this.marcEditor1.TabIndex = 0;
            this.marcEditor1.UiState = "{\"FieldNameCaptionWidth\":100}";
            this.marcEditor1.VertGridColor = System.Drawing.Color.LightGray;
            this.marcEditor1.SelectedFieldChanged += new System.EventHandler(this.marcEditor1_Click);
            this.marcEditor1.GetConfigDom += new DigitalPlatform.Marc.GetConfigDomEventHandle(this.marcEditor1_GetConfigDom);
            // 
            // btn_loadrecord_from_disk
            // 
            this.btn_loadrecord_from_disk.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_loadrecord_from_disk.Location = new System.Drawing.Point(146, 3);
            this.btn_loadrecord_from_disk.Name = "btn_loadrecord_from_disk";
            this.btn_loadrecord_from_disk.Size = new System.Drawing.Size(138, 37);
            this.btn_loadrecord_from_disk.TabIndex = 1;
            this.btn_loadrecord_from_disk.Text = "打开本地记录";
            this.btn_loadrecord_from_disk.UseVisualStyleBackColor = true;
            this.btn_loadrecord_from_disk.Click += new System.EventHandler(this.btn_loadrecord_from_disk_Click);
            // 
            // btn_save_record
            // 
            this.btn_save_record.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_save_record.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_save_record.Location = new System.Drawing.Point(289, 3);
            this.btn_save_record.Name = "btn_save_record";
            this.btn_save_record.Size = new System.Drawing.Size(138, 37);
            this.btn_save_record.TabIndex = 16;
            this.btn_save_record.Text = "保存";
            this.btn_save_record.UseVisualStyleBackColor = true;
            this.btn_save_record.Click += new System.EventHandler(this.btn_save_record_Click);
            // 
            // btn_200f_2_7xx
            // 
            this.btn_200f_2_7xx.Location = new System.Drawing.Point(23, 38);
            this.btn_200f_2_7xx.Name = "btn_200f_2_7xx";
            this.btn_200f_2_7xx.Size = new System.Drawing.Size(109, 28);
            this.btn_200f_2_7xx.TabIndex = 19;
            this.btn_200f_2_7xx.Text = "200f->701";
            this.btn_200f_2_7xx.UseVisualStyleBackColor = true;
            this.btn_200f_2_7xx.Click += new System.EventHandler(this.btn_200f_2_7xx_Click);
            // 
            // btn_200g_2_702
            // 
            this.btn_200g_2_702.Location = new System.Drawing.Point(162, 38);
            this.btn_200g_2_702.Name = "btn_200g_2_702";
            this.btn_200g_2_702.Size = new System.Drawing.Size(109, 28);
            this.btn_200g_2_702.TabIndex = 20;
            this.btn_200g_2_702.Text = "200g->702";
            this.btn_200g_2_702.UseVisualStyleBackColor = true;
            this.btn_200g_2_702.Click += new System.EventHandler(this.btn_200g_2_702_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1332, 729);
            this.splitContainer1.SplitterDistance = 527;
            this.splitContainer1.TabIndex = 21;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_task);
            this.tabControl1.Controls.Add(this.tabPage_images);
            this.tabControl1.Controls.Add(this.tabPage_fix);
            this.tabControl1.Controls.Add(this.tabPage_info);
            this.tabControl1.Controls.Add(this.tabPage_chk_info);
            this.tabControl1.Controls.Add(this.tabPage_z39);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(527, 729);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_task
            // 
            this.tabPage_task.Controls.Add(this.splitContainer3);
            this.tabPage_task.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage_task.Location = new System.Drawing.Point(4, 22);
            this.tabPage_task.Name = "tabPage_task";
            this.tabPage_task.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_task.Size = new System.Drawing.Size(519, 703);
            this.tabPage_task.TabIndex = 0;
            this.tabPage_task.Text = "任务";
            this.tabPage_task.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.btn_catalog_waiting);
            this.splitContainer3.Panel1.Controls.Add(this.btn_check_waiting);
            this.splitContainer3.Panel1.Controls.Add(this.btn_catalog_ing);
            this.splitContainer3.Panel1.Controls.Add(this.btn_check_failure);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.listView2);
            this.splitContainer3.Size = new System.Drawing.Size(513, 697);
            this.splitContainer3.SplitterDistance = 64;
            this.splitContainer3.TabIndex = 52;
            // 
            // btn_catalog_waiting
            // 
            this.btn_catalog_waiting.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_catalog_waiting.Location = new System.Drawing.Point(5, 13);
            this.btn_catalog_waiting.Name = "btn_catalog_waiting";
            this.btn_catalog_waiting.Size = new System.Drawing.Size(118, 36);
            this.btn_catalog_waiting.TabIndex = 0;
            this.btn_catalog_waiting.Text = "待编目列表";
            this.btn_catalog_waiting.UseVisualStyleBackColor = true;
            this.btn_catalog_waiting.Click += new System.EventHandler(this.btn_catalog_waiting_Click);
            // 
            // btn_check_waiting
            // 
            this.btn_check_waiting.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_check_waiting.Location = new System.Drawing.Point(375, 13);
            this.btn_check_waiting.Name = "btn_check_waiting";
            this.btn_check_waiting.Size = new System.Drawing.Size(118, 36);
            this.btn_check_waiting.TabIndex = 3;
            this.btn_check_waiting.Text = "待审核列表";
            this.btn_check_waiting.UseVisualStyleBackColor = true;
            // 
            // btn_catalog_ing
            // 
            this.btn_catalog_ing.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_catalog_ing.Location = new System.Drawing.Point(127, 13);
            this.btn_catalog_ing.Name = "btn_catalog_ing";
            this.btn_catalog_ing.Size = new System.Drawing.Size(118, 36);
            this.btn_catalog_ing.TabIndex = 1;
            this.btn_catalog_ing.Text = "编目中列表";
            this.btn_catalog_ing.UseVisualStyleBackColor = true;
            this.btn_catalog_ing.Click += new System.EventHandler(this.btn_catalog_ing_Click);
            // 
            // btn_check_failure
            // 
            this.btn_check_failure.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_check_failure.Location = new System.Drawing.Point(251, 13);
            this.btn_check_failure.Name = "btn_check_failure";
            this.btn_check_failure.Size = new System.Drawing.Size(118, 36);
            this.btn_check_failure.TabIndex = 2;
            this.btn_check_failure.Text = "审核未通过";
            this.btn_check_failure.UseVisualStyleBackColor = true;
            this.btn_check_failure.Click += new System.EventHandler(this.btn_check_failure_Click);
            // 
            // listView2
            // 
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(0, 0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(513, 629);
            this.listView2.TabIndex = 51;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.DoubleClick += new System.EventHandler(this.listView2_DoubleClick);
            // 
            // tabPage_images
            // 
            this.tabPage_images.Controls.Add(this.webBrowser1);
            this.tabPage_images.Location = new System.Drawing.Point(4, 22);
            this.tabPage_images.Name = "tabPage_images";
            this.tabPage_images.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_images.Size = new System.Drawing.Size(519, 703);
            this.tabPage_images.TabIndex = 1;
            this.tabPage_images.Text = "书刊图片";
            this.tabPage_images.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(513, 697);
            this.webBrowser1.TabIndex = 55;
            // 
            // tabPage_fix
            // 
            this.tabPage_fix.Controls.Add(this.groupBox1);
            this.tabPage_fix.Controls.Add(this.groupBox2);
            this.tabPage_fix.Location = new System.Drawing.Point(4, 22);
            this.tabPage_fix.Name = "tabPage_fix";
            this.tabPage_fix.Size = new System.Drawing.Size(519, 703);
            this.tabPage_fix.TabIndex = 2;
            this.tabPage_fix.Text = "自动生成";
            this.tabPage_fix.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(40, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 228);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "自定义组合一";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_200f_2_7xx);
            this.groupBox2.Controls.Add(this.btn_200g_2_702);
            this.groupBox2.Location = new System.Drawing.Point(40, 291);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(414, 349);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "常见自动生成按钮";
            // 
            // tabPage_info
            // 
            this.tabPage_info.Controls.Add(this.webBrowser_field_info);
            this.tabPage_info.Location = new System.Drawing.Point(4, 22);
            this.tabPage_info.Name = "tabPage_info";
            this.tabPage_info.Size = new System.Drawing.Size(519, 703);
            this.tabPage_info.TabIndex = 3;
            this.tabPage_info.Text = "字段提示";
            this.tabPage_info.UseVisualStyleBackColor = true;
            // 
            // webBrowser_field_info
            // 
            this.webBrowser_field_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser_field_info.Location = new System.Drawing.Point(0, 0);
            this.webBrowser_field_info.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_field_info.Name = "webBrowser_field_info";
            this.webBrowser_field_info.Size = new System.Drawing.Size(519, 703);
            this.webBrowser_field_info.TabIndex = 0;
            // 
            // tabPage_chk_info
            // 
            this.tabPage_chk_info.Location = new System.Drawing.Point(4, 22);
            this.tabPage_chk_info.Name = "tabPage_chk_info";
            this.tabPage_chk_info.Size = new System.Drawing.Size(519, 703);
            this.tabPage_chk_info.TabIndex = 4;
            this.tabPage_chk_info.Text = "MARC检查结果";
            this.tabPage_chk_info.UseVisualStyleBackColor = true;
            // 
            // tabPage_z39
            // 
            this.tabPage_z39.Controls.Add(this.listView1);
            this.tabPage_z39.Controls.Add(this.textBox_password);
            this.tabPage_z39.Controls.Add(this.label7);
            this.tabPage_z39.Controls.Add(this.textBox_userName);
            this.tabPage_z39.Controls.Add(this.label8);
            this.tabPage_z39.Controls.Add(this.textBox_groupID);
            this.tabPage_z39.Controls.Add(this.label9);
            this.tabPage_z39.Controls.Add(this.radioButton_authenStyleIdpass);
            this.tabPage_z39.Controls.Add(this.radioButton_authenStyleOpen);
            this.tabPage_z39.Controls.Add(this.textBox_database);
            this.tabPage_z39.Controls.Add(this.label2);
            this.tabPage_z39.Controls.Add(this.textBox_serverAddr);
            this.tabPage_z39.Controls.Add(this.label3);
            this.tabPage_z39.Controls.Add(this.textBox_serverPort);
            this.tabPage_z39.Controls.Add(this.label6);
            this.tabPage_z39.Controls.Add(this.button_search);
            this.tabPage_z39.Controls.Add(this.label5);
            this.tabPage_z39.Controls.Add(this.textBox_queryWord);
            this.tabPage_z39.Controls.Add(this.label4);
            this.tabPage_z39.Controls.Add(this.comboBox_use);
            this.tabPage_z39.Location = new System.Drawing.Point(4, 22);
            this.tabPage_z39.Name = "tabPage_z39";
            this.tabPage_z39.Size = new System.Drawing.Size(519, 703);
            this.tabPage_z39.TabIndex = 5;
            this.tabPage_z39.Text = "Z39检索";
            this.tabPage_z39.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.HoverSelection = true;
            this.listView1.Location = new System.Drawing.Point(39, 264);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(439, 300);
            this.listView1.TabIndex = 80;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // textBox_password
            // 
            this.textBox_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_password.Location = new System.Drawing.Point(127, 122);
            this.textBox_password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(91, 21);
            this.textBox_password.TabIndex = 79;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 122);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 78;
            this.label7.Text = "密码(&P):";
            // 
            // textBox_userName
            // 
            this.textBox_userName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_userName.Location = new System.Drawing.Point(127, 89);
            this.textBox_userName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_userName.Name = "textBox_userName";
            this.textBox_userName.Size = new System.Drawing.Size(91, 21);
            this.textBox_userName.TabIndex = 77;
            this.textBox_userName.Text = "A110000CLC";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 89);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 76;
            this.label8.Text = "用户名(&U):";
            // 
            // textBox_groupID
            // 
            this.textBox_groupID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_groupID.Location = new System.Drawing.Point(127, 54);
            this.textBox_groupID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_groupID.Name = "textBox_groupID";
            this.textBox_groupID.Size = new System.Drawing.Size(91, 21);
            this.textBox_groupID.TabIndex = 75;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 62);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 74;
            this.label9.Text = "&Group ID:";
            // 
            // radioButton_authenStyleIdpass
            // 
            this.radioButton_authenStyleIdpass.AutoSize = true;
            this.radioButton_authenStyleIdpass.Checked = true;
            this.radioButton_authenStyleIdpass.Location = new System.Drawing.Point(382, 138);
            this.radioButton_authenStyleIdpass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton_authenStyleIdpass.Name = "radioButton_authenStyleIdpass";
            this.radioButton_authenStyleIdpass.Size = new System.Drawing.Size(65, 16);
            this.radioButton_authenStyleIdpass.TabIndex = 73;
            this.radioButton_authenStyleIdpass.TabStop = true;
            this.radioButton_authenStyleIdpass.Text = "&ID/Pass";
            this.radioButton_authenStyleIdpass.UseVisualStyleBackColor = true;
            // 
            // radioButton_authenStyleOpen
            // 
            this.radioButton_authenStyleOpen.AutoSize = true;
            this.radioButton_authenStyleOpen.Location = new System.Drawing.Point(313, 138);
            this.radioButton_authenStyleOpen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton_authenStyleOpen.Name = "radioButton_authenStyleOpen";
            this.radioButton_authenStyleOpen.Size = new System.Drawing.Size(47, 16);
            this.radioButton_authenStyleOpen.TabIndex = 72;
            this.radioButton_authenStyleOpen.Text = "&Open";
            this.radioButton_authenStyleOpen.UseVisualStyleBackColor = true;
            // 
            // textBox_database
            // 
            this.textBox_database.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_database.Location = new System.Drawing.Point(377, 103);
            this.textBox_database.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_database.Name = "textBox_database";
            this.textBox_database.Size = new System.Drawing.Size(120, 21);
            this.textBox_database.TabIndex = 71;
            this.textBox_database.Text = "UCS01U";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 66;
            this.label2.Text = "地址:";
            // 
            // textBox_serverAddr
            // 
            this.textBox_serverAddr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_serverAddr.Location = new System.Drawing.Point(377, 53);
            this.textBox_serverAddr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_serverAddr.Name = "textBox_serverAddr";
            this.textBox_serverAddr.Size = new System.Drawing.Size(120, 21);
            this.textBox_serverAddr.TabIndex = 67;
            this.textBox_serverAddr.Text = "202.96.31.28";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 83);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 68;
            this.label3.Text = "端口号:";
            // 
            // textBox_serverPort
            // 
            this.textBox_serverPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_serverPort.Location = new System.Drawing.Point(377, 80);
            this.textBox_serverPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_serverPort.Name = "textBox_serverPort";
            this.textBox_serverPort.Size = new System.Drawing.Size(120, 21);
            this.textBox_serverPort.TabIndex = 69;
            this.textBox_serverPort.Text = "9991";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(287, 112);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 70;
            this.label6.Text = "数据库名:";
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(377, 188);
            this.button_search.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(110, 40);
            this.button_search.TabIndex = 65;
            this.button_search.Text = "检索";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 216);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 64;
            this.label5.Text = "检索途径:";
            // 
            // textBox_queryWord
            // 
            this.textBox_queryWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_queryWord.Location = new System.Drawing.Point(104, 177);
            this.textBox_queryWord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_queryWord.Name = "textBox_queryWord";
            this.textBox_queryWord.Size = new System.Drawing.Size(225, 21);
            this.textBox_queryWord.TabIndex = 63;
            this.textBox_queryWord.Text = "978-7-80218-517-3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 180);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 62;
            this.label4.Text = "检索词:";
            // 
            // comboBox_use
            // 
            this.comboBox_use.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_use.FormattingEnabled = true;
            this.comboBox_use.Location = new System.Drawing.Point(104, 213);
            this.comboBox_use.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox_use.Name = "comboBox_use";
            this.comboBox_use.Size = new System.Drawing.Size(225, 20);
            this.comboBox_use.TabIndex = 61;
            this.comboBox_use.Text = "ISBN -";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btn_z39_search);
            this.splitContainer2.Panel1.Controls.Add(this.btn_check);
            this.splitContainer2.Panel1.Controls.Add(this.btn_loadrecord_from_disk);
            this.splitContainer2.Panel1.Controls.Add(this.btn_save_and_check);
            this.splitContainer2.Panel1.Controls.Add(this.btn_save_record);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.marcEditor1);
            this.splitContainer2.Size = new System.Drawing.Size(801, 729);
            this.splitContainer2.SplitterDistance = 44;
            this.splitContainer2.TabIndex = 20;
            // 
            // btn_z39_search
            // 
            this.btn_z39_search.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_z39_search.Location = new System.Drawing.Point(3, 3);
            this.btn_z39_search.Name = "btn_z39_search";
            this.btn_z39_search.Size = new System.Drawing.Size(138, 37);
            this.btn_z39_search.TabIndex = 17;
            this.btn_z39_search.Text = "Z39检索记录";
            this.btn_z39_search.UseVisualStyleBackColor = true;
            this.btn_z39_search.Click += new System.EventHandler(this.btn_z39_search_Click);
            // 
            // btn_check
            // 
            this.btn_check.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_check.Location = new System.Drawing.Point(575, 3);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(138, 37);
            this.btn_check.TabIndex = 19;
            this.btn_check.Text = "审核";
            this.btn_check.UseVisualStyleBackColor = true;
            // 
            // btn_save_and_check
            // 
            this.btn_save_and_check.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_save_and_check.Location = new System.Drawing.Point(432, 3);
            this.btn_save_and_check.Name = "btn_save_and_check";
            this.btn_save_and_check.Size = new System.Drawing.Size(138, 37);
            this.btn_save_and_check.TabIndex = 18;
            this.btn_save_and_check.Text = "保存并送审";
            this.btn_save_and_check.UseVisualStyleBackColor = true;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 729);
            this.Controls.Add(this.splitContainer1);
            this.Name = "EditForm";
            this.Text = "数据编辑";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_task.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tabPage_images.ResumeLayout(false);
            this.tabPage_fix.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabPage_info.ResumeLayout(false);
            this.tabPage_z39.ResumeLayout(false);
            this.tabPage_z39.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DigitalPlatform.Marc.MarcEditor marcEditor1;
        private System.Windows.Forms.Button btn_loadrecord_from_disk;
        private System.Windows.Forms.Button btn_save_record;
        private System.Windows.Forms.Button btn_200f_2_7xx;
        private System.Windows.Forms.Button btn_200g_2_702;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_task;
        private System.Windows.Forms.TabPage tabPage_images;
        private System.Windows.Forms.TabPage tabPage_fix;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabPage tabPage_info;
        private System.Windows.Forms.Button btn_check;
        private System.Windows.Forms.Button btn_save_and_check;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Button btn_check_waiting;
        private System.Windows.Forms.Button btn_check_failure;
        private System.Windows.Forms.Button btn_catalog_ing;
        private System.Windows.Forms.Button btn_catalog_waiting;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TabPage tabPage_chk_info;
        private System.Windows.Forms.TabPage tabPage_z39;
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
        private System.Windows.Forms.Button btn_z39_search;
        private System.Windows.Forms.WebBrowser webBrowser_field_info;
    }
}

