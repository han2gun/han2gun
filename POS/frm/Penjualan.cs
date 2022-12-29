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
    public partial class Penjualan : Form
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
        public static string barcode;

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
        int cellkondisi;
        //int cellstokdisplay;

        string namabarang;
        string satuan1;
        string satuan2;
        string hargajual;
        string stokgudang;
        //string stokdisplay;
        string diskonpersen;
        string diskonrp;

        string idbarangdisplay;
        double qtybarangdetail;
        double totalQtyBarang;

        bool detailDelete;
        DataGridViewRow row;

        public Penjualan(MenuUtama mnutama)
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
            cellkondisi = 10;
            //cellstokdisplay = 10;
            namabarang = "";
            totalQtyBarang = 0;
            detailDelete = true;
            fs.BoldHeaderDataGridView(dgTransaksi);
            this.KeyDown += new KeyEventHandler(this.OnKeyDown);
            ActiveControl = txtKodeBarcode;
        }

        #region code
        private void UsrAccess()
        {
           string data = qry.GetData(this, "UsrAccess", userName, 0,
               "penjualansv,penjualandel,penjualanprt,penjualanup", "usrmgmt", "usrname = '" + userName + "'");

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
            fs.FillTextBoxArray(new TextBox[] { txtIdCustomer, txtCatatan, txtKodeBarcode, txtBank, txtNoKartu }, "");
            fs.FillTextBoxArray(new TextBox[] { txtDiskonPersen, txtDiskonRp, txtPPn, txtOngkir, txtPembayaran }, "0.00");
            fs.FillLabelArray(new Label[] { lblTotal, lblGrandTotal, lblKembalian }, "0.00");
            lblNamaCustomer.Text = "";
            dtTglTransaksi.Value = DateTime.Today;
            tglinput = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            chkPPn.Checked = false;
            cboJenisBayar.SelectedIndex = 0;
            dgTransaksi.Rows.Clear();
            lblID.Text = "AUTO ID";
            chkTanda.Checked = false;
            txtKodeBarcode.Focus();
            TampilCustomerAwal();
            TampilSalesAwal();
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
                        psn.PesanInfo("ID Penjualan Masih Kosong");
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
                    op.PencarianOpen("Pencarian", "Penjualan", userName);
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
                case Keys.F6:
                    txtPembayaran.Focus();
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

            string data = qry.GetData(this, "TampilData", id, 13, "id,idcustomer,sales,tgltransaksi,catatan,jenisbayar,bank,nokartu," +
                "total,discpersen,discrp,ppn,ppnnominal,ongkir,grandtotal,bayar,kembalian,tglinput",
                "penjualan", "id = '" + id + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    idUpdate = filldata[0]; //jika kosong berarti data baru, jika muncul id data lama -> cek status boleh update atau tidak
                    txtIdCustomer.Text = filldata[1];
                    txtSales.Text = filldata[2];
                    dtTglTransaksi.Value = Convert.ToDateTime(filldata[3]);
                    txtCatatan.Text = filldata[4];
                    cboJenisBayar.Text = filldata[5];
                    txtBank.Text = filldata[6];
                    txtNoKartu.Text = filldata[7];
                    lblTotal.Text = fs.FormatNumbCurr(filldata[8]);
                    txtDiskonPersen.Text = fs.FormatNumbCurr(filldata[9]);
                    txtDiskonRp.Text = fs.FormatNumbCurr(filldata[10]);
                    chkPPn.Checked = fs.IntToBool(filldata[11]);
                    txtPPn.Text = fs.FormatNumbCurr(filldata[12]);
                    txtOngkir.Text = fs.FormatNumbCurr(filldata[13]);
                    lblGrandTotal.Text = fs.FormatNumbCurr(filldata[14]);
                    txtPembayaran.Text = fs.FormatNumbCurr(filldata[15]);
                    lblKembalian.Text = fs.FormatNumbCurr(filldata[16]);
                    tglinput = DateTime.Parse(filldata[17]).ToString("yyyy-MM-dd HH:mm:ss");

                    TampilDetailData(id);

                    qry.InsertLogAktivitas("TampilData", this, lblID.Text, userName);
                }
            }
        }

        private void TampilCustomerAwal()
        {
            string data = qry.GetData(this, "TampilCustomerAwal", lblID.Text, 8, "id", "customer", "cekawal = 1");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    txtIdCustomer.Text = filldata[0];

                    qry.InsertLogAktivitas("TampilCustomerAwal", this, txtIdCustomer.Text, userName);
                }
            }
        }

        private void TampilSalesAwal()
        {
            string data = qry.GetData(this, "TampilSalesAwal", lblID.Text, 8, "id,nama", "karyawan", "cekawal = 1");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    txtSales.Text = filldata[0] + "-" + filldata[1];

                    qry.InsertLogAktivitas("TampilSalesAwal", this, txtSales.Text, userName);
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
            qry.DataGridViewFill(this, dgTransaksi, "TampilDetailData", "id,barcode,nama,keterangan,qty,satuan,hjual,discpersen,discrp,subtotal,kondisi",
                "penjualan_detail", "id = '" + id + "'");

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
                    dgTransaksi.Rows[i].Cells[cellkondisi].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[10];
                }

                dgTransaksi.AutoResizeColumns();
                qry.InsertLogAktivitas("TampilDetailData", this, lblID.Text, userName);
            }
        }

        private void TampilBarang(string barcode)
        {
            string data = qry.GetData(this, "TampilBarang", id, 8, "barcode,nama,satuan1,hargajual1,stokgudang",
                "barang", "barcode = '" + barcode + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    namabarang = filldata[1];
                    satuan1 = filldata[2];
                    hargajual = fs.FormatNumbCurr(filldata[3]);
                    stokgudang = fs.FormatNumbCurr(filldata[4]);

                    qry.InsertLogAktivitas("TampilBarang", this, txtKodeBarcode.Text, userName);
                }
            }
        }

        private void TampilSatuanBarang(string barcode)
        {
            string data = qry.GetData(this, "TampilSatuanBarang", barcode, 0, "barcode,satuan1,satuan2,satuan3,satuan4,satuan5", "barang", "barcode = '" + barcode + "'");

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

        private void TampilDiskonAktif(string barcode)
        {
            diskonpersen = "0";
            diskonrp = "0";

            string data = qry.GetData(this, "TampilDiskonAktif", id, 13, "b.discpersen,b.discrp", 
                "diskon a inner join diskon_detail b on a.id = b.id", 
                "b.barcode = '" + barcode + "' and a.aktif = 1 and " +
                "'" + DateTime.Now.ToString("yyyy-MM-dd") + "' between tglmulai and tglselesai");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    diskonpersen = fs.FormatNumbCurr(filldata[0]);
                    diskonrp = fs.FormatNumbCurr(filldata[1]);

                    qry.InsertLogAktivitas("TampilDiskonAktif", this, lblID.Text + "-" + barcode, userName);
                }
            }
        }

        private void InsertDataGrid()
        {
            bool match = true;

            TampilDiskonAktif(txtKodeBarcode.Text.Trim());

            if (namabarang != "")
            {
                double totalqty = HitungTotalQyBarang(txtKodeBarcode.Text.Trim());
                int row = dgTransaksi.Rows.Count - 1;

                if(chkTanda.Checked == true)
                {
                    if(totalqty + 1 > CekStokBarang(txtKodeBarcode.Text.Trim()))
                    {
                        DialogResult result = MessageBox.Show("Stok Barang Tidak Mencukupi,Apakah Tetap Akan Melanjutkan?",
                            "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (result == DialogResult.Yes)
                        {
                            if (Convert.ToDouble(diskonpersen) > 0)
                            {
                                string countdiscrp = fs.FormatNumbCurr((Convert.ToDouble(hargajual) * Convert.ToDouble(diskonpersen) / 100).ToString());

                                dgTransaksi.Rows.Add("X", txtKodeBarcode.Text.Trim(), namabarang, "", "1.00", satuan1, hargajual, diskonpersen, countdiscrp,
                                    fs.FormatNumbCurr(((Convert.ToDouble(hargajual) * 1) - Convert.ToDouble(countdiscrp)).ToString()), 1);
                            }
                            else if (Convert.ToDouble(diskonrp) > 0)
                            {
                                dgTransaksi.Rows.Add("X", txtKodeBarcode.Text.Trim(), namabarang, "", "1.00", satuan1, hargajual, diskonpersen, diskonrp,
                                    fs.FormatNumbCurr(((Convert.ToDouble(hargajual) * 1) - Convert.ToDouble(diskonrp)).ToString()), 1);
                            }
                            else
                            {
                                dgTransaksi.Rows.Add("X", txtKodeBarcode.Text.Trim(), namabarang, "", "1.00", satuan1, hargajual, diskonpersen, diskonrp, hargajual, 1);
                            }
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(diskonpersen) > 0)
                        {
                            string countdiscrp = fs.FormatNumbCurr((Convert.ToDouble(hargajual) * Convert.ToDouble(diskonpersen) / 100).ToString());

                            dgTransaksi.Rows.Add("X", txtKodeBarcode.Text.Trim(), namabarang, "", "1.00", satuan1, hargajual, diskonpersen, countdiscrp,
                                fs.FormatNumbCurr(((Convert.ToDouble(hargajual) * 1) - Convert.ToDouble(countdiscrp)).ToString()), 1);
                        }
                        else if (Convert.ToDouble(diskonrp) > 0)
                        {
                            dgTransaksi.Rows.Add("X", txtKodeBarcode.Text.Trim(), namabarang, "", "1.00", satuan1, hargajual, diskonpersen, diskonrp,
                                fs.FormatNumbCurr(((Convert.ToDouble(hargajual) * 1) - Convert.ToDouble(diskonrp)).ToString()), 1);
                        }
                        else
                        {
                            dgTransaksi.Rows.Add("X", txtKodeBarcode.Text.Trim(), namabarang, "", "1.00", satuan1, hargajual, diskonpersen, diskonrp, hargajual, 1);
                        }
                    }
                }
                else
                {
                    if (row >= 0)
                    {
                        for (int i = 0; i <= row; i++)
                        {
                            if (dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString() == txtKodeBarcode.Text.Trim())
                            {
                                //if (Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellqty].Value) >= CekStokBarang(dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString()))
                                if (totalqty + 1 > CekStokBarang(txtKodeBarcode.Text.Trim()))
                                {
                                    DialogResult result = MessageBox.Show("Stok Barang " + dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString() + " Tidak Mencukupi, " +
                                        "Stok Tersedia " + CekStokBarang(dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString()).ToString() + ", Apakah Tetap Akan Melanjutkan?",
                                        "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                                    if (result == DialogResult.Yes)
                                    {
                                        dgTransaksi.Rows[i].Cells[cellqty].Value = fs.FormatNumbCurr((Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellqty].Value) + 1).ToString());

                                        dgTransaksi.Rows[i].Cells[cellsubtotal].Value = HitungSubTotalRow(dgTransaksi.Rows[i].Cells[cellqty].Value.ToString(),
                                            dgTransaksi.Rows[i].Cells[cellhjual].Value.ToString(), diskonpersen, diskonrp, i);
                                    }
                                }
                                else
                                {
                                    dgTransaksi.Rows[i].Cells[cellqty].Value = fs.FormatNumbCurr((Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellqty].Value) + 1).ToString());

                                    dgTransaksi.Rows[i].Cells[cellsubtotal].Value = HitungSubTotalRow(dgTransaksi.Rows[i].Cells[cellqty].Value.ToString(),
                                        dgTransaksi.Rows[i].Cells[cellhjual].Value.ToString(), diskonpersen, diskonrp, i);
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
                            if (Convert.ToDouble(diskonpersen) > 0)
                            {
                                string countdiscrp = fs.FormatNumbCurr((Convert.ToDouble(hargajual) * Convert.ToDouble(diskonpersen) / 100).ToString());

                                dgTransaksi.Rows.Add("X", txtKodeBarcode.Text.Trim(), namabarang, "", "1.00", satuan1, hargajual, diskonpersen, countdiscrp,
                                    fs.FormatNumbCurr(((Convert.ToDouble(hargajual) * 1) - Convert.ToDouble(countdiscrp)).ToString()),0);
                            }
                            else if (Convert.ToDouble(diskonrp) > 0)
                            {
                                dgTransaksi.Rows.Add("X", txtKodeBarcode.Text.Trim(), namabarang, "", "1.00", satuan1, hargajual, diskonpersen, diskonrp,
                                    fs.FormatNumbCurr(((Convert.ToDouble(hargajual) * 1) - Convert.ToDouble(diskonrp)).ToString()),0);
                            }
                            else
                            {
                                dgTransaksi.Rows.Add("X", txtKodeBarcode.Text.Trim(), namabarang, "", "1.00", satuan1, hargajual, diskonpersen, diskonrp, hargajual,0);
                            }
                            //dgTransaksi.AutoResizeColumns();
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(diskonpersen) > 0)
                        {
                            string countdiscrp = fs.FormatNumbCurr((Convert.ToDouble(hargajual) * Convert.ToDouble(diskonpersen) / 100).ToString());

                            dgTransaksi.Rows.Add("X", txtKodeBarcode.Text.Trim(), namabarang, "", "1.00", satuan1, hargajual, diskonpersen, countdiscrp,
                                fs.FormatNumbCurr(((Convert.ToDouble(hargajual) * 1) - Convert.ToDouble(countdiscrp)).ToString()),0);
                        }
                        else if (Convert.ToDouble(diskonrp) > 0)
                        {
                            dgTransaksi.Rows.Add("X", txtKodeBarcode.Text.Trim(), namabarang, "", "1.00", satuan1, hargajual, diskonpersen, diskonrp,
                                fs.FormatNumbCurr(((Convert.ToDouble(hargajual) * 1) - Convert.ToDouble(diskonrp)).ToString()),0);
                        }
                        else
                        {
                            dgTransaksi.Rows.Add("X", txtKodeBarcode.Text.Trim(), namabarang, "", "1.00", satuan1, hargajual, diskonpersen, diskonrp, hargajual,0);
                        }
                        //dgTransaksi.AutoResizeColumns();
                    }
                }
            }
        }

        private string HitungSubTotalRow(string valQty, string valHarga, string valDiscPersen, string valDiscRp, int row)
        {
            double hasil;
            double qty = Convert.ToDouble(valQty);
            double harga = Convert.ToDouble(valHarga);
            double discpersen = Convert.ToDouble(valDiscPersen);
            double discrp = Convert.ToDouble(valDiscRp);
            double hasildiskon = 0;

            if (discpersen > 0)
            {
                hasildiskon = (harga * qty * discpersen) / 100;
                dgTransaksi.Rows[row].Cells[celldiscrp].Value = fs.FormatNumbCurr(hasildiskon.ToString());
                tempDiskonRow = hasildiskon;
            }
            else
            {
                hasildiskon = Convert.ToDouble(dgTransaksi.Rows[row].Cells[celldiscrp].Value);
            }

            hasil = qty * harga - hasildiskon;

            return fs.FormatNumbCurr(hasil.ToString());
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

        private void HitungKembalian()
        {
            double grandtotal = Convert.ToDouble(lblGrandTotal.Text);
            double pembayaran = Convert.ToDouble(txtPembayaran.Text);
            double hasiltotal = 0;

            if(Convert.ToDouble(txtPembayaran.Text) >= Convert.ToDouble(lblGrandTotal.Text))
            {
                hasiltotal = pembayaran - grandtotal;
            }

            lblKembalian.Text = fs.FormatNumbCurr(hasiltotal.ToString());
        }

        private void HitungPPn()
        {
            double total = Convert.ToDouble(lblTotal.Text);
            double diskon = Convert.ToDouble(txtDiskonPersen.Text);
            double diksonrp = Convert.ToDouble(txtDiskonRp.Text);
            double hasildiskon = 0;
            double hasiltotal = 0;
            double hasilppn = 0;

            if (chkPPn.Checked == true)
            {
                if (diskon > 0)
                {
                    hasildiskon = (total * diskon) / 100;
                }
                else
                {
                    hasildiskon = Convert.ToDouble(txtDiskonRp.Text);
                }

                hasiltotal = total - hasildiskon;

                if (dgTransaksi.Rows.Count > 0)
                {
                    hasilppn = hasiltotal * 10 / 100;
                }
                else
                {
                    hasilppn = 0;
                }
            }
            else
            {
                hasilppn = 0;
            }

            txtPPn.Text = fs.FormatNumbCurr(hasilppn.ToString());
        }

        private void HitungGrandTotal()
        {
            double total = Convert.ToDouble(lblTotal.Text);
            double diskon = Convert.ToDouble(txtDiskonPersen.Text);
            double diksonrp = Convert.ToDouble(txtDiskonRp.Text);
            double ppn = Convert.ToDouble(txtPPn.Text);
            double ongkir = Convert.ToDouble(txtOngkir.Text);
            double hasildiskon = 0;
            double hasiltotal = 0;

            //hitung diskon rupiah dulu
            if (diskon > 0)
            {
                hasildiskon = (total * diskon) / 100;
                txtDiskonRp.Text = fs.FormatNumbCurr(hasildiskon.ToString());
                tempDiskon = hasildiskon;
            }
            else
            {
                hasildiskon = Convert.ToDouble(txtDiskonRp.Text);
            }

            if (dgTransaksi.Rows.Count > 0)
            {
                hasiltotal = total - hasildiskon + ppn + ongkir;
            }
            else
            {
                hasiltotal = 0;
            }

            string getdigitakhir = "";
            string hasilpembulatan = Convert.ToString(Math.Round(hasiltotal));
            int panjangstring = hasilpembulatan.Length;
            int posisiawalsubstring = panjangstring - 2;

            if(Convert.ToInt32(hasilpembulatan) > 0)
            {
                getdigitakhir = hasilpembulatan.Substring(posisiawalsubstring);

                if (Convert.ToInt32(getdigitakhir) > 0 && Convert.ToInt32(getdigitakhir) < 100)
                {
                    lblGrandTotal.Text = fs.FormatNumbCurr(Convert.ToDouble((Convert.ToInt32(hasilpembulatan) - Convert.ToInt32(getdigitakhir) + 100)).ToString());
                }
                else
                {
                    lblGrandTotal.Text = fs.FormatNumbCurr(hasiltotal.ToString());
                }
            }

            //hitung kembalian jika pembayaran tidak 0
            if(Convert.ToDouble(txtPembayaran.Text) > 0)
            {
                HitungKembalian();
            }
        }

        private double HitungTotalQyBarang(string barcode)
        {
            double qty = 0;
            int row = dgTransaksi.Rows.Count - 1;

            if(row > 0)
            {
                for (int i = 0; i <= row; i++)
                {
                    if(dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString() == barcode)
                    {
                        qty = qty + Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellqty].Value);
                    }
                }
            }

            return qty;
        }

        //dipakai ketika akan mengubah qty atau menambah qty barang supaya tidak melebihi stok yang ada
        private double CekStokBarang(string barcode)
        {
            double stok = 0;

            string data = qry.GetData(this, "CekStokBarang", barcode, 0, "stokgudang", "barang",
                "barcode = '" + barcode + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    stok = Convert.ToInt32(filldata[0]);

                    qry.InsertLogAktivitas("CekStokBarang", this, barcode, userName);
                }
            }

            return stok;
        }

        private double CekHPP(string barcode)
        {
            double hpp = 0;

            string data = qry.GetData(this, "CekHPP", barcode, 0, "stokgudang,stokrupiah", "barang",
                "barcode = '" + barcode + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    if(Convert.ToDouble(filldata[1]) > 0)
                    {
                        hpp = Convert.ToDouble(filldata[1]) / Convert.ToDouble(filldata[0]);
                    }
                    else
                    {
                        hpp = 0;
                    }

                    qry.InsertLogAktivitas("CekHPP", this, barcode, userName);
                }
            }

            return hpp;
        }

        private void DeleteStok(string idtransaksi)
        {
            try
            {
                DataSet ds = new DataSet();
                kon.OpenConn();
                kon.da = new MySqlDataAdapter("select barcode,qty,subtotalhpp from penjualan_detail where id = '" + idtransaksi + "'", kon.con);
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
            /*if (qry.DataExist(this, "Hapus", lblID.Text, lblID.Text, "idpenjualan", "piutang", "idpenjualan = '" + lblID.Text + "'"))
            {
                fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Nota Penjualan " + lblID.Text + " Telah Digunakan Dalam Transaksi Piutang",
                    frmUtama.tooltip_x, frmUtama.tooltip_y, "warning");
            }
            else
            {*/
                string lunas;

                if(cboJenisBayar.Text != "TEMPO")
                {
                    lunas = "1";
                }
                else
                {
                    lunas = "0";
                }

                try
                {
                    DeleteStok(lblID.Text);
                    qry.DeleteData("penjualan", "id = '" + lblID.Text + "'");
                    qry.DeleteData("penjualan_detail", "id = '" + lblID.Text + "'");

                    if (lblID.Text == "AUTO ID")
                    {
                        lblID.Text = qry.CreateID(this, "Simpan", "id", "penjualan", "id like 'PJ." + dtTglTransaksi.Value.ToString("MMyyyy") + ".%'",
                            "PJ." + dtTglTransaksi.Value.ToString("MMyyyy") + ".", "transaksi");
                    }

                    qry.InsertData("penjualan", "id,idcustomer,sales,tgltransaksi,catatan,jenisbayar,bank,nokartu,total,discpersen,discrp,ppn,ppnnominal," +
                        "ongkir,grandtotal,bayar,kembalian,flaglunas,tglinput,tglupdate",
                        "'" + lblID.Text + "'," +
                        "'" + txtIdCustomer.Text.Trim() + "'," +
                        "'" + txtSales.Text.Trim() + "'," +
                        "'" + string.Format("{0:yyyy-MM-dd}", dtTglTransaksi.Value) + "'," +
                        "'" + txtCatatan.Text.Trim() + "'," +
                        "'" + cboJenisBayar.Text + "'," +
                        "'" + txtBank.Text.Trim() + "'," +
                        "'" + txtNoKartu.Text.Trim() + "'," +
                        "" + fs.FNum(lblTotal.Text) + "," +
                        "" + fs.FNum(txtDiskonPersen.Text) + "," +
                        "" + fs.FNum(txtDiskonRp.Text) + "," +
                        "" + fs.BoolToInt(chkPPn.Checked) + "," +
                        "" + fs.FNum(txtPPn.Text) + "," +
                        "" + fs.FNum(txtOngkir.Text) + "," +
                        "" + fs.FNum(lblGrandTotal.Text) + "," +
                        "" + fs.FNum(txtPembayaran.Text) + "," +
                        "" + fs.FNum(lblKembalian.Text) + "," +
                        "" + fs.FNum(lunas) + "," +
                        "'" + tglinput + "'," +
                        "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'");

                    psn.CreateLogTransaksiPenjualan(this, "Simpan", "ID --> " + lblID.Text + "==========================================================");

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
                        string kondisi = dgTransaksi.Rows[i].Cells[cellkondisi].Value.ToString();

                        double hpp = CekHPP(dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString());
                        double subtotalhpp = hpp * Convert.ToDouble(qty);

                        //tandai
                        if (barcode != "" && Convert.ToDouble(qty) > 0)
                        {
                            qry.InsertData("penjualan_detail", "id,barcode,nama,keterangan,kondisi,qty,satuan,hjual,discpersen,discrp,subtotal,subtotalhpp",
                                "'" + lblID.Text + "'," +
                                "'" + barcode + "'," +
                                "'" + nama + "'," +
                                "'" + keterangan + "'," +
                                "" + kondisi + "," +
                                "" + fs.FNum(qty) + "," +
                                "'" + satuan + "'," +
                                "" + fs.FNum(hjual) + "," +
                                "" + fs.FNum(diskpersen) + "," +
                                "" + fs.FNum(diskrp) + "," +
                                "" + fs.FNum(subtotal) + "," +
                                "" + fs.FNum(subtotalhpp.ToString()) + "");
                        }

                        qry.UpdateData("barang", "stokgudang = stokgudang - " + fs.FNum(qty) + "," +
                            "stokrupiah = stokrupiah - " + fs.FNum(subtotalhpp.ToString()) + "", "barcode = '" + barcode + "'");

                        psn.CreateLogTransaksiPenjualan(this, "Simpan", "Barcode --> " + barcode + "# IDBarangDetail --> XXX# Qty --> " + fs.FormatNumbCurr(qty) + "# " +
                            "Satuan --> " + satuan + "# H.Jual --> " + fs.FormatNumbCurr(hjual) + "# Disc(%) --> " + fs.FormatNumbCurr(diskpersen) + "# " +
                            "Disc(Rp) --> " + fs.FormatNumbCurr(diskrp) + "# Subtotal --> " + fs.FormatNumbCurr(subtotal) + "");
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
            //}
        }

        private void Hapus()
        {
            if (qry.DataExist(this, "Hapus", lblID.Text, lblID.Text, "idpenjualan", "piutang", "idpenjualan = '" + lblID.Text + "'"))
            {
                fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Nota Penjualan " + lblID.Text + " Telah Digunakan Dalam Transaksi Piutang",
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
                        DeleteStok(lblID.Text); //tandai
                        qry.DeleteData("penjualan", "id = '" + lblID.Text + "'");
                        qry.DeleteData("penjualan_detail", "id = '" + lblID.Text + "'");

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

        private void Penjualan_Load(object sender, EventArgs e)
        {
            tglinput = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            TampilCustomerAwal();
            TampilSalesAwal();
            cboJenisBayar.SelectedIndex = 0;

            if (id != "")
                lblID.Text = id;

            frmUtama.lblNamaForm.Text = "- Penjualan";
            UsrAccess();
        }

        private void Penjualan_KeyPress(object sender, KeyPressEventArgs e)
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
            HitungKembalian();
            SelectToolBar(btnCetak);
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            SelectToolBar(btnKeluar);
        }

        private void btnCariCustomer_Click(object sender, EventArgs e)
        {
            cls.OpenForm op = new cls.OpenForm(frmUtama);
            op.ListOpen("List", "Penjualan-Customer", "Customer", "", userName);

            txtIdCustomer.Text = idcustomer;
            idcustomer = "";
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
            TampilCustomer(txtIdCustomer.Text);
        }

        private void txtCatatan_Leave(object sender, EventArgs e)
        {
            txtKodeBarcode.Focus();
        }

        private void brnCariBarang_Click(object sender, EventArgs e)
        {
            cls.OpenForm op = new cls.OpenForm(frmUtama);
            op.ListOpen("List", "Penjualan-BarangJual", "Barang", "", userName);

            txtKodeBarcode.Text = barcode;
            barcode = "";
            txtKodeBarcode.Focus();
        }

        private void txtKodeBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                TampilBarang(txtKodeBarcode.Text);

                if(namabarang == "")
                {
                    psn.PesanInfo("Kode Barang " + txtKodeBarcode.Text.Trim() + " Tidak Ada Dalam Database");
                    txtKodeBarcode.Text = "";
                    chkTanda.Checked = false;
                    txtKodeBarcode.Focus();
                }
                else if (Convert.ToDouble(stokgudang) <= 0)
                {
                    DialogResult result = MessageBox.Show("Stok Barang " + txtKodeBarcode.Text.Trim() + " Tidak Mencukupi, " +
                        "Stok Tersedia " + CekStokBarang(txtKodeBarcode.Text.Trim()).ToString() + "",
                        "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        InsertDataGrid();
                        lblTotal.Text = fs.FormatNumbCurr(HitungTotal().ToString());
                        HitungGrandTotal();
                        namabarang = "";
                        txtKodeBarcode.Text = "";
                        chkTanda.Checked = false;
                    }

                    txtKodeBarcode.Text = "";
                    chkTanda.Checked = false;
                }
                else
                {
                    InsertDataGrid();
                    lblTotal.Text = fs.FormatNumbCurr(HitungTotal().ToString());
                    HitungGrandTotal();
                    namabarang = "";
                    txtKodeBarcode.Text = "";
                    chkTanda.Checked = false;
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

                        lblTotal.Text = fs.FormatNumbCurr(HitungTotal().ToString());
                        HitungGrandTotal();

                        qry.InsertLogAktivitas("dgTransaksi_CellClick", this, row.Cells[cellbarcode].Value.ToString(), userName);
                        psn.CreateLogSuccessForm(this, "dgTransaksi_CellClick", row.Cells[cellbarcode].Value.ToString());
                        fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Hapus Kode Barang " + row.Cells[cellbarcode].Value.ToString() + " dari List Penjualan Berhasil",
                                frmUtama.tooltip_x, frmUtama.tooltip_y, "info");
                    }
                }
            }
            /*else if (e.ColumnIndex == dgTransaksi.Columns["clSatuan"].Index && e.RowIndex >= 0)
            {
                row = dgTransaksi.Rows[e.RowIndex];

                TampilSatuanBarang(row.Cells[cellbarcode].Value.ToString());
                pnlComboBox.Visible = true;
            }*/
        }

        private void dgTransaksi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgTransaksi.CurrentCell.ColumnIndex == cellqty || dgTransaksi.CurrentCell.ColumnIndex == cellhjual ||
                dgTransaksi.CurrentCell.ColumnIndex == celldiscpersen || dgTransaksi.CurrentCell.ColumnIndex == celldiscrp)
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

            if (e.KeyChar == (char)Keys.Tab)
            {
                txtDiskonPersen.Focus();
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
                totalQtyBarang = HitungTotalQyBarang(row.Cells[cellbarcode].Value.ToString());

                if (Convert.ToString(dgTransaksi.CurrentCell.Value) == "")
                {
                    dgTransaksi.CurrentCell.Value = "0.00";
                }
                //else if(Convert.ToDouble(dgTransaksi.CurrentCell.Value) > CekStokBarang(row.Cells[cellbarcode].Value.ToString()))
                ///else if (Convert.ToDouble(dgTransaksi.CurrentCell.Value) > totalQtyBarang)
                else if (totalQtyBarang > CekStokBarang(row.Cells[cellbarcode].Value.ToString()))
                {
                    DialogResult result = MessageBox.Show("Stok Barang " + row.Cells[cellbarcode].Value.ToString() + " Tidak Mencukupi, " +
                        "Stok Tersedia " + CekStokBarang(row.Cells[cellbarcode].Value.ToString()).ToString() + ", Apakah Akan Tetap Melanjutkan?",
                        "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        dgTransaksi.CurrentCell.Value = fs.FormatNumbCurr(Convert.ToString(dgTransaksi.CurrentCell.Value));
                        //dgTransaksi.CurrentCell.Value = "1.00";
                    }
                    else
                    {
                        dgTransaksi.CurrentCell.Value = "0.00";
                    }
                }
                dgTransaksi.CurrentCell.Value = fs.FormatNumbCurr(Convert.ToString(dgTransaksi.CurrentCell.Value));
            }
            else if ((dgTransaksi.Focused) && (dgTransaksi.CurrentCell.ColumnIndex == cellhjual))
            {
                if (Convert.ToString(dgTransaksi.CurrentCell.Value) == "")
                {
                    dgTransaksi.CurrentCell.Value = "0.00";
                }
                dgTransaksi.CurrentCell.Value = fs.FormatNumbCurr(Convert.ToString(dgTransaksi.CurrentCell.Value));
            }
            else if ((dgTransaksi.Focused) && (dgTransaksi.CurrentCell.ColumnIndex == celldiscpersen))
            {
                if (Convert.ToDouble(dgTransaksi.CurrentCell.Value) == 0)
                {
                    row.Cells[celldiscpersen].Value = "0.00";
                    row.Cells[celldiscrp].Value = "0.00";
                }
                else if (Convert.ToString(dgTransaksi.CurrentCell.Value) == "")
                {
                    dgTransaksi.CurrentCell.Value = "0.00";
                }
                dgTransaksi.CurrentCell.Value = fs.FormatNumbCurr(Convert.ToString(dgTransaksi.CurrentCell.Value));
            }
            else if ((dgTransaksi.Focused) && (dgTransaksi.CurrentCell.ColumnIndex == celldiscrp))
            {
                if (Convert.ToDouble(row.Cells[celldiscrp].Value.ToString()) != tempDiskonRow)
                {
                    row.Cells[celldiscpersen].Value = "0.00";
                    tempDiskonRow = 0;
                }
                else if (Convert.ToString(dgTransaksi.CurrentCell.Value) == "")
                {
                    dgTransaksi.CurrentCell.Value = "0.00";
                }
                dgTransaksi.CurrentCell.Value = fs.FormatNumbCurr(Convert.ToString(dgTransaksi.CurrentCell.Value));
            }

            row.Cells[cellsubtotal].Value = HitungSubTotalRow(row.Cells[cellqty].Value.ToString(), row.Cells[cellhjual].Value.ToString(),
                    row.Cells[celldiscpersen].Value.ToString(), row.Cells[celldiscrp].Value.ToString(), e.RowIndex);
            lblTotal.Text = fs.FormatNumbCurr(HitungTotal().ToString());
            HitungGrandTotal();
        }

        private void txtDiskonPersen_Leave(object sender, EventArgs e)
        {
            fs.TextLeave(txtDiskonPersen);

            if (Convert.ToDouble(txtDiskonPersen.Text) == 0)
            {
                txtDiskonPersen.Text = "0.00";
                txtDiskonRp.Text = "0.00";
            }

            HitungPPn();
            HitungGrandTotal();
        }

        private void txtDiskonPersen_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.InputNumber(e);
        }

        private void txtDiskonRp_Leave(object sender, EventArgs e)
        {
            fs.TextLeave(txtDiskonRp);

            if (txtDiskonRp.Text != fs.FormatNumbCurr(tempDiskon.ToString()))
            {
                txtDiskonPersen.Text = "0.00";
                tempDiskon = 0;
            }

            HitungPPn();
            HitungGrandTotal();
        }

        private void txtDiskonRp_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.InputNumber(e);
        }

        private void txtOngkir_Leave(object sender, EventArgs e)
        {
            fs.TextLeave(txtOngkir);
            HitungGrandTotal();
        }

        private void txtOngkir_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.InputNumber(e);
        }

        private void chkPPn_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPPn.Checked == true)
            {
                HitungPPn();
            }
            else
            {
                txtPPn.Text = "0.00";
            }
        }

        private void txtPPn_TextChanged(object sender, EventArgs e)
        {
            HitungGrandTotal();
        }

        private void txtPembayaran_Leave(object sender, EventArgs e)
        {
            fs.TextLeave(txtPembayaran);
            HitungKembalian();
        }

        private void txtPembayaran_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.InputNumber(e);
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

        private void btnTambah_Click(object sender, EventArgs e)
        {
            TampilBarang(txtKodeBarcode.Text);

            if (namabarang == "")
            {
                psn.PesanInfo("Kode Barang " + txtKodeBarcode.Text.Trim() + " Tidak Ada Dalam Database");
                txtKodeBarcode.Text = "";
                chkTanda.Checked = false;
                txtKodeBarcode.Focus();
            }
            else if (Convert.ToDouble(stokgudang) <= 0)
            {
                DialogResult result = MessageBox.Show("Stok Barang " + txtKodeBarcode.Text.Trim() + " Tidak Mencukupi, " +
                    "Stok Tersedia " + CekStokBarang(txtKodeBarcode.Text.Trim()).ToString() + "",
                    "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    InsertDataGrid();
                    lblTotal.Text = fs.FormatNumbCurr(HitungTotal().ToString());
                    HitungGrandTotal();
                    namabarang = "";
                    txtKodeBarcode.Text = "";
                    chkTanda.Checked = false;
                }

                txtKodeBarcode.Text = "";
                chkTanda.Checked = false;
            }
            else
            {
                InsertDataGrid();
                lblTotal.Text = fs.FormatNumbCurr(HitungTotal().ToString());
                HitungGrandTotal();
                namabarang = "";
                txtKodeBarcode.Text = "";
                chkTanda.Checked = false;
            }
        }
    }
}
