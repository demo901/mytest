
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
            this.tabPage_images = new System.Windows.Forms.TabPage();
            this.tabPage_fix = new System.Windows.Forms.TabPage();
            this.tabPage_info = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_z39_search = new System.Windows.Forms.Button();
            this.btn_save_and_check = new System.Windows.Forms.Button();
            this.btn_check = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.btn_catalog_waiting = new System.Windows.Forms.Button();
            this.btn_catalog_ing = new System.Windows.Forms.Button();
            this.btn_check_failure = new System.Windows.Forms.Button();
            this.btn_check_waiting = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_task.SuspendLayout();
            this.tabPage_images.SuspendLayout();
            this.tabPage_fix.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
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
            this.marcEditor1.Marc = "";
            this.marcEditor1.MarcDefDom = null;
            this.marcEditor1.Name = "marcEditor1";
            this.marcEditor1.NameBackColor = System.Drawing.SystemColors.Window;
            this.marcEditor1.NameCaptionBackColor = System.Drawing.SystemColors.Info;
            this.marcEditor1.NameCaptionTextColor = System.Drawing.SystemColors.InfoText;
            this.marcEditor1.NameTextColor = System.Drawing.Color.Blue;
            this.marcEditor1.ReadOnly = false;
            this.marcEditor1.SelectionStart = -1;
            this.marcEditor1.Size = new System.Drawing.Size(775, 675);
            this.marcEditor1.TabIndex = 0;
            this.marcEditor1.UiState = "{\"FieldNameCaptionWidth\":100}";
            this.marcEditor1.VertGridColor = System.Drawing.Color.LightGray;
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
            this.splitContainer1.Size = new System.Drawing.Size(1289, 729);
            this.splitContainer1.SplitterDistance = 510;
            this.splitContainer1.TabIndex = 21;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_task);
            this.tabControl1.Controls.Add(this.tabPage_images);
            this.tabControl1.Controls.Add(this.tabPage_fix);
            this.tabControl1.Controls.Add(this.tabPage_info);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(510, 729);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_task
            // 
            this.tabPage_task.Controls.Add(this.splitContainer3);
            this.tabPage_task.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage_task.Location = new System.Drawing.Point(4, 22);
            this.tabPage_task.Name = "tabPage_task";
            this.tabPage_task.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_task.Size = new System.Drawing.Size(502, 703);
            this.tabPage_task.TabIndex = 0;
            this.tabPage_task.Text = "任务";
            this.tabPage_task.UseVisualStyleBackColor = true;
            // 
            // tabPage_images
            // 
            this.tabPage_images.Controls.Add(this.webBrowser1);
            this.tabPage_images.Location = new System.Drawing.Point(4, 22);
            this.tabPage_images.Name = "tabPage_images";
            this.tabPage_images.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_images.Size = new System.Drawing.Size(502, 703);
            this.tabPage_images.TabIndex = 1;
            this.tabPage_images.Text = "书刊图片";
            this.tabPage_images.UseVisualStyleBackColor = true;
            // 
            // tabPage_fix
            // 
            this.tabPage_fix.Controls.Add(this.groupBox1);
            this.tabPage_fix.Controls.Add(this.groupBox2);
            this.tabPage_fix.Location = new System.Drawing.Point(4, 22);
            this.tabPage_fix.Name = "tabPage_fix";
            this.tabPage_fix.Size = new System.Drawing.Size(502, 703);
            this.tabPage_fix.TabIndex = 2;
            this.tabPage_fix.Text = "自动生成";
            this.tabPage_fix.UseVisualStyleBackColor = true;
            // 
            // tabPage_info
            // 
            this.tabPage_info.Location = new System.Drawing.Point(4, 22);
            this.tabPage_info.Name = "tabPage_info";
            this.tabPage_info.Size = new System.Drawing.Size(502, 703);
            this.tabPage_info.TabIndex = 3;
            this.tabPage_info.Text = "字段提示";
            this.tabPage_info.UseVisualStyleBackColor = true;
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
            // listView2
            // 
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(0, 0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(496, 629);
            this.listView2.TabIndex = 51;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.DoubleClick += new System.EventHandler(this.listView2_DoubleClick);
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
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(496, 697);
            this.webBrowser1.TabIndex = 55;
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
            this.splitContainer2.Size = new System.Drawing.Size(775, 729);
            this.splitContainer2.TabIndex = 20;
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
            this.splitContainer3.Size = new System.Drawing.Size(496, 697);
            this.splitContainer3.SplitterDistance = 64;
            this.splitContainer3.TabIndex = 52;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 729);
            this.Controls.Add(this.splitContainer1);
            this.Name = "EditForm";
            this.Text = "数据编辑";
            this.Activated += new System.EventHandler(this.EditForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_task.ResumeLayout(false);
            this.tabPage_images.ResumeLayout(false);
            this.tabPage_fix.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
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
        private System.Windows.Forms.Button btn_z39_search;
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
    }
}

