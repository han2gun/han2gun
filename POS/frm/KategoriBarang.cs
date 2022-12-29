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
    public partial class KategoriBarang : Form
    {
        cls.Fungsi fs = new cls.Fungsi();
        cls.Pesan psn = new cls.Pesan();
        cls.Query qry = new cls.Query();

        MenuUtama frmUtama;
        public string userName;
        public string id;
        string idUpdate;
        bool updateData;

        public KategoriBarang(MenuUtama mnutama)
        {
            InitializeComponent();

            frmUtama = mnutama;
            idUpdate = "";
            updateData = false;
            this.KeyDown += new KeyEventHandler(this.OnKeyDown);
            ActiveControl = txtNama;
        }

        #region code
        private void UsrAccess()
        {
            string data = qry.GetData(this, "UsrAccess", userName, 0,
                "kelbarangsv,kelbarangdel,kelbarangup", "usrmgmt", "usrname = '" + userName + "'");

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
            fs.ClearTextBox(this.Controls);
            lblID.Text = "AUTO ID";
            txtNama.Focus();
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
                    if (txtNama.Text.Trim() == "")
                    {
                        psn.PesanInfo("Nama Masih Kosong");
                        txtNama.Focus();
                    }
                    /*else if(qry.DataExist(this, "SelectToolBar", txtNama.Text.Trim(), lblID.Text, "nama", "kategori", "nama = '" + txtNama.Text.Trim() + "'"))
                    {
                        psn.PesanInfo("Nama Kategori Yang Sama Sudah Ada");
                        txtNama.Focus();
                    }*/
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
                        psn.PesanInfo("ID Kategori Barang Masih Kosong");
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
                    op.PencarianOpen("Pencarian", "KategoriBarang", userName);
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

            string data = qry.GetData(this, "TampilData", id, 8, "id,nama,catatan", "kategori", "id = '" + id + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    idUpdate = filldata[0]; //jika kosong berarti data baru, jika muncul id data lama -> cek status boleh update atau tidak
                    txtNama.Text = filldata[1];
                    txtCatatan.Text = filldata[2];

                    qry.InsertLogAktivitas("TampilData", this, lblID.Text, userName);
                }
            }
        }

        private void Simpan()
        {
            if (qry.DataExist(this, "Simpan", lblID.Text, txtNama.Text.Trim(), "id", "kategori", "id = '" + lblID.Text + "'"))
            {
                try
                {
                    qry.UpdateData("kategori",
                        "nama = '" + txtNama.Text.Trim() + "'," +
                        "catatan = '" + txtCatatan.Text.Trim() + "'," +
                        "tglupdate = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'",
                        "id = '" + lblID.Text + "'");

                    qry.InsertLogAktivitas("Update", this, lblID.Text, userName);
                    fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Update " + this.Name.ToString() + " " + lblID.Text + " " + txtNama.Text.Trim() + " Berhasil",
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
                if (qry.DataExist(this, "SelectToolBar", txtNama.Text.Trim(), lblID.Text, "nama", "kategori", "nama = '" + txtNama.Text.Trim() + "'"))
                {
                    psn.PesanInfo("Nama Kategori Yang Sama Sudah Ada");
                    txtNama.Focus();
                }
                else
                {
                    if (lblID.Text == "AUTO ID")
                    {
                        lblID.Text = qry.CreateID(this, "Simpan", "id", "kategori", "id like 'KT.%'", "KT.", "master");
                    }

                    try
                    {
                        qry.InsertData("kategori",
                            "id,nama,catatan,tglinput,tglupdate",
                            "'" + lblID.Text + "','" + txtNama.Text.Trim() + "','" + txtCatatan.Text.Trim() + "'," +
                            "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                            "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'");

                        qry.InsertLogAktivitas("Simpan", this, lblID.Text, userName);
                        fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Simpan " + this.Name.ToString() + " " + lblID.Text + " " + txtNama.Text.Trim() + " Berhasil",
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
        }

        private void Hapus()
        {
            if (qry.DataExist(this, "Hapus", lblID.Text, txtNama.Text.Trim(), "idkategori", "barang", "idkategori = '" + lblID.Text + "'"))
            {
                fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Data Kategori " + lblID.Text + " Telah Digunakan Untuk Master Barang",
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
                        qry.DeleteData("kategori", "id = '" + lblID.Text + "'");

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
        }

        /*private void Cetak(string idtransaksi)
        {
            cls.OpenForm op = new cls.OpenForm(frmUtama);
            op.PencetakanDataOpen(this, "PencetakanData", idtransaksi, "", userName);
        }*/
        #endregion

        private void KategoriBarang_Load(object sender, EventArgs e)
        {
            if (id != "")
                lblID.Text = id;

            frmUtama.lblNamaForm.Text = "- Kategori Barang";
            UsrAccess();
        }

        private void KategoriBarang_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
