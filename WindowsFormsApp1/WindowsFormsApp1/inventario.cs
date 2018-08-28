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
    public partial class inventario : Form
    {
        public inventario()
        {
            InitializeComponent();
            Llenardatagrid();
            
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Cambiosinstock();
            this.Cambiopocostock();
        }

        void Llenardatagrid()
        {
            MySqlConnection conectar = new MySqlConnection("server =localhost; user id =root; password =1234; persistsecurityinfo = True; port =3306; database =proyecto; SslMode = none;");
            conectar.Open();

            MySqlCommand codigo = new MySqlCommand();
            MySqlConnection conectanos = new MySqlConnection();
            codigo.Connection = conectar;
            codigo.CommandText = ("SELECT id,producto,stock,precio,distribuidor FROM inventario ;");

            MySqlDataAdapter data = new MySqlDataAdapter(codigo);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;
            conectar.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void Cambiosinstock()
        {
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                string abono = Convert.ToString(row.Cells["stock"].Value);
                if (abono=="0")
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }
        private void Cambiopocostock()
        {
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                int abono = Convert.ToInt32(row.Cells["stock"].Value);
                if (abono <= 2 && abono > 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
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
            codigo.CommandText = ("delete from inventario where id='" + id.ToString() + "'");
            codigo.ExecuteNonQuery();
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
            Cambiarproducto cambiarproducto = new Cambiarproducto(id);
            cambiarproducto.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Llenardatagrid();
            Cambiopocostock();
            Cambiosinstock();

        }
    }
}
