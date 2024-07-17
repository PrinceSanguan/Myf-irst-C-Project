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

namespace SchoolManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new SqlConnection object to connect to the database.
            SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=schooldb;Integrated Security=True");
            // Open the database connection.
            con.Open();

            // Retrieve the values entered by the user in the text boxes.
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Create a new SqlCommand object to execute the SQL query.
            // The query checks if there is a record in the 'logintab' table with the entered username and password.
            SqlCommand cnn = new SqlCommand("select Username,Password from logintab where Username=@username and Password=@password", con);
            cnn.Parameters.AddWithValue("@username", username);
            cnn.Parameters.AddWithValue("@password", password);

            // Create a SqlDataAdapter to execute the query and fill the results into a DataTable.
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Check if any rows were returned, indicating a successful login.
            if (dt.Rows.Count > 0)
            {
                // If login is successful, show the main form.
                Main mn = new Main();
                mn.Show();
            }
            else
            {
                // If login failed, show an error message.
                MessageBox.Show("Invalid login");
            }

            // Close the database connection.
            con.Close();
        }
    }
}
