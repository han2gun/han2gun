using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.rpt
{
    public partial class Laporan : Form
    {
        cls.Fungsi fs = new cls.Fungsi();
        cls.Pesan psn = new cls.Pesan();
        cls.Query qry = new cls.Query();

        MenuUtama frmUtama;
        public string userName;
        public string jenisLaporan;

        string kasAwalMasuk = "0";
        string kasAwalKeluar = "0";

        public Laporan(MenuUtama mnutama)
        {
            InitializeComponent();

            frmUtama = mnutama;
            this.KeyDown += new KeyEventHandler(this.OnKeyDown);
            ActiveControl = dtAwal;
        }

        #region code
        private void SelectToolBar(Button btn)
        {
            switch (btn.AccessibleName)
            {
                case "KELUAR":
                    cls.OpenForm op = new cls.OpenForm(frmUtama);
                    op.LaporanOpen("Laporan", userName);
                    break;
                default:
                    break;
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F10:
                    SelectToolBar(btnKeluar);
                    break;
                default:
                    break;
            }
        }

        private void KasAwalMasuk()
        {
            string data = qry.GetData(this, "KasAwalMasuk", "", 0,
                    "sum(b.nominal)", "kas a INNER JOIN kas_detail b ON a.id = b.id",
                    "a.tgltransaksi < '" + dtAwal.Value.ToString("yyyy-MM-dd") + "' AND a.jeniskas = 1");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    if (filldata[0] == "")
                    {
                        kasAwalMasuk = "0";
                    }
                    else
                    {
                        kasAwalMasuk = filldata[0];
                    }

                    qry.InsertLogAktivitas("KasAwalMasuk", this, "", userName);
                }
            }
        }

        private void KasAwalKeluar()
        {
            string data = qry.GetData(this, "KasAwalKeluar", "", 0,
                    "sum(b.nominal)", "kas a INNER JOIN kas_detail b ON a.id = b.id",
                    "a.tgltransaksi < '" + dtAwal.Value.ToString("yyyy-MM-dd") + "' AND a.jeniskas = 0");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    if (filldata[0] == "")
                    {
                        kasAwalKeluar = "0";
                    }
                    else
                    {
                        kasAwalKeluar = filldata[0];
                    }

                    qry.InsertLogAktivitas("KasAwalKeluar", this, "", userName);
                }
            }
        }

        private void ViewReport()
        {
            if(jenisLaporan == "LaporanPembelianPeriode")
            {
                qry.CetakDokumen(this, "",
                    "a.id,a.idsupplier,a.nonota,a.tgltransaksi,a.tgltempo,a.catatan,a.total,a.discpersen,a.discrp,a.potlain,a.biayalain," +
                    "a.ppn,a.ppnnominal,a.ongkir,a.grandtotal,b.nama as namasupp,b.alamat as alamatsupp,b.telp as telpsupp,b.nohp as nohpsupp," +
                    "b.fax as faxsupp,b.email as emailsupp,b.npwp as npwpsupp,b.website as websitesupp,b.catatan as catatansupp,c.barcode," +
                    "c.nama as namabarang,c.keterangan,c.qty,c.satuan,c.hbeli,c.discpersen as discpersen_dtl,c.discpersen2 as discpersen2_dtl," +
                    "c.discpersen3 as discpersen3_dtl,c.discrp as discrp_dtl,c.ppn as ppn_dtl,c.subtotal as subtotal_dtl,d.idkategori,e.nama as namakategori",
                    "pembelian a INNER JOIN pembelian_detail c ON a.id = c.id " +
                    "INNER JOIN barang d ON c.barcode = d.barcode " +
                    "INNER JOIN supplier b ON a.idsupplier = b.id " +
                    "INNER JOIN kategori e ON d.idkategori = e.id",
                    "where a.tgltransaksi >= '" + dtAwal.Value.ToString("yyyy-MM-dd") + "' " +
                    "and a.tgltransaksi <= '" + dtAkhir.Value.ToString("yyyy-MM-dd") + "'",
                    "lap_pembelian_periode_1");
                cr.PembelianPeriode rptDoc = new cr.PembelianPeriode();
                rptDoc.SetDataSource(qry.dataset.Tables[1]);
                rptDoc.DataDefinition.FormulaFields["periode"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + " s/d " +
                    "" + dtAkhir.Value.ToString("dd-MMM-yyyy") + "'";
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if (jenisLaporan == "LaporanReturPembelianPeriode")
            {
                qry.CetakDokumen(this, "",
                    "a.id,a.idsupplier,a.idpembelian,a.tgltransaksi,a.catatan,a.total," +
                    "a.ongkir,a.grandtotal,b.barcode,b.nama,b.keterangan,b.qty,b.satuan," +
                    "b.hbeli,b.discpersen,b.discpersen2,b.discpersen3,b.discrp,b.subtotal," +
                    "b.subtotalbersih,b.kondisi,c.nama as namasupp,c.alamat,c.telp,c.nohp," +
                    "c.fax,c.email,c.npwp,c.website,c.catatan as catatansupp,d.nonota",
                    "retur_pembelian a INNER JOIN retur_pembelian_detail b ON a.id = b.id " +
                    "INNER JOIN supplier c ON a.idsupplier = c.id " +
                    "INNER JOIN pembelian d ON a.idpembelian = d.id",
                    "where a.tgltransaksi >= '" + dtAwal.Value.ToString("yyyy-MM-dd") + "' " +
                    "and a.tgltransaksi <= '" + dtAkhir.Value.ToString("yyyy-MM-dd") + "'",
                    "retur_pembelian_20");
                cr.ReturPembelianPeriode rptDoc = new cr.ReturPembelianPeriode();
                rptDoc.SetDataSource(qry.dataset.Tables[20]);
                rptDoc.DataDefinition.FormulaFields["periode"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + " s/d " +
                    "" + dtAkhir.Value.ToString("dd-MMM-yyyy") + "'";
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if(jenisLaporan == "LaporanGudangMasukPeriode")
            {
                qry.CetakDokumen(this, "",
                    "a.id,a.idpembelian,a.tgltransaksi,a.catatan,b.numbpembelian,b.barcode,b.nama,b.qty as qtyterima,c.qty as qtypembelian,b.satuan,b.tglrusak as tglexp",
                    "gudang_masuk a INNER JOIN gudang_masuk_detail b ON a.id = b.id " +
                    "INNER JOIN pembelian_detail c ON b.numbpembelian = c.numb",
                    "where a.tgltransaksi >= '" + dtAwal.Value.ToString("yyyy-MM-dd") + "' " +
                    "and a.tgltransaksi <= '" + dtAkhir.Value.ToString("yyyy-MM-dd") + "'",
                    "gudang_masuk_13");
                cr.GudangMasukPeriode rptDoc = new cr.GudangMasukPeriode();
                rptDoc.SetDataSource(qry.dataset.Tables[13]);
                rptDoc.DataDefinition.FormulaFields["periode"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + " s/d " +
                    "" + dtAkhir.Value.ToString("dd-MMM-yyyy") + "'";
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if(jenisLaporan == "LaporanPindahGudangPeriode")
            {
                qry.CetakDokumen(this, "",
                    "a.id,a.tgltransaksi,a.catatan,a.lokasi,b.barcode,b.nama,b.qty,b.satuan",
                    "pindah_gudang a INNER JOIN pindah_gudang_detail b ON a.id = b.id",
                    "where a.tgltransaksi >= '" + dtAwal.Value.ToString("yyyy-MM-dd") + "' " +
                    "and a.tgltransaksi <= '" + dtAkhir.Value.ToString("yyyy-MM-dd") + "'",
                    "pindah_gudang_14");
                cr.PindahGudangPeriode rptDoc = new cr.PindahGudangPeriode();
                rptDoc.SetDataSource(qry.dataset.Tables[14]);
                rptDoc.DataDefinition.FormulaFields["periode"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + " s/d " +
                    "" + dtAkhir.Value.ToString("dd-MMM-yyyy") + "'";
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if(jenisLaporan == "LaporanPenjualanPeriode")
            {
                qry.CetakDokumen(this, "",
                    "a.id,a.idcustomer,a.sales,a.tgltransaksi,a.catatan,a.jenisbayar,a.bank,a.nokartu,a.total,a.discpersen,a.discrp,a.ppn," +
                    "a.ppnnominal,a.ongkir,a.grandtotal,a.bayar,a.kembalian,b.barcode,b.qty,b.satuan,b.hjual,b.discpersen as discpersen_dtl," +
                    "b.discrp as discrp_dtl,b.subtotal,c.nama as namacust,c.alamat,c.telp,c.nohp,c.fax,c.email,c.npwp,c.website,c.catatan as catatancust," +
                    "d.idkategori,b.nama as namabarang,b.keterangan,e.nama as namakategori",
                    "penjualan a INNER JOIN penjualan_detail b ON a.id = b.id " +
                    "INNER JOIN barang d ON b.barcode = d.barcode " +
                    "INNER JOIN kategori e ON d.idkategori = e.id " +
                    "INNER JOIN customer c ON a.idcustomer = c.id ",
                    "where a.tgltransaksi >= '" + dtAwal.Value.ToString("yyyy-MM-dd") + "' " +
                    "and a.tgltransaksi <= '" + dtAkhir.Value.ToString("yyyy-MM-dd") + "'",
                    "lap_penjualan_periode_2");
                cr.PenjualanPeriode rptDoc = new cr.PenjualanPeriode();
                rptDoc.SetDataSource(qry.dataset.Tables[2]);
                rptDoc.DataDefinition.FormulaFields["periode"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + " s/d " +
                    "" + dtAkhir.Value.ToString("dd-MMM-yyyy") + "'";
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if (jenisLaporan == "LaporanReturPenjualanPeriode")
            {
                qry.CetakDokumen(this, "",
                    "a.id,a.idcustomer,a.idpenjualan,a.tgltransaksi,a.catatan,a.grandtotal," +
                    "b.barcode,b.nama,b.keterangan,b.qty,b.satuan,b.hjual," +
                    "b.discpersen,b.discrp,b.subtotal,b.subtotalhpp,b.kondisi,c.nama as namacustomer," +
                    "c.alamat,c.telp,c.nohp,c.fax,c.email,c.npwp,c.website,c.catatan as catatancustomer",
                    "retur_penjualan a INNER JOIN retur_penjualan_detail b ON a.id = b.id " +
                    "INNER JOIN customer c ON a.idcustomer = c.id",
                    "where a.tgltransaksi >= '" + dtAwal.Value.ToString("yyyy-MM-dd") + "' " +
                    "and a.tgltransaksi <= '" + dtAkhir.Value.ToString("yyyy-MM-dd") + "'",
                    "retur_penjualan_19");
                cr.ReturPenjualanPeriode rptDoc = new cr.ReturPenjualanPeriode();
                rptDoc.SetDataSource(qry.dataset.Tables[19]);
                rptDoc.DataDefinition.FormulaFields["periode"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + " s/d " +
                    "" + dtAkhir.Value.ToString("dd-MMM-yyyy") + "'";
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if (jenisLaporan == "LaporanRLPenjualanPeriode")
            {
                qry.CetakDokumen(this, "",
                    "a.id,a.idcustomer,a.sales,a.tgltransaksi,a.catatan,a.jenisbayar,a.bank,a.nokartu," +
                    "a.total,a.discpersen,a.discrp,a.ppn,a.ppnnominal,a.ongkir,a.grandtotal,a.bayar,a.kembalian," +
                    "a.flaglunas,b.barcode,b.qty,b.satuan,b.hjual,b.discpersen as discdetail,b.discrp as discrpdetail," +
                    "b.subtotal,b.subtotalhpp,b.nama as namabarang,b.keterangan,d.id as idkategori,d.nama as namakategori," +
                    "e.nama as namacustomer,e.alamat,e.telp,e.nohp,e.fax,e.email,e.npwp,e.website,e.catatan as catatancustomer",
                    "penjualan a INNER JOIN penjualan_detail b ON a.id = b.id " +
                    "INNER JOIN barang c ON b.barcode = c.barcode " +
                    "INNER JOIN kategori d ON c.idkategori = d.id " +
                    "INNER JOIN customer e ON a.idcustomer = e.id ",
                    "where a.tgltransaksi >= '" + dtAwal.Value.ToString("yyyy-MM-dd") + "' " +
                    "and a.tgltransaksi <= '" + dtAkhir.Value.ToString("yyyy-MM-dd") + "'",
                    "lap_rl_penjualan_18");
                cr.RLPenjualanPeriode rptDoc = new cr.RLPenjualanPeriode();
                rptDoc.SetDataSource(qry.dataset.Tables[18]);
                rptDoc.DataDefinition.FormulaFields["periode"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + " s/d " +
                    "" + dtAkhir.Value.ToString("dd-MMM-yyyy") + "'";
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if(jenisLaporan == "LaporanKasPeriode")
            {
                qry.CetakDokumenUnion(this, "",
                    "a.id,if (a.jeniskas = 1, 'KAS MASUK', 'KAS KELUAR') as jeniskas,a.tgltransaksi," +
                    "a.catatan,a.grandtotal,b.keterangan as keterangandtl,b.nominal as nominaldtlkeluar,0 as nominaldtlmasuk " +
                    "from kas a inner join kas_detail b on a.id = b.id where a.jeniskas = 0 and " +
                    "a.tgltransaksi >= '" + dtAwal.Value.ToString("yyyy-MM-dd") + "' " +
                    "and a.tgltransaksi <= '" + dtAkhir.Value.ToString("yyyy-MM-dd") + "'" +
                    "UNION ALL " +
                    "select a.id,if (a.jeniskas = 1, 'KAS MASUK', 'KAS KELUAR') as jeniskas,a.tgltransaksi," +
                    "a.catatan,a.grandtotal,b.keterangan as keterangandtl,0 as nominaldtlkeluar,b.nominal as nominaldtlmasuk " +
                    "from kas a inner join kas_detail b on a.id = b.id where a.jeniskas = 1 and " +
                    "a.tgltransaksi >= '" + dtAwal.Value.ToString("yyyy-MM-dd") + "' " +
                    "and a.tgltransaksi <= '" + dtAkhir.Value.ToString("yyyy-MM-dd") + "'" +
                    "order by tgltransaksi asc",
                    "lap_kas_periode_3");
                cr.KasPeriode rptDoc = new cr.KasPeriode();
                rptDoc.SetDataSource(qry.dataset.Tables[3]);
                rptDoc.DataDefinition.FormulaFields["periode"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + " s/d " +
                    "" + dtAkhir.Value.ToString("dd-MMM-yyyy") + "'";
                rptDoc.DataDefinition.FormulaFields["kasawalmasuk"].Text = "'" + kasAwalMasuk + "'";
                rptDoc.DataDefinition.FormulaFields["kasawalkeluar"].Text = "'" + kasAwalKeluar + "'";
                rptDoc.DataDefinition.FormulaFields["tglawal"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + "'";
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if (jenisLaporan == "LaporanLogApp")
            {
                qry.CetakDokumen(this, "",
                    "tgl,time,keterangan,namaform,idtransaksi,pengguna",
                    "logaudit",
                    "where tgl >= '" + dtAwal.Value.ToString("yyyy-MM-dd") + "' " +
                    "and tgl <= '" + dtAkhir.Value.ToString("yyyy-MM-dd") + "'",
                    "log_app_22");
                cr.LogApp rptDoc = new cr.LogApp();
                rptDoc.SetDataSource(qry.dataset.Tables[22]);
                rptDoc.DataDefinition.FormulaFields["periode"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + " s/d " +
                    "" + dtAkhir.Value.ToString("dd-MMM-yyyy") + "'";
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
        }
        #endregion

        private void Laporan_Load(object sender, EventArgs e)
        {
            if (jenisLaporan == "LaporanPembelianPeriode")
            {
                frmUtama.lblNamaForm.Text = "- Laporan Pembelian Periode";
            }
            else if (jenisLaporan == "LaporanReturPembelianPeriode")
            {
                frmUtama.lblNamaForm.Text = "- Laporan Retur Pembelian Periode";
            }
            else if (jenisLaporan == "LaporanGudangMasukPeriode")
            {
                frmUtama.lblNamaForm.Text = "- Laporan Gudang Masuk Periode";
            }
            else if (jenisLaporan == "LaporanPindahGudangPeriode")
            {
                frmUtama.lblNamaForm.Text = "- Laporan Pindah Gudang Periode";
            }
            else if(jenisLaporan == "LaporanPenjualanPeriode")
            {
                frmUtama.lblNamaForm.Text = "- Laporan Penjualan Periode";
            }
            else if (jenisLaporan == "LaporanReturPenjualanPeriode")
            {
                frmUtama.lblNamaForm.Text = "- Laporan Retur Penjualan Periode";
            }
            else if (jenisLaporan == "LaporanRLPenjualanPeriode")
            {
                frmUtama.lblNamaForm.Text = "- Laporan R/L Penjualan Periode";
            }
            else if (jenisLaporan == "LaporanKasPeriode")
            {
                frmUtama.lblNamaForm.Text = "- Laporan Kas Periode";
            }
            else if (jenisLaporan == "LaporanLogApp")
            {
                frmUtama.lblNamaForm.Text = "- Laporan Log Aplikasi";
            }
        }

        private void Laporan_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.BlockChar(e);
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            SelectToolBar(btnKeluar);
        }

        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            if (dtAwal.Value > dtAkhir.Value)
            {
                psn.PesanInfo("Tanggal Awal Tidak Boleh Lebih Besar Dari Tanggal Akhir");
                dtAwal.Focus();
            }
            else
            {
                if (jenisLaporan == "LaporanKasPeriode")
                {
                    KasAwalMasuk();
                    KasAwalKeluar();
                }

                ViewReport();
            }
        }
    }
}
