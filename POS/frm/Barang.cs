using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using System.Threading;

namespace POS.frm
{
    public partial class Barang : Form
    {
        cls.Fungsi fs = new cls.Fungsi();
        cls.Pesan psn = new cls.Pesan();
        cls.Query qry = new cls.Query();

        MenuUtama frmUtama;
        public string userName;
        public string id;
        string idUpdate;
        bool updateData;

        public Barang(MenuUtama mnutama)
        {
            InitializeComponent();

            frmUtama = mnutama;
            idUpdate = "";
            updateData = false;
            this.KeyDown += new KeyEventHandler(this.OnKeyDown);
            ActiveControl = txtKodeBarcode;
        }

        #region code
        private void UsrAccess()
        {
            string data = qry.GetData(this, "UsrAccess", userName, 0,
                "barangsv,barangdel,barangprt,barangup,barangstokrp", "usrmgmt", "usrname = '" + userName + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    if (filldata[0] == "1")
                        btnSimpan.Enabled = true;
                    if (filldata[1] == "1")
                        btnHapus.Enabled = true;
                    if (filldata[2] == "1")
                        btnCetak.Enabled = true;
                    if (filldata[3] == "1")
                        updateData = true;
                    if (filldata[4] == "1")
                    {
                        label11.Visible = true;
                        lblStokRupiah.Visible = true;
                    }

                    qry.InsertLogAktivitas("UsrAccess", this, userName, userName);
                }
            }
        }

        private bool Clear(bool pbAll)
        {
            if (pbAll)
            {
                txtKodeBarcode.Text = "";
                txtKodeBarcode.Focus();
            }
            fs.FillTextBoxArray(new TextBox[] { txtNama, txtCatatan, txtSatuan1, txtSatuan2, txtSatuan3, txtSatuan4, txtSatuan5 }, "");
            fs.FillTextBoxArray(new TextBox[] { txtQtySatuan2, txtQtySatuan3, txtQtySatuan4, txtQtySatuan5, txtStokMin }, "0.00");
            fs.FillTextBoxArray(new TextBox[] { txtHargaBeli, txtHargaJual1, txtHargaJual2, txtHargaJual3, txtHargaJual4, txtHargaJual5 }, "0.00");
            lblStokTersedia.Text = "0.00";
            lblStokRupiah.Text = "0.00";
            //txtSatuan1.Enabled = true; //bernilai true jika ketika load data barang ditemukan di form lain satuan ke disable, makanya ketika clear harus di true dulu
            chkNonAktif.Checked = false;
            cboSatuanStokMin.Text = "";
            qry.ComboBoxFill(this, cboKategori, "Clear", "concat(id,'-',nama)", "kategori");

            return pbAll;
        }

        private void SelectToolBar(Button btn)
        {
            switch (btn.AccessibleName)
            {
                case "BARU":
                    DialogResult result = MessageBox.Show("Bersihkan Data?", "Konfirmasi", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        Clear(true);
                    }
                    break;
                case "SIMPAN":
                    if (txtKodeBarcode.Text.Trim() == "")
                    {
                        psn.PesanInfo("Kode Barcode Masih Kosong");
                        txtKodeBarcode.Focus();
                    }
                    else if(txtNama.Text.Trim() == "")
                    {
                        psn.PesanInfo("Nama Masih Kosong");
                        txtNama.Focus();
                    }
                    else if (cboKategori.Text.Trim() == "")
                    {
                        psn.PesanInfo("Kategori Masih Kosong");
                        cboKategori.Focus();
                    }
                    else if(Convert.ToDouble(txtQtySatuan2.Text) > 0 && txtSatuan2.Text == "")
                    {
                        psn.PesanInfo("Nama Satuan Tingkat 2 Masih Kosong");
                        txtSatuan2.Focus();
                    }
                    else if (Convert.ToDouble(txtQtySatuan3.Text) > 0 && txtSatuan3.Text == "")
                    {
                        psn.PesanInfo("Nama Satuan Tingkat 3 Masih Kosong");
                        txtSatuan3.Focus();
                    }
                    else if (Convert.ToDouble(txtQtySatuan4.Text) > 0 && txtSatuan4.Text == "")
                    {
                        psn.PesanInfo("Nama Satuan Tingkat 4 Masih Kosong");
                        txtSatuan4.Focus();
                    }
                    else if (Convert.ToDouble(txtQtySatuan5.Text) > 0 && txtSatuan5.Text == "")
                    {
                        psn.PesanInfo("Nama Satuan Tingkat 5 Masih Kosong");
                        txtSatuan5.Focus();
                    }
                    else if (Convert.ToDouble(txtQtySatuan2.Text) <= 0 && txtSatuan2.Text != "")
                    {
                        psn.PesanInfo("Qty Satuan Tingkat 2 Masih Kosong");
                        txtQtySatuan2.Focus();
                    }
                    else if (Convert.ToDouble(txtQtySatuan3.Text) <= 0 && txtSatuan3.Text != "")
                    {
                        psn.PesanInfo("Qty Satuan Tingkat 3 Masih Kosong");
                        txtQtySatuan3.Focus();
                    }
                    else if (Convert.ToDouble(txtQtySatuan4.Text) <= 0 && txtSatuan4.Text != "")
                    {
                        psn.PesanInfo("Qty Satuan Tingkat 4 Masih Kosong");
                        txtQtySatuan4.Focus();
                    }
                    else if (Convert.ToDouble(txtQtySatuan5.Text) <= 0 && txtSatuan5.Text != "")
                    {
                        psn.PesanInfo("Qty Satuan Tingkat 5 Masih Kosong");
                        txtQtySatuan5.Focus();
                    }
                    else
                    {
                        if (idUpdate == "")
                        {
                            Simpan();
                        }
                        else
                        {
                            if (updateData == true)
                            {
                                Simpan();
                            }
                            else
                            {
                                psn.PesanInfo("Anda Tidak Memiliki Hak Akses Untuk Melakukan Perubahan Data, Silahkan Kontak ke Admin");
                            }
                        }
                    }
                    break;
                case "HAPUS":
                    if (txtKodeBarcode.Text == "")
                    {
                        psn.PesanInfo("Kode Barcode Masih Kosong");
                    }
                    else
                    {
                        Hapus();
                    }
                    break;
                /*case "CETAK":
                    if (txtNama.Text.Trim() == "")
                    {
                        psn.PesanInfo("Nama Masih Kosong");
                        txtNama.Focus();
                    }
                    else
                    {
                        if (idUpdate == "")
                        {
                            Simpan();
                            Cetak(id);
                        }
                        else
                        {
                            if (updateData == true)
                            {
                                Simpan();
                                Cetak(id);
                            }
                            else
                            {
                                Cetak(id);
                            }
                        }
                    }

                    id = "";

                    break;*/
                case "KELUAR":
                    cls.OpenForm op = new cls.OpenForm(frmUtama);
                    op.PencarianOpen("Pencarian", "Barang", userName);
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
                case Keys.F3:
                    if (btnSimpan.Enabled == true)
                        SelectToolBar(btnSimpan);
                    break;
                case Keys.F4:
                    if (btnHapus.Enabled == true)
                        SelectToolBar(btnHapus);
                    break;
                /*case Keys.F12:
                    if (btnCetak.Enabled == true)
                        SelectToolBar(btnCetak);
                    break;*/
                case Keys.F10:
                    SelectToolBar(btnKeluar);
                    break;
                default:
                    break;
            }
        }

        private void TampilData(string barcode)
        {
            idUpdate = "";

            Clear(false);

            string data = qry.GetData(this, "TampilData", barcode, 1, "a.barcode,a.nama,b.id,b.nama,a.catatan," +
                "a.satuan1,a.satuan2,a.qtysatuan2,a.satuan3,a.qtysatuan3,a.satuan4,a.qtysatuan4,a.satuan5,a.qtysatuan5," +
                "a.stokmin,a.stokgudang,a.satuanstok,a.hargabeli,a.hargajual1,a.hargajual2,a.hargajual3,a.hargajual4," +
                "a.hargajual5,a.flag,a.stokrupiah", 
                "barang a inner join kategori b on a.idkategori = b.id", "a.barcode = '" + barcode + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    idUpdate = filldata[0]; //jika kosong berarti data baru, jika muncul id data lama -> cek status boleh update atau tidak
                    txtNama.Text = filldata[1];
                    cboKategori.Text = filldata[2] + "-" + filldata[3];
                    txtCatatan.Text = filldata[4];
                    txtSatuan1.Text = filldata[5];
                    txtSatuan2.Text = filldata[6];
                    txtQtySatuan2.Text = fs.FormatNumbCurr(filldata[7]);
                    txtSatuan3.Text = filldata[8];
                    txtQtySatuan3.Text = fs.FormatNumbCurr(filldata[9]);
                    txtSatuan4.Text = filldata[10];
                    txtQtySatuan4.Text = fs.FormatNumbCurr(filldata[11]);
                    txtSatuan5.Text = filldata[12];
                    txtQtySatuan5.Text = fs.FormatNumbCurr(filldata[13]);
                    txtStokMin.Text = fs.FormatNumbCurr(filldata[14]);
                    lblStokTersedia.Text = fs.FormatNumbCurr(filldata[15]);
                    cboSatuanStokMin.Text = filldata[16];
                    txtHargaBeli.Text = fs.FormatNumbCurr(filldata[17]);
                    txtHargaJual1.Text = fs.FormatNumbCurr(filldata[18]);
                    txtHargaJual2.Text = fs.FormatNumbCurr(filldata[19]);
                    txtHargaJual3.Text = fs.FormatNumbCurr(filldata[20]);
                    txtHargaJual4.Text = fs.FormatNumbCurr(filldata[21]);
                    txtHargaJual5.Text = fs.FormatNumbCurr(filldata[22]);
                    chkNonAktif.Checked = fs.IntToBool(filldata[23]);
                    lblStokRupiah.Text = fs.FormatNumbCurr(filldata[24]);

                    lblSatuan2.Text = txtSatuan1.Text;
                    lblSatuan3.Text = txtSatuan2.Text;
                    lblSatuan4.Text = txtSatuan3.Text;
                    lblSatuan5.Text = txtSatuan4.Text;

                    lblJualSatuan1.Text = txtSatuan1.Text;
                    lblJualSatuan2.Text = txtSatuan2.Text;
                    lblJualSatuan3.Text = txtSatuan3.Text;
                    lblJualSatuan4.Text = txtSatuan4.Text;
                    lblJualSatuan5.Text = txtSatuan5.Text;

                    qry.InsertLogAktivitas("TampilData", this, txtKodeBarcode.Text, userName);
                }
            }
        }

        private void TampilSatuanStokMin()
        {
            cboSatuanStokMin.Items.Clear();
            string[] list = { txtSatuan1.Text.Trim(), txtSatuan2.Text.Trim(), txtSatuan3.Text.Trim(), txtSatuan4.Text.Trim(), txtSatuan5.Text.Trim() };

            for(int i = 0; i < list.Length; i++)
            {
                if(list[i] != "")
                {
                    cboSatuanStokMin.Items.Add(list[i]);
                }
            }
        }

        private void SatuanBertingkat(TextBox txtUtama, TextBox txtUtama2, TextBox txtTujuan, TextBox txtTujuan2, TextBox txtSebelum, Label lblTujuan, 
            TextBox txtHargaJual, Label lblHargaJual)
        {
            if (txtUtama.Text.Trim() != "")
            {
                fs.EnaDisTextBoxArray(new TextBox[] { txtTujuan, txtTujuan2 }, "enable");
                lblTujuan.Text = txtUtama.Text.Trim();
                lblHargaJual.Text = txtUtama.Text.Trim();
                txtSebelum.Enabled = false;
                txtHargaJual.Enabled = true;
                TampilSatuanStokMin();
            }
            else if (txtUtama.Text.Trim() == "")
            {
                fs.EnaDisTextBoxArray(new TextBox[] { txtTujuan, txtTujuan2 }, "disable");
                txtTujuan2.Text = "0.00";
                lblTujuan.Text = "";
                txtHargaJual.Text = "0.00";
                lblHargaJual.Text = "";
                txtUtama2.Text = "0.00";
                txtSebelum.Enabled = true;
                txtHargaJual.Enabled = false;
                TampilSatuanStokMin();
            }
        }

        private void QtyBertingkat(TextBox txtSatuan, TextBox txtQty)
        {
            if(txtSatuan.Text == "")
            {
                txtQty.Text = "0.00";
            }
            else
            {
                txtQty.Text = fs.FormatNumbCurr(txtQty.Text);
            }
        }

        private void Simpan()
        {
            cboSatuanStokMin.Text = txtSatuan1.Text;

            if (qry.DataExist(this, "Simpan", txtKodeBarcode.Text.Trim(), txtNama.Text.Trim(), "barcode", "barang", "barcode = '" + txtKodeBarcode.Text.Trim() + "'"))
            {
                string[] cutString = cboKategori.Text.Split('-');

                try
                {
                    qry.UpdateData("barang",
                        "nama = '" + txtNama.Text.Trim() + "'," +
                        "idkategori = '" + cutString[0] + "'," +
                        "catatan = '" + txtCatatan.Text.Trim() + "'," +
                        "satuan1 = '" + txtSatuan1.Text.Trim() + "'," +
                        "satuan2 = '" + txtSatuan2.Text.Trim() + "'," +
                        "qtysatuan2 = " + fs.FNum(txtQtySatuan2.Text.Trim()) + "," +
                        "satuan3 = '" + txtSatuan3.Text.Trim() + "'," +
                        "qtysatuan3 = " + fs.FNum(txtQtySatuan3.Text.Trim()) + "," +
                        "satuan4 = '" + txtSatuan4.Text.Trim() + "'," +
                        "qtysatuan4 = " + fs.FNum(txtQtySatuan4.Text.Trim()) + "," +
                        "satuan5 = '" + txtSatuan5.Text.Trim() + "'," +
                        "qtysatuan5 = " + fs.FNum(txtQtySatuan5.Text.Trim()) + "," +
                        "stokmin = " + fs.FNum(txtStokMin.Text.Trim()) + "," +
                        "satuanstok = '" + cboSatuanStokMin.Text.Trim() + "'," +
                        "hargabeli = " + fs.FNum(txtHargaBeli.Text.Trim()) + "," +
                        "hargajual1 = " + fs.FNum(txtHargaJual1.Text.Trim()) + "," +
                        "hargajual2 = " + fs.FNum(txtHargaJual2.Text.Trim()) + "," +
                        "hargajual3 = " + fs.FNum(txtHargaJual3.Text.Trim()) + "," +
                        "hargajual4 = " + fs.FNum(txtHargaJual4.Text.Trim()) + "," +
                        "hargajual5 = " + fs.FNum(txtHargaJual5.Text.Trim()) + "," +
                        "flag = " + fs.BoolToInt(chkNonAktif.Checked) + "," +
                        "tglupdate = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'",
                        "barcode = '" + txtKodeBarcode.Text.Trim() + "'");

                    qry.InsertLogAktivitas("Update", this, txtKodeBarcode.Text.Trim(), userName);
                    fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Update " + this.Name.ToString() + " " + txtKodeBarcode.Text.Trim() + " " + txtNama.Text.Trim() + " Berhasil",
                        frmUtama.tooltip_x, frmUtama.tooltip_y, "info");
                    id = txtKodeBarcode.Text;
                    Clear(true);
                }
                catch (Exception ex)
                {
                    psn.CreateLogErrorForm(this, "Update", "Update " + txtKodeBarcode.Text.Trim() + " Gagal", ex.ToString());
                }
            }
            else
            {
                string[] cutString = cboKategori.Text.Split('-');

                try
                {
                    qry.InsertData("barang",
                        "barcode,nama,idkategori,catatan,satuan1,satuan2,qtysatuan2,satuan3,qtysatuan3,satuan4,qtysatuan4,satuan5,qtysatuan5," +
                        "stokmin,satuanstok,hargabeli,hargajual1,hargajual2,hargajual3,hargajual4,hargajual5,stokgudang,stokrupiah,flag,tglinput,tglupdate",
                        "'" + txtKodeBarcode.Text.Trim() + "','" + txtNama.Text.Trim() + "','" + cutString[0] + "'," +
                        "'" + txtCatatan.Text.Trim() + "','" + txtSatuan1.Text.Trim() + "','" + txtSatuan2.Text.Trim() + "'," +
                        "" + fs.FNum(txtQtySatuan2.Text) + ",'" + txtSatuan3.Text.Trim() + "'," + fs.FNum(txtQtySatuan3.Text) + "," +
                        "'" + txtSatuan4.Text.Trim() + "'," + fs.FNum(txtQtySatuan4.Text) + ",'" + txtSatuan5.Text.Trim() + "'," +
                        "" + fs.FNum(txtQtySatuan5.Text) + "," + fs.FNum(txtStokMin.Text) + ",'" + cboSatuanStokMin.Text + "'," +
                        "" + fs.FNum(txtHargaBeli.Text) + "," + fs.FNum(txtHargaJual1.Text) + "," + fs.FNum(txtHargaJual2.Text) + "," +
                        "" + fs.FNum(txtHargaJual3.Text) + "," + fs.FNum(txtHargaJual4.Text) + "," + fs.FNum(txtHargaJual5.Text) + ",0,0," +
                        "" + fs.BoolToInt(chkNonAktif.Checked) + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                        "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'");

                    qry.InsertLogAktivitas("Simpan", this, txtKodeBarcode.Text.Trim(), userName);
                    fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Simpan " + this.Name.ToString() + " " + txtKodeBarcode.Text.Trim() + " " + txtNama.Text.Trim() + " Berhasil",
                        frmUtama.tooltip_x, frmUtama.tooltip_y, "info");
                    id = txtKodeBarcode.Text;
                    Clear(true);
                }
                catch (Exception ex)
                {
                    psn.CreateLogErrorForm(this, "Simpan", "Simpan " + txtKodeBarcode.Text.Trim() + " Gagal", ex.ToString());
                }
            }
        }

        private void Hapus()
        {
            if (qry.DataExist(this, "Hapus", txtKodeBarcode.Text.Trim(), txtNama.Text.Trim(), "barcode", "pembelian_detail", "barcode = '" + txtKodeBarcode.Text.Trim() + "'"))
            {
                fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Data Barang " + txtKodeBarcode.Text.Trim() + " Telah Digunakan Untuk Transaksi",
                    frmUtama.tooltip_x, frmUtama.tooltip_y, "warning");
            }
            else
            {
                DialogResult result = MessageBox.Show("Hapus Data?", "Konfirmasi", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        qry.DeleteData("barang", "barcode = '" + txtKodeBarcode.Text.Trim() + "'");

                        qry.InsertLogAktivitas("Hapus", this, txtKodeBarcode.Text.Trim(), userName);
                        psn.CreateLogSuccessForm(this, "Hapus", txtKodeBarcode.Text.Trim());
                        fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Hapus " + txtKodeBarcode.Text.Trim() + " Berhasil", frmUtama.tooltip_x, frmUtama.tooltip_y, "info");

                        Clear(true);
                    }
                    catch (Exception e)
                    {
                        psn.CreateLogErrorForm(this, "Hapus", "Hapus " + txtKodeBarcode.Text.Trim() + " Gagal", e.ToString());
                    }
                }
            }
        }

        /*private void Cetak(string idtransaksi)
        {
            cls.OpenForm op = new cls.OpenForm(frmUtama);
            op.PencetakanDataOpen(this, "PencetakanData", idtransaksi, "", userName);
        }*/
        #endregion

        private void Barang_Load(object sender, EventArgs e)
        {
            qry.ComboBoxFill(this, cboKategori, "Clear", "concat(id,'-',nama)", "kategori");
            fs.FillLabelArray(new Label[] { lblSatuan2, lblSatuan3, lblSatuan4, lblSatuan5, lblJualSatuan1, lblJualSatuan2, lblJualSatuan3, lblJualSatuan4, lblJualSatuan5 }, "");

            if (id != "")
                txtKodeBarcode.Text = id;

            frmUtama.lblNamaForm.Text = "- Barang";
            UsrAccess();

            /*if (qry.DataExist(this, "Barang_Load", txtKodeBarcode.Text.Trim(), txtNama.Text.Trim(), "barcode", "pembelian_detail", "barcode = '" + txtKodeBarcode.Text.Trim() + "'"))
            {
                fs.EnaDisTextBoxArray(new TextBox[] { txtSatuan1, txtSatuan2, txtQtySatuan2, txtSatuan3, txtQtySatuan3, txtSatuan4, txtQtySatuan4, txtSatuan5 }, "disable");
            }*/
        }

        private void Barang_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.BlockChar(e);
        }

        private void txtKodeBarcode_TextChanged(object sender, EventArgs e)
        {
            TampilData(txtKodeBarcode.Text);
        }

        private void txtSatuan1_TextChanged(object sender, EventArgs e)
        {
            if(txtSatuan1.Text.Trim() != "")
            {
                fs.EnaDisTextBoxArray(new TextBox[] { txtSatuan2, txtQtySatuan2 }, "enable");
                lblSatuan2.Text = txtSatuan1.Text.Trim();
                lblJualSatuan1.Text = txtSatuan1.Text.Trim();
                TampilSatuanStokMin();
            }
            else if(txtSatuan1.Text.Trim() == "")
            {
                fs.EnaDisTextBoxArray(new TextBox[] { txtSatuan2, txtQtySatuan2 }, "disable");
                txtQtySatuan2.Text = "0.00";
                lblSatuan2.Text = "";
                txtHargaJual1.Text = "0.00";
                lblJualSatuan1.Text = "";
                TampilSatuanStokMin();
            }
        }

        private void txtSatuan1_Leave(object sender, EventArgs e)
        {
            if (txtSatuan1.Text.Trim() != "")
            {
                fs.EnaDisTextBoxArray(new TextBox[] { txtSatuan2, txtQtySatuan2 }, "enable");
                lblSatuan2.Text = txtSatuan1.Text.Trim();
                lblJualSatuan1.Text = txtSatuan1.Text.Trim();
                TampilSatuanStokMin();
            }
            else if (txtSatuan1.Text.Trim() == "")
            {
                fs.EnaDisTextBoxArray(new TextBox[] { txtSatuan2, txtQtySatuan2 }, "disable");
                txtQtySatuan2.Text = "0.00";
                lblSatuan2.Text = "";
                txtHargaJual1.Text = "0.00";
                lblJualSatuan1.Text = "";
                TampilSatuanStokMin();
            }
        }

        private void txtSatuan2_TextChanged(object sender, EventArgs e)
        {
            SatuanBertingkat(txtSatuan2, txtQtySatuan2, txtSatuan3, txtQtySatuan3, txtSatuan1, lblSatuan3, txtHargaJual2, lblJualSatuan2);
        }

        private void txtSatuan2_Leave(object sender, EventArgs e)
        {
            SatuanBertingkat(txtSatuan2, txtQtySatuan2, txtSatuan3, txtQtySatuan3, txtSatuan1, lblSatuan3, txtHargaJual2, lblJualSatuan2);
        }

        private void txtSatuan3_TextChanged(object sender, EventArgs e)
        {
            SatuanBertingkat(txtSatuan3, txtQtySatuan3, txtSatuan4, txtQtySatuan4, txtSatuan2, lblSatuan4, txtHargaJual3, lblJualSatuan3);
        }

        private void txtSatuan3_Leave(object sender, EventArgs e)
        {
            SatuanBertingkat(txtSatuan3, txtQtySatuan3, txtSatuan4, txtQtySatuan4, txtSatuan2, lblSatuan4, txtHargaJual3, lblJualSatuan3);
        }

        private void txtSatuan4_TextChanged(object sender, EventArgs e)
        {
            SatuanBertingkat(txtSatuan4, txtQtySatuan4, txtSatuan5, txtQtySatuan5, txtSatuan3, lblSatuan5, txtHargaJual4, lblJualSatuan4);
        }

        private void txtSatuan4_Leave(object sender, EventArgs e)
        {
            SatuanBertingkat(txtSatuan4, txtQtySatuan4, txtSatuan5, txtQtySatuan5, txtSatuan3, lblSatuan5, txtHargaJual4, lblJualSatuan4);
        }

        private void txtSatuan5_TextChanged(object sender, EventArgs e)
        {
            if(txtSatuan5.Text.Trim() != "")
            {
                fs.EnaDisTextBoxArray(new TextBox[] { txtSatuan4, txtHargaJual5 }, "disable");
                lblJualSatuan5.Text = txtSatuan5.Text.Trim();
                txtHargaJual5.Enabled = true;
                TampilSatuanStokMin();
            }
            else if (txtSatuan5.Text.Trim() == "")
            {
                txtHargaJual5.Text = "0.00";
                lblJualSatuan5.Text = "";
                txtQtySatuan5.Text = "0.00";
                txtSatuan4.Enabled = true;
                txtHargaJual5.Enabled = false;
                TampilSatuanStokMin();
            }
        }

        private void txtSatuan5_Leave(object sender, EventArgs e)
        {
            if(txtSatuan5.Text.Trim() != "")
            {
                fs.EnaDisTextBoxArray(new TextBox[] { txtSatuan4, txtHargaJual5 }, "disable");
                lblJualSatuan5.Text = txtSatuan5.Text.Trim();
                txtHargaJual5.Enabled = true;
                TampilSatuanStokMin();
            }
            else if (txtSatuan5.Text.Trim() == "")
            {
                txtHargaJual5.Text = "0.00";
                lblJualSatuan5.Text = "";
                txtQtySatuan5.Text = "0.00";
                txtSatuan4.Enabled = true;
                txtHargaJual5.Enabled = false;
                TampilSatuanStokMin();
            }
        }

        private void txtQtySatuan2_Leave(object sender, EventArgs e)
        {
            QtyBertingkat(txtSatuan2, txtQtySatuan2);
        }

        private void txtQtySatuan3_Leave(object sender, EventArgs e)
        {
            QtyBertingkat(txtSatuan3, txtQtySatuan3);
        }

        private void txtQtySatuan4_Leave(object sender, EventArgs e)
        {
            QtyBertingkat(txtSatuan4, txtQtySatuan4);
        }

        private void txtQtySatuan5_Leave(object sender, EventArgs e)
        {
            QtyBertingkat(txtSatuan5, txtQtySatuan5);
        }

        private void txtStokMin_Leave(object sender, EventArgs e)
        {
            fs.TextLeave(txtStokMin);
        }

        private void cboSatuanStokMin_Click(object sender, EventArgs e)
        {
            //TampilSatuanStokMin();
        }

        private void cboSatuanStokMin_Enter(object sender, EventArgs e)
        {
            //TampilSatuanStokMin();
        }

        private void txtHargaBeli_Leave(object sender, EventArgs e)
        {
            fs.TextLeave(txtHargaBeli);
        }

        private void txtHargaJual1_Leave(object sender, EventArgs e)
        {
            fs.TextLeave(txtHargaJual1);
        }

        private void txtHargaJual2_Leave(object sender, EventArgs e)
        {
            fs.TextLeave(txtHargaJual2);
        }

        private void txtHargaJual3_Leave(object sender, EventArgs e)
        {
            fs.TextLeave(txtHargaJual3);
        }

        private void txtHargaJual4_Leave(object sender, EventArgs e)
        {
            fs.TextLeave(txtHargaJual4);
        }

        private void txtHargaJual5_Leave(object sender, EventArgs e)
        {
            fs.TextLeave(txtHargaJual5);
        }

        private void btnBaru_Click(object sender, EventArgs e)
        {
            SelectToolBar(btnBaru);
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            SelectToolBar(btnSimpan);
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            SelectToolBar(btnHapus);
        }

        private void btnCetak_Click(object sender, EventArgs e)
        {
            SelectToolBar(btnCetak);
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            SelectToolBar(btnKeluar);
        }

        private void txtQtySatuan2_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.InputNumber(e);
        }

        private void txtQtySatuan3_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.InputNumber(e);
        }

        private void txtQtySatuan4_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.InputNumber(e);
        }

        private void txtQtySatuan5_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.InputNumber(e);
        }

        private void txtStokMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.InputNumber(e);
        }

        private void txtHargaBeli_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.InputNumber(e);
        }

        private void txtHargaJual1_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.InputNumber(e);
        }

        private void txtHargaJual2_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.InputNumber(e);
        }

        private void txtHargaJual3_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.InputNumber(e);
        }

        private void txtHargaJual4_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.InputNumber(e);
        }

        private void txtHargaJual5_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.InputNumber(e);
        }
    }
}
