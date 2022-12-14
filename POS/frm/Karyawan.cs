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
    public partial class Karyawan : Form
    {
        cls.Fungsi fs = new cls.Fungsi();
        cls.Pesan psn = new cls.Pesan();
        cls.Query qry = new cls.Query();

        MenuUtama frmUtama;
        public string userName;
        public string id;
        string idUpdate;
        bool updateData;

        public Karyawan(MenuUtama mnutama)
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
                "karyawansv,karyawandel,karyawanprt,karyawanup", "usrmgmt", "usrname = '" + userName + "'");

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
            fs.ClearTextBox(this.Controls);
            chkSalesAwal.Checked = false;
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
                        psn.PesanInfo("ID Karyawan Masih Kosong");
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
                    op.PencarianOpen("Pencarian", "Karyawan", userName);
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

            string data = qry.GetData(this, "TampilData", id, 8, "id,cekawal,nama,alamat,telp,nohp,email,catatan", "karyawan", "id = '" + id + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    idUpdate = filldata[0]; //jika kosong berarti data baru, jika muncul id data lama -> cek status boleh update atau tidak
                    chkSalesAwal.Checked = fs.IntToBool(filldata[1]);
                    txtNama.Text = filldata[2];
                    txtAlamat.Text = filldata[3];
                    txtNoTelp.Text = filldata[4];
                    txtNoHP.Text = filldata[5];
                    txtEmail.Text = filldata[6];
                    txtCatatan.Text = filldata[7];

                    qry.InsertLogAktivitas("TampilData", this, lblID.Text, userName);
                }
            }
        }

        private void Simpan()
        {
            if (qry.DataExist(this, "Simpan", lblID.Text, txtNama.Text.Trim(), "id", "karyawan", "id = '" + lblID.Text + "'"))
            {
                try
                {
                    if (chkSalesAwal.Checked == true)
                    {
                        string idsaleslama = "";
                        string namasalaeslama = "";

                        string data = qry.GetData(this, "Simpan-Cek Karyawan Awal Lama", "", 8, "id,nama", "karyawan", "cekawal = 1");

                        if (data != "")
                        {
                            string[] filldata = data.Split('|');

                            if (filldata.ToString() != "")
                            {
                                idsaleslama = filldata[0];
                                namasalaeslama = filldata[1];

                                qry.InsertLogAktivitas("Simpan-Cek Karyawan Awal Lama", this, idsaleslama, userName);
                            }
                            qry.UpdateData("karyawan",
                            "cekawal = 0",
                            "id = '" + idsaleslama + "'");

                            qry.InsertLogAktivitas("Update-Cek Karyawan Awal Lama", this, idsaleslama, userName);
                            fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Update-Cek Cust Awal Lama " + this.Name.ToString() + " " + idsaleslama + " Berhasil",
                                frmUtama.tooltip_x, frmUtama.tooltip_y, "info");
                        }
                    }

                    qry.UpdateData("karyawan",
                        "cekawal = " + fs.BoolToInt(chkSalesAwal.Checked) + "," +
                        "nama = '" + txtNama.Text.Trim() + "'," +
                        "alamat = '" + txtAlamat.Text.Trim() + "'," +
                        "telp = '" + txtNoTelp.Text.Trim() + "'," +
                        "nohp = '" + txtNoHP.Text.Trim() + "'," +
                        "email = '" + txtEmail.Text.Trim() + "'," +
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
                if (lblID.Text == "AUTO ID")
                {
                    lblID.Text = qry.CreateID(this, "Simpan", "id", "karyawan", "id like 'KR.%'", "KR.", "master");
                }

                try
                {
                    if (chkSalesAwal.Checked == true)
                    {
                        string idsaleslama = "";
                        string namasalaeslama = "";

                        string data = qry.GetData(this, "Simpan-Cek Karyawan Awal Lama", "", 8, "id,nama", "karyawan", "cekawal = 1");

                        if (data != "")
                        {
                            string[] filldata = data.Split('|');

                            if (filldata.ToString() != "")
                            {
                                idsaleslama = filldata[0];
                                namasalaeslama = filldata[1];

                                qry.InsertLogAktivitas("Simpan-Cek Karyawan Awal Lama", this, idsaleslama, userName);
                            }
                            qry.UpdateData("karyawan",
                            "cekawal = 0",
                            "id = '" + idsaleslama + "'");

                            qry.InsertLogAktivitas("Update-Cek Karyawan Awal Lama", this, idsaleslama, userName);
                            fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Update-Cek Cust Awal Lama " + this.Name.ToString() + " " + idsaleslama + " Berhasil",
                                frmUtama.tooltip_x, frmUtama.tooltip_y, "info");
                        }
                    }

                    qry.InsertData("karyawan",
                        "id,cekawal,nama,alamat,telp,nohp,email,catatan,tglinput,tglupdate",
                        "'" + lblID.Text + "'," + fs.BoolToInt(chkSalesAwal.Checked) + ",'" + txtNama.Text.Trim() + "','" + txtAlamat.Text.Trim() + "'," +
                        "'" + txtNoTelp.Text.Trim() + "','" + txtNoHP.Text.Trim() + "','" + txtEmail.Text.Trim() + "'," +
                        "'" + txtCatatan.Text.Trim() + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
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
                        qry.DeleteData("karyawan", "id = '" + lblID.Text + "'");

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
            op.PreviewCetakOpen(this, "PreviewCetakData", "", "", userName);
        }
        #endregion

        private void Karyawan_Load(object sender, EventArgs e)
        {
            if (id != "")
                lblID.Text = id;

            frmUtama.lblNamaForm.Text = "- Karyawan / Sales";
            UsrAccess();
        }

        private void Karyawan_KeyPress(object sender, KeyPressEventArgs e)
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

        private void lblID_TextChanged(object sender, EventArgs e)
        {
            TampilData(lblID.Text);
        }
    }
}
