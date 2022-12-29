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
    public partial class Kas : Form
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

        int cellhapus;
        int cellketerangan;
        int cellnominal;

        bool detailDelete;
        DataGridViewRow row;

        public Kas(MenuUtama mnutama)
        {
            InitializeComponent();

            frmUtama = mnutama;
            idUpdate = "";
            updateData = true;
            cellhapus = 0;
            cellketerangan = 1;
            cellnominal = 2;
            detailDelete = true;
            fs.BoldHeaderDataGridView(dgTransaksi);
            this.KeyDown += new KeyEventHandler(this.OnKeyDown);
            ActiveControl = dtTglTransaksi;
        }

        #region code
        private void UsrAccess()
        {
           string data = qry.GetData(this, "UsrAccess", userName, 0,
               "kassv,kasdel,kasprt,kasup", "usrmgmt", "usrname = '" + userName + "'");

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
            fs.FillTextBoxArray(new TextBox[] { txtCatatan, txtKeterangan }, "");
            fs.FillTextBoxArray(new TextBox[] { txtNominal }, "0.00");
            fs.FillLabelArray(new Label[] { lblGrandTotal }, "0.00");
            dtTglTransaksi.Value = DateTime.Today;
            tglinput = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dgTransaksi.Rows.Clear();
            rbKasKeluar.Checked = true;
            lblID.Text = "AUTO ID";
            dtTglTransaksi.Focus();
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
                        psn.PesanInfo("Detail Transaksi Kas Masih Kosong");
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
                        psn.PesanInfo("ID Kas Masih Kosong");
                    }
                    else
                    {
                        Hapus();
                    }
                    break;
                case "CETAK":
                    if (dgTransaksi.Rows.Count <= 0)
                    {
                        psn.PesanInfo("Detail Transaksi Kas Masih Kosong");
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
                    op.PencarianOpen("Pencarian", "Kas", userName);
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
                    break;
                case Keys.F10:
                    SelectToolBar(btnKeluar);
                    break;
                default:
                    break;*/
            }
        }

        private void TampilData(string id)
        {
            idUpdate = "";

            string data = qry.GetData(this, "TampilData", id, 13, "id,jeniskas,tgltransaksi,catatan,grandtotal,tglinput",
                "kas", "id = '" + id + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    idUpdate = filldata[0]; //jika kosong berarti data baru, jika muncul id data lama -> cek status boleh update atau tidak
                    if(filldata[1] == "1")
                    {
                        rbKasMasuk.Checked = true;
                    }
                    else
                    {
                        rbKasKeluar.Checked = true;
                    }
                    dtTglTransaksi.Value = Convert.ToDateTime(filldata[2]);
                    txtCatatan.Text = filldata[3];
                    lblGrandTotal.Text = fs.FormatNumbCurr(filldata[4]);
                    tglinput = DateTime.Parse(filldata[5]).ToString("yyyy-MM-dd HH:mm:ss");

                    TampilDetailData(id);

                    qry.InsertLogAktivitas("TampilData", this, lblID.Text, userName);
                }
            }
        }

        private void TampilDetailData(string id)
        {
            qry.DataGridViewFill(this, dgTransaksi, "TampilDetailData", "id,keterangan,nominal",
                "kas_detail", "id = '" + id + "'");

            int row = qry.ds.Tables["detail"].Rows.Count - 1;

            if (row >= 0)
            {
                for (int i = 0; i <= row; i++)
                {
                    dgTransaksi.Rows.Add();
                    dgTransaksi.Rows[i].Cells[cellhapus].Value = "X";
                    dgTransaksi.Rows[i].Cells[cellketerangan].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[1];
                    dgTransaksi.Rows[i].Cells[cellnominal].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[2].ToString());
                }

                dgTransaksi.AutoResizeColumns();
                qry.InsertLogAktivitas("TampilDetailData", this, lblID.Text, userName);
            }
        }

        private double HitungGrandTotal()
        {
            double subtotal = 0;

            if (dgTransaksi.Rows.Count > 0)
            {
                for (int i = 0; i < dgTransaksi.Rows.Count; i++)
                {
                    if (dgTransaksi.Rows[i].Cells[cellketerangan].Value.ToString() != "")
                    {
                        subtotal = subtotal + Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellnominal].Value);
                    }
                }
            }
            else
            {
                subtotal = 0;
            }

            return subtotal;
        }

        private void Simpan()
        {
            try
            {
                qry.DeleteData("kas", "id = '" + lblID.Text + "'");
                qry.DeleteData("kas_detail", "id = '" + lblID.Text + "'");

                if (lblID.Text == "AUTO ID")
                {
                    lblID.Text = qry.CreateID(this, "Simpan", "id", "kas", "id like 'KS." + dtTglTransaksi.Value.ToString("MMyyyy") + ".%'",
                        "KS." + dtTglTransaksi.Value.ToString("MMyyyy") + ".", "transaksi");
                }

                qry.InsertData("kas", "id,jeniskas,tgltransaksi,catatan,grandtotal,tglinput,tglupdate",
                    "'" + lblID.Text + "'," +
                    "" + fs.BoolToInt(rbKasMasuk.Checked) + "," +
                    "'" + string.Format("{0:yyyy-MM-dd}", dtTglTransaksi.Value) + "'," +
                    "'" + txtCatatan.Text.Trim() + "'," +
                    "" + fs.FNum(lblGrandTotal.Text) + "," +
                    "'" + tglinput + "'," +
                    "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'");

                for (int i = 0; i < dgTransaksi.Rows.Count; i++)
                {
                    string keterangan = dgTransaksi.Rows[i].Cells[cellketerangan].Value.ToString();
                    string nominal = dgTransaksi.Rows[i].Cells[cellnominal].Value.ToString();

                    if (keterangan != "")
                    {
                        qry.InsertData("kas_detail", "id,keterangan,nominal",
                            "'" + lblID.Text + "'," +
                            "'" + keterangan + "'," +
                            "" + fs.FNum(nominal) + "");
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
                        qry.DeleteData("kas", "id = '" + lblID.Text + "'");
                        qry.DeleteData("kas_detail", "id = '" + lblID.Text + "'");

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

        private void Kas_Load(object sender, EventArgs e)
        {
            tglinput = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            rbKasKeluar.Checked = true;

            if (id != "")
                lblID.Text = id;

            frmUtama.lblNamaForm.Text = "- Kas";
            UsrAccess();
        }

        private void Kas_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnTambahList_Click(object sender, EventArgs e)
        {
            if(txtKeterangan.Text.Trim() == "")
            {
                psn.PesanInfo("Keterangan Transaksi Kas Tidak Boleh Kosong");
            }
            else
            {
                dgTransaksi.Rows.Add("X", txtKeterangan.Text.Trim(), fs.FormatNumbCurr(txtNominal.Text.Trim()));
                dgTransaksi.AutoResizeColumns();
                txtKeterangan.Focus();
                txtKeterangan.Text = "";
                txtNominal.Text = "0.00";
                lblGrandTotal.Text = fs.FormatNumbCurr(HitungGrandTotal().ToString());
            }            
        }

        private void btnTambahList_Leave(object sender, EventArgs e)
        {
            //dgTransaksi.Focus();
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
                else
                {
                    DialogResult result = MessageBox.Show("Apakah Data Ingin Dihapus?", "Konfirmasi", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        dgTransaksi.Rows.Remove(row);

                        lblGrandTotal.Text = fs.FormatNumbCurr(HitungGrandTotal().ToString());

                        qry.InsertLogAktivitas("dgTransaksi_CellClick", this, row.Cells[cellketerangan].Value.ToString(), userName);
                        psn.CreateLogSuccessForm(this, "dgTransaksi_CellClick", row.Cells[cellketerangan].Value.ToString());
                        fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Hapus Detail Kas " + row.Cells[cellketerangan].Value.ToString() + " dari List Kas Berhasil",
                                frmUtama.tooltip_x, frmUtama.tooltip_y, "info");
                    }
                }
            }
        }

        private void dgTransaksi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgTransaksi.CurrentCell.ColumnIndex == cellnominal)
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

            if ((dgTransaksi.Focused) && (dgTransaksi.CurrentCell.ColumnIndex == cellnominal))
            {
                if (Convert.ToString(dgTransaksi.CurrentCell.Value) == "")
                {
                    dgTransaksi.CurrentCell.Value = "0.00";
                }
                dgTransaksi.CurrentCell.Value = fs.FormatNumbCurr(Convert.ToString(dgTransaksi.CurrentCell.Value));
            }

            lblGrandTotal.Text = fs.FormatNumbCurr(HitungGrandTotal().ToString());
        }

        private void dgTransaksi_Leave(object sender, EventArgs e)
        {
            btnSimpan.Focus();
        }

        private void lblID_TextChanged(object sender, EventArgs e)
        {
            TampilData(lblID.Text);
        }

        private void txtNominal_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.InputNumber(e);
        }

        private void txtNominal_Leave(object sender, EventArgs e)
        {
            fs.TextLeave(txtNominal);
        }

        private void txtCatatan_Leave(object sender, EventArgs e)
        {
            txtKeterangan.Focus();
        }
    }
}
