using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace WindowsFormsApp1
{

    public partial class IniciarSesion : Form
    {

        public string Usuario10;

        public IniciarSesion()
        {
            InitializeComponent();

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void IniciarSesion_Load(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {

            Inicio inicio = new Inicio();
            MySqlConnection conectar = new MySqlConnection("server =localhost; user id =root; password =1234; persistsecurityinfo = True; port =3306; database =proyecto; SslMode = none;");
            conectar.Open();

            MySqlCommand codigo = new MySqlCommand();
            MySqlConnection conectanos = new MySqlConnection();
            codigo.Connection = conectar;
            codigo.CommandText = ("select * from login where usuario = '" + usuario.Text + "' and password = '" + Contraseña.Text + "' ");
            MySqlDataReader leer = codigo.ExecuteReader();
            if (leer.Read())
            {
                Usuario10 = usuario.Text;
                inicio.usuario9 = Usuario10;
                inicio.Show();
                this.Hide();
            }
            else
            {
                label3.Visible = true;
            }
            conectar.Close();


        }
    }
}
