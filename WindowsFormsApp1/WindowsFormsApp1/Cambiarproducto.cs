﻿using System;
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
    public partial class Cambiarproducto : Form
    {
        MySqlConnection conectar = new MySqlConnection("server =localhost; user id =root; password =1234; persistsecurityinfo = True; port =3306; database =proyecto; SslMode = none;");
        MySqlCommand codigo = new MySqlCommand();
        MySqlConnection conectanos = new MySqlConnection();
        public int id1;
        
        public Cambiarproducto(int id)
        {
            id1 = id;
            InitializeComponent();
            llenartextbox();
        }
        void llenartextbox()
        { 
                conectar.Open();
                codigo.Connection = conectar;
                codigo.CommandText = ("select * from proyecto.inventario where id='"+id1.ToString()+"' ;");
                MySqlDataReader leer = codigo.ExecuteReader();
                while (leer.Read())
                {
                    string aux = leer.GetString("producto");
                    textBox1.Text = aux;
                    aux = leer.GetString("stock");
                    textBox2.Text = aux;
                    aux = leer.GetString("precio");
                    textBox3.Text = aux;
                    aux = leer.GetString("distribuidor");
                    textBox4.Text = aux;
                }
                conectar.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                label5.Visible = true;
            }
            else
            {
                conectar.Open();
                codigo.Connection = conectar;
                codigo.CommandText = ("update inventario  set producto='"+textBox1.Text+"', stock='"+textBox2.Text+"', precio='"+textBox3.Text+"', distribuidor='"+textBox4.Text+"' where id='" + id1.ToString() + "' ");
                codigo.ExecuteNonQuery();
                this.Hide();
            }
            
        }
    }
}
