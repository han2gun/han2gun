using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class Database : Form
    {
        cls.Query qry = new cls.Query();

        public string userName;
        MenuUtama frmUtama;

        public Database(MenuUtama mnutama)
        {
            InitializeComponent();
            frmUtama = mnutama;
        }

        #region code
        private void UsrAccess()
        {
            string data = qry.GetData(this, "UsrAccess", userName, 0,
                "backupdb,restoredb", "usrmgmt", "usrname = '" + userName + "'");

            if (data != "")
            {
                string[] filldata = data.Split('|');

                if (filldata.ToString() != "")
                {
                    if (filldata[0] == "1")
                    {
                        btnBackup.Enabled = true;
                    }
                    if (filldata[1] == "1")
                    {
                        btnRestore.Enabled = true;
                    }

                    qry.InsertLogAktivitas("UsrAccess", this, userName, userName);
                }
            }
        }

        private void OpenBackup()
        {
            cls.OpenForm op = new cls.OpenForm(frmUtama);
            op.BackupOpen(this, "Backup", "", userName);
        }

        private void OpenRestore()
        {
            cls.OpenForm op = new cls.OpenForm(frmUtama);
            op.RestoreOpen(this, "Restore", "", userName);
        }
        #endregion

        private void Database_Load(object sender, EventArgs e)
        {
            frmUtama.lblNamaForm.Text = "- Database";
            UsrAccess();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            OpenBackup();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            OpenRestore();
        }
    }
}
