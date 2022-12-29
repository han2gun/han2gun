using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class Pengaturan : Form
    {
        cls.Query qry = new cls.Query();

        public string userName;
        MenuUtama frmUtama;

        public Pengaturan(MenuUtama mnutama)
        {
            InitializeComponent();
            frmUtama = mnutama;
        }

        #region code
        private void UsrAccess()
        {
            string data = qry.GetData(this, "UsrAccess", userName, 0,
                "usrmgmt,ubahpassword", "usrmgmt", "usrname = '" + userName + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    if (filldata[0] == "1")
                    {
                        btnUsrMgmt.Enabled = true;
                    }
                    if (filldata[1] == "1")
                    {
                        btnUbahPass.Enabled = true;
                    }

                    qry.InsertLogAktivitas("UsrAccess", this, userName, userName);
                }
            }
        }

        private void OpenPencarian(string formPencarian)
        {
            cls.OpenForm op = new cls.OpenForm(frmUtama);
            op.PencarianOpen("Pencarian", formPencarian, userName);
        }

        private void OpenUbahPassword()
        {
            cls.OpenForm op = new cls.OpenForm(frmUtama);
            op.UbahPassOpen(this, "UbahPass", "", userName);
        }
        #endregion

        private void Pengaturan_Load(object sender, EventArgs e)
        {
            frmUtama.lblNamaForm.Text = "- Pengaturan";
            UsrAccess();
        }

        private void btnUsrMgmt_Click(object sender, EventArgs e)
        {
            OpenPencarian("PengaturanPengguna");
        }

        private void btnUbahPass_Click(object sender, EventArgs e)
        {
            OpenUbahPassword();
        }
    }
}
