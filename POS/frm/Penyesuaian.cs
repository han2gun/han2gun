using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace POS.frm
{
    public partial class Penyesuaian : Form
    {
        cls.Fungsi fs = new cls.Fungsi();
        cls.Pesan psn = new cls.Pesan();
        cls.Query qry = new cls.Query();
        cls.Koneksi kon = new cls.Koneksi();

        MenuUtama frmUtama;
        public string userName;
        public string id;
        string idUpdate;
        bool updateData;
        double tempDiskon;
        double tempDiskonRow;
        string tglinput;

        public static string barcode;

        //variabel cell
        int cellhapus;
        int cellbarcode;
        int cellnama;
        int cellstok;
        int cellnilaistok;
        int cellpenyesuaian;
        int cellselisih;
        int cellsatuan;
        int cellnilaibarang;
        int cellsubtotal;

        string namabarang;
        string satuan;
        string hpp;

        bool detailDelete;
        DataGridViewRow row;

        public Penyesuaian(MenuUtama mnutama)
        {
            InitializeComponent();
            frmUtama = mnutama;
            idUpdate = "";
            updateData = false;
            cellhapus = 0;
            cellbarcode = 1;
            cellnama = 2;
            cellstok = 3;
            cellnilaistok = 4;
            cellpenyesuaian = 5;
            cellselisih = 6;
            cellsatuan = 7;
            cellnilaibarang = 8;
            cellsubtotal = 9;
            namabarang = "";
            detailDelete = true;
            fs.BoldHeaderDataGridView(dgTransaksi);
            //this.KeyDown += new KeyEventHandler(this.OnKeyDown);
            ActiveControl = txtKodeBarcode;
        }

        #region code
        private void UsrAccess()
        {
            string data = qry.GetData(this, "UsrAccess", userName, 0,
                "penyesuaiansv,penyesuaiandel,penyesuaianprt,penyesuaianup", "usrmgmt", "usrname = '" + userName + "'");

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
            fs.FillTextBoxArray(new TextBox[] { txtCatatan, txtKodeBarcode }, "");
            dtTglTransaksi.Value = DateTime.Today;
            tglinput = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dgTransaksi.Rows.Clear();
            lblID.Text = "AUTO ID";
            txtKodeBarcode.Focus();
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
                    if (dgTransaksi.Rows.Count <= 0)
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
                        psn.PesanInfo("ID Penyesuaian Masih Kosong");
                    }
                    else
                    {
                        Hapus();
                    }
                    break;
                case "CETAK":
                    if (dgTransaksi.Rows.Count <= 0)
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
                    op.PencarianOpen("Pencarian", "Penyesuaian", userName);
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
                case Keys.F12:
                    if (btnCetak.Enabled == true)
                        SelectToolBar(btnCetak);
                    break;
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

            string data = qry.GetData(this, "TampilData", id, 13, "id,tgltransaksi,catatan,tglinput",
                "penyesuaian", "id = '" + id + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    idUpdate = filldata[0]; //jika kosong berarti data baru, jika muncul id data lama -> cek status boleh update atau tidak
                    dtTglTransaksi.Value = Convert.ToDateTime(filldata[1]);
                    txtCatatan.Text = filldata[2];
                    tglinput = DateTime.Parse(filldata[3]).ToString("yyyy-MM-dd HH:mm:ss");

                    TampilDetailData(id);

                    qry.InsertLogAktivitas("TampilData", this, lblID.Text, userName);
                }
            }
        }

        private void TampilDetailData(string id)
        {
            qry.DataGridViewFill(this, dgTransaksi, "TampilDetailData", "id,barcode,nama,stok,nilaistok,qtypenyesuaian,qtyselisih,satuan,nilaiqty,subtotal",
                "penyesuaian_detail", "id = '" + id + "'");

            int row = qry.ds.Tables["detail"].Rows.Count - 1;

            if (row >= 0)
            {
                for (int i = 0; i <= row; i++)
                {
                    dgTransaksi.Rows.Add();
                    dgTransaksi.Rows[i].Cells[cellhapus].Value = "X";
                    dgTransaksi.Rows[i].Cells[cellbarcode].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[1];
                    dgTransaksi.Rows[i].Cells[cellnama].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[2];
                    dgTransaksi.Rows[i].Cells[cellstok].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[3].ToString());
                    dgTransaksi.Rows[i].Cells[cellnilaistok].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[4].ToString());
                    dgTransaksi.Rows[i].Cells[cellpenyesuaian].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[5].ToString());
                    dgTransaksi.Rows[i].Cells[cellselisih].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[6].ToString());
                    dgTransaksi.Rows[i].Cells[cellsatuan].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[7];
                    dgTransaksi.Rows[i].Cells[cellnilaibarang].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[8].ToString());
                    dgTransaksi.Rows[i].Cells[cellsubtotal].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[9].ToString());
                }

                dgTransaksi.AutoResizeColumns();
                qry.InsertLogAktivitas("TampilDetailData", this, lblID.Text, userName);
            }
        }

        private void TampilBarang(string barcode)
        {
            string data = qry.GetData(this, "TampilBarang", id, 8, "barcode,nama,satuan1",
                "barang", "barcode = '" + barcode + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    namabarang = filldata[1];
                    satuan = filldata[2];

                    qry.InsertLogAktivitas("TampilBarang", this, txtKodeBarcode.Text, userName);
                }
            }
        }

        private void InsertDataGrid()
        {
            bool match = true;

            if (namabarang != "")
            {
                int row = dgTransaksi.Rows.Count - 1;

                if (row >= 0)
                {
                    for (int i = 0; i <= row; i++)
                    {
                        if (dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString() == txtKodeBarcode.Text.Trim())
                        {
                            psn.PesanInfo("Barang Sudah Ada di Dalam List");
                            txtKodeBarcode.Focus();
                            
                            match = true;
                            break;
                        }
                        else
                        {
                            match = false;
                        }
                    }

                    if (match == false)
                    {
                        dgTransaksi.Rows.Add("X", txtKodeBarcode.Text.Trim(), namabarang, fs.FormatNumbCurr(HitungStok(txtKodeBarcode.Text.Trim()).ToString()),
                            fs.FormatNumbCurr(HitungSaldo(txtKodeBarcode.Text.Trim()).ToString()), "0.00", "0.00", satuan, "0.00", "0.00");
                        //dgTransaksi.AutoResizeColumns();
                    }
                }
                else
                {
                    dgTransaksi.Rows.Add("X", txtKodeBarcode.Text.Trim(), namabarang, fs.FormatNumbCurr(HitungStok(txtKodeBarcode.Text.Trim()).ToString()),
                            fs.FormatNumbCurr(HitungSaldo(txtKodeBarcode.Text.Trim()).ToString()), "0.00", "0.00", satuan, "0.00", "0.00"); ;
                    //dgTransaksi.AutoResizeColumns();
                }
            }
        }

        private double HitungStok(string barcode)
        {
            double stok = 0;
            try
            {
                kon.OpenConn();
                kon.cmd = new MySqlCommand("call stokGudang('" + barcode + "','" + dtTglTransaksi.Value.ToString("yyyy-MM-dd") + "')", kon.con);
                kon.cmd.ExecuteNonQuery();
                kon.rd = kon.cmd.ExecuteReader();
                while (kon.rd.Read())
                {
                    stok = Convert.ToDouble(kon.rd["qtypembelian"].ToString()) - Convert.ToDouble(kon.rd["qtyreturpembelian"].ToString()) -
                        Convert.ToDouble(kon.rd["qtypenjualan"].ToString()) + Convert.ToDouble(kon.rd["qtyreturpenjualan"].ToString()) +
                        Convert.ToDouble(kon.rd["qtypenyesuaian"].ToString());
                }
                kon.CloseConn();
            }
            catch (Exception e)
            {
                psn.CreateLogErrorClass("GetData >> " + this.Name.ToString() + " >> HitungStok", "Tampil Data " + barcode + " Gagal", e.ToString());
            }

            return stok;
        }

        private double HitungSaldo(string barcode)
        {
            double stok = 0;
            try
            {
                kon.OpenConn();
                kon.cmd = new MySqlCommand("call stokRupiah('" + barcode + "','" + dtTglTransaksi.Value.ToString("yyyy-MM-dd") + "')", kon.con);
                kon.cmd.ExecuteNonQuery();
                kon.rd = kon.cmd.ExecuteReader();
                while (kon.rd.Read())
                {
                    stok = Convert.ToDouble(kon.rd["saldopembelian"].ToString()) - Convert.ToDouble(kon.rd["saldoreturpembelian"].ToString()) -
                        Convert.ToDouble(kon.rd["saldopenjualan"].ToString()) + Convert.ToDouble(kon.rd["saldoreturpenjualan"].ToString()) +
                        Convert.ToDouble(kon.rd["saldopenyesuaian"].ToString());
                }
                kon.CloseConn();
            }
            catch (Exception e)
            {
                psn.CreateLogErrorClass("GetData >> " + this.Name.ToString() + " >> HitungSaldo", "Tampil Data " + barcode + " Gagal", e.ToString());
            }

            return stok;
        }

        private string HitungSelisih(string valStok, string ValPenyesuaian)
        {
            double hasil = 0;
            double stok = Convert.ToDouble(valStok);
            double penyesuaian = Convert.ToDouble(ValPenyesuaian);

            hasil = penyesuaian - stok;

            return fs.FormatNumbCurr(hasil.ToString());
        }

        private string HitungNilaiQty(string valStok, string valSaldo)
        {
            double hasil = 0;
            double stok = Convert.ToDouble(valStok);
            double saldo = Convert.ToDouble(valSaldo);

            if(saldo == 0 && stok == 0)
            {
                hasil = 0;
            }
            else if(saldo != 0 && stok == 0)
            {
                hasil = saldo;
            }
            else if(saldo == 0 && stok != 0)
            {
                hasil = 0;
            }
            else if(saldo != 0 && stok != 0)
            {
                hasil = saldo / stok;
            }
            return fs.FormatNumbCurr(hasil.ToString());
        }

        private string HitungSubtotal(string Valselisih, string valNilaiQty)
        {
            double hasil = 0;
            double selisih = Convert.ToDouble(Valselisih);
            double nilaiqty = Convert.ToDouble(valNilaiQty);

            hasil = selisih * nilaiqty;

            return fs.FormatNumbCurr(hasil.ToString());
        }

        private void DeleteStok(string idtransaksi)
        {
            try
            {
                DataSet ds = new DataSet();
                kon.OpenConn();
                kon.da = new MySqlDataAdapter("select barcode,qtyselisih,subtotal from penyesuaian_detail where id = '" + idtransaksi + "'", kon.con);
                kon.da.Fill(ds, "data");
                int row = ds.Tables["data"].Rows.Count - 1;

                if (row >= 0)
                {
                    for (int i = 0; i <= row; i++)
                    {
                        qry.UpdateData("barang", "stokgudang = stokgudang - " + fs.FNum(ds.Tables["data"].Rows[i].ItemArray[1].ToString()) + "," +
                            "stokrupiah = stokrupiah - " + fs.FNum(ds.Tables["data"].Rows[i].ItemArray[2].ToString()) + "",
                            "barcode = '" + ds.Tables["data"].Rows[i].ItemArray[0].ToString() + "'");
                    }
                }
            }
            catch (Exception ex)
            {
                psn.CreateLogErrorForm(this, "DeleteStok", "Hapus Stok " + idtransaksi + " Gagal", ex.ToString());
            }
            finally
            {
                kon.CloseConn();
            }
        }

        private void Simpan()
        {
            try
            {
                DeleteStok(lblID.Text);
                qry.DeleteData("penyesuaian", "id = '" + lblID.Text + "'");
                qry.DeleteData("penyesuaian_detail", "id = '" + lblID.Text + "'");

                if (lblID.Text == "AUTO ID")
                {
                    lblID.Text = qry.CreateID(this, "Simpan", "id", "penyesuaian", "id like 'OP." + dtTglTransaksi.Value.ToString("MMyyyy") + ".%'",
                        "OP." + dtTglTransaksi.Value.ToString("MMyyyy") + ".", "transaksi");
                }

                qry.InsertData("penyesuaian", "id,tgltransaksi,catatan,tglinput,tglupdate",
                    "'" + lblID.Text + "'," +
                    "'" + string.Format("{0:yyyy-MM-dd}", dtTglTransaksi.Value) + "'," +
                    "'" + txtCatatan.Text.Trim() + "'," +
                    "'" + tglinput + "'," +
                    "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'");

                for (int i = 0; i < dgTransaksi.Rows.Count; i++)
                {
                    string barcode = dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString();
                    string nama = dgTransaksi.Rows[i].Cells[cellnama].Value.ToString();
                    string stok = dgTransaksi.Rows[i].Cells[cellstok].Value.ToString();
                    string nilaistok = dgTransaksi.Rows[i].Cells[cellnilaistok].Value.ToString();
                    string qtypenyesuaian = dgTransaksi.Rows[i].Cells[cellpenyesuaian].Value.ToString();
                    string qtyselisih = dgTransaksi.Rows[i].Cells[cellselisih].Value.ToString();
                    string satuan = dgTransaksi.Rows[i].Cells[cellsatuan].Value.ToString();
                    string nilaiqty = dgTransaksi.Rows[i].Cells[cellnilaibarang].Value.ToString();
                    string subtotal = dgTransaksi.Rows[i].Cells[cellsubtotal].Value.ToString();

                    //tandai
                    if (barcode != "" && Convert.ToDouble(qtyselisih) != 0)
                    {
                        qry.InsertData("penyesuaian_detail", "id,barcode,nama,stok,nilaistok,qtypenyesuaian,qtyselisih,satuan,nilaiqty,subtotal",
                            "'" + lblID.Text + "'," +
                            "'" + barcode + "'," +
                            "'" + nama + "'," +
                            "" + fs.FNum(stok) + "," +
                            "" + fs.FNum(nilaistok) + "," +
                            "" + fs.FNum(qtypenyesuaian) + "," +
                            "" + fs.FNum(qtyselisih) + "," +
                            "'" + satuan + "'," +
                            "" + fs.FNum(nilaiqty) + "," +
                            "" + fs.FNum(subtotal) + "");
                    }

                    qry.UpdateData("barang", "stokgudang = stokgudang + " + fs.FNum(qtyselisih) + "," +
                        "stokrupiah = stokrupiah + " + fs.FNum(subtotal.ToString()) + "", "barcode = '" + barcode + "'");
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
            DialogResult result = MessageBox.Show("Hapus Data?", "Konfirmasi", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DeleteStok(lblID.Text); //tandai
                    qry.DeleteData("penyesuaian", "id = '" + lblID.Text + "'");
                    qry.DeleteData("penyesuaian_detail", "id = '" + lblID.Text + "'");

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
        }

        private void Cetak(string idtransaksi)
        {
            cls.OpenForm op = new cls.OpenForm(frmUtama);
            op.PreviewCetakOpen(this, "PreviewCetakData", idtransaksi, "", userName);
        }
        #endregion

        private void Penyesuaian_Load(object sender, EventArgs e)
        {
            tglinput = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (id != "")
                lblID.Text = id;

            frmUtama.lblNamaForm.Text = "- Penyesuaian";
            UsrAccess();
        }

        private void Penyesuaian_KeyPress(object sender, KeyPressEventArgs e)
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
            op.ListOpen("List", "Penyesuaian-Barang", "Barang", "", userName);

            txtKodeBarcode.Text = barcode;
            barcode = "";
            txtKodeBarcode.Focus();
        }

        private void txtKodeBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                TampilBarang(txtKodeBarcode.Text);

                if (namabarang == "")
                {
                    psn.PesanInfo("Kode Barang " + txtKodeBarcode.Text.Trim() + " Tidak Ada Dalam Database");
                    txtKodeBarcode.Text = "";
                    txtKodeBarcode.Focus();
                }
                else
                {
                    InsertDataGrid();
                    namabarang = "";
                    txtKodeBarcode.Text = "";
                }
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
                        fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Hapus Kode Barang " + row.Cells[cellbarcode].Value.ToString() + " dari List Penyesuaian Berhasil",
                                frmUtama.tooltip_x, frmUtama.tooltip_y, "info");
                    }
                }
            }
        }

        private void dgTransaksi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgTransaksi.CurrentCell.ColumnIndex == cellpenyesuaian)
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

            if ((dgTransaksi.Focused) && (dgTransaksi.CurrentCell.ColumnIndex == cellpenyesuaian))
            {
                if (Convert.ToString(dgTransaksi.CurrentCell.Value) == "")
                {
                    dgTransaksi.CurrentCell.Value = "0.00";
                }
                dgTransaksi.CurrentCell.Value = fs.FormatNumbCurr(Convert.ToString(dgTransaksi.CurrentCell.Value));
            }
            else if ((dgTransaksi.Focused) && (dgTransaksi.CurrentCell.ColumnIndex == cellnilaistok))
            {
                if (Convert.ToString(dgTransaksi.CurrentCell.Value) == "")
                {
                    dgTransaksi.CurrentCell.Value = "0.00";
                }
                dgTransaksi.CurrentCell.Value = fs.FormatNumbCurr(Convert.ToString(dgTransaksi.CurrentCell.Value));
            }

            row.Cells[cellselisih].Value = HitungSelisih(row.Cells[cellstok].Value.ToString(), row.Cells[cellpenyesuaian].Value.ToString());
            row.Cells[cellnilaibarang].Value = HitungNilaiQty(row.Cells[cellstok].Value.ToString(), row.Cells[cellnilaistok].Value.ToString());
            row.Cells[cellsubtotal].Value = HitungSubtotal(row.Cells[cellselisih].Value.ToString(), row.Cells[cellnilaibarang].Value.ToString());
        }

        private void lblID_TextChanged(object sender, EventArgs e)
        {
            TampilData(lblID.Text);
        }
    }
}
