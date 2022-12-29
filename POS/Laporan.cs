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
    public partial class Laporan : Form
    {
        cls.Query qry = new cls.Query();

        public string userName;
        MenuUtama frmUtama;

        public Laporan(MenuUtama mnutama)
        {
            InitializeComponent();
            frmUtama = mnutama;
        }

        private void UsrAccess()
        {
            string data = qry.GetData(this, "UsrAccess", userName, 0,
                "lappembelianperiode,lappembeliansupplier,lappembelianbarang,cekhargabelibarang," +
                "lapgudangmasukperiode,lapgudangmasukbarang,lapgudangmasukkartustok,lapgudangmasukstok," +
                "lappindahgudangperiode,lappindahgudangbarang,lappindahgudangkartustok,lappindahgudangstok," +
                "lappenjualanperiode,lappenjualancustomer,lappenjualanbarang,lappenjualankategori," +
                "laprlpenjualanperiode,laprlpenjualanbarang,laprlpenjualankategori," +
                "lapkasperiode,lapreturpembelianperiode, lapreturpembeliansupplier, lapreturpembelianbarang," +
                "lapreturpenjualanperiode,lapreturpenjualancustomer,lapreturpenjualanbarang," +
                "lappenggunaanaplikasi,lapmutasistok", "usrmgmt", "usrname = '" + userName + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    if (filldata[0] == "1")
                    {
                        btnLapPembelianPeriode.Enabled = true;
                    }
                    if (filldata[1] == "1")
                    {
                        btnLapPembelianSupplier.Enabled = true;
                    }
                    if (filldata[2] == "1")
                    {
                        btnLapPembelianBarang.Enabled = true;
                    }
                    if (filldata[3] == "1")
                    {
                        btnCekHargaBeli.Enabled = true;
                    }
                    if (filldata[4] == "1")
                    {
                        btnLapGudangMasukPeriode.Enabled = true;
                    }
                    if (filldata[5] == "1")
                    {
                        btnLapGudangMasukBarang.Enabled = true;
                    }
                    if (filldata[6] == "1")
                    {
                        btnLapGudangMasukKartuStok.Enabled = true;
                    }
                    if (filldata[7] == "1")
                    {
                        btnLapGudangMasukStok.Enabled = true;
                    }
                    if (filldata[8] == "1")
                    {
                        btnLapPindahGudangPeriode.Enabled = true;
                    }
                    if (filldata[9] == "1")
                    {
                        btnLapPindahGudangBarang.Enabled = true;
                    }
                    if (filldata[10] == "1")
                    {
                        btnLapPindahGudangKartuStok.Enabled = true;
                    }
                    if (filldata[11] == "1")
                    {
                        btnLapPindahGudangStok.Enabled = true;
                    }
                    if (filldata[12] == "1")
                    {
                        btnLapPenjualanPeriode.Enabled = true;
                    }
                    if (filldata[13] == "1")
                    {
                        btnLapPenjualanCustomer.Enabled = true;
                    }
                    if (filldata[14] == "1")
                    {
                        btnLapPenjualanBarang.Enabled = true;
                    }
                    if (filldata[15] == "1")
                    {
                        btnLapPenjualanKategori.Enabled = true;
                    }
                    if (filldata[16] == "1")
                    {
                        btnLapRLPenjualanPeriode.Enabled = true;
                    }
                    if (filldata[17] == "1")
                    {
                        btnLapRLPenjualanBarang.Enabled = true;
                    }
                    if (filldata[18] == "1")
                    {
                        btnLapRLPenjualanKategori.Enabled = true;
                    }
                    if (filldata[19] == "1")
                    {
                        btnLapKasPeriode.Enabled = true;
                    }
                    if (filldata[20] == "1")
                    {
                        btnLapReturBeliPeriode.Enabled = true;
                    }
                    if (filldata[21] == "1")
                    {
                        btnLapReturBeliSupplier.Enabled = true;
                    }
                    if (filldata[22] == "1")
                    {
                        btnLapReturBeliBarang.Enabled = true;
                    }
                    if (filldata[23] == "1")
                    {
                        btnLapReturJualPeriode.Enabled = true;
                    }
                    if (filldata[24] == "1")
                    {
                        btnLapReturJualCustomer.Enabled = true;
                    }
                    if (filldata[25] == "1")
                    {
                        btnLapReturJualBarang.Enabled = true;
                    }
                    if (filldata[26] == "1")
                    {
                        btnLapPenggunaanAppPeriode.Enabled = true;
                    }
                    if (filldata[27] == "1")
                    {
                        btnLapMutasiStok.Enabled = true;
                    }

                    qry.InsertLogAktivitas("UsrAccess", this, userName, userName);
                }
            }
        }

        private void OpenLaporan(string jenisLaporan)
        {
            cls.OpenForm op = new cls.OpenForm(frmUtama);
            op.LaporanFilterOpen(this, "Laporan Report", jenisLaporan, userName);
        }

        private void OpenLaporanParam(string jenisLaporan)
        {
            cls.OpenForm op = new cls.OpenForm(frmUtama);
            op.LaporanFilterParamOpen(this, "Laporan Param Report", jenisLaporan, userName);
        }

        private void OpenLaporanParam2(string jenisLaporan)
        {
            cls.OpenForm op = new cls.OpenForm(frmUtama);
            op.LaporanFilterParam2Open(this, "Laporan Param 2 Report", jenisLaporan, userName);
        }

        private void btnLapPembelianPeriode_Click(object sender, EventArgs e)
        {
            OpenLaporan("LaporanPembelianPeriode");
        }

        private void btnLapPembelianSupplier_Click(object sender, EventArgs e)
        {
            OpenLaporanParam("LaporanPembelianSupplier");
        }

        private void btnLapPembelianBarang_Click(object sender, EventArgs e)
        {
            OpenLaporanParam("LaporanPembelianBarang");
        }

        private void btnLapPenjualanPeriode_Click(object sender, EventArgs e)
        {
            OpenLaporan("LaporanPenjualanPeriode");
        }

        private void btnLapPenjualanKategori_Click(object sender, EventArgs e)
        {
            OpenLaporanParam("LaporanPenjualanKategori");
        }

        private void Laporan_Load(object sender, EventArgs e)
        {
            frmUtama.lblNamaForm.Text = "- Laporan";
            UsrAccess();
        }

        private void btnLapPenjualanBarang_Click(object sender, EventArgs e)
        {
            OpenLaporanParam("LaporanPenjualanBarang");
        }

        private void btnLapPenjualanCustomer_Click(object sender, EventArgs e)
        {
            OpenLaporanParam("LaporanPenjualanCustomer");
        }

        private void btnLapKasPeriode_Click(object sender, EventArgs e)
        {
            OpenLaporan("LaporanKasPeriode");
        }

        private void btnLapGudangMasukStok_Click(object sender, EventArgs e)
        {
            OpenLaporanParam("LaporanGudangMasukStok");
        }

        private void btnLapPindahGudangStok_Click(object sender, EventArgs e)
        {
            OpenLaporanParam("LaporanPindahGudangStok");
        }

        private void btnCekHargaBeli_Click(object sender, EventArgs e)
        {
            OpenLaporanParam2("CekHargaBeliBarang");
        }

        private void btnLapGudangMasukKartuStok_Click(object sender, EventArgs e)
        {
            OpenLaporanParam("LaporanGudangMasukKartuStok");
        }

        private void btnLapPindahGudangKartuStok_Click(object sender, EventArgs e)
        {
            OpenLaporanParam("LaporanPindahGudangKartuStok");
        }

        private void btnLapGudangMasukPeriode_Click(object sender, EventArgs e)
        {
            OpenLaporan("LaporanGudangMasukPeriode");
        }

        private void btnLapPindahGudangPeriode_Click(object sender, EventArgs e)
        {
            OpenLaporan("LaporanPindahGudangPeriode");
        }

        private void btnLapGudangMasukBarang_Click(object sender, EventArgs e)
        {
            OpenLaporanParam("LaporanGudangMasukBarang");
        }

        private void btnLapPindahGudangBarang_Click(object sender, EventArgs e)
        {
            OpenLaporanParam("LaporanPindahGudangBarang");
        }

        private void btnLapRLPenjualanPeriode_Click(object sender, EventArgs e)
        {
            OpenLaporan("LaporanRLPenjualanPeriode");
        }

        private void btnLapRLPenjualanBarang_Click(object sender, EventArgs e)
        {
            OpenLaporanParam("LaporanRLPenjualanBarang");
        }

        private void btnLapRLPenjualanKategori_Click(object sender, EventArgs e)
        {
            OpenLaporanParam("LaporanRLPenjualanKategori");
        }

        private void btnLapPenggunaanAppPeriode_Click(object sender, EventArgs e)
        {
            OpenLaporan("LaporanLogApp");
        }

        private void btnLapReturBeliPeriode_Click(object sender, EventArgs e)
        {
            OpenLaporan("LaporanReturPembelianPeriode");
        }

        private void btnLapReturBeliSupplier_Click(object sender, EventArgs e)
        {
            OpenLaporanParam("LaporanReturPembelianSupplier");
        }

        private void btnLapReturBeliBarang_Click(object sender, EventArgs e)
        {
            OpenLaporanParam("LaporanReturPembelianBarang");
        }

        private void btnLapReturJualPeriode_Click(object sender, EventArgs e)
        {
            OpenLaporan("LaporanReturPenjualanPeriode");
        }

        private void btnLapReturJualCustomer_Click(object sender, EventArgs e)
        {
            OpenLaporanParam("LaporanReturPenjualanCustomer");
        }

        private void btnLapReturJualBarang_Click(object sender, EventArgs e)
        {
            OpenLaporanParam("LaporanReturPenjualanBarang");
        }

        private void btnLapMutasiStok_Click(object sender, EventArgs e)
        {
            OpenLaporanParam("LaporanMutasiStok");
        }
    }
}
