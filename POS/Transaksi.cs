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
    public partial class Transaksi : Form
    {
        cls.Query qry = new cls.Query();

        public string userName;
        MenuUtama frmUtama;

        public Transaksi(MenuUtama mnutama)
        {
            InitializeComponent();
            frmUtama = mnutama;
        }

        private void UsrAccess()
        {
            string data = qry.GetData(this, "UsrAccess", userName, 0,
                "pembelian,returpembelian,hutang,gudangmasuk,pindahgudang,diskon,penjualan,returpenjualan,piutang,kas,penyesuaian", "usrmgmt", "usrname = '" + userName + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    if (filldata[0] == "1")
                    {
                        btnPembelian.Enabled = true;
                    }
                    if (filldata[1] == "1")
                    {
                        btnReturPembelian.Enabled = true;
                    }
                    if (filldata[2] == "1")
                    {
                        btnHutang.Enabled = true;
                    }
                    if (filldata[3] == "1")
                    {
                        btnGudang.Enabled = true;
                    }
                    if (filldata[4] == "1")
                    {
                        btnPindahGudang.Enabled = true;
                    }
                    if (filldata[5] == "1")
                    {
                        btnDiskon.Enabled = true;
                    }
                    if (filldata[6] == "1")
                    {
                        btnPenjualan.Enabled = true;
                    }
                    if (filldata[7] == "1")
                    {
                        btnReturPenjualan.Enabled = true;
                    }
                    if (filldata[8] == "1")
                    {
                        btnPiutang.Enabled = true;
                    }
                    if (filldata[9] == "1")
                    {
                        btnKas.Enabled = true;
                    }
                    if (filldata[10] == "1")
                    {
                        btnPenyesuaian.Enabled = true;
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

        private void btnPembelian_Click(object sender, EventArgs e)
        {
            OpenPencarian("Pembelian");
        }

        private void btnGudang_Click(object sender, EventArgs e)
        {
            OpenPencarian("Gudang");
        }

        private void btnPindahGudang_Click(object sender, EventArgs e)
        {
            OpenPencarian("PindahGudang");
        }

        private void btnKas_Click(object sender, EventArgs e)
        {
            OpenPencarian("Kas");
        }

        private void btnDiskon_Click(object sender, EventArgs e)
        {
            OpenPencarian("Diskon");
        }

        private void btnPenjualan_Click(object sender, EventArgs e)
        {
            OpenPencarian("Penjualan");
        }

        private void Transaksi_Load(object sender, EventArgs e)
        {
            frmUtama.lblNamaForm.Text = "- Transaksi";
            UsrAccess();
        }

        private void btnHutang_Click(object sender, EventArgs e)
        {
            OpenPencarian("Hutang");
        }

        private void btnPiutang_Click(object sender, EventArgs e)
        {
            OpenPencarian("Piutang");
        }

        private void btnReturPenjualan_Click(object sender, EventArgs e)
        {
            OpenPencarian("ReturPenjualan");
        }

        private void btnReturPembelian_Click(object sender, EventArgs e)
        {
            OpenPencarian("ReturPembelian");
        }

        private void btnPenyesuaian_Click(object sender, EventArgs e)
        {
            OpenPencarian("Penyesuaian");
        }
    }
}
