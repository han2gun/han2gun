using System;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace POS.cls
{
    class Fungsi
    {
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public string inifilepath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        FileInfo configFile;

        public string ReadConfig(string fileininame, string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(4096);
            int i = GetPrivateProfileString(Section, Key, "", temp, 4096, fileininame);
            return temp.ToString();
        }

        public bool CekConfigFile()
        {
            configFile = new FileInfo(inifilepath + "\\" + "Config.ini");

            if (!configFile.Exists)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void InputNumber(KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        public void BlockChar(KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 96 || ch == 39 || ch == 34 || ch == 124)
            {
                e.Handled = true;
            }
        }

        public void AllowOnlyBackspace(KeyPressEventArgs e)
        {
            if (e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        public void MoveSidePanel(Control btn, Panel pnl)
        {
            pnl.Top = btn.Top;
            pnl.Height = btn.Height;

        }

        public int BoolToInt(bool bl)
        {
            return Convert.ToInt32(bl);
        }

        public bool IntToBool(string str)
        {
            return Convert.ToBoolean(Convert.ToInt32(str));
        }

        public void HeaderDataGridView(DataGridView dg, string[] namaKolom, int kolom)
        {
            for (int i = 0; i < kolom; i++)
            {
                dg.Columns[i].HeaderText = namaKolom[i];
            }
            dg.AutoResizeColumns();
        }

        public void BoldHeaderDataGridView(DataGridView dg)
        {
            dg.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold);
        }

        public void ClearTextBox(Control.ControlCollection cc)
        {
            foreach (Control ctrl in cc)
            {
                TextBox tb = ctrl as TextBox;
                if (tb != null)
                    tb.Text = "";
                else
                    ClearTextBox(ctrl.Controls);
            }
        }

        public void ClearTextBoxArray(TextBox[] txt)
        {
            for (int i = 0; i < txt.Length; i++)
            {
                txt[i].Text = "";
            }
        }

        public void ClearCheckBox(Control.ControlCollection cc)
        {
            foreach (Control ctrl in cc)
            {
                CheckBox tb = ctrl as CheckBox;
                if (tb != null)
                    tb.Checked = false;
                else
                    ClearCheckBox(ctrl.Controls);
            }
        }

        public void FillTextBoxArray(TextBox[] txt, string isi)
        {
            for (int i = 0; i < txt.Length; i++)
            {
                txt[i].Text = isi;
            }
        }

        public void EnaDisTextBoxArray(TextBox[] txt, string isi)
        {
            for (int i = 0; i < txt.Length; i++)
            {
                if(isi == "enable")
                {
                    txt[i].Enabled = true;
                }
                else
                {
                    txt[i].Enabled = false;
                }
            }
        }

        public void FillLabelArray(Label[] lbl, string isi)
        {
            for (int i = 0; i < lbl.Length; i++)
            {
                lbl[i].Text = isi;
            }
        }

        public string FormatNumbCurr(string text)
        {
            return string.Format("{0:#,##0.00}", double.Parse(text));
        }

        public string FNum(string num)
        {
            if (num == "")
            {
                num = "0";
            }
            num = string.Format("{0:0.00}", double.Parse(num));
            num = num.Replace(",", "");
            return num;
        }

        public void ToolTipTransaksi(ToolTip tt, Form frm, string str, int x, int y, string stat)
        {
            if (stat == "info")
            {
                tt.ToolTipIcon = ToolTipIcon.Info;
            }
            else if (stat == "warning")
            {
                tt.ToolTipIcon = ToolTipIcon.Warning;
            }

            tt.Show(str, frm, new Point(x, y), 2 * 1000);
        }

        public void ButtonLocation(Button btn, int x, int y)
        {
            btn.Location = new Point(Screen.PrimaryScreen.Bounds.Width - x, Screen.PrimaryScreen.Bounds.Height - y);
        }

        public void TextLeave(TextBox txt)
        {
            if (txt.Text == "")
            {
                txt.Text = "0.00";
            }
            txt.Text = FormatNumbCurr(txt.Text);
        }
    }
}
