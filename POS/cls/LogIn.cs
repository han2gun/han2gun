using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace POS.cls
{
    class LogIn
    {
        Pesan psn = new Pesan();
        Fungsi fs = new Fungsi();
        Query qry = new Query();
        Koneksi kon = new Koneksi();

        Login frmLogin;
        MenuUtama frmUtama;

        public LogIn(Login lgin, MenuUtama mnutama)
        {
            frmLogin = lgin;
            frmUtama = mnutama;
        }

        private void SaveLogIn(string userName, string keterangan)
        {
            try
            {
                qry.InsertLogAktivitas("SaveLogIn", frmLogin, "", userName);
                psn.CreateLogSuccessClass("SaveLogIn", userName + " " + keterangan);
            }
            catch (Exception e)
            {
                psn.CreateLogErrorClass("SaveLogIn", userName, e.ToString());
            }
        }

        public void signIn(string username, string pass)
        {
            string userName = "";
            string pengguna = "";

            try
            {
                kon.OpenConn();
                kon.cmd = new MySqlCommand("select usrname,namauser,pass,roleusr from usrmgmt " +
                    "where usrname = '" + username + "' and pass = password('" + pass + "');", kon.con);
                kon.cmd.ExecuteNonQuery();
                kon.rd = kon.cmd.ExecuteReader();
                while (kon.rd.Read())
                {
                    userName = kon.rd["usrname"].ToString();
                    pengguna = kon.rd["namauser"].ToString();
                    frmUtama.lblNamaPengguna.Text = kon.rd["namauser"].ToString();
                    frmUtama.userName = kon.rd["usrname"].ToString();
                    frmUtama.lblPosisi.Text = kon.rd["roleusr"].ToString();
                }

                if (userName == "")
                {
                    frmLogin.lblError.Text = "Username atau password anda salah";
                    frmLogin.lblError.Visible = true;
                    frmLogin.txtUserName.Focus();
                    SaveLogIn(username, "GAGAL");
                }
                else
                {
                    frmLogin.lblError.Visible = false;
                    SaveLogIn(userName, "BERHASIL");
                    frmLogin.Close();
                    
                    frmUtama.btnSignInOut.Text = "Sign Out";
                    frmUtama.btnSignInOut.Image = frmUtama.imageList1.Images[0];
                    frmUtama.userName = userName;
                    
                    frmUtama.btnMasterData.Enabled = true;
                    frmUtama.btnTransaksi.Enabled = true;
                    frmUtama.btnLaporan.Enabled = true;
                    frmUtama.btnPengaturan.Enabled = true;
                    frmUtama.btnDatabase.Enabled = true;
                }
            }
            catch (Exception e)
            {
                psn.CreateLogErrorClass("signIn", "Sign In " + username + " Gagal", e.ToString());
            }
        }
    }
}
