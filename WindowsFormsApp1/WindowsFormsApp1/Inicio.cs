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
    public partial class Inicio : Form
    {
        public string usuario9;
        

        public Inicio()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AsignarTareas asignar = new AsignarTareas(usuario9);
            asignar.Show();
        }

            private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Vertareas vertareas = new Vertareas(usuario9);
            vertareas.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            inventario inventario = new inventario();
            inventario.Show();
        }
    }
}
