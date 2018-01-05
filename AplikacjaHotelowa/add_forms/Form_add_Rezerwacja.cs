using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikacjaHotelowa.add_forms
{
    public partial class Form_add_Rezerwacja : Form
    {
        String Login;
        int koszt;
        static SqlConnection con = new SqlConnection(AplikacjaHotelowa.Properties.Settings.Default.AplikacjaHotelowaConnectionString);
        DataClasses1DataContext dc = new DataClasses1DataContext(con);


        public Form_add_Rezerwacja(string login)
        {
            this.Login = login;
            InitializeComponent();
            koszt = 0;
        }

        private void Form_add_Rezerwacja_Load(object sender, EventArgs e)
        {
            //wypisanie wszystkich dostępnych hoteli z bazy w listobx
            
            var selectQuery = from a in dc.GetTable<Budynki>() select a.Nazwa;
            myListBox2.DataSource = selectQuery;

            //ustawienie aktualnej daty

            dateTimePicker1.Value = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day);
            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(3);




            dataGridView2.ColumnCount = 7;
            dataGridView2.ColumnHeadersVisible = true;
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Beige;
            dataGridView2.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            dataGridView2.Columns[0].Name = "ID";
            dataGridView2.Columns[1].Name = "Termin Przybycia";
            dataGridView2.Columns[2].Name = "Termin Odjazdu";
            dataGridView2.Columns[3].Name = "Całkowity koszt";
            dataGridView2.Columns[4].Name = "Typ";
            dataGridView2.Columns[5].Name = "Cena za dobe";
            dataGridView2.Columns[6].Name = "Opis";
            
        }

        public void end()
        {
            int Osoba_ID;
            if (button3.Enabled != false)
            {
                MessageBox.Show("Nie zatwierdzono danych Osoby Rezerującej");
            }
            else
            { 
                try
                {
                    

                    Osoba_ID = dc.Dodaj_Osobe_returnID(t_Imie.Text, t_Nazwisko.Text, t_telefon.Text);

                    int ApartamentID ;
                    DateTime przyjazd;
                    DateTime odjazd;
                    for (int j = 0; j < dataGridView2.Rows.Count; j++)
                    {
                        ApartamentID = Int32.Parse(dataGridView2.Rows[j].Cells[0].Value.ToString());
                        przyjazd = (DateTime)dataGridView2.Rows[j].Cells[1].Value;
                        odjazd = (DateTime)dataGridView2.Rows[j].Cells[2].Value;

                       // dc.Dodaj_Rezerwacje(ApartamentID,Osoba_ID,przyjazd,odjazd);

                        dc.DodajRezerwacjeIOsobe(Osoba_ID, ApartamentID, przyjazd, odjazd);

                        MONGO.MongoDB.Add_action(Login, "Dodano Rezerwacje (" + t_Imie.Text +" , " + t_Nazwisko.Text + " , " +ApartamentID +" , " + przyjazd.ToString() + " , " + odjazd.ToString() + ")", DateTime.Now);

                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show("Dodawania zostało anulowane.\n\n\n" + "\"" + e.Message + "\"" + "\n\n\n\n\n\n");
                }
            }
        }
     
        private void button2_Click(object sender, EventArgs e)
        {
            end();
           /* */
        }


        private void myListBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            /* var selectQuery2 = from a in dc.GetTable<Apartamenty>()
                                join b in dc.GetTable<Budynki>() on a.BudynkiId equals b.Id
                                join c in dc.GetTable<Typ>() on a.TypId equals c.Id
                                where b.Nazwa == myListBox2.Items[myListBox2.SelectedIndex].ToString()
                                select new { a.Id, Typ = c.Nazwa, a.Cena, c.Opis};

            dataGridView1.DataSource = selectQuery2;*/
            actual_date();
        }

        public void actual_date()
        {
            dataGridView1.DataSource = dc.DostepneWDanymTerminieWBudynku(myListBox2.Items[myListBox2.SelectedIndex].ToString(), dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (t_Imie.Text == "" || t_Nazwisko.Text =="" ||t_telefon.Text == "" )
            {
                MessageBox.Show("Nie wpisano wszystkich danych");
                return;
            }else if(!t_telefon.Text.All(char.IsDigit)){
                MessageBox.Show("W numerze mogą być tylko liczby");
                return;
            }
            t_Imie.Enabled = false;
            t_Nazwisko.Enabled = false;
            t_telefon.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            t_Imie.Enabled = true;
            t_Nazwisko.Enabled = true;
            t_telefon.Enabled = true;
            button3.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dateTimePicker2.Value.Subtract(dateTimePicker1.Value).Days == 0)
            {
                MessageBox.Show("Nie można zarezerwować Apartamentu na 0 Dni");
                return;
            }

            bool fraga = false;

            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                for (int j = 0  ; j < dataGridView2.Rows.Count; j++)
                {
                    if ((int)dataGridView2.Rows[j].Cells[0].Value == (int)dataGridView1.SelectedRows[i].Cells[0].Value)
                    {
                        DateTime przyjazd = (DateTime)dataGridView2.Rows[j].Cells[1].Value;
                        DateTime odjazd = (DateTime)dataGridView2.Rows[j].Cells[2].Value;

                        if (dateTimePicker1.Value < odjazd &&odjazd <=dateTimePicker2.Value 
                            || dateTimePicker1.Value <= przyjazd && przyjazd < dateTimePicker2.Value
                            || dateTimePicker1.Value > przyjazd && odjazd > dateTimePicker2.Value)
                        {
                            MessageBox.Show("Ta data koliduje z apartamentem dodanym do listy");
                            fraga = true;
                            break;
                        }
                        
                    }
                }
                if (fraga)
                {
                    continue;
                }

                int index = dataGridView2.Rows.Add();
                dataGridView2.Rows[index].Cells[0].Value = dataGridView1.SelectedRows[i].Cells[0].Value;
                dataGridView2.Rows[index].Cells[1].Value = dateTimePicker1.Value;
                dataGridView2.Rows[index].Cells[2].Value = dateTimePicker2.Value;
                dataGridView2.Rows[index].Cells[3].Value = dateTimePicker2.Value.Subtract(dateTimePicker1.Value).Days* Int32.Parse(dataGridView1.SelectedRows[i].Cells[2].Value.ToString());
                dataGridView2.Rows[index].Cells[4].Value = String.Copy(dataGridView1.SelectedRows[i].Cells[1].Value.ToString());
                dataGridView2.Rows[index].Cells[5].Value = String.Copy(dataGridView1.SelectedRows[i].Cells[2].Value.ToString());
                dataGridView2.Rows[index].Cells[6].Value = String.Copy(dataGridView1.SelectedRows[i].Cells[3].Value.ToString());

                koszt += (int)dataGridView2.Rows[index].Cells[3].Value;

                label14.Text = koszt + "  ZŁ";
            }


        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            actual_date();
            dateTimePicker2.MinDate = dateTimePicker1.Value;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            actual_date();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow item in this.dataGridView2.SelectedRows)
             {
                dataGridView2.Rows.RemoveAt(item.Index);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

    }
}
