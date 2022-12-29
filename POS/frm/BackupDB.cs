using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace POS.frm
{
    public partial class BackupDB : Form
    {
        cls.Pesan psn = new cls.Pesan();
        
        public string userName;
        string inifilepath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        FileInfo configFile;
        string backup;
        string server;
        MenuUtama frmUtama;

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        private BackgroundWorker bw;

        public BackupDB(MenuUtama mnutama)
        {
            InitializeComponent();
            frmUtama = mnutama;

            this.bw = new BackgroundWorker();
            this.bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            this.bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            this.bw.WorkerReportsProgress = true;

            this.btnBackup.Click += new EventHandler(btnBackup_Click);
        }

        #region code
        private static string readConfig(string fileininame, string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(4096);
            int i = GetPrivateProfileString(Section, Key, "", temp, 4096, fileininame);
            return temp.ToString();
        }

        private void loadConfig(string fileIni)
        {
            backup = readConfig(fileIni, "Setting", "backup");
            server = readConfig(fileIni, "Setting", "server");
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.btnBackup.Enabled = true;
            this.picLoading.Visible = false;
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string conn = "server=" + server + ";user=root;password=haniel;database=pos_salatiga;charset=utf8";

                string file = backup + "\\" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".sql";
                FileInfo fl = new FileInfo(file);
                DirectoryInfo di = new DirectoryInfo(fl.DirectoryName);

                if (!di.Exists)
                {
                    di.Create();
                }

                using (MySqlConnection con = new MySqlConnection(conn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = con;
                            con.Open();
                            mb.ExportToFile(file);
                            con.Close();
                        }
                    }
                }
                System.Threading.Thread.Sleep(100);
                psn.PesanInfo("Backup berhasil");
            }
            catch (Exception ex)
            {
                psn.PesanError("Backup Database Gagal");
                psn.CreateLogErrorForm(this, "Hapus", "Backup DB Gagal", ex.ToString());
            }
        }
        #endregion

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (!this.bw.IsBusy)
            {
                this.bw.RunWorkerAsync();
                this.btnBackup.Enabled = false;
                this.picLoading.Visible = true;
            }
        }

        private void BackupDB_Load(object sender, EventArgs e)
        {
            frmUtama.lblNamaForm.Text = "- Barang";
            configFile = new FileInfo(inifilepath + "\\" + "Config.ini");

            if (!configFile.Exists)
            {
                psn.PesanInfo("Load Config.ini gagal, file tidak ditemukan");
                psn.CreateLogErrorForm(this, "BackupDB", "Missing file Config.ini", "");
            }
            else
            {
                loadConfig(inifilepath + "\\" + "Config.ini");
                label4.Text = "File akan tersimpan di " + backup + "";
            }
        }
    }
}
