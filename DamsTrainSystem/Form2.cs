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
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace DamsTrainSystem
{
    public partial class Form2 : Form
    {
        string connectionString = "Data Source=LAB109PC15\\SQLEXPRESS;Initial Catalog=DamsTrainSystem;Integrated Security=True";

        public Form2()
        {
            InitializeComponent();
            textBox3.UseSystemPasswordChar = true;
            textBox4.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                // Check if passwords match
                if (textBox3.Text == textBox4.Text)
                {
                    // Check if it's a valid email address
                    if (ValidEmail(textBox2.Text))
                    {
                        // Check if email already exists
                        if (!EmailExists(textBox2.Text))
                        {
                            // Insert data into SQL table
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                try
                                {
                                    connection.Open();
                                    string query = "INSERT INTO DamsUsers (userName, userEmail, userPassword) VALUES (@userName, @userEmail, @userPassword)";
                                    SqlCommand command = new SqlCommand(query, connection);
                                    command.Parameters.AddWithValue("@userName", textBox1.Text);
                                    command.Parameters.AddWithValue("@userEmail", textBox2.Text);
                                    command.Parameters.AddWithValue("@userPassword", textBox3.Text);
                                    command.ExecuteNonQuery();

                                    MessageBox.Show("Account created successfully. Log in now.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Optionally, you can hide the current form
                                    this.Hide();

                                    // Open Form3 or do any other necessary operation
                                    Form3 form3 = new Form3();
                                    form3.Show();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Account with this email already exists. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid email format. Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Password doesn't match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please, fill in all the boxes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidEmail(string email)
        {
            // Check if the email is in a valid format
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return false; // Return false if the email does not contain '@' or is in an invalid format
            }

            // Check if the email is in a valid format using MailAddress
            try
            {
                MailAddress m = new MailAddress(email); // This will throw an exception if not valid
                return true; // Return true if the email is valid
            }
            catch (FormatException)
            {
                return false; // Return false if the email format is invalid
            }
        }

        private bool EmailExists(string email)
        {
            // Check if the email exists in the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM DamsUsers WHERE userEmail = @userEmail", connection);
                command.Parameters.AddWithValue("@userEmail", email);
                int count = (int)command.ExecuteScalar();
                return count > 0; // Return true if the email exists in the database, otherwise false
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Show Form3
            Form3 form3 = new Form3();
            form3.FormClosed += (s, args) => this.Show(); // Show Form2 when Form3 is closed
            form3.ShowDialog(); // ShowDialog ensures Form2 is not accessible until Form3 is closed
        }
    }
}
