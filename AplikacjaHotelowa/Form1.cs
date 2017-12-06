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

namespace AplikacjaHotelowa
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(AplikacjaHotelowa.Properties.Settings.Default.AplikacjaHotelowaConnectionString);


        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(con);

            var selectQuery =
                from a in dc.GetTable<Adresy>()
                select a;
            dataGridView1.DataSource = selectQuery;
        }

        private Adresy Current_Cursor_Address()
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
                    Delete_Adres_Linq(Adres_Kursor.Id);
                }
                else if (cb_procedura.Checked)
                {
                    Delete_Adres_Procedure(Adres_Kursor.Id);
                }
                if (saveRow > 1) dataGridView1.CurrentCell = dataGridView1[saveColumn, saveRow - 1];
            }
            
        }

        private void Delete_Adres_Procedure(int id)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(con);
            try
            {
                dc.DeleteAdres(id);
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

        private void Delete_Adres_Linq(int id)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(con);
            Adresy Deleteadresee = dc.Adresies.FirstOrDefault(adr => adr.Id.Equals(id));

            dc.Adresies.DeleteOnSubmit(Deleteadresee);
            try
            {
                dc.SubmitChanges();
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
            Statystyka form = new Statystyka(from a in dc.GetTable<liczba_budynkow_w_miastach>()select a);
            var result = form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(con);
            Statystyka form = new Statystyka(from a in dc.GetTable<liczba_budynkow_w_wojewodztwach>() select a);
            var result = form.ShowDialog();
        }
    
    }
}
