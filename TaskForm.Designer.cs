
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btn_check_failer = new System.Windows.Forms.Button();
            this.btn_catalog_ing = new System.Windows.Forms.Button();
            this.btn_catalog_waiting = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(629, 58);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(620, 659);
            this.webBrowser1.TabIndex = 54;
            // 
            // btn_check_failer
            // 
            this.btn_check_failer.Location = new System.Drawing.Point(317, 16);
            this.btn_check_failer.Name = "btn_check_failer";
            this.btn_check_failer.Size = new System.Drawing.Size(124, 28);
            this.btn_check_failer.TabIndex = 53;
            this.btn_check_failer.Text = "审核未通过列表";
            this.btn_check_failer.UseVisualStyleBackColor = true;
            // 
            // btn_catalog_ing
            // 
            this.btn_catalog_ing.Location = new System.Drawing.Point(171, 16);
            this.btn_catalog_ing.Name = "btn_catalog_ing";
            this.btn_catalog_ing.Size = new System.Drawing.Size(124, 28);
            this.btn_catalog_ing.TabIndex = 52;
            this.btn_catalog_ing.Text = "编目中列表";
            this.btn_catalog_ing.UseVisualStyleBackColor = true;
            // 
            // btn_catalog_waiting
            // 
            this.btn_catalog_waiting.Location = new System.Drawing.Point(23, 16);
            this.btn_catalog_waiting.Name = "btn_catalog_waiting";
            this.btn_catalog_waiting.Size = new System.Drawing.Size(127, 28);
            this.btn_catalog_waiting.TabIndex = 51;
            this.btn_catalog_waiting.Text = "待编目列表";
            this.btn_catalog_waiting.UseVisualStyleBackColor = true;
            this.btn_catalog_waiting.Click += new System.EventHandler(this.btn_catalog_waiting_Click);
            // 
            // listView2
            // 
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(12, 58);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(611, 659);
            this.listView2.TabIndex = 50;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.Click += new System.EventHandler(this.listView2_Click);
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 729);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.btn_check_failer);
            this.Controls.Add(this.btn_catalog_ing);
            this.Controls.Add(this.btn_catalog_waiting);
            this.Controls.Add(this.listView2);
            this.Name = "TaskForm";
            this.Text = "任务窗口";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaskForm_FormClosing);
            this.Load += new System.EventHandler(this.TaskForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btn_check_failer;
        private System.Windows.Forms.Button btn_catalog_ing;
        private System.Windows.Forms.Button btn_catalog_waiting;
        private System.Windows.Forms.ListView listView2;
    }
}