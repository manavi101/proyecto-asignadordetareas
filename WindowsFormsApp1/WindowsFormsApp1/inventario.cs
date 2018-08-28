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
            this.cambiosinstock();
            this.cambiopocostock();
        }

        void Llenardatagrid()
        {
            MySqlConnection conectar = new MySqlConnection("server =localhost; user id =root; password =1234; persistsecurityinfo = True; port =3306; database =proyecto; SslMode = none;");
            conectar.Open();

            MySqlCommand codigo = new MySqlCommand();
            MySqlConnection conectanos = new MySqlConnection();
            codigo.Connection = conectar;
            codigo.CommandText = ("SELECT id,nombre,stock,precio,distribuidor FROM inventario ;");

            MySqlDataAdapter data = new MySqlDataAdapter(codigo);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;
            conectar.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void cambiosinstock()
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
        private void cambiopocostock()
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
    }
}
