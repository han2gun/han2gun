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
    public partial class PreviewCetakData : Form
    {
        cls.Fungsi fs = new cls.Fungsi();
        cls.Pesan psn = new cls.Pesan();
        cls.Query qry = new cls.Query();

        MenuUtama frmUtama;
        public string userName;
        public string id;
        public string namaForm;
        public string namaSubForm;

        string parameter;

        public PreviewCetakData(MenuUtama mnutama)
        {
            InitializeComponent();

            frmUtama = mnutama;
            this.KeyDown += new KeyEventHandler(this.OnKeyDown);
        }

        #region code
        private void UsrAccess()
        {
            string data = qry.GetData(this, "UsrAccess", userName, 0,
                "barangstokrp", "usrmgmt", "usrname = '" + userName + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    if (filldata[0] == "0")
                        parameter = "HPP Hide";

                    qry.InsertLogAktivitas("UsrAccess", this, userName, userName);
                }
            }
        }

        private void SelectToolBar(Button btn)
        {
            switch (btn.AccessibleName)
            {
                case "KELUAR":
                    id = "";

                    cls.OpenForm op = new cls.OpenForm(frmUtama);

                    if (namaForm == "Penjualan")
                    {
                        op.PenjualanOpen(this, "Penjualan", id, userName);
                    }
                    else if (namaForm == "ReturPenjualan")
                    {
                        op.ReturPenjualanOpen(this, "ReturPenjualan", id, userName);
                    }
                    else if (namaForm == "Pembelian")
                    {
                        op.PembelianOpen(this, "Pembelian", id, userName);
                    }
                    else if (namaForm == "ReturPembelian")
                    {
                        op.ReturPembelianOpen(this, "ReturPembelian", id, userName);
                    }
                    else if (namaForm == "Gudang")
                    {
                        op.GudangOpen(this, "Gudang", id, userName);
                    }
                    else if (namaForm == "GudangPindah")
                    {
                        op.PindahGudangOpen(this, "GudangPindah", id, userName);
                    }
                    else if (namaForm == "Diskon")
                    {
                        op.DiskonOpen(this, "Diskon", id, userName);
                    }
                    else if (namaForm == "Kas")
                    {
                        op.KasOpen(this, "Kas", id, userName);
                    }
                    else if (namaForm == "Penyesuaian")
                    {
                        op.PenyesuaianOpen(this, "Penyesuaian", id, userName);
                    }
                    else if(namaForm == "Pencarian")
                    {
                        if (namaSubForm == "Karyawan")
                        {
                            op.PencarianOpen("Pencarian", "Karyawan", userName);
                        }
                        else if (namaSubForm == "Customer")
                        {
                            op.PencarianOpen("Pencarian", "Customer", userName);
                        }
                        else if (namaSubForm == "Supplier")
                        {
                            op.PencarianOpen("Pencarian", "Supplier", userName);
                        }
                        else if (namaSubForm == "KategoriBarang")
                        {
                            op.PencarianOpen("Pencarian", "KategoriBarang", userName);
                        }
                        else if (namaSubForm == "Barang")
                        {
                            op.PencarianOpen("Pencarian", "Barang", userName);
                        }
                    }
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

        private void ViewReport()
        {
            if (namaForm == "Penjualan")
            {
                qry.CetakDokumen(this, id, "a.id,a.idcustomer,a.sales,a.tgltransaksi,a.catatan," +
                    "a.jenisbayar,a.bank,a.nokartu,a.total,a.discpersen,a.discrp,a.ppn,a.ppnnominal," +
                    "a.ongkir,a.grandtotal,a.bayar,a.kembalian,b.barcode,b.kondisi as idbarangdetail,b.qty,b.satuan," +
                    "b.hjual,b.discpersen as discpersen_dtl,b.discrp as discrp_dtl,b.subtotal,b.nama as namabarang,b.keterangan," +
                    "c.nama as namacustomer,c.alamat as alamatcustomer,c.telp as telpcustomer,c.nohp as nohpcustomer," +
                    "e.nama as namausaha,e.alamat,e.telp,e.nohp,e.fax,e.email,e.npwp,e.website",
                    "penjualan a inner join penjualan_detail b on a.id = b.id " +
                    "inner join customer c on a.idcustomer = c.id " +
                    "inner join barang d on b.barcode = d.barcode, datausaha e",
                    "where a.id = '" + id + "'", "nota_penjualan_0");
                cr.Penjualan rptDoc = new cr.Penjualan();
                rptDoc.SetDataSource(qry.dataset.Tables[0]);
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
                //rptDoc.PrintToPrinter(1, false, 0, 0);
            }
            else if (namaForm == "ReturPenjualan")
            {
                qry.CetakDokumen(this, "",
                    "a.id,a.idcustomer,a.idpenjualan,a.tgltransaksi,a.catatan,a.grandtotal," +
                    "b.barcode,b.nama,b.keterangan,b.qty,b.satuan,b.hjual," +
                    "b.discpersen,b.discrp,b.subtotal,b.subtotalhpp,b.kondisi,c.nama as namacustomer," +
                    "c.alamat,c.telp,c.nohp,c.fax,c.email,c.npwp,c.website,c.catatan as catatancustomer",
                    "retur_penjualan a INNER JOIN retur_penjualan_detail b ON a.id = b.id " +
                    "INNER JOIN customer c ON a.idcustomer = c.id",
                    "where a.id = '" + id + "'",
                    "retur_penjualan_19");
                cr.ReturPenjualan rptDoc = new cr.ReturPenjualan();
                rptDoc.SetDataSource(qry.dataset.Tables[19]);
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if (namaForm == "Pembelian")
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
                    "where a.id = '" + id + "'",
                    "lap_pembelian_periode_1");
                cr.Pembelian rptDoc = new cr.Pembelian();
                rptDoc.SetDataSource(qry.dataset.Tables[1]);
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if (namaForm == "ReturPembelian")
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
                    "where a.id = '" + id + "'",
                    "retur_pembelian_20");
                cr.ReturPembelian rptDoc = new cr.ReturPembelian();
                rptDoc.SetDataSource(qry.dataset.Tables[20]);
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if (namaForm == "Gudang")
            {
                qry.CetakDokumen(this, "",
                    "a.id,a.idpembelian,a.tgltransaksi,a.catatan,b.numbpembelian,b.barcode,b.nama,b.qty as qtyterima,c.qty as qtypembelian,b.satuan,b.tglrusak as tglexp",
                    "gudang_masuk a INNER JOIN gudang_masuk_detail b ON a.id = b.id " +
                    "INNER JOIN pembelian_detail c ON b.numbpembelian = c.numb",
                    "where a.id = '" + id + "'",
                    "gudang_masuk_13");
                cr.GudangMasuk rptDoc = new cr.GudangMasuk();
                rptDoc.SetDataSource(qry.dataset.Tables[13]);
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if (namaForm == "GudangPindah")
            {
                qry.CetakDokumen(this, "",
                    "a.id,a.tgltransaksi,a.catatan,a.lokasi,b.barcode,b.nama,b.qty,b.satuan",
                    "pindah_gudang a INNER JOIN pindah_gudang_detail b ON a.id = b.id",
                    "where a.id = '" + id + "'",
                    "pindah_gudang_14");
                cr.PindahGudang rptDoc = new cr.PindahGudang();
                rptDoc.SetDataSource(qry.dataset.Tables[14]);
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if (namaForm == "Diskon")
            {
                qry.CetakDokumen(this, "",
                    "a.id,a.aktif,a.nama as namadiskon,a.tglmulai,a.tglselesai,a.catatan," +
                    "b.barcode,b.discpersen,b.discrp,c.nama as namabarang,d.nama as namakategori",
                    "diskon a INNER JOIN diskon_detail b ON a.id = b.id " +
                    "INNER JOIN barang c ON b.barcode = c.barcode " +
                    "INNER JOIN kategori d ON c.idkategori = d.id",
                    "where a.id = '" + id + "'",
                    "diskon_9");
                cr.Diskon rptDoc = new cr.Diskon();
                rptDoc.SetDataSource(qry.dataset.Tables[9]);
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if (namaForm == "Kas")
            {
                qry.CetakDokumen(this, "",
                    "a.id,a.jeniskas,a.tgltransaksi,a.catatan,a.grandtotal,b.keterangan,b.nominal",
                    "kas a INNER JOIN kas_detail b ON a.id = b.id",
                    "where a.id = '" + id + "'",
                    "kas_10");
                cr.Kas rptDoc = new cr.Kas();
                rptDoc.SetDataSource(qry.dataset.Tables[10]);
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if (namaForm == "Penyesuaian")
            {
                qry.CetakDokumen(this, "",
                    "a.id,a.tgltransaksi,a.catatan,b.barcode,b.nama,b.stok,b.nilaistok,b.qtypenyesuaian," +
                    "b.qtyselisih,b.satuan,b.nilaiqty,b.subtotal",
                    "penyesuaian a INNER JOIN penyesuaian_detail b ON a.id = b.id",
                    "where a.id = '" + id + "'",
                    "penyesuaian_21");
                cr.Penyesuaian rptDoc = new cr.Penyesuaian();
                rptDoc.SetDataSource(qry.dataset.Tables[21]);
                crViewer.ReportSource = rptDoc;
                crViewer.Refresh();
                qry.dataset.Clear();
            }
            else if (namaForm == "Pencarian")
            {
                if(namaSubForm == "Karyawan")
                {
                    qry.CetakDokumen(this, id, "id,nama,alamat,telp,nohp,email,catatan",
                        "karyawan","", "karyawan_4");
                    cr.Karyawan rptDoc = new cr.Karyawan();
                    rptDoc.SetDataSource(qry.dataset.Tables[4]);
                    crViewer.ReportSource = rptDoc;
                    crViewer.Refresh();
                    qry.dataset.Clear();
                }
                else if(namaSubForm == "Customer")
                {
                    qry.CetakDokumen(this, id, "id,cekawal,nama,alamat,telp,nohp,fax,email,npwp,website,catatan",
                        "customer", "", "pelanggan_5");
                    cr.Pelanggan rptDoc = new cr.Pelanggan();
                    rptDoc.SetDataSource(qry.dataset.Tables[5]);
                    crViewer.ReportSource = rptDoc;
                    crViewer.Refresh();
                    qry.dataset.Clear();
                }
                else if(namaSubForm == "Supplier")
                {
                    qry.CetakDokumen(this, id, "id,nama,alamat,telp,nohp,fax,email,npwp,website,catatan",
                        "supplier", "", "pemasok_6");
                    cr.Pemasok rptDoc = new cr.Pemasok();
                    rptDoc.SetDataSource(qry.dataset.Tables[6]);
                    crViewer.ReportSource = rptDoc;
                    crViewer.Refresh();
                    qry.dataset.Clear();
                }
                else if(namaSubForm == "KategoriBarang")
                {
                    qry.CetakDokumen(this, id, "id,nama,catatan",
                        "supplier", "", "kategori_barang_8");
                    cr.Kategori rptDoc = new cr.Kategori();
                    rptDoc.SetDataSource(qry.dataset.Tables[8]);
                    crViewer.ReportSource = rptDoc;
                    crViewer.Refresh();
                    qry.dataset.Clear();
                }
                else if(namaSubForm == "Barang")
                {
                    qry.CetakDokumen(this, id, "a.barcode,a.nama,a.idkategori,a.catatan,a.satuan1,a.stokmin," +
                        "a.satuanstok,a.hargabeli,a.hargajual1,a.stokgudang,a.stokrupiah,b.nama as namakategori,b.catatan as catatankategori",
                        "barang a inner join kategori b on a.idkategori = b.id", "", "barang_7");
                    cr.Barang rptDoc = new cr.Barang();
                    rptDoc.SetDataSource(qry.dataset.Tables[7]);
                    rptDoc.DataDefinition.FormulaFields["HPPHide"].Text = "'" + parameter + "'";
                    crViewer.ReportSource = rptDoc;
                    crViewer.Refresh();
                    qry.dataset.Clear();
                }
            }
            crViewer.Refresh();
        }
        #endregion

        private void PreviewCetakData_Load(object sender, EventArgs e)
        {
            frmUtama.lblNamaForm.Text = "- Laporan";
            UsrAccess();

            ViewReport();
        }

        private void PreviewCetakData_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.BlockChar(e);
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            SelectToolBar(btnKeluar);
        }
    }
}
