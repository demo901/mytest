using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using DigitalPlatform;
using DigitalPlatform.Core;
using DigitalPlatform.LibraryClient;
using DigitalPlatform.Text;

namespace mytest
{
    static class Program
    {
        static MainForm _mainForm = null;
        static SearchForm _searchForm = null;
        static EditForm _editForm = null;

        public static EditForm EditForm
        {
            get
            {
                return _editForm;
            }
        }
        public static MainForm MainForm
        {
            get
            {
                return _mainForm;
            }
        }

        public static SearchForm SearchForm
        {
            get
            {
                return _searchForm;
            }
        }

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                _searchForm = new SearchForm();
                _mainForm = new MainForm();
                _editForm = new EditForm();

                Application.Run(_mainForm);
            }
        }
    }
    public class Z39_Record
    {
        public static string Rec_Type;
        public static int Rec_Index;
        public static string Rec_Data;
        public static bool Rec_Status;
    }
}
