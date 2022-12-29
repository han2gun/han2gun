using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;

namespace POS.frm
{
    public partial class Pembelian : Form
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
        int flagMasukGudang;

        public static string idsupplier;
        public static string barcode;

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
        int cellppn;
        int cellsubtotal;
        int cellqty1;

        string namabarang;
        string hargabeli;
        string satuan1;
        string satuan2;

        bool detailDelete;
        DataGridViewRow row;

        public Pembelian(MenuUtama mnutama)
        {
            InitializeComponent();
            frmUtama = mnutama;
            idUpdate = "";
            updateData = false;
            flagMasukGudang = 0;
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
            cellppn = 12;
            cellsubtotal = 13;
            cellqty1 = 14;
            namabarang = "";
            hargabeli = "0.00";
            detailDelete = true;
            fs.BoldHeaderDataGridView(dgTransaksi);
            this.KeyDown += new KeyEventHandler(this.OnKeyDown);
            ActiveControl = txtIdSupplier;
        }

        #region code
        private void UsrAccess()
        {
           string data = qry.GetData(this, "UsrAccess", userName, 0,
               "pembeliansv,pembeliandel,pembelianprt,pembelianup", "usrmgmt", "usrname = '" + userName + "'");

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
            fs.FillTextBoxArray(new TextBox[] { txtIdSupplier, txtNota, txtCatatan, txtKodeBarcode }, "");
            fs.FillTextBoxArray(new TextBox[] { txtDiskonPersen, txtDiskonRp, txtPotLain, txtBiayaLain, txtPPn, txtOngkir }, "0.00");
            fs.FillLabelArray(new Label[] { lblTotal, lblGrandTotal }, "0.00");
            lblNamaSupplier.Text = "";
            dtTglTransaksi.Value = DateTime.Today;
            dtTglTempo.Value = DateTime.Today;
            tglinput = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            chkPPn.Checked = false;
            flagMasukGudang = 0;
            dgTransaksi.Rows.Clear();
            lblID.Text = "AUTO ID";
            chkTanda.Checked = false;
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
                        psn.PesanInfo("ID Pembelian Masih Kosong");
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
                    op.PencarianOpen("Pencarian", "Pembelian", userName);
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

            string data = qry.GetData(this, "TampilData", id, 13, "id,idsupplier,nonota,tgltransaksi,tgltempo,catatan,total,discpersen,discrp," +
                "potlain,biayalain,ppn,ppnnominal,ongkir,grandtotal,flaggudang,tglinput", 
                "pembelian", "id = '" + id + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    idUpdate = filldata[0]; //jika kosong berarti data baru, jika muncul id data lama -> cek status boleh update atau tidak
                    txtIdSupplier.Text = filldata[1];
                    txtNota.Text = filldata[2];
                    dtTglTransaksi.Value = Convert.ToDateTime(filldata[3]);
                    dtTglTempo.Value = Convert.ToDateTime(filldata[4]);
                    txtCatatan.Text = filldata[5];
                    lblTotal.Text = fs.FormatNumbCurr(filldata[6]);
                    txtDiskonPersen.Text = fs.FormatNumbCurr(filldata[7]);
                    txtDiskonRp.Text = fs.FormatNumbCurr(filldata[8]);
                    txtPotLain.Text = fs.FormatNumbCurr(filldata[9]);
                    txtBiayaLain.Text = fs.FormatNumbCurr(filldata[10]);
                    chkPPn.Checked = fs.IntToBool(filldata[11]);
                    txtPPn.Text = fs.FormatNumbCurr(filldata[12]);
                    txtOngkir.Text = fs.FormatNumbCurr(filldata[13]);
                    lblGrandTotal.Text = fs.FormatNumbCurr(filldata[14]);
                    flagMasukGudang = Convert.ToInt32(filldata[15]);
                    tglinput = DateTime.Parse(filldata[16]).ToString("yyyy-MM-dd HH:mm:ss");

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

        private void TampilDetailData(string id)
        {
            qry.DataGridViewFill(this, dgTransaksi, "TampilDetailData", "id,barcode,nama,keterangan,qty,satuan,hbeli,discpersen,discpersen2,discpersen3,discrp,ppn,subtotal,kondisi",
                "pembelian_detail", "id = '" + id + "'");

            int row = qry.ds.Tables["detail"].Rows.Count - 1;

            if (row >= 0)
            {
                for (int i = 0; i <= row; i++)
                {
                    dgTransaksi.Rows.Add();
                    dgTransaksi.Rows[i].Cells[cellhapus].Value = "X";
                    dgTransaksi.Rows[i].Cells[cellkondisi].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[13];
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
                    dgTransaksi.Rows[i].Cells[cellppn].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[11].ToString());
                    dgTransaksi.Rows[i].Cells[cellsubtotal].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[12].ToString());
                    dgTransaksi.Rows[i].Cells[cellqty1].Value = "0.00";
                }

                dgTransaksi.AutoResizeColumns();
                qry.InsertLogAktivitas("TampilDetailData", this, lblID.Text, userName);
            }
        }

        private void TampilBarang(string barcode)
        {
            string data = qry.GetData(this, "TampilBarang", id, 8, "barcode,nama,satuan1,hargabeli", "barang", "barcode = '" + barcode + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    namabarang = filldata[1];
                    satuan1 = filldata[2];
                    hargabeli = fs.FormatNumbCurr(filldata[3]);

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

            for(int i = 0; i < satuan.Length; i++)
            {
                cboSatuan.Items.Add(satuan[i]);
            }

            cboSatuan.SelectedIndex = 0;
        }

        /*private string TampilSatuan1(string barcode)
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
        }*/

        /*private double TampilQty2(string barcode)
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
        }*/

        private void InsertDataGrid()
        {
            bool match = true;

            if (namabarang != "")
            {
                int row = dgTransaksi.Rows.Count - 1;

                if (chkTanda.Checked == true)
                {
                    dgTransaksi.Rows.Add("X", 1, txtKodeBarcode.Text.Trim(), namabarang, "", "1.00", satuan1, hargabeli, "0.00", "0.00", "0.00", "0.00", "0.00", hargabeli, "0.00");
                }
                else
                {
                    if (row >= 0)
                    {
                        for (int i = 0; i <= row; i++)
                        {
                            if (dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString() == txtKodeBarcode.Text.Trim())
                            {
                                dgTransaksi.Rows[i].Cells[cellqty].Value = fs.FormatNumbCurr((Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellqty].Value) + 1).ToString());
                                //panggil fungsi hitung subtotal
                                dgTransaksi.Rows[i].Cells[cellsubtotal].Value = HitungSubTotalRow(dgTransaksi.Rows[i].Cells[cellqty].Value.ToString(),
                                    dgTransaksi.Rows[i].Cells[cellhbeli].Value.ToString(), dgTransaksi.Rows[i].Cells[celldiscpersen].Value.ToString(),
                                    dgTransaksi.Rows[i].Cells[celldiscpersen2].Value.ToString(), dgTransaksi.Rows[i].Cells[celldiscpersen3].Value.ToString(),
                                    dgTransaksi.Rows[i].Cells[cellppn].Value.ToString(), dgTransaksi.Rows[i].Cells[celldiscrp].Value.ToString(), i);

                                //lblTotal.Text = fs.FormatNumbCurr(HitungTotal().ToString());
                                //HitungGrandTotal();

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
                            dgTransaksi.Rows.Add("X", 0, txtKodeBarcode.Text.Trim(), namabarang, "", "1.00", satuan1, hargabeli, "0.00", "0.00", "0.00", "0.00", "0.00", hargabeli, "0.00");
                            //dgTransaksi.AutoResizeColumns();
                        }
                    }
                    else
                    {
                        dgTransaksi.Rows.Add("X", 0, txtKodeBarcode.Text.Trim(), namabarang, "", "1.00", satuan1, hargabeli, "0.00", "0.00", "0.00", "0.00", "0.00", hargabeli, "0.00");

                        /*int rowActive = dgTransaksi.Rows.Count - 1;

                        dgTransaksi.Rows[rowActive].Cells[cellsubtotal].Value = HitungSubTotalRow(dgTransaksi.Rows[rowActive].Cells[cellqty].Value.ToString(),
                            dgTransaksi.Rows[rowActive].Cells[cellhbeli].Value.ToString(), dgTransaksi.Rows[rowActive].Cells[celldiscpersen].Value.ToString(),
                            dgTransaksi.Rows[rowActive].Cells[celldiscpersen2].Value.ToString(), dgTransaksi.Rows[rowActive].Cells[celldiscpersen3].Value.ToString(),
                            dgTransaksi.Rows[rowActive].Cells[cellppn].Value.ToString(), dgTransaksi.Rows[rowActive].Cells[celldiscrp].Value.ToString(), rowActive);

                        lblTotal.Text = fs.FormatNumbCurr(HitungTotal().ToString());
                        HitungGrandTotal();*/
                        //dgTransaksi.AutoResizeColumns();
                    }
                }
            }
        }

        private string HitungSubTotalRow(string valQty, string valHarga, string valDiscPersen, string valDiscPersen2, string valDiscPersen3, string valPPn, string valDiscRp, int row)
        {
            double hasil;
            double qty = Convert.ToDouble(valQty);
            double harga = Convert.ToDouble(valHarga);
            double discpersen = Convert.ToDouble(valDiscPersen);
            double discpersen2 = Convert.ToDouble(valDiscPersen2);
            double discpersen3 = Convert.ToDouble(valDiscPersen3);
            double ppn = Convert.ToDouble(valPPn);
            double discrp = Convert.ToDouble(valDiscRp);
            double hasildiskon = 0;
            double hasildiskon2 = 0;
            double hasildiskon3 = 0;
            double totaldiskon = 0;
            //double hasilppn = 0;

            if(discpersen > 0)
            {
                hasildiskon = (harga * qty * discpersen) / 100;
                dgTransaksi.Rows[row].Cells[celldiscrp].Value = fs.FormatNumbCurr(hasildiskon.ToString());
                tempDiskonRow = hasildiskon;
            }

            if (discpersen2 > 0)
            {
                hasildiskon2 = (((harga * qty) - hasildiskon) * discpersen2) / 100;
                dgTransaksi.Rows[row].Cells[celldiscrp].Value = fs.FormatNumbCurr((hasildiskon + hasildiskon2).ToString());
                tempDiskonRow = hasildiskon2;
            }

            if (discpersen3 > 0)
            {
                hasildiskon3 = (((harga * qty) - (hasildiskon + hasildiskon2)) * discpersen3) / 100;
                dgTransaksi.Rows[row].Cells[celldiscrp].Value = fs.FormatNumbCurr((hasildiskon + hasildiskon2 + hasildiskon3).ToString());
                tempDiskonRow = hasildiskon3;
            }

            totaldiskon = hasildiskon + hasildiskon2 + hasildiskon3;

            if(hasildiskon == 0 && hasildiskon2 == 0 && hasildiskon3 == 0)
            {
                totaldiskon = Convert.ToDouble(dgTransaksi.Rows[row].Cells[celldiscrp].Value);
            }

            ppn = ((qty * harga) - totaldiskon) * Convert.ToDouble(dgTransaksi.Rows[row].Cells[cellppn].Value) / 100;

            hasil = (qty * harga) - totaldiskon + ppn;

            return fs.FormatNumbCurr(hasil.ToString());
        }

        private double HitungTotalQtySatuan()
        {
            double totalqty = 0;

            if (dgTransaksi.Rows.Count > 0)
            {
                for (int i = 0; i < dgTransaksi.Rows.Count; i++)
                {
                    if (dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString() != "")
                    {
                        totalqty = totalqty + Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellqty].Value);
                    }
                }
            }
            else
            {
                totalqty = 0;
            }

            return totalqty;
        }

        private double HitungTotal()
        {
            double subtotal = 0;

            if(dgTransaksi.Rows.Count > 0)
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

        private void HitungPPn()
        {
            double total = Convert.ToDouble(lblTotal.Text);
            double diskon = Convert.ToDouble(txtDiskonPersen.Text);
            double diksonrp = Convert.ToDouble(txtDiskonRp.Text);
            double potlain = Convert.ToDouble(txtPotLain.Text);
            double biayalain = Convert.ToDouble(txtBiayaLain.Text);
            double hasildiskon = 0;
            double hasiltotal = 0;
            double hasilppn = 0;

            if(chkPPn.Checked == true)
            {
                if (diskon > 0)
                {
                    hasildiskon = (total * diskon) / 100;
                }
                else
                {
                    hasildiskon = Convert.ToDouble(txtDiskonRp.Text);
                }

                hasiltotal = total - hasildiskon - potlain + biayalain;

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
            double potlain = Convert.ToDouble(txtPotLain.Text);
            double biayalain = Convert.ToDouble(txtBiayaLain.Text);
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

            if(dgTransaksi.Rows.Count > 0)
            {
                hasiltotal = total - hasildiskon - potlain + biayalain + ppn + ongkir;
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
                kon.da = new MySqlDataAdapter("select barcode,qty,subtotalbersih from pembelian_detail where id = '" + idtransaksi + "'", kon.con);
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
            double totalQty = HitungTotalQtySatuan();

            try
            {
                DeleteStok(lblID.Text);
                qry.DeleteData("pembelian", "id = '" + lblID.Text + "'");
                qry.DeleteData("pembelian_detail", "id = '" + lblID.Text + "'");

                if (lblID.Text == "AUTO ID")
                {
                    lblID.Text = qry.CreateID(this, "Simpan", "id", "pembelian", "id like 'PO." + dtTglTransaksi.Value.ToString("MMyyyy") + ".%'",
                        "PO." + dtTglTransaksi.Value.ToString("MMyyyy") + ".", "transaksi");
                }

                double bagiBiayaLain = 0;
                double bagiPotLain = 0;
                double bagiOngkir = 0;

                //hitung bagi biaya lain
                if (Convert.ToDouble(txtBiayaLain.Text.Trim()) > 0)
                    bagiBiayaLain = Convert.ToDouble(txtBiayaLain.Text.Trim()) / totalQty;

                //hitung bagi potongan lain
                if (Convert.ToDouble(txtPotLain.Text.Trim()) > 0)
                    bagiPotLain = Convert.ToDouble(txtPotLain.Text.Trim()) / totalQty;

                //hitung bagi ongkir
                if (Convert.ToDouble(txtOngkir.Text.Trim()) > 0)
                    bagiOngkir = Convert.ToDouble(txtOngkir.Text.Trim()) / totalQty;

                qry.InsertData("pembelian", "id,idsupplier,nonota,tgltransaksi,tgltempo,catatan,total,discpersen,discrp,potlain,biayalain," +
                    "ppn,ppnnominal,ongkir,grandtotal,flaggudang,tglinput,tglupdate",
                    "'" + lblID.Text + "'," +
                    "'" + txtIdSupplier.Text.Trim() + "'," +
                    "'" + txtNota.Text.Trim() + "'," +
                    "'" + string.Format("{0:yyyy-MM-dd}", dtTglTransaksi.Value) + "'," +
                    "'" + string.Format("{0:yyyy-MM-dd}", dtTglTempo.Value) + "'," +
                    "'" + txtCatatan.Text.Trim() + "'," +
                    "" + fs.FNum(lblTotal.Text) + "," +
                    "" + fs.FNum(txtDiskonPersen.Text) + "," +
                    "" + fs.FNum(txtDiskonRp.Text) + "," +
                    "" + fs.FNum(txtPotLain.Text) + "," +
                    "" + fs.FNum(txtBiayaLain.Text) + "," +
                    "" + fs.BoolToInt(chkPPn.Checked) + "," +
                    "" + fs.FNum(txtPPn.Text) + "," +
                    "" + fs.FNum(txtOngkir.Text) + "," +
                    "" + fs.FNum(lblGrandTotal.Text) + "," +
                    "" + flagMasukGudang + "," +
                    "'" + tglinput + "'," +
                    "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'");

                for (int i = 0; i < dgTransaksi.Rows.Count; i++)
                {
                    string kondisi = dgTransaksi.Rows[i].Cells[cellkondisi].Value.ToString();
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
                    string ppn = dgTransaksi.Rows[i].Cells[cellppn].Value.ToString();
                    string subtotal = dgTransaksi.Rows[i].Cells[cellsubtotal].Value.ToString();

                    //hitung subtotal bersih
                    double hrgSatuan = 0;
                    double hrgDiskon = 0;
                    double hrgPPn = 0;
                    double hrgAsliSatuan = 0;
                    double subtotalBersih = 0;

                    if (Convert.ToDouble(subtotal) <= 0)
                    {
                        hrgSatuan = 0;
                    }
                    else
                    {
                        hrgSatuan = Convert.ToDouble(subtotal) / Convert.ToDouble(qty);
                    }

                    if (hrgSatuan <= 0)
                    {
                        hrgAsliSatuan = 0;
                        hrgDiskon = 0;
                        hrgPPn = 0;
                        hrgAsliSatuan = 0;
                        subtotalBersih = 0;
                    }
                    else
                    {
                        if (Convert.ToDouble(txtDiskonPersen.Text.Trim()) > 0)
                            hrgDiskon = hrgSatuan * Convert.ToDouble(txtDiskonPersen.Text.Trim()) / 100;

                        if (chkPPn.Checked == true)
                            hrgPPn = ((hrgSatuan - hrgDiskon + bagiBiayaLain - bagiPotLain) * 10 / 100);

                        hrgAsliSatuan = hrgSatuan - hrgDiskon + bagiBiayaLain - bagiPotLain + hrgPPn + bagiOngkir;
                        subtotalBersih = hrgAsliSatuan * Convert.ToDouble(qty);
                    }                    

                    if (barcode != "" && Convert.ToDouble(qty) > 0)
                    {
                        qry.InsertData("pembelian_detail", "id,barcode,nama,keterangan,qty,satuan,hbeli,discpersen," +
                            "discpersen2,discpersen3,discrp,ppn,subtotal,subtotalbersih,kondisi",
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
                            "" + fs.FNum(ppn) + "," +
                            "" + fs.FNum(subtotal) + "," +
                            "" + fs.FNum(subtotalBersih.ToString()) + "," +
                            "" + kondisi + "");
                    }

                    /*if (Convert.ToDouble(hbeli) > 0)
                    {
                        qry.UpdateData("barang", "hargabeli = " + fs.FNum(hbeli) + "", "barcode = '" + barcode + "'");
                    }*/

                    qry.UpdateData("barang", "stokgudang = stokgudang + " + fs.FNum(qty) + "," +
                        "stokrupiah = stokrupiah + " + fs.FNum(subtotalBersih.ToString()) + "", "barcode = '" + barcode + "'");
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
            if (qry.DataExist(this, "Hapus", lblID.Text, lblID.Text, "idpembelian", "hutang", "idpembelian = '" + lblID.Text + "'"))
            {
                fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Nota Pembelian " + lblID.Text + " Telah Digunakan Dalam Transaksi Hutang",
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
                        qry.DeleteData("pembelian", "id = '" + lblID.Text + "'");
                        qry.DeleteData("pembelian_detail", "id = '" + lblID.Text + "'");

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

        private void Pembelian_Load(object sender, EventArgs e)
        {
            tglinput = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (id != "")
                lblID.Text = id;

            frmUtama.lblNamaForm.Text = "- Pembelian";
            UsrAccess();
        }

        private void Pembelian_KeyPress(object sender, KeyPressEventArgs e)
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
            cls.OpenForm op = new cls.OpenForm(frmUtama);
            op.ListOpen("List", "Pembelian-Supplier", "Supplier", "", userName);

            txtIdSupplier.Text = idsupplier;
            idsupplier = "";
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
            op.ListOpen("List", "Pembelian-Barang", "Barang", "", userName);

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

                if (namabarang == "")
                {
                    psn.PesanInfo("Kode Barang " + txtKodeBarcode.Text.Trim() + " Tidak Ada Dalam Database");
                    txtKodeBarcode.Text = "";
                    chkTanda.Checked = false;
                    txtKodeBarcode.Focus();
                }
                else
                {
                    InsertDataGrid();
                    lblTotal.Text = fs.FormatNumbCurr(HitungTotal().ToString());
                    HitungGrandTotal();
                    namabarang = "";
                    hargabeli = "0.00";
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
                        fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Hapus Kode Barang " + row.Cells[cellbarcode].Value.ToString() + " dari List Pembelian Berhasil",
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
            if (dgTransaksi.CurrentCell.ColumnIndex == cellqty || dgTransaksi.CurrentCell.ColumnIndex == cellhbeli || 
                dgTransaksi.CurrentCell.ColumnIndex == celldiscpersen || dgTransaksi.CurrentCell.ColumnIndex == celldiscpersen2 ||
                dgTransaksi.CurrentCell.ColumnIndex == celldiscpersen3 || dgTransaksi.CurrentCell.ColumnIndex == celldiscrp ||
                dgTransaksi.CurrentCell.ColumnIndex == cellppn)
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

            if ((dgTransaksi.Focused) && (dgTransaksi.CurrentCell.ColumnIndex == cellqty) || (dgTransaksi.Focused) && (dgTransaksi.CurrentCell.ColumnIndex == cellhbeli))
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
                else if(Convert.ToString(dgTransaksi.CurrentCell.Value) == "")
                {
                    dgTransaksi.CurrentCell.Value = "0.00";
                }
                dgTransaksi.CurrentCell.Value = fs.FormatNumbCurr(Convert.ToString(dgTransaksi.CurrentCell.Value));
            }
            else if ((dgTransaksi.Focused) && (dgTransaksi.CurrentCell.ColumnIndex == celldiscpersen2))
            {
                if (Convert.ToDouble(dgTransaksi.CurrentCell.Value) == 0)
                {
                    row.Cells[celldiscpersen2].Value = "0.00";
                    row.Cells[celldiscrp].Value = "0.00";
                }
                else if (Convert.ToString(dgTransaksi.CurrentCell.Value) == "")
                {
                    dgTransaksi.CurrentCell.Value = "0.00";
                }
                dgTransaksi.CurrentCell.Value = fs.FormatNumbCurr(Convert.ToString(dgTransaksi.CurrentCell.Value));
            }
            else if ((dgTransaksi.Focused) && (dgTransaksi.CurrentCell.ColumnIndex == celldiscpersen3))
            {
                if (Convert.ToDouble(dgTransaksi.CurrentCell.Value) == 0)
                {
                    row.Cells[celldiscpersen3].Value = "0.00";
                    row.Cells[celldiscrp].Value = "0.00";
                }
                else if (Convert.ToString(dgTransaksi.CurrentCell.Value) == "")
                {
                    dgTransaksi.CurrentCell.Value = "0.00";
                }
                dgTransaksi.CurrentCell.Value = fs.FormatNumbCurr(Convert.ToString(dgTransaksi.CurrentCell.Value));
            }
            else if((dgTransaksi.Focused) && (dgTransaksi.CurrentCell.ColumnIndex == celldiscrp))
            {
                if (Convert.ToDouble(row.Cells[celldiscrp].Value.ToString()) != tempDiskonRow)
                {
                    row.Cells[celldiscpersen].Value = "0.00";
                    row.Cells[celldiscpersen2].Value = "0.00";
                    row.Cells[celldiscpersen3].Value = "0.00";
                    tempDiskonRow = 0;
                }
                else if (Convert.ToString(dgTransaksi.CurrentCell.Value) == "")
                {
                    dgTransaksi.CurrentCell.Value = "0.00";
                }
                dgTransaksi.CurrentCell.Value = fs.FormatNumbCurr(Convert.ToString(dgTransaksi.CurrentCell.Value));
            }
            if ((dgTransaksi.Focused) && (dgTransaksi.CurrentCell.ColumnIndex == cellppn))
            {
                if (Convert.ToString(dgTransaksi.CurrentCell.Value) == "")
                {
                    dgTransaksi.CurrentCell.Value = "0.00";
                }
                dgTransaksi.CurrentCell.Value = fs.FormatNumbCurr(Convert.ToString(dgTransaksi.CurrentCell.Value));
            }

            row.Cells[cellsubtotal].Value = HitungSubTotalRow(row.Cells[cellqty].Value.ToString(), row.Cells[cellhbeli].Value.ToString(),
                    row.Cells[celldiscpersen].Value.ToString(), row.Cells[celldiscpersen2].Value.ToString(), row.Cells[celldiscpersen3].Value.ToString(),
                    row.Cells[cellppn].Value.ToString(), row.Cells[celldiscrp].Value.ToString(), e.RowIndex);
            lblTotal.Text = fs.FormatNumbCurr(HitungTotal().ToString());
            HitungGrandTotal();
        }

        private void dgTransaksi_Leave(object sender, EventArgs e)
        {
            txtDiskonPersen.Focus();
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
            if(chkPPn.Checked == true)
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

        private void txtPotLain_Leave(object sender, EventArgs e)
        {
            fs.TextLeave(txtPotLain);

            HitungPPn();
            HitungGrandTotal();
        }

        private void txtPotLain_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.InputNumber(e);
        }

        private void txtBiayaLain_Leave(object sender, EventArgs e)
        {
            fs.TextLeave(txtBiayaLain);

            HitungPPn();
            HitungGrandTotal();
        }

        private void txtBiayaLain_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.InputNumber(e);
        }
    }
}
