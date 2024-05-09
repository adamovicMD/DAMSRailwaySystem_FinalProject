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

namespace DamsTrainSystem
{
    public partial class Form5 : Form
    {

        string connectionString = "Data Source=LAB109PC15\\SQLEXPRESS;Initial Catalog=DamsTrainSystem;Integrated Security=True";

        public Form5()
        {
            InitializeComponent();
        }

        public void BindData(DataTable dt)
        {
            dataGridView1.DataSource = dt;
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Get the ticketID from the selected row
                int ticketId = Convert.ToInt32(selectedRow.Cells["ticketID"].Value); // Assuming ticketID is the primary key column

                // Update the database record to set seatAvailability to 'occupied'
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string updateQuery = "UPDATE Tickets SET seatAvailability = 'occupied' WHERE ticketID = @TicketID";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@TicketID", ticketId);
                    updateCommand.ExecuteNonQuery();
                }

                // Manually update the seatAvailability value in the DataGridView
                // Find the index of the "seatAvailability" column in the DataGridView
                int seatAvailabilityColumnIndex = -1;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    if (column.Name == "seatAvailability")
                    {
                        seatAvailabilityColumnIndex = column.Index;
                        break;
                    }
                }

                // Update the seatAvailability cell in the selected row if the column exists
                if (seatAvailabilityColumnIndex != -1)
                {
                    selectedRow.Cells[seatAvailabilityColumnIndex].Value = "occupied";
                }

                // Customize the message box
                DialogResult result = MessageBox.Show("Successfully booked seat. Thanks for booking with DAMS!",
                    "Booking Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                // Change button text and handle exit option
                if (result == DialogResult.OK)
                {
                    // Change button text to "Book another ticket"
                    button1.Text = "Book another ticket";
                    // Change button color to "baby blue"
                    button1.BackColor = System.Drawing.Color.LightSkyBlue;
                }
                else if (result == DialogResult.Cancel)
                {
                    // Show confirmation message before exiting
                    DialogResult confirmExit = MessageBox.Show("Are you sure you want to exit?", "Exit Program",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmExit == DialogResult.Yes)
                    {
                        // Exit the application
                        Application.Exit();
                    }
                }
            }
            else
            {
                // No row is selected, disable button1
                button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
