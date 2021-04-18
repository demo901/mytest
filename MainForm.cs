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
            var ef = Program.EditForm;
            if(ef.Visible == true)
            {
                ef.Activate();
                return;
            }
            ef.MdiParent = this;
            ef.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var ef = Program.EditForm;
            ef.MdiParent = this;
            ef.Show();
        }
        private void menu_open_SearchForm_Click(object sender, EventArgs e)
        {
            var sf = Program.SearchForm;
            if (sf.Visible == true)
            {
                sf.Activate();
                return;
            }

            sf.MdiParent = this;
            sf.Show();
        }
    }
}
