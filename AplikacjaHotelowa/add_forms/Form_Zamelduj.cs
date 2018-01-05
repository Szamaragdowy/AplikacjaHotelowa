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
    public partial class Form_Zamelduj : Form
    {
        String[] rekord;
        public List<string> returnedValue;

        public Form_Zamelduj(String[] rekord)
        {
            this.rekord = rekord;
            List<string> returnedValue = new List<string>();
            InitializeComponent();
        }

        private void Form_Update_Rezerwacja_Load(object sender, EventArgs e)
        {
            t_Imie.Text = rekord[1];
            t_Nazwisko.Text = rekord[2];
            dateTimePicker1.Value = DateTime.Parse(rekord[5]);
            dateTimePicker2.Value = DateTime.Parse(rekord[6]);
            t_hotel.Text = rekord[7];
            t_typ.Text = rekord[8];
            T_numer_pokoju.Text = rekord[9];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == "" ||textBox1.Text == "" || t_telefon.Text == "")
            {
                MessageBox.Show("Prosze wpisać dane osoby zameldowanej");
                return;
            }
             
            for(int i = 0; i < rekord.Length; i++)
            {
                returnedValue.Add(rekord[0]);
            }
            returnedValue.Add(textBox2.Text);
            returnedValue.Add(textBox1.Text);
            returnedValue.Add(t_telefon.Text);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
