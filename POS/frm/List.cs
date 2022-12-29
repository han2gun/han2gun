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
    public partial class List : Form
    {
        cls.Query qry = new cls.Query();
        cls.Fungsi fs = new cls.Fungsi();

        public string formpencarian;
        public string namapencarian;
        public string kondisi;
        string[] headercolom;
        string[] penyaringan;
        string[] pilihancbo;
        int banyakkolom;
        int indexcombo;
        string query;
        string halpencarian;
        DataGridViewRow row;
        public string userName;

        public List()
        {
            InitializeComponent();

            this.KeyDown += new KeyEventHandler(this.OnKeyDown);
            fs.BoldHeaderDataGridView(dgPencarian);
            ActiveControl = txtPencarian;
        }

        #region code
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                default:
                    break;
            }
        }

        private void LoadDetailData()
        {
            if (namapencarian == "Supplier")
            {
                headercolom = new string[] { "ID", "Nama", "Alamat", "Telp.", "No. HP", "Fax", "Email", "NPWP", "Website", "Catatan" };
                banyakkolom = 10;
                penyaringan = new string[] { "nama", "alamat", "telp", "nohp", "fax", "email", "npwp", "website", "catatan", "id" };
                pilihancbo = new string[] { penyaringan[0].ToUpper(), penyaringan[1].ToUpper(), penyaringan[2].ToUpper(), penyaringan[3].ToUpper(),
                    penyaringan[4].ToUpper(), penyaringan[5].ToUpper(), penyaringan[6].ToUpper(), penyaringan[7].ToUpper(), penyaringan[8].ToUpper(),
                    penyaringan[9].ToUpper() };
                for (int i = 0; i < pilihancbo.Length; i++)
                {
                    cboPencarian.Items.Add(pilihancbo[i]);
                }
                cboPencarian.SelectedIndex = 0;
            }
            else if (namapencarian == "Barang")
            {
                headercolom = new string[] { "Barcode", "Nama", "Kategori", "H. Jual", "Satuan" };
                banyakkolom = 5;
                penyaringan = new string[] { "a.nama", "a.barcode", "b.nama", "a.satuan1" };
                pilihancbo = new string[] { "NAMA", "BARCODE", "KATEGORI", "SATUAN" };
                for (int i = 0; i < pilihancbo.Length; i++)
                {
                    cboPencarian.Items.Add(pilihancbo[i]);
                }
                cboPencarian.SelectedIndex = 0;
            }
            else if (namapencarian == "BarangGudang")
            {
                headercolom = new string[] { "Barcode", "Nama" };
                banyakkolom = 2;
                penyaringan = new string[] { "nama", "barcode" };
                pilihancbo = new string[] { penyaringan[0].ToUpper(), penyaringan[1].ToUpper() };
                for (int i = 0; i < pilihancbo.Length; i++)
                {
                    cboPencarian.Items.Add(pilihancbo[i]);
                }
                cboPencarian.SelectedIndex = 0;
            }
            else if (namapencarian == "BarangByIDPenjualan")
            {
                headercolom = new string[] { "Barcode", "Nama", "Kategori", "H. Jual", "Qty", "Satuan", "Disc %", "Disc Rp.", "Sub Total", "Stat" };
                banyakkolom = 10;
                penyaringan = new string[] { "a.nama", "a.barcode", "c.nama", "a.satuan" };
                pilihancbo = new string[] { "NAMA", "BARCODE", "KATEGORI", "SATUAN" };
                for (int i = 0; i < pilihancbo.Length; i++)
                {
                    cboPencarian.Items.Add(pilihancbo[i]);
                }
                cboPencarian.SelectedIndex = 0;
            }
            else if (namapencarian == "BarangByIDPembelian")
            {
                headercolom = new string[] { "Barcode", "Nama", "Keterangan", "Kategori", "H. Beli", "Qty", "Satuan", "Disc 1 %", "Disc 2 %",
                    "Disc 3 %", "Disc Rp.", "Sub Total", "Stat" };
                banyakkolom = 13;
                penyaringan = new string[] { "a.nama", "a.barcode", "a.keterangan", "c.nama", "a.satuan" };
                pilihancbo = new string[] { "NAMA", "BARCODE", "KETERANGAN", "KATEGORI", "SATUAN" };
                for (int i = 0; i < pilihancbo.Length; i++)
                {
                    cboPencarian.Items.Add(pilihancbo[i]);
                }
                cboPencarian.SelectedIndex = 0;
            }
            else if (namapencarian == "Pembelian")
            {
                headercolom = new string[] { "ID", "Status", "Supplier", "No. Nota", "Tgl. Transaksi", "Catatan" };
                banyakkolom = 6;
                penyaringan = new string[] { "b.nama", "a.nonota", "if(flaggudang=0,'BLM LUNAS','LUNAS')", "a.catatan", "a.id" };
                pilihancbo = new string[] { "SUPPLIER", "NO. NOTA", "STATUS", "CATATAN", "ID" };
                for (int i = 0; i < pilihancbo.Length; i++)
                {
                    cboPencarian.Items.Add(pilihancbo[i]);
                }
                cboPencarian.SelectedIndex = 0;
            }
            else if (namapencarian == "PembelianBySupplier")
            {
                headercolom = new string[] { "ID", "No. Nota", "Tgl. Transaksi", "Catatan" };
                banyakkolom = 4;
                penyaringan = new string[] { "a.id", "a.nonota", "a.catatan" };
                pilihancbo = new string[] { "ID", "NO. NOTA", "CATATAN" };
                for (int i = 0; i < pilihancbo.Length; i++)
                {
                    cboPencarian.Items.Add(pilihancbo[i]);
                }
                cboPencarian.SelectedIndex = 0;
            }
            else if (namapencarian == "Penjualan")
            {
                headercolom = new string[] { "ID", "Status", "Customer", "Tgl. Transaksi", "Catatan" };
                banyakkolom = 5;
                penyaringan = new string[] { "b.nama", "if(a.flaglunas = 0,'BLM LUNAS','LUNAS')", "a.catatan", "a.id" };
                pilihancbo = new string[] { "CUSTOMER", "STATUS", "CATATAN", "ID" };
                for (int i = 0; i < pilihancbo.Length; i++)
                {
                    cboPencarian.Items.Add(pilihancbo[i]);
                }
                cboPencarian.SelectedIndex = 0;
            }
            else if (namapencarian == "PenjualanByCustomer")
            {
                headercolom = new string[] { "ID", "Jenis Bayar", "Tgl. Transaksi", "Catatan" };
                banyakkolom = 4;
                penyaringan = new string[] { "a.id", "a.jenisbayar", "a.catatan" };
                pilihancbo = new string[] { "ID", "JENIS BAYAR", "CATATAN" };
                for (int i = 0; i < pilihancbo.Length; i++)
                {
                    cboPencarian.Items.Add(pilihancbo[i]);
                }
                cboPencarian.SelectedIndex = 0;
            }
            else if (namapencarian == "Customer")
            {
                headercolom = new string[] { "ID", "Nama", "Alamat", "Telp.", "No. HP", "Fax", "Email", "NPWP", "Website", "Catatan" };
                banyakkolom = 10;
                penyaringan = new string[] { "nama", "alamat", "telp", "nohp", "fax", "email", "npwp", "website", "catatan", "id" };
                pilihancbo = new string[] { penyaringan[0].ToUpper(), penyaringan[1].ToUpper(), penyaringan[2].ToUpper(), penyaringan[3].ToUpper(),
                    penyaringan[4].ToUpper(), penyaringan[5].ToUpper(), penyaringan[6].ToUpper(), penyaringan[7].ToUpper(), penyaringan[8].ToUpper(),
                    penyaringan[9].ToUpper() };
                for (int i = 0; i < pilihancbo.Length; i++)
                {
                    cboPencarian.Items.Add(pilihancbo[i]);
                }
                cboPencarian.SelectedIndex = 0;
            }
            else if (namapencarian == "BarangJual")
            {
                headercolom = new string[] { "Barcode", "Nama" };
                banyakkolom = 2;
                penyaringan = new string[] { "nama", "barcode" };
                pilihancbo = new string[] { penyaringan[0].ToUpper(), penyaringan[1].ToUpper() };
                for (int i = 0; i < pilihancbo.Length; i++)
                {
                    cboPencarian.Items.Add(pilihancbo[i]);
                }
                cboPencarian.SelectedIndex = 0;
            }
            else if (namapencarian == "Kategori")
            {
                headercolom = new string[] { "ID", "Nama", "Catatan" };
                banyakkolom = 3;
                penyaringan = new string[] { "nama", "catatan", "id" };
                pilihancbo = new string[] { penyaringan[0].ToUpper(), penyaringan[1].ToUpper() };
                for (int i = 0; i < pilihancbo.Length; i++)
                {
                    cboPencarian.Items.Add(pilihancbo[i]);
                }
                cboPencarian.SelectedIndex = 0;
            }
            else if (namapencarian == "GudangMasuk")
            {
                headercolom = new string[] { "ID", "Supplier", "No. Pembelian", "No. Nota", "Tgl.Transaksi", "Catatan" };
                banyakkolom = 6;
                penyaringan = new string[] { "c.nama", "b.id", "b.nonota", "a.catatan", "a.id" };
                pilihancbo = new string[] { "SUPPLIER", "NO. PEMBELIAN", "NO. NOTA", "CATATAN", "ID" };
                for (int i = 0; i < pilihancbo.Length; i++)
                {
                    cboPencarian.Items.Add(pilihancbo[i]);
                }
                cboPencarian.SelectedIndex = 0;
            }
        }

        private void Pencarian()
        {
            if (namapencarian == "Supplier")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                query = "select id,nama,alamat,telp,nohp,fax,email,npwp,website,catatan from supplier where " +
                    penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' order by id limit 100";
                halpencarian = "Supplier";
            }
            else if (namapencarian == "Barang")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                query = "select a.barcode,a.nama,b.nama as namakategori,format(a.hargajual1,2) as hargajual,a.satuan1 " +
                    "from barang a inner join kategori b on a.idkategori = b.id where " +
                    penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' order by a.nama limit 200";
                halpencarian = "Barang";
            }
            else if (namapencarian == "BarangGudang")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                query = "select barcode,nama from gudang_masuk_detail where " +
                    penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' group by barcode order by a.nama limit 200";
                halpencarian = "BarangGudang";
            }
            else if (namapencarian == "BarangByIDPenjualan")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                query = "select a.barcode,a.nama,c.nama as namakategori,format(a.hjual,2) as hargajual,format(a.qty,2) as qty,a.satuan,format(a.discpersen,2) as discpersen," +
                    "format(a.discrp,2) as discrp,format(a.subtotal,2) as subtotal,a.kondisi " +
                    "from penjualan_detail a inner join barang b on a.barcode = b.barcode inner join kategori c on b.idkategori = c.id where " +
                    penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' " +
                    "and a.id = '" + kondisi + "' order by c.nama limit 200";
                halpencarian = "BarangByIDPenjualan";
            }
            else if (namapencarian == "BarangByIDPembelian")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                query = "select a.barcode,a.nama,a.keterangan,c.nama as namakategori,format(a.hbeli,2) as hargabeli,format(a.qty,2) as qty,a.satuan,format(a.discpersen,2) as discpersen," +
                    "format(a.discpersen2,2) as discpersen2,format(a.discpersen3,2) as discpersen3,format(a.discrp,2) as discrp,format(a.subtotal,2) as subtotal, a.kondisi " +
                    "from pembelian_detail a inner join barang b on a.barcode = b.barcode inner join kategori c on b.idkategori = c.id where " +
                    penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' " +
                    "and a.id = '" + kondisi + "' order by c.nama limit 200";
                halpencarian = "BarangByIDPembelian";
            }
            else if (namapencarian == "Pembelian")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                query = "select a.id, if(flaggudang=0,'BLM LUNAS','LUNAS') as flaggudang, b.nama, a.nonota, date_format(a.tgltransaksi, '%d-%b-%Y') as tgltr, a.catatan " +
                    "from pembelian a inner join supplier b on a.idsupplier = b.id where " +
                    penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' order by a.tgltransaksi desc limit 200";
                halpencarian = "Pembelian";
            }
            else if (namapencarian == "PembelianBySupplier")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                query = "select a.id, a.nonota, date_format(a.tgltransaksi, '%d-%b-%Y') as tgltr, a.catatan " +
                    "from pembelian a inner join supplier b on a.idsupplier = b.id where " +
                    penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' " +
                    "and b.id = '" + kondisi + "' order by a.tgltransaksi desc limit 200";
                halpencarian = "PembelianBySupplier";
            }
            else if (namapencarian == "Penjualan")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                query = "select a.id, if(a.flaglunas = 0,'BLM LUNAS','LUNAS'), b.nama, date_format(a.tgltransaksi, '%d-%b-%Y') as tgltr, a.catatan " +
                    "from penjualan a inner join customer b on a.idcustomer = b.id where " +
                    penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' order by a.tgltransaksi desc limit 200";
                halpencarian = "Penjualan";
            }
            else if (namapencarian == "PenjualanByCustomer")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                query = "select a.id, a.jenisbayar, date_format(a.tgltransaksi, '%d-%b-%Y') as tgltr, a.catatan " +
                    "from penjualan a inner join customer b on a.idcustomer = b.id where " +
                    penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' " +
                    "and b.id = '" + kondisi + "' order by a.tgltransaksi desc limit 200";
                halpencarian = "PenjualanByCustomer";
            }
            else if (namapencarian == "Customer")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                query = "select id,nama,alamat,telp,nohp,fax,email,npwp,website,catatan from customer where " +
                    penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' order by id limit 100";
                halpencarian = "Customer";
            }
            else if (namapencarian == "BarangJual")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                query = "select a.barcode,b.nama from barang_display a inner join barang b on a.barcode = b.barcode where " +
                    penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' group by a.barcode order by b.nama limit 200";
                halpencarian = "BarangJual";
            }
            else if (namapencarian == "Kategori")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                query = "select id,nama,catatan from kategori where " +
                    penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' order by nama limit 200";
                halpencarian = "Kategori";
            }
            else if (namapencarian == "GudangMasuk")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                query = "select a.id, c.nama, b.id, b.nonota, date_format(a.tgltransaksi, '%d-%b-%Y') as tgltr, a.catatan " +
                    "from gudang_masuk a inner join pembelian b on a.idpembelian = b.id inner join supplier c on b.idsupplier = c.id where " +
                    penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' order by a.tgltransaksi limit 200";
                halpencarian = "GudangMasuk";
            }

            qry.PencarianDataString(this, formpencarian, dgPencarian, headercolom, banyakkolom, query, halpencarian, cboPencarian.Text, txtPencarian.Text.Trim());
        }

        private void HasilPencarian()
        {
            if (formpencarian == "Pembelian-Supplier")
            {
                Pembelian.idsupplier = row.Cells[0].Value.ToString();
            }
            else if (formpencarian == "Pembelian-Barang")
            {
                Pembelian.barcode = row.Cells[0].Value.ToString();
            }
            else if (formpencarian == "ReturPembelian-Supplier")
            {
                ReturPembelian.idsupplier = row.Cells[0].Value.ToString();
            }
            else if (formpencarian == "ReturPembelian-IDPembelian")
            {
                ReturPembelian.idpembelian = row.Cells[0].Value.ToString();
            }
            else if (formpencarian == "ReturPembelian-Barang")
            {
                ReturPembelian.barcode = row.Cells[0].Value.ToString();
                ReturPembelian.strkondisi = row.Cells[12].Value.ToString();
            }
            else if (formpencarian == "Hutang-IDPembelian")
            {
                Hutang.idpembelian = row.Cells[0].Value.ToString();
            }
            else if (formpencarian == "Piutang-IDPenjualan")
            {
                Piutang.idpenjualan = row.Cells[0].Value.ToString();
            }
            else if (formpencarian == "GudangMasuk-Pembelian")
            {
                Gudang.idpembelian = row.Cells[0].Value.ToString();
            }
            else if (formpencarian == "PindahGudang-BarangGudang")
            {
                GudangPindah.barcode = row.Cells[0].Value.ToString();
            }
            else if (formpencarian == "Diskon-Barang")
            {
                Diskon.barcode = row.Cells[0].Value.ToString();
            }
            else if (formpencarian == "Penjualan-Customer")
            {
                Penjualan.idcustomer = row.Cells[0].Value.ToString();
            }
            else if (formpencarian == "ReturPenjualan-Customer")
            {
                ReturPenjualan.idcustomer = row.Cells[0].Value.ToString();
            }
            else if (formpencarian == "ReturPenjualan-IDPenjualan")
            {
                ReturPenjualan.idpenjualan = row.Cells[0].Value.ToString();
            }
            else if (formpencarian == "ReturPenjualan-Barang")
            {
                ReturPenjualan.barcode = row.Cells[0].Value.ToString();
                ReturPenjualan.strkondisi = row.Cells[9].Value.ToString();
            }
            else if (formpencarian == "Penjualan-BarangJual")
            {
                Penjualan.barcode = row.Cells[0].Value.ToString();
            }
            else if (formpencarian == "PindahGudang-GudangMasuk")
            {
                GudangPindah.idGudangMasuk = row.Cells[0].Value.ToString();
            }
            else if (formpencarian == "Penyesuaian-Barang")
            {
                Penyesuaian.barcode = row.Cells[0].Value.ToString();
            }
            else if (formpencarian == "LaporanPembelianSupplier" || formpencarian == "LaporanPembelianBarang" || formpencarian == "LaporanPenjualanKategori" ||
                formpencarian == "LaporanPenjualanBarang" || formpencarian == "LaporanPenjualanCustomer" || formpencarian == "LaporanGudangMasukStok" ||
                formpencarian == "LaporanPindahGudangStok" || formpencarian == "LaporanGudangMasukKartuStok" || formpencarian == "LaporanPindahGudangKartuStok" ||
                formpencarian == "LaporanGudangMasukBarang" || formpencarian == "LaporanPindahGudangBarang" || formpencarian == "LaporanRLPenjualanKategori" ||
                formpencarian == "LaporanRLPenjualanBarang" || formpencarian == "LaporanReturPembelianSupplier" || formpencarian == "LaporanReturPembelianBarang" ||
                formpencarian == "LaporanReturPenjualanCustomer" || formpencarian == "LaporanReturPenjualanBarang" || formpencarian == "LaporanMutasiStok")
            {
                rpt.LaporanParam.id = row.Cells[0].Value.ToString();
            }
            else if (formpencarian == "CekHargaBeliBarang-PerBarang" || formpencarian == "CekHargaBeliBarang-PerKategori")
            {
                rpt.LaporanParam2.id = row.Cells[0].Value.ToString();
            }
        }
        #endregion

        private void List_Load(object sender, EventArgs e)
        {
            LoadDetailData();
            Pencarian();
        }

        private void List_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.BlockChar(e);
        }

        private void txtPencarian_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Pencarian();
                dgPencarian.Focus();
            }
        }

        private void btnPencarian_Click(object sender, EventArgs e)
        {
            Pencarian();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtPencarian.Text = "";
            Pencarian();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgPencarian_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgPencarian.Rows.Count > 0)
            {
                if (e.RowIndex >= 0)
                {
                    row = dgPencarian.Rows[e.RowIndex];

                    HasilPencarian();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void dgPencarian_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgPencarian.Rows.Count > 0)
                {
                    var selectedCell = dgPencarian.CurrentCell.RowIndex;
                    if (selectedCell >= 0)
                    {
                        row = dgPencarian.Rows[selectedCell];

                        HasilPencarian();
                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
