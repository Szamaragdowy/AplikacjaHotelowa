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
    public partial class Form_add_Typ : Form
    {
        public Typ ReturnValue;
        public Typ Typ_kursor;
        int number;

        public Form_add_Typ(int n, Typ Typ_kursor)
        {
            InitializeComponent();
            this.Typ_kursor = Typ_kursor;
            this.number = n;
        }

        private void Form_add_Typ_Load(object sender, EventArgs e)
        {
            switch (number)
            {
                case 0:
                    this.Text = "Dodaj ";
                    button1.Text = "Dodaj";
                    break;
                case 1:
                    this.Text = "Zmien ";
                    button1.Text = "Zmien";
                    t_ID.Enabled = false;
                    wczytaj_typ();
                    break;
                case 2:
                    this.Text = "Usun ";
                    button1.Text = "Usun";
                    wczytaj_typ();
                    t_ID.Enabled = false;
                    t_Nazwa.Enabled = false; 
                    t_Opis.Enabled = false;

                    break;
            }
        }
        

        private void wczytaj_typ()
        {
            t_ID.Text = Typ_kursor.Id.ToString();
            t_Nazwa.Text = Typ_kursor.Nazwa;
            t_Opis.Text = Typ_kursor.Opis;
        }

        private void end()
        {
            Typ New = new Typ();

            if (t_ID.Text != "")
            New.Id = Int32.Parse(t_ID.Text);
            New.Nazwa = t_Nazwa.Text;
            New.Opis = t_Opis.Text;

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
