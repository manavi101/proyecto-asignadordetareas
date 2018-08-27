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
using static WindowsFormsApp1.Program;

namespace WindowsFormsApp1
{
    public partial class Vertareas : Form
    {
        public string auxiliar;
        public string usuario8;


        public Vertareas(string usuario7)
        {

            InitializeComponent();
            usuario8 = usuario7;
            averiguarempleado();
            admin();
            llenardatagrid();

        }



        private void Vertareas_Load(object sender, EventArgs e)
        {
        }
        void averiguarempleado()
        {



            MySqlConnection conectar = new MySqlConnection("server =localhost; user id =root; password =1234; persistsecurityinfo = True; port =3306; database =proyecto; SslMode = none;");
            conectar.Open();

            MySqlCommand codigo = new MySqlCommand();
            MySqlConnection conectanos = new MySqlConnection();
            codigo.Connection = conectar;
            codigo.CommandText = ("select * from proyecto.login where usuario='" + usuario8 + "' ;");

            MySqlDataReader leer = codigo.ExecuteReader();
            while (leer.Read())
            {
                auxiliar = leer.GetString("empleado");
            }
            conectar.Close();

        }
        void llenardatagrid()
        {
            if (usuario8 == "admin")
            {
                MySqlConnection conectar = new MySqlConnection("server =localhost; user id =root; password =1234; persistsecurityinfo = True; port =3306; database =proyecto; SslMode = none;");
                conectar.Open();

                MySqlCommand codigo = new MySqlCommand();
                MySqlConnection conectanos = new MySqlConnection();
                codigo.Connection = conectar;
                codigo.CommandText = ("SELECT id,sector,rol,empleado,Fechainicial,FechaMaxima,Tarea FROM asignartareas ;");

                MySqlDataAdapter data = new MySqlDataAdapter(codigo);
                DataTable dt = new DataTable();
                data.Fill(dt);
                dataGridView1.DataSource = dt;
                conectar.Close();
            }
            else
            {
                MySqlConnection conectar = new MySqlConnection("server =localhost; user id =root; password =1234; persistsecurityinfo = True; port =3306; database =proyecto; SslMode = none;");
                conectar.Open();

                MySqlCommand codigo = new MySqlCommand();
                MySqlConnection conectanos = new MySqlConnection();
                codigo.Connection = conectar;
                codigo.CommandText = ("SELECT sector,rol,empleado,Fechainicial,FechaMaxima,Tarea FROM asignartareas where empleado='" + auxiliar + "';");

                MySqlDataAdapter data = new MySqlDataAdapter(codigo);
                DataTable dt = new DataTable();
                data.Fill(dt);
                dataGridView1.DataSource = dt;
                conectar.Close();
            }
        }
        void admin()
        {
            if (usuario8 == "admin")
            {
                dataGridView1.AllowUserToDeleteRows = true;
                button2.Visible = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
                MySqlConnection conectar = new MySqlConnection("server =localhost; user id =root; password =1234; persistsecurityinfo = True; port =3306; database =proyecto; SslMode = none;");
                conectar.Open();

                MySqlCommand codigo = new MySqlCommand();
                MySqlConnection conectanos = new MySqlConnection();
                codigo.Connection = conectar;
                codigo.CommandText = ("delete from asignartareas where id='" + id.ToString() + "'");
                codigo.ExecuteNonQuery();
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
        }
    }
}

