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

namespace WindowsFormsApp2
{
    public partial class Manger : Form
    {
        
        public Manger()
        {
            InitializeComponent();
        }

        
        public DataSet ds;
        public SqlDataAdapter adapter;
        


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\cocal\WindowsFormsApp2\WindowsFormsApp2\Login.mdf;Integrated Security=True;Connect Timeout=30");
            cnn.Open();

            SqlCommand command;
            string sql;
            adapter = new SqlDataAdapter();
            ds = new DataSet();

            sql = @"SELECT * FROM Employees";
            command = new SqlCommand(sql, cnn);

            adapter.SelectCommand = command;
            adapter.Fill(ds, "Employees");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Employees";

            cnn.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\cocal\WindowsFormsApp2\WindowsFormsApp2\Login.mdf;Integrated Security=True;Connect Timeout=30");
            cnn.Open();

            SqlCommand command;
            string sql;
            adapter = new SqlDataAdapter();
            ds = new DataSet();

            sql = @"SELECT * FROM Stock";
            command = new SqlCommand(sql, cnn);

            adapter.SelectCommand = command;
            adapter.Fill(ds, "Stock");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Stock";

            cnn.Close();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\cocal\WindowsFormsApp2\WindowsFormsApp2\Login.mdf;Integrated Security=True;Connect Timeout=30");
            cnn.Open();

            SqlCommand command;
            string sql;
            adapter = new SqlDataAdapter();
            ds = new DataSet();

            sql = @"SELECT * FROM Events";
            command = new SqlCommand(sql, cnn);

            adapter.SelectCommand = command;
            adapter.Fill(ds, "Events");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Events";

            cnn.Close();
        }

        private void Manger_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
