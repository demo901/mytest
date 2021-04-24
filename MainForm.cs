using System;
using System.Windows.Forms;

namespace mytest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menu_open_MarcEdit_form_Click(object sender, EventArgs e)
        {
            if(Program.EditForm.Visible == true)
            {
                Program.EditForm.Activate();
                return;
            }
            Program.EditForm.MdiParent = this;
            Program.EditForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Program.EditForm.MdiParent = this;
            Program.EditForm.Show();
        }
        private void menu_open_SearchForm_Click(object sender, EventArgs e)
        {
            if (Program.SearchForm.Visible == true)
            {
                Program.SearchForm.Activate();
                return;
            }

            Program.SearchForm.MdiParent = this;
            Program.SearchForm.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (MessageBox.Show("是否关闭程序?", "Confirm Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    Environment.Exit(0);
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
        }

        private void menu_open_task_form_Click(object sender, EventArgs e)
        {
            if (Program.TaskForm.Visible == true)
            {
                Program.TaskForm.Activate();
                return;
            }

            Program.TaskForm.MdiParent = this;
            Program.TaskForm.Show();
        }
    }
}
