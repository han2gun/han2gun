using System;
using System.IO;
using System.Windows.Forms;

namespace POS
{
    public partial class MenuUtama : Form
    {
        cls.Pesan psn = new cls.Pesan();
        cls.Fungsi fs = new cls.Fungsi();
        cls.Query qry = new cls.Query();

        string inifilepath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        public string userName;
        public string server;
        public string backup;
        public string restore;
        public int btn_pencarianlain_x;
        public int btn_pencarianlain_y;
        public int btn_pencariantgl_x;
        public int btn_pencariantgl_y;
        public int btn_refreshlain_x;
        public int btn_refreshlain_y;
        public int btn_refreshtgl_x;
        public int btn_refreshtgl_y;
        public int tooltip_x;
        public int tooltip_y;
        int panelWidth;
        bool isCollapsed;

        public MenuUtama()
        {
            InitializeComponent();

            lblDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            panelWidth = pnlSideBar.Width;
            isCollapsed = false;
        }

        #region code
        private void SignOut()
        {
            qry.InsertLogAktivitas("SignOut", this, "", userName);
            psn.CreateLogSuccessForm(this, "SignOut", userName);

            btnSignInOut.Text = "Sign In";
            btnSignInOut.Image = imageList1.Images[1];
            
            btnMasterData.Enabled = false;
            btnTransaksi.Enabled = false;
            btnLaporan.Enabled = false;
            btnPengaturan.Enabled = false;
            btnDatabase.Enabled = false;
            lblNamaPengguna.Text = "";
            lblPosisi.Text = "";
            userName = "";

            Login login = new Login(this);
            login.TopLevel = false;
            pnlUtama.Controls.Add(login);
            login.Show();
        }

        private void loadConfig(string fileIni)
        {
            server = fs.ReadConfig(fileIni, "Setting", "server");
            backup = fs.ReadConfig(fileIni, "Setting", "backup");
            restore = fs.ReadConfig(fileIni, "Setting", "restore");
            btn_pencarianlain_x = Convert.ToInt32(fs.ReadConfig(fileIni, "Layout", "btn_pencarianlain_x"));
            btn_pencarianlain_y = Convert.ToInt32(fs.ReadConfig(fileIni, "Layout", "btn_pencarianlain_y"));
            btn_pencariantgl_x = Convert.ToInt32(fs.ReadConfig(fileIni, "Layout", "btn_pencariantgl_x"));
            btn_pencariantgl_y = Convert.ToInt32(fs.ReadConfig(fileIni, "Layout", "btn_pencariantgl_y"));
            btn_refreshlain_x = Convert.ToInt32(fs.ReadConfig(fileIni, "Layout", "btn_refreshlain_x"));
            btn_refreshlain_y = Convert.ToInt32(fs.ReadConfig(fileIni, "Layout", "btn_refreshlain_y"));
            btn_refreshtgl_x = Convert.ToInt32(fs.ReadConfig(fileIni, "Layout", "btn_refreshtgl_x"));
            btn_refreshtgl_y = Convert.ToInt32(fs.ReadConfig(fileIni, "Layout", "btn_refreshtgl_y"));
            tooltip_x = Convert.ToInt32(fs.ReadConfig(fileIni, "Layout", "tooltip_x"));
            tooltip_y = Convert.ToInt32(fs.ReadConfig(fileIni, "Layout", "tooltip_y"));
        }

        public void CloseAllForm()
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "MenuUtama")
                    Application.OpenForms[i].Close();
            }
        }
        #endregion

        private void MenuUtama_Load(object sender, EventArgs e)
        {
            if (fs.CekConfigFile() == true)
            {
                loadConfig(fs.inifilepath + "\\" + "Config.ini");
            }
            else
            {
                psn.CreateLogErrorForm(this, "MenuUtama_Load", "File Config.ini Tidak Ditemukan", "");
            }

            lblNamaPengguna.Text = "";
            lblPosisi.Text = "";
            lblNamaForm.Text = "";

            Login lgn = new Login(this);
            lgn.TopLevel = false;
            pnlUtama.Controls.Add(lgn);
            lgn.Show();
        }

        private void MenuUtama_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Keluar dari aplikasi?", "Keluar", MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                e.Cancel = false;
                psn.CreateLogSuccessForm(this, "MenuUtama_FormClosing", "Aplikasi di tutup");
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void timerSideBar_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                pnlSideBar.Width = pnlSideBar.Width + 12;
                if (pnlSideBar.Width >= panelWidth)
                {
                    timerSideBar.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                pnlSideBar.Width = pnlSideBar.Width - 52;
                if (pnlSideBar.Width <= 50)
                {
                    timerSideBar.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            timerSideBar.Start();
        }

        private void timerDate_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMasterData_Click(object sender, EventArgs e)
        {
            fs.MoveSidePanel(btnMasterData, pnlCursor);

            cls.OpenForm op = new cls.OpenForm(this);
            op.MasterDataOpen("MasterData", userName);
        }

        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            fs.MoveSidePanel(btnTransaksi, pnlCursor);

            cls.OpenForm op = new cls.OpenForm(this);
            op.TransaksiOpen("Transaksi", userName);
        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            fs.MoveSidePanel(btnLaporan, pnlCursor);

            cls.OpenForm op = new cls.OpenForm(this);
            op.LaporanOpen("Laporan", userName);
        }

        private void btnSignInOut_Click(object sender, EventArgs e)
        {
            if (btnSignInOut.Text == "Sign Out")
            {
                CloseAllForm();
                SignOut();
            }
        }

        private void btnPengaturan_Click(object sender, EventArgs e)
        {
            fs.MoveSidePanel(btnPengaturan, pnlCursor);

            cls.OpenForm op = new cls.OpenForm(this);
            op.PengaturanOpen("Pengaturan", userName);
        }

        private void btnDatabase_Click(object sender, EventArgs e)
        {
            fs.MoveSidePanel(btnDatabase, pnlCursor);

            cls.OpenForm op = new cls.OpenForm(this);
            op.DatabaseOpen("Database", userName);
        }
    }
}
