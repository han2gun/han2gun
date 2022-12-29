using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace POS.cls
{
    class Query
    {
        Koneksi kon = new Koneksi();
        Pesan psn = new Pesan();
        Fungsi fs = new Fungsi();

        //public DsDelivery dataset = new DsDelivery();
        public DSPOS dataset = new DSPOS();
        public DataSet ds;

        private int ManipulationData(string query)
        {
            try
            {
                int res = 0;
                kon.OpenConn();
                kon.cmd = new MySqlCommand(query, kon.con);
                kon.da = new MySqlDataAdapter(kon.cmd);
                res = kon.cmd.ExecuteNonQuery();
                kon.CloseConn();
                return res;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int InsertData(string namatabel, string namafield, string isidata)
        {
            return ManipulationData("insert into " + namatabel + "(" + namafield + ") values(" + isidata + ");");
        }

        public int DeleteData(string namatabel, string kondisi)
        {
            return ManipulationData("delete from " + namatabel + " where " + kondisi + ";");
        }

        public int UpdateData(string namatabel, string isidata, string kondisi)
        {
            return ManipulationData("update " + namatabel + " set " + isidata + " where " + kondisi + ";");
        }

        public int InsertLogAktivitas(string fungsi, Form frm, string idtransaksi, string userName)
        {
            return ManipulationData("insert into logaudit values('" + DateTime.Now.ToString("yyyy-MM-dd") + "','" +
                DateTime.Now.ToString("HH:mm:ss") + "','" + fungsi + "','" + frm.Name + "','" + idtransaksi + "','" + userName + "')");
        }

        public string CreateID(Form namaform, string fungsi, string namafield, string namatabel, string kondisi, string formatid, string jenistr)
        {
            string temp = "";
            string idawal = "";
            string strleft = "";
            string strright = "";
            string strtampung = "";
            int nilai = 0;
            int potong = 0;

            if (jenistr == "master")
            {
                idawal = "00001";
                strtampung = "0000";
                potong = 5;
            }
            else if (jenistr == "transaksi")
            {
                idawal = "0001";
                strtampung = "000";
                potong = 4;
            }

            try
            {
                kon.OpenConn();
                kon.cmd = new MySqlCommand("select " + namafield + " from " + namatabel + " where " + kondisi + " order by " + namafield + " desc limit 1", kon.con);
                kon.cmd.ExecuteNonQuery();
                kon.rd = kon.cmd.ExecuteReader();
                while (kon.rd.Read())
                {
                    temp = kon.rd[namafield].ToString();

                    string[] cutString = temp.Split('.');

                    if (jenistr == "master")
                    {
                        strleft = cutString[0] + ".";
                        strright = cutString[1];
                    }
                    else if (jenistr == "transaksi")
                    {
                        strleft = cutString[0] + "." + cutString[1] + ".";
                        strright = cutString[2];
                    }

                    nilai = Convert.ToInt32(strright);
                    nilai = nilai + 1;
                    strtampung = strtampung + nilai.ToString();
                    strtampung = strtampung.Substring(strtampung.Length - potong, potong);
                    psn.CreateLogSuccessClass("CreateID >> " + namaform.Name.ToString() + " >> " + fungsi + "", strleft + strtampung + " ID Lanjutan");
                    return strleft + strtampung;
                }
            }
            catch (Exception e)
            {
                psn.CreateLogErrorClass("CreateID >> " + namaform.Name.ToString() + " >> " + fungsi + "", "Create ID " + strleft + strtampung + " Gagal", e.ToString());
            }
            finally
            {
                kon.CloseConn();
            }
            psn.CreateLogSuccessClass("CreateID >> " + namaform.Name.ToString() + " >> " + fungsi + "", formatid + idawal + " ID Baru");
            return formatid + idawal;
        }

        public string GetData(Form namaform, string fungsi, string id, int panjangid, string namafield, string namatabel, string kondisi)
        {
            string[] cutString = namafield.Split(',');
            string isidata = "";

            try
            {
                DataSet ds = new DataSet();
                kon.OpenConn();
                kon.da = new MySqlDataAdapter("select " + namafield + " from " + namatabel + " where " + kondisi + "", kon.con);
                kon.da.Fill(ds, "data");
                int row = ds.Tables["data"].Rows.Count - 1;

                for (int i = 0; i <= row; i++)
                {
                    for (int j = 0; j < cutString.Length; j++)
                    {
                        isidata = isidata + ds.Tables["data"].Rows[i].ItemArray[j].ToString() + "|";
                    }
                }

                if (id.Length >= panjangid && isidata != "")
                {
                    psn.CreateLogSuccessClass("GetData >> " + namaform.Name.ToString() + " >> " + fungsi + "", id + " Data Ditemukan");
                }
                else if (id.Length >= panjangid && isidata == "")
                {
                    psn.CreateLogSuccessClass("GetData >> " + namaform.Name.ToString() + " >> " + fungsi + "", id + " Data Tidak Ditemukan");
                }

                return isidata;
            }
            catch (Exception e)
            {
                psn.CreateLogErrorClass("GetData >> " + namaform.Name.ToString() + " >> " + fungsi + "", "Tampil Data " + id + " Gagal", e.ToString());
            }
            finally
            {
                kon.CloseConn();
            }

            return isidata;
        }

        public void DataGridViewFill(Form namaform, DataGridView dg, string fungsi, string namafield, string namatabel, string kondisi)
        {
            dg.Rows.Clear();

            try
            {
                ds = new DataSet();
                kon.OpenConn();
                kon.da = new MySqlDataAdapter("select " + namafield + " from " + namatabel + " where " + kondisi + "", kon.con);
                kon.da.Fill(ds, "detail");
            }
            catch (Exception e)
            {
                psn.CreateLogErrorClass("DataGridViewFill >> " + namaform.Name.ToString() + " >> " + fungsi + "", "Tampil Data Gagal", e.ToString());
            }
            finally
            {
                kon.CloseConn();
            }
        }

        public bool DataExist(Form namaform, string fungsi, string id, string isidata, string field, string tabel, string condition)
        {
            string dataFound = "";

            try
            {
                kon.OpenConn();
                kon.cmd = new MySqlCommand("select " + field + " from " + tabel + " where " + condition + "", kon.con);
                kon.cmd.ExecuteNonQuery();
                kon.rd = kon.cmd.ExecuteReader();
                while (kon.rd.Read())
                {
                    dataFound = kon.rd[field].ToString();
                }

                if (dataFound != "")
                {
                    psn.CreateLogSuccessClass("DataExist >> " + namaform.Name.ToString() + " >> " + fungsi + "", id + " Kondisi TRUE");
                    return true;
                }
            }
            catch (Exception e)
            {
                psn.CreateLogErrorClass("DataExist >> " + namaform.Name.ToString() + " >> " + fungsi + "", "Cek Data " + id + " Gagal", e.ToString());
            }
            finally
            {
                kon.CloseConn();
            }
            psn.CreateLogSuccessClass("DataExist >> " + namaform.Name.ToString() + " >> " + fungsi + "", id + " Kondisi FALSE");
            return false;
        }

        public void PencarianDataString(Form namaform, string formasal, DataGridView dg, string[] header, int banyakkolom, string query,
            string perihalpencarian, string txtisicombo, string txtisipencarian)
        {
            try
            {
                kon.dv = new DataView();
                kon.dt = new DataTable();
                kon.OpenConn();
                kon.da = new MySqlDataAdapter(query, kon.con);
                kon.dt.Clear();
                kon.da.Fill(kon.dt);
                kon.dv = kon.dt.DefaultView;
                dg.DataSource = kon.dv;
                fs.HeaderDataGridView(dg, header, banyakkolom);

                if (txtisipencarian != "")
                    psn.CreateLogSuccessClass("PencarianDataString >> " + namaform.Name.ToString() + " >> " + formasal + "",
                        "Pencarian " + perihalpencarian + " Berdasar " + txtisicombo + " Kata Kunci " + txtisipencarian + "");
            }
            catch (Exception e)
            {
                psn.CreateLogErrorClass("PencarianDataString >> " + namaform.Name.ToString() + " >> " + formasal + "",
                    "Pencarian " + perihalpencarian + " Berdasar " + txtisicombo + " Kata Kunci " + txtisipencarian + "", e.ToString());
            }
            finally
            {
                kon.CloseConn();
            }
        }

        public void ComboBoxFill(Form namaform, ComboBox cbo, string fungsi, string namafield, string namatabel)
        {
            cbo.Text = "";
            cbo.Items.Clear();

            try
            {
                kon.OpenConn();
                kon.cmd = new MySqlCommand("select " + namafield + " from " + namatabel + "", kon.con);
                kon.cmd.ExecuteNonQuery();
                kon.rd = kon.cmd.ExecuteReader();
                while (kon.rd.Read())
                {
                    cbo.Items.Add(kon.rd[0].ToString());
                }

                psn.CreateLogSuccessClass("ComboBoxFill >> " + namaform.Name.ToString() + " >> " + fungsi + "", "List Ditemukan");
            }
            catch (Exception e)
            {
                psn.CreateLogErrorClass("ComboBoxFill >> " + namaform.Name.ToString() + " >> " + fungsi + "", "Tampil List Gagal", e.ToString());
            }
            finally
            {
                kon.CloseConn();
            }
        }

        public void CetakDokumen(Form namaform, string id, string namafield, string namatabel, string kondisi, string namadataset)
        {
            try
            {
                kon.OpenConn();
                kon.da = new MySqlDataAdapter("select " + namafield + " from " + namatabel + " " + kondisi + "", kon.con);
                kon.da.Fill(dataset, namadataset);

                psn.CreateLogSuccessClass("CetakDokumen >> " + namaform.Name.ToString() + " >> " + id + "", "Preview");
            }
            catch (Exception e)
            {
                psn.CreateLogErrorClass("CetakDokumen >> " + namaform.Name.ToString() + " >> " + id + "", "Tampil Preview Dokumen Cetak Gagal", e.ToString());
            }
            finally
            {
                kon.CloseConn();
            }
        }

        public void CetakDokumenProsedure(Form namaform, string query, string namadataset)
        {
            try
            {
                kon.OpenConn();
                kon.da = new MySqlDataAdapter(query, kon.con);
                kon.da.Fill(dataset, namadataset);

                psn.CreateLogSuccessClass("CetakDokumen >> " + namaform.Name.ToString() + " >> " + namaform + "", "Preview");
            }
            catch (Exception e)
            {
                psn.CreateLogErrorClass("CetakDokumen >> " + namaform.Name.ToString() + " >> " + namaform + "", "Tampil Preview Dokumen Cetak Gagal", e.ToString());
            }
            finally
            {
                kon.CloseConn();
            }
        }

        public void CetakDokumenUnion(Form namaform, string id, string query, string namadataset)
        {
            try
            {
                kon.OpenConn();
                kon.da = new MySqlDataAdapter("select " + query + "", kon.con);
                kon.da.Fill(dataset, namadataset);

                psn.CreateLogSuccessClass("CetakDokumen >> " + namaform.Name.ToString() + " >> " + id + "", "Preview");
            }
            catch (Exception e)
            {
                psn.CreateLogErrorClass("CetakDokumen >> " + namaform.Name.ToString() + " >> " + id + "", "Tampil Preview Dokumen Cetak Gagal", e.ToString());
            }
            finally
            {
                kon.CloseConn();
            }
        }
    }
}
