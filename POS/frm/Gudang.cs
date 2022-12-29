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
    public partial class Gudang : Form
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

        public static string idpembelian;

        //variabel cell
        int cellnumb;
        int cellbarcode;
        int cellnama;
        int cellqtybeli;
        int cellqtyditerima;
        int cellqty;
        int cellsatuan;
        int cellsubtotal;
        int cellqty1;
        int cellqtypembagi;
        int cellexpdate;
        int celltester;

        DataGridViewRow row;

        public Gudang(MenuUtama mnutama)
        {
            InitializeComponent();
            frmUtama = mnutama;
            idUpdate = "";
            updateData = false;
            cellnumb = 0;
            cellbarcode = 1;
            cellnama = 2;
            cellqtybeli = 3;
            cellqtyditerima = 4;
            cellqty = 5;
            cellsatuan = 6;
            cellsubtotal = 7;
            cellqty1 = 8;
            cellqtypembagi = 9;
            cellexpdate = 10;
            celltester = 11;
            fs.BoldHeaderDataGridView(dgTransaksi);
            this.KeyDown += new KeyEventHandler(this.OnKeyDown);
            ActiveControl = txtIDPembelian;
        }

        #region code
        private void UsrAccess()
        {
            string data = qry.GetData(this, "UsrAccess", userName, 0,
                "gudangmasuksv,gudangmasukdel,gudangmasukprt,gudangmasukup", "usrmgmt", "usrname = '" + userName + "'");

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
            fs.FillTextBoxArray(new TextBox[] { txtIDPembelian, txtCatatan }, "");
            fs.FillLabelArray(new Label[] { lblNamaSupplier, lblNoNota }, "");
            fs.FillTextBoxArray(new TextBox[] { txtDiskonPersen, txtDiskonRp, txtPotLain, txtBiayaLain, txtPPn, txtOngkir }, "0.00");
            fs.FillLabelArray(new Label[] { lblTotal, lblGrandTotal }, "0.00");
            lblNamaSupplier.Text = "";
            dtTglTransaksi.Value = DateTime.Today;
            tglinput = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dgTransaksi.Rows.Clear();
            lblID.Text = "AUTO ID";
            chkTerimaSemuaBarang.Checked = false;
            txtIDPembelian.Focus();
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
                    if (txtIDPembelian.Text.Trim() == "")
                    {
                        psn.PesanInfo("No. Pembelian Masih Kosong");
                        txtIDPembelian.Focus();
                    }
                    else if (dgTransaksi.Rows.Count <= 0)
                    {
                        psn.PesanInfo("Detail Transaksi Masih Kosong");
                    }
                    else if (HitungTotalQty() <= 0)
                    {
                        psn.PesanInfo("Belum Ada Qty Masuk Yang Diinput");
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
                        psn.PesanInfo("ID Transaksi Gudang Masih Kosong");
                    }
                    else
                    {
                        Hapus();
                    }
                    break;
                case "CETAK":
                    if (txtIDPembelian.Text.Trim() == "")
                    {
                        psn.PesanInfo("No. Pembelian Masih Kosong");
                        txtIDPembelian.Focus();
                    }
                    else if (dgTransaksi.Rows.Count <= 0)
                    {
                        psn.PesanInfo("Detail Transaksi Masih Kosong");
                    }
                    else if (HitungTotalQty() <= 0)
                    {
                        psn.PesanInfo("Belum Ada Qty Masuk Yang Diinput");
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
                    op.PencarianOpen("Pencarian", "Gudang", userName);
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
                    break;
                case Keys.F10:
                    SelectToolBar(btnKeluar);
                    break;
                default:
                    break;*/
            }
        }

        private void TampilData(string id)
        {
            idUpdate = "";

            string data = qry.GetData(this, "TampilData", id, 13, "id,idpembelian,tgltransaksi,catatan,tglinput",
                "gudang_masuk", "id = '" + id + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    idUpdate = filldata[0]; //jika kosong berarti data baru, jika muncul id data lama -> cek status boleh update atau tidak
                    txtIDPembelian.Text = filldata[1];
                    dtTglTransaksi.Value = Convert.ToDateTime(filldata[2]);
                    txtCatatan.Text = filldata[3];
                    tglinput = DateTime.Parse(filldata[4]).ToString("yyyy-MM-dd HH:mm:ss");

                    TampilDetailData(id);

                    qry.InsertLogAktivitas("TampilData", this, lblID.Text, userName);
                }
            }
        }

        private string TampilQtyPembelian(string id, string barcode, string numb)
        {
            string qty = "0";

            string data = qry.GetData(this, "TampilQtyPembelian", id, 13, "id, qty", "pembelian_detail", 
                "id = '" + id + "' and barcode = '" + barcode + "' and numb = " + numb + "");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    qty = filldata[1];

                    qry.InsertLogAktivitas("TampilQtyPembelian", this, txtIDPembelian.Text + "-" + barcode, userName);
                }
            }

            return qty;
        }

        private string TampilSubTotalPembelian(string id, string barcode, string numb)
        {
            string subtotal = "0";

            string data = qry.GetData(this, "TampilSubTotalPembelian", id, 13, "id, subtotal", "pembelian_detail", 
                "id = '" + id + "' and barcode = '" + barcode + "' and numb = " + numb + "");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    subtotal = filldata[1];

                    qry.InsertLogAktivitas("TampilSubTotalPembelian", this, txtIDPembelian.Text + "-" + barcode, userName);
                }
            }

            return subtotal;
        }

        private string TampilQtyDiterima(string idpembelian, string barcode, string id, string numb)
        {
            string qtyditerima = "0";

            string data = qry.GetData(this, "TampilQtyDiterima", id, 13, "a.idpembelian, b.barcode, sum(b.qty) as qty", "gudang_masuk a inner join gudang_masuk_detail b on a.id = b.id", 
                "a.idpembelian = '" + idpembelian + "' and b.barcode = '" + barcode + "' and b.numbpembelian = " + numb + " and a.id != '" + id + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    qtyditerima = filldata[2];

                    qry.InsertLogAktivitas("TampilQtyDiterima", this, txtIDPembelian.Text + "-" + barcode, userName);
                }
            }

            return qtyditerima;
        }

        private void TampilDetailData(string id)
        {
            qry.DataGridViewFill(this, dgTransaksi, "TampilDetailData", "id,numbpembelian,barcode,nama,qty,satuan,tglrusak,tester", "gudang_masuk_detail", "id = '" + id + "'");

            int row = qry.ds.Tables["detail"].Rows.Count - 1;

            if (row >= 0)
            {
                for (int i = 0; i <= row; i++)
                {
                    dgTransaksi.Rows.Add();
                    dgTransaksi.Rows[i].Cells[cellnumb].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[1];
                    dgTransaksi.Rows[i].Cells[cellbarcode].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[2];
                    dgTransaksi.Rows[i].Cells[cellnama].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[3];
                    dgTransaksi.Rows[i].Cells[cellqty].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[4].ToString());
                    dgTransaksi.Rows[i].Cells[cellsatuan].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[5];
                    //memanggil fungsi lain
                    dgTransaksi.Rows[i].Cells[cellqtybeli].Value = fs.FormatNumbCurr(TampilQtyPembelian(txtIDPembelian.Text, 
                        dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString(), dgTransaksi.Rows[i].Cells[cellnumb].Value.ToString()).ToString());
                    dgTransaksi.Rows[i].Cells[cellsubtotal].Value = fs.FormatNumbCurr(TampilSubTotalPembelian(txtIDPembelian.Text, 
                        dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString(), dgTransaksi.Rows[i].Cells[cellnumb].Value.ToString()).ToString());
                    dgTransaksi.Rows[i].Cells[cellqty1].Value = "0.00";
                    dgTransaksi.Rows[i].Cells[cellqtypembagi].Value = "0.00";
                    dgTransaksi.Rows[i].Cells[cellexpdate].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[6];
                    dgTransaksi.Rows[i].Cells[celltester].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[7];

                    if (TampilQtyDiterima(txtIDPembelian.Text, dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString(), lblID.Text, dgTransaksi.Rows[i].Cells[cellnumb].Value.ToString()) == "")
                    {
                        dgTransaksi.Rows[i].Cells[cellqtyditerima].Value = "0.00";
                    }
                    else
                    {
                        dgTransaksi.Rows[i].Cells[cellqtyditerima].Value = fs.FormatNumbCurr(
                            TampilQtyDiterima(txtIDPembelian.Text, dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString(), lblID.Text, dgTransaksi.Rows[i].Cells[cellnumb].Value.ToString()).ToString());
                    }
                }

                dgTransaksi.AutoResizeColumns();
                qry.InsertLogAktivitas("TampilDetailData", this, lblID.Text, userName);
            }
        }

        private void TampilPembelian(string id)
        {
            string data = qry.GetData(this, "TampilPembelian", id, 13, "a.id,b.nama,a.nonota,a.tgltransaksi,a.total,a.discpersen,a.discrp," +
                "a.potlain,a.biayalain,a.ppn,a.ppnnominal,a.ongkir,a.grandtotal",
                "pembelian a inner join supplier b on a.idsupplier = b.id", "a.id = '" + id + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    lblNamaSupplier.Text = filldata[1];
                    lblNoNota.Text = filldata[2];
                    dtTglBeli.Value = Convert.ToDateTime(filldata[3]);
                    lblTotal.Text = fs.FormatNumbCurr(filldata[4]);
                    txtDiskonPersen.Text = fs.FormatNumbCurr(filldata[5]);
                    txtDiskonRp.Text = fs.FormatNumbCurr(filldata[6]);
                    txtPotLain.Text = fs.FormatNumbCurr(filldata[7]);
                    txtBiayaLain.Text = fs.FormatNumbCurr(filldata[8]);
                    chkPPn.Checked = fs.IntToBool(filldata[9]);
                    txtPPn.Text = fs.FormatNumbCurr(filldata[10]);
                    txtOngkir.Text = fs.FormatNumbCurr(filldata[11]);
                    lblGrandTotal.Text = fs.FormatNumbCurr(filldata[12]);

                    qry.InsertLogAktivitas("TampilPembelian", this, txtIDPembelian.Text, userName);
                }

                if (lblID.Text == "AUTO ID")
                {
                    TampilDataDetailPembelian(id);
                }
            }
        }

        private void TampilDataDetailPembelian(string id)
        {
            qry.DataGridViewFill(this, dgTransaksi, "TampilDataDetailPembelian", "id,numb,barcode,nama,qty,satuan,subtotal,tester",
                "pembelian_detail", "id = '" + id + "'");

            int row = qry.ds.Tables["detail"].Rows.Count - 1;

            if (row >= 0)
            {
                for (int i = 0; i <= row; i++)
                {
                    dgTransaksi.Rows.Add();
                    dgTransaksi.Rows[i].Cells[cellnumb].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[1];
                    dgTransaksi.Rows[i].Cells[cellbarcode].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[2];
                    dgTransaksi.Rows[i].Cells[cellnama].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[3];
                    dgTransaksi.Rows[i].Cells[cellqtybeli].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[4].ToString());
                    dgTransaksi.Rows[i].Cells[cellqty].Value = "0.00";
                    dgTransaksi.Rows[i].Cells[cellsatuan].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[5];
                    dgTransaksi.Rows[i].Cells[cellsubtotal].Value = fs.FormatNumbCurr(qry.ds.Tables["detail"].Rows[i].ItemArray[6].ToString());
                    dgTransaksi.Rows[i].Cells[cellqty1].Value = "0.00";
                    dgTransaksi.Rows[i].Cells[cellqtypembagi].Value = "0.00";
                    dgTransaksi.Rows[i].Cells[cellexpdate].Value = "";
                    dgTransaksi.Rows[i].Cells[celltester].Value = qry.ds.Tables["detail"].Rows[i].ItemArray[7];

                    if (TampilQtyDiterima(txtIDPembelian.Text, dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString(), lblID.Text, dgTransaksi.Rows[i].Cells[cellnumb].Value.ToString()) == "")
                    {
                        dgTransaksi.Rows[i].Cells[cellqtyditerima].Value = "0.00";
                    }
                    else
                    {
                        dgTransaksi.Rows[i].Cells[cellqtyditerima].Value = fs.FormatNumbCurr(
                            TampilQtyDiterima(txtIDPembelian.Text, dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString(), lblID.Text, dgTransaksi.Rows[i].Cells[cellnumb].Value.ToString()).ToString());
                    }
                }

                dgTransaksi.AutoResizeColumns();
                qry.InsertLogAktivitas("TampilDataDetailPembelian", this, txtIDPembelian.Text, userName);
            }
        }

        private double HitungTotalQty()
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

        private double HitungTotalQtySatuanTerkecil()
        {
            double totalqty = 0;

            if (dgTransaksi.Rows.Count > 0)
            {
                for (int i = 0; i < dgTransaksi.Rows.Count; i++)
                {
                    if (dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString() != "")
                    {
                        totalqty = totalqty + Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellqtypembagi].Value);
                    }
                }
            }
            else
            {
                totalqty = 0;
            }

            return totalqty;
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

        /*private double StokGudangTersedia(string id, string barcode)
        {
            //dalam satuan terkecil
            double qty = 0;

            string data = qry.GetData(this, "StokGudangTersedia", id, 13, "id, barcode, qtymasuk", "pembelian_barang", 
                "id = '" + id + "' and barcode = '" + barcode + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    qty = Convert.ToDouble(filldata[2]);

                    qry.InsertLogAktivitas("StokGudangTersedia", this, txtIDPembelian.Text + "-" + barcode, userName);
                }
            }

            return qty;
        }*/

        /*private double QtyBarangMasuk(string id, string barcode)
        {
            //dalam satuan terkecil
            double qty = 0;

            string data = qry.GetData(this, "QtyBarangMasuk", id, 13, "id, barcode, qty", "gudang_masuk_detail",
                "id = '" + id + "' and barcode = '" + barcode + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    qty = Convert.ToDouble(filldata[2]);

                    qry.InsertLogAktivitas("QtyBarangMasuk", this, lblID.Text + "-" + barcode, userName);
                }
            }

            return qty;
        }*/

        private void DeleteStok(string idtransaksi)
        {
            try
            {
                DataSet ds = new DataSet();
                kon.OpenConn();
                kon.da = new MySqlDataAdapter("select barcode,stok from barang_detail where idgudangmasuk = '" + idtransaksi + "'", kon.con);
                kon.da.Fill(ds, "data");
                int row = ds.Tables["data"].Rows.Count - 1;

                if(row >= 0)
                {
                    for (int i = 0; i <= row; i++)
                    {
                        qry.UpdateData("barang", "stokgudang = stokgudang - " + fs.FNum(ds.Tables["data"].Rows[i].ItemArray[1].ToString()) + "",
                                "barcode = '" + ds.Tables["data"].Rows[i].ItemArray[0].ToString() + "'");

                        /*if (ds.Tables["data"].Rows[i].ItemArray[2].ToString() == TampilSatuan1(ds.Tables["data"].Rows[i].ItemArray[0].ToString()))
                        {
                            qry.UpdateData("barang", "stokgudang = stokgudang - " + fs.FNum(ds.Tables["data"].Rows[i].ItemArray[1].ToString()) + "",
                                "barcode = " + ds.Tables["data"].Rows[i].ItemArray[0].ToString() + "");
                        }
                        else
                        {
                            double qtypcs = Convert.ToDouble(ds.Tables["data"].Rows[i].ItemArray[1].ToString()) *
                                TampilQty2(ds.Tables["data"].Rows[i].ItemArray[0].ToString());

                            qry.UpdateData("barang", "stokgudang = stokgudang - " + fs.FNum(qtypcs.ToString()) + "",
                                "barcode = " + ds.Tables["data"].Rows[i].ItemArray[0].ToString() + "");
                        }*/
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

        //harus ada mekanisme buat ngurangi qtymasuk terus tambah lagi di barang_detail
        private void Simpan()
        {
            if (qry.DataExist(this, "Hapus", lblID.Text, txtIDPembelian.Text.Trim(), "b.idgudangmasuk",
                "barang_display a inner join barang_detail b on a.idbarangdetail = b.id", "b.idgudangmasuk = '" + lblID.Text + "'"))
            {
                fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Stok Pada Dokumen " + lblID.Text + " Sudah Pindah ke Stok Display",
                    frmUtama.tooltip_x, frmUtama.tooltip_y, "warning");
            }
            else
            {
                try
                {
                    DeleteStok(lblID.Text);
                    qry.DeleteData("gudang_masuk", "id = '" + lblID.Text + "'");
                    qry.DeleteData("gudang_masuk_detail", "id = '" + lblID.Text + "'");
                    qry.DeleteData("barang_detail", "idgudangmasuk = '" + lblID.Text + "'");

                    //mulai simpan
                    if (lblID.Text == "AUTO ID")
                    {
                        lblID.Text = qry.CreateID(this, "Simpan", "id", "gudang_masuk", "id like 'PB." + dtTglTransaksi.Value.ToString("MMyyyy") + ".%'",
                            "PB." + dtTglTransaksi.Value.ToString("MMyyyy") + ".", "transaksi");
                    }

                    qry.InsertData("gudang_masuk", "id,idpembelian,tgltransaksi,catatan,tglinput,tglupdate",
                        "'" + lblID.Text + "'," +
                        "'" + txtIDPembelian.Text.Trim() + "'," +
                        "'" + string.Format("{0:yyyy-MM-dd}", dtTglTransaksi.Value) + "'," +
                        "'" + txtCatatan.Text.Trim() + "'," +
                        "'" + tglinput + "'," +
                        "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'");                    

                    for (int i = 0; i < dgTransaksi.Rows.Count; i++)
                    {
                        string barcode = dgTransaksi.Rows[i].Cells[cellbarcode].Value.ToString();
                        string numb = dgTransaksi.Rows[i].Cells[cellnumb].Value.ToString();
                        string nama = dgTransaksi.Rows[i].Cells[cellnama].Value.ToString();
                        string qtybeli = dgTransaksi.Rows[i].Cells[cellqtybeli].Value.ToString();
                        string qty = dgTransaksi.Rows[i].Cells[cellqty].Value.ToString(); //qty yang diterima
                        string qty1 = dgTransaksi.Rows[i].Cells[cellqty1].Value.ToString(); //konversi qty yang diterima
                        string qtypembagi = dgTransaksi.Rows[i].Cells[cellqtypembagi].Value.ToString(); //konversi qty dari qty beli
                        string satuan = dgTransaksi.Rows[i].Cells[cellsatuan].Value.ToString();
                        string subtotal = dgTransaksi.Rows[i].Cells[cellsubtotal].Value.ToString();
                        string tglrusak = dgTransaksi.Rows[i].Cells[cellexpdate].Value.ToString(); //expired date
                        string tester = dgTransaksi.Rows[i].Cells[celltester].Value.ToString();
                        string comparesatuan = TampilSatuan1(barcode);
                        string hbelisatuan = "0.00";

                        if (barcode != "" && Convert.ToDouble(qty) > 0)
                        {
                            qry.InsertData("gudang_masuk_detail", "id,numbpembelian,barcode,nama,qty,satuan,tglrusak,tester",
                                "'" + lblID.Text + "'," +
                                "" + fs.FNum(numb) + "," +
                                "'" + barcode + "'," +
                                "'" + nama + "'," +
                                "" + fs.FNum(qty) + "," +
                                "'" + satuan + "'," +
                                "'" + tglrusak + "'," +
                                "" + tester + "");

                            //simpan detail barang per harga tanggal beli -> untuk tahu harga FIFO nya
                            if (comparesatuan == satuan)
                            {
                                //harga beli dibaginya dengan semua qty meskipun ada beberapa qty yang belum diterima
                                hbelisatuan = Convert.ToString(Convert.ToDouble(subtotal) / Convert.ToDouble(qtybeli));

                                qry.InsertData("barang_detail", "idpembelian,idgudangmasuk,tglbeli,barcode,hbelisatuan,ongkir,ppn,diskonumum,stok,tglrusak,tester",
                                    "'" + txtIDPembelian.Text.Trim() + "'," +
                                    "'" + lblID.Text + "'," +
                                    "'" + string.Format("{0:yyyy-MM-dd}", dtTglBeli.Value) + "'," +
                                    "'" + barcode + "'," +
                                    "" + fs.FNum(hbelisatuan) + "," +
                                    "0,0,0," +
                                    "" + fs.FNum(qty) + "," +
                                    "'" + tglrusak + "'," +
                                    "" + tester + "");
                            }
                            else
                            {
                                qty1 = Convert.ToString(TampilQty2(barcode) * Convert.ToDouble(qty));
                                //harga beli dibaginya dengan semua qty meskipun ada beberapa qty yang belum diterima
                                qtypembagi = Convert.ToString(TampilQty2(barcode) * Convert.ToDouble(qtybeli));
                                hbelisatuan = Convert.ToString(Convert.ToDouble(subtotal) / Convert.ToDouble(qtypembagi));

                                qry.InsertData("barang_detail", "idpembelian,idgudangmasuk,tglbeli,barcode,hbelisatuan,ongkir,ppn,diskonumum,stok,tglrusak,tester",
                                    "'" + txtIDPembelian.Text.Trim() + "'," +
                                    "'" + lblID.Text + "'," +
                                    "'" + string.Format("{0:yyyy-MM-dd}", dtTglBeli.Value) + "'," +
                                    "'" + barcode + "'," +
                                    "" + fs.FNum(hbelisatuan) + "," +
                                    "0,0,0," +
                                    "" + fs.FNum(qty1) + "," +
                                    "'" + tglrusak + "'," +
                                    "" + tester + "");
                            }
                        }

                        //update stok di tabel barang
                        if (comparesatuan == satuan)
                        {
                            //mengisi nilai cellqtypembagi, untuk hitung total qty
                            dgTransaksi.Rows[i].Cells[cellqtypembagi].Value = qtybeli;

                            qry.UpdateData("barang", "stokgudang = stokgudang + " + fs.FNum(qty) + "", "barcode = '" + barcode + "'");
                        }
                        else
                        {
                            qty1 = Convert.ToString(TampilQty2(barcode) * Convert.ToDouble(qty));
                            qtypembagi = Convert.ToString(TampilQty2(barcode) * Convert.ToDouble(qtybeli));
                            //mengisi nilai cellqtypembagi, untuk hitung total qty
                            dgTransaksi.Rows[i].Cells[cellqtypembagi].Value = qtypembagi;

                            qry.UpdateData("barang", "stokgudang = stokgudang + " + fs.FNum(qty1) + "", "barcode = '" + barcode + "'");
                        }
                    }

                    //jadinya yang disimpan ke database persen nya aja, bukan rupiahnya
                    if (Convert.ToDouble(txtDiskonPersen.Text) > 0)
                    {
                        string diskonumumbagi = txtDiskonPersen.Text.Trim();

                        qry.UpdateData("barang_detail", "diskonumum = " + fs.FNum(diskonumumbagi) + "", "idgudangmasuk = '" + lblID.Text + "'");
                    }
                    //potongan lain di luar diskon % dibagi rata
                    if (Convert.ToDouble(txtPotLain.Text) > 0)
                    {
                        string potlain = Convert.ToString(Convert.ToDouble(txtPotLain.Text) / HitungTotalQtySatuanTerkecil());

                        qry.UpdateData("barang_detail", "potlain = " + fs.FNum(potlain) + "", "idgudangmasuk = '" + lblID.Text + "'");
                    }
                    //biaya lain diluar ppn
                    if (Convert.ToDouble(txtBiayaLain.Text) > 0)
                    {
                        string biayalain = Convert.ToString(Convert.ToDouble(txtBiayaLain.Text) / HitungTotalQtySatuanTerkecil());

                        qry.UpdateData("barang_detail", "biayalain = " + fs.FNum(biayalain) + "", "idgudangmasuk = '" + lblID.Text + "'");
                    }
                    //ppn yang disimpan persen nya (10%)
                    if (Convert.ToDouble(txtPPn.Text) > 0)
                    {
                        string ppnbagi = "10";

                        qry.UpdateData("barang_detail", "ppn = " + fs.FNum(ppnbagi) + "", "idgudangmasuk = '" + lblID.Text + "'");
                    }

                    if (Convert.ToDouble(txtOngkir.Text) > 0)
                    {
                        string ongkirbagi = Convert.ToString(Convert.ToDouble(txtOngkir.Text) / HitungTotalQtySatuanTerkecil());

                        qry.UpdateData("barang_detail", "ongkir = " + fs.FNum(ongkirbagi) + "", "idgudangmasuk = '" + lblID.Text + "'");
                    }

                    qry.UpdateData("pembelian", "flaggudang = 1", "id = '" + txtIDPembelian.Text.Trim() + "'");

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
        }

        //harus ada mekanisme mengurangi qtymasuk di pembelian_barang
        private void Hapus()
        {
            if (qry.DataExist(this, "Hapus", lblID.Text, txtIDPembelian.Text.Trim(), "b.idgudangmasuk", 
                "barang_display a inner join barang_detail b on a.idbarangdetail = b.id", "b.idgudangmasuk = '" + lblID.Text + "'"))
            {
                fs.ToolTipTransaksi(frmUtama.toolTip2, frmUtama, "Stok Pada Dokumen " + lblID.Text + " Sudah Pindah ke Stok Display",
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
                        qry.DeleteData("gudang_masuk", "id = '" + lblID.Text + "'");
                        qry.DeleteData("gudang_masuk_detail", "id = '" + lblID.Text + "'");
                        qry.DeleteData("barang_detail", "idgudangmasuk = '" + lblID.Text + "'");
                        qry.UpdateData("pembelian", "flaggudang = 0", "id = '" + txtIDPembelian.Text.Trim() + "'");

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

        private void Gudang_Load(object sender, EventArgs e)
        {
            tglinput = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (id != "")
                lblID.Text = id;

            frmUtama.lblNamaForm.Text = "- Gudang Masuk";
            UsrAccess();
        }

        private void Gudang_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnCariPembelian_Click(object sender, EventArgs e)
        {
            cls.OpenForm op = new cls.OpenForm(frmUtama);
            op.ListOpen("List", "GudangMasuk-Pembelian", "Pembelian", "", userName);

            txtIDPembelian.Text = idpembelian;
            idpembelian = "";
        }

        private void txtIDPembelian_KeyPress(object sender, KeyPressEventArgs e)
        {
            fs.AllowOnlyBackspace(e);
        }

        private void txtIDPembelian_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                btnCariPembelian_Click(sender, e);
            }
        }

        private void txtIDPembelian_TextChanged(object sender, EventArgs e)
        {
            TampilPembelian(txtIDPembelian.Text);
        }

        private void txtCatatan_Leave(object sender, EventArgs e)
        {
            dgTransaksi.Focus();
        }

        private void dgTransaksi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgTransaksi.Columns["clExpDate"].Index && e.RowIndex >= 0)
            {
                row = dgTransaksi.Rows[e.RowIndex];

                dtExpired.Value = DateTime.Today;
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

        private void dgTransaksi_KeyDown(object sender, KeyEventArgs e)
        {
            if(dgTransaksi.CurrentCell.ColumnIndex == cellexpdate)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    dgTransaksi.CurrentCell.Value = "";
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
                else if (Convert.ToDouble(dgTransaksi.CurrentCell.Value) > (Convert.ToDouble(row.Cells[cellqtybeli].Value) - Convert.ToDouble(row.Cells[cellqtyditerima].Value)))
                {
                    psn.PesanInfo("Qty yang anda input tidak sesuai dengan jumlah pembelian");
                    dgTransaksi.CurrentCell.Value = "0.00";
                }

                dgTransaksi.CurrentCell.Value = fs.FormatNumbCurr(Convert.ToString(dgTransaksi.CurrentCell.Value));
            }
        }

        private void dgTransaksi_Leave(object sender, EventArgs e)
        {
            btnSimpan.Focus();
        }

        private void lblID_TextChanged(object sender, EventArgs e)
        {
            TampilData(lblID.Text);
        }

        private void chkTerimaSemuaBarang_CheckedChanged(object sender, EventArgs e)
        {
            if(chkTerimaSemuaBarang.Checked == true)
            {
                if (dgTransaksi.Rows.Count > 0)
                {
                    for (int i = 0; i < dgTransaksi.Rows.Count; i++)
                    {
                        dgTransaksi.Rows[i].Cells[cellqty].Value = fs.FormatNumbCurr(Convert.ToString(Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellqtybeli].Value) -
                            Convert.ToDouble(dgTransaksi.Rows[i].Cells[cellqtyditerima].Value)));
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

        private void btnHidePanel_Click(object sender, EventArgs e)
        {
            pnlComboBox.Visible = false;
            dgTransaksi.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            row.Cells[cellexpdate].Value = dtExpired.Value.ToString("yyyy-MM-dd");
            pnlComboBox.Visible = false;
            dgTransaksi.Focus();
        }
    }
}
