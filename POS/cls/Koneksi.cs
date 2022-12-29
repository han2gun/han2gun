using MySql.Data.MySqlClient;
using System.Data;

namespace POS.cls
{
    class Koneksi
    {
        Fungsi fs = new Fungsi();
        Pesan psn = new Pesan();

        public MySqlConnection con;
        public MySqlCommand cmd;
        public MySqlDataAdapter da;
        public MySqlDataReader rd;
        public DataView dv;
        public DataTable dt;

        private string server;
        private string dbName = "pos_cat";
        //private string dbName = "pos_cat_asli";
        private string dbPort = "3306";
        private string dbUser = "root";
        private string dbPassword = "haniel";
        //private string dbPassword = "cat123456!";

        private void LoadConfig(string fileIni)
        {
            server = fs.ReadConfig(fileIni, "Setting", "server");
        }

        public Koneksi()
        {
            if (fs.CekConfigFile() == true)
            {
                LoadConfig(fs.inifilepath + "\\" + "Config.ini");
                con = new MySqlConnection(@"server=" + server + ";userid=" + dbUser + ";password=" + dbPassword
                                          + ";database=" + dbName + ";port=" + dbPort + "");
            }
            else
            {
                psn.CreateLogErrorClass("Koneksi", "Missing Config.ini", "");
            }
        }

        public void OpenConn()
        {
            con.Open();
        }

        public void CloseConn()
        {
            con.Dispose();
        }
    }
}
