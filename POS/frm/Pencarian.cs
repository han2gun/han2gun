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
    public partial class Pencarian : Form
    {
        cls.Query qry = new cls.Query();
        cls.Fungsi fs = new cls.Fungsi();

        public string userName;
        public string formpencarian;
        string[] headercolom;
        string[] penyaringan;
        string[] pilihancbo;
        int banyakkolom;
        int indexcombo;
        int pencariancell;
        string query;
        string halpencarian;
        DataGridViewRow row;
        MenuUtama frmUtama;

        public Pencarian(MenuUtama mnutama)
        {
            InitializeComponent();

            frmUtama = mnutama;
            this.KeyDown += new KeyEventHandler(this.OnKeyDown);
            fs.BoldHeaderDataGridView(dgPencarian);
            pencariancell = 0;
            ActiveControl = txtPencarian;
        }

        #region Code
        private void UsrAccess()
        {
            string data = qry.GetData(this, "UsrAccess", userName, 0,
                "karyawanprt,pelangganprt,pemasokprt,kelbarangprt,barangprt", "usrmgmt", "usrname = '" + userName + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    if (filldata[0] == "1")
                        btnCetak.Enabled = true;
                    if (filldata[1] == "1")
                        btnCetak.Enabled = true;
                    if (filldata[2] == "1")
                        btnCetak.Enabled = true;
                    if (filldata[3] == "1")
                        btnCetak.Enabled = true;
                    if (filldata[4] == "1")
                        btnCetak.Enabled = true;

                    qry.InsertLogAktivitas("UsrAccess", this, userName, userName);
                }
            }
        }

        private void SelectToolBar(Button btn)
        {
            cls.OpenForm op = new cls.OpenForm(frmUtama);

            switch (btn.AccessibleName)
            {
                case "BARU":
                    if (formpencarian == "Supplier")
                    {
                        op.SupplierOpen(this, formpencarian, "", userName);
                    }
                    else if (formpencarian == "Karyawan")
                    {
                        op.KaryawanOpen(this, formpencarian, "", userName);
                    }
                    else if (formpencarian == "Customer")
                    {
                        op.CustomerOpen(this, formpencarian, "", userName);
                    }
                    else if (formpencarian == "KategoriBarang")
                    {
                        op.KategoriOpen(this, formpencarian, "", userName);
                    }
                    else if (formpencarian == "Barang")
                    {
                        op.BarangOpen(this, formpencarian, "", userName);
                    }
                    else if (formpencarian == "Pembelian")
                    {
                        op.PembelianOpen(this, formpencarian, "", userName);
                    }
                    else if (formpencarian == "ReturPembelian")
                    {
                        op.ReturPembelianOpen(this, formpencarian, "", userName);
                    }
                    else if (formpencarian == "Hutang")
                    {
                        op.HutangOpen(this, formpencarian, "", userName);
                    }
                    else if (formpencarian == "Gudang")
                    {
                        op.GudangOpen(this, formpencarian, "", userName);
                    }
                    else if (formpencarian == "PindahGudang")
                    {
                        op.PindahGudangOpen(this, formpencarian, "", userName);
                    }
                    else if (formpencarian == "Kas")
                    {
                        op.KasOpen(this, formpencarian, "", userName);
                    }
                    else if (formpencarian == "Diskon")
                    {
                        op.DiskonOpen(this, formpencarian, "", userName);
                    }
                    else if (formpencarian == "Penjualan")
                    {
                        op.PenjualanOpen(this, formpencarian, "", userName);
                    }
                    else if (formpencarian == "ReturPenjualan")
                    {
                        op.ReturPenjualanOpen(this, formpencarian, "", userName);
                    }
                    else if (formpencarian == "Piutang")
                    {
                        op.PiutangOpen(this, formpencarian, "", userName);
                    }
                    else if (formpencarian == "Penyesuaian")
                    {
                        op.PenyesuaianOpen(this, formpencarian, "", userName);
                    }
                    else if (formpencarian == "PengaturanPengguna")
                    {
                        op.UserMgmtOpen(this, formpencarian, "", userName);
                    }
                    break;
                case "KELUAR":
                    if (formpencarian == "Supplier" || formpencarian == "Karyawan" || formpencarian == "Customer" || formpencarian == "KategoriBarang" ||
                        formpencarian == "Barang")
                    {
                        op.MasterDataOpen("MasterData", userName);
                    }
                    else if (formpencarian == "Pembelian" || formpencarian == "ReturPembelian" || formpencarian == "Hutang" || formpencarian == "Gudang" || 
                        formpencarian == "PindahGudang" || formpencarian == "Kas" || formpencarian == "Diskon" || formpencarian == "Penjualan" || 
                        formpencarian == "ReturPenjualan" || formpencarian == "Piutang" || formpencarian == "Penyesuaian")
                    {
                        op.TransaksiOpen("Transaksi", userName);
                    }
                    else if (formpencarian == "PengaturanPengguna")
                    {
                        op.PengaturanOpen("Pengaturan", userName);
                    }

                    frmUtama.lblNamaForm.Visible = false;
                    break;
                case "CETAK":
                    if (formpencarian == "Karyawan")
                    {
                        Cetak("Karyawan");
                    }
                    else if (formpencarian == "Supplier")
                    {
                        Cetak("Supplier");
                    }
                    else if (formpencarian == "Customer")
                    {
                        Cetak("Customer");
                    }
                    else if (formpencarian == "KategoriBarang")
                    {
                        Cetak("KategoriBarang");
                    }
                    else if (formpencarian == "Barang")
                    {
                        Cetak("Barang");
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
                case Keys.F2:
                    if (btnBaru.Enabled == true)
                        SelectToolBar(btnBaru);
                    break;
                case Keys.F10:
                    SelectToolBar(btnKeluar);
                    break;
                case Keys.F12:
                    SelectToolBar(btnCetak);
                    break;
                default:
                    break;
            }
        }

        private void RadioButtonOption()
        {
            if (formpencarian == "Supplier" || formpencarian == "Karyawan" || formpencarian == "Customer" || formpencarian == "KategoriBarang" ||
                formpencarian == "Barang" || formpencarian == "PengaturanPengguna")
            {
                rbTanggal.Visible = false;
            }
            else if (formpencarian == "Pembelian" || formpencarian == "ReturPembelian" || formpencarian == "Hutang" || formpencarian == "Gudang" || 
                formpencarian == "PindahGudang" || formpencarian == "Kas" || formpencarian == "Diskon" || formpencarian == "Penjualan" || 
                formpencarian == "ReturPenjualan" || formpencarian == "Piutang" || formpencarian == "Penyesuaian")
            {
                rbTanggal.Visible = true;
            }
        }

        private void LoadDetailData()
        {
            if (formpencarian == "Supplier")
            {
                frmUtama.lblNamaForm.Text = "- Pencarian Supplier";
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
            else if (formpencarian == "Karyawan")
            {
                frmUtama.lblNamaForm.Text = "- Pencarian Karyawan";
                headercolom = new string[] { "ID", "Awal", "Nama", "Alamat", "Telp.", "No. HP", "Email", "Catatan" };
                banyakkolom = 8;
                penyaringan = new string[] { "nama", "alamat", "telp", "nohp", "email", "catatan", "id" };
                pilihancbo = new string[] { penyaringan[0].ToUpper(), penyaringan[1].ToUpper(), penyaringan[2].ToUpper(), penyaringan[3].ToUpper(),
                    penyaringan[4].ToUpper(), penyaringan[5].ToUpper(), penyaringan[6].ToUpper() };
                for (int i = 0; i < pilihancbo.Length; i++)
                {
                    cboPencarian.Items.Add(pilihancbo[i]);
                }
                cboPencarian.SelectedIndex = 0;
            }
            else if (formpencarian == "Customer")
            {
                frmUtama.lblNamaForm.Text = "- Pencarian Customer";
                headercolom = new string[] { "ID", "Awal", "Nama", "Alamat", "Telp.", "No. HP", "Fax", "Email", "NPWP", "Website", "Catatan" };
                banyakkolom = 11;
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
            else if (formpencarian == "KategoriBarang")
            {
                frmUtama.lblNamaForm.Text = "- Pencarian Kategori Barang";
                headercolom = new string[] { "ID", "Nama", "Catatan" };
                banyakkolom = 3;
                penyaringan = new string[] { "nama", "catatan", "id" };
                pilihancbo = new string[] { penyaringan[0].ToUpper(), penyaringan[1].ToUpper(), penyaringan[2].ToUpper() };
                for (int i = 0; i < pilihancbo.Length; i++)
                {
                    cboPencarian.Items.Add(pilihancbo[i]);
                }
                cboPencarian.SelectedIndex = 0;
            }
            else if (formpencarian == "Barang")
            {
                frmUtama.lblNamaForm.Text = "- Pencarian Barang";
                headercolom = new string[] { "Barcode", "Nama", "Kategori", "Catatan", "Stok", "Stok Min.", "Satuan", "Harga Beli", "Harga Jual" };
                banyakkolom = 9;
                penyaringan = new string[] { "a.barcode", "a.nama", "b.nama", "a.catatan" };
                pilihancbo = new string[] { "BARCODE", "NAMA", "KATEGORI", "CATATAN" };
                for (int i = 0; i < pilihancbo.Length; i++)
                {
                    cboPencarian.Items.Add(pilihancbo[i]);
                }
                cboPencarian.SelectedIndex = 0;
            }
            else if (formpencarian == "Pembelian")
            {
                frmUtama.lblNamaForm.Text = "- Pencarian Pembelian";
                headercolom = new string[] { "ID", "Supplier", "No. Nota", "Tgl. Transaksi", "Tgl. Tempo", "Catatan", "Grand Total" };
                banyakkolom = 7;
                penyaringan = new string[] { "b.nama", "a.nonota", "a.catatan", "a.id" };
                pilihancbo = new string[] { "SUPPLIER", "NO. NOTA", "CATATAN", "ID" };
                for (int i = 0; i < pilihancbo.Length; i++)
                {
                    cboPencarian.Items.Add(pilihancbo[i]);
                }
                cboPencarian.SelectedIndex = 0;
            }
            else if (formpencarian == "ReturPembelian")
            {
                frmUtama.lblNamaForm.Text = "- Pencarian Retur Pembelian";
                headercolom = new string[] { "ID", "Supplier", "ID Pembelian", "No. Nota", "Tgl. Transaksi", "Catatan", "Grand Total" };
                banyakkolom = 7;
                penyaringan = new string[] { "b.nama", "a.idpembelian", "c.nonota", "a.catatan", "a.id" };
                pilihancbo = new string[] { "SUPPLIER", "ID PEMBELIAN", "NO. NOTA", "CATATAN", "ID" };
                for (int i = 0; i < pilihancbo.Length; i++)
                {
                    cboPencarian.Items.Add(pilihancbo[i]);
                }
                cboPencarian.SelectedIndex = 0;
            }
            else if (formpencarian == "Hutang")
            {
                frmUtama.lblNamaForm.Text = "- Pencarian Hutang";
                headercolom = new string[] { "ID", "Tgl. Transaksi", "Supplier", "ID Pembelian", "No. Nota", "Catatan", "Total Bayar" };
                banyakkolom = 7;
                penyaringan = new string[] { "c.nama", "b.nonota", "a.catatan", "b.id", "a.id" };
                pilihancbo = new string[] { "SUPPLIER", "NO. NOTA", "CATATAN", "ID PEMBELIAN", "ID" };
                for (int i = 0; i < pilihancbo.Length; i++)
                {
                    cboPencarian.Items.Add(pilihancbo[i]);
                }
                cboPencarian.SelectedIndex = 0;
            }
            else if (formpencarian == "Gudang")
            {
                frmUtama.lblNamaForm.Text = "- Pencarian Gudang";
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
            else if (formpencarian == "PindahGudang")
            {
                frmUtama.lblNamaForm.Text = "- Pencarian Pindah Gudang";
                headercolom = new string[] { "ID", "Tgl. Transaksi", "Catatan", "Lokasi" };
                banyakkolom = 4;
                penyaringan = new string[] { "lokasi", "catatan", "id" };
                pilihancbo = new string[] { penyaringan[0].ToUpper(), penyaringan[1].ToUpper(), penyaringan[2].ToUpper() };
                for (int i = 0; i < pilihancbo.Length; i++)
                {
                    cboPencarian.Items.Add(pilihancbo[i]);
                }
                cboPencarian.SelectedIndex = 0;
            }
            else if (formpencarian == "Kas")
            {
                frmUtama.lblNamaForm.Text = "- Pencarian Kas";
                headercolom = new string[] { "ID", "Jenis", "Tgl. Transaksi", "Catatan", "Grand Total" };
                banyakkolom = 5;
                penyaringan = new string[] { "if(jeniskas = 1,'KAS MASUK','KAS KELUAR')", "catatan", "id" };
                pilihancbo = new string[] { "JENIS KAS", "CATATAN", "ID" };
                for (int i = 0; i < pilihancbo.Length; i++)
                {
                    cboPencarian.Items.Add(pilihancbo[i]);
                }
                cboPencarian.SelectedIndex = 0;
            }
            else if (formpencarian == "Diskon")
            {
                frmUtama.lblNamaForm.Text = "- Pencarian Diskon";
                headercolom = new string[] { "ID", "Aktif", "Nama", "Tgl. Mulai", "Tgl. Selesai" };
                banyakkolom = 5;
                penyaringan = new string[] { "Nama", "if(aktif = 0, 'TDK AKTIF', 'AKTIF')", "ID" };
                pilihancbo = new string[] { "NAMA", "AKTIF", "ID" };
                for (int i = 0; i < pilihancbo.Length; i++)
                {
                    cboPencarian.Items.Add(pilihancbo[i]);
                }
                cboPencarian.SelectedIndex = 0;
            }
            else if (formpencarian == "Penjualan")
            {
                frmUtama.lblNamaForm.Text = "- Pencarian Penjualan";
                headercolom = new string[] { "ID", "Customer", "Sales", "Tgl.Transaksi", "Catatan", "Grand Total" };
                banyakkolom = 6;
                penyaringan = new string[] { "b.nama", "a.sales", "a.catatan", "a.id" };
                pilihancbo = new string[] { "CUSTOMER", "SALES", "CATATAN", "ID"  };
                for (int i = 0; i < pilihancbo.Length; i++)
                {
                    cboPencarian.Items.Add(pilihancbo[i]);
                }
                cboPencarian.SelectedIndex = 0;
            }
            else if (formpencarian == "ReturPenjualan")
            {
                frmUtama.lblNamaForm.Text = "- Pencarian Retur Penjualan";
                headercolom = new string[] { "ID", "Customer", "ID Penjualan", "Tgl.Transaksi", "Catatan", "Grand Total" };
                banyakkolom = 6;
                penyaringan = new string[] { "c.nama", "a.idpenjualan", "a.catatan", "a.id" };
                pilihancbo = new string[] { "CUSTOMER", "ID PENJUALAN", "CATATAN", "ID" };
                for (int i = 0; i < pilihancbo.Length; i++)
                {
                    cboPencarian.Items.Add(pilihancbo[i]);
                }
                cboPencarian.SelectedIndex = 0;
            }
            else if (formpencarian == "Piutang")
            {
                frmUtama.lblNamaForm.Text = "- Pencarian Piutang";
                headercolom = new string[] { "ID", "Tgl. Transaksi", "Customer", "ID Penjualan", "Catatan", "Total Bayar" };
                banyakkolom = 6;
                penyaringan = new string[] { "c.nama", "a.catatan", "b.id", "a.id" };
                pilihancbo = new string[] { "CUSTOMER", "CATATAN", "ID PENJUALAN", "ID" };
                for (int i = 0; i < pilihancbo.Length; i++)
                {
                    cboPencarian.Items.Add(pilihancbo[i]);
                }
                cboPencarian.SelectedIndex = 0;
            }
            else if (formpencarian == "Penyesuaian")
            {
                frmUtama.lblNamaForm.Text = "- Pencarian Penyesuaian";
                headercolom = new string[] { "ID", "Tgl. Transaksi", "Catatan" };
                banyakkolom = 3;
                penyaringan = new string[] { "id", "catatan" };
                pilihancbo = new string[] { penyaringan[0].ToUpper(), penyaringan[1].ToUpper() };
                for (int i = 0; i < pilihancbo.Length; i++)
                {
                    cboPencarian.Items.Add(pilihancbo[i]);
                }
                cboPencarian.SelectedIndex = 0;
            }
            else if (formpencarian == "PengaturanPengguna")
            {
                frmUtama.lblNamaForm.Text = "- Pencarian Pengguna";
                headercolom = new string[] { "User Name", "Pengguna", "Role" };
                banyakkolom = 3;
                penyaringan = new string[] { "usrname", "namauser", "roleusr" };
                pilihancbo = new string[] { "USER NAME", "PENGGUNA", "ROLE" };
                for (int i = 0; i < pilihancbo.Length; i++)
                {
                    cboPencarian.Items.Add(pilihancbo[i]);
                }
                cboPencarian.SelectedIndex = 0;
            }

            frmUtama.lblNamaForm.Visible = true;
        }

        private void PencarianData()
        {
            string tglAwal = dtAwal.Value.ToString("yyyy-MM-dd");
            string tglAkhir = dtAkhir.Value.ToString("yyyy-MM-dd");

            if (formpencarian == "Supplier")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                query = "select id,nama,alamat,telp,nohp,fax,email,npwp,website,catatan from supplier where " +
                    penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' order by id limit 200";
                halpencarian = "Supplier";
            }
            else if (formpencarian == "Karyawan")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                query = "select id,if(cekawal = 1,'YA','-'),nama,alamat,telp,nohp,email,catatan from karyawan where " +
                    penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' order by id limit 200";
                halpencarian = "Karyawan";
            }
            else if (formpencarian == "Customer")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                query = "select id,if(cekawal = 1,'YA','-'),nama,alamat,telp,nohp,fax,email,npwp,website,catatan from customer where " +
                    penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' order by id limit 200";
                halpencarian = "Customer";
            }
            else if (formpencarian == "KategoriBarang")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                query = "select id,nama,catatan from kategori where " +
                    penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' order by id limit 200";
                halpencarian = "Kategori Barang";
            }
            else if (formpencarian == "Barang")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                query = "select a.barcode, a.nama, b.nama, a.catatan, format(a.stokgudang,2) as stokgudang, format(a.stokmin,2) as stokmin, a.satuanstok, " +
                    "format(a.hargabeli,2) as hargabeli, format(a.hargajual1,2) as hargajual " +
                    "from barang a inner join kategori b on a.idkategori = b.id " +
                    "where " + penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' order by a.nama limit 200";
                halpencarian = "Barang";
            }
            else if (formpencarian == "PengaturanPengguna")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                query = "select usrname,namauser,roleusr from usrmgmt where " +
                    penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' order by usrname limit 100";
                halpencarian = "Pengaturan Pengguna";
            }
            else if (formpencarian == "Pembelian")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                string queryAwal = "select a.id, b.nama, a.nonota, date_format(a.tgltransaksi, '%d-%b-%Y') as tgltr, date_format(a.tgltempo, '%d-%b-%Y') as tgltmp, " +
                    "a.catatan, format(a.grandtotal,2) as grandtotal from pembelian a inner join supplier b on a.idsupplier = b.id";

                if (rbLain.Checked == true)
                {
                    query = queryAwal + " where " + penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' order by a.tgltransaksi desc limit 200";
                }
                else
                {
                    query = queryAwal + " where a.tgltransaksi >= '" + tglAwal + "' and a.tgltransaksi <= '" + tglAkhir + "' order by a.tgltransaksi desc limit 200";
                }

                halpencarian = "Pembelian";
            }
            else if (formpencarian == "ReturPembelian")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                string queryAwal = "select a.id, b.nama, a.idpembelian, c.nonota, date_format(a.tgltransaksi, '%d-%b-%Y') as tgltr, a.catatan, format(a.grandtotal,2) as grandtotal " +
                    "from retur_pembelian a inner join supplier b on a.idsupplier = b.id " +
                    "inner join pembelian c on a.idpembelian = c.id";

                if (rbLain.Checked == true)
                {
                    query = queryAwal + " where " + penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' order by a.tgltransaksi desc limit 200";
                }
                else
                {
                    query = queryAwal + " where a.tgltransaksi >= '" + tglAwal + "' and a.tgltransaksi <= '" + tglAkhir + "' order by a.tgltransaksi desc limit 200";
                }

                halpencarian = "ReturPembelian";
            }
            else if (formpencarian == "Hutang")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                string queryAwal = "select a.id, date_format(a.tgltransaksi, '%d-%b-%Y') as tgltr, c.nama, b.id, b.nonota, a.catatan, format(a.bayar,2) as bayar " +
                    "from hutang a inner join pembelian b on a.idpembelian = b.id inner join supplier c on b.idsupplier = c.id";

                if (rbLain.Checked == true)
                {
                    query = queryAwal + " where " + penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' order by a.tgltransaksi desc limit 200";
                }
                else
                {
                    query = queryAwal + " where a.tgltransaksi >= '" + tglAwal + "' and a.tgltransaksi <= '" + tglAkhir + "' order by a.tgltransaksi desc limit 200";
                }

                halpencarian = "Hutang";
            }
            else if (formpencarian == "Gudang")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                string queryAwal = "select a.id, c.nama, b.id, b.nonota, date_format(a.tgltransaksi, '%d-%b-%Y') as tgltr, a.catatan " +
                    "from gudang_masuk a inner join pembelian b on a.idpembelian = b.id inner join supplier c on b.idsupplier = c.id";

                if (rbLain.Checked == true)
                {
                    query = queryAwal + " where " + penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' order by a.tgltransaksi desc limit 200";
                }
                else
                {
                    query = queryAwal + " where a.tgltransaksi >= '" + tglAwal + "' and a.tgltransaksi <= '" + tglAkhir + "' order by a.tgltransaksi desc limit 200";
                }

                halpencarian = "Gudang";
            }
            else if (formpencarian == "PindahGudang")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                string queryAwal = "select id, date_format(tgltransaksi, '%d-%b-%Y') as tgltr, catatan, lokasi from pindah_gudang";

                if (rbLain.Checked == true)
                {
                    query = queryAwal + " where " + penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' order by tgltransaksi desc limit 200";
                }
                else
                {
                    query = queryAwal + " where tgltransaksi >= '" + tglAwal + "' and tgltransaksi <= '" + tglAkhir + "' order by tgltransaksi desc limit 200";
                }

                halpencarian = "PindahGudang";
            }
            else if (formpencarian == "Kas")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                string queryAwal = "select id, if(jeniskas = 1, 'KAS MASUK', 'KAS KELUAR') as jenis, date_format(tgltransaksi, '%d-%b-%Y') as tgltr, catatan, format(grandtotal,2) " +
                    "from kas";

                if (rbLain.Checked == true)
                {
                    query = queryAwal + " where " + penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' order by tgltransaksi desc limit 200";
                }
                else
                {
                    query = queryAwal + " where tgltransaksi >= '" + tglAwal + "' and tgltransaksi <= '" + tglAkhir + "' order by tgltransaksi desc limit 200";
                }

                halpencarian = "Kas";
            }
            else if (formpencarian == "Diskon")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                string queryAwal = "select id, if(aktif = 0, 'TDK AKTIF', 'AKTIF') as aktif, nama, date_format(tglmulai, '%d-%b-%Y') as tglmulai, " +
                    "date_format(tglselesai, '%d-%b-%Y') as tglselesai from diskon";

                if (rbLain.Checked == true)
                {
                    query = queryAwal + " where " + penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' order by tglmulai desc limit 200";
                }
                else
                {
                    query = queryAwal + " where tglmulai >= '" + tglAwal + "' and tglmulai <= '" + tglAkhir + "' order by tglmulai desc limit 200";
                }

                halpencarian = "Diskon";
            }
            else if (formpencarian == "Penjualan")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                string queryAwal = "select a.id, b.nama, a.sales, date_format(a.tgltransaksi, '%d-%b-%Y') as tgltr, a.catatan, format(a.grandtotal,2) as grandtotal " +
                    "from penjualan a inner join customer b on a.idcustomer = b.id";

                if (rbLain.Checked == true)
                {
                    query = queryAwal + " where " + penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' order by a.tgltransaksi desc limit 200";
                }
                else
                {
                    query = queryAwal + " where a.tgltransaksi >= '" + tglAwal + "' and a.tgltransaksi <= '" + tglAkhir + "' order by a.tgltransaksi desc limit 200";
                }

                halpencarian = "Penjualan";
            }
            else if (formpencarian == "ReturPenjualan")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                string queryAwal = "select a.id, c.nama, a.idpenjualan, date_format(a.tgltransaksi, '%d-%b-%Y') as tgltr, a.catatan, format(a.grandtotal,2) as grandtotal " +
                    "from retur_penjualan a inner join penjualan b on a.idpenjualan = b.id " +
                    "inner join customer c on b.idcustomer = c.id";

                if (rbLain.Checked == true)
                {
                    query = queryAwal + " where " + penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' order by a.tgltransaksi desc limit 200";
                }
                else
                {
                    query = queryAwal + " where a.tgltransaksi >= '" + tglAwal + "' and a.tgltransaksi <= '" + tglAkhir + "' order by a.tgltransaksi desc limit 200";
                }

                halpencarian = "ReturPenjualan";
            }
            else if (formpencarian == "Piutang")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                string queryAwal = "select a.id, date_format(a.tgltransaksi, '%d-%b-%Y') as tgltr, c.nama, b.id, a.catatan, format(a.bayar,2) as bayar " +
                    "from piutang a inner join penjualan b on a.idpenjualan = b.id inner join customer c on b.idcustomer = c.id";

                if (rbLain.Checked == true)
                {
                    query = queryAwal + " where " + penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' order by a.tgltransaksi desc limit 200";
                }
                else
                {
                    query = queryAwal + " where a.tgltransaksi >= '" + tglAwal + "' and a.tgltransaksi <= '" + tglAkhir + "' order by a.tgltransaksi desc limit 200";
                }

                halpencarian = "Piutang";
            }
            else if (formpencarian == "Penyesuaian")
            {
                indexcombo = Convert.ToInt32(cboPencarian.SelectedIndex);
                string queryAwal = "select id, date_format(tgltransaksi, '%d-%b-%Y') as tgltr, catatan " +
                    "from penyesuaian";

                if (rbLain.Checked == true)
                {
                    query = queryAwal + " where " + penyaringan[indexcombo].ToString() + " like '%" + txtPencarian.Text.Trim() + "%' order by tgltransaksi desc limit 200";
                }
                else
                {
                    query = queryAwal + " where tgltransaksi >= '" + tglAwal + "' and tgltransaksi <= '" + tglAkhir + "' order by tgltransaksi desc limit 200";
                }

                halpencarian = "Penyesuaian";
            }

            qry.PencarianDataString(this, formpencarian, dgPencarian, headercolom, banyakkolom, query, halpencarian, cboPencarian.Text, txtPencarian.Text.Trim());

            if(formpencarian == "Barang")
            {
                dgPencarian.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgPencarian.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgPencarian.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgPencarian.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else if(formpencarian == "Pembelian")
            {
                dgPencarian.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else if (formpencarian == "ReturPembelian")
            {
                dgPencarian.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else if (formpencarian == "Hutang")
            {
                dgPencarian.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else if (formpencarian == "Penjualan")
            {
                dgPencarian.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else if (formpencarian == "ReturPenjualan")
            {
                dgPencarian.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else if (formpencarian == "Piutang")
            {
                dgPencarian.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else if (formpencarian == "Kas")
            {
                dgPencarian.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void Cetak(string namaform)
        {
            cls.OpenForm op = new cls.OpenForm(frmUtama);
            op.PreviewCetakOpen(this, "PreviewCetakData", "", namaform, userName);
        }
        #endregion

        private void Pencarian_Load(object sender, EventArgs e)
        {
            UsrAccess();
            RadioButtonOption();
            LoadDetailData();
            PencarianData();

            if(formpencarian == "Karyawan" || formpencarian == "Customer" || formpencarian == "Supplier" || formpencarian == "KategoriBarang" || formpencarian == "Barang")
            {
                btnCetak.Visible = true;
            }
        }

        private void Pencarian_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.BlockChar(e);
        }

        private void txtPencarian_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                PencarianData();
                //dgPencarian.Focus();
            }
        }

        private void btnPencarian_Click(object sender, EventArgs e)
        {
            PencarianData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtPencarian.Text = "";
            PencarianData();
        }

        private void dgPencarian_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cls.OpenForm op = new cls.OpenForm(frmUtama);

            if (dgPencarian.Rows.Count > 0)
            {
                if (e.RowIndex >= 0)
                {
                    row = dgPencarian.Rows[e.RowIndex];

                    if (formpencarian == "Supplier")
                    {
                        op.SupplierOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                    }
                    else if (formpencarian == "Karyawan")
                    {
                        op.KaryawanOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                    }
                    else if (formpencarian == "Customer")
                    {
                        op.CustomerOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                    }
                    else if (formpencarian == "KategoriBarang")
                    {
                        op.KategoriOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                    }
                    else if (formpencarian == "Barang")
                    {
                        op.BarangOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                    }
                    else if (formpencarian == "Pembelian")
                    {
                        op.PembelianOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                    }
                    else if (formpencarian == "ReturPembelian")
                    {
                        op.ReturPembelianOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                    }
                    else if (formpencarian == "Hutang")
                    {
                        op.HutangOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                    }
                    else if (formpencarian == "Gudang")
                    {
                        op.GudangOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                    }
                    else if (formpencarian == "PindahGudang")
                    {
                        op.PindahGudangOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                    }
                    else if (formpencarian == "Kas")
                    {
                        op.KasOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                    }
                    else if (formpencarian == "Diskon")
                    {
                        op.DiskonOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                    }
                    else if (formpencarian == "Penjualan")
                    {
                        op.PenjualanOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                    }
                    else if (formpencarian == "ReturPenjualan")
                    {
                        op.ReturPenjualanOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                    }
                    else if (formpencarian == "Piutang")
                    {
                        op.PiutangOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                    }
                    else if (formpencarian == "Penyesuaian")
                    {
                        op.PenyesuaianOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                    }
                    else if (formpencarian == "PengaturanPengguna")
                    {
                        op.UserMgmtOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                    }
                }
            }
        }

        private void dgPencarian_KeyDown(object sender, KeyEventArgs e)
        {
            cls.OpenForm op = new cls.OpenForm(frmUtama);

            if (e.KeyCode == Keys.Enter)
            {
                if (dgPencarian.Rows.Count > 0)
                {
                    var selectedCell = dgPencarian.CurrentCell.RowIndex;
                    if (selectedCell >= 0)
                    {
                        row = dgPencarian.Rows[selectedCell];

                        if (formpencarian == "Supplier")
                        {
                            op.SupplierOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                        }
                        else if (formpencarian == "Karyawan")
                        {
                            op.KaryawanOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                        }
                        else if (formpencarian == "Customer")
                        {
                            op.CustomerOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                        }
                        else if (formpencarian == "KategoriBarang")
                        {
                            op.KategoriOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                        }
                        else if (formpencarian == "Barang")
                        {
                            op.BarangOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                        }
                        else if (formpencarian == "Pembelian")
                        {
                            op.PembelianOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                        }
                        else if (formpencarian == "ReturPembelian")
                        {
                            op.ReturPembelianOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                        }
                        else if (formpencarian == "Hutang")
                        {
                            op.HutangOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                        }
                        else if (formpencarian == "Gudang")
                        {
                            op.GudangOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                        }
                        else if (formpencarian == "PindahGudang")
                        {
                            op.PindahGudangOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                        }
                        else if (formpencarian == "Kas")
                        {
                            op.KasOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                        }
                        else if (formpencarian == "Diskon")
                        {
                            op.DiskonOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                        }
                        else if (formpencarian == "Penjualan")
                        {
                            op.PenjualanOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                        }
                        else if (formpencarian == "ReturPenjualan")
                        {
                            op.ReturPenjualanOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                        }
                        else if (formpencarian == "Piutang")
                        {
                            op.PiutangOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                        }
                        else if (formpencarian == "Penyesuaian")
                        {
                            op.PenyesuaianOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                        }
                        else if (formpencarian == "PengaturanPengguna")
                        {
                            op.UserMgmtOpen(this, formpencarian, row.Cells[pencariancell].Value.ToString(), userName);
                        }
                    }
                }
            }
        }

        private void btnBaru_Click(object sender, EventArgs e)
        {
            SelectToolBar(btnBaru);
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            SelectToolBar(btnKeluar);
        }

        private void rbLain_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLain.Checked == true)
            {
                dtAwal.Visible = false;
                label1.Visible = false;
                dtAkhir.Visible = false;
                cboPencarian.Visible = true;
                txtPencarian.Visible = true;
                fs.ButtonLocation(btnPencarian, frmUtama.btn_pencarianlain_x, frmUtama.btn_pencarianlain_y);
                fs.ButtonLocation(btnRefresh, frmUtama.btn_refreshlain_x, frmUtama.btn_refreshlain_y);
            }
        }

        private void rbTanggal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTanggal.Checked == true)
            {
                dtAwal.Visible = true;
                label1.Visible = true;
                dtAkhir.Visible = true;
                cboPencarian.Visible = false;
                txtPencarian.Visible = false;
                fs.ButtonLocation(btnPencarian, frmUtama.btn_pencariantgl_x, frmUtama.btn_pencariantgl_y);
                fs.ButtonLocation(btnRefresh, frmUtama.btn_refreshtgl_x, frmUtama.btn_refreshtgl_y);
            }
        }

        private void btnCetak_Click(object sender, EventArgs e)
        {
            SelectToolBar(btnCetak);
        }
    }
}
