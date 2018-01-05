using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikacjaHotelowa.add_forms
{
    public partial class Form_add_udogodnienia : Form
    {
        public Udogodnienia ReturnValue;
        public Udogodnienia Udogodnienie_kursor;
        int number;

        public Form_add_udogodnienia(int n, Udogodnienia Udogodnienie_kursor)
        {
            InitializeComponent();
            this.Udogodnienie_kursor = Udogodnienie_kursor;
            this.number = n;
        }

        private void Form_add_udogodnienia_Load(object sender, EventArgs e)
        {
            switch (number)
            {
                case 0:
                    this.Text = "Dodaj Udogodnienie";
                    button1.Text = "Dodaj";
                    break;
                case 1:
                    this.Text = "Zmien Udogodnienie";
                    button1.Text = "Zmien";
                    t_ID.Enabled = false;
                    wczytaj_Udogodnienie();
                    break;
                case 2:
                    this.Text = "Usun Udogodnienie";
                    button1.Text = "Usun";
                    wczytaj_Udogodnienie();
                    t_ID.Enabled = false;
                    t_Nazwa.Enabled = false;
                    t_Opis.Enabled = false;
                    break;
            }
        }

        private void wczytaj_Udogodnienie()
        {
            t_ID.Text = Udogodnienie_kursor.Id.ToString();
            t_Nazwa.Text = Udogodnienie_kursor.nazwa;
            t_Opis.Text = Udogodnienie_kursor.opis;
        }

        private void end()
        {
            Udogodnienia New = new Udogodnienia();

            if (t_ID.Text != "")
                New.Id = Int32.Parse(t_ID.Text);
            New.nazwa = t_Nazwa.Text;
            New.opis = t_Opis.Text;

            ReturnValue = New;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            end();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
