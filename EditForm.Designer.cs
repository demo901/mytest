
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
            this.txt_recordid = new System.Windows.Forms.TextBox();
            this.btn_fetch_record = new System.Windows.Forms.Button();
            this.btn_save_record = new System.Windows.Forms.Button();
            this.btn_200f_2_7xx = new System.Windows.Forms.Button();
            this.btn_200g_2_702 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // marcEditor1
            // 
            this.marcEditor1.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.marcEditor1.Size = new System.Drawing.Size(814, 640);
            this.marcEditor1.TabIndex = 0;
            this.marcEditor1.UiState = "{\"FieldNameCaptionWidth\":100}";
            this.marcEditor1.VertGridColor = System.Drawing.Color.LightGray;
            this.marcEditor1.GetConfigDom += new DigitalPlatform.Marc.GetConfigDomEventHandle(this.marcEditor1_GetConfigDom);
            // 
            // btn_loadrecord_from_disk
            // 
            this.btn_loadrecord_from_disk.Location = new System.Drawing.Point(1090, 499);
            this.btn_loadrecord_from_disk.Name = "btn_loadrecord_from_disk";
            this.btn_loadrecord_from_disk.Size = new System.Drawing.Size(152, 28);
            this.btn_loadrecord_from_disk.TabIndex = 1;
            this.btn_loadrecord_from_disk.Text = "测试从磁盘加载记录";
            this.btn_loadrecord_from_disk.UseVisualStyleBackColor = true;
            this.btn_loadrecord_from_disk.Click += new System.EventHandler(this.btn_loadrecord_from_disk_Click);
            // 
            // txt_recordid
            // 
            this.txt_recordid.BackColor = System.Drawing.Color.Black;
            this.txt_recordid.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_recordid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txt_recordid.Location = new System.Drawing.Point(1090, 591);
            this.txt_recordid.Name = "txt_recordid";
            this.txt_recordid.Size = new System.Drawing.Size(152, 26);
            this.txt_recordid.TabIndex = 9;
            this.txt_recordid.Text = "55f335f9-d795-42d8-afbf-d80c1c0bb46c";
            // 
            // btn_fetch_record
            // 
            this.btn_fetch_record.ForeColor = System.Drawing.Color.Blue;
            this.btn_fetch_record.Location = new System.Drawing.Point(1090, 557);
            this.btn_fetch_record.Name = "btn_fetch_record";
            this.btn_fetch_record.Size = new System.Drawing.Size(152, 28);
            this.btn_fetch_record.TabIndex = 15;
            this.btn_fetch_record.Text = "测试加载Folio记录";
            this.btn_fetch_record.UseVisualStyleBackColor = true;
            this.btn_fetch_record.Click += new System.EventHandler(this.btn_fetch_record_Click);
            // 
            // btn_save_record
            // 
            this.btn_save_record.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_save_record.ForeColor = System.Drawing.Color.Red;
            this.btn_save_record.Location = new System.Drawing.Point(153, 12);
            this.btn_save_record.Name = "btn_save_record";
            this.btn_save_record.Size = new System.Drawing.Size(136, 38);
            this.btn_save_record.TabIndex = 16;
            this.btn_save_record.Text = "保存到服务器";
            this.btn_save_record.UseVisualStyleBackColor = true;
            this.btn_save_record.Click += new System.EventHandler(this.btn_save_record_Click);
            // 
            // btn_200f_2_7xx
            // 
            this.btn_200f_2_7xx.Location = new System.Drawing.Point(832, 83);
            this.btn_200f_2_7xx.Name = "btn_200f_2_7xx";
            this.btn_200f_2_7xx.Size = new System.Drawing.Size(109, 28);
            this.btn_200f_2_7xx.TabIndex = 19;
            this.btn_200f_2_7xx.Text = "200f->701";
            this.btn_200f_2_7xx.UseVisualStyleBackColor = true;
            this.btn_200f_2_7xx.Click += new System.EventHandler(this.btn_200f_2_7xx_Click);
            // 
            // btn_200g_2_702
            // 
            this.btn_200g_2_702.Location = new System.Drawing.Point(832, 117);
            this.btn_200g_2_702.Name = "btn_200g_2_702";
            this.btn_200g_2_702.Size = new System.Drawing.Size(109, 28);
            this.btn_200g_2_702.TabIndex = 20;
            this.btn_200g_2_702.Text = "200g->702";
            this.btn_200g_2_702.UseVisualStyleBackColor = true;
            this.btn_200g_2_702.Click += new System.EventHandler(this.btn_200g_2_702_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 729);
            this.Controls.Add(this.btn_200g_2_702);
            this.Controls.Add(this.btn_200f_2_7xx);
            this.Controls.Add(this.btn_save_record);
            this.Controls.Add(this.btn_fetch_record);
            this.Controls.Add(this.txt_recordid);
            this.Controls.Add(this.btn_loadrecord_from_disk);
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
        private System.Windows.Forms.Button btn_loadrecord_from_disk;
        private System.Windows.Forms.TextBox txt_recordid;
        private System.Windows.Forms.Button btn_fetch_record;
        private System.Windows.Forms.Button btn_save_record;
        private System.Windows.Forms.Button btn_200f_2_7xx;
        private System.Windows.Forms.Button btn_200g_2_702;
    }
}

