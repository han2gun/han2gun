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
    public partial class DataPerusahaan : Form
    {
        cls.Fungsi fs = new cls.Fungsi();
        cls.Pesan psn = new cls.Pesan();
        cls.Query qry = new cls.Query();

        MenuUtama frmUtama;
        public string userName;
        public string id;
        string idUpdate;
        bool updateData;

        public DataPerusahaan(MenuUtama mnutama)
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
                "identitassv,identitasdel,identitasup", "usrmgmt", "usrname = '" + userName + "'");

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
            lblID.Text = "1";
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
                    Hapus();
                    break;
                case "KELUAR":
                    cls.OpenForm op = new cls.OpenForm(frmUtama);
                    op.MasterDataOpen("MasterData", userName);
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

            string data = qry.GetData(this, "TampilData", id, 8, "id,nama,alamat,telp,nohp,fax,email,npwp,website,catatan", "datausaha", "id = '" + id + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    idUpdate = filldata[0]; //jika kosong berarti data baru, jika muncul id data lama -> cek status boleh update atau tidak
                    txtNama.Text = filldata[1];
                    txtAlamat.Text = filldata[2];
                    txtNoTelp.Text = filldata[3];
                    txtNoHP.Text = filldata[4];
                    txtFax.Text = filldata[5];
                    txtEmail.Text = filldata[6];
                    txtNPWP.Text = filldata[7];
                    txtWebsite.Text = filldata[8];
                    txtCatatan.Text = filldata[9];

                    qry.InsertLogAktivitas("TampilData", this, lblID.Text, userName);
                }
            }
        }

        private void Simpan()
        {
            if (qry.DataExist(this, "Simpan", lblID.Text, txtNama.Text.Trim(), "id", "datausaha", "id = '" + lblID.Text + "'"))
            {
                try
                {
                    qry.UpdateData("datausaha",
                        "nama = '" + txtNama.Text.Trim() + "'," +
                        "alamat = '" + txtAlamat.Text.Trim() + "'," +
                        "telp = '" + txtNoTelp.Text.Trim() + "'," +
                        "nohp = '" + txtNoHP.Text.Trim() + "'," +
                        "fax = '" + txtFax.Text.Trim() + "'," +
                        "email = '" + txtEmail.Text.Trim() + "'," +
                        "npwp = '" + txtNPWP.Text.Trim() + "'," +
                        "website = '" + txtWebsite.Text.Trim() + "'," +
                        "catatan = '" + txtCatatan.Text.Trim() + "'," +
                        "tglupdate = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'",
                        "id = '" + lblID.Text + "'");

                    qry.InsertLogAktivitas("Update", this, lblID.Text, userName);
                    fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Update " + this.Name.ToString() + " " + lblID.Text + " " + txtNama.Text.Trim() + " Berhasil",
                        frmUtama.tooltip_x, frmUtama.tooltip_y, "info");
                    id = lblID.Text;
                    //Clear(); tidak perlu di clear
                }
                catch (Exception ex)
                {
                    psn.CreateLogErrorForm(this, "Update", "Update " + lblID.Text + " Gagal", ex.ToString());
                }
            }
            else
            {
                try
                {
                    qry.InsertData("datausaha",
                        "id,nama,alamat,telp,nohp,fax,email,npwp,website,catatan,tglinput,tglupdate",
                        "'" + lblID.Text + "','" + txtNama.Text.Trim() + "','" + txtAlamat.Text.Trim() + "'," +
                        "'" + txtNoTelp.Text.Trim() + "','" + txtNoHP.Text.Trim() + "','" + txtFax.Text.Trim() + "'," +
                        "'" + txtEmail.Text.Trim() + "','" + txtNPWP.Text.Trim() + "','" + txtWebsite.Text.Trim() + "'," +
                        "'" + txtCatatan.Text.Trim() + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                        "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'");

                    qry.InsertLogAktivitas("Simpan", this, lblID.Text, userName);
                    fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Simpan " + this.Name.ToString() + " " + lblID.Text + " " + txtNama.Text.Trim() + " Berhasil",
                        frmUtama.tooltip_x, frmUtama.tooltip_y, "info");
                    id = lblID.Text;
                    //Clear(); tidak perlu di clear
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
                if (qry.DataExist(this, "Simpan", lblID.Text, txtNama.Text.Trim(), "id", "datausaha", "id = '" + lblID.Text + "'"))
                {
                    try
                    {
                        qry.UpdateData("datausaha",
                            "nama = ''," +
                            "alamat = ''," +
                            "telp = ''," +
                            "nohp = ''," +
                            "fax = ''," +
                            "email = ''," +
                            "npwp = ''," +
                            "website = ''," +
                            "catatan = ''," +
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
                        psn.CreateLogErrorForm(this, "Hapus", "Hapus " + lblID.Text + " Gagal", ex.ToString());
                    }
                }
            }
        }
        #endregion

        private void DataPerusahaan_Load(object sender, EventArgs e)
        {
            TampilData("1");
            frmUtama.lblNamaForm.Text = "- Data Perusahaan";
            UsrAccess();
        }

        private void DataPerusahaan_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
