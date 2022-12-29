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
    public partial class Piutang : Form
    {
        //tidak semua transaksi penjualan masuk di piutang, hanya yang jenis bayar nya hutang yang bisa dibayar disini

        cls.Fungsi fs = new cls.Fungsi();
        cls.Pesan psn = new cls.Pesan();
        cls.Query qry = new cls.Query();

        MenuUtama frmUtama;
        public string userName;
        public string id;
        string idUpdate;
        bool updateData;
        string jenisbayar;

        public static string idpenjualan;

        //variabel cell
        int cellid;
        int celltglbayar;
        int cellcatatan;
        int cellpembayaran;

        public Piutang(MenuUtama mnutama)
        {
            InitializeComponent();
            frmUtama = mnutama;
            updateData = false;
            cellid = 0;
            celltglbayar = 1;
            cellcatatan = 2;
            cellpembayaran = 3;
            fs.BoldHeaderDataGridView(dgTransaksi);
            this.KeyDown += new KeyEventHandler(this.OnKeyDown);
            ActiveControl = txtIDPenjualan;
        }

        #region code
        private void UsrAccess()
        {
            string data = qry.GetData(this, "UsrAccess", userName, 0,
                "piutangsv,piutangdel,piutangup", "usrmgmt", "usrname = '" + userName + "'");

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
                        updateData = true;

                    qry.InsertLogAktivitas("UsrAccess", this, userName, userName);
                }
            }
        }

        private void Clear()
        {
            fs.FillTextBoxArray(new TextBox[] { txtIDPenjualan, txtDetailPenjualan, txtCatatan }, "");
            fs.FillLabelArray(new Label[] { lblTotalHutang, lblTotalBayar, lblSisa }, "0.00");
            txtPembayaran.Text = "0.00";
            jenisbayar = "";
            dtTglTransaksi.Value = DateTime.Today;
            dgTransaksi.Rows.Clear();
            lblID.Text = "AUTO ID";
            txtIDPenjualan.Focus();
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
                    if (txtIDPenjualan.Text.Trim() == "")
                    {
                        psn.PesanInfo("ID Penjualan Masih Kosong");
                        txtIDPenjualan.Focus();
                    }
                    else if (Convert.ToDouble(txtPembayaran.Text) <= 0)
                    {
                        psn.PesanInfo("Pembayaran Tidak Boleh 0");
                        txtPembayaran.Focus();
                    }
                    else if (Convert.ToDouble(txtPembayaran.Text) > Convert.ToDouble(lblSisa.Text))
                    {
                        psn.PesanInfo("Pembayaran Lebih Besar dari Sisa Hutang");
                        txtPembayaran.Focus();
                    }
                    else if(jenisbayar != "HUTANG")
                    {
                        psn.PesanInfo("Transaksi Penjualan Sudah Lunas");
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
                        psn.PesanInfo("ID Penjualan Masih Kosong");
                    }
                    else
                    {
                        Hapus();
                    }
                    break;
                /*case "CETAK":
                    if (txtIDPenjualan.Text.Trim() == "")
                    {
                        psn.PesanInfo("ID Penjualan Masih Kosong");
                        txtIDPenjualan.Focus();
                    }
                    else if (Convert.ToDouble(txtPembayaran.Text) <= 0)
                    {
                        psn.PesanInfo("Pembayaran Tidak Boleh 0");
                        txtPembayaran.Focus();
                    }
                    else if (Convert.ToDouble(txtPembayaran.Text) > Convert.ToDouble(lblSisa.Text))
                    {
                        psn.PesanInfo("Pembayaran Lebih Besar dari Sisa Hutang");
                        txtPembayaran.Focus();
                    }
                    else if(jenisbayar != "HUTANG")
                    {
                        psn.PesanInfo("Transaksi Penjualan Sudah Lunas");
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
                    op.PencarianOpen("Pencarian", "Piutang", userName);
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

            string data = qry.GetData(this, "TampilData", id, 13, "id,tgltransaksi,idpenjualan,catatan,bayar",
                "piutang", "id = '" + id + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    idUpdate = filldata[0]; //jika kosong berarti data baru, jika muncul id data lama -> cek status boleh update atau tidak
                    dtTglTransaksi.Value = Convert.ToDateTime(filldata[1]);
                    txtIDPenjualan.Text = filldata[2];
                    txtCatatan.Text = filldata[3];
                    txtPembayaran.Text = fs.FormatNumbCurr(filldata[4]);

                    qry.InsertLogAktivitas("TampilData", this, lblID.Text, userName);
                }
            }
        }

        private void TampilDetailData(string id)
        {
            qry.DataGridViewFill(this, dgTransaksi, "TampilDetailData", "id,date_format(tgltransaksi, '%d-%b-%Y') as tgltr,catatan,bayar",
                "piutang", "idpenjualan = '" + id + "' and id != '" + lblID.Text + "'");

            int row = qry.ds.Tables["detail"].Rows.Count - 1;

            if (row >= 0)
            {
                for (int i = 0; i <= row; i++)
                {
                    dgTransaksi.Rows.Add();
                    dgTransaksi.Rows[i].Cells[cellid].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[0];
                    dgTransaksi.Rows[i].Cells[celltglbayar].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[1];
                    dgTransaksi.Rows[i].Cells[cellcatatan].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[2];
                    dgTransaksi.Rows[i].Cells[cellpembayaran].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[3].ToString());
                }

                lblTotalBayar.Text = fs.FormatNumbCurr(Convert.ToString(HitungTotalBayar()));

                dgTransaksi.AutoResizeColumns();
                qry.InsertLogAktivitas("TampilDetailData", this, lblID.Text, userName);
            }
        }

        private void TampilPenjualan(string id)
        {
            string data = qry.GetData(this, "TampilPenjualan", id, 13, "b.nama,a.jenisbayar,a.tgltransaksi,a.catatan,a.grandtotal",
                "penjualan a inner join customer b on a.idcustomer = b.id", "a.id = '" + id + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    txtDetailPenjualan.Text = "Nama \t\t: " + filldata[0] +
                        Environment.NewLine + "Jenis Bayar \t: " + filldata[1] +
                        Environment.NewLine + "Tgl. Transaksi \t: " + Convert.ToDateTime(filldata[2]).ToString("dd-MMM-yyyy") +
                        Environment.NewLine + "Catatan \t: " + filldata[3];
                    lblTotalHutang.Text = fs.FormatNumbCurr(filldata[4]);
                    jenisbayar = filldata[1];

                    if(filldata[1] != "HUTANG")
                    {
                        lblTotalBayar.Text = fs.FormatNumbCurr(filldata[4]);
                    }

                    qry.InsertLogAktivitas("TampilPenjualan", this, txtIDPenjualan.Text, userName);
                }

                TampilDetailData(id);
                HitungSisaBayar();
            }
        }

        private double HitungTotalBayar()
        {
            double subtotal = 0;

            if (dgTransaksi.Rows.Count > 0)
            {
                for (int i = 0; i < dgTransaksi.Rows.Count; i++)
                {
                    if (dgTransaksi.Rows[i].Cells[cellpembayaran].Value.ToString() != "")
                    {
                        subtotal = subtotal + Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellpembayaran].Value);
                    }
                }
            }
            else
            {
                subtotal = 0;
            }

            return subtotal;
        }

        private void HitungSisaBayar()
        {
            lblSisa.Text = fs.FormatNumbCurr(Convert.ToString(Convert.ToDouble(lblTotalHutang.Text) - Convert.ToDouble(lblTotalBayar.Text)));
        }

        private void Simpan()
        {
            if (qry.DataExist(this, "Simpan", lblID.Text, txtIDPenjualan.Text.Trim(), "id", "piutang", "id = '" + lblID.Text + "'"))
            {
                try
                {
                    qry.UpdateData("piutang",
                        "tgltransaksi = '" + string.Format("{0:yyyy-MM-dd}", dtTglTransaksi.Value) + "'," +
                        "idpenjualan = '" + txtIDPenjualan.Text.Trim() + "'," +
                        "catatan = '" + txtCatatan.Text.Trim() + "'," +
                        "bayar = " + fs.FNum(txtPembayaran.Text.Trim()) + "," +
                        "tglupdate = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'",
                        "id = '" + lblID.Text + "'");

                    qry.InsertLogAktivitas("Update", this, lblID.Text, userName);
                    fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Update " + this.Name.ToString() + " " + lblID.Text + " " + txtIDPenjualan.Text.Trim() + " Berhasil",
                        frmUtama.tooltip_x, frmUtama.tooltip_y, "info");
                    id = lblID.Text;
                    Clear();
                }
                catch (Exception ex)
                {
                    psn.CreateLogErrorForm(this, "Update", "Update " + lblID.Text + " Gagal", ex.ToString());
                }
            }
            else
            {
                if (lblID.Text == "AUTO ID")
                {
                    lblID.Text = qry.CreateID(this, "Simpan", "id", "piutang", "id like 'PT." + dtTglTransaksi.Value.ToString("MMyyyy") + ".%'",
                            "PT." + dtTglTransaksi.Value.ToString("MMyyyy") + ".", "transaksi");
                }

                try
                {
                    qry.InsertData("piutang",
                        "id,tgltransaksi,idpenjualan,catatan,bayar,tglinput,tglupdate",
                        "'" + lblID.Text + "'," +
                        "'" + string.Format("{0:yyyy-MM-dd}", dtTglTransaksi.Value) + "'," +
                        "'" + txtIDPenjualan.Text.Trim() + "'," +
                        "'" + txtCatatan.Text.Trim() + "'," +
                        "" + fs.FNum(txtPembayaran.Text) + "," +
                        "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                        "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'");

                    qry.InsertLogAktivitas("Simpan", this, lblID.Text, userName);
                    fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Simpan " + this.Name.ToString() + " " + lblID.Text + " " + txtIDPenjualan.Text.Trim() + " Berhasil",
                        frmUtama.tooltip_x, frmUtama.tooltip_y, "info");
                    id = lblID.Text;
                    Clear();
                }
                catch (Exception ex)
                {
                    psn.CreateLogErrorForm(this, "Simpan", "Simpan " + lblID.Text + " Gagal", ex.ToString());
                }
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
                    qry.DeleteData("piutang", "id = '" + lblID.Text + "'");

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
        #endregion

        private void Piutang_Load(object sender, EventArgs e)
        {
            if (id != "")
                lblID.Text = id;

            frmUtama.lblNamaForm.Text = "- Piutang";
            UsrAccess();
        }

        private void Piutang_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            SelectToolBar(btnKeluar);
        }

        private void lblID_TextChanged(object sender, EventArgs e)
        {
            TampilData(lblID.Text);
        }

        private void btnCariPenjualan_Click(object sender, EventArgs e)
        {
            cls.OpenForm op = new cls.OpenForm(frmUtama);
            op.ListOpen("List", "Piutang-IDPenjualan", "Penjualan", "", userName);

            txtIDPenjualan.Text = idpenjualan;
            idpenjualan = "";
        }

        private void txtIDPenjualan_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.AllowOnlyBackspace(e);
        }

        private void txtIDPenjualan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                btnCariPenjualan_Click(sender, e);
            }
        }

        private void txtIDPenjualan_TextChanged(object sender, EventArgs e)
        {
            TampilPenjualan(txtIDPenjualan.Text.Trim());
        }

        private void txtPembayaran_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.InputNumber(e);
        }

        private void txtPembayaran_Leave(object sender, EventArgs e)
        {
            fs.TextLeave(txtPembayaran);
        }

        private void txtCatatan_Leave(object sender, EventArgs e)
        {
            txtPembayaran.Focus();
        }

        private void chkLunas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLunas.Checked == true)
            {
                txtPembayaran.Text = lblSisa.Text;
            }
            else
            {
                txtPembayaran.Text = "0.00";
            }
        }
    }
}
