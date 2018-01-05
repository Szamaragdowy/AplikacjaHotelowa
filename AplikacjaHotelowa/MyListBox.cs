using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikacjaHotelowa
{
    public class MyListBox : System.Windows.Forms.ListBox
    {
        private const int WM_VSCROLL = 277; // Vertical scroll
        private const int SB_ENDSCROLL = 8; // Ends scroll

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_VSCROLL && (m.WParam == (IntPtr)SB_ENDSCROLL))
            {
                this.SelectedIndex = TopIndex;
            }
            base.WndProc(ref m);
        }
    }
}
