using System;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace POS.frm
{
    public partial class RestoreDB : Form
    {
        cls.Fungsi fs = new cls.Fungsi();
        cls.Pesan psn = new cls.Pesan();

        MenuUtama frmUtama;
        public string userName;

        public RestoreDB(MenuUtama mnutama)
        {
            InitializeComponent();

            frmUtama = mnutama;
            this.KeyDown += new KeyEventHandler(this.OnKeyDown);
            ActiveControl = btnOpenLokasi;
        }

        #region Code
        private void SelectToolBar(Button btn)
        {
            cls.OpenForm op = new cls.OpenForm(frmUtama);

            switch (btn.AccessibleName)
            {
                case "RESTORE":
                    if (txtLokasi.Text == "")
                    {
                        psn.PesanInfo("Lokasi Restore Masih Kosong");
                    }
                    else
                    {
                        RestoreData();
                    }
                    break;
                case "KELUAR":
                    op.DatabaseOpen("Database", userName);
                    frmUtama.lblNamaForm.Visible = false;
                    break;
                default:
                    break;
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    if (btnOpenLokasi.Enabled == true)
                        SelectToolBar(btnRestore);
                    break;
                case Keys.F10:
                    SelectToolBar(btnKeluar);
                    break;
                default:
                    break;
            }
        }

        private void RestoreData()
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
                pictureBox1.Visible = true;
                btnRestore.Enabled = false;
            }
        }
        #endregion

        private void RestoreDB_Load(object sender, EventArgs e)
        {
            frmUtama.lblNamaForm.Text = "- Restore Database";
        }

        private void RestoreDB_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.BlockChar(e);
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            SelectToolBar(btnRestore);
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {            
            SelectToolBar(btnKeluar);
        }

        private void btnOpenLokasi_Click(object sender, EventArgs e)
        {
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "SQL files (*.sql)|*.sql|All files (*.*)|*.*";
            if (DialogResult.OK == sfd.ShowDialog())
            {
                txtLokasi.Text = sfd.FileName;
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                string conn = "server=" + frmUtama.server + ";user=root;password=haniel;database=pos_salatiga;charset=utf8";

                string file = txtLokasi.Text;
                using (MySqlConnection con = new MySqlConnection(conn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = con;
                            con.Open();
                            mb.ImportFromFile(file);
                            con.Close();
                        }
                    }
                }
                psn.CreateLogSuccessForm(this, "backgroundWorker1_DoWork", "Restore Success");
            }
            catch (Exception ex)
            {
                psn.CreateLogErrorForm(this, "backgroundWorker1_DoWork", "Restore Gagal", ex.ToString());
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
            btnRestore.Enabled = true;
            psn.PesanInfo("Restore Success");
        }
    }
}
