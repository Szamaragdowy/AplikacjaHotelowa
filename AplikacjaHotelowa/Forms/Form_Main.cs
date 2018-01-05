using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using AplikacjaHotelowa.add_forms;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace AplikacjaHotelowa
{
    public partial class Form_Main : Form
    {
        SqlConnection con = new SqlConnection(AplikacjaHotelowa.Properties.Settings.Default.AplikacjaHotelowaConnectionString);
        String Login;
        String uprawnienia;


        public Form_Main(String Login, String uprawnienia)
        {
            this.Login = Login;
            this.uprawnienia = uprawnienia;
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView6.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView7.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView8.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(con);

            var selectQuery = from a in dc.GetTable<Adresy>()
                              select a;
            dataGridView1.DataSource = selectQuery;

            var selectQuery2 = from a in dc.GetTable<Budynki>()
                               select new { a.Id, a.Nazwa, a.Opis, a.TelMenadzer, a.TelRecepcja, a.Adresy_Id };
            dataGridView2.DataSource = selectQuery2;


            var selectQuery3 = from a in dc.GetTable<Apartamenty>()
                               select new { a.Id, a.Cena, a.BudynkiId, a.TypId, a.NumerPokoju };
            dataGridView3.DataSource = selectQuery3;

            var selectQuery4 = from a in dc.GetTable<Typ>()
                               select new { a.Id, a.Nazwa, a.Opis };
            dataGridView4.DataSource = selectQuery4;

            var selectQuery5 = from a in dc.GetTable<Udogodnienia>()
                               select new { a.Id, a.nazwa, a.opis };
            dataGridView5.DataSource = selectQuery5;

            var selectQuery6 = from a in dc.GetTable<UdogodnieniaLista>()
                               select new { a.ApartamentyId, a.UdogodnieniaId };
            dataGridView6.DataSource = selectQuery6;

            var selectQuery7 = from a in dc.GetTable<Rezerwacja>()
                               select new { a.Id, a.Osoby.Imie, a.Osoby.Nazwisko, a.StatusRezerwacji, a.StatusZameldowania.Opis, a.TerminPrzybycia, a.TerminOdjazdu, a.Apartamenty.Budynki.Nazwa, Typ = a.Apartamenty.Typ.Nazwa, a.Apartamenty.NumerPokoju };
            dataGridView7.DataSource = selectQuery7;

            if (uprawnienia =="Admin") {
                logi_actual();
            }
            else
            {
                button15.Visible = false;
                button16.Visible = false;
                button17.Visible = false;
                button10.Visible = false;
                button11.Visible = false;
                button12.Visible = false;
                button20.Visible = false;
                button21.Visible = false;
                button22.Visible = false;
                button25.Visible = false;
                button26.Visible = false;
                button27.Visible = false;
                InsertButton.Visible = false;
                UpdateButton.Visible = false;
                DeleteButton.Visible = false;
                groupBox2.Visible = false;
                button5.Visible = false;
                button19.Visible = false;
                button18.Visible = false;
            }
        }

        private void InsertButton_Click_1(object sender, EventArgs e)
        {
            Adresy AdresKursor = Current_Cursor_Address();
            Form_Ustaw form2 = new Form_Ustaw(0, AdresKursor);
            form2.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);
 
            var result = form2.ShowDialog();
            if (result == DialogResult.OK)
            {
                Adresy adres = form2.ReturnValue;

                if (cb_linq.Checked)
                {
                    Insert_Adres_Linq(adres);

                }else if (cb_procedura.Checked)
                {
                    Insert_Adres_Procedure(adres);
                }
                dataGridView1.CurrentCell = dataGridView1[0, dataGridView1.RowCount - 1];     
            }
        }

        private void Insert_Adres_Procedure(Adresy adres)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(con);
            dc.Adresies.InsertOnSubmit(adres);

            try
            {
                dc.InsertAdres(adres.Miasto, adres.Ulica, adres.NumerBudynku, adres.Województwo, adres.Kraj);
                MONGO.MongoDB.Add_action(Login, "Dodano Adres (" + adres.Miasto + " , " + adres.Ulica + " , " + adres.NumerBudynku + " , " + adres.Województwo + " , " + adres.Kraj + ")", DateTime.Now);
            }
            catch (SqlException sqlexception)
            {
                MessageBox.Show("Dodawanie zostało anulowane. \n\n\n" + "\"" + sqlexception.Message + "\""
                    + "\n Class: " + sqlexception.Class + "\n Ssttate: " + sqlexception.State + "\n Number: " + sqlexception.Number);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Dodawania zostało anulowane.\n\n\n" + "\"" + exception.Message + "\"");
            }

            var selectQuery =
              from a in dc.GetTable<Adresy>()
              select a;
            dataGridView1.DataSource = selectQuery;
        }

        private void Insert_Adres_Linq(Adresy adres)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(con);
            dc.Adresies.InsertOnSubmit(adres);

            try
            {
                dc.SubmitChanges();
                MONGO.MongoDB.Add_action(Login, "Dodano Adres (" + adres.Miasto + " , " + adres.Ulica + " , " + adres.NumerBudynku + " , " + adres.Województwo + " , " + adres.Kraj + ")", DateTime.Now);
            }
            catch (SqlException sqlexception)
            {
                MessageBox.Show("Dodawanie zostało anulowane. \n\n\n" + "\"" + sqlexception.Message + "\""
                    + "\n Class: " + sqlexception.Class + "\n State: " + sqlexception.State + "\n Number: " + sqlexception.Number);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Dodawania zostało anulowane.\n\n\n" + "\"" + exception.Message + "\""+ "\n\n\n\n\n\n");
            }
            var selectQuery =
              from a in dc.GetTable<Adresy>()
              select a;
            dataGridView1.DataSource = selectQuery;
        }

        private void UpdateButton_Click_1(object sender, EventArgs e)
        {
            Adresy Adres_Kursor = Current_Cursor_Address();
            int saveRow = dataGridView1.CurrentCell.RowIndex;
            int saveColumn = dataGridView1.CurrentCell.ColumnIndex;
            Form_Ustaw form2 = new Form_Ustaw(1, Adres_Kursor);
            form2.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);
            var result = form2.ShowDialog();

            if (result == DialogResult.OK)
            {
                Adresy returnedAdres = form2.ReturnValue;

                if (cb_linq.Checked)
                {
                    Update_Adres_Linq(returnedAdres, Adres_Kursor.Id);
                }
                else if (cb_procedura.Checked)
                {
                    Update_Adres_Procedure(returnedAdres);
                }
                dataGridView1.CurrentCell = dataGridView1[saveColumn, saveRow];
            }
            
        }

        private void Update_Adres_Procedure(Adresy adres)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(con);
            try
            {
                dc.UpdateAdres(adres.Id, adres.Miasto, adres.Ulica, adres.NumerBudynku, adres.Województwo, adres.Kraj);

                MONGO.MongoDB.Add_action(Login, "Zmieniono adres (" + adres.Miasto + " , " + adres.Ulica + " , " + adres.NumerBudynku + " , " + adres.Województwo + " , " + adres.Kraj + ")", DateTime.Now);
            }
            catch (SqlException sqlexception)
            {
                MessageBox.Show("Usuwanie zostało anulowane. \n\n\n" + "\"" + sqlexception.Message + "\""
                    + "\n Class: " + sqlexception.Class + "\n State: " + sqlexception.State + "\n Number: " + sqlexception.Number);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Zmienianie zostało anulowane proszę spróbować jeszcze raz. \n\n\n" + "\"" + exception.Message + "\"");
            }

            var selectQuery =
             from a in dc.GetTable<Adresy>()
             select a;
            dataGridView1.DataSource = selectQuery;
        }

        private void Update_Adres_Linq(Adresy returnedAdres,int kursor)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(con);

            Adresy adresee = dc.Adresies.FirstOrDefault(adr => adr.Id.Equals(kursor));

            Adresy save = new Adresy();
            save.Miasto = String.Copy(adresee.Miasto);
            save.Ulica = String.Copy(adresee.Ulica);
            save.NumerBudynku = String.Copy(adresee.NumerBudynku);
            save.Województwo = String.Copy(adresee.Województwo);
            save.Kraj = String.Copy(adresee.Kraj);

            adresee.Miasto = returnedAdres.Miasto;
            adresee.Ulica = returnedAdres.Ulica;
            adresee.NumerBudynku = returnedAdres.NumerBudynku;
            adresee.Województwo = returnedAdres.Województwo;
            adresee.Kraj = returnedAdres.Kraj;

            try
            {
                dc.SubmitChanges();
                MONGO.MongoDB.Add_action(Login, "Zmieniono adres (" + returnedAdres.Miasto + " , " + returnedAdres.Ulica + " , " + returnedAdres.NumerBudynku + " , " + returnedAdres.Województwo + " , " + returnedAdres.Kraj + ")", DateTime.Now);
            }
            catch (SqlException sqlexception)
            {
                adresee.Miasto = save.Miasto;
                adresee.Ulica = save.Ulica;
                adresee.NumerBudynku = save.NumerBudynku;
                adresee.Województwo = save.Województwo;
                adresee.Kraj = save.Kraj;
                MessageBox.Show("Zmienianie zostało anulowane. \n\n\n" + "\"" + sqlexception.Message + "\""
                    + "\n Class: " + sqlexception.Class + "\n State: " + sqlexception.State + "\n Number: " + sqlexception.Number);
            }
            catch (Exception exception)
            {
                adresee.Miasto = save.Miasto;
                adresee.Ulica = save.Ulica;
                adresee.NumerBudynku = save.NumerBudynku;
                adresee.Województwo = save.Województwo;
                adresee.Kraj = save.Kraj;
                MessageBox.Show("Zmienianie zostało anulowane. \n\n\n" + "\"" + exception.Message + "\"");
            }


            var selectQuery =
                from a in dc.GetTable<Adresy>()
                select a;
            dataGridView1.DataSource = selectQuery;
        }

        private void DeleteButton_Click_1(object sender, EventArgs e)
        {
            Adresy Adres_Kursor = Current_Cursor_Address();
            Form_Ustaw form2 = new Form_Ustaw(2, Adres_Kursor);
            int saveRow = dataGridView1.CurrentCell.RowIndex;
            int saveColumn = dataGridView1.CurrentCell.ColumnIndex;
            form2.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);
            var result = form2.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (cb_linq.Checked)
                {
                    Delete_Adres_Linq(Adres_Kursor);   
                }
                else if (cb_procedura.Checked)
                {
                    Delete_Adres_Procedure(Adres_Kursor);
                }
                if (saveRow > 1) dataGridView1.CurrentCell = dataGridView1[saveColumn, saveRow - 1];
            }
            
        }

        private void Delete_Adres_Procedure(Adresy Adres_Kursor )
        {
            int id = Adres_Kursor.Id;
            DataClasses1DataContext dc = new DataClasses1DataContext(con);
            try
            {
                dc.DeleteAdres(id);
                MONGO.MongoDB.Add_action(Login, "Usunieto adres (" + Adres_Kursor.Miasto + " , " + Adres_Kursor.Ulica + " , " + Adres_Kursor.NumerBudynku + " , " + Adres_Kursor.Województwo + " , " + Adres_Kursor.Kraj + ")", DateTime.Now);
            }
            catch(SqlException sqlexception)
            {
                MessageBox.Show("Usuwanie zostało anulowane. \n\n\n" + "\"" + sqlexception.Message + "\"" 
                    + "\n Class: "+ sqlexception.Class +"\n State: "+ sqlexception.State + "\n Number: " + sqlexception.Number);
            }
            catch (Exception exception)
            {

                MessageBox.Show("Usuwanie zostało anulowane. \n\n\n" + "\"" + exception.Message + "\"");
            }


            var selectQuery =
             from a in dc.GetTable<Adresy>()
             select a;
            dataGridView1.DataSource = selectQuery;
        }

        private void Delete_Adres_Linq(Adresy Adres_Kursor)
        {
            int id = Adres_Kursor.Id;
            DataClasses1DataContext dc = new DataClasses1DataContext(con);
            Adresy Deleteadresee = dc.Adresies.FirstOrDefault(adr => adr.Id.Equals(id));

            dc.Adresies.DeleteOnSubmit(Deleteadresee);
            try
            {
                dc.SubmitChanges();
                MONGO.MongoDB.Add_action(Login, "Usunieto adres (" + Adres_Kursor.Miasto + " , " + Adres_Kursor.Ulica + " , " + Adres_Kursor.NumerBudynku + " , " + Adres_Kursor.Województwo + " , " + Adres_Kursor.Kraj + ")", DateTime.Now);
            }
            catch (SqlException sqlexception)
            {
                MessageBox.Show("Usuwanie zostało anulowane. \n\n\n" + "\"" + sqlexception.Message + "\""
                    + "\n Class: " + sqlexception.Class + "\n State: " + sqlexception.State + "\n Number: " + sqlexception.Number);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Usuwanie zostało anulowane. \n\n\n" + "\"" + exception.Message + "\"");
            }

    var selectQuery =
              from a in dc.GetTable<Adresy>()
              select a;
            dataGridView1.DataSource = selectQuery;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(con);
            Statystyka form = new Statystyka(from a in dc.GetTable<liczba_adresów_w_miastach>()select a);
            form.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);
            var result = form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(con);
            Statystyka form = new Statystyka(from a in dc.GetTable<liczba_adresów_w_wojewodztwach>() select a);
            form.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);
            var result = form.ShowDialog();
        }

        private void add_budenek_form(object sender, EventArgs e)
        {
            Budynki Budynek_Kursor = Current_Cursor_Budynki();
            Form_add_budynek form_Add_Budynek = new Form_add_budynek(0,Budynek_Kursor);
            form_Add_Budynek.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);

            var result = form_Add_Budynek.ShowDialog();
            if (result == DialogResult.OK)
            {

                 Budynki budynek = form_Add_Budynek.ReturnValue;

                DataClasses1DataContext dc = new DataClasses1DataContext(con);
                dc.Budynkis.InsertOnSubmit(budynek);

                try
                {
                    dc.SubmitChanges();
                    MONGO.MongoDB.Add_action(Login, "Dodano budynek (" + budynek.Nazwa + ")", DateTime.Now);
                    var selectQuery2 = from a in dc.GetTable<Budynki>()
                                       select new { a.Id, a.Nazwa, a.Opis, a.TelMenadzer, a.TelRecepcja, a.Adresy_Id };
                    dataGridView2.DataSource = selectQuery2;

                }
                catch (SqlException sqlexception)
                {
                    MessageBox.Show("Dodawanie zostało anulowane. \n\n\n" + "\"" + sqlexception.Message + "\""
                        + "\n Class: " + sqlexception.Class + "\n State: " + sqlexception.State + "\n Number: " + sqlexception.Number);
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Dodawania zostało anulowane.\n\n\n" + "\"" + exception.Message + "\"" + "\n\n\n\n\n\n");
                }
                dataGridView1.CurrentCell = dataGridView1[0, dataGridView1.RowCount - 1];
            }
        }

        private Adresy  Current_Cursor_Address()
        {
            DataGridViewRow n = dataGridView1.CurrentRow;

            String[] substrings = n.AccessibilityObject.Value.Split(';');

            Adresy Adres_Kursor = new Adresy();
            Adres_Kursor.Id = Int32.Parse(substrings[0]);
            Adres_Kursor.Miasto = substrings[1];
            Adres_Kursor.Ulica = substrings[2];
            Adres_Kursor.NumerBudynku = substrings[3];
            Adres_Kursor.Województwo = substrings[4];
            Adres_Kursor.Kraj = substrings[5];

            return Adres_Kursor;
        }
        private Budynki Current_Cursor_Budynki()
        {
            DataGridViewRow n = dataGridView2.CurrentRow;

            String[] substrings = n.AccessibilityObject.Value.Split(';');

            Budynki Budynek_Kursor = new Budynki();
            Budynek_Kursor.Id = Int32.Parse(substrings[0]);
            Budynek_Kursor.Nazwa = substrings[1];
            Budynek_Kursor.Opis = substrings[2];
            Budynek_Kursor.TelMenadzer = substrings[3];
            Budynek_Kursor.TelRecepcja = substrings[4];
            Budynek_Kursor.Adresy_Id = Int32.Parse(substrings[5]);

            return Budynek_Kursor;
        }

        private void change_budynek_button(object sender, EventArgs e)
        {
            Budynki Budynek_Kursor = Current_Cursor_Budynki();
            int saveRow = dataGridView2.CurrentCell.RowIndex;
            int saveColumn = dataGridView2.CurrentCell.ColumnIndex;
            Form_add_budynek form_Add_Budynek = new Form_add_budynek(1, Budynek_Kursor);
            form_Add_Budynek.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);
            var result = form_Add_Budynek.ShowDialog();

            if (result == DialogResult.OK)
            {
                Budynki budynek = form_Add_Budynek.ReturnValue;
                DataClasses1DataContext dc = new DataClasses1DataContext(con);


                Budynki budynke = dc.Budynkis.FirstOrDefault(adr => adr.Id.Equals(Budynek_Kursor.Id));

                Budynki save = new Budynki();
                save.Nazwa = String.Copy(budynke.Nazwa);
                save.Opis = String.Copy(budynke.Opis);
                save.TelMenadzer = String.Copy(budynke.TelMenadzer);
                save.TelRecepcja = String.Copy(budynke.TelRecepcja);
                save.Adresy_Id = budynke.Adresy_Id;

                budynke.Nazwa = budynek.Nazwa;
                budynke.Opis = budynek.Opis;
                budynke.TelMenadzer = budynek.TelMenadzer;
                budynke.TelRecepcja = budynek.TelRecepcja;
                budynke.Adresy_Id = budynek.Adresy_Id;

                try
                {
                    dc.SubmitChanges();
                    MONGO.MongoDB.Add_action(Login, "Zmieniono Dane Budynku (" + budynek.Nazwa + ")", DateTime.Now);
                    var selectQuery2 = from a in dc.GetTable<Budynki>()
                                       select new { a.Id, a.Nazwa, a.Opis, a.TelMenadzer, a.TelRecepcja, a.Adresy_Id };
                    dataGridView2.DataSource = selectQuery2;
                    dataGridView2.CurrentCell = dataGridView2[saveColumn, saveRow];
                }
                catch (SqlException sqlexception)
                {
                    budynke.Nazwa = save.Nazwa;
                    budynke.Opis = save.Opis;
                    budynke.TelMenadzer = save.TelMenadzer;
                    budynke.TelRecepcja = save.TelRecepcja;
                    budynke.Adresy_Id = save.Adresy_Id;

                    MessageBox.Show("Zmienianie zostało anulowane. \n\n\n" + "\"" + sqlexception.Message + "\""
                        + "\n Class: " + sqlexception.Class + "\n State: " + sqlexception.State + "\n Number: " + sqlexception.Number);
                }
                catch (Exception exception)
                {
                    budynke.Nazwa = save.Nazwa;
                    budynke.Opis = save.Opis;
                    budynke.TelMenadzer = save.TelMenadzer;
                    budynke.TelRecepcja = save.TelRecepcja;
                    budynke.Adresy_Id = save.Adresy_Id;

                    MessageBox.Show("Zmienianie zostało anulowane. \n\n\n" + "\"" + exception.Message + "\"");
                }

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Budynki Budynek_Kursor = Current_Cursor_Budynki();
            Form_add_budynek form_Add_Budynek = new Form_add_budynek(2, Budynek_Kursor);
            int saveRow = dataGridView2.CurrentCell.RowIndex;
            int saveColumn = dataGridView2.CurrentCell.ColumnIndex;
            form_Add_Budynek.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);
            var result = form_Add_Budynek.ShowDialog();
            if (result == DialogResult.OK)
            {

                DataClasses1DataContext dc = new DataClasses1DataContext(con);
                Budynki DeletingBudynek = dc.Budynkis.FirstOrDefault(adr => adr.Id.Equals(Budynek_Kursor.Id));

                dc.Budynkis.DeleteOnSubmit(DeletingBudynek);

                try
                {
                    dc.SubmitChanges();
                    MONGO.MongoDB.Add_action(Login, "Usunieto budynek (" + DeletingBudynek.Nazwa + ")", DateTime.Now);
                    var selectQuery2 = from a in dc.GetTable<Budynki>()
                                       select new { a.Id, a.Nazwa, a.Opis, a.TelMenadzer, a.TelRecepcja, a.Adresy_Id };
                    dataGridView2.DataSource = selectQuery2;
                    if (saveRow > 1) dataGridView2.CurrentCell = dataGridView2[saveColumn, saveRow - 1];
                }
                catch (SqlException sqlexception)
                {
                    MessageBox.Show("Usuwanie zostało anulowane. \n\n\n" + "\"" + sqlexception.Message + "\""
                        + "\n Class: " + sqlexception.Class + "\n State: " + sqlexception.State + "\n Number: " + sqlexception.Number);
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Usuwanie zostało anulowane. \n\n\n" + "\"" + exception.Message + "\"");
                }

                    
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(con);
            Statystyka form = new Statystyka(from a in dc.GetTable<Liczba_Budynków_w_Miastach>() select a);
            form.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);
            var result = form.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(con);
            Statystyka form = new Statystyka(from a in dc.GetTable<Liczba_Budynków_w_Województwach>() select a);
            form.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);
            var result = form.ShowDialog();
        }
        private Typ Current_Cursor_Typ()
        {
            DataGridViewRow n = dataGridView4.CurrentRow;
            Typ Typ_Kursor = new Typ();

            if (n != null) { 
                String[] substrings = n.AccessibilityObject.Value.Split(';');

                Typ_Kursor.Id = Int32.Parse(substrings[0]);
                Typ_Kursor.Nazwa = substrings[1];
                Typ_Kursor.Opis = substrings[2];
            }
            return Typ_Kursor;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Typ Typ_Kursor = Current_Cursor_Typ();
            Form_add_Typ form_add_Typ = new Form_add_Typ(0, Typ_Kursor);
            form_add_Typ.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);

            var result = form_add_Typ.ShowDialog();
            if (result == DialogResult.OK)
            {
                Typ typ = form_add_Typ.ReturnValue;

                DataClasses1DataContext dc = new DataClasses1DataContext(con);
                dc.Typs.InsertOnSubmit(typ);

                try
                {
                    dc.SubmitChanges();
                    MONGO.MongoDB.Add_action(Login, "Dodano nowy Typ Apartamentu (" + typ.Nazwa +" , " + typ.Opis + ")", DateTime.Now);
                    var selectQuery2 = from a in dc.GetTable<Typ>()
                                       select new { a.Id, a.Nazwa, a.Opis};
                    dataGridView4.DataSource = selectQuery2;

                }
                catch (SqlException sqlexception)
                {
                    MessageBox.Show("Dodawanie zostało anulowane. \n\n\n" + "\"" + sqlexception.Message + "\""
                        + "\n Class: " + sqlexception.Class + "\n State: " + sqlexception.State + "\n Number: " + sqlexception.Number);
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Dodawania zostało anulowane.\n\n\n" + "\"" + exception.Message + "\"" + "\n\n\n\n\n\n");
                }
                dataGridView4.CurrentCell = dataGridView4[0, dataGridView4.RowCount - 1];
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Typ Typ_Kursor = Current_Cursor_Typ();
            int saveRow = dataGridView4.CurrentCell.RowIndex;
            int saveColumn = dataGridView4.CurrentCell.ColumnIndex;
            Form_add_Typ form_add_Typ = new Form_add_Typ(1, Typ_Kursor);
            form_add_Typ.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);

            var result = form_add_Typ.ShowDialog();

            if (result == DialogResult.OK)
            {
                Typ typ = form_add_Typ.ReturnValue;

                DataClasses1DataContext dc = new DataClasses1DataContext(con);
                Typ type = dc.Typs.FirstOrDefault(adr => adr.Id.Equals(typ.Id));


                Typ save = new Typ();
                save.Nazwa = String.Copy(type.Nazwa);
                save.Opis = String.Copy(type.Opis);


                type.Nazwa = typ.Nazwa;
                type.Opis = typ.Opis;

                try
                {
                    dc.SubmitChanges();
                    MONGO.MongoDB.Add_action(Login, "Zmieniono Typ Apartamentu (" + typ.Nazwa + " , " + typ.Opis + ")", DateTime.Now);
                    var selectQuery2 = from a in dc.GetTable<Typ>()
                                       select new { a.Id, a.Nazwa, a.Opis };
                    dataGridView4.DataSource = selectQuery2;
                }
                catch (SqlException sqlexception)
                {
                    type.Nazwa = save.Nazwa;
                    type.Opis = save.Opis;

                    MessageBox.Show("Zmienianie zostało anulowane. \n\n\n" + "\"" + sqlexception.Message + "\""
                        + "\n Class: " + sqlexception.Class + "\n State: " + sqlexception.State + "\n Number: " + sqlexception.Number);
                }
                catch (Exception exception)
                {
                    type.Nazwa = save.Nazwa;
                    type.Opis = save.Opis;

                    MessageBox.Show("Zmienianie zostało anulowane. \n\n\n" + "\"" + exception.Message + "\"");
                }
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Typ Typ_Kursor = Current_Cursor_Typ();
            int saveRow = dataGridView4.CurrentCell.RowIndex;
            int saveColumn = dataGridView4.CurrentCell.ColumnIndex;
            Form_add_Typ form_add_Typ = new Form_add_Typ(2, Typ_Kursor);
            form_add_Typ.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);

            var result = form_add_Typ.ShowDialog();

            if (result == DialogResult.OK)
            {
                Typ typ = form_add_Typ.ReturnValue;

                DataClasses1DataContext dc = new DataClasses1DataContext(con);
                Typ Deleting_type = dc.Typs.FirstOrDefault(adr => adr.Id.Equals(typ.Id));

                dc.Typs.DeleteOnSubmit(Deleting_type);

                try
                {
                    dc.SubmitChanges();
                    MONGO.MongoDB.Add_action(Login, "Usunieto Typ Apartamentu (" + typ.Nazwa + " , " + typ.Opis + ")", DateTime.Now);
                    var selectQuery2 = from a in dc.GetTable<Typ>()
                                       select new { a.Id, a.Nazwa, a.Opis};
                    dataGridView4.DataSource = selectQuery2;
                    if (saveRow > 1) dataGridView4.CurrentCell = dataGridView4[saveColumn, saveRow - 1];
                }
                catch (SqlException sqlexception)
                {
                    MessageBox.Show("Usuwanie zostało anulowane. \n\n\n" + "\"" + sqlexception.Message + "\""
                        + "\n Class: " + sqlexception.Class + "\n State: " + sqlexception.State + "\n Number: " + sqlexception.Number);
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Usuwanie zostało anulowane. \n\n\n" + "\"" + exception.Message + "\"");
                }
            }
        }

        private Udogodnienia Current_Cursor_Udogodnienie()
        {
            DataGridViewRow n = dataGridView5.CurrentRow;
            Udogodnienia Udogodnienie_Kursor = new Udogodnienia();

            if (n != null)
            {
                String[] substrings = n.AccessibilityObject.Value.Split(';');

                Udogodnienie_Kursor.Id = Int32.Parse(substrings[0]);
                Udogodnienie_Kursor.nazwa = substrings[1];
                Udogodnienie_Kursor.opis = substrings[2];
            }

            return Udogodnienie_Kursor;
        }
        private void button25_Click(object sender, EventArgs e)
        {
            Udogodnienia Udogodnienie_Kursor = Current_Cursor_Udogodnienie();
            Form_add_udogodnienia form_add_udogodnienia = new Form_add_udogodnienia(0, Udogodnienie_Kursor);
            form_add_udogodnienia.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);

            var result = form_add_udogodnienia.ShowDialog();
            if (result == DialogResult.OK)
            {

                Udogodnienia udogodnienie = form_add_udogodnienia.ReturnValue;

                DataClasses1DataContext dc = new DataClasses1DataContext(con);
                dc.Udogodnienias.InsertOnSubmit(udogodnienie);

                try
                {
                    dc.SubmitChanges();
                    MONGO.MongoDB.Add_action(Login, "Dodano nowe Udogodnienie Apartamentu (" + udogodnienie.nazwa + " , " + udogodnienie.opis + ")", DateTime.Now);
                    var selectQuery2 = from a in dc.GetTable<Udogodnienia>()
                                       select new { a.Id, a.nazwa, a.opis };
                    dataGridView5.DataSource = selectQuery2;

                }
                catch (SqlException sqlexception)
                {
                    MessageBox.Show("Dodawanie zostało anulowane. \n\n\n" + "\"" + sqlexception.Message + "\""
                        + "\n Class: " + sqlexception.Class + "\n State: " + sqlexception.State + "\n Number: " + sqlexception.Number);
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Dodawania zostało anulowane.\n\n\n" + "\"" + exception.Message + "\"" + "\n\n\n\n\n\n");
                }
                dataGridView5.CurrentCell = dataGridView5[0, dataGridView5.RowCount - 1];
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Udogodnienia Udogodnienie_Kursor = Current_Cursor_Udogodnienie();
            int saveRow = dataGridView5.CurrentCell.RowIndex;
            int saveColumn = dataGridView5.CurrentCell.ColumnIndex;
            Form_add_udogodnienia form_add_udogodnienia = new Form_add_udogodnienia(1, Udogodnienie_Kursor);
            form_add_udogodnienia.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);

            var result = form_add_udogodnienia.ShowDialog();
            if (result == DialogResult.OK)
            {

                Udogodnienia udogodnienie = form_add_udogodnienia.ReturnValue;

                DataClasses1DataContext dc = new DataClasses1DataContext(con);

                Udogodnienia udogodnienieeeeeee = dc.Udogodnienias.FirstOrDefault(adr => adr.Id.Equals(udogodnienie.Id));


                Udogodnienia save = new Udogodnienia();
                save.nazwa = String.Copy(udogodnienieeeeeee.nazwa);
                save.opis = String.Copy(udogodnienieeeeeee.opis);


                udogodnienieeeeeee.nazwa = udogodnienie.nazwa;
                udogodnienieeeeeee.opis = udogodnienie.opis;

                try
                {
                    dc.SubmitChanges();
                    MONGO.MongoDB.Add_action(Login, "Zmieniono Udogodnienie Apartamentu (" + udogodnienie.nazwa + " , " + udogodnienie.opis + ")", DateTime.Now);
                    var selectQuery2 = from a in dc.GetTable<Udogodnienia>()
                                       select new { a.Id, a.nazwa, a.opis };
                    dataGridView5.DataSource = selectQuery2;
                    dataGridView5.CurrentCell = dataGridView5[saveColumn, saveRow];
                }
                catch (SqlException sqlexception)
                {
                    udogodnienieeeeeee.nazwa = save.nazwa;
                    udogodnienieeeeeee.opis = save.opis;

                    MessageBox.Show("Zmienianie zostało anulowane. \n\n\n" + "\"" + sqlexception.Message + "\""
                        + "\n Class: " + sqlexception.Class + "\n State: " + sqlexception.State + "\n Number: " + sqlexception.Number);
                }
                catch (Exception exception)
                {
                    udogodnienieeeeeee.nazwa = save.nazwa;
                    udogodnienieeeeeee.opis = save.opis;

                    MessageBox.Show("Zmienianie zostało anulowane. \n\n\n" + "\"" + exception.Message + "\"");
                }
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Udogodnienia Udogodnienie_Kursor = Current_Cursor_Udogodnienie();
            int saveRow = dataGridView5.CurrentCell.RowIndex;
            int saveColumn = dataGridView5.CurrentCell.ColumnIndex;
            Form_add_udogodnienia form_add_udogodnienia = new Form_add_udogodnienia(2, Udogodnienie_Kursor);
            form_add_udogodnienia.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);

            var result = form_add_udogodnienia.ShowDialog();
            if (result == DialogResult.OK)
            {

                Udogodnienia udogodnienie = form_add_udogodnienia.ReturnValue;

                DataClasses1DataContext dc = new DataClasses1DataContext(con);

                Udogodnienia deleting_udogodnienie = dc.Udogodnienias.FirstOrDefault(adr => adr.Id.Equals(udogodnienie.Id));

                dc.Udogodnienias.DeleteOnSubmit(deleting_udogodnienie);

                try
                {
                    dc.SubmitChanges();
                    MONGO.MongoDB.Add_action(Login, "Usunieto Udogodnienie Apartamentu (" + udogodnienie.nazwa + " , " + udogodnienie.opis + ")", DateTime.Now);
                    var selectQuery2 = from a in dc.GetTable<Udogodnienia>()
                                       select new { a.Id, a.nazwa, a.opis };
                    dataGridView5.DataSource = selectQuery2;

                    if (saveRow > 1) dataGridView5.CurrentCell = dataGridView5[saveColumn, saveRow - 1];
                }
                catch (SqlException sqlexception)
                {
                    MessageBox.Show("Usuwanie zostało anulowane. \n\n\n" + "\"" + sqlexception.Message + "\""
                        + "\n Class: " + sqlexception.Class + "\n State: " + sqlexception.State + "\n Number: " + sqlexception.Number);
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Usuwanie zostało anulowane. \n\n\n" + "\"" + exception.Message + "\"");
                }
            }
        }
        public UdogodnieniaLista Current_Cursor_UdogodnienieLista()
        {
            DataGridViewRow n = dataGridView6.CurrentRow;
            UdogodnieniaLista Typ_Kursor = new UdogodnieniaLista();

            if (n != null)
            {
                String[] substrings = n.AccessibilityObject.Value.Split(';');

                Typ_Kursor.ApartamentyId = Int32.Parse(substrings[0]);
                Typ_Kursor.UdogodnieniaId = Int32.Parse(substrings[1]);
            }
            return Typ_Kursor;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UdogodnieniaLista Udogodnienie_Kursor = Current_Cursor_UdogodnienieLista();
            Form_add_lista_udogodnien form = new Form_add_lista_udogodnien(0, Udogodnienie_Kursor);
            form.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);

            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {

                UdogodnieniaLista returnedValue = form.ReturnValue;

                DataClasses1DataContext dc = new DataClasses1DataContext(con);
                dc.UdogodnieniaListas.InsertOnSubmit(returnedValue);

                try
                {
                    dc.SubmitChanges();
                    var selectQuery2 = from a in dc.GetTable<UdogodnieniaLista>()
                                       select new { a.ApartamentyId, a.UdogodnieniaId };
                    dataGridView6.DataSource = selectQuery2;

                }
                catch (SqlException sqlexception)
                {
                    MessageBox.Show("Dodawanie zostało anulowane. \n\n\n" + "\"" + sqlexception.Message + "\""
                        + "\n Class: " + sqlexception.Class + "\n State: " + sqlexception.State + "\n Number: " + sqlexception.Number);
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Dodawania zostało anulowane.\n\n\n" + "\"" + exception.Message + "\"" + "\n\n\n\n\n\n");
                }
                //dataGridView6.CurrentCell = dataGridView6[0, dataGridView6.RowCount - 1];
            }
        }
        public Apartamenty Current_Cursor_Apartament()
        {
            DataGridViewRow n = dataGridView3.CurrentRow;
            Apartamenty Apartamenty_Kursor = new Apartamenty();

            if (n != null)
            {
                String[] substrings = n.AccessibilityObject.Value.Split(';');

                Apartamenty_Kursor.Id = Int32.Parse(substrings[0]);
                Apartamenty_Kursor.BudynkiId = Int32.Parse(substrings[1]);
                Apartamenty_Kursor.TypId = Int32.Parse(substrings[2]);
                Apartamenty_Kursor.NumerPokoju = Int32.Parse(substrings[3]);
                Apartamenty_Kursor.Cena = Decimal.Parse(substrings[4]);
            }
            return Apartamenty_Kursor;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Apartamenty Kursor = Current_Cursor_Apartament();
            Form_add_Apartament form = new Form_add_Apartament(0, Kursor);
            form.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);

            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {

                Apartamenty returnedValue = form.ReturnValue;

                DataClasses1DataContext dc = new DataClasses1DataContext(con);
                dc.Apartamenties.InsertOnSubmit(returnedValue);

                try
                {
                    dc.SubmitChanges();
                    MONGO.MongoDB.Add_action(Login, "Dodano nowy Apartament (Typ: " + returnedValue.Typ + " do Hotelu: " + returnedValue.Budynki.Nazwa + ")", DateTime.Now);
                    var selectQuery2 = from a in dc.GetTable<Apartamenty>()
                                       select new { a.Id, a.Cena, a.BudynkiId, a.TypId, a.NumerPokoju };
                    dataGridView3.DataSource = selectQuery2;

                }
                catch (SqlException sqlexception)
                {
                    MessageBox.Show("Dodawanie zostało anulowane. \n\n\n" + "\"" + sqlexception.Message + "\""
                        + "\n Class: " + sqlexception.Class + "\n State: " + sqlexception.State + "\n Number: " + sqlexception.Number);
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Dodawania zostało anulowane.\n\n\n" + "\"" + exception.Message + "\"" + "\n\n\n\n\n\n");
                }
                dataGridView3.CurrentCell = dataGridView3[0, dataGridView3.RowCount - 1];
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Form_add_Rezerwacja form = new Form_add_Rezerwacja(Login);
            form.SetDesktopLocation(this.Location.X , this.Location.Y);
          

            var is_form_ok = form.ShowDialog();
            if (is_form_ok == DialogResult.OK)
            {
                DataClasses1DataContext dc = new DataClasses1DataContext(con);
                var selectQuery7 = from a in dc.GetTable<Rezerwacja>()
                                   select new { a.Id, a.Osoby.Imie, a.Osoby.Nazwisko, a.StatusRezerwacji, a.StatusZameldowania.Opis, a.TerminPrzybycia, a.TerminOdjazdu, a.Apartamenty.Budynki.Nazwa, Typ = a.Apartamenty.Typ.Nazwa, a.Apartamenty.NumerPokoju };
                dataGridView7.DataSource = selectQuery7;
            }
            
        }

         void logi_actual()
        {
            var connectionString = "mongodb://localhost";
            var mongoClient = new MongoClient(connectionString);

            MongoServer mongoServer = mongoClient.GetServer();
            var database = mongoServer.GetDatabase("new_db");
            var collection = database.GetCollection<MONGO.Akcja>("Akcje").AsQueryable();


            dataGridView8.DataSource = collection.Select(r => new { Login = r.Login, Działanie = r.Działanie, Data = r.Data, ID = r._id, }).ToList();

            mongoServer.Disconnect();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            logi_actual();
        }

        private void TAB_1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tabPage8 && uprawnienia !="Admin")
                e.Cancel = true;
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            MONGO.MongoDB.Add_action(Login, "Wylogowano", DateTime.Now);
        }

        private void button28_Click(object sender, EventArgs e)
        {
           /* DataGridViewRow n = dataGridView7.CurrentRow;

            String[] substrings = n.AccessibilityObject.Value.Split(';');

             var selectQuery7 = from a in dc.GetTable<Rezerwacja>()
                                select new { a.Id, a.Osoby.Imie, a.Osoby.Nazwisko, a.StatusRezerwacji, a.StatusZameldowania.Opis, a.TerminPrzybycia, a.TerminOdjazdu, a.Apartamenty.Budynki.Nazwa, Typ = a.Apartamenty.Typ.Nazwa, a.Apartamenty.NumerPokoju };
            
            Form_Zamelduj form = new Form_Zamelduj(substrings);
           
            form.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);
            var result = form.ShowDialog();
            

            List < String > returned = form.returnedValue;

            String[] wynik = returned.ToArray();

            DataClasses1DataContext dc = new DataClasses1DataContext(con);

            Rezerwacja rezerwacja_zmieniana = dc.Rezerwacjas.FirstOrDefault(adr => adr.ApartamentyId.Equals(wynik[0]));

            */
            

            /*
           

          dc.UpdateAdres(adres.Id, adres.Miasto, adres.Ulica, adres.NumerBudynku, adres.Województwo, adres.Kraj);

                MONGO.MongoDB.Add_action(Login, "Zmieniono adres (" + adres.Miasto + " , " + adres.Ulica + " , " + adres.NumerBudynku + " , " + adres.Województwo + " , " + adres.Kraj + ")", DateTime.Now);
            }
            catch (SqlException sqlexception)
            {
                MessageBox.Show("Usuwanie zostało anulowane. \n\n\n" + "\"" + sqlexception.Message + "\""
                    + "\n Class: " + sqlexception.Class + "\n State: " + sqlexception.State + "\n Number: " + sqlexception.Number);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Zmienianie zostało anulowane proszę spróbować jeszcze raz. \n\n\n" + "\"" + exception.Message + "\"");
            }

            var selectQuery =
             from a in dc.GetTable<Adresy>()
             select a;
            dataGridView1.DataSource = selectQuery;
            */
            /*
            if (result == DialogResult.OK)
            {

            }
            */
        }
    }
}
