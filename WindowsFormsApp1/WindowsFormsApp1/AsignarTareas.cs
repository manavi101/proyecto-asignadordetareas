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
  
    public partial class AsignarTareas : Form
    {
        MySqlConnection conectar = new MySqlConnection("server =localhost; user id =root; password =1234; persistsecurityinfo = True; port =3306; database =proyecto; SslMode = none;");
        MySqlCommand codigo = new MySqlCommand();
        MySqlConnection conectanos = new MySqlConnection();
        public static int Auxiliar1;
        public static string Auxiliar;
        public string usuario;
        public int Auxiliar3;
        public int Auxiliar4;
        public bool Asignarcat()
        {
                asignarcat2();
                asignarcat3();
                if(Auxiliar3>=Auxiliar4)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }

        public AsignarTareas(string usuario)
        {
            asignartareasid();
            InitializeComponent();
            llenarcombo1();
            Asignarcat1(usuario);    
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            this.Hide();
        }

        void llenarcombo1()
        {
                conectar.Open();
                codigo.Connection = conectar;
                codigo.CommandText = ("select * from proyecto.sector ;");
                MySqlDataReader leer = codigo.ExecuteReader();
                while (leer.Read())
                {
                    string aux = leer.GetString("sector");
                    comboBox1.Items.Add(aux);
                }
                conectar.Close();
        }
        void llenarcombo2()
        {
                conectar.Open();
                codigo.Connection = conectar;
                codigo.CommandText = ("select *from roles where sector = '"+comboBox1.Text+"'");
                MySqlDataReader leer = codigo.ExecuteReader();
                while (leer.Read())
                {
                    string aux = leer.GetString("rol");
                    comboBox2.Items.Add(aux);
                }
                conectar.Close();
        }
        void llenarcombo3()
        {
                conectar.Open();
                codigo.Connection = conectar;
                codigo.CommandText = ("select *from roles where rol = '" + comboBox2.Text + "'");
                MySqlDataReader leer = codigo.ExecuteReader();
                while (leer.Read())
                {
                    Auxiliar = leer.GetString("idrol");   
                }
                conectar.Close();
        }
        void llenarcombo4()
        {
                conectar.Open();
                codigo.Connection = conectar;
                codigo.CommandText = ("select *from usuario where rol = '" + AsignarTareas.Auxiliar + "'");
                MySqlDataReader leer = codigo.ExecuteReader();
                while (leer.Read())
                {
                    string aux = leer.GetString("empleado");
                    comboBox3.Items.Add(aux);
                }
                comboBox3.Items.Remove("admin");
                conectar.Close();
        }
        void asignartareasid()
        {
                conectar.Open();
                codigo.Connection = conectar;
                codigo.CommandText = ("SELECT * FROM `asignartareas` ORDER BY `id` DESC LIMIT 1");
                MySqlDataReader leer = codigo.ExecuteReader();
                while (leer.Read())
                {
                    Auxiliar1 = leer.GetInt32("id");
                    Auxiliar1++;
                }
                conectar.Close();
        }  
        void Asignarcat1(string usuario)
        {
                conectar.Open();
                codigo.Connection = conectar;
                codigo.CommandText = ("SELECT * FROM `usuario` where empleado='"+usuario+"' ");
                codigo.ExecuteNonQuery();
                MySqlDataReader leer = codigo.ExecuteReader();
                while (leer.Read())
                {
                    Auxiliar3 = leer.GetInt32("rol");  
                }
                conectar.Close();
        }
        void asignarcat2()
        {
                conectar.Open();
                codigo.Connection = conectar;
                codigo.CommandText = ("SELECT * FROM `roles` where idrol='" + Auxiliar3.ToString() + "' ");
                codigo.ExecuteNonQuery();
                MySqlDataReader leer = codigo.ExecuteReader();
                while (leer.Read())
                {
                    Auxiliar4 = leer.GetInt32("categoria");
                }
                conectar.Close();
        }
        void asignarcat3()
        {          
            conectar.Open();
            codigo.Connection = conectar;
            codigo.CommandText = ("SELECT * FROM `roles` where rol='" + comboBox2.Text + "' ");
            codigo.ExecuteNonQuery();
            MySqlDataReader leer = codigo.ExecuteReader();
            while (leer.Read())
            {
                Auxiliar3 = leer.GetInt32("categoria");
            }
            conectar.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                comboBox2.Text = "";
                comboBox3.Text = "";
                llenarcombo2();
            }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            comboBox3.Text = "";
            llenarcombo3();
            llenarcombo4();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" | comboBox2.Text == "" | comboBox3.Text == "" | textBox1.Text == "")
            {
                label7.Text = "Error : Por favor asignar todos los campos";
                label7.Visible = true;
            }
            else
            {
                if (Asignarcat() == true)
                {      
                    conectar.Open();          
                    codigo.Connection = conectar;
                    codigo.CommandText = ("INSERT INTO asignartareas (id,sector,rol,empleado,Fechainicial,Fechamaxima,Tarea) VALUES (" + Auxiliar1 + ",'" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + textBox1.Text + "')");
                    codigo.ExecuteNonQuery();
                    conectar.Close();
                    this.Hide();
                }
                else
                {
                    label7.Text = "Error: Su categoria no permite asignar esta tarea";
                    label7.Visible = true;
                }
            }
        }

    }
}
