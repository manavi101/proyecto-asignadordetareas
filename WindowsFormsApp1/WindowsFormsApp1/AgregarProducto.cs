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
    public partial class AgregarProducto : Form
    {
        MySqlConnection conectar = new MySqlConnection("server =localhost; user id =root; password =1234; persistsecurityinfo = True; port =3306; database =proyecto; SslMode = none;");
        MySqlCommand codigo = new MySqlCommand();
        MySqlConnection conectanos = new MySqlConnection();
        public int Auxiliar;

        public AgregarProducto()
        {
                InitializeComponent();
        }
        
        void Asignarid()
        { 
                conectar.Open();
                codigo.Connection = conectar;
                codigo.CommandText = ("SELECT * FROM `inventario` ORDER BY `id` DESC LIMIT 1");
                MySqlDataReader leer = codigo.ExecuteReader();
                while (leer.Read())
                {
                    Auxiliar = leer.GetInt32("id");
                    Auxiliar++;
                }
                conectar.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                Asignarid();
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" )
            {

            }
                else
                {
                    conectar.Open();
                    codigo.Connection = conectar;
                    codigo.CommandText = ("INSERT INTO inventario (id,producto,stock,precio,distribuidor) VALUES (" + Auxiliar + ",'" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')");
                    codigo.ExecuteNonQuery();
                    conectar.Close();
                    this.Hide();
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
                this.Hide();
        }

    }
}
