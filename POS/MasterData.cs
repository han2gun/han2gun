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
    public partial class MasterData : Form
    {
        cls.Query qry = new cls.Query();

        public string userName;
        MenuUtama frmUtama;

        public MasterData(MenuUtama mnutama)
        {
            InitializeComponent();
            frmUtama = mnutama;
        }

        private void UsrAccess()
        {
            string data = qry.GetData(this, "UsrAccess", userName, 0,
                "identitas,karyawan,pelanggan,pemasok,kelbarang,barang", "usrmgmt", "usrname = '" + userName + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    if (filldata[0] == "1")
                    {
                        btnDataUsaha.Enabled = true;
                    }
                    if (filldata[1] == "1")
                    {
                        btnKaryawan.Enabled = true;
                    }
                    if (filldata[2] == "1")
                    {
                        btnCustomer.Enabled = true;
                    }
                    if (filldata[3] == "1")
                    {
                        btnSupplier.Enabled = true;
                    }
                    if (filldata[4] == "1")
                    {
                        btnKategori.Enabled = true;
                    }
                    if (filldata[5] == "1")
                    {
                        btnBarang.Enabled = true;
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

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            OpenPencarian("Supplier");
        }

        private void btnKaryawan_Click(object sender, EventArgs e)
        {
            OpenPencarian("Karyawan");
        }

        private void btnDataUsaha_Click(object sender, EventArgs e)
        {
            cls.OpenForm op = new cls.OpenForm(frmUtama);
            op.DataUsahaOpen(this, "Data Usaha", "", userName);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            OpenPencarian("Customer");
        }

        private void btnKategori_Click(object sender, EventArgs e)
        {
            OpenPencarian("KategoriBarang");
        }

        private void btnBarang_Click(object sender, EventArgs e)
        {
            OpenPencarian("Barang");
        }

        private void MasterData_Load(object sender, EventArgs e)
        {
            frmUtama.lblNamaForm.Text = "- Master Data";
            UsrAccess();
        }
    }
}
