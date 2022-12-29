using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.frm
{
    public partial class UbahPassword : Form
    {
        cls.Fungsi fs = new cls.Fungsi();
        cls.Pesan psn = new cls.Pesan();
        cls.Query qry = new cls.Query();

        MenuUtama frmUtama;
        public string userName;
        public string id;

        public UbahPassword(MenuUtama mnutama)
        {
            InitializeComponent();

            frmUtama = mnutama;
            this.KeyDown += new KeyEventHandler(this.OnKeyDown);
            ActiveControl = txtPassword;
        }

        #region code
        private void UsrAccess()
        {
            string data = qry.GetData(this, "UsrAccess", userName, 0,
                "ubahpasswordsv", "usrmgmt", "usrname = '" + userName + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    if (filldata[0] == "1")
                        btnSimpan.Enabled = true;

                    qry.InsertLogAktivitas("UsrAccess", this, userName, userName);
                }
            }
        }

        private void Clear()
        {
            lblUserName.Text = userName;
            txtPassword.Text = "";
            txtPassword.Focus();
        }

        private void SelectToolBar(Button btn)
        {
            switch (btn.AccessibleName)
            {
                case "BARU":
                    DialogResult result = MessageBox.Show("Bersihkan Data?", "Konfirmasi", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        Clear();
                    }
                    break;
                case "SIMPAN":
                    if (txtPassword.Text.Trim() == "")
                    {
                        psn.PesanInfo("Password Masih Kosong");
                        txtPassword.Focus();
                    }
                    else
                    {
                        Simpan();
                    }
                    break;
                case "KELUAR":
                    cls.OpenForm op = new cls.OpenForm(frmUtama);
                    op.PengaturanOpen("Pengaturan", userName);
                    break;
                default:
                    break;
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F3:
                    if (btnSimpan.Enabled == true)
                        SelectToolBar(btnSimpan);
                    break;
                case Keys.F10:
                    SelectToolBar(btnKeluar);
                    break;
                default:
                    break;
            }
        }

        private void Simpan()
        {
            try
            {
                qry.UpdateData("usrmgmt",
                    "pass = password('" + txtPassword.Text.Trim() + "')",
                    "usrname = '" + lblUserName.Text + "'");

                qry.InsertLogAktivitas("Update", this, lblUserName.Text, userName);
                fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Update " + lblUserName.Text + " Berhasil", frmUtama.tooltip_x, frmUtama.tooltip_y, "info");
                Clear();
            }
            catch (Exception ex)
            {
                psn.CreateLogErrorForm(this, "Update", "Update " + lblUserName.Text + " Gagal", ex.ToString());
            }
        }
        #endregion

        private void UbahPassword_Load(object sender, EventArgs e)
        {
            lblUserName.Text = userName;

            frmUtama.lblNamaForm.Text = "- Ubah Password";
            UsrAccess();
        }

        private void UbahPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.BlockChar(e);
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            SelectToolBar(btnSimpan);
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            SelectToolBar(btnKeluar);
        }
    }
}
