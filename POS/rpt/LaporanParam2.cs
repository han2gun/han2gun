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
    public partial class LaporanParam2 : Form
    {
        cls.Fungsi fs = new cls.Fungsi();
        cls.Pesan psn = new cls.Pesan();
        cls.Query qry = new cls.Query();

        MenuUtama frmUtama;
        public static string id;
        public string userName;
        public string jenisLaporan;

        public LaporanParam2(MenuUtama mnutama)
        {
            InitializeComponent();

            frmUtama = mnutama;
            this.KeyDown += new KeyEventHandler(this.OnKeyDown);
            ActiveControl = txtPencarian;
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
            if (jenisLaporan == "CekHargaBeliBarang")
            {
                string data = "";

                if(rbBarang.Checked == true)
                {
                    data = qry.GetData(this, "TampilData-CekHargaBeliBarang-Barang", id, 8, "nama", "barang", "barcode = '" + id + "'");
                }
                else if(rbKategori.Checked == true)
                {
                    data = qry.GetData(this, "TampilData-CekHargaBeliBarang-Kategori", id, 8, "nama", "kategori", "id = '" + id + "'");
                }

                if (data != "")
                {
                    string[] filldata = data.Split('|');

                    if (filldata.ToString() != "")
                    {
                        lblPencarian.Text = filldata[0];

                        qry.InsertLogAktivitas("TampilData-CekHargaBeliBarang", this, txtPencarian.Text.Trim(), userName);
                    }
                }
            }
        }

        private void ViewReport()
        {
            if (jenisLaporan == "CekHargaBeliBarang")
            {
                if (rbSemua.Checked == true)
                {
                    qry.CetakDokumen(this, "",
                        "a.barcode,b.nama AS namabarang,c.id as idkategori,c.nama AS namakategori,d.tgltransaksi,d.id,e.nama AS namasupplier," +
                        "a.hbelisatuan,a.ongkir,a.ppn,a.diskonumum,a.potlain,a.biayalain,f.stok,b.hargajual1 as hjual",
                        "barang_detail a INNER JOIN pembelian d ON a.idpembelian = d.id " +
                        "INNER JOIN barang_display f ON a.id = f.idbarangdetail " +
                        "INNER JOIN barang b ON f.barcode = b.barcode " +
                        "INNER JOIN kategori c ON b.idkategori = c.id " +
                        "INNER JOIN supplier e ON d.idsupplier = e.id",
                        "where f.stok > 0",
                        "cek_harga_beli_15");
                    cr.CekHargaBeliSemua rptDoc = new cr.CekHargaBeliSemua();
                    rptDoc.SetDataSource(qry.dataset.Tables[15]);
                    crViewer.ReportSource = rptDoc;
                    crViewer.Refresh();
                    qry.dataset.Clear();
                }
                else if (rbBarang.Checked == true)
                {
                    qry.CetakDokumen(this, "",
                        "a.barcode,b.nama AS namabarang,c.id as idkategori,c.nama AS namakategori,d.tgltransaksi,d.id,e.nama AS namasupplier," +
                        "a.hbelisatuan,a.ongkir,a.ppn,a.diskonumum,a.potlain,a.biayalain,f.stok,b.hargajual1 as hjual",
                        "barang_detail a INNER JOIN pembelian d ON a.idpembelian = d.id " +
                        "INNER JOIN barang_display f ON a.id = f.idbarangdetail " +
                        "INNER JOIN barang b ON f.barcode = b.barcode " +
                        "INNER JOIN kategori c ON b.idkategori = c.id " +
                        "INNER JOIN supplier e ON d.idsupplier = e.id",
                        "where a.barcode = '" + txtPencarian.Text.Trim() + "' and f.stok > 0",
                        "cek_harga_beli_15");
                    cr.CekHargaBeliBarang rptDoc = new cr.CekHargaBeliBarang();
                    rptDoc.SetDataSource(qry.dataset.Tables[15]);
                    crViewer.ReportSource = rptDoc;
                    crViewer.Refresh();
                    qry.dataset.Clear();
                }
                else if (rbKategori.Checked == true)
                {
                    qry.CetakDokumen(this, "",
                        "a.barcode,b.nama AS namabarang,c.id as idkategori,c.nama AS namakategori,d.tgltransaksi,d.id,e.nama AS namasupplier," +
                        "a.hbelisatuan,a.ongkir,a.ppn,a.diskonumum,a.potlain,a.biayalain,f.stok,b.hargajual1 as hjual",
                        "barang_detail a INNER JOIN pembelian d ON a.idpembelian = d.id " +
                        "INNER JOIN barang_display f ON a.id = f.idbarangdetail " +
                        "INNER JOIN barang b ON f.barcode = b.barcode " +
                        "INNER JOIN kategori c ON b.idkategori = c.id " +
                        "INNER JOIN supplier e ON d.idsupplier = e.id",
                        "where c.id = '" + txtPencarian.Text.Trim() + "' and f.stok > 0",
                        "cek_harga_beli_15");
                    cr.CekHargaBeliKategori rptDoc = new cr.CekHargaBeliKategori();
                    rptDoc.SetDataSource(qry.dataset.Tables[15]);
                    crViewer.ReportSource = rptDoc;
                    crViewer.Refresh();
                    qry.dataset.Clear();
                }
            }
        }
        #endregion

        private void LaporanParam2_Load(object sender, EventArgs e)
        {
            rbSemua.Checked = true;

            if (jenisLaporan == "CekHargaBeliBarang")
            {
                frmUtama.lblNamaForm.Text = "- Cek Harga Beli";
            }
        }

        private void LaporanParam2_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.BlockChar(e);
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            SelectToolBar(btnKeluar);
        }

        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            if(rbBarang.Checked == true || rbKategori.Checked == true)
            {
                if (txtPencarian.Text == "")
                {
                    psn.PesanInfo(label7.Text + " Masih Kosong");
                    txtPencarian.Focus();
                }
                else
                {
                    ViewReport();
                }
            }
            else if(rbSemua.Checked == true)
            {
                ViewReport();
            }            
        }

        private void btnPencarian_Click(object sender, EventArgs e)
        {
            if (jenisLaporan == "CekHargaBeliBarang")
            {
                if(rbBarang.Checked == true)
                {
                    cls.OpenForm op = new cls.OpenForm(frmUtama);
                    op.ListOpen("List", "CekHargaBeliBarang-PerBarang", "Barang", "", userName);

                    txtPencarian.Text = id;
                    id = "";
                }
                else if(rbKategori.Checked == true)
                {
                    cls.OpenForm op = new cls.OpenForm(frmUtama);
                    op.ListOpen("List", "CekHargaBeliBarang-PerKategori", "Kategori", "", userName);

                    txtPencarian.Text = id;
                    id = "";
                }   
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

        private void rbSemua_CheckedChanged(object sender, EventArgs e)
        {
            if(rbSemua.Checked == true)
            {
                txtPencarian.Enabled = false;
                btnPencarian.Enabled = false;
            }
        }

        private void rbBarang_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBarang.Checked == true)
            {
                txtPencarian.Enabled = true;
                btnPencarian.Enabled = true;
            }
        }

        private void rbKategori_CheckedChanged(object sender, EventArgs e)
        {
            if(rbKategori.Checked == true)
            {
                txtPencarian.Enabled = true;
                btnPencarian.Enabled = true;
            }
        }
    }
}
