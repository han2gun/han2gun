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
    public partial class ReturPenjualan : Form
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
        double tempDiskon;
        double tempDiskonRow;
        string tglinput;

        public static string idcustomer;
        public static string idpenjualan;
        public static string barcode;
        public static string strkondisi;

        //variabel cell
        int cellhapus;
        int cellbarcode;
        int cellnama;
        int cellketerangan;
        int cellqty;
        int cellsatuan;
        int cellhjual;
        int celldiscpersen;
        int celldiscrp;
        int cellsubtotal;
        int cellsubtotalhpp;
        int cellkondisi;
        //int cellstokdisplay;

        string namabarang;
        string keterangan;
        string qty;
        string satuan1;
        string hargajual;
        string discpersen;
        string discrp;
        string subtotal;
        string subtotalhpp;
        string kondisi;

        string idbarangdisplay;
        double qtybarangdetail;

        bool detailDelete;
        DataGridViewRow row;

        public ReturPenjualan(MenuUtama mnutama)
        {
            InitializeComponent();

            frmUtama = mnutama;
            idUpdate = "";
            updateData = false;
            cellhapus = 0;
            cellbarcode = 1;
            cellnama = 2;
            cellketerangan = 3;
            cellqty = 4;
            cellsatuan = 5;
            cellhjual = 6;
            celldiscpersen = 7;
            celldiscrp = 8;
            cellsubtotal = 9;
            cellsubtotalhpp = 10;
            cellkondisi = 11;
            //cellstokdisplay = 10;
            namabarang = "";
            kondisi = "0";
            detailDelete = true;
            fs.BoldHeaderDataGridView(dgTransaksi);
            this.KeyDown += new KeyEventHandler(this.OnKeyDown);
            ActiveControl = txtKodeBarcode;
        }

        #region code
        private void UsrAccess()
        {
            string data = qry.GetData(this, "UsrAccess", userName, 0,
                "returpenjualansv,returpenjualandel,returpenjualanprt,returpenjualanup", "usrmgmt", "usrname = '" + userName + "'");

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
            fs.FillTextBoxArray(new TextBox[] { txtIdCustomer, txtIDPenjualan, txtCatatan, txtKodeBarcode }, "");
            fs.FillLabelArray(new Label[] { lblGrandTotal }, "0.00");
            lblNamaCustomer.Text = "";
            dtTglTransaksi.Value = DateTime.Today;
            tglinput = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dgTransaksi.Rows.Clear();
            lblID.Text = "AUTO ID";
            kondisi = "0";
            txtKodeBarcode.Focus();
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
                    if (txtIdCustomer.Text.Trim() == "")
                    {
                        psn.PesanInfo("Customer Masih Kosong");
                        txtIdCustomer.Focus();
                    }
                    else if (txtIDPenjualan.Text.Trim() == "")
                    {
                        psn.PesanInfo("ID Penjualan Masih Kosong");
                        txtIDPenjualan.Focus();
                    }
                    else if (dgTransaksi.Rows.Count <= 0)
                    {
                        psn.PesanInfo("Detail Transaksi Masih Kosong");
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
                        psn.PesanInfo("ID Retur Penjualan Masih Kosong");
                    }
                    else
                    {
                        Hapus();
                    }
                    break;
                case "CETAK":
                    if (txtIdCustomer.Text.Trim() == "")
                    {
                        psn.PesanInfo("Customer Masih Kosong");
                        txtIdCustomer.Focus();
                    }
                    else if (txtIDPenjualan.Text.Trim() == "")
                    {
                        psn.PesanInfo("ID Penjualan Masih Kosong");
                        txtIDPenjualan.Focus();
                    }
                    else if (dgTransaksi.Rows.Count <= 0)
                    {
                        psn.PesanInfo("Detail Transaksi Masih Kosong");
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

                    break;
                case "KELUAR":
                    cls.OpenForm op = new cls.OpenForm(frmUtama);
                    op.PencarianOpen("Pencarian", "ReturPenjualan", userName);
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
                case Keys.F12:
                    if (btnCetak.Enabled == true)
                        SelectToolBar(btnCetak);
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
            idUpdate = "";

            string data = qry.GetData(this, "TampilData", id, 13, "id,idcustomer,idpenjualan,tgltransaksi,catatan,grandtotal,tglinput",
                "retur_penjualan", "id = '" + id + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    idUpdate = filldata[0]; //jika kosong berarti data baru, jika muncul id data lama -> cek status boleh update atau tidak
                    txtIdCustomer.Text = filldata[1];
                    txtIDPenjualan.Text = filldata[2];
                    dtTglTransaksi.Value = Convert.ToDateTime(filldata[3]);
                    txtCatatan.Text = filldata[4];
                    lblGrandTotal.Text = fs.FormatNumbCurr(filldata[5]);
                    tglinput = DateTime.Parse(filldata[6]).ToString("yyyy-MM-dd HH:mm:ss");

                    TampilDetailData(id);

                    qry.InsertLogAktivitas("TampilData", this, lblID.Text, userName);
                }
            }
        }

        private void TampilCustomer(string id)
        {
            string data = qry.GetData(this, "TampilCustomer", id, 8, "id,nama", "customer", "id = '" + id + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    lblNamaCustomer.Text = filldata[1];

                    qry.InsertLogAktivitas("TampilCustomer", this, txtIdCustomer.Text, userName);
                }
            }
        }

        private void TampilDetailData(string id)
        {
            qry.DataGridViewFill(this, dgTransaksi, "TampilDetailData", "id,barcode,nama,keterangan,qty,satuan,hjual,discpersen,discrp,subtotal,subtotalhpp,kondisi",
                "retur_penjualan_detail", "id = '" + id + "'");

            int row = qry.ds.Tables["detail"].Rows.Count - 1;

            if (row >= 0)
            {
                for (int i = 0; i <= row; i++)
                {
                    dgTransaksi.Rows.Add();
                    dgTransaksi.Rows[i].Cells[cellhapus].Value = "X";
                    dgTransaksi.Rows[i].Cells[cellbarcode].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[1];
                    dgTransaksi.Rows[i].Cells[cellnama].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[2];
                    dgTransaksi.Rows[i].Cells[cellketerangan].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[3];
                    dgTransaksi.Rows[i].Cells[cellqty].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[4].ToString());
                    dgTransaksi.Rows[i].Cells[cellsatuan].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[5];
                    dgTransaksi.Rows[i].Cells[cellhjual].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[6].ToString());
                    dgTransaksi.Rows[i].Cells[celldiscpersen].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[7].ToString());
                    dgTransaksi.Rows[i].Cells[celldiscrp].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[8].ToString());
                    dgTransaksi.Rows[i].Cells[cellsubtotal].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[9].ToString());
                    dgTransaksi.Rows[i].Cells[cellsubtotalhpp].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[10].ToString());
                    dgTransaksi.Rows[i].Cells[cellkondisi].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[11].ToString());
                }

                dgTransaksi.AutoResizeColumns();
                qry.InsertLogAktivitas("TampilDetailData", this, lblID.Text, userName);
            }
        }

        private void TampilBarang(string barcode, string kondisi)
        {
            string data = qry.GetData(this, "TampilBarang", id, 8, "barcode,nama,keterangan,qty,satuan,hjual,discpersen,discrp,subtotal,subtotalhpp",
                "penjualan_detail", "barcode = '" + barcode + "' and kondisi = " + kondisi + "");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    namabarang = filldata[1];
                    keterangan = filldata[2];
                    qty = fs.FormatNumbCurr(filldata[3]);
                    satuan1 = filldata[4];
                    hargajual = fs.FormatNumbCurr(filldata[5]);
                    discpersen = fs.FormatNumbCurr(filldata[6]);
                    discrp = fs.FormatNumbCurr(Convert.ToString(Convert.ToDouble(filldata[7]) / Convert.ToDouble(filldata[3]))); //discrp per satuan qty
                    subtotal = fs.FormatNumbCurr(Convert.ToString(Convert.ToDouble(filldata[8]) / Convert.ToDouble(filldata[3]))); //discrp per satuan qty
                    subtotalhpp = fs.FormatNumbCurr(Convert.ToString(Convert.ToDouble(filldata[9]) / Convert.ToDouble(filldata[3]))); //discrp per satuan qty

                    qry.InsertLogAktivitas("TampilBarang", this, txtKodeBarcode.Text, userName);
                }
            }
        }

        //cek lagi
        private void InsertDataGrid()
        {
            bool match = true;

            if (namabarang != "")
            {
                int row = dgTransaksi.Rows.Count - 1;

                if (kondisi == "1")
                {
                    if (row >= 0)
                    {
                        for(int i = 0; i <= row; i++)
                        {
                            if (dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString() == txtKodeBarcode.Text.Trim() && 
                                dgTransaksi.Rows[i].Cells[cellkondisi].Value.ToString() == kondisi)
                            {
                                //cek ketersediaan qty pembelian dahulu
                                if(Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellqty].Value) >= 
                                    CekQtyPenjualan(dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString(),"1") -
                                    CekQtySudahReturJual(lblID.Text, txtIDPenjualan.Text, dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString(), "1"))
                                {
                                    psn.PesanInfo("Stok Penjualan Sudah Tidak Mencukupi Untuk di Retur");
                                }
                                else
                                {
                                    dgTransaksi.Rows[i].Cells[cellqty].Value = fs.FormatNumbCurr((Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellqty].Value) + 1).ToString());
                                    dgTransaksi.Rows[i].Cells[celldiscrp].Value =
                                        fs.FormatNumbCurr(Convert.ToString(Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellqty].Value) * Convert.ToDouble(dgTransaksi.Rows[i].Cells[celldiscrp].Value)));
                                    dgTransaksi.Rows[i].Cells[cellsubtotal].Value =
                                        fs.FormatNumbCurr(Convert.ToString(Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellqty].Value) * Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellsubtotal].Value)));
                                    dgTransaksi.Rows[i].Cells[cellsubtotalhpp].Value =
                                        fs.FormatNumbCurr(Convert.ToString(Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellqty].Value) * Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellsubtotalhpp].Value)));
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
                            dgTransaksi.Rows.Add("X", txtKodeBarcode.Text.Trim(), namabarang, keterangan, "1.00", satuan1, hargajual,
                                discpersen, discrp, subtotal, subtotalhpp, "1");
                        }
                    }
                    else
                    {
                        dgTransaksi.Rows.Add("X", txtKodeBarcode.Text.Trim(), namabarang, keterangan, "1.00", satuan1, hargajual,
                                discpersen, discrp, subtotal, subtotalhpp, "1");
                    }
                }
                else
                {
                    if (row >= 0)
                    {
                        for (int i = 0; i <= row; i++)
                        {
                            if (dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString() == txtKodeBarcode.Text.Trim() &&
                                dgTransaksi.Rows[i].Cells[cellkondisi].Value.ToString() == kondisi)
                            {
                                //cek ketersediaan qty pembelian dahulu
                                if (Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellqty].Value) >=
                                    CekQtyPenjualan(dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString(), "0") -
                                    CekQtySudahReturJual(lblID.Text, txtIDPenjualan.Text, dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString(), "0"))
                                {
                                    psn.PesanInfo("Stok Penjualan Sudah Tidak Mencukupi Untuk di Retur");
                                }
                                else
                                {
                                    dgTransaksi.Rows[i].Cells[cellqty].Value = fs.FormatNumbCurr((Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellqty].Value) + 1).ToString());
                                    dgTransaksi.Rows[i].Cells[celldiscrp].Value =
                                        fs.FormatNumbCurr(Convert.ToString(Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellqty].Value) * Convert.ToDouble(dgTransaksi.Rows[i].Cells[celldiscrp].Value)));
                                    dgTransaksi.Rows[i].Cells[cellsubtotal].Value =
                                        fs.FormatNumbCurr(Convert.ToString(Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellqty].Value) * Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellsubtotal].Value)));
                                    dgTransaksi.Rows[i].Cells[cellsubtotalhpp].Value =
                                        fs.FormatNumbCurr(Convert.ToString(Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellqty].Value) * Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellsubtotalhpp].Value)));
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
                            dgTransaksi.Rows.Add("X", txtKodeBarcode.Text.Trim(), namabarang, keterangan, "1.00", satuan1, hargajual,
                                discpersen, discrp, subtotal, subtotalhpp, "0");
                        }
                    }
                    else
                    {
                        dgTransaksi.Rows.Add("X", txtKodeBarcode.Text.Trim(), namabarang, keterangan, "1.00", satuan1, hargajual,
                                discpersen, discrp, subtotal, subtotalhpp, "0");
                    }
                }
            }
        }

        private double HitungTotal()
        {
            double subtotal = 0;

            if (dgTransaksi.Rows.Count > 0)
            {
                for (int i = 0; i < dgTransaksi.Rows.Count; i++)
                {
                    if (dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString() != "")
                    {
                        subtotal = subtotal + Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellsubtotal].Value);
                    }
                }
            }
            else
            {
                subtotal = 0;
            }

            return subtotal;
        }

        private double CekQtyPenjualan(string barcode, string kondisi)
        {
            double stok = 0;

            string data = qry.GetData(this, "CekQtyPenjualan", barcode, 0, "sum(qty)", "penjualan_detail",
                "id = '" + txtIDPenjualan.Text.Trim() + "' and barcode = '" + barcode + "' and kondisi = " + kondisi + " group by barcode,kondisi");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    stok = Convert.ToInt32(filldata[0]);

                    qry.InsertLogAktivitas("CekQtyPenjualan", this, barcode, userName);
                }
            }

            return stok;
        }

        private double CekQtySudahReturJual(string idretur, string idpenjualan, string barcode, string kondisi)
        {
            double stok = 0;

            string data = qry.GetData(this, "CekQtySudahReturJual", barcode, 0, "sum(b.qty)",
                "retur_penjualan a inner join retur_penjualan_detail b on a.id = b.id ",
                "a.id != '" + lblID.Text + "' and a.idpenjualan = '" + txtIDPenjualan.Text.Trim() + "' " +
                "and b.barcode = '" + barcode + "' and b.kondisi = " + kondisi + " group by b.barcode,b.kondisi");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    stok = Convert.ToInt32(filldata[0]);

                    qry.InsertLogAktivitas("CekQtySudahReturJual", this, barcode, userName);
                }
            }

            return stok;
        }

        private void DeleteStok(string idtransaksi)
        {
            try
            {
                DataSet ds = new DataSet();
                kon.OpenConn();
                kon.da = new MySqlDataAdapter("select barcode,qty,subtotalhpp from retur_penjualan_detail where id = '" + idtransaksi + "'", kon.con);
                kon.da.Fill(ds, "data");
                int row = ds.Tables["data"].Rows.Count - 1;

                if (row >= 0)
                {
                    for (int i = 0; i <= row; i++)
                    {
                        qry.UpdateData("barang", "stokgudang = stokgudang - " + fs.FNum(ds.Tables["data"].Rows[i].ItemArray[1].ToString()) + "," +
                            "stokrupiah = stokrupiah - " + fs.FNum(ds.Tables["data"].Rows[i].ItemArray[2].ToString()) + "",
                            "barcode = '" + ds.Tables["data"].Rows[i].ItemArray[0].ToString() + "'");
                    }
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

        private void Simpan()
        {
            try
            {
                DeleteStok(lblID.Text);
                qry.DeleteData("retur_penjualan", "id = '" + lblID.Text + "'");
                qry.DeleteData("retur_penjualan_detail", "id = '" + lblID.Text + "'");

                if (lblID.Text == "AUTO ID")
                {
                    lblID.Text = qry.CreateID(this, "Simpan", "id", "retur_penjualan", "id like 'RJ." + dtTglTransaksi.Value.ToString("MMyyyy") + ".%'",
                        "RJ." + dtTglTransaksi.Value.ToString("MMyyyy") + ".", "transaksi");
                }

                qry.InsertData("retur_penjualan", "id,idcustomer,idpenjualan,tgltransaksi,catatan,grandtotal,tglinput,tglupdate",
                    "'" + lblID.Text + "'," +
                    "'" + txtIdCustomer.Text.Trim() + "'," +
                    "'" + txtIDPenjualan.Text.Trim() + "'," +
                    "'" + string.Format("{0:yyyy-MM-dd}", dtTglTransaksi.Value) + "'," +
                    "'" + txtCatatan.Text.Trim() + "'," +
                    "" + fs.FNum(lblGrandTotal.Text) + "," +
                    "'" + tglinput + "'," +
                    "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'");


                for (int i = 0; i < dgTransaksi.Rows.Count; i++)
                {
                    string barcode = dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString();
                    string nama = dgTransaksi.Rows[i].Cells[cellnama].Value.ToString();
                    string keterangan = dgTransaksi.Rows[i].Cells[cellketerangan].Value.ToString();
                    string qty = dgTransaksi.Rows[i].Cells[cellqty].Value.ToString();
                    string satuan = dgTransaksi.Rows[i].Cells[cellsatuan].Value.ToString();
                    string hjual = dgTransaksi.Rows[i].Cells[cellhjual].Value.ToString();
                    string diskpersen = dgTransaksi.Rows[i].Cells[celldiscpersen].Value.ToString();
                    string diskrp = dgTransaksi.Rows[i].Cells[celldiscrp].Value.ToString();
                    string subtotal = dgTransaksi.Rows[i].Cells[cellsubtotal].Value.ToString();
                    string subtotalhpp = dgTransaksi.Rows[i].Cells[cellsubtotalhpp].Value.ToString();
                    string kondisi = dgTransaksi.Rows[i].Cells[cellkondisi].Value.ToString();

                    /*double hpp = CekHPP(txtIDPenjualan.Text.Trim(), barcode, fs.FNum(hjual));
                    double subtotalhpp = hpp * Convert.ToDouble(qty);*/

                    //tandai
                    if (barcode != "" && Convert.ToDouble(qty) > 0)
                    {
                        qry.InsertData("retur_penjualan_detail", "id,barcode,nama,keterangan,qty,satuan,hjual,discpersen,discrp,subtotal,subtotalhpp,kondisi",
                            "'" + lblID.Text + "'," +
                            "'" + barcode + "'," +
                            "'" + nama + "'," +
                            "'" + keterangan + "'," +
                            "" + fs.FNum(qty) + "," +
                            "'" + satuan + "'," +
                            "" + fs.FNum(hjual) + "," +
                            "" + fs.FNum(diskpersen) + "," +
                            "" + fs.FNum(diskrp) + "," +
                            "" + fs.FNum(subtotal) + "," +
                            "" + fs.FNum(subtotalhpp.ToString()) + "," +
                            "" + kondisi + "");
                    }

                    qry.UpdateData("barang", "stokgudang = stokgudang + " + fs.FNum(qty) + "," +
                        "stokrupiah = stokrupiah + " + fs.FNum(subtotalhpp.ToString()) + "", "barcode = '" + barcode + "'");
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

        private void Hapus()
        {
            DialogResult result = MessageBox.Show("Hapus Data?", "Konfirmasi", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DeleteStok(lblID.Text); //tandai
                    qry.DeleteData("retur_penjualan", "id = '" + lblID.Text + "'");
                    qry.DeleteData("retur_penjualan_detail", "id = '" + lblID.Text + "'");

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

        private void Cetak(string idtransaksi)
        {
            cls.OpenForm op = new cls.OpenForm(frmUtama);
            op.PreviewCetakOpen(this, "PreviewCetakData", idtransaksi, "", userName);
        }
        #endregion

        private void ReturPenjualan_Load(object sender, EventArgs e)
        {
            tglinput = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (id != "")
                lblID.Text = id;

            frmUtama.lblNamaForm.Text = "- Retur Penjualan";
            UsrAccess();
        }

        private void ReturPenjualan_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnCariCustomer_Click(object sender, EventArgs e)
        {
            if (dgTransaksi.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Mengubah ID Customer Maka List Akan Dibersihkan, Apakah Anda Akan Melanjutkan?", "Konfirmasi", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    dgTransaksi.Rows.Clear();

                    cls.OpenForm op = new cls.OpenForm(frmUtama);
                    op.ListOpen("List", "ReturPenjualan-Customer", "Customer", "", userName);

                    txtIdCustomer.Text = idcustomer;
                    idcustomer = "";
                }
            }
            else
            {
                cls.OpenForm op = new cls.OpenForm(frmUtama);
                op.ListOpen("List", "ReturPenjualan-Customer", "Customer", "", userName);

                txtIdCustomer.Text = idcustomer;
                idcustomer = "";
            }
        }

        private void txtIdCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.AllowOnlyBackspace(e);
        }

        private void txtIdCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                btnCariCustomer_Click(sender, e);
            }
        }

        private void txtIdCustomer_TextChanged(object sender, EventArgs e)
        {
            TampilCustomer(txtIdCustomer.Text.Trim());
        }

        private void txtCatatan_Leave(object sender, EventArgs e)
        {
            txtKodeBarcode.Focus();
        }

        private void brnCariBarang_Click(object sender, EventArgs e)
        {
            cls.OpenForm op = new cls.OpenForm(frmUtama);
            op.ListOpen("List", "ReturPenjualan-Barang", "BarangByIDPenjualan", txtIDPenjualan.Text.Trim(), userName);

            txtKodeBarcode.Text = barcode;
            kondisi = strkondisi;
            strkondisi = "";
            barcode = "";
            txtKodeBarcode.Focus();
        }

        private void txtKodeBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                TampilBarang(txtKodeBarcode.Text, kondisi);

                if (namabarang == "")
                {
                    psn.PesanInfo("Kode Barang " + txtKodeBarcode.Text.Trim() + " Tidak Ada Dalam Database");
                    txtKodeBarcode.Text = "";
                    kondisi = "0";
                    txtKodeBarcode.Focus();
                }
                else if (CekQtyPenjualan(txtKodeBarcode.Text.Trim(), kondisi) - CekQtySudahReturJual(lblID.Text, txtIDPenjualan.Text.Trim(), txtKodeBarcode.Text.Trim(), kondisi) <= 0)
                {
                    psn.PesanInfo("Stok Penjualan Sudah Tidak Mencukupi Untuk di Retur");
                }
                else
                {
                    InsertDataGrid();
                    lblGrandTotal.Text = fs.FormatNumbCurr(HitungTotal().ToString());
                    namabarang = "";
                    kondisi = "0";
                    txtKodeBarcode.Text = "";
                }
            }
        }

        private void txtKodeBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                brnCariBarang_Click(sender, e);
            }
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

                        lblGrandTotal.Text = fs.FormatNumbCurr(HitungTotal().ToString());

                        qry.InsertLogAktivitas("dgTransaksi_CellClick", this, row.Cells[cellbarcode].Value.ToString(), userName);
                        psn.CreateLogSuccessForm(this, "dgTransaksi_CellClick", row.Cells[cellbarcode].Value.ToString());
                        fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Hapus Kode Barang " + row.Cells[cellbarcode].Value.ToString() + " dari List Retur Penjualan Berhasil",
                                frmUtama.tooltip_x, frmUtama.tooltip_y, "info");
                    }
                }
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
            else if (dgTransaksi.CurrentCell.ColumnIndex == cellketerangan)
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
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
                TampilBarang(row.Cells[cellbarcode].Value.ToString(), row.Cells[cellkondisi].Value.ToString());
                namabarang = "";

                if (Convert.ToString(dgTransaksi.CurrentCell.Value) == "")
                {
                    dgTransaksi.CurrentCell.Value = "0.00";
                }
                else if (Convert.ToDouble(dgTransaksi.CurrentCell.Value.ToString()) >
                    CekQtyPenjualan(row.Cells[cellbarcode].Value.ToString(), row.Cells[cellkondisi].Value.ToString()) -
                    CekQtySudahReturJual(lblID.Text, txtIDPenjualan.Text.Trim(), row.Cells[cellbarcode].Value.ToString(), row.Cells[cellkondisi].Value.ToString()))
                {
                    psn.PesanInfo("Stok Penjualan Sudah Tidak Mencukupi Untuk di Retur");
                    dgTransaksi.CurrentCell.Value = "1.00";
                }
                dgTransaksi.CurrentCell.Value = fs.FormatNumbCurr(Convert.ToString(dgTransaksi.CurrentCell.Value));

                row.Cells[celldiscrp].Value = fs.FormatNumbCurr(Convert.ToString(Convert.ToDouble(discrp) * Convert.ToDouble(dgTransaksi.CurrentCell.Value)));
                row.Cells[cellsubtotal].Value = fs.FormatNumbCurr(Convert.ToString(Convert.ToDouble(subtotal) * Convert.ToDouble(dgTransaksi.CurrentCell.Value)));
                row.Cells[cellsubtotalhpp].Value = fs.FormatNumbCurr(Convert.ToString(Convert.ToDouble(subtotalhpp) * Convert.ToDouble(dgTransaksi.CurrentCell.Value)));
            }
            lblGrandTotal.Text = fs.FormatNumbCurr(HitungTotal().ToString());
        }

        private void lblID_TextChanged(object sender, EventArgs e)
        {
            TampilData(lblID.Text);
        }

        private void btnCariIDPenjualan_Click(object sender, EventArgs e)
        {
            if(dgTransaksi.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Mengubah ID Penjualan Maka List Akan Dibersihkan, Apakah Anda Akan Melanjutkan?", "Konfirmasi", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    dgTransaksi.Rows.Clear();

                    cls.OpenForm op = new cls.OpenForm(frmUtama);
                    op.ListOpen("List", "ReturPenjualan-IDPenjualan", "PenjualanByCustomer", txtIdCustomer.Text.Trim(), userName);

                    txtIDPenjualan.Text = idpenjualan;
                    idpenjualan = "";
                }
            }
            else
            {
                cls.OpenForm op = new cls.OpenForm(frmUtama);
                op.ListOpen("List", "ReturPenjualan-IDPenjualan", "PenjualanByCustomer", txtIdCustomer.Text.Trim(), userName);

                txtIDPenjualan.Text = idpenjualan;
                idpenjualan = "";
            }
        }

        private void txtIDPenjualan_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.AllowOnlyBackspace(e);
        }

        private void txtIDPenjualan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                btnCariIDPenjualan_Click(sender, e);
            }
        }
    }
}
