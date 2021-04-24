
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_recordid = new System.Windows.Forms.TextBox();
            this.btn_fetch_record = new System.Windows.Forms.Button();
            this.btn_save_record = new System.Windows.Forms.Button();
            this.btn_200f_2_7xx = new System.Windows.Forms.Button();
            this.btn_200g_2_702 = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.btn_catalog_waiting = new System.Windows.Forms.Button();
            this.btn_catalog_ing = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_check_failer = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
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
            // listView2
            // 
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(725, 83);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(611, 243);
            this.listView2.TabIndex = 41;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.Click += new System.EventHandler(this.listView2_Click);
            // 
            // btn_catalog_waiting
            // 
            this.btn_catalog_waiting.Location = new System.Drawing.Point(736, 41);
            this.btn_catalog_waiting.Name = "btn_catalog_waiting";
            this.btn_catalog_waiting.Size = new System.Drawing.Size(127, 28);
            this.btn_catalog_waiting.TabIndex = 43;
            this.btn_catalog_waiting.Text = "待编目列表";
            this.btn_catalog_waiting.UseVisualStyleBackColor = true;
            this.btn_catalog_waiting.Click += new System.EventHandler(this.btn_catalog_waiting_Click);
            // 
            // btn_catalog_ing
            // 
            this.btn_catalog_ing.Location = new System.Drawing.Point(884, 41);
            this.btn_catalog_ing.Name = "btn_catalog_ing";
            this.btn_catalog_ing.Size = new System.Drawing.Size(124, 28);
            this.btn_catalog_ing.TabIndex = 44;
            this.btn_catalog_ing.Text = "编目中列表";
            this.btn_catalog_ing.UseVisualStyleBackColor = true;
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(379, 41);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(150, 28);
            this.btn_search.TabIndex = 45;
            this.btn_search.Text = "Z39检索记录";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_check_failer
            // 
            this.btn_check_failer.Location = new System.Drawing.Point(1030, 41);
            this.btn_check_failer.Name = "btn_check_failer";
            this.btn_check_failer.Size = new System.Drawing.Size(124, 28);
            this.btn_check_failer.TabIndex = 46;
            this.btn_check_failer.Text = "审核未通过列表";
            this.btn_check_failer.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(725, 332);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(610, 354);
            this.webBrowser1.TabIndex = 49;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 698);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.btn_check_failer);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.btn_catalog_ing);
            this.Controls.Add(this.btn_catalog_waiting);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.btn_200g_2_702);
            this.Controls.Add(this.btn_200f_2_7xx);
            this.Controls.Add(this.btn_save_record);
            this.Controls.Add(this.btn_fetch_record);
            this.Controls.Add(this.txt_recordid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.marcEditor1);
            this.Name = "EditForm";
            this.Text = "数据编辑";
            this.Activated += new System.EventHandler(this.EditForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditForm_FormClosing);
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
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Button btn_catalog_waiting;
        private System.Windows.Forms.Button btn_catalog_ing;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_check_failer;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}

