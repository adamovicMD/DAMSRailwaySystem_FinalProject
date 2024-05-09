using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static DamsTrainSystem.authenticate;
using static DamsTrainSystem.authenticate.DamsUsers;

namespace DamsTrainSystem
{
    public partial class Form3 : Form
    {
        string connectionString = "Data Source=LAB109PC15\\SQLEXPRESS;Initial Catalog=DamsTrainSystem;Integrated Security=True";

        public Form3()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string password = textBox2.Text;

            // Check if email and password match any records in the DamsUsers table
            if (CredentialsMatch(email, password))
            {
                if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
                {
                    DamsUsers authenticatedUser = DatabaseManager.AuthenticateUser(email, password);
                    if (authenticatedUser != null)
                    {
                        // Display the username on Form4
                        Form4 welcome = new Form4(authenticatedUser);
                        welcome.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Email or password is incorrect. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private bool CredentialsMatch(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM DamsUsers WHERE userEmail = @userEmail AND userPassword = @userPassword";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userEmail", email);
                command.Parameters.AddWithValue("@userPassword", password);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Show Form3
            Form2 form2 = new Form2();
            form2.FormClosed += (s, args) => this.Show(); // Show Form2 when Form3 is closed
            form2.ShowDialog(); // ShowDialog ensures Form2 is not accessible until Form3 is closed
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
