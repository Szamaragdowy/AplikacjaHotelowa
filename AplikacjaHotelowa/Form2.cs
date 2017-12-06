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
    public partial class Form_Ustaw : Form
    {
        public Adresy ReturnValue;
        public Adresy Adres_kursor;
        int number;
        public Form_Ustaw(int n,Adresy Adres_kursor)
        {
            InitializeComponent();
            this.Adres_kursor = Adres_kursor;
            this.number = n;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            switch (number)
            {
                case 0:
                    this.Text = "Dodaj";
                    button1.Text = "Dodaj";
                    t_Kraj.Text = "Polska";
                    break;
                case 1:
                    this.Text = "Zmien";
                    button1.Text = "Zmien";
                    t_ID.Enabled = false;
                    wczytaj_adres();
                    break;
                case 2:
                    this.Text = "Usun";
                    button1.Text = "Usun";
                    wczytaj_adres();
                    t_ID.Enabled = false;
                    t_Miasto.Enabled = false;
                    t_Ulica.Enabled = false;
                    t_NumerBudynku.Enabled = false;
                    t_Wojewodztwo.Enabled = false;
                    t_Kraj.Enabled = false;
                
                    t_ID.Enabled = false;
                    break;
            }
        }

        private void wczytaj_adres()
        {
            t_ID.Text = Adres_kursor.Id.ToString();
            t_Miasto.Text = Adres_kursor.Miasto;
            t_Ulica.Text = Adres_kursor.Ulica;
            t_NumerBudynku.Text =Adres_kursor.NumerBudynku;
            t_Wojewodztwo.Text = Adres_kursor.Województwo;
            t_Kraj.Text = Adres_kursor.Kraj;
        }

        private void end()
        {
            Adresy New = new Adresy();
            if(this.Text != "Dodaj" )New.Id = Int32.Parse(t_ID.Text);
            New.Miasto = t_Miasto.Text;
            New.NumerBudynku = t_NumerBudynku.Text;
            New.Ulica = t_Ulica.Text;
            New.Województwo = t_Wojewodztwo.Text;
            New.Kraj = t_Kraj.Text;

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
