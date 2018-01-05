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
    public partial class Form_add_Apartament : Form
    {
        public Apartamenty ReturnValue;
        public Apartamenty Apartament_kursor;
        int number;
        public Form_add_Apartament(int n, Apartamenty Apartament_kursor)
        {
            InitializeComponent();
            this.Apartament_kursor = Apartament_kursor;
            this.number = n;
        }

        private void Form_add_Aprtament_Load(object sender, EventArgs e)
        {
            switch (number)
            {
                case 0:
                    this.Text = "Dodaj";
                    button2.Text = "Dodaj";
                    break;
                case 1:
                    this.Text = "Zmien";
                    button2.Text = "Zmien";
                    t_ID.Enabled = false;

                    wczytaj_Apartament();
                    break;
                case 2:
                    this.Text = "Usun";
                    button2.Text = "Usun";
                    wczytaj_Apartament();
                    t_ID.Enabled = false;
                    t_budynekID.Enabled = false;
                    t_Cena.Enabled = false;
                    t_Numerpokoju.Enabled = false;
                    t_typID.Enabled = false;

                    break;
            }
        }

        private void wczytaj_Apartament()
        {
            t_ID.Text = Apartament_kursor.Id.ToString();
            t_Numerpokoju.Text = Apartament_kursor.NumerPokoju.ToString();
            t_Cena.Text = Apartament_kursor.Cena.ToString();
            t_budynekID.Text = Apartament_kursor.BudynkiId.ToString();
            t_typID.Text = Apartament_kursor.TypId.ToString();
        }

        private void end()
        {
            Apartamenty New = new Apartamenty();
            if (this.Text != "Dodaj") New.Id = Int32.Parse(t_ID.Text);
            New.NumerPokoju = Int32.Parse(t_Numerpokoju.Text);
            New.Cena = Decimal.Parse(t_Cena.Text);
            New.BudynkiId = Int32.Parse(t_budynekID.Text);
            New.TypId = Int32.Parse(t_typID.Text);

            ReturnValue = New;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            end();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
