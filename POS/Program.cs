using System;
using System.Diagnostics;
using System.Management;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace POS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            cls.Koneksi kon = new cls.Koneksi();
            cls.Pesan psn = new cls.Pesan();
            cls.Enkripsi enc = new cls.Enkripsi();

            loadConfig(inifilepath + "\\" + "Config.ini");

            if (!IsStillRunning())
            {
                if (key != enc.Encrypt(enc.MD5Hash(enc.getProcessorId()), true))
                {
                    psn.PesanInfo("Licensi yang di daftarkan salah, silahkan hubungi pihak developer aplikasi");
                }
                else
                {
                    try
                    {
                        kon.OpenConn();
                        psn.CreateLogSuccessClass("Main", "Application Start");

                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new MenuUtama());
                    }
                    catch (Exception e)
                    {
                        psn.CreateLogErrorClass("Main", "Koneksi ke Database Bermasalah", e.ToString());
                    }
                }
            }
        }

        static bool IsStillRunning()
        {
            string processName = Process.GetCurrentProcess().MainModule.ModuleName;
            ManagementObjectSearcher mos = new ManagementObjectSearcher();
            mos.Query.QueryString = @"SELECT * FROM Win32_Process WHERE Name = '" + processName + @"'";
            if (mos.Get().Count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static string inifilepath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        static string key;

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        private static string readConfig(string fileininame, string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(4096);
            int i = GetPrivateProfileString(Section, Key, "", temp, 4096, fileininame);
            return temp.ToString();
        }

        private static void loadConfig(string fileIni)
        {
            key = readConfig(fileIni, "Setting", "key");
        }
    }
}
