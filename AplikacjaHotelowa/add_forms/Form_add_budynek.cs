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
    public partial class Form_add_budynek : Form
    {
        static SqlConnection con = new SqlConnection(AplikacjaHotelowa.Properties.Settings.Default.AplikacjaHotelowaConnectionString);
        DataClasses1DataContext dc = new DataClasses1DataContext(con);

        public Budynki ReturnValue;
        public Budynki Budynek_kursor;
        int number;

        public Form_add_budynek(int n, Budynki Budynek_kursor)
        {
            InitializeComponent();
            this.Budynek_kursor = Budynek_kursor;
            this.number = n;

            switch (number)
            {
                case 0:
                    this.Text = "Dodaj Budynek";
                    button2.Text = "Dodaj";
                    t_opis.Text = "Przykładowy opis";
                    var selectQuery1 = from a in dc.GetTable<Adresy>()
                                       group a by a.Miasto into g
                                       select g.Key;

                    myListBox1.DataSource = selectQuery1;
                    break;
                case 1:
                    this.Text = "Zmien Budynek";
                    button2.Text = "Zmien";
                    wczytaj_budynek();

                    Adresy adresWybrany1 = (from a in dc.GetTable<Adresy>()
                                           where a.Id == Budynek_kursor.Adresy_Id
                                           select a).First();

                    var select = from a in dc.GetTable<Adresy>()
                                       group a by a.Miasto into g
                                       select g.Key;

                    myListBox1.DataSource = select;

                    break;
                case 2:
                    this.Text = "Usun Budynek";
                    button2.Text = "Usun";
                    wczytaj_budynek();
                    Adresy adresWybrany = (from a in dc.GetTable<Adresy>()
                                           where a.Id == Budynek_kursor.Adresy_Id
                                           select a).First();

                    myListBox1.BeginUpdate();
                    myListBox1.Items.Add(adresWybrany.Miasto);
                    myListBox1.EndUpdate();

                    myListBox2.BeginUpdate();
                    myListBox2.Items.Add(adresWybrany.Ulica);
                    myListBox2.EndUpdate();

                    myListBox3.BeginUpdate();
                    myListBox3.Items.Add(adresWybrany.NumerBudynku);
                    myListBox3.EndUpdate();

                    myListBox4.BeginUpdate();
                    myListBox4.Items.Add(adresWybrany.Województwo);
                    myListBox4.EndUpdate();

                    myListBox5.BeginUpdate();
                    myListBox5.Items.Add(adresWybrany.Kraj);
                    myListBox5.EndUpdate();

                    myListBox6.BeginUpdate();
                    myListBox6.Items.Add(adresWybrany.Id.ToString());
                    myListBox6.EndUpdate();


                    t_adresid.Enabled = false;
                    t_nazwa.Enabled = false;
                    t_opis.Enabled = false;
                    t_telmenadzera.Enabled = false;
                    t_telrecepcja.Enabled = false;
                    myListBox1.Enabled = false;
                    myListBox2.Enabled = false;
                    myListBox3.Enabled = false;
                    myListBox4.Enabled = false;
                    myListBox5.Enabled = false;
                    myListBox6.Enabled = false;
                    button1.Enabled = false;
                    break;
            }

           
        }

        private void wczytaj_budynek()
        {
            t_adresid.Text = Budynek_kursor.Adresy_Id.ToString();
            t_nazwa.Text = Budynek_kursor.Nazwa;
            t_opis.Text = Budynek_kursor.Opis;
            t_telmenadzera.Text = Budynek_kursor.TelMenadzer;
            t_telrecepcja.Text = Budynek_kursor.TelRecepcja;
        }

        private void Form_add_budynek_Load(object sender, EventArgs e)
        {
            this.adresyTableAdapter.Fill(this.aplikacjaHotelowaDataSet.Adresy);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selectQuery = (from a in dc.GetTable<Adresy>()
                               where (a.Miasto == myListBox1.GetItemText(myListBox1.SelectedItem.ToString())) &&
                                     (a.Ulica == myListBox2.GetItemText(myListBox2.SelectedItem.ToString())) &&
                                     (a.NumerBudynku == myListBox3.GetItemText(myListBox3.SelectedItem.ToString())) &&
                                     (a.Województwo == myListBox4.GetItemText(myListBox4.SelectedItem.ToString())) &&
                                     (a.Kraj == myListBox5.GetItemText(myListBox5.SelectedItem.ToString()))
                               group a by a.Id into g
                               select g.Key).First();

            t_adresid.Text = selectQuery.ToString();
        }
        private void end()
        {
            Budynki New = new Budynki();
            New.Nazwa = t_nazwa.Text;
            New.TelMenadzer = t_telmenadzera.Text;
            New.TelRecepcja = t_telrecepcja.Text;
            if (t_adresid.Text != "")
                New.Adresy_Id = Int32.Parse(t_adresid.Text);
            New.Opis = t_opis.Text;

            ReturnValue = New;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            end();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void myListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectQuery = from a in dc.GetTable<Adresy>()
                              where a.Miasto == myListBox1.GetItemText(myListBox1.SelectedItem.ToString())
                              group a by a.Ulica into g
                              select g.Key;

            myListBox2.DataSource = selectQuery;


            var selectQuery2 = from a in dc.GetTable<Adresy>()
                               where a.Miasto == myListBox1.GetItemText(myListBox1.SelectedItem.ToString())
                               group a by a.Kraj into g
                               select g.Key;

            myListBox5.DataSource = selectQuery2;

            var selectQuery3 = from a in dc.GetTable<Adresy>()
                               where a.Miasto == myListBox1.GetItemText(myListBox1.SelectedItem.ToString())
                               group a by a.Województwo into g
                               select g.Key;

            myListBox4.DataSource = selectQuery3;

            var selectQuery6 = from a in dc.GetTable<Adresy>()
                               where (a.Miasto == myListBox1.GetItemText(myListBox1.SelectedItem.ToString())) &&
                                     (a.Ulica == myListBox2.GetItemText(myListBox2.SelectedItem.ToString())) &&
                                     (a.NumerBudynku == myListBox3.GetItemText(myListBox3.SelectedItem.ToString())) &&
                                     (a.Województwo == myListBox4.GetItemText(myListBox4.SelectedItem.ToString())) &&
                                     (a.Kraj == myListBox5.GetItemText(myListBox5.SelectedItem.ToString()))
                               group a by a.Id into g
                               select g.Key;

            myListBox6.DataSource = selectQuery6;
        }

        private void myListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            var selectQuery = from a in dc.GetTable<Adresy>()
                              where (a.Miasto == myListBox1.GetItemText(myListBox1.SelectedItem.ToString())) &&
                              (a.Ulica == myListBox2.GetItemText(myListBox2.SelectedItem.ToString()))
                              select a.NumerBudynku;

            myListBox3.DataSource = selectQuery;

            var selectQuery6 = from a in dc.GetTable<Adresy>()
                               where (a.Miasto == myListBox1.GetItemText(myListBox1.SelectedItem.ToString())) &&
                                     (a.Ulica == myListBox2.GetItemText(myListBox2.SelectedItem.ToString())) &&
                                     (a.NumerBudynku == myListBox3.GetItemText(myListBox3.SelectedItem.ToString())) &&
                                     (a.Województwo == myListBox4.GetItemText(myListBox4.SelectedItem.ToString())) &&
                                     (a.Kraj == myListBox5.GetItemText(myListBox5.SelectedItem.ToString()))
                               group a by a.Id into g
                               select g.Key;

            myListBox6.DataSource = selectQuery6;
        }

        private void myListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectQuery6 = from a in dc.GetTable<Adresy>()
                               where (a.Miasto == myListBox1.GetItemText(myListBox1.SelectedItem.ToString())) &&
                                     (a.Ulica == myListBox2.GetItemText(myListBox2.SelectedItem.ToString())) &&
                                     (a.NumerBudynku == myListBox3.GetItemText(myListBox3.SelectedItem.ToString())) &&
                                     (a.Województwo == myListBox4.GetItemText(myListBox4.SelectedItem.ToString())) &&
                                     (a.Kraj == myListBox5.GetItemText(myListBox5.SelectedItem.ToString()))
                               group a by a.Id into g
                               select g.Key;

            myListBox6.DataSource = selectQuery6;
        }

        private void myListBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectQuery6 = from a in dc.GetTable<Adresy>()
                               where (a.Miasto == myListBox1.GetItemText(myListBox1.SelectedItem.ToString())) &&
                                     (a.Ulica == myListBox2.GetItemText(myListBox2.SelectedItem.ToString())) &&
                                     (a.NumerBudynku == myListBox3.GetItemText(myListBox3.SelectedItem.ToString())) &&
                                     (a.Województwo == myListBox4.GetItemText(myListBox4.SelectedItem.ToString())) &&
                                     (a.Kraj == myListBox5.GetItemText(myListBox5.SelectedItem.ToString()))
                               group a by a.Id into g
                               select g.Key;

            myListBox6.DataSource = selectQuery6;
        }

        private void myListBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectQuery6 = from a in dc.GetTable<Adresy>()
                               where (a.Miasto == myListBox1.GetItemText(myListBox1.SelectedItem.ToString())) &&
                                     (a.Ulica == myListBox2.GetItemText(myListBox2.SelectedItem.ToString())) &&
                                     (a.NumerBudynku == myListBox3.GetItemText(myListBox3.SelectedItem.ToString())) &&
                                     (a.Województwo == myListBox4.GetItemText(myListBox4.SelectedItem.ToString())) &&
                                     (a.Kraj == myListBox5.GetItemText(myListBox5.SelectedItem.ToString()))
                               group a by a.Id into g
                               select g.Key;

            myListBox6.DataSource = selectQuery6;
        }


        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Graphics g = e.Graphics;

            // draw the background color you want
            // mine is set to olive, change it to whatever you want
            g.FillRectangle(new SolidBrush(Color.Gray), e.Bounds);

            // draw the text of the list item, not doing this will only show
            // the background color
            // you will need to get the text of item to display
            g.DrawString(myListBox1.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), new PointF(e.Bounds.X, e.Bounds.Y));

            e.DrawFocusRectangle();
        }

        private void listBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            Graphics g = e.Graphics;
            g.FillRectangle(new SolidBrush(Color.White), e.Bounds);
            ListBox lb = (ListBox)sender;
            g.DrawString(lb.Items[e.Index].ToString(), e.Font, new SolidBrush(Color.Black), new PointF(e.Bounds.X, e.Bounds.Y+3));

            e.DrawFocusRectangle();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            end();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }

}
