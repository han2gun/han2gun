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
    public partial class Hutang : Form
    {
        cls.Fungsi fs = new cls.Fungsi();
        cls.Pesan psn = new cls.Pesan();
        cls.Query qry = new cls.Query();

        MenuUtama frmUtama;
        public string userName;
        public string id;
        string idUpdate;
        bool updateData;
        
        public static string idpembelian;

        //variabel cell
        int cellid;
        int celltglbayar;
        int cellcatatan;
        int cellpembayaran;

        public Hutang(MenuUtama mnutama)
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
            ActiveControl = txtIDPembelian;
        }

        #region code
        private void UsrAccess()
        {
            string data = qry.GetData(this, "UsrAccess", userName, 0,
                "hutangsv,hutangdel,hutangup", "usrmgmt", "usrname = '" + userName + "'");

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
            fs.FillTextBoxArray(new TextBox[] { txtIDPembelian, txtDetailPembelian, txtCatatan }, "");
            fs.FillLabelArray(new Label[] { lblTotalHutang, lblTotalBayar, lblSisa }, "0.00");
            txtPembayaran.Text = "0.00";
            dtTglTransaksi.Value = DateTime.Today;
            dgTransaksi.Rows.Clear();
            lblID.Text = "AUTO ID";
            txtIDPembelian.Focus();
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
                    if (txtIDPembelian.Text.Trim() == "")
                    {
                        psn.PesanInfo("ID Pembelian Masih Kosong");
                        txtIDPembelian.Focus();
                    }
                    else if (Convert.ToDouble(txtPembayaran.Text) <= 0)
                    {
                        psn.PesanInfo("Pembayaran Tidak Boleh 0");
                        txtPembayaran.Focus();
                    }
                    else if(Convert.ToDouble(txtPembayaran.Text) > Convert.ToDouble(lblSisa.Text))
                    {
                        psn.PesanInfo("Pembayaran Lebih Besar dari Sisa Hutang");
                        txtPembayaran.Focus();
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
                        psn.PesanInfo("ID Pembelian Masih Kosong");
                    }
                    else
                    {
                        Hapus();
                    }
                    break;
                /*case "CETAK":
                    if (txtIdSupplier.Text.Trim() == "")
                    {
                        psn.PesanInfo("Supplier Masih Kosong");
                        txtIdSupplier.Focus();
                    }
                    else if (txtIDPembelian.Text.Trim() == "")
                    {
                        psn.PesanInfo("ID Pembelian Masih Kosong");
                        txtIDPembelian.Focus();
                    }
                    else if (Convert.ToDouble(txtPembayaran.Text) <= 0)
                    {
                        psn.PesanInfo("Pembayaran Tidak Boleh 0");
                        txtPembayaran.Focus();
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
                    op.PencarianOpen("Pencarian", "Hutang", userName);
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

            string data = qry.GetData(this, "TampilData", id, 13, "id,tgltransaksi,idpembelian,catatan,bayar",
                "hutang", "id = '" + id + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    idUpdate = filldata[0]; //jika kosong berarti data baru, jika muncul id data lama -> cek status boleh update atau tidak
                    dtTglTransaksi.Value = Convert.ToDateTime(filldata[1]);
                    txtIDPembelian.Text = filldata[2];
                    txtCatatan.Text = filldata[3];
                    txtPembayaran.Text = fs.FormatNumbCurr(filldata[4]);

                    qry.InsertLogAktivitas("TampilData", this, lblID.Text, userName);
                }
            }
        }

        private void TampilDetailData(string id)
        {
            qry.DataGridViewFill(this, dgTransaksi, "TampilDetailData", "id,date_format(tgltransaksi, '%d-%b-%Y') as tgltr,catatan,bayar",
                "hutang", "idpembelian = '" + id + "' and id != '" + lblID.Text + "'");

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

        private void TampilPembelian(string id)
        {
            string data = qry.GetData(this, "TampilPembelian", id, 13, "b.nama,a.nonota,a.tgltransaksi,a.catatan,a.grandtotal",
                "pembelian a inner join supplier b on a.idsupplier = b.id", "a.id = '" + id + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    txtDetailPembelian.Text = "Nama \t\t: " + filldata[0] +
                        Environment.NewLine + "No. Nota \t: " + filldata[1] +
                        Environment.NewLine + "Tgl. Transaksi \t: " + Convert.ToDateTime(filldata[2]).ToString("dd-MMM-yyyy") +
                        Environment.NewLine + "Catatan \t: " + filldata[3];
                    lblTotalHutang.Text = fs.FormatNumbCurr(filldata[4]);

                    qry.InsertLogAktivitas("TampilPembelian", this, txtIDPembelian.Text, userName);
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
            if (qry.DataExist(this, "Simpan", lblID.Text, txtIDPembelian.Text.Trim(), "id", "hutang", "id = '" + lblID.Text + "'"))
            {
                try
                {
                    qry.UpdateData("hutang",
                        "tgltransaksi = '" + string.Format("{0:yyyy-MM-dd}", dtTglTransaksi.Value) + "'," +
                        "idpembelian = '" + txtIDPembelian.Text.Trim() + "'," +
                        "catatan = '" + txtCatatan.Text.Trim() + "'," +
                        "bayar = " + fs.FNum(txtPembayaran.Text.Trim()) + "," +
                        "tglupdate = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'",
                        "id = '" + lblID.Text + "'");

                    if (Convert.ToDouble(txtPembayaran.Text.Trim()) - Convert.ToDouble(lblSisa.Text) == 0)
                    {
                        qry.UpdateData("pembelian", "flaggudang = 1", "id = '" + txtIDPembelian.Text.Trim() + "'");
                    }
                    else
                    {
                        qry.UpdateData("pembelian", "flaggudang = 0", "id = '" + txtIDPembelian.Text.Trim() + "'");
                    }

                    qry.InsertLogAktivitas("Update", this, lblID.Text, userName);
                    fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Update " + this.Name.ToString() + " " + lblID.Text + " " + txtIDPembelian.Text.Trim() + " Berhasil",
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
                    lblID.Text = qry.CreateID(this, "Simpan", "id", "hutang", "id like 'HT." + dtTglTransaksi.Value.ToString("MMyyyy") + ".%'",
                            "HT." + dtTglTransaksi.Value.ToString("MMyyyy") + ".", "transaksi");
                }

                try
                {
                    qry.InsertData("hutang",
                        "id,tgltransaksi,idpembelian,catatan,bayar,tglinput,tglupdate",
                        "'" + lblID.Text + "'," +
                        "'" + string.Format("{0:yyyy-MM-dd}", dtTglTransaksi.Value) + "'," +
                        "'" + txtIDPembelian.Text.Trim() + "'," +
                        "'" + txtCatatan.Text.Trim() + "'," +
                        "" + fs.FNum(txtPembayaran.Text) + "," +
                        "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                        "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'");

                    if (Convert.ToDouble(txtPembayaran.Text.Trim()) - Convert.ToDouble(lblSisa.Text) == 0)
                    {
                        qry.UpdateData("pembelian", "flaggudang = 1", "id = '" + txtIDPembelian.Text.Trim() + "'");
                    }
                    else
                    {
                        qry.UpdateData("pembelian", "flaggudang = 0", "id = '" + txtIDPembelian.Text.Trim() + "'");
                    }

                    qry.InsertLogAktivitas("Simpan", this, lblID.Text, userName);
                    fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Simpan " + this.Name.ToString() + " " + lblID.Text + " " + txtIDPembelian.Text.Trim() + " Berhasil",
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
                    qry.DeleteData("hutang", "id = '" + lblID.Text + "'");

                    if (Convert.ToDouble(txtPembayaran.Text.Trim()) - Convert.ToDouble(lblSisa.Text) == 0)
                    {
                        qry.UpdateData("pembelian", "flaggudang = 0", "id = '" + txtIDPembelian.Text.Trim() + "'");
                    }

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

        private void Hutang_Load(object sender, EventArgs e)
        {
            if (id != "")
                lblID.Text = id;

            frmUtama.lblNamaForm.Text = "- Hutang";
            UsrAccess();
        }

        private void Hutang_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnCariPembelian_Click(object sender, EventArgs e)
        {
            cls.OpenForm op = new cls.OpenForm(frmUtama);
            op.ListOpen("List", "Hutang-IDPembelian", "Pembelian", "", userName);

            txtIDPembelian.Text = idpembelian;
            idpembelian = "";
        }

        private void txtIDPembelian_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.AllowOnlyBackspace(e);
        }

        private void txtIDPembelian_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                btnCariPembelian_Click(sender, e);
            }
        }

        private void txtIDPembelian_TextChanged(object sender, EventArgs e)
        {
            TampilPembelian(txtIDPembelian.Text.Trim());
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
            if(chkLunas.Checked == true)
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
