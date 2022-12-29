using System;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace POS.cls
{
    class Pesan
    {
        public void PesanInfo(string mssg)
        {
            MessageBox.Show(mssg, "Information", MessageBoxButtons.OK,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        public void PesanError(string mssg)
        {
            MessageBox.Show(mssg, "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        public void PesanWarning(string mssg)
        {
            MessageBox.Show(mssg, "Warning", MessageBoxButtons.OK,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        public void PesanQuestion(string mssg)
        {
            MessageBox.Show(mssg, "Question", MessageBoxButtons.OK,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }

        public void CreateLogSuccessForm(Form frm, string fungsi, string mssg)
        {
            StreamWriter strLog;
            FileStream fileStream = null;
            DirectoryInfo dirInfo = null;
            FileInfo logInfo;

            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Logs\\";
            filePath = filePath + "Log_" + DateTime.Now.ToString("yyyyMM") + "." + "log";
            logInfo = new FileInfo(filePath);
            dirInfo = new DirectoryInfo(logInfo.DirectoryName);
            if (!dirInfo.Exists) dirInfo.Create();
            if (!logInfo.Exists)
            {
                fileStream = logInfo.Create();
            }
            else
            {
                fileStream = new FileStream(filePath, FileMode.Append);
            }
            strLog = new StreamWriter(fileStream);

            strLog.WriteLine(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "\t" + "[SUCCESS FORM]" + "\t" + "[" + frm.Name.ToString() + "]" + "\t" +
                    "[" + fungsi + "]" + "\t" + mssg);

            strLog.Dispose();
        }

        public void CreateLogSuccessClass(string fungsi, string mssg)
        {
            StreamWriter strLog;
            FileStream fileStream = null;
            DirectoryInfo dirInfo = null;
            FileInfo logInfo;

            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Logs\\";
            filePath = filePath + "Log_" + DateTime.Now.ToString("yyyyMM") + "." + "log";
            logInfo = new FileInfo(filePath);
            dirInfo = new DirectoryInfo(logInfo.DirectoryName);
            if (!dirInfo.Exists) dirInfo.Create();
            if (!logInfo.Exists)
            {
                fileStream = logInfo.Create();
            }
            else
            {
                fileStream = new FileStream(filePath, FileMode.Append);
            }
            strLog = new StreamWriter(fileStream);

            strLog.WriteLine(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "\t" + "[SUCCESS CLASS]" + "\t" + "[" + fungsi + "]" + "\t" + mssg);

            strLog.Close();
        }

        public void CreateLogErrorForm(Form frm, string fungsi, string mssg, string e)
        {
            StreamWriter strLog;
            FileStream fileStream = null;
            DirectoryInfo dirInfo = null;
            FileInfo logInfo;

            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Logs\\";
            filePath = filePath + "Log_" + DateTime.Now.ToString("yyyyMM") + "." + "log";
            logInfo = new FileInfo(filePath);
            dirInfo = new DirectoryInfo(logInfo.DirectoryName);
            if (!dirInfo.Exists) dirInfo.Create();
            if (!logInfo.Exists)
            {
                fileStream = logInfo.Create();
            }
            else
            {
                fileStream = new FileStream(filePath, FileMode.Append);
            }
            strLog = new StreamWriter(fileStream);

            strLog.WriteLine(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "\t" + "[FAILED FORM]" + "\t" + "[" + frm.Name.ToString() + "]" + "\t" +
                "[" + fungsi + "]" + "\t" + mssg + "\n" + e);

            strLog.Dispose();

            MessageBox.Show(mssg, "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        public void CreateLogErrorClass(string fungsi, string mssg, string e)
        {
            StreamWriter strLog;
            FileStream fileStream = null;
            DirectoryInfo dirInfo = null;
            FileInfo logInfo;

            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Logs\\";
            filePath = filePath + "Log_" + DateTime.Now.ToString("yyyyMM") + "." + "log";
            logInfo = new FileInfo(filePath);
            dirInfo = new DirectoryInfo(logInfo.DirectoryName);
            if (!dirInfo.Exists) dirInfo.Create();
            if (!logInfo.Exists)
            {
                fileStream = logInfo.Create();
            }
            else
            {
                fileStream = new FileStream(filePath, FileMode.Append);
            }
            strLog = new StreamWriter(fileStream);

            strLog.WriteLine(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "\t" + "[FAILED CLASS]" + "\t" + "[" + fungsi + "]" + "\t" + mssg + "\n" + e);

            strLog.Dispose();

            MessageBox.Show(mssg, "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        public void CreateLogTransaksiPenjualan(Form frm, string fungsi, string mssg)
        {
            StreamWriter strLog;
            FileStream fileStream = null;
            DirectoryInfo dirInfo = null;
            FileInfo logInfo;

            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Logs\\";
            filePath = filePath + "Log_Penjualan_" + DateTime.Now.ToString("yyyyMM") + "." + "log";
            logInfo = new FileInfo(filePath);
            dirInfo = new DirectoryInfo(logInfo.DirectoryName);
            if (!dirInfo.Exists) dirInfo.Create();
            if (!logInfo.Exists)
            {
                fileStream = logInfo.Create();
            }
            else
            {
                fileStream = new FileStream(filePath, FileMode.Append);
            }
            strLog = new StreamWriter(fileStream);

            strLog.WriteLine(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "\t" + "[INSERT]" + "\t" + "[" + frm.Name.ToString() + "]" + "\t" +
                "[" + fungsi + "]" + "\t" + mssg + "");

            strLog.Dispose();
        }
    }
}
