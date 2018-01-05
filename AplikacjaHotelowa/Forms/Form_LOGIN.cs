using AplikacjaHotelowa.MONGO;
using MongoDB.Driver;
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
    public partial class Form_LOGIN : Form
    {
        static SqlConnection con = new SqlConnection(AplikacjaHotelowa.Properties.Settings.Default.AplikacjaHotelowaConnectionString);

        DataClasses1DataContext dc = new DataClasses1DataContext(con);

        public Form_LOGIN()
        {
            InitializeComponent();
            t_haslo.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uprawnienia = "";
            if (t_login.Text =="" || t_haslo.Text == "")
            {
                MessageBox.Show("Prosze wpisać dane logowania");
                return;
            }


            var exist = from a in dc.GetTable<Uzytkownicy>() where a.login_uzytkownika == t_login.Text && a.haslo ==t_haslo.Text select a;
        
                if (exist.Any()) {

                
                foreach (var user in exist)
                {
                    if(user.haslo != t_haslo.Text ||user.login_uzytkownika !=t_login.Text)
                    {
                        MessageBox.Show("Dane logowania są niepoprawne");
                        return;
                    }
                        uprawnienia =  user.Uprawnienia;
                }

                MONGO.MongoDB.Add_action(t_login.Text, "Zalogowano", DateTime.Now);

            Form_Main Main = new Form_Main(t_login.Text,uprawnienia);
            Main.ShowDialog();
            }
            else
            {
                MessageBox.Show("Dane logowania są niepoprawne");
            }
        }

        private void Form_LOGIN_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
