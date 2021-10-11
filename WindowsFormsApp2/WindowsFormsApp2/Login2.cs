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
    public partial class Login2 : Form
    {
        public Login2()
        {
            InitializeComponent();
        }

        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\cocal\WindowsFormsApp2\WindowsFormsApp2\Login.mdf;Integrated Security=True;Connect Timeout=30";

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login obj2 = new Login();
            obj2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id;
            string fname, lname, cell, username, password;

            try
            {
                id = Convert.ToInt32(idnum.Text);

                fname = name.Text;
                lname = surname.Text;
                cell = phone.Text;
                username = user.Text;
                password = pass.Text;

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string insert_query = "INSERT INTO Login VALUES('" + id + "','" + fname + "', '" + lname + "', '" + cell + "', '" + username + "', '" + password + "')";
                SqlCommand cmd = new SqlCommand(insert_query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data successfully inserted");
                con.Close();

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                idnum.Clear();
                surname.Clear();
                name.Clear();
                phone.Clear();
                user.Clear();
                pass.Clear();

            }

        }
    }
}
