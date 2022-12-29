using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class Login : Form
    {
        cls.Pesan psn = new cls.Pesan();
        cls.Fungsi fs = new cls.Fungsi();
        cls.Query qry = new cls.Query();
        MenuUtama frmUtama;

        int jmlUser = 0;

        public Login(MenuUtama mnutama)
        {
            InitializeComponent();
            frmUtama = mnutama;
        }

        #region code
        private void CekUserReady()
        {
            string data = qry.GetData(this, "CekUserReady", "", 0, "count(*)", "usrmgmt", "usrname != ''");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    jmlUser = Convert.ToInt32(filldata[0]);

                    qry.InsertLogAktivitas("CekUserReady", this, "Jumlah User = " + jmlUser.ToString() + "", "");
                }
            }
        }

        private void CreateUser()
        {
            try
            {
                qry.InsertData("usrmgmt", "usrname,namauser,pass,roleusr," +
                    "identitas,identitassv,identitasdel,identitasprt,identitasup," + //identitas
                    "karyawan,karyawansv,karyawandel,karyawanprt,karyawanup," + //karyawan
                    "pelanggan,pelanggansv,pelanggandel,pelangganprt,pelangganup," + //pelanggan
                    "pemasok,pemasoksv,pemasokdel,pemasokprt,pemasokup," + //pemasok
                    "kelbarang,kelbarangsv,kelbarangdel,kelbarangprt,kelbarangup," + //kelbarang
                    "barang,barangsv,barangdel,barangprt,barangup,barangstokrp," + //barang
                    "pembelian,pembeliansv,pembeliandel,pembelianprt,pembelianup," + //pembelian
                    "returpembelian,returpembeliansv,returpembeliandel,returpembelianprt,returpembelianup," + //returpembelian
                    "hutang,hutangsv,hutangdel,hutangup," + //hutang
                    "penyesuaian,penyesuaiansv,penyesuaiandel,penyesuaianprt,penyesuaianup," + //penyesuaian
                    "gudangmasuk,gudangmasuksv,gudangmasukdel,gudangmasukprt,gudangmasukup," + //gudangmasuk
                    "pindahgudang,pindahgudangsv,pindahgudangdel,pindahgudangprt,pindahgudangup," + //pindahgudang
                    "diskon,diskonsv,diskondel,diskonprt,diskonup," + //diskon
                    "penjualan,penjualansv,penjualandel,penjualanprt,penjualanup," + //penjualan
                    "returpenjualan,returpenjualansv,returpenjualandel,returpenjualanprt,returpenjualanup," + //returpenjualan
                    "piutang,piutangsv,piutangdel,piutangup," + //piutang
                    "kas,kassv,kasdel,kasprt,kasup," + //kas
                    "lappembelianperiode,lappembeliansupplier,lappembelianbarang,cekhargabelibarang," + //lap pembelian
                    "lapgudangmasukperiode,lapgudangmasukbarang,lapgudangmasukkartustok," + //lap gudang
                    "lappindahgudangperiode,lappindahgudangbarang,lappindahgudangkartustok," + //lap pindah gudang
                    "lappenjualanperiode,lappenjualancustomer,lappenjualanbarang,lappenjualankategori," + //lap penjualan
                    "laprlpenjualanperiode,laprlpenjualanbarang,laprlpenjualankategori," + //lap R/L
                    "lapkasperiode," + //lap kas
                    "lapreturpembelianperiode,lapreturpembeliansupplier,lapreturpembelianbarang," + //lap retur pembelian
                    "lapreturpenjualanperiode,lapreturpenjualancustomer,lapreturpenjualanbarang," + //lap retur penjualan
                    "lappenggunaanaplikasi," + //lap penggunaan aplikasi
                    "lapmutasistok," + //lap mutasi stok
                    "usrmgmt,usrmgmtsv,usrmgmtdel,usrmgmtreset,usrmgmtup," + //user mgmt
                    "ubahpassword,ubahpasswordsv,backupdb,restoredb," + //ubah pass dan DB
                    "tglinput, tglupdate",
                    "'admin','ADMIN',password('admin'),'ADMIN'," +
                    "1,1,1,1,1," + //identitas
                    "1,1,1,1,1," + //karyawan
                    "1,1,1,1,1," + //pelanggan
                    "1,1,1,1,1," + //pemasok
                    "1,1,1,1,1," + //kelbarang
                    "1,1,1,1,1,1," + //barang
                    "1,1,1,1,1," + //pembelian
                    "1,1,1,1,1," + //returpembelian
                    "1,1,1,1," + //hutang
                    "1,1,1,1,1," + //penyesuaian
                    "1,1,1,1,1," + //gudangmasuk
                    "1,1,1,1,1," + //pindahgudang
                    "1,1,1,1,1," + //diskon
                    "1,1,1,1,1," + //penjualan
                    "1,1,1,1,1," + //returpenjualan
                    "1,1,1,1," + //piutang
                    "1,1,1,1,1," + //kas
                    "1,1,1,1," + //lappembelian
                    "1,1,1," + //lapgudang
                    "1,1,1," + //lappindahgudang
                    "1,1,1,1," + //lappenjualan
                    "1,1,1," + //lap R/L
                    "1," + //lapkas
                    "1,1,1," + //lap retur pembelian
                    "1,1,1," + //lap retur penjualan
                    "1," + //lap penggunaan aplikasi
                    "1," + //lap mutasi stok
                    "1,1,1,1,1," + //user mgmt
                    "1,1,1,1," + //ubah pass dan DB
                    "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'");

                qry.InsertLogAktivitas("CreateUser", this, "admin", "admin");
            }
            catch (Exception e)
            {
                psn.PesanInfo("Pembuatan user awal gagal");
                psn.CreateLogErrorForm(this, "Simpan", "Insert Admin Gagal", e.ToString());
            }
        }
        #endregion

        private void Login_Load(object sender, EventArgs e)
        {
            Location = new Point(Screen.PrimaryScreen.Bounds.Width - 1000, Screen.PrimaryScreen.Bounds.Height - 500);
            txtUserName.Focus();

            CekUserReady();

            if (jmlUser == 0)
            {
                CreateUser();
            }
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            cls.LogIn lg = new cls.LogIn(this, frmUtama);

            if (txtUserName.Text == "" || txtPassword.Text == "")
            {
                lblError.Text = "User Name / Password masih kosong";
                lblError.Visible = true;
            }
            else
            {
                //cls.Login lg = new cls.Login(this, frmUtama);
                lg.signIn(txtUserName.Text, txtPassword.Text);
                //this.Close();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSignIn_Click(sender, new EventArgs());
            }
        }
    }
}
