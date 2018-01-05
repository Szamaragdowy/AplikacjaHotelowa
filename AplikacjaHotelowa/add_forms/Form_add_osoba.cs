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
    public partial class Form_add_osoba : Form
    {
        public Osoby ReturnValue;
        public Osoby kursor;
        int number;

        public Form_add_osoba(int n, Osoby kursor)
        {
            InitializeComponent();
            this.kursor = kursor;
            this.number = n;
        }

        private void Form_add_osoba_Load(object sender, EventArgs e)
        {
            switch (number)
            {
                case 0:
                    this.Text = "Dodaj";
                    button1.Text = "Dodaj";
                    break;
                case 1:
                    this.Text = "Zmien";
                    button1.Text = "Zmien";
                    t_ID.Enabled = false;
                    wczytaj();
                    break;
                case 2:
                    this.Text = "Usun";
                    button1.Text = "Usun";
                    wczytaj();
                    t_ID.Enabled = false;
                    t_Imie.Enabled = false;
                    t_Nazwisko.Enabled = false;
                    t_telefon.Enabled = false;
                    break;
            }
        }

        private void end()
        {
            Osoby New = new Osoby();
            New.Imie = t_Imie.Text;
            New.Nazwisko = t_Nazwisko.Text;
            New.Tel = t_telefon.Text;

            ReturnValue = New;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            end();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
      

        private void wczytaj()
        {
            t_ID.Text = kursor.Id.ToString();
            t_Imie.Text = kursor.Imie;
            t_Nazwisko.Text = kursor.Nazwisko;
            t_telefon.Text = kursor.Tel;
        }


    }
}
