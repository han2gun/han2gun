using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace POS.frm
{
    public partial class GudangPindah : Form
    {
        cls.Fungsi fs = new cls.Fungsi();
        cls.Pesan psn = new cls.Pesan();
        cls.Query qry = new cls.Query();
        cls.Koneksi kon = new cls.Koneksi();

        MenuUtama frmUtama;
        public string userName;
        public string id;
        string idUpdate;
        bool updateData;
        string tglinput;

        public static string barcode;
        public static string idGudangMasuk;

        //variabel cell
        int cellhapus;
        int cellbarcode;
        int cellnama;
        int cellstokbarang;
        int cellqty;        
        int cellsatuan;
        int cellqty1;

        string namabarang;
        string satuan1;
        string satuan2;
        string stokgudang;
        string idbarangdetail;
        double qtybarangdetail;
        string tglbelibarangdetail;
        string tester;

        bool detailDelete;
        DataGridViewRow row;

        public GudangPindah(MenuUtama mnutama)
        {
            InitializeComponent();

            frmUtama = mnutama;
            idUpdate = "";
            updateData = false;
            cellhapus = 0;
            cellbarcode = 1;
            cellnama = 2;
            cellstokbarang = 3;
            cellqty = 4;
            cellsatuan = 5;
            cellqty1 = 6;
            namabarang = "";
            detailDelete = true;
            fs.BoldHeaderDataGridView(dgTransaksi);
            this.KeyDown += new KeyEventHandler(this.OnKeyDown);
            ActiveControl = dtTglTransaksi;
        }

        #region code
        private void UsrAccess()
        {
           string data = qry.GetData(this, "UsrAccess", userName, 0,
               "pindahgudangsv,pindahgudangdel,pindahgudangprt,pindahgudangup", "usrmgmt", "usrname = '" + userName + "'");

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
            fs.FillTextBoxArray(new TextBox[] { txtCatatan, txtKodeBarcode, txtIDGudang }, "");
            dtTglTransaksi.Value = DateTime.Today;
            tglinput = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            cboLokasi.Text = "";
            dgTransaksi.Rows.Clear();
            lblID.Text = "AUTO ID";
            dtTglTransaksi.Focus();
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
                    if (cboLokasi.Text.Trim() == "")
                    {
                        psn.PesanInfo("Lokasi Pindah Gudang Masih Kosong");
                        cboLokasi.Focus();
                    }
                    else if (dgTransaksi.Rows.Count <= 0)
                    {
                        psn.PesanInfo("Detail Transaksi Masih Kosong");
                    }
                    else
                    {
                        if (idUpdate == "")
                        {
                            if(cboLokasi.SelectedIndex == 0)
                            {
                                SimpanDisplay();
                            }                            
                        }
                        else
                        {
                            if (updateData == true)
                            {
                                if(cboLokasi.SelectedIndex == 0)
                                {
                                    SimpanDisplay();
                                }
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
                        psn.PesanInfo("ID Pindah Gudang Masih Kosong");
                    }
                    else
                    {
                        if(cboLokasi.SelectedIndex == 0)
                        {
                            HapusDisplay();
                        }                        
                    }
                    break;
                case "CETAK":
                    if (cboLokasi.Text.Trim() == "")
                    {
                        psn.PesanInfo("Lokasi Pindah Gudang Masih Kosong");
                        cboLokasi.Focus();
                    }
                    else if (dgTransaksi.Rows.Count <= 0)
                    {
                        psn.PesanInfo("Detail Transaksi Masih Kosong");
                    }
                    else
                    {
                        if (idUpdate == "")
                        {
                            SimpanDisplay();
                            Cetak(id);
                        }
                        else
                        {
                            if (updateData == true)
                            {
                                SimpanDisplay();
                                Cetak(id);
                            }
                            else
                            {
                                Cetak(id);
                            }
                        }
                    }

                    id = "";
                
                    break;
                case "KELUAR":
                    cls.OpenForm op = new cls.OpenForm(frmUtama);
                    op.PencarianOpen("Pencarian", "PindahGudang", userName);
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

            string data = qry.GetData(this, "TampilData", id, 13, "id,tgltransaksi,catatan,lokasi,tglinput",
                "pindah_gudang", "id = '" + id + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    idUpdate = filldata[0]; //jika kosong berarti data baru, jika muncul id data lama -> cek status boleh update atau tidak
                    dtTglTransaksi.Value = Convert.ToDateTime(filldata[1]);
                    txtCatatan.Text = filldata[2];
                    cboLokasi.Text = filldata[3];
                    tglinput = DateTime.Parse(filldata[4]).ToString("yyyy-MM-dd HH:mm:ss");

                    TampilDetailData(id);

                    qry.InsertLogAktivitas("TampilData", this, lblID.Text, userName);
                }
            }
        }

        //tampil detail data qty gudang harus sesuai dengan stok gudang
        private void TampilDetailData(string id)
        {
            qry.DataGridViewFill(this, dgTransaksi, "TampilDetailData", "a.id,a.barcode,a.nama,a.qty,a.satuan,b.stokgudang",
                "pindah_gudang_detail a inner join barang b on a.barcode = b.barcode", "id = '" + id + "'");

            int row = qry.ds.Tables["detail"].Rows.Count - 1;

            if (row >= 0)
            {
                for (int i = 0; i <= row; i++)
                {
                    dgTransaksi.Rows.Add();
                    dgTransaksi.Rows[i].Cells[cellhapus].Value = "X";
                    dgTransaksi.Rows[i].Cells[cellbarcode].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[1];
                    dgTransaksi.Rows[i].Cells[cellnama].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[2];
                    dgTransaksi.Rows[i].Cells[cellstokbarang].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[5].ToString());
                    dgTransaksi.Rows[i].Cells[cellqty].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[3].ToString());
                    dgTransaksi.Rows[i].Cells[cellsatuan].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[4];
                    dgTransaksi.Rows[i].Cells[cellqty1].Value = "0.00";
                }

                dgTransaksi.AutoResizeColumns();
                qry.InsertLogAktivitas("TampilDetailData", this, lblID.Text, userName);
            }
        }

        /*private string TampilStokBarang(string barcode)
        {
            string qty = "0";

            string data = qry.GetData(this, "TampilStokBarang", id, 13, "stokgudang", "barang", "barcode = '" + barcode + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    qty = fs.FormatNumbCurr(filldata[0]);

                    qry.InsertLogAktivitas("TampilStokBarang", this, lblID.Text + "-" + barcode, userName);
                }
            }

            return qty;
        }*/

        private void TampilBarang(string barcode)
        {
            string data = qry.GetData(this, "TampilBarang", id, 8, "a.barcode,a.nama,b.satuan1,b.stokgudang", 
                "gudang_masuk_detail a inner join barang b on a.barcode = b.barcode", 
                "a.barcode = '" + barcode + "' group by a.barcode");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    namabarang = filldata[1];
                    satuan1 = filldata[2];
                    stokgudang = fs.FormatNumbCurr(filldata[3]);

                    qry.InsertLogAktivitas("TampilBarang", this, txtKodeBarcode.Text, userName);
                }
            }
        }

        private void TampilSatuanBarang(string barcode)
        {
            string data = qry.GetData(this, "TampilSatuanBarang", barcode, 0, "barcode,satuan1,satuan2", "barang", "barcode = '" + barcode + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    satuan1 = filldata[1];
                    satuan2 = filldata[2];

                    qry.InsertLogAktivitas("TampilSatuanBarang", this, barcode, userName);
                }
            }

            string[] satuan = { satuan1, satuan2 };

            cboSatuan.Items.Clear();

            for (int i = 0; i < satuan.Length; i++)
            {
                cboSatuan.Items.Add(satuan[i]);
            }

            cboSatuan.SelectedIndex = 0;
        }

        private string TampilSatuan1(string barcode)
        {
            string satuan = "";

            string data = qry.GetData(this, "TampilSatuan1", barcode, 0, "barcode,satuan1", "barang", "barcode = '" + barcode + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    satuan = filldata[1];

                    qry.InsertLogAktivitas("TampilSatuan1", this, barcode, userName);
                }
            }

            return satuan;
        }

        private double TampilQty2(string barcode)
        {
            double qty = 0;

            string data = qry.GetData(this, "TampilQty2", barcode, 0, "barcode,qtysatuan2", "barang", "barcode = '" + barcode + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    qty = Convert.ToDouble(filldata[1]);

                    qry.InsertLogAktivitas("TampilQty2", this, barcode, userName);
                }
            }

            return qty;
        }

        private void InsertDataGrid()
        {
            bool match = true;

            if (namabarang != "")
            {
                int row = dgTransaksi.Rows.Count - 1;

                if (row >= 0)
                {
                    for (int i = 0; i <= row; i++)
                    {
                        if (dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString() == txtKodeBarcode.Text.Trim())
                        {
                            if(Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellqty].Value) + 1 > Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellstokbarang].Value))
                            {
                                psn.PesanInfo("Stok Barang tidak mencukupi untuk pindah Gudang");
                            }
                            else
                            {
                                dgTransaksi.Rows[i].Cells[cellqty].Value = fs.FormatNumbCurr((Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellqty].Value) + 1).ToString());
                            }

                            match = true;
                            break;
                        }
                        else
                        {
                            match = false;
                        }
                    }

                    if (match == false)
                    {
                        dgTransaksi.Rows.Add("X", txtKodeBarcode.Text.Trim(), namabarang, stokgudang, "1.00", 
                            satuan1, "0.00", "0.00", "0.00", "0.00", "0.00");
                        //dgTransaksi.AutoResizeColumns();
                    }
                }
                else
                {
                    dgTransaksi.Rows.Add("X", txtKodeBarcode.Text.Trim(), namabarang, stokgudang, "1.00", 
                        satuan1, "0.00", "0.00", "0.00", "0.00", "0.00");
                    //dgTransaksi.AutoResizeColumns();
                }
            }
        }

        //di join sama barang_detail supaya keliatan stok nya masih ada atau tidak
        private void TampilDataGudangMasuk()
        {
            qry.DataGridViewFill(this, dgTransaksi, "TampilDataGudangMasuk", "gd.barcode,b.nama,gd.stok,b.satuan1",
                "gudang_masuk g inner join barang_detail gd on g.id = gd.idgudangmasuk " +
                "inner join barang b on gd.barcode = b.barcode", "g.id = '" + txtIDGudang.Text.Trim() + "'");

            int row = qry.ds.Tables["detail"].Rows.Count - 1;

            if (row >= 0)
            {
                for (int i = 0; i <= row; i++)
                {
                    dgTransaksi.Rows.Add();
                    dgTransaksi.Rows[i].Cells[0].Value = "X";
                    dgTransaksi.Rows[i].Cells[1].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[0];
                    dgTransaksi.Rows[i].Cells[2].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[1];
                    dgTransaksi.Rows[i].Cells[3].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[2].ToString());
                    dgTransaksi.Rows[i].Cells[4].Value = "0.00";
                    dgTransaksi.Rows[i].Cells[5].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[3];
                    dgTransaksi.Rows[i].Cells[6].Value = "0.00";
                }

                dgTransaksi.AutoResizeColumns();
                qry.InsertLogAktivitas("TampilDataGudangMasuk", this, txtIDGudang.Text.Trim(), userName);
            }
        }

        private int HitungBanyakStok(string barcode)
        {
            int count = 0;

            string data = qry.GetData(this, "HitungBanyakStok", barcode, 0, "count(*)", "barang_detail",
                "barcode = '" + barcode + "' group by barcode");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    count = Convert.ToInt32(filldata[0]);

                    qry.InsertLogAktivitas("HitungBanyakStok", this, barcode, userName);
                }
            }

            return count;
        }

        private void CariStokBarang(string barcode)
        {
            idbarangdetail = "";
            qtybarangdetail = 0;
            tglbelibarangdetail = "";
            tester = "";

            string data = qry.GetData(this, "CariStokBarang", barcode, 0, "id,barcode,stok,tglbeli,tester", "barang_detail", 
                "barcode = '" + barcode + "' and stok > 0 order by tglbeli asc limit 1");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    idbarangdetail = filldata[0];
                    qtybarangdetail = Convert.ToDouble(filldata[2]);
                    tglbelibarangdetail = Convert.ToString(DateTime.Parse(filldata[3]).ToString("yyyy-MM-dd"));
                    tester = filldata[4];

                    qry.InsertLogAktivitas("CariStokBarang", this, barcode, userName);
                }
            }
        }

        private void DeleteStok(string idtransaksi)
        {
            try
            {
                DataSet ds = new DataSet();
                kon.OpenConn();
                kon.da = new MySqlDataAdapter("select idbarangdetail,barcode,stok from barang_display where idpindahgudang = '" + idtransaksi + "'", kon.con);
                kon.da.Fill(ds, "data");
                int row = ds.Tables["data"].Rows.Count - 1;

                for (int i = 0; i <= row; i++)
                {
                    qry.UpdateData("barang", "stokgudang = stokgudang + " + fs.FNum(ds.Tables["data"].Rows[i].ItemArray[2].ToString()) + "",
                            "barcode = '" + ds.Tables["data"].Rows[i].ItemArray[1].ToString() + "'");

                    qry.UpdateData("barang_detail", "stok = stok + " + fs.FNum(ds.Tables["data"].Rows[i].ItemArray[2].ToString()) + "",
                        "id = '" + ds.Tables["data"].Rows[i].ItemArray[0].ToString() + "'");
                }
            }
            catch (Exception ex)
            {
                psn.CreateLogErrorForm(this, "DeleteStok", "Hapus Stok " + idtransaksi + " Gagal", ex.ToString());
            }
            finally
            {
                kon.CloseConn();
            }
        }

        //harus ada mekanisme buat ngurangi qtymasuk terus tambah lagi di barang_display
        private void SimpanDisplay()
        {
            if (qry.DataExist(this, "Hapus", lblID.Text, cboLokasi.Text.Trim(), "b.idpindahgudang", 
                "penjualan_detail a inner join barang_display b on a.idbarangdetail = b.idbarangdetail", "b.idpindahgudang = '" + lblID.Text + "'"))
            {
                fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Data " + lblID.Text + " Telah Digunakan Untuk Transaksi Penjualan",
                    frmUtama.tooltip_x, frmUtama.tooltip_y, "warning");
            }
            else
            {
                try
                {
                    DeleteStok(lblID.Text);
                    qry.DeleteData("pindah_gudang", "id = '" + lblID.Text + "'");
                    qry.DeleteData("pindah_gudang_detail", "id = '" + lblID.Text + "'");
                    qry.DeleteData("barang_display", "idpindahgudang = '" + lblID.Text + "'");

                    if (lblID.Text == "AUTO ID")
                    {
                        lblID.Text = qry.CreateID(this, "Simpan", "id", "pindah_gudang", "id like 'MV." + dtTglTransaksi.Value.ToString("MMyyyy") + ".%'",
                            "MV." + dtTglTransaksi.Value.ToString("MMyyyy") + ".", "transaksi");
                    }

                    qry.InsertData("pindah_gudang", "id,tgltransaksi,catatan,lokasi,tglinput,tglupdate",
                        "'" + lblID.Text + "'," +
                        "'" + string.Format("{0:yyyy-MM-dd}", dtTglTransaksi.Value) + "'," +
                        "'" + txtCatatan.Text.Trim() + "'," +
                        "'" + cboLokasi.Text + "'," +
                        "'" + tglinput + "'," +
                        "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'");

                    for (int i = 0; i < dgTransaksi.Rows.Count; i++)
                    {
                        string barcode = dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString();
                        string nama = dgTransaksi.Rows[i].Cells[cellnama].Value.ToString();
                        string qty = dgTransaksi.Rows[i].Cells[cellqty].Value.ToString();
                        string qty1 = dgTransaksi.Rows[i].Cells[cellqty1].Value.ToString();
                        string satuan = dgTransaksi.Rows[i].Cells[cellsatuan].Value.ToString();
                        string comparesatuan = TampilSatuan1(barcode);

                        if (barcode != "" && Convert.ToDouble(qty) > 0)
                        {
                            qry.InsertData("pindah_gudang_detail", "id,barcode,nama,qty,satuan",
                                "'" + lblID.Text + "'," +
                                "'" + barcode + "'," +
                                "'" + nama + "'," +
                                "" + fs.FNum(qty) + "," +
                                "'" + satuan + "'");
                        }

                        if (comparesatuan == satuan)
                        {
                            int count = HitungBanyakStok(barcode);
                            double sisa = Convert.ToDouble(qty);

                            for (int j = 0; j < count; j++)
                            {
                                CariStokBarang(barcode);

                                if (qtybarangdetail >= sisa)
                                {
                                    qry.InsertData("barang_display", "idbarangdetail,tglbeli,idpindahgudang,barcode,stok,tester",
                                        "'" + idbarangdetail + "'," +
                                        "'" + tglbelibarangdetail + "'," +
                                        "'" + lblID.Text + "'," +
                                        "'" + barcode + "'," +
                                        "" + fs.FNum(sisa.ToString()) + "," +
                                        "" + tester + "");

                                    qry.UpdateData("barang_detail", "stok = stok - " + fs.FNum(sisa.ToString()) + "", "id = " + idbarangdetail + "");
                                    qry.UpdateData("barang", "stokgudang = stokgudang - " + fs.FNum(sisa.ToString()) + "", "barcode = '" + barcode + "'");

                                    break;
                                }
                                else if (qtybarangdetail < sisa)
                                {
                                    qry.InsertData("barang_display", "idbarangdetail,tglbeli,idpindahgudang,barcode,stok,tester",
                                        "'" + idbarangdetail + "'," +
                                        "'" + tglbelibarangdetail + "'," +
                                        "'" + lblID.Text + "'," +
                                        "'" + barcode + "'," +
                                        "" + fs.FNum(qtybarangdetail.ToString()) + "," +
                                        "" + tester + "");

                                    qry.UpdateData("barang_detail", "stok = stok - " + fs.FNum(qtybarangdetail.ToString()) + "", "id = " + idbarangdetail + "");
                                    qry.UpdateData("barang", "stokgudang = stokgudang - " + fs.FNum(qtybarangdetail.ToString()) + "", "barcode = '" + barcode + "'");

                                    sisa = sisa - qtybarangdetail;
                                }
                            }
                        }
                        else
                        {
                            qty1 = Convert.ToString(TampilQty2(barcode) * Convert.ToDouble(qty));
                            int count = HitungBanyakStok(barcode);
                            double sisa = Convert.ToDouble(qty1);

                            for (int j = 0; j > count; j++)
                            {
                                CariStokBarang(barcode);

                                if (qtybarangdetail >= sisa)
                                {
                                    qry.InsertData("barang_display", "idbarangdetail,tglbeli,idpindahgudang,barcode,stok,tester",
                                        "'" + idbarangdetail + "'," +
                                        "'" + tglbelibarangdetail + "'," +
                                        "'" + lblID.Text + "'," +
                                        "'" + barcode + "'," +
                                        "" + fs.FNum(sisa.ToString()) + "," +
                                        "" + tester + "");

                                    qry.UpdateData("barang_detail", "stok = stok - " + fs.FNum(sisa.ToString()) + "", "id = " + idbarangdetail + "");
                                    qry.UpdateData("barang", "stokgudang = stokgudang - " + fs.FNum(sisa.ToString()) + "", "barcode = '" + barcode + "'");

                                    break;
                                }
                                else if (qtybarangdetail < sisa)
                                {
                                    qry.InsertData("barang_display", "idbarangdetail,tglbeli,idpindahgudang,barcode,stok,tester",
                                        "'" + idbarangdetail + "'," +
                                        "'" + tglbelibarangdetail + "'," +
                                        "'" + lblID.Text + "'," +
                                        "'" + barcode + "'," +
                                        "" + fs.FNum(qtybarangdetail.ToString()) + "," +
                                        "" + tester + "");

                                    qry.UpdateData("barang_detail", "stok = stok - " + fs.FNum(qtybarangdetail.ToString()) + "", "id = " + idbarangdetail + "");
                                    qry.UpdateData("barang", "stokgudang = stokgudang - " + fs.FNum(qtybarangdetail.ToString()) + "", "barcode = '" + barcode + "'");

                                    sisa = sisa - qtybarangdetail;
                                }
                            }
                        }
                    }

                    qry.InsertLogAktivitas("Simpan", this, lblID.Text, userName);
                    fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Simpan " + this.Name.ToString() + " " + lblID.Text + " Berhasil",
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

        private void HapusDisplay()
        {
            if (qry.DataExist(this, "Hapus", lblID.Text, cboLokasi.Text.Trim(), "b.idpindahgudang",
                "penjualan_detail a inner join barang_display b on a.idbarangdetail = b.idbarangdetail", "b.idpindahgudang = '" + lblID.Text + "'"))
            {
                fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Data " + lblID.Text + " Telah Digunakan Untuk Transaksi Penjualan",
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
                        DeleteStok(lblID.Text);
                        qry.DeleteData("pindah_gudang", "id = '" + lblID.Text + "'");
                        qry.DeleteData("pindah_gudang_detail", "id = '" + lblID.Text + "'");
                        qry.DeleteData("barang_display", "idpindahgudang = '" + lblID.Text + "'");

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

        private void Cetak(string idtransaksi)
        {
            cls.OpenForm op = new cls.OpenForm(frmUtama);
            op.PreviewCetakOpen(this, "PreviewCetakData", idtransaksi, "", userName);
        }
        #endregion

        private void GudangPindah_Load(object sender, EventArgs e)
        {
            tglinput = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            rbNotaGudang.Checked = true;

            if (id != "")
                lblID.Text = id;

            frmUtama.lblNamaForm.Text = "- Pindah Gudang";
            UsrAccess();
        }

        private void GudangPindah_KeyPress(object sender, KeyPressEventArgs e)
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

        private void brnCariBarang_Click(object sender, EventArgs e)
        {
            cls.OpenForm op = new cls.OpenForm(frmUtama);
            op.ListOpen("List", "PindahGudang-BarangGudang", "BarangGudang", "", userName);

            txtKodeBarcode.Text = barcode;
            barcode = "";
            txtKodeBarcode.Focus();
        }

        private void brnCariBarang_Leave(object sender, EventArgs e)
        {
            dgTransaksi.Focus();
        }

        private void txtKodeBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                TampilBarang(txtKodeBarcode.Text);
                InsertDataGrid();
                namabarang = "";
                txtKodeBarcode.Text = "";
            }
        }

        private void txtKodeBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                brnCariBarang_Click(sender, e);
            }
        }

        private void cboLokasi_Leave(object sender, EventArgs e)
        {
            txtKodeBarcode.Focus();
        }

        private void dgTransaksi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgTransaksi.Columns["clHapus"].Index && e.RowIndex >= 0)
            {
                row = dgTransaksi.Rows[e.RowIndex];

                if (lblID.Text != "AUTO ID" && detailDelete == false)
                {
                    psn.PesanInfo("Anda Tidak Memiliki Hak Akses Untuk Menghapus Data, Silahkan Kontak ke Admin");
                }
                else if (dgTransaksi.Rows[e.RowIndex].Cells[cellbarcode].Value.ToString() != "")
                {
                    DialogResult result = MessageBox.Show("Apakah Data Ingin Dihapus?", "Konfirmasi", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        dgTransaksi.Rows.Remove(row);

                        qry.InsertLogAktivitas("dgTransaksi_CellClick", this, row.Cells[cellbarcode].Value.ToString(), userName);
                        psn.CreateLogSuccessForm(this, "dgTransaksi_CellClick", row.Cells[cellbarcode].Value.ToString());
                        fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Hapus Kode Barang " + row.Cells[cellbarcode].Value.ToString() + " dari List Pindah Gudang Berhasil",
                                frmUtama.tooltip_x, frmUtama.tooltip_y, "info");
                    }
                }
            }
            else if (e.ColumnIndex == dgTransaksi.Columns["clSatuan"].Index && e.RowIndex >= 0)
            {
                row = dgTransaksi.Rows[e.RowIndex];

                TampilSatuanBarang(row.Cells[cellbarcode].Value.ToString());
                pnlComboBox.Visible = true;
            }
        }

        private void dgTransaksi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgTransaksi.CurrentCell.ColumnIndex == cellqty)
            {
                char ch = e.KeyChar;
                if (!char.IsDigit(ch) && ch != 8 && ch != 46)
                {
                    e.Handled = true;
                }
            }
        }

        private void dgTransaksi_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(dgTransaksi_KeyPress);
            e.Control.KeyPress += new KeyPressEventHandler(dgTransaksi_KeyPress);
        }

        private void dgTransaksi_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            row = dgTransaksi.Rows[e.RowIndex];

            if ((dgTransaksi.Focused) && (dgTransaksi.CurrentCell.ColumnIndex == cellqty))
            {
                if (Convert.ToString(dgTransaksi.CurrentCell.Value) == "")
                {
                    dgTransaksi.CurrentCell.Value = "0.00";
                }
                else if (Convert.ToDouble(dgTransaksi.CurrentCell.Value) > Convert.ToDouble(row.Cells[cellstokbarang].Value))
                {
                    psn.PesanInfo("Stok Barang tidak mencukupi untuk pindah Gudang");
                    dgTransaksi.CurrentCell.Value = "0.00";
                }

                dgTransaksi.CurrentCell.Value = fs.FormatNumbCurr(Convert.ToString(dgTransaksi.CurrentCell.Value));
            }
        }

        private void dgTransaksi_Leave(object sender, EventArgs e)
        {
            btnSimpan.Focus();
        }

        private void btnHidePanel_Click(object sender, EventArgs e)
        {
            pnlComboBox.Visible = false;
            dgTransaksi.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            row.Cells[cellsatuan].Value = cboSatuan.Text;
            pnlComboBox.Visible = false;
            dgTransaksi.Focus();
        }

        private void lblID_TextChanged(object sender, EventArgs e)
        {
            TampilData(lblID.Text);
        }

        private void chkTerimaSemuaBarang_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTerimaSemuaBarang.Checked == true)
            {
                if (dgTransaksi.Rows.Count > 0)
                {
                    for (int i = 0; i < dgTransaksi.Rows.Count; i++)
                    {
                        dgTransaksi.Rows[i].Cells[cellqty].Value = fs.FormatNumbCurr(Convert.ToString(Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellstokbarang].Value)));
                    }
                }
            }
            else
            {
                if (dgTransaksi.Rows.Count > 0)
                {
                    for (int i = 0; i < dgTransaksi.Rows.Count; i++)
                    {
                        dgTransaksi.Rows[i].Cells[cellqty].Value = "0.00";
                    }
                }
            }
        }

        private void rbNotaGudang_CheckedChanged(object sender, EventArgs e)
        {
            if(rbNotaGudang.Checked == true)
            {
                txtIDGudang.Enabled = true;
                btnCariIDGudang.Enabled = true;
            }
            else
            {
                txtIDGudang.Enabled = false;
                btnCariIDGudang.Enabled = false;
            }
        }

        private void rbBarang_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBarang.Checked == true)
            {
                txtKodeBarcode.Enabled = true;
                brnCariBarang.Enabled = true;
            }
            else
            {
                txtKodeBarcode.Enabled = false;
                brnCariBarang.Enabled = false;
            }
        }

        private void btnCariIDGudang_Click(object sender, EventArgs e)
        {
            cls.OpenForm op = new cls.OpenForm(frmUtama);
            op.ListOpen("List", "PindahGudang-GudangMasuk", "GudangMasuk", "", userName);

            txtIDGudang.Text = idGudangMasuk;
            idGudangMasuk = "";
            txtIDGudang.Focus();
        }

        private void btnCariIDGudang_Leave(object sender, EventArgs e)
        {
            dgTransaksi.Focus();
        }

        private void txtIDGudang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                TampilDataGudangMasuk();
            }
        }

        private void txtIDGudang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                btnCariIDGudang_Click(sender, e);
            }
        }
    }
}
