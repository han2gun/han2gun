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
    public partial class Diskon : Form
    {
        cls.Fungsi fs = new cls.Fungsi();
        cls.Pesan psn = new cls.Pesan();
        cls.Query qry = new cls.Query();

        MenuUtama frmUtama;
        public string userName;
        public string id;
        string idUpdate;
        bool updateData;
        string tglinput;

        public static string barcode;

        //variabel cell
        int cellhapus;
        int cellbarcode;
        int cellnama;
        int celldiscpersen;
        int celldiscrupiah;

        string namabarang;
        bool detailDelete;
        DataGridViewRow row;

        public Diskon(MenuUtama mnutama)
        {
            InitializeComponent();

            frmUtama = mnutama;
            idUpdate = "";
            updateData = false;
            cellhapus = 0;
            cellbarcode = 1;
            cellnama = 2;
            celldiscpersen = 3;
            celldiscrupiah = 4;
            detailDelete = true;
            namabarang = "";
            fs.BoldHeaderDataGridView(dgTransaksi);
            this.KeyDown += new KeyEventHandler(this.OnKeyDown);
            ActiveControl = txtNamaDisc;
        }

        #region code
        private void UsrAccess()
       {
           string data = qry.GetData(this, "UsrAccess", userName, 0,
               "diskonsv,diskondel,diskonprt,diskonup", "usrmgmt", "usrname = '" + userName + "'");

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

                   qry.InsertLogAktivitas("UsrAccess", this, userName, userName);
               }
           }
       }

        private void Clear()
        {
            fs.FillTextBoxArray(new TextBox[] { txtNamaDisc, txtCatatan, txtKodeBarcode }, "");
            dtTglMulai.Value = DateTime.Today;
            dtTglSelesai.Value = DateTime.Today;
            tglinput = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dgTransaksi.Rows.Clear();
            lblID.Text = "AUTO ID";
            rbBarcode.Checked = true;
            txtDiskonList.Text = "0.00";
            txtNamaDisc.Focus();
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
                        Clear();
                    }
                    break;
                case "SIMPAN":
                    if (txtNamaDisc.Text.Trim() == "")
                    {
                        psn.PesanInfo("Nama Diskon Masih Kosong");
                        txtNamaDisc.Focus();
                    }
                    else if(dtTglSelesai.Value < dtTglMulai.Value)
                    {
                        psn.PesanInfo("Tanggal Selesai tidak boleh lebih kecil dari Tanggal Mulai");
                        dtTglSelesai.Focus();
                    }
                    else if (dgTransaksi.Rows.Count <= 0)
                    {
                        psn.PesanInfo("Detail Transaksi Masih Kosong");
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
                    if (lblID.Text == "AUTO ID")
                    {
                        psn.PesanInfo("ID Diskon Masih Kosong");
                    }
                    else
                    {
                        Hapus();
                    }
                    break;
                case "CETAK":
                    if (txtNamaDisc.Text.Trim() == "")
                    {
                        psn.PesanInfo("Nama Diskon Masih Kosong");
                        txtNamaDisc.Focus();
                    }
                    else if (dtTglSelesai.Value < dtTglMulai.Value)
                    {
                        psn.PesanInfo("Tanggal Selesai tidak boleh lebih kecil dari Tanggal Mulai");
                        dtTglSelesai.Focus();
                    }
                    else if (dgTransaksi.Rows.Count <= 0)
                    {
                        psn.PesanInfo("Detail Transaksi Masih Kosong");
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

                    break;
                case "KELUAR":
                    cls.OpenForm op = new cls.OpenForm(frmUtama);
                    op.PencarianOpen("Pencarian", "Diskon", userName);
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

        private void TampilData(string id)
        {
            idUpdate = "";

            string data = qry.GetData(this, "TampilData", id, 13, "id,aktif,nama,tglmulai,tglselesai,catatan,tglinput",
                "diskon", "id = '" + id + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    idUpdate = filldata[0]; //jika kosong berarti data baru, jika muncul id data lama -> cek status boleh update atau tidak
                    chkAktif.Checked = fs.IntToBool(filldata[1]);
                    txtNamaDisc.Text = filldata[2];
                    dtTglMulai.Value = Convert.ToDateTime(filldata[3]);
                    dtTglSelesai.Value = Convert.ToDateTime(filldata[4]);
                    txtCatatan.Text = filldata[5];
                    tglinput = DateTime.Parse(filldata[6]).ToString("yyyy-MM-dd HH:mm:ss");

                    TampilDetailData(id);

                    qry.InsertLogAktivitas("TampilData", this, lblID.Text, userName);
                }
            }
        }

        private void TampilDetailData(string id)
        {
            qry.DataGridViewFill(this, dgTransaksi, "TampilDetailData", "a.id,a.barcode,b.nama,a.discpersen,a.discrp",
                "diskon_detail a inner join barang b on a.barcode = b.barcode", "a.id = '" + id + "'");

            int row = qry.ds.Tables["detail"].Rows.Count - 1;

            if (row >= 0)
            {
                for (int i = 0; i <= row; i++)
                {
                    dgTransaksi.Rows.Add();
                    dgTransaksi.Rows[i].Cells[cellhapus].Value = "X";
                    dgTransaksi.Rows[i].Cells[cellbarcode].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[1];
                    dgTransaksi.Rows[i].Cells[cellnama].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[2];
                    dgTransaksi.Rows[i].Cells[celldiscpersen].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[3].ToString());
                    dgTransaksi.Rows[i].Cells[celldiscrupiah].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[4].ToString());
                }

                dgTransaksi.AutoResizeColumns();
                qry.InsertLogAktivitas("TampilDetailData", this, lblID.Text, userName);
            }
        }

        private void TampilBarang(string barcode)
        {
            string data = qry.GetData(this, "TampilBarang", id, 8, "barcode,nama,satuan1", "barang", "barcode = '" + barcode + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    namabarang = filldata[1];

                    qry.InsertLogAktivitas("TampilBarang", this, txtKodeBarcode.Text, userName);
                }
            }
        }

        private void TampilSemuaBarang()
        {
            qry.DataGridViewFill(this, dgTransaksi, "TampilSemuaBarang", "barcode,nama",
                "barang", "barcode != ''");

            int row = qry.ds.Tables["detail"].Rows.Count - 1;

            if (row >= 0)
            {
                for (int i = 0; i <= row; i++)
                {
                    dgTransaksi.Rows.Add();
                    dgTransaksi.Rows[i].Cells[cellhapus].Value = "X";
                    dgTransaksi.Rows[i].Cells[cellbarcode].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[0];
                    dgTransaksi.Rows[i].Cells[cellnama].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[1];
                    dgTransaksi.Rows[i].Cells[celldiscpersen].Value = "0.00";
                    dgTransaksi.Rows[i].Cells[celldiscrupiah].Value = "0.00";
                }

                dgTransaksi.AutoResizeColumns();
                qry.InsertLogAktivitas("TampilSemuaBarang", this, lblID.Text, userName);
            }
        }

        private void TampilSemuaKategori()
        {
            string[] cutString = cboKategori.Text.Split('-');

            qry.DataGridViewFill(this, dgTransaksi, "TampilSemuaKategori", "barcode,nama",
                "barang", "idkategori = '" + cutString[0] + "'");

            int row = qry.ds.Tables["detail"].Rows.Count - 1;

            if (row >= 0)
            {
                for (int i = 0; i <= row; i++)
                {
                    dgTransaksi.Rows.Add();
                    dgTransaksi.Rows[i].Cells[cellhapus].Value = "X";
                    dgTransaksi.Rows[i].Cells[cellbarcode].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[0];
                    dgTransaksi.Rows[i].Cells[cellnama].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[1];
                    dgTransaksi.Rows[i].Cells[celldiscpersen].Value = "0.00";
                    dgTransaksi.Rows[i].Cells[celldiscrupiah].Value = "0.00";
                }

                dgTransaksi.AutoResizeColumns();
                qry.InsertLogAktivitas("TampilSemuaKategori", this, lblID.Text, userName);
            }
        }

        //ada cek barang yang tanggal dan aktif diskon nya bersamaan - jadi tidak bisa masuk
        private bool CekDataDBKembar(string barcode)
        {
            bool dataada = false;
            string hasil;

            string data = qry.GetData(this, "CekDataDBKembar", id, 13, "b.id",
                "diskon a inner join diskon_detail b on a.id = b.id", 
                "b.barcode = '" + barcode + "' and a.aktif = 1 " +
                "and a.tglselesai >= '" + dtTglMulai.Value.ToString("yyyy-MM-dd") + "' and a.tglmulai <= '" + dtTglSelesai.Value.ToString("yyyy-MM-dd") + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    hasil = filldata[0];

                    if(hasil != "")
                    {
                        dataada = true;
                    }
                    else
                    {
                        dataada = false;
                    }

                    qry.InsertLogAktivitas("CekDataDBKembar", this, lblID.Text, userName);
                }
            }

            return dataada;
        }

        //ada cek untuk barang yang sama yang sudah ada di list
        private bool CekDataListKembar()
        {
            bool dataada = false;

            for(int i = 0; i < dgTransaksi.Rows.Count; i++)
            {
                if(dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString() == txtKodeBarcode.Text.Trim())
                {
                    dataada = true;
                }
            }

            return dataada;
        }

        private void InsertDataGrid()
        {
            if(namabarang != "")
            {
                if (CekDataListKembar())
                {
                    psn.PesanInfo("Barang Sudah Ada di List");
                    txtKodeBarcode.Focus();
                }
                else if (CekDataDBKembar(txtKodeBarcode.Text.Trim()))
                {
                    psn.PesanInfo("Barang Sudah Digunakan di Daftar Diskon Lainnya");
                    txtKodeBarcode.Focus();
                }
                else
                {
                    dgTransaksi.Rows.Add("X", txtKodeBarcode.Text.Trim(), namabarang, "0.00", "0.00");
                }
            }         
        }

        private void Simpan()
        {
            try
            {
                qry.DeleteData("diskon", "id = '" + lblID.Text + "'");
                qry.DeleteData("diskon_detail", "id = '" + lblID.Text + "'");

                if (lblID.Text == "AUTO ID")
                {
                    lblID.Text = qry.CreateID(this, "Simpan", "id", "diskon", "id like 'DS." + dtTglMulai.Value.ToString("MMyyyy") + ".%'",
                        "DS." + dtTglMulai.Value.ToString("MMyyyy") + ".", "transaksi");
                }

                qry.InsertData("diskon", "id,aktif,nama,tglmulai,tglselesai,catatan,tglinput,tglupdate",
                    "'" + lblID.Text + "'," +
                    "" + fs.BoolToInt(chkAktif.Checked) + "," +
                    "'" + txtNamaDisc.Text.Trim() + "'," +
                    "'" + string.Format("{0:yyyy-MM-dd}", dtTglMulai.Value) + "'," +
                    "'" + string.Format("{0:yyyy-MM-dd}", dtTglSelesai.Value) + "'," +
                    "'" + txtCatatan.Text.Trim() + "'," +
                    "'" + tglinput + "'," +
                    "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'");

                for (int i = 0; i < dgTransaksi.Rows.Count; i++)
                {
                    string barcode = dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString();
                    string discpersen = dgTransaksi.Rows[i].Cells[celldiscpersen].Value.ToString();
                    string discrupiah = dgTransaksi.Rows[i].Cells[celldiscrupiah].Value.ToString();

                    if (barcode != "")
                    {
                        qry.InsertData("diskon_detail", "id,barcode,discpersen,discrp",
                            "'" + lblID.Text + "'," +
                            "'" + barcode + "'," +
                            "" + fs.FNum(discpersen) + "," +
                            "" + fs.FNum(discrupiah) + "");
                    }
                }

                qry.InsertLogAktivitas("Simpan", this, lblID.Text, userName);
                fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Simpan " + this.Name.ToString() + " " + lblID.Text + " Berhasil",
                        frmUtama.tooltip_x, frmUtama.tooltip_y, "info");
                id = lblID.Text;
                Clear();
            }
            catch (Exception ex)
            {
                psn.CreateLogErrorForm(this, "Simpan", "Simpan " + lblID.Text + " Gagal", ex.ToString());
            }
        }

        private void Hapus()
        {
            /*if (qry.DataExist(this, "Hapus", lblID.Text, txtNama.Text.Trim(), "idkaryawan", "daftarmuatan", "idkaryawan = '" + lblID.Text + "'") ||
                qry.DataExist(this, "Hapus", lblID.Text, txtNama.Text.Trim(), "idkernet", "daftarmuatan", "idkernet = '" + lblID.Text + "'"))
            {
                fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Data " + lblID.Text + " Telah Digunakan Untuk Transaksi",
                    frmUtama.tooltip_x, frmUtama.tooltip_y, "warning");
            }
            else
            {*/
                DialogResult result = MessageBox.Show("Hapus Data?", "Konfirmasi", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        qry.DeleteData("diskon", "id = '" + lblID.Text + "'");
                        qry.DeleteData("diskon_detail", "id = '" + lblID.Text + "'");

                        qry.InsertLogAktivitas("Hapus", this, lblID.Text, userName);
                        psn.CreateLogSuccessForm(this, "Hapus", lblID.Text);
                        fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Hapus " + lblID.Text + " Berhasil", frmUtama.tooltip_x, frmUtama.tooltip_y, "info");

                        Clear();
                    }
                    catch (Exception e)
                    {
                        psn.CreateLogErrorForm(this, "Hapus", "Hapus " + lblID.Text + " Gagal", e.ToString());
                    }
                }
            //}
        }

        private void Cetak(string idtransaksi)
        {
            cls.OpenForm op = new cls.OpenForm(frmUtama);
            op.PreviewCetakOpen(this, "PreviewCetakData", idtransaksi, "", userName);
        }
        #endregion

        private void Diskon_Load(object sender, EventArgs e)
        {
            qry.ComboBoxFill(this, cboKategori, "Clear", "concat(id,'-',nama)", "kategori");
            tglinput = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            rbBarcode.Checked = true;

            if (id != "")
                lblID.Text = id;

            frmUtama.lblNamaForm.Text = "- Diskon";
            UsrAccess();
        }

        private void Diskon_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.BlockChar(e);
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

        private void brnCariBarang_Click(object sender, EventArgs e)
        {
            cls.OpenForm op = new cls.OpenForm(frmUtama);
            op.ListOpen("List", "Diskon-Barang", "Barang", "", userName);

            txtKodeBarcode.Text = barcode;
            barcode = "";
            txtKodeBarcode.Focus();
        }

        private void brnCariBarang_Leave(object sender, EventArgs e)
        {
            dgTransaksi.Focus();
        }

        private void txtKodeBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                TampilBarang(txtKodeBarcode.Text);
                InsertDataGrid();
                namabarang = "";
                txtKodeBarcode.Text = "";
            }
        }

        private void txtKodeBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                brnCariBarang_Click(sender, e);
            }
        }

        private void txtCatatan_Leave(object sender, EventArgs e)
        {
            txtKodeBarcode.Focus();
        }

        private void dgTransaksi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgTransaksi.Columns["clHapus"].Index && e.RowIndex >= 0)
            {
                row = dgTransaksi.Rows[e.RowIndex];

                if (lblID.Text != "AUTO ID" && detailDelete == false)
                {
                    psn.PesanInfo("Anda Tidak Memiliki Hak Akses Untuk Menghapus Data, Silahkan Kontak ke Admin");
                }
                else if (dgTransaksi.Rows[e.RowIndex].Cells[cellbarcode].Value.ToString() != "")
                {
                    DialogResult result = MessageBox.Show("Apakah Data Ingin Dihapus?", "Konfirmasi", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        dgTransaksi.Rows.Remove(row);

                        qry.InsertLogAktivitas("dgTransaksi_CellClick", this, row.Cells[cellbarcode].Value.ToString(), userName);
                        psn.CreateLogSuccessForm(this, "dgTransaksi_CellClick", row.Cells[cellbarcode].Value.ToString());
                        fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Hapus Kode Barang " + row.Cells[cellbarcode].Value.ToString() + " dari Diskon Berhasil",
                                frmUtama.tooltip_x, frmUtama.tooltip_y, "info");
                    }
                }
            }
        }

        private void dgTransaksi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgTransaksi.CurrentCell.ColumnIndex == celldiscpersen || dgTransaksi.CurrentCell.ColumnIndex == celldiscrupiah)
            {
                char ch = e.KeyChar;
                if (!char.IsDigit(ch) && ch != 8 && ch != 46)
                {
                    e.Handled = true;
                }
            }
        }

        private void dgTransaksi_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(dgTransaksi_KeyPress);
            e.Control.KeyPress += new KeyPressEventHandler(dgTransaksi_KeyPress);
        }

        private void dgTransaksi_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            row = dgTransaksi.Rows[e.RowIndex];

            if ((dgTransaksi.Focused) && (dgTransaksi.CurrentCell.ColumnIndex == celldiscpersen))
            {
                if (Convert.ToString(dgTransaksi.CurrentCell.Value) == "")
                {
                    dgTransaksi.CurrentCell.Value = "0.00";
                }
                else if (Convert.ToDouble(dgTransaksi.CurrentCell.Value) > 0)
                {
                    row.Cells[celldiscrupiah].Value = "0.00";
                }

                dgTransaksi.CurrentCell.Value = fs.FormatNumbCurr(Convert.ToString(dgTransaksi.CurrentCell.Value));
            }
            else if ((dgTransaksi.Focused) && (dgTransaksi.CurrentCell.ColumnIndex == celldiscrupiah))
            {
                if (Convert.ToString(dgTransaksi.CurrentCell.Value) == "")
                {
                    dgTransaksi.CurrentCell.Value = "0.00";
                }
                else if (Convert.ToDouble(dgTransaksi.CurrentCell.Value) > 0)
                {
                    row.Cells[celldiscpersen].Value = "0.00";
                }

                dgTransaksi.CurrentCell.Value = fs.FormatNumbCurr(Convert.ToString(dgTransaksi.CurrentCell.Value));
            }

        }

        private void dgTransaksi_Leave(object sender, EventArgs e)
        {
            btnSimpan.Focus();
        }

        private void lblID_TextChanged(object sender, EventArgs e)
        {
            TampilData(lblID.Text);
        }

        private void btnTerapkan_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgTransaksi.Rows.Count; i++)
            {
                dgTransaksi.Rows[i].Cells[celldiscpersen].Value = txtDiskonList.Text.Trim();
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if(rbBarcode.Checked == true)
            {
                TampilBarang(txtKodeBarcode.Text);
                InsertDataGrid();
                namabarang = "";
                txtKodeBarcode.Text = "";
                txtKodeBarcode.Focus();
            }
            else
            {
                if (dgTransaksi.Rows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Daftar List Tidak Kosong Apakah Anda Yakin Ingin Mengganti Isi Diskon?", "Konfirmasi", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (result == DialogResult.Yes)
                    {
                        dgTransaksi.Rows.Clear();

                        if (rbSemuaBarang.Checked == true)
                        {
                            TampilSemuaBarang();
                        }
                        else if(rbKategori.Checked == true)
                        {
                            if (cboKategori.Text == "")
                            {
                                psn.PesanInfo("Kategori Masih Kosong!");
                                cboKategori.Focus();
                            }
                            else
                            {
                                TampilSemuaKategori();
                            }
                        }
                    }
                }
                else
                {
                    if (rbSemuaBarang.Checked == true)
                    {
                        TampilSemuaBarang();
                    }
                    else if (rbKategori.Checked == true)
                    {
                        if(cboKategori.Text == "")
                        {
                            psn.PesanInfo("Kategori Masih Kosong!");
                            cboKategori.Focus();
                        }
                        else
                        {
                            TampilSemuaKategori();
                        }
                    }
                }
            }
        }

        private void txtDiskonList_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.InputNumber(e);
        }

        private void txtDiskonList_Leave(object sender, EventArgs e)
        {
            fs.TextLeave(txtDiskonList);
        }
    }
}
