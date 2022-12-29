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
    public partial class ReturPembelian : Form
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
        double tempDiskonRow;

        public static string idsupplier;
        public static string idpembelian;
        public static string barcode;
        public static string strkondisi;

        //variabel cell
        int cellhapus;
        int cellkondisi;
        int cellbarcode;
        int cellnama;
        int cellketerangan;
        int cellqty;
        int cellsatuan;
        int cellhbeli;
        int celldiscpersen;
        int celldiscpersen2;
        int celldiscpersen3;
        int celldiscrp;
        int cellsubtotal;
        int cellsubtotalbersih;

        string namabarang;
        string keterangan;
        string qty;
        string satuan1;
        string hargabeli;
        string discpersen;
        string discpersen2;
        string discpersen3;
        string discrp;
        string subtotal;
        string subtotalbersih;
        string kondisi;

        bool detailDelete;
        DataGridViewRow row;

        public ReturPembelian(MenuUtama mnutama)
        {
            InitializeComponent();
            frmUtama = mnutama;
            idUpdate = "";
            updateData = false;
            cellhapus = 0;
            cellkondisi = 1;
            cellbarcode = 2;
            cellnama = 3;
            cellketerangan = 4;
            cellqty = 5;
            cellsatuan = 6;
            cellhbeli = 7;
            celldiscpersen = 8;
            celldiscpersen2 = 9;
            celldiscpersen3 = 10;
            celldiscrp = 11;
            cellsubtotal = 12;
            cellsubtotalbersih = 13;
            namabarang = "";
            kondisi = "0";
            detailDelete = true;
            fs.BoldHeaderDataGridView(dgTransaksi);
            this.KeyDown += new KeyEventHandler(this.OnKeyDown);
            ActiveControl = txtIdSupplier;
        }

        #region code
        private void UsrAccess()
        {
            string data = qry.GetData(this, "UsrAccess", userName, 0,
                "returpembeliansv,returpembeliandel,returpembelianprt,returpembelianup", "usrmgmt", "usrname = '" + userName + "'");

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
            fs.FillTextBoxArray(new TextBox[] { txtIdSupplier, txtIDPembelian, txtCatatan, txtKodeBarcode }, "");
            fs.FillTextBoxArray(new TextBox[] { txtDiskonPersenPembelian, txtDiskonRpPembelian, txtPotLainPembelian,
                txtBiayaLainPembelian, txtPPnPembelian, txtOngkirPembelian, txtOngkir }, "0.00");
            fs.FillLabelArray(new Label[] { lblNoNota, lblTotal, lblGrandTotal, lblTotalQtyPembelian }, "0.00");
            chkPPnPembelian.Checked = false;
            lblNamaSupplier.Text = "";
            dtTglTransaksi.Value = DateTime.Today;
            tglinput = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dgTransaksi.Rows.Clear();
            lblID.Text = "AUTO ID";
            kondisi = "0";
            txtIdSupplier.Focus();
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
                    if (txtIdSupplier.Text.Trim() == "")
                    {
                        psn.PesanInfo("Supplier Masih Kosong");
                        txtIdSupplier.Focus();
                    }
                    else if (txtIDPembelian.Text.Trim() == "")
                    {
                        psn.PesanInfo("ID Pembelian Masih Kosong");
                        txtIDPembelian.Focus();
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
                        psn.PesanInfo("ID Retur Pembelian Masih Kosong");
                    }
                    else
                    {
                        Hapus();
                    }
                    break;
                case "CETAK":
                    if (txtIdSupplier.Text.Trim() == "")
                    {
                        psn.PesanInfo("Supplier Masih Kosong");
                        txtIdSupplier.Focus();
                    }
                    else if (txtIDPembelian.Text.Trim() == "")
                    {
                        psn.PesanInfo("ID Pembelian Masih Kosong");
                        txtIDPembelian.Focus();
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
                    op.PencarianOpen("Pencarian", "ReturPembelian", userName);
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

            string data = qry.GetData(this, "TampilData", id, 13, "id,idsupplier,idpembelian,tgltransaksi,catatan,total,ongkir,grandtotal,tglinput",
                "retur_pembelian", "id = '" + id + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    idUpdate = filldata[0]; //jika kosong berarti data baru, jika muncul id data lama -> cek status boleh update atau tidak
                    txtIdSupplier.Text = filldata[1];
                    txtIDPembelian.Text = filldata[2];
                    dtTglTransaksi.Value = Convert.ToDateTime(filldata[3]);
                    txtCatatan.Text = filldata[4];
                    lblTotal.Text = fs.FormatNumbCurr(filldata[5]);
                    txtOngkir.Text = fs.FormatNumbCurr(filldata[6]);
                    lblGrandTotal.Text = fs.FormatNumbCurr(filldata[7]);
                    tglinput = DateTime.Parse(filldata[8]).ToString("yyyy-MM-dd HH:mm:ss");

                    TampilDetailData(id);

                    qry.InsertLogAktivitas("TampilData", this, lblID.Text, userName);
                }
            }
        }

        private void TampilSupplier(string id)
        {
            string data = qry.GetData(this, "TampilSupplier", id, 8, "id,nama", "supplier", "id = '" + id + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    lblNamaSupplier.Text = filldata[1];

                    qry.InsertLogAktivitas("TampilSupplier", this, txtIdSupplier.Text, userName);
                }
            }
        }

        private void TampilPembelian(string id)
        {
            string data = qry.GetData(this, "TampilPembelian", id, 8, "id,nonota,discpersen,discrp,potlain,biayalain,ppn,ppnnominal,ongkir", "pembelian", "id = '" + id + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    lblNoNota.Text = filldata[1];
                    txtDiskonPersenPembelian.Text = fs.FormatNumbCurr(filldata[2]);
                    txtDiskonRpPembelian.Text = fs.FormatNumbCurr(filldata[3]);
                    txtPotLainPembelian.Text = fs.FormatNumbCurr(filldata[4]);
                    txtBiayaLainPembelian.Text = fs.FormatNumbCurr(filldata[5]);
                    chkPPnPembelian.Checked = fs.IntToBool(filldata[6]);
                    txtPPnPembelian.Text = fs.FormatNumbCurr(filldata[7]);
                    txtOngkir.Text = fs.FormatNumbCurr(filldata[8]);

                    qry.InsertLogAktivitas("TampilPembelian", this, txtIDPembelian.Text, userName);
                }
            }
        }

        private void TampilTotalQtyPembelian(string id)
        {
            string data = qry.GetData(this, "TampilTotalQtyPembelian", id, 8, "id,sum(qty)", "pembelian_detail", "id = '" + id + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    lblTotalQtyPembelian.Text = filldata[1];

                    qry.InsertLogAktivitas("TampilTotalQtyPembelian", this, txtIDPembelian.Text, userName);
                }
            }
        }

        private void TampilDetailData(string id)
        {
            qry.DataGridViewFill(this, dgTransaksi, "TampilDetailData", "id,barcode,nama,keterangan,qty,satuan,hbeli," +
                "discpersen,discpersen2,discpersen3,discrp,subtotal,subtotalbersih,kondisi",
                "retur_pembelian_detail", "id = '" + id + "'");

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
                    dgTransaksi.Rows[i].Cells[cellhbeli].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[6].ToString());
                    dgTransaksi.Rows[i].Cells[celldiscpersen].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[7].ToString());
                    dgTransaksi.Rows[i].Cells[celldiscpersen2].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[8].ToString());
                    dgTransaksi.Rows[i].Cells[celldiscpersen3].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[9].ToString());
                    dgTransaksi.Rows[i].Cells[celldiscrp].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[10].ToString());
                    dgTransaksi.Rows[i].Cells[cellsubtotal].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[11].ToString());
                    dgTransaksi.Rows[i].Cells[cellsubtotalbersih].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[12].ToString());
                    dgTransaksi.Rows[i].Cells[cellkondisi].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[13];
                }

                dgTransaksi.AutoResizeColumns();
                qry.InsertLogAktivitas("TampilDetailData", this, lblID.Text, userName);
            }
        }

        private void TampilBarang(string id, string barcode,string kondisi)
        {
            string data = qry.GetData(this, "TampilBarang", id, 8, "barcode,nama,keterangan,qty,satuan,hbeli,discpersen,discpersen2,discpersen3,discrp,subtotal,subtotalbersih",
                "pembelian_detail", "id = '" + id + "' and barcode = '" + barcode + "' and kondisi = " + kondisi + "");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    namabarang = filldata[1];
                    keterangan = filldata[2];
                    qty = fs.FormatNumbCurr(filldata[3]);
                    satuan1 = filldata[4];
                    hargabeli = fs.FormatNumbCurr(filldata[5]);
                    discpersen = fs.FormatNumbCurr(filldata[6]);
                    discpersen2 = fs.FormatNumbCurr(filldata[7]);
                    discpersen3 = fs.FormatNumbCurr(filldata[8]);
                    discrp = fs.FormatNumbCurr(Convert.ToString(Convert.ToDouble(filldata[9]) / Convert.ToDouble(filldata[3]))); //discrp per satuan qty
                    subtotal = fs.FormatNumbCurr(Convert.ToString(Convert.ToDouble(filldata[10]) / Convert.ToDouble(filldata[3]))); //subtotal per satuan qty
                    subtotalbersih = fs.FormatNumbCurr(Convert.ToString(Convert.ToDouble(filldata[11]) / Convert.ToDouble(filldata[3]))); //subtotalbersih per satuan qty

                    qry.InsertLogAktivitas("TampilBarang", this, txtKodeBarcode.Text, userName);
                }
            }
        }

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
                                    CekQtyPembelian(dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString(),"1") -
                                    CekQtySudahReturBeli(lblID.Text, txtIDPembelian.Text, dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString(), "1"))
                                {
                                    psn.PesanInfo("Stok Pembelian Sudah Tidak Mencukupi Untuk di Retur");
                                }
                                else
                                {
                                    dgTransaksi.Rows[i].Cells[cellqty].Value = fs.FormatNumbCurr((Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellqty].Value) + 1).ToString());
                                    dgTransaksi.Rows[i].Cells[celldiscrp].Value =
                                        fs.FormatNumbCurr(Convert.ToString(Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellqty].Value) * Convert.ToDouble(dgTransaksi.Rows[i].Cells[celldiscrp].Value)));
                                    dgTransaksi.Rows[i].Cells[cellsubtotal].Value =
                                        fs.FormatNumbCurr(Convert.ToString(Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellqty].Value) * Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellsubtotal].Value)));
                                    dgTransaksi.Rows[i].Cells[cellsubtotalbersih].Value =
                                        fs.FormatNumbCurr(Convert.ToString(Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellqty].Value) * Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellsubtotalbersih].Value)));
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
                            dgTransaksi.Rows.Add("X", "1", txtKodeBarcode.Text.Trim(), namabarang, keterangan, "1.00", satuan1, hargabeli,
                            discpersen, discpersen2, discpersen3, discrp, subtotal, subtotalbersih);
                        }
                    }
                    else
                    {
                        dgTransaksi.Rows.Add("X", "1", txtKodeBarcode.Text.Trim(), namabarang, keterangan, "1.00", satuan1, hargabeli, 
                            discpersen, discpersen2, discpersen3, discrp, subtotal, subtotalbersih);
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
                                    CekQtyPembelian(dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString(), "0") -
                                    CekQtySudahReturBeli(lblID.Text, txtIDPembelian.Text, dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString(), "0"))
                                {
                                    psn.PesanInfo("Stok Pembelian Sudah Tidak Mencukupi Untuk di Retur");
                                }
                                else
                                {
                                    dgTransaksi.Rows[i].Cells[cellqty].Value = fs.FormatNumbCurr((Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellqty].Value) + 1).ToString());
                                    dgTransaksi.Rows[i].Cells[celldiscrp].Value =
                                        fs.FormatNumbCurr(Convert.ToString(Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellqty].Value) * Convert.ToDouble(dgTransaksi.Rows[i].Cells[celldiscrp].Value)));
                                    dgTransaksi.Rows[i].Cells[cellsubtotal].Value =
                                        fs.FormatNumbCurr(Convert.ToString(Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellqty].Value) * Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellsubtotal].Value)));
                                    dgTransaksi.Rows[i].Cells[cellsubtotalbersih].Value =
                                        fs.FormatNumbCurr(Convert.ToString(Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellqty].Value) * Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellsubtotalbersih].Value)));
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
                            dgTransaksi.Rows.Add("X", "0", txtKodeBarcode.Text.Trim(), namabarang, keterangan, "1.00", satuan1, hargabeli,
                                discpersen, discpersen2, discpersen3, discrp, subtotal, subtotalbersih);
                        }
                    }
                    else
                    {
                        dgTransaksi.Rows.Add("X", "0", txtKodeBarcode.Text.Trim(), namabarang, keterangan, "1.00", satuan1, hargabeli,
                            discpersen, discpersen2, discpersen3, discrp, subtotal, subtotalbersih);
                    }
                }
            }
        }

        private double CekQtyPembelian(string barcode, string kondisi)
        {
            double stok = 0;

            string data = qry.GetData(this, "CekQtyPembelian", barcode, 0, "sum(qty)", "pembelian_detail",
                "id = '" + txtIDPembelian.Text.Trim() + "' and barcode = '" + barcode + "' and kondisi = " + kondisi + " group by barcode,kondisi");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    stok = Convert.ToInt32(filldata[0]);

                    qry.InsertLogAktivitas("CekQtyPembelian", this, barcode, userName);
                }
            }

            return stok;
        }

        private double CekQtySudahReturBeli(string idretur, string idpembelian, string barcode, string kondisi)
        {
            double stok = 0;

            string data = qry.GetData(this, "CekQtySudahReturBeli", barcode, 0, "sum(b.qty)",
                "retur_pembelian a inner join retur_pembelian_detail b on a.id = b.id ",
                "a.id != '" + lblID.Text + "' and a.idpembelian = '" + txtIDPembelian.Text.Trim() + "' " +
                "and b.barcode = '" + barcode + "' and b.kondisi = " + kondisi + " group by b.barcode,b.kondisi");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    stok = Convert.ToInt32(filldata[0]);

                    qry.InsertLogAktivitas("CekQtySudahReturBeli", this, barcode, userName);
                }
            }

            return stok;
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

        private void HitungGrandTotal()
        {
            double total = Convert.ToDouble(lblTotal.Text);
            double ongkir = Convert.ToDouble(txtOngkir.Text);
            double hasiltotal = 0;

            if (dgTransaksi.Rows.Count > 0)
            {
                hasiltotal = total + ongkir;
            }
            else
            {
                hasiltotal = 0;
            }

            lblGrandTotal.Text = fs.FormatNumbCurr(hasiltotal.ToString());
        }

        private void DeleteStok(string idtransaksi)
        {
            try
            {
                DataSet ds = new DataSet();
                kon.OpenConn();
                kon.da = new MySqlDataAdapter("select barcode,qty,subtotalbersih from retur_pembelian_detail where id = '" + idtransaksi + "'", kon.con);
                kon.da.Fill(ds, "data");
                int row = ds.Tables["data"].Rows.Count - 1;

                if (row >= 0)
                {
                    for (int i = 0; i <= row; i++)
                    {
                        qry.UpdateData("barang", "stokgudang = stokgudang + " + fs.FNum(ds.Tables["data"].Rows[i].ItemArray[1].ToString()) + "," +
                            "stokrupiah = stokrupiah + " + fs.FNum(ds.Tables["data"].Rows[i].ItemArray[2].ToString()) + "",
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
                qry.DeleteData("retur_pembelian", "id = '" + lblID.Text + "'");
                qry.DeleteData("retur_pembelian_detail", "id = '" + lblID.Text + "'");

                if (lblID.Text == "AUTO ID")
                {
                    lblID.Text = qry.CreateID(this, "Simpan", "id", "retur_pembelian", "id like 'RB." + dtTglTransaksi.Value.ToString("MMyyyy") + ".%'",
                        "RB." + dtTglTransaksi.Value.ToString("MMyyyy") + ".", "transaksi");
                }

                qry.InsertData("retur_pembelian", "id,idsupplier,idpembelian,tgltransaksi,catatan,total,ongkir,grandtotal,tglinput,tglupdate",
                    "'" + lblID.Text + "'," +
                    "'" + txtIdSupplier.Text.Trim() + "'," +
                    "'" + txtIDPembelian.Text.Trim() + "'," +
                    "'" + string.Format("{0:yyyy-MM-dd}", dtTglTransaksi.Value) + "'," +
                    "'" + txtCatatan.Text.Trim() + "'," +
                    "" + fs.FNum(lblTotal.Text) + "," +
                    "" + fs.FNum(txtOngkir.Text) + "," +
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
                    string hbeli = dgTransaksi.Rows[i].Cells[cellhbeli].Value.ToString();
                    string discpersen = dgTransaksi.Rows[i].Cells[celldiscpersen].Value.ToString();
                    string discpersen2 = dgTransaksi.Rows[i].Cells[celldiscpersen2].Value.ToString();
                    string discpersen3 = dgTransaksi.Rows[i].Cells[celldiscpersen3].Value.ToString();
                    string discrp = dgTransaksi.Rows[i].Cells[celldiscrp].Value.ToString();
                    string subtotal = dgTransaksi.Rows[i].Cells[cellsubtotal].Value.ToString();
                    string subtotalbersih = dgTransaksi.Rows[i].Cells[cellsubtotalbersih].Value.ToString();
                    string kondisi = dgTransaksi.Rows[i].Cells[cellkondisi].Value.ToString();

                    /*double hrgSatuan = 0;
                    double subtotalBersih = 0;

                    hrgSatuan = Convert.ToDouble(subtotal) / Convert.ToDouble(qty);
                    subtotalBersih = hrgSatuan * Convert.ToDouble(qty);*/

                    if (barcode != "" && Convert.ToDouble(qty) > 0)
                    {
                        qry.InsertData("retur_pembelian_detail", "id,barcode,nama,keterangan,qty,satuan,hbeli,discpersen,discpersen2,discpersen3,discrp,subtotal,subtotalbersih,kondisi",
                            "'" + lblID.Text + "'," +
                            "'" + barcode + "'," +
                            "'" + nama + "'," +
                            "'" + keterangan + "'," +
                            "" + fs.FNum(qty) + "," +
                            "'" + satuan + "'," +
                            "" + fs.FNum(hbeli) + "," +
                            "" + fs.FNum(discpersen) + "," +
                            "" + fs.FNum(discpersen2) + "," +
                            "" + fs.FNum(discpersen3) + "," +
                            "" + fs.FNum(discrp) + "," +
                            "" + fs.FNum(subtotal) + "," +
                            "" + fs.FNum(subtotalbersih.ToString()) + "," +
                            "" + kondisi + "");
                    }

                    qry.UpdateData("barang", "stokgudang = stokgudang - " + fs.FNum(qty) + "," +
                        "stokrupiah = stokrupiah - " + fs.FNum(subtotalbersih.ToString()) + "", "barcode = '" + barcode + "'");
                }

                qry.InsertLogAktivitas("Simpan", this, lblID.Text, userName);
                fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Simpan " + this.Name.ToString() + " " + lblID.Text + " " + lblNamaSupplier.Text + " Berhasil",
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
                    DeleteStok(lblID.Text);
                    qry.DeleteData("retur_pembelian", "id = '" + lblID.Text + "'");
                    qry.DeleteData("retur_pembelian_detail", "id = '" + lblID.Text + "'");

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

        private void ReturPembelian_Load(object sender, EventArgs e)
        {
            tglinput = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (id != "")
                lblID.Text = id;

            frmUtama.lblNamaForm.Text = "- Retur Pembelian";
            UsrAccess();
        }

        private void ReturPembelian_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnCariSupplier_Click(object sender, EventArgs e)
        {
            if (dgTransaksi.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Mengubah ID Customer Maka List Akan Dibersihkan, Apakah Anda Akan Melanjutkan?", "Konfirmasi", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    dgTransaksi.Rows.Clear();

                    cls.OpenForm op = new cls.OpenForm(frmUtama);
                    op.ListOpen("List", "ReturPembelian-Supplier", "Supplier", "", userName);

                    txtIdSupplier.Text = idsupplier;
                    idsupplier = "";
                }
            }
            else
            {
                cls.OpenForm op = new cls.OpenForm(frmUtama);
                op.ListOpen("List", "ReturPembelian-Supplier", "Supplier", "", userName);

                txtIdSupplier.Text = idsupplier;
                idsupplier = "";
            }
        }

        private void txtIdSupplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.AllowOnlyBackspace(e);
        }

        private void txtIdSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                btnCariSupplier_Click(sender, e);
            }
        }

        private void txtIdSupplier_TextChanged(object sender, EventArgs e)
        {
            TampilSupplier(txtIdSupplier.Text);
        }

        private void brnCariBarang_Click(object sender, EventArgs e)
        {
            cls.OpenForm op = new cls.OpenForm(frmUtama);
            op.ListOpen("List", "ReturPembelian-Barang", "BarangByIDPembelian", txtIDPembelian.Text.Trim(), userName);

            txtKodeBarcode.Text = barcode;
            kondisi = strkondisi;
            barcode = "";
            strkondisi = "";
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
                TampilBarang(txtIDPembelian.Text.Trim(), txtKodeBarcode.Text, kondisi);

                if (namabarang == "")
                {
                    psn.PesanInfo("Kode Barang " + txtKodeBarcode.Text.Trim() + " Tidak Ada Dalam Database");
                    txtKodeBarcode.Text = "";
                    kondisi = "0";
                    txtKodeBarcode.Focus();
                }
                else if(CekQtyPembelian(txtKodeBarcode.Text.Trim(),kondisi) - CekQtySudahReturBeli(lblID.Text, txtIDPembelian.Text.Trim(), txtKodeBarcode.Text.Trim(), kondisi) <= 0)
                {
                    psn.PesanInfo("Stok Pembelian Sudah Tidak Mencukupi Untuk di Retur");
                }
                else
                {
                    InsertDataGrid();
                    lblTotal.Text = fs.FormatNumbCurr(HitungTotal().ToString());
                    HitungGrandTotal();
                    namabarang = "";
                    txtKodeBarcode.Text = "";
                    kondisi = "0";
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

        private void txtCatatan_Leave(object sender, EventArgs e)
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

                        lblTotal.Text = fs.FormatNumbCurr(HitungTotal().ToString());
                        HitungGrandTotal();

                        qry.InsertLogAktivitas("dgTransaksi_CellClick", this, row.Cells[cellbarcode].Value.ToString(), userName);
                        psn.CreateLogSuccessForm(this, "dgTransaksi_CellClick", row.Cells[cellbarcode].Value.ToString());
                        fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Hapus Kode Barang " + row.Cells[cellbarcode].Value.ToString() + " dari List Retur Pembelian Berhasil",
                                frmUtama.tooltip_x, frmUtama.tooltip_y, "info");
                    }
                }
            }
        }

        private void dgTransaksi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgTransaksi.CurrentCell.ColumnIndex == cellqty || dgTransaksi.CurrentCell.ColumnIndex == cellhbeli)
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
                TampilBarang(txtIDPembelian.Text.Trim(), row.Cells[cellbarcode].Value.ToString(), row.Cells[cellkondisi].Value.ToString());
                namabarang = "";

                if (Convert.ToString(dgTransaksi.CurrentCell.Value) == "")
                {
                    dgTransaksi.CurrentCell.Value = "0.00";
                }
                else if(Convert.ToDouble(dgTransaksi.CurrentCell.Value.ToString()) >
                    CekQtyPembelian(row.Cells[cellbarcode].Value.ToString(),row.Cells[cellkondisi].Value.ToString()) -
                    CekQtySudahReturBeli(lblID.Text, txtIDPembelian.Text.Trim(), row.Cells[cellbarcode].Value.ToString(), row.Cells[cellkondisi].Value.ToString()))
                {
                    psn.PesanInfo("Stok Pembelian Sudah Tidak Mencukupi Untuk di Retur");
                    dgTransaksi.CurrentCell.Value = "1.00";
                }
                dgTransaksi.CurrentCell.Value = fs.FormatNumbCurr(Convert.ToString(dgTransaksi.CurrentCell.Value));

                row.Cells[celldiscrp].Value = fs.FormatNumbCurr(Convert.ToString(Convert.ToDouble(discrp) * Convert.ToDouble(dgTransaksi.CurrentCell.Value)));
                row.Cells[cellsubtotal].Value = fs.FormatNumbCurr(Convert.ToString(Convert.ToDouble(subtotal) * Convert.ToDouble(dgTransaksi.CurrentCell.Value)));
                row.Cells[cellsubtotalbersih].Value = fs.FormatNumbCurr(Convert.ToString(Convert.ToDouble(subtotalbersih) * Convert.ToDouble(dgTransaksi.CurrentCell.Value)));
            }

            lblTotal.Text = fs.FormatNumbCurr(HitungTotal().ToString());
            HitungGrandTotal();
        }

        private void dgTransaksi_Leave(object sender, EventArgs e)
        {
            txtOngkir.Focus();
        }

        private void txtOngkir_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.InputNumber(e);
        }

        private void txtOngkir_Leave(object sender, EventArgs e)
        {
            fs.TextLeave(txtOngkir);
            HitungGrandTotal();
        }

        private void lblID_TextChanged(object sender, EventArgs e)
        {
            TampilData(lblID.Text);
        }

        private void btnCariIDPembelian_Click(object sender, EventArgs e)
        {
            if (dgTransaksi.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Mengubah ID Customer Maka List Akan Dibersihkan, Apakah Anda Akan Melanjutkan?", "Konfirmasi", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    dgTransaksi.Rows.Clear();

                    cls.OpenForm op = new cls.OpenForm(frmUtama);
                    op.ListOpen("List", "ReturPembelian-IDPembelian", "PembelianBySupplier", txtIdSupplier.Text.Trim(), userName);

                    txtIDPembelian.Text = idpembelian;
                    idpembelian = "";
                }
            }
            else
            {
                cls.OpenForm op = new cls.OpenForm(frmUtama);
                op.ListOpen("List", "ReturPembelian-IDPembelian", "PembelianBySupplier", txtIdSupplier.Text.Trim(), userName);

                txtIDPembelian.Text = idpembelian;
                idpembelian = "";
            }
        }

        private void txtIDPembelian_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.AllowOnlyBackspace(e);
        }

        private void txtIDPembelian_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                btnCariIDPembelian_Click(sender, e);
            }
        }

        private void txtIDPembelian_TextChanged(object sender, EventArgs e)
        {
            TampilPembelian(txtIDPembelian.Text);
        }
    }
}
