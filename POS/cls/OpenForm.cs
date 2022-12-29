using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.cls
{
    class OpenForm
    {
        MenuUtama frmUtama;

        public OpenForm(MenuUtama mnutama)
        {
            frmUtama = mnutama;
        }

        public void CloseAllForm()
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "MenuUtama")
                    Application.OpenForms[i].Close();
            }
        }

        public void PencarianOpen(string namaForm, string formPencarian, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            frm.Pencarian cari = new frm.Pencarian(frmUtama);
            cari.TopLevel = false;
            cari.userName = userName;
            cari.formpencarian = formPencarian;
            frmUtama.pnlUtama.Controls.Add(cari);
            cari.Show();
        }

        public void MasterDataOpen(string namaForm, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            MasterData mnmaster = new MasterData(frmUtama);
            mnmaster.TopLevel = false;
            mnmaster.userName = userName;
            frmUtama.pnlUtama.Controls.Add(mnmaster);
            mnmaster.Show();
        }

        public void TransaksiOpen(string namaForm, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            Transaksi mntransaksi = new Transaksi(frmUtama);
            mntransaksi.TopLevel = false;
            mntransaksi.userName = userName;
            frmUtama.pnlUtama.Controls.Add(mntransaksi);
            mntransaksi.Show();
        }

        public void LaporanOpen(string namaForm, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            Laporan mnlaporan = new Laporan(frmUtama);
            mnlaporan.TopLevel = false;
            mnlaporan.userName = userName;
            frmUtama.pnlUtama.Controls.Add(mnlaporan);
            mnlaporan.Show();
        }

        public void PengaturanOpen(string namaForm, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            Pengaturan mnpengaturan = new Pengaturan(frmUtama);
            mnpengaturan.TopLevel = false;
            mnpengaturan.userName = userName;
            frmUtama.pnlUtama.Controls.Add(mnpengaturan);
            mnpengaturan.Show();
        }

        public void DatabaseOpen(string namaForm, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            Database db = new Database(frmUtama);
            db.TopLevel = false;
            db.userName = userName;
            frmUtama.pnlUtama.Controls.Add(db);
            db.Show();
        }

        public void ListOpen(string namaForm, string formPencarian, string pencarian, string kondisi, string userName)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            frm.List lst = new frm.List();
            lst.userName = userName;
            lst.formpencarian = formPencarian;
            lst.namapencarian = pencarian;
            lst.kondisi = kondisi;

            if (lst.ShowDialog() == DialogResult.OK)
            {
            }
        }

        public void SupplierOpen(Form frms, string namaForm, string idTransaksi, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            frm.Supplier supp = new frm.Supplier(frmUtama);
            supp.TopLevel = false;
            supp.id = idTransaksi;
            supp.userName = userName;
            frmUtama.pnlUtama.Controls.Add(supp);
            supp.Show();
            frms.Close();
        }

        public void KaryawanOpen(Form frms, string namaForm, string idTransaksi, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            frm.Karyawan kry = new frm.Karyawan(frmUtama);
            kry.TopLevel = false;
            kry.id = idTransaksi;
            kry.userName = userName;
            frmUtama.pnlUtama.Controls.Add(kry);
            kry.Show();
            frms.Close();
        }

        public void DataUsahaOpen(Form frms, string namaForm, string idTransaksi, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            frm.DataPerusahaan du = new frm.DataPerusahaan(frmUtama);
            du.TopLevel = false;
            du.id = idTransaksi;
            du.userName = userName;
            frmUtama.pnlUtama.Controls.Add(du);
            du.Show();
            frms.Close();
        }

        public void CustomerOpen(Form frms, string namaForm, string idTransaksi, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            frm.Customer cs = new frm.Customer(frmUtama);
            cs.TopLevel = false;
            cs.id = idTransaksi;
            cs.userName = userName;
            frmUtama.pnlUtama.Controls.Add(cs);
            cs.Show();
            frms.Close();
        }

        public void KategoriOpen(Form frms, string namaForm, string idTransaksi, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            frm.KategoriBarang kg = new frm.KategoriBarang(frmUtama);
            kg.TopLevel = false;
            kg.id = idTransaksi;
            kg.userName = userName;
            frmUtama.pnlUtama.Controls.Add(kg);
            kg.Show();
            frms.Close();
        }

        public void BarangOpen(Form frms, string namaForm, string idTransaksi, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            frm.Barang brg = new frm.Barang(frmUtama);
            brg.TopLevel = false;
            brg.id = idTransaksi;
            brg.userName = userName;
            frmUtama.pnlUtama.Controls.Add(brg);
            brg.Show();
            frms.Close();
        }

        public void PembelianOpen(Form frms, string namaForm, string idTransaksi, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            frm.Pembelian bl = new frm.Pembelian(frmUtama);
            bl.TopLevel = false;
            bl.id = idTransaksi;
            bl.userName = userName;
            frmUtama.pnlUtama.Controls.Add(bl);
            bl.Show();
            frms.Close();
        }

        public void ReturPembelianOpen(Form frms, string namaForm, string idTransaksi, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            frm.ReturPembelian rb = new frm.ReturPembelian(frmUtama);
            rb.TopLevel = false;
            rb.id = idTransaksi;
            rb.userName = userName;
            frmUtama.pnlUtama.Controls.Add(rb);
            rb.Show();
            frms.Close();
        }

        public void HutangOpen(Form frms, string namaForm, string idTransaksi, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            frm.Hutang ht = new frm.Hutang(frmUtama);
            ht.TopLevel = false;
            ht.id = idTransaksi;
            ht.userName = userName;
            frmUtama.pnlUtama.Controls.Add(ht);
            ht.Show();
            frms.Close();
        }

        public void GudangOpen(Form frms, string namaForm, string idTransaksi, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            frm.Gudang gd = new frm.Gudang(frmUtama);
            gd.TopLevel = false;
            gd.id = idTransaksi;
            gd.userName = userName;
            frmUtama.pnlUtama.Controls.Add(gd);
            gd.Show();
            frms.Close();
        }

        public void PindahGudangOpen(Form frms, string namaForm, string idTransaksi, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            frm.GudangPindah gd = new frm.GudangPindah(frmUtama);
            gd.TopLevel = false;
            gd.id = idTransaksi;
            gd.userName = userName;
            frmUtama.pnlUtama.Controls.Add(gd);
            gd.Show();
            frms.Close();
        }

        public void DiskonOpen(Form frms, string namaForm, string idTransaksi, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            frm.Diskon ds = new frm.Diskon(frmUtama);
            ds.TopLevel = false;
            ds.id = idTransaksi;
            ds.userName = userName;
            frmUtama.pnlUtama.Controls.Add(ds);
            ds.Show();
            frms.Close();
        }

        public void KasOpen(Form frms, string namaForm, string idTransaksi, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            frm.Kas ks = new frm.Kas(frmUtama);
            ks.TopLevel = false;
            ks.id = idTransaksi;
            ks.userName = userName;
            frmUtama.pnlUtama.Controls.Add(ks);
            ks.Show();
            frms.Close();
        }

        public void PenjualanOpen(Form frms, string namaForm, string idTransaksi, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            frm.Penjualan pj = new frm.Penjualan(frmUtama);
            pj.TopLevel = false;
            pj.id = idTransaksi;
            pj.userName = userName;
            frmUtama.pnlUtama.Controls.Add(pj);
            pj.Show();
            frms.Close();
        }

        public void ReturPenjualanOpen(Form frms, string namaForm, string idTransaksi, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            frm.ReturPenjualan rj = new frm.ReturPenjualan(frmUtama);
            rj.TopLevel = false;
            rj.id = idTransaksi;
            rj.userName = userName;
            frmUtama.pnlUtama.Controls.Add(rj);
            rj.Show();
            frms.Close();
        }

        public void PiutangOpen(Form frms, string namaForm, string idTransaksi, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            frm.Piutang pt = new frm.Piutang(frmUtama);
            pt.TopLevel = false;
            pt.id = idTransaksi;
            pt.userName = userName;
            frmUtama.pnlUtama.Controls.Add(pt);
            pt.Show();
            frms.Close();
        }

        public void PenyesuaianOpen(Form frms, string namaForm, string idTransaksi, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            frm.Penyesuaian pn = new frm.Penyesuaian(frmUtama);
            pn.TopLevel = false;
            pn.id = idTransaksi;
            pn.userName = userName;
            frmUtama.pnlUtama.Controls.Add(pn);
            pn.Show();
            frms.Close();
        }

        public void UserMgmtOpen(Form frms, string namaForm, string idTransaksi, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            frm.UserMgmt us = new frm.UserMgmt(frmUtama);
            us.TopLevel = false;
            us.id = idTransaksi;
            us.userName = userName;
            frmUtama.pnlUtama.Controls.Add(us);
            us.Show();
            frms.Close();
        }

        public void UbahPassOpen(Form frms, string namaForm, string idTransaksi, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            frm.UbahPassword up = new frm.UbahPassword(frmUtama);
            up.TopLevel = false;
            up.id = idTransaksi;
            up.userName = userName;
            frmUtama.pnlUtama.Controls.Add(up);
            up.Show();
            frms.Close();
        }

        public void BackupOpen(Form frms, string namaForm, string idTransaksi, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            frm.BackupDB bc = new frm.BackupDB(frmUtama);
            bc.TopLevel = false;
            bc.userName = userName;
            frmUtama.pnlUtama.Controls.Add(bc);
            bc.Show();
            frms.Close();
        }

        public void RestoreOpen(Form frms, string namaForm, string idTransaksi, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            frm.RestoreDB rs = new frm.RestoreDB(frmUtama);
            rs.TopLevel = false;
            rs.userName = userName;
            frmUtama.pnlUtama.Controls.Add(rs);
            rs.Show();
            frms.Close();
        }

        public void LaporanFilterOpen(Form frms, string namaForm, string jenisLap, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            rpt.Laporan lp = new rpt.Laporan(frmUtama);
            lp.TopLevel = false;
            lp.userName = userName;
            lp.jenisLaporan = jenisLap;
            frmUtama.pnlUtama.Controls.Add(lp);
            lp.Show();
            frms.Close();
        }

        public void LaporanFilterParamOpen(Form frms, string namaForm, string jenisLap, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            rpt.LaporanParam lp = new rpt.LaporanParam(frmUtama);
            lp.TopLevel = false;
            lp.userName = userName;
            lp.jenisLaporan = jenisLap;
            frmUtama.pnlUtama.Controls.Add(lp);
            lp.Show();
            frms.Close();
        }

        public void LaporanFilterParam2Open(Form frms, string namaForm, string jenisLap, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            rpt.LaporanParam2 lp = new rpt.LaporanParam2(frmUtama);
            lp.TopLevel = false;
            lp.userName = userName;
            lp.jenisLaporan = jenisLap;
            frmUtama.pnlUtama.Controls.Add(lp);
            lp.Show();
            frms.Close();
        }

        public void PreviewCetakOpen(Form frms, string namaForm, string id, string namaSubForm, string userName)
        {
            CloseAllForm();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == namaForm)
                {
                    form.Activate();
                    return;
                }
            }

            frm.PreviewCetakData pv = new frm.PreviewCetakData(frmUtama);
            pv.TopLevel = false;
            pv.namaForm = frms.Name.ToString();
            pv.id = id;
            pv.namaSubForm = namaSubForm;
            pv.userName = userName;
            frmUtama.pnlUtama.Controls.Add(pv);
            pv.Show();
            frms.Close();
        }
    }
}
