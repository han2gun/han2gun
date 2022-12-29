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
    public partial class UserMgmt : Form
    {
        cls.Fungsi fs = new cls.Fungsi();
        cls.Pesan psn = new cls.Pesan();
        cls.Query qry = new cls.Query();

        TextBox[] txtClear;
        CheckBox[] grpDataPerusahaan, grpKaryawan, grpPelanggan, grpPemasok, grpKategori, grpBarang, 
            grpPembelian, grpReturPembelian, grpHutang, grpGudangMasuk, grpPindahGudang, grpDiskon, 
            grpPenjualan, grpReturPenjualan, grpPiutang, grpKas, grpPenyesuaian, grpPengaturanPengguna, 
            grpUbahPassword, grpLaporan, grpUtama;

        MenuUtama frmUtama;
        public string userName;

        public string id;
        string idUpdate;
        bool updateData;

        public UserMgmt(MenuUtama mnutama)
        {
            InitializeComponent();

            frmUtama = mnutama;
            idUpdate = "";
            updateData = false;
            txtClear = new TextBox[] { txtPassword, txtPengguna };
            grpDataPerusahaan = new CheckBox[] { dataperusahaansv, dataperusahaandel, dataperusahaanup };
            grpKaryawan = new CheckBox[] { karyawansv, karyawandel, karyawanprt, karyawanup };
            grpPelanggan = new CheckBox[] { pelanggansv, pelanggandel, pelangganprt, pelangganup };
            grpPemasok = new CheckBox[] { pemasoksv, pemasokdel, pemasokprt, pemasokup };
            grpKategori = new CheckBox[] { kategorisv, kategoridel, kategoriprt, kategoriup };
            grpBarang = new CheckBox[] { barangsv, barangdel, barangprt, barangup, barangstokrp };
            grpPembelian = new CheckBox[] { pembeliansv, pembeliandel, pembelianprt, pembelianup };
            grpReturPembelian = new CheckBox[] { returpembeliansv, returpembeliandel, returpembelianprt, returpembelianup };
            grpHutang = new CheckBox[] { hutangsv, hutangdel, hutangup };
            grpGudangMasuk = new CheckBox[] { gudangmasuksv, gudangmasukdel, gudangmasukprt, gudangmasukup };
            grpPindahGudang = new CheckBox[] { pindahgudangsv, pindahgudangdel, pindahgudangprt, pindahgudangup };
            grpDiskon = new CheckBox[] { diskonsv, diskondel, diskonprt, diskonup };
            grpPenjualan = new CheckBox[] { penjualansv, penjualandel, penjualanprt, penjualanup };
            grpReturPenjualan = new CheckBox[] { returpenjualansv, returpenjualandel, returpenjualanprt, returpenjualanup };
            grpPiutang = new CheckBox[] { piutangsv, piutangdel, piutangup };
            grpKas = new CheckBox[] { kassv, kasdel, kasprt, kasup };
            grpPenyesuaian = new CheckBox[] { penyesuaiansv, penyesuaiandel, penyesuaianprt, penyesuaianup };
            grpPengaturanPengguna = new CheckBox[] { usrmgmtsv, usrmgmtdel, usrmgmtreset, usrmgmtup };
            grpUbahPassword = new CheckBox[] { ubahpasssv };
            grpLaporan = new CheckBox[] { lappembelianperiode, lappembeliansupplier, lappembelianbarang, cekhargabelibarang,
                lapgudangmasukperiode, lapgudangmasukbarang, lapgudangmasukkartustok, lapgudangmasukstok,
                lappindahgudangperiode, lappindahgudangbarang, lappindahgudangkartustok, lappindahgudangstok,
                lappenjualanperiode, lappenjualancustomer, lappenjualanbarang, lappenjualankategori,
                laprlpenjualanperiode, laprlpenjualanbarang, laprlpenjualankategori,
                lapkasperiode,
                lapreturpembelianperiode,lapreturpembeliansupplier,lapreturpembelianbarang,
                lapreturpenjualanperiode,lapreturpenjualancustomer,lapreturpenjualanbarang,
                lappenggunaanaplikasi,
                lapmutasistok};
            grpUtama = new CheckBox[] { dataperusahaan, karyawan, pelanggan, pemasok, kategori, barang, pembelian,
                returpembelian, gudangmasuk, pindahgudang, hutang, diskon, penjualan, returpenjualan, piutang, kas,
                penyesuaian, usrmgmt, ubahpass, backupdb, restoredb };
            this.KeyDown += new KeyEventHandler(this.OnKeyDown);
            cboRole.SelectedIndex = 0;
            ActiveControl = txtUserName;
        }

        #region code
        private void UsrAccess()
        {
            string data = qry.GetData(this, "UsrAccess", userName, 0,
                "usrmgmtsv,usrmgmtdel,usrmgmtreset,usrmgmtup", "usrmgmt", "usrname = '" + userName + "'");

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
                        btnResetPass.Enabled = true;
                    if (filldata[3] == "1")
                        updateData = true;

                    qry.InsertLogAktivitas("UsrAccess", this, userName, userName);
                }
            }
        }

        private void Clear(bool pbAll)
        {
            if (pbAll)
            {
                txtUserName.Text = "";
                txtUserName.Focus();
            }
            fs.ClearCheckBox(this.Controls);
            fs.ClearTextBoxArray(txtClear);
            cboRole.SelectedIndex = 0;
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
                    if (txtUserName.Text == "")
                    {
                        psn.PesanInfo("User Name Masih Kosong");
                        txtUserName.Focus();
                    }
                    else if (txtPassword.Text == "")
                    {
                        psn.PesanInfo("Password Masih Kosong");
                        txtPassword.Focus();
                    }
                    else if (txtPengguna.Text == "")
                    {
                        psn.PesanInfo("Pengguna Masih Kosong");
                        txtPengguna.Focus();
                    }
                    else if (cboRole.Text == "")
                    {
                        psn.PesanInfo("Role Pengguna Masih Kosong");
                        cboRole.Focus();
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
                    if (txtUserName.Text == "")
                    {
                        psn.PesanInfo("User Name Masih Kosong");
                    }
                    else
                    {
                        Hapus();
                    }
                    break;
                case "KELUAR":
                    cls.OpenForm op = new cls.OpenForm(frmUtama);
                    op.PencarianOpen("Pencarian", "PengaturanPengguna", userName);
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
                case Keys.F10:
                    SelectToolBar(btnKeluar);
                    break;
                default:
                    break;
            }
        }

        private void TampilData(string id)
        {
            Clear(false);

            string data = qry.GetData(this, "TampilData", id, txtUserName.Text.Length,
                "usrname,namauser,pass,roleusr," +
                "identitas,identitassv,identitasdel,identitasup," +
                "karyawan,karyawansv,karyawandel,karyawanprt,karyawanup," +
                "pelanggan,pelanggansv,pelanggandel,pelangganprt,pelangganup," +
                "pemasok,pemasoksv,pemasokdel,pemasokprt,pemasokup," +
                "kelbarang,kelbarangsv,kelbarangdel,kelbarangprt,kelbarangup," +
                "barang,barangsv,barangdel,barangprt,barangup,barangstokrp," +
                "pembelian,pembeliansv,pembeliandel,pembelianprt,pembelianup," +
                "returpembelian,returpembeliansv,returpembeliandel,returpembelianprt,returpembelianup," +
                "hutang,hutangsv,hutangdel,hutangup," +
                "penyesuaian,penyesuaiansv,penyesuaiandel,penyesuaianprt,penyesuaianup," +
                "gudangmasuk,gudangmasuksv,gudangmasukdel,gudangmasukprt,gudangmasukup," +
                "pindahgudang,pindahgudangsv,pindahgudangdel,pindahgudangprt,pindahgudangup," +
                "diskon,diskonsv,diskondel,diskonprt,diskonup," +
                "penjualan,penjualansv,penjualandel,penjualanprt,penjualanup," +
                "returpenjualan,returpenjualansv,returpenjualandel,returpenjualanprt,returpenjualanup," +
                "piutang,piutangsv,piutangdel,piutangup," +
                "kas,kassv,kasdel,kasprt,kasup," +
                "lappembelianperiode,lappembeliansupplier,lappembelianbarang,cekhargabelibarang," +
                "lapgudangmasukperiode,lapgudangmasukbarang,lapgudangmasukkartustok,lapgudangmasukstok," +
                "lappindahgudangperiode,lappindahgudangbarang,lappindahgudangkartustok,lappindahgudangstok," +
                "lappenjualanperiode,lappenjualancustomer,lappenjualanbarang,lappenjualankategori," +
                "laprlpenjualanperiode,laprlpenjualanbarang,laprlpenjualankategori," +
                "lapkasperiode," +
                "lapreturpembelianperiode, lapreturpembeliansupplier, lapreturpembelianbarang, " +
                "lapreturpenjualanperiode,lapreturpenjualancustomer,lapreturpenjualanbarang," +
                "lappenggunaanaplikasi," +
                "lapmutasistok," +
                "usrmgmt,usrmgmtsv,usrmgmtdel,usrmgmtreset,usrmgmtup," +
                "ubahpassword,ubahpasswordsv,backupdb,restoredb", "usrmgmt", "usrname = '" + id + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    idUpdate = filldata[0]; //jika kosong berarti data baru, jika muncul id data lama -> cek status boleh update atau tidak
                    txtPengguna.Text = filldata[1];
                    txtPassword.Text = filldata[2];
                    cboRole.Text = filldata[3];
                    dataperusahaan.Checked = fs.IntToBool(filldata[4]);
                    dataperusahaansv.Checked = fs.IntToBool(filldata[5]);
                    dataperusahaandel.Checked = fs.IntToBool(filldata[6]);
                    dataperusahaanup.Checked = fs.IntToBool(filldata[7]);
                    karyawan.Checked = fs.IntToBool(filldata[8]);
                    karyawansv.Checked = fs.IntToBool(filldata[9]);
                    karyawandel.Checked = fs.IntToBool(filldata[10]);
                    karyawanprt.Checked = fs.IntToBool(filldata[11]);
                    karyawanup.Checked = fs.IntToBool(filldata[12]);
                    pelanggan.Checked = fs.IntToBool(filldata[13]);
                    pelanggansv.Checked = fs.IntToBool(filldata[14]);
                    pelanggandel.Checked = fs.IntToBool(filldata[15]);
                    pelangganprt.Checked = fs.IntToBool(filldata[16]);
                    pelangganup.Checked = fs.IntToBool(filldata[17]);
                    pemasok.Checked = fs.IntToBool(filldata[18]);
                    pemasoksv.Checked = fs.IntToBool(filldata[19]);
                    pemasokdel.Checked = fs.IntToBool(filldata[20]);
                    pemasokprt.Checked = fs.IntToBool(filldata[21]);
                    pemasokup.Checked = fs.IntToBool(filldata[22]);
                    kategori.Checked = fs.IntToBool(filldata[23]);
                    kategorisv.Checked = fs.IntToBool(filldata[24]);
                    kategoridel.Checked = fs.IntToBool(filldata[25]);
                    kategoriprt.Checked = fs.IntToBool(filldata[26]);
                    kategoriup.Checked = fs.IntToBool(filldata[27]);
                    barang.Checked = fs.IntToBool(filldata[28]);
                    barangsv.Checked = fs.IntToBool(filldata[29]);
                    barangdel.Checked = fs.IntToBool(filldata[30]);
                    barangprt.Checked = fs.IntToBool(filldata[31]);
                    barangup.Checked = fs.IntToBool(filldata[32]);
                    barangstokrp.Checked = fs.IntToBool(filldata[33]);
                    pembelian.Checked = fs.IntToBool(filldata[34]);
                    pembeliansv.Checked = fs.IntToBool(filldata[35]);
                    pembeliandel.Checked = fs.IntToBool(filldata[36]);
                    pembelianprt.Checked = fs.IntToBool(filldata[37]);
                    pembelianup.Checked = fs.IntToBool(filldata[38]);
                    returpembelian.Checked = fs.IntToBool(filldata[39]);
                    returpembeliansv.Checked = fs.IntToBool(filldata[40]);
                    returpembeliandel.Checked = fs.IntToBool(filldata[41]);
                    returpembelianprt.Checked = fs.IntToBool(filldata[42]);
                    returpembelianup.Checked = fs.IntToBool(filldata[43]);
                    hutang.Checked = fs.IntToBool(filldata[44]);
                    hutangsv.Checked = fs.IntToBool(filldata[45]);
                    hutangdel.Checked = fs.IntToBool(filldata[46]);
                    hutangup.Checked = fs.IntToBool(filldata[47]);
                    penyesuaian.Checked = fs.IntToBool(filldata[48]);
                    penyesuaiansv.Checked = fs.IntToBool(filldata[49]);
                    penyesuaiandel.Checked = fs.IntToBool(filldata[50]);
                    penyesuaianprt.Checked = fs.IntToBool(filldata[51]);
                    penyesuaianup.Checked = fs.IntToBool(filldata[52]);
                    gudangmasuk.Checked = fs.IntToBool(filldata[53]);
                    gudangmasuksv.Checked = fs.IntToBool(filldata[54]);
                    gudangmasukdel.Checked = fs.IntToBool(filldata[55]);
                    gudangmasukprt.Checked = fs.IntToBool(filldata[56]);
                    gudangmasukup.Checked = fs.IntToBool(filldata[57]);
                    pindahgudang.Checked = fs.IntToBool(filldata[58]);
                    pindahgudangsv.Checked = fs.IntToBool(filldata[59]);
                    pindahgudangdel.Checked = fs.IntToBool(filldata[60]);
                    pindahgudangprt.Checked = fs.IntToBool(filldata[61]);
                    pindahgudangup.Checked = fs.IntToBool(filldata[62]);
                    diskon.Checked = fs.IntToBool(filldata[63]);
                    diskonsv.Checked = fs.IntToBool(filldata[64]);
                    diskondel.Checked = fs.IntToBool(filldata[65]);
                    diskonprt.Checked = fs.IntToBool(filldata[66]);
                    diskonup.Checked = fs.IntToBool(filldata[67]);
                    penjualan.Checked = fs.IntToBool(filldata[68]);
                    penjualansv.Checked = fs.IntToBool(filldata[69]);
                    penjualandel.Checked = fs.IntToBool(filldata[70]);
                    penjualanprt.Checked = fs.IntToBool(filldata[71]);
                    penjualanup.Checked = fs.IntToBool(filldata[72]);
                    returpenjualan.Checked = fs.IntToBool(filldata[73]);
                    returpenjualansv.Checked = fs.IntToBool(filldata[74]);
                    returpenjualandel.Checked = fs.IntToBool(filldata[75]);
                    returpenjualanprt.Checked = fs.IntToBool(filldata[76]);
                    returpenjualanup.Checked = fs.IntToBool(filldata[77]);
                    piutang.Checked = fs.IntToBool(filldata[78]);
                    piutangsv.Checked = fs.IntToBool(filldata[79]);
                    piutangdel.Checked = fs.IntToBool(filldata[80]);
                    piutangup.Checked = fs.IntToBool(filldata[81]);
                    kas.Checked = fs.IntToBool(filldata[82]);
                    kassv.Checked = fs.IntToBool(filldata[83]);
                    kasdel.Checked = fs.IntToBool(filldata[84]);
                    kasprt.Checked = fs.IntToBool(filldata[85]);
                    kasup.Checked = fs.IntToBool(filldata[86]);
                    lappembelianperiode.Checked = fs.IntToBool(filldata[87]);
                    lappembeliansupplier.Checked = fs.IntToBool(filldata[88]);
                    lappembelianbarang.Checked = fs.IntToBool(filldata[89]);
                    cekhargabelibarang.Checked = fs.IntToBool(filldata[90]);
                    lapgudangmasukperiode.Checked = fs.IntToBool(filldata[91]);
                    lapgudangmasukbarang.Checked = fs.IntToBool(filldata[92]);
                    lapgudangmasukkartustok.Checked = fs.IntToBool(filldata[93]);
                    lapgudangmasukstok.Checked = fs.IntToBool(filldata[94]);
                    lappindahgudangperiode.Checked = fs.IntToBool(filldata[95]);
                    lappindahgudangbarang.Checked = fs.IntToBool(filldata[96]);
                    lappindahgudangkartustok.Checked = fs.IntToBool(filldata[97]);
                    lappindahgudangstok.Checked = fs.IntToBool(filldata[98]);
                    lappenjualanperiode.Checked = fs.IntToBool(filldata[99]);
                    lappenjualancustomer.Checked = fs.IntToBool(filldata[100]);
                    lappenjualanbarang.Checked = fs.IntToBool(filldata[101]);
                    lappenjualankategori.Checked = fs.IntToBool(filldata[102]);
                    laprlpenjualanperiode.Checked = fs.IntToBool(filldata[103]);
                    laprlpenjualanbarang.Checked = fs.IntToBool(filldata[104]);
                    laprlpenjualankategori.Checked = fs.IntToBool(filldata[105]);
                    lapkasperiode.Checked = fs.IntToBool(filldata[106]);
                    lapreturpembelianperiode.Checked = fs.IntToBool(filldata[107]);
                    lapreturpembeliansupplier.Checked = fs.IntToBool(filldata[108]);
                    lapreturpembelianbarang.Checked = fs.IntToBool(filldata[109]);
                    lapreturpenjualanperiode.Checked = fs.IntToBool(filldata[110]);
                    lapreturpenjualancustomer.Checked = fs.IntToBool(filldata[111]);
                    lapreturpenjualanbarang.Checked = fs.IntToBool(filldata[112]);
                    lappenggunaanaplikasi.Checked = fs.IntToBool(filldata[113]);
                    lapmutasistok.Checked = fs.IntToBool(filldata[114]);
                    usrmgmt.Checked = fs.IntToBool(filldata[115]);
                    usrmgmtsv.Checked = fs.IntToBool(filldata[116]);
                    usrmgmtdel.Checked = fs.IntToBool(filldata[117]);
                    usrmgmtreset.Checked = fs.IntToBool(filldata[118]);
                    usrmgmtup.Checked = fs.IntToBool(filldata[119]);
                    ubahpass.Checked = fs.IntToBool(filldata[120]);
                    ubahpasssv.Checked = fs.IntToBool(filldata[121]);
                    backupdb.Checked = fs.IntToBool(filldata[122]);
                    restoredb.Checked = fs.IntToBool(filldata[123]);

                    qry.InsertLogAktivitas("TampilData", this, txtUserName.Text.Trim(), userName);
                }
            }
        }

        private void ResetPass()
        {
            if (txtUserName.Text != "")
            {
                if (qry.DataExist(this, "ResetPass", txtUserName.Text, txtPengguna.Text.Trim(), "usrname", "usrmgmt", "usrname = '" + txtUserName.Text + "'"))
                {
                    qry.UpdateData("usrmgmt", "pass = password('" + txtUserName.Text.Trim() + "')", "usrname = '" + txtUserName.Text.Trim() + "'");
                }
            }
            else
            {
                psn.PesanInfo("User Name Masih Kosong");
            }
        }

        private void Simpan()
        {
            if (qry.DataExist(this, "Simpan", txtUserName.Text, txtPengguna.Text.Trim(), "usrname", "usrmgmt", "usrname = '" + txtUserName.Text + "'"))
            {
                try
                {
                    qry.UpdateData("usrmgmt",
                        "namauser = '" + txtPengguna.Text.Trim() + "'," +
                        "roleusr = '" + cboRole.Text + "'," +
                        "identitas = " + fs.BoolToInt(dataperusahaan.Checked) + "," +
                        "identitassv = " + fs.BoolToInt(dataperusahaansv.Checked) + "," +
                        "identitasdel = " + fs.BoolToInt(dataperusahaandel.Checked) + "," +
                        "identitasup = " + fs.BoolToInt(dataperusahaanup.Checked) + "," +
                        "karyawan = " + fs.BoolToInt(karyawan.Checked) + "," +
                        "karyawansv = " + fs.BoolToInt(karyawansv.Checked) + "," +
                        "karyawandel = " + fs.BoolToInt(karyawandel.Checked) + "," +
                        "karyawanprt = " + fs.BoolToInt(karyawanprt.Checked) + "," +
                        "karyawanup = " + fs.BoolToInt(karyawanup.Checked) + "," +
                        "pelanggan = " + fs.BoolToInt(pelanggan.Checked) + "," +
                        "pelanggansv = " + fs.BoolToInt(pelanggansv.Checked) + "," +
                        "pelanggandel = " + fs.BoolToInt(pelanggandel.Checked) + "," +
                        "pelangganprt = " + fs.BoolToInt(pelangganprt.Checked) + "," +
                        "pelangganup = " + fs.BoolToInt(pelangganup.Checked) + "," +
                        "pemasok = " + fs.BoolToInt(pemasok.Checked) + "," +
                        "pemasoksv = " + fs.BoolToInt(pemasoksv.Checked) + "," +
                        "pemasokdel = " + fs.BoolToInt(pemasokdel.Checked) + "," +
                        "pemasokprt = " + fs.BoolToInt(pemasokprt.Checked) + "," +
                        "pemasokup = " + fs.BoolToInt(pemasokup.Checked) + "," +
                        "kelbarang = " + fs.BoolToInt(kategori.Checked) + "," +
                        "kelbarangsv = " + fs.BoolToInt(kategorisv.Checked) + "," +
                        "kelbarangdel = " + fs.BoolToInt(kategoridel.Checked) + "," +
                        "kelbarangprt = " + fs.BoolToInt(kategoriprt.Checked) + "," +
                        "kelbarangup = " + fs.BoolToInt(kategoriup.Checked) + "," +
                        "barang = " + fs.BoolToInt(barang.Checked) + "," +
                        "barangsv = " + fs.BoolToInt(barangsv.Checked) + "," +
                        "barangdel = " + fs.BoolToInt(barangdel.Checked) + "," +
                        "barangprt = " + fs.BoolToInt(barangprt.Checked) + "," +
                        "barangup = " + fs.BoolToInt(barangup.Checked) + "," +
                        "barangstokrp = " + fs.BoolToInt(barangstokrp.Checked) + "," +
                        "pembelian = " + fs.BoolToInt(pembelian.Checked) + "," +
                        "pembeliansv = " + fs.BoolToInt(pembeliansv.Checked) + "," +
                        "pembeliandel = " + fs.BoolToInt(pembeliandel.Checked) + "," +
                        "pembelianprt = " + fs.BoolToInt(pembelianprt.Checked) + "," +
                        "pembelianup = " + fs.BoolToInt(pembelianup.Checked) + "," +
                        "returpembelian = " + fs.BoolToInt(returpembelian.Checked) + "," +
                        "returpembeliansv = " + fs.BoolToInt(returpembeliansv.Checked) + "," +
                        "returpembeliandel = " + fs.BoolToInt(returpembeliandel.Checked) + "," +
                        "returpembelianprt = " + fs.BoolToInt(returpembelianprt.Checked) + "," +
                        "returpembelianup = " + fs.BoolToInt(returpembelianup.Checked) + "," +
                        "hutang = " + fs.BoolToInt(hutang.Checked) + "," +
                        "hutangsv = " + fs.BoolToInt(hutangsv.Checked) + "," +
                        "hutangdel = " + fs.BoolToInt(hutangdel.Checked) + "," +
                        "hutangup = " + fs.BoolToInt(hutangup.Checked) + "," +
                        "penyesuaian = " + fs.BoolToInt(penyesuaian.Checked) + "," +
                        "penyesuaiansv = " + fs.BoolToInt(penyesuaiansv.Checked) + "," +
                        "penyesuaiandel = " + fs.BoolToInt(penyesuaiandel.Checked) + "," +
                        "penyesuaianprt = " + fs.BoolToInt(penyesuaianprt.Checked) + "," +
                        "penyesuaianup = " + fs.BoolToInt(penyesuaianup.Checked) + "," +
                        "gudangmasuk = " + fs.BoolToInt(gudangmasuk.Checked) + "," +
                        "gudangmasuksv = " + fs.BoolToInt(gudangmasuksv.Checked) + "," +
                        "gudangmasukdel = " + fs.BoolToInt(gudangmasukdel.Checked) + "," +
                        "gudangmasukprt = " + fs.BoolToInt(gudangmasukprt.Checked) + "," +
                        "gudangmasukup = " + fs.BoolToInt(gudangmasukup.Checked) + "," +
                        "pindahgudang = " + fs.BoolToInt(pindahgudang.Checked) + "," +
                        "pindahgudangsv = " + fs.BoolToInt(pindahgudangsv.Checked) + "," +
                        "pindahgudangdel = " + fs.BoolToInt(pindahgudangdel.Checked) + "," +
                        "pindahgudangprt = " + fs.BoolToInt(pindahgudangprt.Checked) + "," +
                        "pindahgudangup = " + fs.BoolToInt(pindahgudangup.Checked) + "," +
                        "diskon = " + fs.BoolToInt(diskon.Checked) + "," +
                        "diskonsv = " + fs.BoolToInt(diskonsv.Checked) + "," +
                        "diskondel = " + fs.BoolToInt(diskondel.Checked) + "," +
                        "diskonprt = " + fs.BoolToInt(diskonprt.Checked) + "," +
                        "diskonup = " + fs.BoolToInt(diskonup.Checked) + "," +
                        "penjualan = " + fs.BoolToInt(penjualan.Checked) + "," +
                        "penjualansv = " + fs.BoolToInt(penjualansv.Checked) + "," +
                        "penjualandel = " + fs.BoolToInt(penjualandel.Checked) + "," +
                        "penjualanprt = " + fs.BoolToInt(penjualanprt.Checked) + "," +
                        "penjualanup = " + fs.BoolToInt(penjualanup.Checked) + "," +
                        "returpenjualan = " + fs.BoolToInt(returpenjualan.Checked) + "," +
                        "returpenjualansv = " + fs.BoolToInt(returpenjualansv.Checked) + "," +
                        "returpenjualandel = " + fs.BoolToInt(returpenjualandel.Checked) + "," +
                        "returpenjualanprt = " + fs.BoolToInt(returpenjualanprt.Checked) + "," +
                        "returpenjualanup = " + fs.BoolToInt(returpenjualanup.Checked) + "," +
                        "piutang = " + fs.BoolToInt(piutang.Checked) + "," +
                        "piutangsv = " + fs.BoolToInt(piutangsv.Checked) + "," +
                        "piutangdel = " + fs.BoolToInt(piutangdel.Checked) + "," +
                        "piutangup = " + fs.BoolToInt(piutangup.Checked) + "," +
                        "kas = " + fs.BoolToInt(kas.Checked) + "," +
                        "kassv = " + fs.BoolToInt(kassv.Checked) + "," +
                        "kasdel = " + fs.BoolToInt(kasdel.Checked) + "," +
                        "kasprt = " + fs.BoolToInt(kasprt.Checked) + "," +
                        "kasup = " + fs.BoolToInt(kasup.Checked) + "," +
                        "lappembelianperiode = " + fs.BoolToInt(lappembelianperiode.Checked) + "," +
                        "lappembeliansupplier = " + fs.BoolToInt(lappembeliansupplier.Checked) + "," +
                        "lappembelianbarang = " + fs.BoolToInt(lappembelianbarang.Checked) + "," +
                        "cekhargabelibarang = " + fs.BoolToInt(cekhargabelibarang.Checked) + "," +
                        "lapgudangmasukperiode = " + fs.BoolToInt(lapgudangmasukperiode.Checked) + "," +
                        "lapgudangmasukbarang = " + fs.BoolToInt(lapgudangmasukbarang.Checked) + "," +
                        "lapgudangmasukkartustok = " + fs.BoolToInt(lapgudangmasukkartustok.Checked) + "," +
                        "lapgudangmasukstok = " + fs.BoolToInt(lapgudangmasukstok.Checked) + "," +
                        "lappindahgudangperiode = " + fs.BoolToInt(lappindahgudangperiode.Checked) + "," +
                        "lappindahgudangbarang = " + fs.BoolToInt(lappindahgudangbarang.Checked) + "," +
                        "lappindahgudangkartustok = " + fs.BoolToInt(lappindahgudangkartustok.Checked) + "," +
                        "lappindahgudangstok = " + fs.BoolToInt(lappindahgudangstok.Checked) + "," +
                        "lappenjualanperiode = " + fs.BoolToInt(lappenjualanperiode.Checked) + "," +
                        "lappenjualancustomer = " + fs.BoolToInt(lappenjualancustomer.Checked) + "," +
                        "lappenjualanbarang = " + fs.BoolToInt(lappenjualanbarang.Checked) + "," +
                        "lappenjualankategori = " + fs.BoolToInt(lappenjualankategori.Checked) + "," +
                        "laprlpenjualanperiode = " + fs.BoolToInt(laprlpenjualanperiode.Checked) + "," +
                        "laprlpenjualanbarang = " + fs.BoolToInt(laprlpenjualanbarang.Checked) + "," +
                        "laprlpenjualankategori = " + fs.BoolToInt(laprlpenjualankategori.Checked) + "," +
                        "lapkasperiode = " + fs.BoolToInt(lapkasperiode.Checked) + "," +
                        "lapreturpembelianperiode = " + fs.BoolToInt(lapreturpembelianperiode.Checked) + "," +
                        "lapreturpembeliansupplier = " + fs.BoolToInt(lapreturpembeliansupplier.Checked) + "," +
                        "lapreturpembelianbarang = " + fs.BoolToInt(lapreturpembelianbarang.Checked) + "," +
                        "lapreturpenjualanperiode = " + fs.BoolToInt(lapreturpenjualanperiode.Checked) + "," +
                        "lapreturpenjualancustomer = " + fs.BoolToInt(lapreturpenjualancustomer.Checked) + "," +
                        "lapreturpenjualanbarang = " + fs.BoolToInt(lapreturpenjualanbarang.Checked) + "," +
                        "lappenggunaanaplikasi = " + fs.BoolToInt(lappenggunaanaplikasi.Checked) + "," +
                        "lapmutasistok = " + fs.BoolToInt(lapmutasistok.Checked) + "," +
                        "usrmgmt = " + fs.BoolToInt(usrmgmt.Checked) + "," +
                        "usrmgmtsv = " + fs.BoolToInt(usrmgmtsv.Checked) + "," +
                        "usrmgmtdel = " + fs.BoolToInt(usrmgmtdel.Checked) + "," +
                        "usrmgmtreset = " + fs.BoolToInt(usrmgmtreset.Checked) + "," +
                        "usrmgmtup = " + fs.BoolToInt(usrmgmtup.Checked) + "," +
                        "ubahpassword = " + fs.BoolToInt(ubahpass.Checked) + "," +
                        "ubahpasswordsv = " + fs.BoolToInt(ubahpasssv.Checked) + "," +
                        "backupdb = " + fs.BoolToInt(backupdb.Checked) + "," +
                        "restoredb = " + fs.BoolToInt(restoredb.Checked) + "," +
                        "tglupdate = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'",
                        "usrname = '" + txtUserName.Text + "'");

                    qry.InsertLogAktivitas("Update", this, txtUserName.Text, userName);
                    fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Update " + txtUserName.Text + " Berhasil", frmUtama.tooltip_x, frmUtama.tooltip_y, "info");
                    Clear(true);
                }
                catch (Exception ex)
                {
                    psn.CreateLogErrorForm(this, "Update", "Update " + txtUserName.Text + " Gagal", ex.ToString());
                }
            }
            else
            {
                try
                {
                    qry.InsertData("usrmgmt",
                        "usrname,namauser,pass,roleusr," +
                        "identitas,identitassv,identitasdel,identitasup," +
                        "karyawan,karyawansv,karyawandel,karyawanprt,karyawanup," +
                        "pelanggan,pelanggansv,pelanggandel,pelangganprt,pelangganup," +
                        "pemasok,pemasoksv,pemasokdel,pemasokprt,pemasokup," +
                        "kelbarang,kelbarangsv,kelbarangdel,kelbarangprt,kelbarangup," +
                        "barang,barangsv,barangdel,barangprt,barangup,barangstokrp," +
                        "pembelian,pembeliansv,pembeliandel,pembelianprt,pembelianup," +
                        "returpembelian,returpembeliansv,returpembeliandel,returpembelianprt,returpembelianup," +
                        "hutang,hutangsv,hutangdel,hutangup," +
                        "penyesuaian,penyesuaiansv,penyesuaiandel,penyesuaianprt,penyesuaianup," +
                        "gudangmasuk,gudangmasuksv,gudangmasukdel,gudangmasukprt,gudangmasukup," +
                        "pindahgudang,pindahgudangsv,pindahgudangdel,pindahgudangprt,pindahgudangup," +
                        "diskon,diskonsv,diskondel,diskonprt,diskonup," +
                        "penjualan,penjualansv,penjualandel,penjualanprt,penjualanup," +
                        "returpenjualan,returpenjualansv,returpenjualandel,returpenjualanprt,returpenjualanup," +
                        "piutang,piutangsv,piutangdel,piutangup," +
                        "kas,kassv,kasdel,kasprt,kasup," +
                        "lappembelianperiode,lappembeliansupplier,lappembelianbarang,cekhargabelibarang," +
                        "lapgudangmasukperiode,lapgudangmasukbarang,lapgudangmasukkartustok,lapgudangmasukstok," +
                        "lappindahgudangperiode,lappindahgudangbarang,lappindahgudangkartustok,lappindahgudangstok," +
                        "lappenjualanperiode,lappenjualancustomer,lappenjualanbarang,lappenjualankategori," +
                        "laprlpenjualanperiode,laprlpenjualanbarang,laprlpenjualankategori," +
                        "lapkasperiode," +
                        "lapreturpembelianperiode, lapreturpembeliansupplier, lapreturpembelianbarang, " +
                        "lapreturpenjualanperiode,lapreturpenjualancustomer,lapreturpenjualanbarang," +
                        "lappenggunaanaplikasi," +
                        "lapmutasistok," +
                        "usrmgmt,usrmgmtsv,usrmgmtdel,usrmgmtreset,usrmgmtup," +
                        "ubahpassword,ubahpasswordsv,backupdb,restoredb,tglinput,tglupdate",
                        "'" + txtUserName.Text.Trim() + "','" + txtPengguna.Text.Trim() + "',password('" + txtPassword.Text.Trim() + "'),'" + cboRole.Text + "'," +
                        "" + fs.BoolToInt(dataperusahaan.Checked) + "," +
                        "" + fs.BoolToInt(dataperusahaansv.Checked) + "," +
                        "" + fs.BoolToInt(dataperusahaandel.Checked) + "," +
                        "" + fs.BoolToInt(dataperusahaanup.Checked) + "," +
                        "" + fs.BoolToInt(karyawan.Checked) + "," +
                        "" + fs.BoolToInt(karyawansv.Checked) + "," +
                        "" + fs.BoolToInt(karyawandel.Checked) + "," +
                        "" + fs.BoolToInt(karyawanprt.Checked) + "," +
                        "" + fs.BoolToInt(karyawanup.Checked) + "," +
                        "" + fs.BoolToInt(pelanggan.Checked) + "," +
                        "" + fs.BoolToInt(pelanggansv.Checked) + "," +
                        "" + fs.BoolToInt(pelanggandel.Checked) + "," +
                        "" + fs.BoolToInt(pelangganprt.Checked) + "," +
                        "" + fs.BoolToInt(pelangganup.Checked) + "," +
                        "" + fs.BoolToInt(pemasok.Checked) + "," +
                        "" + fs.BoolToInt(pemasoksv.Checked) + "," +
                        "" + fs.BoolToInt(pemasokdel.Checked) + "," +
                        "" + fs.BoolToInt(pemasokprt.Checked) + "," +
                        "" + fs.BoolToInt(pemasokup.Checked) + "," +
                        "" + fs.BoolToInt(kategori.Checked) + "," +
                        "" + fs.BoolToInt(kategorisv.Checked) + "," +
                        "" + fs.BoolToInt(kategoridel.Checked) + "," +
                        "" + fs.BoolToInt(kategoriprt.Checked) + "," +
                        "" + fs.BoolToInt(kategoriup.Checked) + "," +
                        "" + fs.BoolToInt(barang.Checked) + "," +
                        "" + fs.BoolToInt(barangsv.Checked) + "," +
                        "" + fs.BoolToInt(barangdel.Checked) + "," +
                        "" + fs.BoolToInt(barangprt.Checked) + "," +
                        "" + fs.BoolToInt(barangup.Checked) + "," +
                        "" + fs.BoolToInt(barangstokrp.Checked) + "," +
                        "" + fs.BoolToInt(pembelian.Checked) + "," +
                        "" + fs.BoolToInt(pembeliansv.Checked) + "," +
                        "" + fs.BoolToInt(pembeliandel.Checked) + "," +
                        "" + fs.BoolToInt(pembelianprt.Checked) + "," +
                        "" + fs.BoolToInt(pembelianup.Checked) + "," +
                        "" + fs.BoolToInt(returpembelian.Checked) + "," +
                        "" + fs.BoolToInt(returpembeliansv.Checked) + "," +
                        "" + fs.BoolToInt(returpembeliandel.Checked) + "," +
                        "" + fs.BoolToInt(returpembelianprt.Checked) + "," +
                        "" + fs.BoolToInt(returpembelianup.Checked) + "," +
                        "" + fs.BoolToInt(hutang.Checked) + "," +
                        "" + fs.BoolToInt(hutangsv.Checked) + "," +
                        "" + fs.BoolToInt(hutangdel.Checked) + "," +
                        "" + fs.BoolToInt(hutangup.Checked) + "," +
                        "" + fs.BoolToInt(penyesuaian.Checked) + "," +
                        "" + fs.BoolToInt(penyesuaiansv.Checked) + "," +
                        "" + fs.BoolToInt(penyesuaiandel.Checked) + "," +
                        "" + fs.BoolToInt(penyesuaianprt.Checked) + "," +
                        "" + fs.BoolToInt(penyesuaianup.Checked) + "," +
                        "" + fs.BoolToInt(gudangmasuk.Checked) + "," +
                        "" + fs.BoolToInt(gudangmasuksv.Checked) + "," +
                        "" + fs.BoolToInt(gudangmasukdel.Checked) + "," +
                        "" + fs.BoolToInt(gudangmasukprt.Checked) + "," +
                        "" + fs.BoolToInt(gudangmasukup.Checked) + "," +
                        "" + fs.BoolToInt(pindahgudang.Checked) + "," +
                        "" + fs.BoolToInt(pindahgudangsv.Checked) + "," +
                        "" + fs.BoolToInt(pindahgudangdel.Checked) + "," +
                        "" + fs.BoolToInt(pindahgudangprt.Checked) + "," +
                        "" + fs.BoolToInt(pindahgudangup.Checked) + "," +
                        "" + fs.BoolToInt(diskon.Checked) + "," +
                        "" + fs.BoolToInt(diskonsv.Checked) + "," +
                        "" + fs.BoolToInt(diskondel.Checked) + "," +
                        "" + fs.BoolToInt(diskonprt.Checked) + "," +
                        "" + fs.BoolToInt(diskonup.Checked) + "," +
                        "" + fs.BoolToInt(penjualan.Checked) + "," +
                        "" + fs.BoolToInt(penjualansv.Checked) + "," +
                        "" + fs.BoolToInt(penjualandel.Checked) + "," +
                        "" + fs.BoolToInt(penjualanprt.Checked) + "," +
                        "" + fs.BoolToInt(penjualanup.Checked) + "," +
                        "" + fs.BoolToInt(returpenjualan.Checked) + "," +
                        "" + fs.BoolToInt(returpenjualansv.Checked) + "," +
                        "" + fs.BoolToInt(returpenjualandel.Checked) + "," +
                        "" + fs.BoolToInt(returpenjualanprt.Checked) + "," +
                        "" + fs.BoolToInt(returpenjualanup.Checked) + "," +
                        "" + fs.BoolToInt(piutang.Checked) + "," +
                        "" + fs.BoolToInt(piutangsv.Checked) + "," +
                        "" + fs.BoolToInt(piutangdel.Checked) + "," +
                        "" + fs.BoolToInt(piutangup.Checked) + "," +
                        "" + fs.BoolToInt(kas.Checked) + "," +
                        "" + fs.BoolToInt(kassv.Checked) + "," +
                        "" + fs.BoolToInt(kasdel.Checked) + "," +
                        "" + fs.BoolToInt(kasprt.Checked) + "," +
                        "" + fs.BoolToInt(kasup.Checked) + "," +
                        "" + fs.BoolToInt(lappembelianperiode.Checked) + "," +
                        "" + fs.BoolToInt(lappembeliansupplier.Checked) + "," +
                        "" + fs.BoolToInt(lappembelianbarang.Checked) + "," +
                        "" + fs.BoolToInt(cekhargabelibarang.Checked) + "," +
                        "" + fs.BoolToInt(lapgudangmasukperiode.Checked) + "," +
                        "" + fs.BoolToInt(lapgudangmasukbarang.Checked) + "," +
                        "" + fs.BoolToInt(lapgudangmasukkartustok.Checked) + "," +
                        "" + fs.BoolToInt(lapgudangmasukstok.Checked) + "," +
                        "" + fs.BoolToInt(lappindahgudangperiode.Checked) + "," +
                        "" + fs.BoolToInt(lappindahgudangbarang.Checked) + "," +
                        "" + fs.BoolToInt(lappindahgudangkartustok.Checked) + "," +
                        "" + fs.BoolToInt(lappindahgudangstok.Checked) + "," +
                        "" + fs.BoolToInt(lappenjualanperiode.Checked) + "," +
                        "" + fs.BoolToInt(lappenjualancustomer.Checked) + "," +
                        "" + fs.BoolToInt(lappenjualanbarang.Checked) + "," +
                        "" + fs.BoolToInt(lappenjualankategori.Checked) + "," +
                        "" + fs.BoolToInt(laprlpenjualanperiode.Checked) + "," +
                        "" + fs.BoolToInt(laprlpenjualanbarang.Checked) + "," +
                        "" + fs.BoolToInt(laprlpenjualankategori.Checked) + "," +
                        "" + fs.BoolToInt(lapkasperiode.Checked) + "," +
                        "" + fs.BoolToInt(lapreturpembelianperiode.Checked) + "," +
                        "" + fs.BoolToInt(lapreturpembeliansupplier.Checked) + "," +
                        "" + fs.BoolToInt(lapreturpembelianbarang.Checked) + "," +
                        "" + fs.BoolToInt(lapreturpenjualanperiode.Checked) + "," +
                        "" + fs.BoolToInt(lapreturpenjualancustomer.Checked) + "," +
                        "" + fs.BoolToInt(lapreturpenjualanbarang.Checked) + "," +
                        "" + fs.BoolToInt(lappenggunaanaplikasi.Checked) + "," +
                        "" + fs.BoolToInt(lapmutasistok.Checked) + "," +
                        "" + fs.BoolToInt(usrmgmt.Checked) + "," +
                        "" + fs.BoolToInt(usrmgmtsv.Checked) + "," +
                        "" + fs.BoolToInt(usrmgmtdel.Checked) + "," +
                        "" + fs.BoolToInt(usrmgmtreset.Checked) + "," +
                        "" + fs.BoolToInt(usrmgmtup.Checked) + "," +
                        "" + fs.BoolToInt(ubahpass.Checked) + "," +
                        "" + fs.BoolToInt(ubahpasssv.Checked) + "," +
                        "" + fs.BoolToInt(backupdb.Checked) + "," +
                        "" + fs.BoolToInt(restoredb.Checked) + "," +
                        "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                        "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'");

                    qry.InsertLogAktivitas("Simpan", this, txtUserName.Text.Trim(), userName);
                    fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Simpan " + txtUserName.Text + " Berhasil", frmUtama.tooltip_x, frmUtama.tooltip_y, "info");
                    Clear(true);
                }
                catch (Exception ex)
                {
                    psn.CreateLogErrorForm(this, "Simpan", "Simpan " + txtUserName.Text.Trim() + " Gagal", ex.ToString());
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
                    qry.DeleteData("usrmgmt", "usrname = '" + txtUserName.Text.Trim() + "'");

                    qry.InsertLogAktivitas("Hapus", this, txtUserName.Text.Trim(), userName);
                    psn.CreateLogSuccessForm(this, "Hapus", txtUserName.Text.Trim());
                    fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Hapus " + txtUserName.Text + " Berhasil", frmUtama.tooltip_x, frmUtama.tooltip_y, "info");

                    Clear(true);
                }
                catch (Exception e)
                {
                    psn.CreateLogErrorForm(this, "Hapus", "Hapus " + txtUserName.Text.Trim() + " Gagal", e.ToString());
                }
            }
        }
        #endregion

        private void UserMgmt_Load(object sender, EventArgs e)
        {
            if (id != "")
                txtUserName.Text = id;

            if (txtUserName.Text.Trim() != "")
                TampilData(txtUserName.Text.Trim());

            frmUtama.lblNamaForm.Text = "- Pengaturan Pengguna";
            UsrAccess();
        }

        private void UserMgmt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            TampilData(txtUserName.Text.Trim());
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            ResetPass();
        }

        private void cboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRole.Text != "")
            {
                //kosongkan dulu semua baru diisi sesuai dengan role yang dipilih
                for (int i = 0; i < grpUtama.Length; i++)
                {
                    grpUtama[i].Checked = false;
                }

                for (int i = 0; i < grpDataPerusahaan.Length; i++)
                {
                    grpDataPerusahaan[i].Checked = false;
                }

                for (int i = 0; i < grpKaryawan.Length; i++)
                {
                    grpKaryawan[i].Checked = false;
                }

                for (int i = 0; i < grpPelanggan.Length; i++)
                {
                    grpPelanggan[i].Checked = false;
                }

                for (int i = 0; i < grpPemasok.Length; i++)
                {
                    grpPemasok[i].Checked = false;
                }

                for (int i = 0; i < grpKategori.Length; i++)
                {
                    grpKategori[i].Checked = false;
                }

                for (int i = 0; i < grpBarang.Length; i++)
                {
                    grpBarang[i].Checked = false;
                }

                for (int i = 0; i < grpPembelian.Length; i++)
                {
                    grpPembelian[i].Checked = false;
                }

                for (int i = 0; i < grpReturPembelian.Length; i++)
                {
                    grpReturPembelian[i].Checked = false;
                }

                for (int i = 0; i < grpHutang.Length; i++)
                {
                    grpHutang[i].Checked = false;
                }

                for (int i = 0; i < grpPenyesuaian.Length; i++)
                {
                    grpPenyesuaian[i].Checked = false;
                }

                for (int i = 0; i < grpGudangMasuk.Length; i++)
                {
                    grpGudangMasuk[i].Checked = false;
                }

                for (int i = 0; i < grpPindahGudang.Length; i++)
                {
                    grpPindahGudang[i].Checked = false;
                }

                for (int i = 0; i < grpDiskon.Length; i++)
                {
                    grpDiskon[i].Checked = false;
                }

                for (int i = 0; i < grpPenjualan.Length; i++)
                {
                    grpPenjualan[i].Checked = false;
                }

                for (int i = 0; i < grpReturPenjualan.Length; i++)
                {
                    grpReturPenjualan[i].Checked = false;
                }

                for (int i = 0; i < grpPiutang.Length; i++)
                {
                    grpPiutang[i].Checked = false;
                }

                for (int i = 0; i < grpKas.Length; i++)
                {
                    grpKas[i].Checked = false;
                }

                for (int i = 0; i < grpPengaturanPengguna.Length; i++)
                {
                    grpPengaturanPengguna[i].Checked = false;
                }

                for (int i = 0; i < grpUbahPassword.Length; i++)
                {
                    grpUbahPassword[i].Checked = false;
                }

                for (int i = 0; i < grpLaporan.Length; i++)
                {
                    grpLaporan[i].Checked = false;
                }
            }

            if (cboRole.SelectedIndex == 0)
            {
                for (int i = 0; i < grpUtama.Length; i++)
                {
                    grpUtama[i].Checked = true;
                }

                for (int i = 0; i < grpDataPerusahaan.Length; i++)
                {
                    grpDataPerusahaan[i].Checked = true;
                }

                for (int i = 0; i < grpKaryawan.Length; i++)
                {
                    grpKaryawan[i].Checked = true;
                }

                for (int i = 0; i < grpPelanggan.Length; i++)
                {
                    grpPelanggan[i].Checked = true;
                }

                for (int i = 0; i < grpPemasok.Length; i++)
                {
                    grpPemasok[i].Checked = true;
                }

                for (int i = 0; i < grpKategori.Length; i++)
                {
                    grpKategori[i].Checked = true;
                }

                for (int i = 0; i < grpBarang.Length; i++)
                {
                    grpBarang[i].Checked = true;
                }

                for (int i = 0; i < grpPembelian.Length; i++)
                {
                    grpPembelian[i].Checked = true;
                }

                for (int i = 0; i < grpReturPembelian.Length; i++)
                {
                    grpReturPembelian[i].Checked = true;
                }

                for (int i = 0; i < grpHutang.Length; i++)
                {
                    grpHutang[i].Checked = true;
                }

                for (int i = 0; i < grpPenyesuaian.Length; i++)
                {
                    grpPenyesuaian[i].Checked = true;
                }

                for (int i = 0; i < grpGudangMasuk.Length; i++)
                {
                    grpGudangMasuk[i].Checked = true;
                }

                for (int i = 0; i < grpPindahGudang.Length; i++)
                {
                    grpPindahGudang[i].Checked = true;
                }

                for (int i = 0; i < grpDiskon.Length; i++)
                {
                    grpDiskon[i].Checked = true;
                }

                for (int i = 0; i < grpPenjualan.Length; i++)
                {
                    grpPenjualan[i].Checked = true;
                }

                for (int i = 0; i < grpReturPenjualan.Length; i++)
                {
                    grpReturPenjualan[i].Checked = true;
                }

                for (int i = 0; i < grpPiutang.Length; i++)
                {
                    grpPiutang[i].Checked = true;
                }

                for (int i = 0; i < grpKas.Length; i++)
                {
                    grpKas[i].Checked = true;
                }

                for (int i = 0; i < grpPengaturanPengguna.Length; i++)
                {
                    grpPengaturanPengguna[i].Checked = true;
                }

                for (int i = 0; i < grpUbahPassword.Length; i++)
                {
                    grpUbahPassword[i].Checked = true;
                }

                for (int i = 0; i < grpLaporan.Length; i++)
                {
                    grpLaporan[i].Checked = true;
                }
            }
            else if (cboRole.SelectedIndex == 1)
            {
                for (int i = 0; i < grpUtama.Length; i++)
                {
                    grpUtama[i].Checked = true;
                }
                usrmgmt.Checked = false;
                backupdb.Checked = false;
                restoredb.Checked = false;

                for (int i = 0; i < grpDataPerusahaan.Length; i++)
                {
                    grpDataPerusahaan[i].Checked = true;
                }
                dataperusahaandel.Checked = false;

                for (int i = 0; i < grpKaryawan.Length; i++)
                {
                    grpKaryawan[i].Checked = true;
                }
                karyawandel.Checked = false;

                for (int i = 0; i < grpPelanggan.Length; i++)
                {
                    grpPelanggan[i].Checked = true;
                }
                pelanggandel.Checked = false;

                for (int i = 0; i < grpPemasok.Length; i++)
                {
                    grpPemasok[i].Checked = true;
                }
                pemasokdel.Checked = false;

                for (int i = 0; i < grpBarang.Length; i++)
                {
                    grpBarang[i].Checked = true;
                }
                barangdel.Checked = false;

                for (int i = 0; i < grpKategori.Length; i++)
                {
                    grpKategori[i].Checked = true;
                }
                kategoridel.Checked = false;

                for (int i = 0; i < grpBarang.Length; i++)
                {
                    grpBarang[i].Checked = true;
                }
                barangdel.Checked = false;

                for (int i = 0; i < grpPembelian.Length; i++)
                {
                    grpPembelian[i].Checked = true;
                }
                pembeliandel.Checked = false;

                for (int i = 0; i < grpReturPembelian.Length; i++)
                {
                    grpReturPembelian[i].Checked = true;
                }
                returpembeliandel.Checked = false;

                for (int i = 0; i < grpHutang.Length; i++)
                {
                    grpHutang[i].Checked = true;
                }
                hutangdel.Checked = false;

                for (int i = 0; i < grpPenyesuaian.Length; i++)
                {
                    grpPenyesuaian[i].Checked = true;
                }
                penyesuaiandel.Checked = false;

                for (int i = 0; i < grpGudangMasuk.Length; i++)
                {
                    grpGudangMasuk[i].Checked = true;
                }
                gudangmasukdel.Checked = false;

                for (int i = 0; i < grpPindahGudang.Length; i++)
                {
                    grpPindahGudang[i].Checked = true;
                }
                pindahgudangdel.Checked = false;

                for (int i = 0; i < grpDiskon.Length; i++)
                {
                    grpDiskon[i].Checked = true;
                }
                diskondel.Checked = false;

                for (int i = 0; i < grpPenjualan.Length; i++)
                {
                    grpPenjualan[i].Checked = true;
                }
                penjualandel.Checked = false;

                for (int i = 0; i < grpReturPenjualan.Length; i++)
                {
                    grpReturPenjualan[i].Checked = true;
                }
                returpenjualandel.Checked = false;

                for (int i = 0; i < grpPiutang.Length; i++)
                {
                    grpPiutang[i].Checked = true;
                }
                piutangdel.Checked = false;

                for (int i = 0; i < grpKas.Length; i++)
                {
                    grpKas[i].Checked = true;
                }
                kasdel.Checked = false;

                for (int i = 0; i < grpUbahPassword.Length; i++)
                {
                    grpUbahPassword[i].Checked = true;
                }

                for (int i = 0; i < grpLaporan.Length; i++)
                {
                    grpLaporan[i].Checked = true;
                }
            }
            else if (cboRole.SelectedIndex == 2)
            {
                for (int i = 0; i < grpUtama.Length; i++)
                {
                    grpUtama[i].Checked = true;
                }

                for (int i = 0; i < grpLaporan.Length; i++)
                {
                    grpLaporan[i].Checked = true;
                }

                for (int i = 0; i < grpUbahPassword.Length; i++)
                {
                    grpUbahPassword[i].Checked = true;
                }

                usrmgmt.Checked = false;
                backupdb.Checked = false;
                restoredb.Checked = false;
            }
        }

        private void dataperusahaan_CheckedChanged(object sender, EventArgs e)
        {
            if (dataperusahaan.Checked == true)
            {
                for (int i = 0; i < grpDataPerusahaan.Length; i++)
                {
                    grpDataPerusahaan[i].Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i < grpDataPerusahaan.Length; i++)
                {
                    grpDataPerusahaan[i].Enabled = false;
                    grpDataPerusahaan[i].Checked = false;
                }
            }
        }

        private void karyawan_CheckedChanged(object sender, EventArgs e)
        {
            if (karyawan.Checked == true)
            {
                for (int i = 0; i < grpKaryawan.Length; i++)
                {
                    grpKaryawan[i].Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i < grpKaryawan.Length; i++)
                {
                    grpKaryawan[i].Enabled = false;
                    grpKaryawan[i].Checked = false;
                }
            }
        }

        private void pelanggan_CheckedChanged(object sender, EventArgs e)
        {
            if (pelanggan.Checked == true)
            {
                for (int i = 0; i < grpPelanggan.Length; i++)
                {
                    grpPelanggan[i].Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i < grpPelanggan.Length; i++)
                {
                    grpPelanggan[i].Enabled = false;
                    grpPelanggan[i].Checked = false;
                }
            }
        }

        private void pemasok_CheckedChanged(object sender, EventArgs e)
        {
            if (pemasok.Checked == true)
            {
                for (int i = 0; i < grpPemasok.Length; i++)
                {
                    grpPemasok[i].Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i < grpPemasok.Length; i++)
                {
                    grpPemasok[i].Enabled = false;
                    grpPemasok[i].Checked = false;
                }
            }
        }

        private void kategori_CheckedChanged(object sender, EventArgs e)
        {
            if (kategori.Checked == true)
            {
                for (int i = 0; i < grpKategori.Length; i++)
                {
                    grpKategori[i].Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i < grpKategori.Length; i++)
                {
                    grpKategori[i].Enabled = false;
                    grpKategori[i].Checked = false;
                }
            }
        }

        private void barang_CheckedChanged(object sender, EventArgs e)
        {
            if (barang.Checked == true)
            {
                for (int i = 0; i < grpBarang.Length; i++)
                {
                    grpBarang[i].Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i < grpBarang.Length; i++)
                {
                    grpBarang[i].Enabled = false;
                    grpBarang[i].Checked = false;
                }
            }
        }

        private void pembelian_CheckedChanged(object sender, EventArgs e)
        {
            if (pembelian.Checked == true)
            {
                for (int i = 0; i < grpPembelian.Length; i++)
                {
                    grpPembelian[i].Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i < grpPembelian.Length; i++)
                {
                    grpPembelian[i].Enabled = false;
                    grpPembelian[i].Checked = false;
                }
            }
        }

        private void returpembelian_CheckedChanged(object sender, EventArgs e)
        {
            if (returpembelian.Checked == true)
            {
                for (int i = 0; i < grpReturPembelian.Length; i++)
                {
                    grpReturPembelian[i].Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i < grpReturPembelian.Length; i++)
                {
                    grpReturPembelian[i].Enabled = false;
                    grpReturPembelian[i].Checked = false;
                }
            }
        }

        private void hutang_CheckedChanged(object sender, EventArgs e)
        {
            if (hutang.Checked == true)
            {
                for (int i = 0; i < grpHutang.Length; i++)
                {
                    grpHutang[i].Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i < grpHutang.Length; i++)
                {
                    grpHutang[i].Enabled = false;
                    grpHutang[i].Checked = false;
                }
            }
        }

        private void gudangmasuk_CheckedChanged(object sender, EventArgs e)
        {
            if (gudangmasuk.Checked == true)
            {
                for (int i = 0; i < grpGudangMasuk.Length; i++)
                {
                    grpGudangMasuk[i].Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i < grpGudangMasuk.Length; i++)
                {
                    grpGudangMasuk[i].Enabled = false;
                    grpGudangMasuk[i].Checked = false;
                }
            }
        }

        private void pindahgudang_CheckedChanged(object sender, EventArgs e)
        {
            if (pindahgudang.Checked == true)
            {
                for (int i = 0; i < grpPindahGudang.Length; i++)
                {
                    grpPindahGudang[i].Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i < grpPindahGudang.Length; i++)
                {
                    grpPindahGudang[i].Enabled = false;
                    grpPindahGudang[i].Checked = false;
                }
            }
        }

        private void diskon_CheckedChanged(object sender, EventArgs e)
        {
            if (diskon.Checked == true)
            {
                for (int i = 0; i < grpDiskon.Length; i++)
                {
                    grpDiskon[i].Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i < grpDiskon.Length; i++)
                {
                    grpDiskon[i].Enabled = false;
                    grpDiskon[i].Checked = false;
                }
            }
        }

        private void penjualan_CheckedChanged(object sender, EventArgs e)
        {
            if (penjualan.Checked == true)
            {
                for (int i = 0; i < grpPenjualan.Length; i++)
                {
                    grpPenjualan[i].Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i < grpPenjualan.Length; i++)
                {
                    grpPenjualan[i].Enabled = false;
                    grpPenjualan[i].Checked = false;
                }
            }
        }

        private void returpenjualan_CheckedChanged(object sender, EventArgs e)
        {
            if (returpenjualan.Checked == true)
            {
                for (int i = 0; i < grpReturPenjualan.Length; i++)
                {
                    grpReturPenjualan[i].Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i < grpReturPenjualan.Length; i++)
                {
                    grpReturPenjualan[i].Enabled = false;
                    grpReturPenjualan[i].Checked = false;
                }
            }
        }

        private void piutang_CheckedChanged(object sender, EventArgs e)
        {
            if (piutang.Checked == true)
            {
                for (int i = 0; i < grpPiutang.Length; i++)
                {
                    grpPiutang[i].Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i < grpPiutang.Length; i++)
                {
                    grpPiutang[i].Enabled = false;
                    grpPiutang[i].Checked = false;
                }
            }
        }

        private void kas_CheckedChanged(object sender, EventArgs e)
        {
            if (kas.Checked == true)
            {
                for (int i = 0; i < grpKas.Length; i++)
                {
                    grpKas[i].Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i < grpKas.Length; i++)
                {
                    grpKas[i].Enabled = false;
                    grpKas[i].Checked = false;
                }
            }
        }

        private void usrmgmt_CheckedChanged(object sender, EventArgs e)
        {
            if (usrmgmt.Checked == true)
            {
                for (int i = 0; i < grpPengaturanPengguna.Length; i++)
                {
                    grpPengaturanPengguna[i].Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i < grpPengaturanPengguna.Length; i++)
                {
                    grpPengaturanPengguna[i].Enabled = false;
                    grpPengaturanPengguna[i].Checked = false;
                }
            }
        }

        private void ubahpass_CheckedChanged(object sender, EventArgs e)
        {
            if (ubahpass.Checked == true)
            {
                for (int i = 0; i < grpUbahPassword.Length; i++)
                {
                    grpUbahPassword[i].Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i < grpUbahPassword.Length; i++)
                {
                    grpUbahPassword[i].Enabled = false;
                    grpUbahPassword[i].Checked = false;
                }
            }
        }

        private void penyesuaian_CheckedChanged(object sender, EventArgs e)
        {
            if (penyesuaian.Checked == true)
            {
                for (int i = 0; i < grpPenyesuaian.Length; i++)
                {
                    grpPenyesuaian[i].Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i < grpPenyesuaian.Length; i++)
                {
                    grpPenyesuaian[i].Enabled = false;
                    grpPenyesuaian[i].Checked = false;
                }
            }
        }
    }
}
