
namespace mytest
{
    partial class TaskForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskForm));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.listView2 = new System.Windows.Forms.ListView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tool_catalog_waiting = new System.Windows.Forms.ToolStripButton();
            this.tool_catalog_ing = new System.Windows.Forms.ToolStripButton();
            this.tool_check_failer = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(606, 613);
            this.webBrowser1.TabIndex = 54;
            // 
            // listView2
            // 
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(12, 32);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(479, 479);
            this.listView2.TabIndex = 50;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.Click += new System.EventHandler(this.listView2_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_catalog_waiting,
            this.tool_catalog_ing,
            this.tool_check_failer});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1243, 32);
            this.toolStrip1.TabIndex = 55;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tool_catalog_waiting
            // 
            this.tool_catalog_waiting.BackColor = System.Drawing.SystemColors.Control;
            this.tool_catalog_waiting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tool_catalog_waiting.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tool_catalog_waiting.Image = ((System.Drawing.Image)(resources.GetObject("tool_catalog_waiting.Image")));
            this.tool_catalog_waiting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_catalog_waiting.Name = "tool_catalog_waiting";
            this.tool_catalog_waiting.Size = new System.Drawing.Size(111, 29);
            this.tool_catalog_waiting.Text = "待编目列表";
            this.tool_catalog_waiting.Click += new System.EventHandler(this.btn_catalog_waiting_Click);
            // 
            // tool_catalog_ing
            // 
            this.tool_catalog_ing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tool_catalog_ing.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tool_catalog_ing.Image = ((System.Drawing.Image)(resources.GetObject("tool_catalog_ing.Image")));
            this.tool_catalog_ing.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_catalog_ing.Name = "tool_catalog_ing";
            this.tool_catalog_ing.Size = new System.Drawing.Size(111, 29);
            this.tool_catalog_ing.Text = "编目中列表";
            this.tool_catalog_ing.Click += new System.EventHandler(this.btn_catalog_ing_Click);
            // 
            // tool_check_failer
            // 
            this.tool_check_failer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tool_check_failer.Image = ((System.Drawing.Image)(resources.GetObject("tool_check_failer.Image")));
            this.tool_check_failer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_check_failer.Name = "tool_check_failer";
            this.tool_check_failer.Size = new System.Drawing.Size(149, 29);
            this.tool_check_failer.Text = "审核未通过列表";
            this.tool_check_failer.Click += new System.EventHandler(this.btn_check_failer_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 32);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.webBrowser1);
            this.splitContainer1.Size = new System.Drawing.Size(1243, 613);
            this.splitContainer1.SplitterDistance = 633;
            this.splitContainer1.TabIndex = 56;
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 645);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "TaskForm";
            this.Text = "任务窗口";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaskForm_FormClosing);
            this.Load += new System.EventHandler(this.TaskForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tool_catalog_waiting;
        private System.Windows.Forms.ToolStripButton tool_catalog_ing;
        private System.Windows.Forms.ToolStripButton tool_check_failer;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}