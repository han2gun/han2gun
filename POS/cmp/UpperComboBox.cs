using System;
using System.Windows.Forms;

namespace POS.cmp
{
    public partial class UpperComboBox : ComboBox
    {
        public UpperComboBox()
        {
            InitializeComponent();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            DroppedDown = false;
            base.OnLostFocus(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper()[0];
            DroppedDown = true;
            base.OnKeyPress(e);
        }
    }
}
