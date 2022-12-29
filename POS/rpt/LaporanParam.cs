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
    public partial class LaporanParam : Form
    {
        cls.Fungsi fs = new cls.Fungsi();
        cls.Pesan psn = new cls.Pesan();
        cls.Query qry = new cls.Query();

        MenuUtama frmUtama;
        public static string id;
        public string userName;
        public string jenisLaporan;
        string stokAwalMasuk = "0";
        string stokAwalKeluar = "0";

        public LaporanParam(MenuUtama mnutama)
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

        private void TampilData(string id)
        {
            if(jenisLaporan == "LaporanPembelianSupplier")
            {
                string data = qry.GetData(this, "TampilData-LaporanPembelianSupplier", id, 8, "nama", "supplier", "id = '" + id + "'");

                if (data != "")
                {
                    string[] filldata = data.Split('|');

                    if (filldata.ToString() != "")
                    {
                        lblPencarian.Text = filldata[0];

                        qry.InsertLogAktivitas("TampilData-LaporanPembelianSupplier", this, txtPencarian.Text.Trim(), userName);
                    }
                }
            }
            else if (jenisLaporan == "LaporanReturPembelianSupplier")
            {
                string data = qry.GetData(this, "TampilData-LaporanReturPembelianSupplier", id, 8, "nama", "supplier", "id = '" + id + "'");

                if (data != "")
                {
                    string[] filldata = data.Split('|');

                    if (filldata.ToString() != "")
                    {
                        lblPencarian.Text = filldata[0];

                        qry.InsertLogAktivitas("TampilData-LaporanReturPembelianSupplier", this, txtPencarian.Text.Trim(), userName);
                    }
                }
            }
            else if (jenisLaporan == "LaporanPembelianBarang")
            {
                string data = qry.GetData(this, "TampilData-LaporanPembelianBarang", id, 8, "nama", "barang", "barcode = '" + id + "'");

                if (data != "")
                {
                    string[] filldata = data.Split('|');

                    if (filldata.ToString() != "")
                    {
                        lblPencarian.Text = filldata[0];

                        qry.InsertLogAktivitas("TampilData-LaporanPembelianBarang", this, txtPencarian.Text.Trim(), userName);
                    }
                }
            }
            else if (jenisLaporan == "LaporanReturPembelianBarang")
            {
                string data = qry.GetData(this, "TampilData-LaporanReturPembelianBarang", id, 8, "nama", "barang", "barcode = '" + id + "'");

                if (data != "")
                {
                    string[] filldata = data.Split('|');

                    if (filldata.ToString() != "")
                    {
                        lblPencarian.Text = filldata[0];

                        qry.InsertLogAktivitas("TampilData-LaporanReturPembelianBarang", this, txtPencarian.Text.Trim(), userName);
                    }
                }
            }
            else if (jenisLaporan == "LaporanPenjualanKategori")
            {
                string data = qry.GetData(this, "TampilData-LaporanPenjualanKategori", id, 8, "nama", "kategori", "id = '" + id + "'");

                if (data != "")
                {
                    string[] filldata = data.Split('|');

                    if (filldata.ToString() != "")
                    {
                        lblPencarian.Text = filldata[0];

                        qry.InsertLogAktivitas("TampilData-LaporanPenjualanKategori", this, txtPencarian.Text.Trim(), userName);
                    }
                }
            }
            else if (jenisLaporan == "LaporanPenjualanBarang")
            {
                string data = qry.GetData(this, "TampilData-LaporanPenjualanBarang", id, 8, "nama", "barang", "barcode = '" + id + "'");

                if (data != "")
                {
                    string[] filldata = data.Split('|');

                    if (filldata.ToString() != "")
                    {
                        lblPencarian.Text = filldata[0];

                        qry.InsertLogAktivitas("TampilData-LaporanPenjualanBarang", this, txtPencarian.Text.Trim(), userName);
                    }
                }
            }
            else if (jenisLaporan == "LaporanReturPenjualanBarang")
            {
                string data = qry.GetData(this, "TampilData-LaporanReturPenjualanBarang", id, 8, "nama", "barang", "barcode = '" + id + "'");

                if (data != "")
                {
                    string[] filldata = data.Split('|');

                    if (filldata.ToString() != "")
                    {
                        lblPencarian.Text = filldata[0];

                        qry.InsertLogAktivitas("TampilData-LaporanReturPenjualanBarang", this, txtPencarian.Text.Trim(), userName);
                    }
                }
            }
            else if (jenisLaporan == "LaporanPenjualanCustomer")
            {
                string data = qry.GetData(this, "TampilData-LaporanPenjualanCustomer", id, 8, "nama", "customer", "id = '" + id + "'");

                if (data != "")
                {
                    string[] filldata = data.Split('|');

                    if (filldata.ToString() != "")
                    {
                        lblPencarian.Text = filldata[0];

                        qry.InsertLogAktivitas("TampilData-LaporanPenjualanCustomer", this, txtPencarian.Text.Trim(), userName);
                    }
                }
            }
            else if (jenisLaporan == "LaporanReturPenjualanCustomer")
            {
                string data = qry.GetData(this, "TampilData-LaporanReturPenjualanCustomer", id, 8, "nama", "customer", "id = '" + id + "'");

                if (data != "")
                {
                    string[] filldata = data.Split('|');

                    if (filldata.ToString() != "")
                    {
                        lblPencarian.Text = filldata[0];

                        qry.InsertLogAktivitas("TampilData-LaporanReturPenjualanCustomer", this, txtPencarian.Text.Trim(), userName);
                    }
                }
            }
            else if (jenisLaporan == "LaporanGudangMasukBarang")
            {
                string data = qry.GetData(this, "TampilData-LaporanGudangMasukBarang", id, 8, "nama", "barang", "barcode = '" + id + "'");

                if (data != "")
                {
                    string[] filldata = data.Split('|');

                    if (filldata.ToString() != "")
                    {
                        lblPencarian.Text = filldata[0];

                        qry.InsertLogAktivitas("TampilData-LaporanGudangMasukBarang", this, txtPencarian.Text.Trim(), userName);
                    }
                }
            }
            else if (jenisLaporan == "LaporanGudangMasukKartuStok")
            {
                string data = qry.GetData(this, "TampilData-LaporanGudangMasukKartuStok", id, 8, "nama", "barang", "barcode = '" + id + "'");

                if (data != "")
                {
                    string[] filldata = data.Split('|');

                    if (filldata.ToString() != "")
                    {
                        lblPencarian.Text = filldata[0];

                        qry.InsertLogAktivitas("TampilData-LaporanGudangMasukKartuStok", this, txtPencarian.Text.Trim(), userName);
                    }
                }
            }
            else if (jenisLaporan == "LaporanGudangMasukStok")
            {
                string data = qry.GetData(this, "TampilData-LaporanGudangMasukStok", id, 8, "nama", "kategori", "id = '" + id + "'");

                if (data != "")
                {
                    string[] filldata = data.Split('|');

                    if (filldata.ToString() != "")
                    {
                        lblPencarian.Text = filldata[0];

                        qry.InsertLogAktivitas("TampilData-LaporanGudangMasukStok", this, txtPencarian.Text.Trim(), userName);
                    }
                }
            }
            else if (jenisLaporan == "LaporanPindahGudangBarang")
            {
                string data = qry.GetData(this, "TampilData-LaporanPindahGudangBarang", id, 8, "nama", "barang", "barcode = '" + id + "'");

                if (data != "")
                {
                    string[] filldata = data.Split('|');

                    if (filldata.ToString() != "")
                    {
                        lblPencarian.Text = filldata[0];

                        qry.InsertLogAktivitas("TampilData-LaporanPindahGudangBarang", this, txtPencarian.Text.Trim(), userName);
                    }
                }
            }
            else if (jenisLaporan == "LaporanPindahGudangKartuStok")
            {
                string data = qry.GetData(this, "TampilData-LaporanPindahGudangKartuStok", id, 8, "nama", "barang", "barcode = '" + id + "'");

                if (data != "")
                {
                    string[] filldata = data.Split('|');

                    if (filldata.ToString() != "")
                    {
                        lblPencarian.Text = filldata[0];

                        qry.InsertLogAktivitas("TampilData-LaporanPindahGudangKartuStok", this, txtPencarian.Text.Trim(), userName);
                    }
                }
            }
            else if (jenisLaporan == "LaporanPindahGudangStok")
            {
                string data = qry.GetData(this, "TampilData-LaporanPindahGudangStok", id, 8, "nama", "kategori", "id = '" + id + "'");

                if (data != "")
                {
                    string[] filldata = data.Split('|');

                    if (filldata.ToString() != "")
                    {
                        lblPencarian.Text = filldata[0];

                        qry.InsertLogAktivitas("TampilData-LaporanPindahGudangStok", this, txtPencarian.Text.Trim(), userName);
                    }
                }
            }
            else if (jenisLaporan == "LaporanMutasiStok")
            {
                string data = qry.GetData(this, "TampilData-LaporanMutasiStok", id, 8, "nama", "kategori", "id = '" + id + "'");

                if (data != "")
                {
                    string[] filldata = data.Split('|');

                    if (filldata.ToString() != "")
                    {
                        lblPencarian.Text = filldata[0];

                        qry.InsertLogAktivitas("TampilData-LaporanMutasiStok", this, txtPencarian.Text.Trim(), userName);
                    }
                }
            }
            else if (jenisLaporan == "LaporanKartuStok")
            {
                string data = qry.GetData(this, "TampilData-LaporanKartuStok", id, 8, "nama", "barang", "barcode = '" + id + "'");

                if (data != "")
                {
                    string[] filldata = data.Split('|');

                    if (filldata.ToString() != "")
                    {
                        lblPencarian.Text = filldata[0];

                        qry.InsertLogAktivitas("TampilData-LaporanKartuStok", this, txtPencarian.Text.Trim(), userName);
                    }
                }
            }
        }

        private void StokAwalMasuk(string id)
        {
            if (jenisLaporan == "LaporanGudangMasukKartuStok")
            {
                string data = qry.GetData(this, "StokAwalMasuk-LaporanGudangMasukKartuStok", id, 8,
                    "a.barcode,(SELECT SUM(gmd.qty) FROM gudang_masuk gm INNER JOIN gudang_masuk_detail gmd ON gm.id = gmd.id " +
                    "WHERE gmd.barcode = a.barcode AND gm.tgltransaksi < '" + dtAwal.Value.ToString("yyyy-MM-dd") + "') as awalmasuk", 
                    "barang a", "a.barcode = '" + id + "'");

                if (data != "")
                {
                    string[] filldata = data.Split('|');

                    if (filldata.ToString() != "")
                    {
                        if(filldata[1] == "")
                        {
                            stokAwalMasuk = "0";
                        }
                        else
                        {
                            stokAwalMasuk = filldata[1];
                        }

                        qry.InsertLogAktivitas("StokAwalMasuk-LaporanGudangMasukKartuStok", this, txtPencarian.Text.Trim(), userName);
                    }
                }
            }
            else if (jenisLaporan == "LaporanPindahGudangKartuStok")
            {
                string data = qry.GetData(this, "StokAwalMasuk-LaporanPindahGudangKartuStok", id, 8,
                    "a.barcode,(SELECT SUM(gmd.qty) FROM pindah_gudang gm INNER JOIN pindah_gudang_detail gmd ON gm.id = gmd.id " +
                    "WHERE gmd.barcode = a.barcode AND gm.tgltransaksi < '" + dtAwal.Value.ToString("yyyy-MM-dd") + "') as awalmasuk",
                    "barang a", "a.barcode = '" + id + "'");

                if (data != "")
                {
                    string[] filldata = data.Split('|');

                    if (filldata.ToString() != "")
                    {
                        if (filldata[1] == "")
                        {
                            stokAwalMasuk = "0";
                        }
                        else
                        {
                            stokAwalMasuk = filldata[1];
                        }

                        qry.InsertLogAktivitas("StokAwalMasuk-LaporanPindahGudangKartuStok", this, txtPencarian.Text.Trim(), userName);
                    }
                }
            }
            else if (jenisLaporan == "LaporanKartuStok")
            {
                string data = qry.GetData(this, "StokAwalMasuk-LaporanPindahGudangKartuStok", id, 8,
                    "a.barcode,(SELECT SUM(gmd.qty) FROM pindah_gudang gm INNER JOIN pindah_gudang_detail gmd ON gm.id = gmd.id " +
                    "WHERE gmd.barcode = a.barcode AND gm.tgltransaksi < '" + dtAwal.Value.ToString("yyyy-MM-dd") + "') as awalmasuk",
                    "barang a", "a.barcode = '" + id + "'");

                if (data != "")
                {
                    string[] filldata = data.Split('|');

                    if (filldata.ToString() != "")
                    {
                        if (filldata[1] == "")
                        {
                            stokAwalMasuk = "0";
                        }
                        else
                        {
                            stokAwalMasuk = filldata[1];
                        }

                        qry.InsertLogAktivitas("StokAwalMasuk-LaporanPindahGudangKartuStok", this, txtPencarian.Text.Trim(), userName);
                    }
                }
            }
        }

        private void StokAwalKeluar(string id)
        {
            if (jenisLaporan == "LaporanGudangMasukKartuStok")
            {
                string data = qry.GetData(this, "StokAwalKeluar-LaporanGudangMasukKartuStok", id, 8,
                    "a.barcode,(SELECT SUM(pgd.qty) FROM pindah_gudang pg INNER JOIN pindah_gudang_detail pgd ON pg.id = pgd.id " +
                    "WHERE pgd.barcode = a.barcode AND pg.tgltransaksi < '" + dtAwal.Value.ToString("yyyy-MM-dd") + "') as awalkeluar", 
                    "barang a", "a.barcode = '" + id + "'");

                if (data != "")
                {
                    string[] filldata = data.Split('|');

                    if (filldata.ToString() != "")
                    {
                        if(filldata[1] == "")
                        {
                            stokAwalKeluar = "0";
                        }
                        else
                        {
                            stokAwalKeluar = filldata[1];
                        }

                        qry.InsertLogAktivitas("StokAwalKeluar-LaporanGudangMasukKartuStok", this, txtPencarian.Text.Trim(), userName);
                    }
                }
            }
            else if (jenisLaporan == "LaporanPindahGudangKartuStok")
            {
                string data = qry.GetData(this, "StokAwalKeluar-LaporanPindahGudangKartuStok", id, 8,
                    "a.barcode,(SELECT SUM(pgd.qty) FROM penjualan pg INNER JOIN penjualan_detail pgd ON pg.id = pgd.id " +
                    "WHERE pgd.barcode = a.barcode AND pg.tgltransaksi < '" + dtAwal.Value.ToString("yyyy-MM-dd") + "') as awalkeluar",
                    "barang a", "a.barcode = '" + id + "'");

                if (data != "")
                {
                    string[] filldata = data.Split('|');

                    if (filldata.ToString() != "")
                    {
                        if (filldata[1] == "")
                        {
                            stokAwalKeluar = "0";
                        }
                        else
                        {
                            stokAwalKeluar = filldata[1];
                        }

                        qry.InsertLogAktivitas("StokAwalKeluar-LaporanPindahGudangKartuStok", this, txtPencarian.Text.Trim(), userName);
                    }
                }
            }
        }

        private void ViewReport()
        {
            if (jenisLaporan == "LaporanPembelianSupplier")
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
                    "where a.idsupplier = '" + txtPencarian.Text.Trim() + "' and a.tgltransaksi >= '" + dtAwal.Value.ToString("yyyy-MM-dd") + "' " +
                    "and a.tgltransaksi <= '" + dtAkhir.Value.ToString("yyyy-MM-dd") + "'",
                    "lap_pembelian_periode_1");
                cr.PembelianSupplier rptDoc = new cr.PembelianSupplier();
                rptDoc.SetDataSource(qry.dataset.Tables[1]);
                rptDoc.DataDefinition.FormulaFields["periode"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + " s/d " +
                    "" + dtAkhir.Value.ToString("dd-MMM-yyyy") + "'";
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if (jenisLaporan == "LaporanReturPembelianSupplier")
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
                    "where a.idsupplier = '" + txtPencarian.Text.Trim() + "' and a.tgltransaksi >= '" + dtAwal.Value.ToString("yyyy-MM-dd") + "' " +
                    "and a.tgltransaksi <= '" + dtAkhir.Value.ToString("yyyy-MM-dd") + "'",
                    "retur_pembelian_20");
                cr.ReturPembelianSupplier rptDoc = new cr.ReturPembelianSupplier();
                rptDoc.SetDataSource(qry.dataset.Tables[20]);
                rptDoc.DataDefinition.FormulaFields["periode"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + " s/d " +
                    "" + dtAkhir.Value.ToString("dd-MMM-yyyy") + "'";
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if (jenisLaporan == "LaporanPembelianBarang")
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
                    "where c.barcode = '" + txtPencarian.Text.Trim() + "' and a.tgltransaksi >= '" + dtAwal.Value.ToString("yyyy-MM-dd") + "' " +
                    "and a.tgltransaksi <= '" + dtAkhir.Value.ToString("yyyy-MM-dd") + "'",
                    "lap_pembelian_periode_1");
                cr.PembelianBarang rptDoc = new cr.PembelianBarang();
                rptDoc.SetDataSource(qry.dataset.Tables[1]);
                rptDoc.DataDefinition.FormulaFields["periode"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + " s/d " +
                    "" + dtAkhir.Value.ToString("dd-MMM-yyyy") + "'";
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if (jenisLaporan == "LaporanReturPembelianBarang")
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
                    "where b.barcode = '" + txtPencarian.Text.Trim() + "' and a.tgltransaksi >= '" + dtAwal.Value.ToString("yyyy-MM-dd") + "' " +
                    "and a.tgltransaksi <= '" + dtAkhir.Value.ToString("yyyy-MM-dd") + "'",
                    "retur_pembelian_20");
                cr.ReturPembelianBarang rptDoc = new cr.ReturPembelianBarang();
                rptDoc.SetDataSource(qry.dataset.Tables[20]);
                rptDoc.DataDefinition.FormulaFields["periode"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + " s/d " +
                    "" + dtAkhir.Value.ToString("dd-MMM-yyyy") + "'";
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if (jenisLaporan == "LaporanPenjualanKategori")
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
                    "where d.idkategori = '" + txtPencarian.Text.Trim() + "' and a.tgltransaksi >= '" + dtAwal.Value.ToString("yyyy-MM-dd") + "' " +
                    "and a.tgltransaksi <= '" + dtAkhir.Value.ToString("yyyy-MM-dd") + "' order by a.tgltransaksi asc",
                    "lap_penjualan_periode_2");
                cr.PenjualanKategori rptDoc = new cr.PenjualanKategori();
                rptDoc.SetDataSource(qry.dataset.Tables[2]);
                rptDoc.DataDefinition.FormulaFields["periode"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + " s/d " +
                    "" + dtAkhir.Value.ToString("dd-MMM-yyyy") + "'";
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if (jenisLaporan == "LaporanRLPenjualanKategori")
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
                    "where c.idkategori = '" + txtPencarian.Text.Trim() + "' and a.tgltransaksi >= '" + dtAwal.Value.ToString("yyyy-MM-dd") + "' " +
                    "and a.tgltransaksi <= '" + dtAkhir.Value.ToString("yyyy-MM-dd") + "' order by a.tgltransaksi asc",
                    "lap_rl_penjualan_18");
                cr.RLPenjualanKategori rptDoc = new cr.RLPenjualanKategori();
                rptDoc.SetDataSource(qry.dataset.Tables[18]);
                rptDoc.DataDefinition.FormulaFields["periode"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + " s/d " +
                    "" + dtAkhir.Value.ToString("dd-MMM-yyyy") + "'";
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if (jenisLaporan == "LaporanPenjualanBarang")
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
                    "where b.barcode = '" + txtPencarian.Text.Trim() + "' and a.tgltransaksi >= '" + dtAwal.Value.ToString("yyyy-MM-dd") + "' " +
                    "and a.tgltransaksi <= '" + dtAkhir.Value.ToString("yyyy-MM-dd") + "' order by a.tgltransaksi asc",
                    "lap_penjualan_periode_2");
                cr.PenjualanBarang rptDoc = new cr.PenjualanBarang();
                rptDoc.SetDataSource(qry.dataset.Tables[2]);
                rptDoc.DataDefinition.FormulaFields["periode"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + " s/d " +
                    "" + dtAkhir.Value.ToString("dd-MMM-yyyy") + "'";
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if (jenisLaporan == "LaporanReturPenjualanBarang")
            {
                qry.CetakDokumen(this, "",
                    "a.id,a.idcustomer,a.idpenjualan,a.tgltransaksi,a.catatan,a.grandtotal," +
                    "b.barcode,b.nama,b.keterangan,b.qty,b.satuan,b.hjual," +
                    "b.discpersen,b.discrp,b.subtotal,b.subtotalhpp,b.kondisi,c.nama as namacustomer," +
                    "c.alamat,c.telp,c.nohp,c.fax,c.email,c.npwp,c.website,c.catatan as catatancustomer",
                    "retur_penjualan a INNER JOIN retur_penjualan_detail b ON a.id = b.id " +
                    "INNER JOIN customer c ON a.idcustomer = c.id",
                    "where b.barcode = '" + txtPencarian.Text.Trim() + "' and a.tgltransaksi >= '" + dtAwal.Value.ToString("yyyy-MM-dd") + "' " +
                    "and a.tgltransaksi <= '" + dtAkhir.Value.ToString("yyyy-MM-dd") + "' order by a.tgltransaksi asc",
                    "retur_penjualan_19");
                cr.ReturPenjualanBarang rptDoc = new cr.ReturPenjualanBarang();
                rptDoc.SetDataSource(qry.dataset.Tables[19]);
                rptDoc.DataDefinition.FormulaFields["periode"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + " s/d " +
                    "" + dtAkhir.Value.ToString("dd-MMM-yyyy") + "'";
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if (jenisLaporan == "LaporanRLPenjualanBarang")
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
                    "where b.barcode = '" + txtPencarian.Text.Trim() + "' and a.tgltransaksi >= '" + dtAwal.Value.ToString("yyyy-MM-dd") + "' " +
                    "and a.tgltransaksi <= '" + dtAkhir.Value.ToString("yyyy-MM-dd") + "' order by a.tgltransaksi asc",
                    "lap_rl_penjualan_18");
                cr.RLPenjualanBarang rptDoc = new cr.RLPenjualanBarang();
                rptDoc.SetDataSource(qry.dataset.Tables[18]);
                rptDoc.DataDefinition.FormulaFields["periode"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + " s/d " +
                    "" + dtAkhir.Value.ToString("dd-MMM-yyyy") + "'";
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if (jenisLaporan == "LaporanPenjualanCustomer")
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
                    "where a.idcustomer = '" + txtPencarian.Text.Trim() + "' and a.tgltransaksi >= '" + dtAwal.Value.ToString("yyyy-MM-dd") + "' " +
                    "and a.tgltransaksi <= '" + dtAkhir.Value.ToString("yyyy-MM-dd") + "' order by a.tgltransaksi asc",
                    "lap_penjualan_periode_2");
                cr.PenjualanCustomer rptDoc = new cr.PenjualanCustomer();
                rptDoc.SetDataSource(qry.dataset.Tables[2]);
                rptDoc.DataDefinition.FormulaFields["periode"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + " s/d " +
                    "" + dtAkhir.Value.ToString("dd-MMM-yyyy") + "'";
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if (jenisLaporan == "LaporanReturPenjualanCustomer")
            {
                qry.CetakDokumen(this, "",
                    "a.id,a.idcustomer,a.idpenjualan,a.tgltransaksi,a.catatan,a.grandtotal," +
                    "b.barcode,b.nama,b.keterangan,b.qty,b.satuan,b.hjual," +
                    "b.discpersen,b.discrp,b.subtotal,b.subtotalhpp,b.kondisi,c.nama as namacustomer," +
                    "c.alamat,c.telp,c.nohp,c.fax,c.email,c.npwp,c.website,c.catatan as catatancustomer",
                    "retur_penjualan a INNER JOIN retur_penjualan_detail b ON a.id = b.id " +
                    "INNER JOIN customer c ON a.idcustomer = c.id",
                    "where a.idcustomer = '" + txtPencarian.Text.Trim() + "' and a.tgltransaksi >= '" + dtAwal.Value.ToString("yyyy-MM-dd") + "' " +
                    "and a.tgltransaksi <= '" + dtAkhir.Value.ToString("yyyy-MM-dd") + "' order by a.tgltransaksi asc",
                    "retur_penjualan_19");
                cr.ReturPenjualanCustomer rptDoc = new cr.ReturPenjualanCustomer();
                rptDoc.SetDataSource(qry.dataset.Tables[19]);
                rptDoc.DataDefinition.FormulaFields["periode"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + " s/d " +
                    "" + dtAkhir.Value.ToString("dd-MMM-yyyy") + "'";
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if (jenisLaporan == "LaporanGudangMasukBarang")
            {
                qry.CetakDokumen(this, "",
                    "a.id,a.idpembelian,a.tgltransaksi,a.catatan,b.numbpembelian,b.barcode,b.nama,b.qty as qtyterima,c.qty as qtypembelian,b.satuan,b.tglrusak as tglexp",
                    "gudang_masuk a INNER JOIN gudang_masuk_detail b ON a.id = b.id " +
                    "INNER JOIN pembelian_detail c ON b.numbpembelian = c.numb",
                    "where b.barcode = '" + txtPencarian.Text.Trim() + "' and a.tgltransaksi >= '" + dtAwal.Value.ToString("yyyy-MM-dd") + "' " +
                    "and a.tgltransaksi <= '" + dtAkhir.Value.ToString("yyyy-MM-dd") + "'",
                    "gudang_masuk_13");
                cr.GudangMasukBarang rptDoc = new cr.GudangMasukBarang();
                rptDoc.SetDataSource(qry.dataset.Tables[13]);
                rptDoc.DataDefinition.FormulaFields["periode"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + " s/d " +
                    "" + dtAkhir.Value.ToString("dd-MMM-yyyy") + "'";
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if (jenisLaporan == "LaporanGudangMasukKartuStok")
            {
                qry.CetakDokumenUnion(this, "", "a.tgltransaksi as tgltransaksi,b.barcode,b.nama as namabarang," +
                    "b.qty as qtymasuk,0 as qtykeluar,b.satuan,'IN' as stat,'MASUK GUDANG' as keterangan " +
                    "FROM gudang_masuk a INNER JOIN gudang_masuk_detail b ON a.id = b.id " +
                    "WHERE b.barcode = '" + txtPencarian.Text.Trim() + "' " +
                    "AND a.tgltransaksi >= '" + dtAwal.Value.ToString("yyyy-MM-dd") + "' AND a.tgltransaksi <= '" + dtAkhir.Value.ToString("yyyy-MM-dd") + "' " +
                    "UNION ALL " +
                    "SELECT a.tgltransaksi as tgltransaksi,b.barcode,b.nama as namabarang," +
                    "0 as qtymasuk,b.qty as qtykeluar,b.satuan,'OUT' as stat,'PINDAH GUDANG' as keterangan " +
                    "FROM pindah_gudang a INNER JOIN pindah_gudang_detail b ON a.id = b.id " +
                    "WHERE b.barcode = '" + txtPencarian.Text.Trim() + "' " +
                    "AND a.tgltransaksi >= '" + dtAwal.Value.ToString("yyyy-MM-dd") + "' AND a.tgltransaksi <= '" + dtAkhir.Value.ToString("yyyy-MM-dd") + "' " +
                    "ORDER BY tgltransaksi", "gudang_kartu_stok_16");
                cr.GudangKartuStok rptDoc = new cr.GudangKartuStok();
                rptDoc.SetDataSource(qry.dataset.Tables[16]);
                rptDoc.DataDefinition.FormulaFields["tglawal"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + "'";
                rptDoc.DataDefinition.FormulaFields["periode"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + " s/d " +
                    "" + dtAkhir.Value.ToString("dd-MMM-yyyy") + "'";
                rptDoc.DataDefinition.FormulaFields["stokawalmasuk"].Text = "'" + stokAwalMasuk + "'";
                rptDoc.DataDefinition.FormulaFields["stokawalkeluar"].Text = "'" + stokAwalKeluar + "'";
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if (jenisLaporan == "LaporanGudangMasukStok")
            {
                qry.CetakDokumenProsedure(this, "call stokGudang('" + txtPencarian.Text.Trim() + "'," +
                    "'" + dtAwal.Value.ToString("yyyy-MM-dd") + "','" + dtAkhir.Value.ToString("yyyy-MM-dd") + "')","gudang_stok_11");
                cr.GudangStok rptDoc = new cr.GudangStok();
                rptDoc.SetDataSource(qry.dataset.Tables[11]);
                rptDoc.DataDefinition.FormulaFields["periode"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + " s/d " +
                    "" + dtAkhir.Value.ToString("dd-MMM-yyyy") + "'";
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if (jenisLaporan == "LaporanPindahGudangBarang")
            {
                qry.CetakDokumen(this, "",
                    "a.id,a.tgltransaksi,a.catatan,a.lokasi,b.barcode,b.nama,b.qty,b.satuan",
                    "pindah_gudang a INNER JOIN pindah_gudang_detail b ON a.id = b.id",
                    "where b.barcode = '" + txtPencarian.Text.Trim() + "' and a.tgltransaksi >= '" + dtAwal.Value.ToString("yyyy-MM-dd") + "' " +
                    "and a.tgltransaksi <= '" + dtAkhir.Value.ToString("yyyy-MM-dd") + "'",
                    "pindah_gudang_14");
                cr.PindahGudangBarang rptDoc = new cr.PindahGudangBarang();
                rptDoc.SetDataSource(qry.dataset.Tables[14]);
                rptDoc.DataDefinition.FormulaFields["periode"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + " s/d " +
                    "" + dtAkhir.Value.ToString("dd-MMM-yyyy") + "'";
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if (jenisLaporan == "LaporanPindahGudangKartuStok")
            {
                qry.CetakDokumenUnion(this, "", "a.tgltransaksi as tgltransaksi,b.barcode,b.nama as namabarang," +
                    "b.qty as qtymasuk,0 as qtykeluar,b.satuan,'IN' as stat,'MASUK GUDANG DISPLAY' as keterangan " +
                    "FROM pindah_gudang a INNER JOIN pindah_gudang_detail b ON a.id = b.id " +
                    "WHERE b.barcode = '" + txtPencarian.Text.Trim() + "' " +
                    "AND a.tgltransaksi >= '" + dtAwal.Value.ToString("yyyy-MM-dd") + "' AND a.tgltransaksi <= '" + dtAkhir.Value.ToString("yyyy-MM-dd") + "' " +
                    "UNION ALL " +
                    "SELECT a.tgltransaksi as tgltransaksi,b.barcode,c.nama as namabarang," +
                    "0 as qtymasuk,b.qty as qtykeluar,b.satuan,'OUT' as stat,'TERJUAL' as keterangan " +
                    "FROM penjualan a INNER JOIN penjualan_detail b ON a.id = b.id " +
                    "INNER JOIN barang c ON b.barcode = c.barcode " +
                    "WHERE b.barcode = '" + txtPencarian.Text.Trim() + "' " +
                    "AND a.tgltransaksi >= '" + dtAwal.Value.ToString("yyyy-MM-dd") + "' AND a.tgltransaksi <= '" + dtAkhir.Value.ToString("yyyy-MM-dd") + "' " +
                    "ORDER BY tgltransaksi", "display_kartu_stok_17");
                cr.DisplayKartuStok rptDoc = new cr.DisplayKartuStok();
                rptDoc.SetDataSource(qry.dataset.Tables[17]);
                rptDoc.DataDefinition.FormulaFields["tglawal"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + "'";
                rptDoc.DataDefinition.FormulaFields["periode"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + " s/d " +
                    "" + dtAkhir.Value.ToString("dd-MMM-yyyy") + "'";
                rptDoc.DataDefinition.FormulaFields["stokawalmasuk"].Text = "'" + stokAwalMasuk + "'";
                rptDoc.DataDefinition.FormulaFields["stokawalkeluar"].Text = "'" + stokAwalKeluar + "'";
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if (jenisLaporan == "LaporanPindahGudangStok")
            {
                qry.CetakDokumenProsedure(this, "call stokDisplay('" + txtPencarian.Text.Trim() + "'," +
                    "'" + dtAwal.Value.ToString("yyyy-MM-dd") + "','" + dtAkhir.Value.ToString("yyyy-MM-dd") + "')", "display_stok_12");
                cr.DisplayStok rptDoc = new cr.DisplayStok();
                rptDoc.SetDataSource(qry.dataset.Tables[12]);
                rptDoc.DataDefinition.FormulaFields["periode"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + " s/d " +
                    "" + dtAkhir.Value.ToString("dd-MMM-yyyy") + "'";
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if (jenisLaporan == "LaporanMutasiStok")
            {
                qry.CetakDokumenProsedure(this, "call stokMutasi('" + txtPencarian.Text.Trim() + "'," +
                    "'" + dtAwal.Value.ToString("yyyy-MM-dd") + "','" + dtAkhir.Value.ToString("yyyy-MM-dd") + "')", "mutasi_stok_23");
                cr.MutasiStok rptDoc = new cr.MutasiStok();
                rptDoc.SetDataSource(qry.dataset.Tables[23]);
                rptDoc.DataDefinition.FormulaFields["periode"].Text = "'" + dtAwal.Value.ToString("dd-MMM-yyyy") + " s/d " +
                    "" + dtAkhir.Value.ToString("dd-MMM-yyyy") + "'";
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
        }
        #endregion

        private void LaporanParam_Load(object sender, EventArgs e)
        {
            if(jenisLaporan == "LaporanPembelianSupplier")
            {
                frmUtama.lblNamaForm.Text = "- Laporan Pembelian Supplier";
            }
            else if (jenisLaporan == "LaporanReturPembelianSupplier")
            {
                frmUtama.lblNamaForm.Text = "- Laporan Retur Pembelian Supplier";
            }
            else if (jenisLaporan == "LaporanPembelianBarang")
            {
                frmUtama.lblNamaForm.Text = "- Laporan Pembelian Barang";
            }
            else if (jenisLaporan == "LaporanReturPembelianBarang")
            {
                frmUtama.lblNamaForm.Text = "- Laporan Retur Pembelian Barang";
            }
            else if (jenisLaporan == "LaporanPenjualanKategori")
            {
                frmUtama.lblNamaForm.Text = "- Laporan Penjualan Kategori";
            }
            else if (jenisLaporan == "LaporanPenjualanBarang")
            {
                frmUtama.lblNamaForm.Text = "- Laporan Penjualan Barang";
            }
            else if (jenisLaporan == "LaporanReturPenjualanBarang")
            {
                frmUtama.lblNamaForm.Text = "- Laporan Retur Penjualan Barang";
            }
            else if (jenisLaporan == "LaporanPenjualanCustomer")
            {
                frmUtama.lblNamaForm.Text = "- Laporan Penjualan Customer";
            }
            else if (jenisLaporan == "LaporanReturPenjualanCustomer")
            {
                frmUtama.lblNamaForm.Text = "- Laporan Retur Penjualan Customer";
            }
            else if (jenisLaporan == "LaporanRLPenjualanKategori")
            {
                frmUtama.lblNamaForm.Text = "- Laporan R/L Penjualan Kategori";
            }
            else if (jenisLaporan == "LaporanRLPenjualanBarang")
            {
                frmUtama.lblNamaForm.Text = "- Laporan R/L Penjualan Barang";
            }
            else if (jenisLaporan == "LaporanGudangMasukBarang")
            {
                frmUtama.lblNamaForm.Text = "- Laporan Gudang Masuk Barang";
            }
            else if (jenisLaporan == "LaporanGudangMasukKartuStok")
            {
                frmUtama.lblNamaForm.Text = "- Laporan Gudang Masuk Kartu Stok";
            }
            else if (jenisLaporan == "LaporanGudangMasukStok")
            {
                frmUtama.lblNamaForm.Text = "- Laporan Gudang Masuk Stok";
            }
            else if (jenisLaporan == "LaporanPindahGudangBarang")
            {
                frmUtama.lblNamaForm.Text = "- Laporan Pindah Gudang Barang";
            }
            else if (jenisLaporan == "LaporanPindahGudangKartuStok")
            {
                frmUtama.lblNamaForm.Text = "- Laporan Pindah Gudang Kartu Stok";
            }
            else if (jenisLaporan == "LaporanPindahGudangStok")
            {
                frmUtama.lblNamaForm.Text = "- Laporan Pindah Gudang Stok";
            }
            else if (jenisLaporan == "LaporanMutasiStok")
            {
                frmUtama.lblNamaForm.Text = "- Laporan Mutasi Stok";
            }
        }

        private void LaporanParam_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.BlockChar(e);
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            SelectToolBar(btnKeluar);
        }

        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            if (jenisLaporan == "LaporanGudangMasukKartuStok" || jenisLaporan == "LaporanPindahGudangKartuStok")
            {
                StokAwalMasuk(txtPencarian.Text.Trim());
                StokAwalKeluar(txtPencarian.Text.Trim());
            }

            if (txtPencarian.Text == "")
            {
                psn.PesanInfo(label7.Text + " Masih Kosong");
                txtPencarian.Focus();
            }
            else if (dtAwal.Value > dtAkhir.Value)
            {
                psn.PesanInfo("Tanggal Awal Tidak Boleh Lebih Besar Dari Tanggal Akhir");
                dtAwal.Focus();
            }
            else
            {
                ViewReport();
            }
        }

        private void btnPencarian_Click(object sender, EventArgs e)
        {
            if (jenisLaporan == "LaporanPembelianSupplier")
            {
                cls.OpenForm op = new cls.OpenForm(frmUtama);
                op.ListOpen("List", "LaporanPembelianSupplier", "Supplier", "", userName);

                txtPencarian.Text = id;
                id = "";
            }
            else if (jenisLaporan == "LaporanReturPembelianSupplier")
            {
                cls.OpenForm op = new cls.OpenForm(frmUtama);
                op.ListOpen("List", "LaporanReturPembelianSupplier", "Supplier", "", userName);

                txtPencarian.Text = id;
                id = "";
            }
            else if (jenisLaporan == "LaporanPembelianBarang")
            {
                cls.OpenForm op = new cls.OpenForm(frmUtama);
                op.ListOpen("List", "LaporanPembelianBarang", "Barang", "", userName);

                txtPencarian.Text = id;
                id = "";
            }
            else if (jenisLaporan == "LaporanReturPembelianBarang")
            {
                cls.OpenForm op = new cls.OpenForm(frmUtama);
                op.ListOpen("List", "LaporanReturPembelianBarang", "Barang", "", userName);

                txtPencarian.Text = id;
                id = "";
            }
            else if (jenisLaporan == "LaporanPenjualanKategori")
            {
                cls.OpenForm op = new cls.OpenForm(frmUtama);
                op.ListOpen("List", "LaporanPenjualanKategori", "Kategori", "", userName);

                txtPencarian.Text = id;
                id = "";
            }
            else if (jenisLaporan == "LaporanRLPenjualanKategori")
            {
                cls.OpenForm op = new cls.OpenForm(frmUtama);
                op.ListOpen("List", "LaporanRLPenjualanKategori", "Kategori", "", userName);

                txtPencarian.Text = id;
                id = "";
            }
            else if (jenisLaporan == "LaporanPenjualanBarang")
            {
                cls.OpenForm op = new cls.OpenForm(frmUtama);
                op.ListOpen("List", "LaporanPenjualanBarang", "Barang", "", userName);

                txtPencarian.Text = id;
                id = "";
            }
            else if (jenisLaporan == "LaporanReturPenjualanBarang")
            {
                cls.OpenForm op = new cls.OpenForm(frmUtama);
                op.ListOpen("List", "LaporanReturPenjualanBarang", "Barang", "", userName);

                txtPencarian.Text = id;
                id = "";
            }
            else if (jenisLaporan == "LaporanRLPenjualanBarang")
            {
                cls.OpenForm op = new cls.OpenForm(frmUtama);
                op.ListOpen("List", "LaporanRLPenjualanBarang", "Barang", "", userName);

                txtPencarian.Text = id;
                id = "";
            }
            else if (jenisLaporan == "LaporanPenjualanCustomer")
            {
                cls.OpenForm op = new cls.OpenForm(frmUtama);
                op.ListOpen("List", "LaporanPenjualanCustomer", "Customer", "", userName);

                txtPencarian.Text = id;
                id = "";
            }
            else if (jenisLaporan == "LaporanReturPenjualanCustomer")
            {
                cls.OpenForm op = new cls.OpenForm(frmUtama);
                op.ListOpen("List", "LaporanReturPenjualanCustomer", "Customer", "", userName);

                txtPencarian.Text = id;
                id = "";
            }
            else if (jenisLaporan == "LaporanGudangMasukBarang")
            {
                cls.OpenForm op = new cls.OpenForm(frmUtama);
                op.ListOpen("List", "LaporanGudangMasukBarang", "Barang", "", userName);

                txtPencarian.Text = id;
                id = "";
            }
            else if (jenisLaporan == "LaporanGudangMasukKartuStok")
            {
                cls.OpenForm op = new cls.OpenForm(frmUtama);
                op.ListOpen("List", "LaporanGudangMasukKartuStok", "Barang", "", userName);

                txtPencarian.Text = id;
                id = "";
            }
            else if (jenisLaporan == "LaporanGudangMasukStok")
            {
                cls.OpenForm op = new cls.OpenForm(frmUtama);
                op.ListOpen("List", "LaporanGudangMasukStok", "Kategori", "", userName);

                txtPencarian.Text = id;
                id = "";
            }
            else if (jenisLaporan == "LaporanPindahGudangBarang")
            {
                cls.OpenForm op = new cls.OpenForm(frmUtama);
                op.ListOpen("List", "LaporanPindahGudangBarang", "Barang", "", userName);

                txtPencarian.Text = id;
                id = "";
            }
            else if (jenisLaporan == "LaporanPindahGudangKartuStok")
            {
                cls.OpenForm op = new cls.OpenForm(frmUtama);
                op.ListOpen("List", "LaporanPindahGudangKartuStok", "Barang", "", userName);

                txtPencarian.Text = id;
                id = "";
            }
            else if (jenisLaporan == "LaporanPindahGudangStok")
            {
                cls.OpenForm op = new cls.OpenForm(frmUtama);
                op.ListOpen("List", "LaporanPindahGudangStok", "Kategori", "", userName);

                txtPencarian.Text = id;
                id = "";
            }
            else if (jenisLaporan == "LaporanMutasiStok")
            {
                cls.OpenForm op = new cls.OpenForm(frmUtama);
                op.ListOpen("List", "LaporanMutasiStok", "Kategori", "", userName);

                txtPencarian.Text = id;
                id = "";
            }
        }

        private void txtPencarian_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.AllowOnlyBackspace(e);
        }

        private void txtPencarian_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                btnPencarian_Click(sender, e);
            }
        }

        private void txtPencarian_TextChanged(object sender, EventArgs e)
        {
            TampilData(txtPencarian.Text.Trim());
        }
    }
}
