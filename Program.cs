using System;
using System.Windows.Forms;

namespace mytest
{
    static class Program
    {
        static SearchForm _searchForm = null;
        static EditForm _editForm = null;
        //static TaskForm _taskForm = null;

        //public static TaskForm TaskForm
        //{
        //    get
        //    {
        //        return _taskForm;
        //    }
        //}
        public static EditForm EditForm
        {
            get
            {
                return _editForm;
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
                _editForm = new EditForm();
                //_taskForm = new TaskForm();

                Application.Run(new MainForm());
            }
        }
    }
    public class Z39_Record
    {
        public static string rec_type;
        public static bool rec_status;
        public static string rec_data;
    }
    public class Folio_Config_Info
    {
        public static string Folio_uname;
        public static string Folio_upass;
        public static string Folio_tenant;
        public static string Folio_token;
        public static string Folio_token_url;
        public static string Folio_data_get_url;
        public static string Folio_data_add_url;
        public static string Folio_data_update_url;
        public static string Folio_task_url;
        public static string Folio_image_url;
    }
    public class Folio_Record
    {
        public static string rec_type;
        public static bool rec_status;
        public static string rec_data;
        public static string id;
        public static string instanceId;
        public static string jsonText;

        public static string code;
        public static string message;
        public static string success;
        public static string rawContent;
        public static string marcContent;
    }
}
