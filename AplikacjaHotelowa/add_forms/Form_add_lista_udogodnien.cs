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
    public partial class Form_add_lista_udogodnien : Form
    {
        public UdogodnieniaLista ReturnValue;
        public UdogodnieniaLista udogodnieniaLista;
        int number;

        public Form_add_lista_udogodnien(int n, UdogodnieniaLista udogodnieniaLista)
        {
            InitializeComponent();
            this.udogodnieniaLista = udogodnieniaLista;
            this.number = n;
        }
        private void Form_add_lista_udogodnien_Load(object sender, EventArgs e)
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
                    t_aID.Enabled = false;
                    t_uID.Enabled = false;
                    wczytaj_Udogodnienie();
                    break;
                case 2:
                    this.Text = "Usun ";
                    button1.Text = "Usun";
                    wczytaj_Udogodnienie();
                    t_aID.Enabled = false;
                    t_uID.Enabled = false;
                    break;
            }
        }
        private void wczytaj_Udogodnienie()
        {
            t_aID.Text = udogodnieniaLista.ApartamentyId.ToString();
            t_uID.Text = udogodnieniaLista.UdogodnieniaId.ToString();
        }

        private void end()
        {
            UdogodnieniaLista New = new UdogodnieniaLista();

            if (t_aID.Text != "")
                New.ApartamentyId = Int32.Parse(t_aID.Text);

            if (t_uID.Text != "")
                New.UdogodnieniaId = Int32.Parse(t_uID.Text);
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
