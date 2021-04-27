using System;
using System.Windows.Forms;

namespace mytest
{
    static class Program
    {
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
                Application.Run(new EditForm());
            }
        }
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
        public static string Folio_field_info_url;
    }
    //可以不使用这里的全局变量，尚未修改完毕
    public class Folio_Record
    {
        public static string rec_type;
        public static bool rec_status;
        public static string rec_data;
        public static string id;
        public static string instanceId;

        public static string code;
        public static string message;
        public static string success;
        public static string rawContent;
        public static string marcContent;
    }
}
