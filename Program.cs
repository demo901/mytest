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

    public class Folio_Record
    {
        public bool saved;//记录是否需要保存
        public bool used;//是否被使用
        public int id;//ListView中的ID索引，从0开始

        public string folio_id;
        public string instanceId;
        public string dp2marcStr;//机内格式数据
        public string code;
        public string message;
        public string success;
        public string rawContent;
        public string marcContent;

        //需要保留来自Folio的字段
        public string f010a_orig;
        public string f210a_orig;
    }
}
