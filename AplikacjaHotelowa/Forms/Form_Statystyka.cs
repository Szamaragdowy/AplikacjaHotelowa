using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikacjaHotelowa
{
    public partial class Statystyka : Form
    {
        public Statystyka(Object data)
        {
            InitializeComponent();
            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;           
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            int Width = 0;
            foreach (DataGridViewColumn x in dataGridView1.Columns)
            {
                Width += x.Width;
            }
            this.Width = Width+36;
        }
    }
}
