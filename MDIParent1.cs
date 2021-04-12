using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DigitalPlatform;
using DigitalPlatform.GUI;
using DigitalPlatform.Xml;
using DigitalPlatform.IO;
using DigitalPlatform.Text;
using DigitalPlatform.Script;   // QuickPinyin IsbnSplitter
using DigitalPlatform.CommonControl;


using DigitalPlatform.Marc;
using DigitalPlatform.MarcDom;
using DigitalPlatform.LibraryClient;
using DigitalPlatform.Core;
using System.Web;

namespace mytest
{
    public partial class MainForm : Form
    {
        //保存界面信息
        public ApplicationInfo AppInfo = null;
        private int childFormNumber = 0;
        public Marc8Encoding Marc8Encoding = null;
        public string DataDir = "";
        public IsbnSplitter IsbnSplitter = null;
        public FromCollection Froms = new FromCollection();
        public string UserLogDir = ""; // 2015/8/8

        public MainForm()
        {
            InitializeComponent();
        }

        public DigitalPlatform.StopManager stopManager = new DigitalPlatform.StopManager();

        public virtual bool Fixed
        {
            get;
            set;
        }

        public void ReportError(string strTitle,
string strError)
        {
            // 发送给 dp2003.com
            string strText = strError;
            if (string.IsNullOrEmpty(strText) == true)
                return;

            strText += "\r\n\r\n===\r\n";   // +PackageEventLog.GetEnvironmentDescription().Replace("\t", "    ");

            try
            {
                // 发送报告
                int nRet = LibraryChannel.CrashReport(
                    "@MAC:" + Program.GetMacAddressString(),
                    strTitle,
                    strText,
                    out strError);
                if (nRet == -1)
                {
                    strError = "CrashReport() (" + strTitle + ") 出错: " + strError;
                    this.WriteErrorLog(strError);
                }
            }
            catch (Exception ex)
            {
                strError = "CrashReport() (" + strTitle + ") 过程出现异常: " + ExceptionUtil.GetDebugText(ex);
                this.WriteErrorLog(strError);
            }
        }

        private static readonly Object _syncRoot_errorLog = new Object(); // 2018/6/26
        // 写入日志文件。每天创建一个单独的日志文件
        public void WriteErrorLog(string strText)
        {
            FileUtil.WriteErrorLog(
                _syncRoot_errorLog,
                this.UserLogDir,
                strText,
                "log_",
                ".txt");
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "窗口 " + childFormNumber++;
            childForm.Show();
        }
        public int GetEncoding(string strName,
    out Encoding encoding,
    out string strError)
        {
            strError = "";
            encoding = null;

            try
            {

                if (StringUtil.IsNumber(strName) == true)
                {
                    try
                    {
                        Int32 nCodePage = Convert.ToInt32(strName);
                        encoding = Encoding.GetEncoding(nCodePage);
                    }
                    catch (Exception ex)
                    {
                        strError = "构造编码方式过程出错: " + ex.Message;
                        return -1;
                    }
                }
                else
                {
                    if (strName.ToLower() == "eacc"
                        || strName.ToLower() == "marc-8")
                        encoding = this.Marc8Encoding;
                    else
                        encoding = Encoding.GetEncoding(strName);
                }
            }
            catch (Exception ex)
            {
                strError = ExceptionUtil.GetAutoText(ex);
                return -1;
            }

            return 0;
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void menu_open_MarcEdit_form_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.MdiParent = this;
            form1.Show();
        }

        private void menu_open_Z39Form_Click(object sender, EventArgs e)
        {
            
        }
        T OpenWindow<T>()
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                T form = Activator.CreateInstance<T>();
                dynamic o = form;
                o.MdiParent = this;

                try
                {
                    // 2018/6/24 MainForm 成员可能不存在，可能会抛出异常
                    if (o.MainForm == null)
                        o.MainForm = this;
                }
                catch
                {
                    // 等将来所有窗口类型的 MainForm 都是只读的以后，再修改这里
                }
                o.Show();
                return form;
            }
            else
                return EnsureChildForm<T>(true);
        }

        /// <summary>
        /// 获得一个已经打开的 MDI 子窗口，如果没有，则新打开一个
        /// </summary>
        /// <typeparam name="T">子窗口类型</typeparam>
        /// <returns>子窗口对象</returns>
        public T EnsureChildForm<T>(bool bActivate = false)
        {
            T form = GetTopChildWindow<T>();
            if (form == null)
            {
                form = Activator.CreateInstance<T>();
                dynamic o = form;
                o.MdiParent = this;

                try
                {
                    // 2013/3/26
                    // 2018/6/24 MainForm 成员可能不存在，可能会抛出异常
                    if (o.MainForm == null)
                        o.MainForm = this;
                }
                catch
                {
                    // 等将来所有窗口类型的 MainForm 都是只读的以后，再修改这里
                }
                o.Show();
            }
            else
            {
                if (bActivate == true)
                {
                    try
                    {
                        dynamic o = form;
                        o.Activate();

                        if (o.WindowState == FormWindowState.Minimized)
                            o.WindowState = FormWindowState.Normal;
                    }
                    catch
                    {
                    }
                }
            }
            return form;
        }

        /// <summary>
        /// 得到特定类型的顶层 MDI 子窗口
        /// 注：不算 Fixed 窗口
        /// </summary>
        /// <typeparam name="T">子窗口类型</typeparam>
        /// <returns>子窗口对象</returns>
        public T GetTopChildWindow<T>()
        {
            if (ActiveMdiChild == null)
                return default(T);

            // 得到顶层的MDI Child
            IntPtr hwnd = this.ActiveMdiChild.Handle;

            if (hwnd == IntPtr.Zero)
                return default(T);

            while (hwnd != IntPtr.Zero)
            {
                Form child = null;
                // 判断一个窗口句柄，是否为 MDI 子窗口？
                // return:
                //      null    不是 MDI 子窗口o
                //      其他      返回这个句柄对应的 Form 对象
                child = IsChildHwnd(hwnd);
                if (child != null && IsFixedMyForm(child) == false)  // 2016/12/16 跳过固定于左侧的 MyForm
                {
                    // if (child is T)
                    if (child.GetType().Equals(typeof(T)) == true)
                    {
                        try
                        {
                            return (T)Convert.ChangeType(child, typeof(T));
                        }
                        catch (InvalidCastException ex)
                        {
                            throw new InvalidCastException("在将类型 '" + child.GetType().ToString() + "' 转换为类型 '" + typeof(T).ToString() + "' 的过程中出现异常: " + ex.Message, ex);
                        }
                    }
                }

                hwnd = API.GetWindow(hwnd, API.GW_HWNDNEXT);
            }

            return default(T);
        }

        // 是否为固定于左侧的 MyForm?
        static bool IsFixedMyForm(Form child)
        {
            if (child is MainForm)
            {
                if (((MainForm)child).Fixed)
                    return true;
            }

            return false;
        }

        // 判断一个窗口句柄，是否为 MDI 子窗口？
        // 注：不处理 Visible == false 的窗口。因为取 Handle 会导致 Visible 变成 true
        // return:
        //      null    不是 MDI 子窗口o
        //      其他      返回这个句柄对应的 Form 对象
        Form IsChildHwnd(IntPtr hwnd)
        {
            foreach (Form child in this.MdiChildren)
            {
                if (child.Visible == true && hwnd == child.Handle)
                    return child;
            }

            return null;
        }
        public string DefaultFontString
        {
            get
            {
                return this.AppInfo.GetString(
                    "Global",
                    "default_font",
                    "");
            }
            set
            {
                this.AppInfo.SetString(
                    "Global",
                    "default_font",
                    value);
            }
        }
        new public Font DefaultFont
        {
            get
            {
                string strDefaultFontString = this.DefaultFontString;
                if (String.IsNullOrEmpty(strDefaultFontString) == true)
                {
                    return GuiUtil.GetDefaultFont();    // 2015/5/8
                    // return null;
                }

                // Create the FontConverter.
                System.ComponentModel.TypeConverter converter =
                    System.ComponentModel.TypeDescriptor.GetConverter(typeof(Font));

                return (Font)converter.ConvertFromString(strDefaultFontString);
            }
        }

    }

    public class Bib1Use
    {
        public string Name = "";
        public string Value = "";
        public string UniName = "";
        public string Comment = "";
    }

    public class FromCollection : List<Bib1Use>
    {
        public string GetValue(string strName)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Name.Trim() == strName.Trim())
                    return this[i].Value;
            }

            return null;    // not found
        }

    }
}
