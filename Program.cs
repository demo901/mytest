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
        public static MainForm MainForm
        {
            get
            {
                return _mainForm;
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
                _mainForm = new MainForm();
                Application.Run(_mainForm);
                //Application.Run(new MainForm());
            }
        }
        public static string GetMacAddressString()
        {
            List<string> macs = SerialCodeForm.GetMacAddress();
            return StringUtil.MakePathList(macs);
        }
    }
}
