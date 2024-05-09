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
using static DamsTrainSystem.authenticate;
using static DamsTrainSystem.authenticate.DamsUsers;

namespace DamsTrainSystem
{
    public partial class Form4 : Form
    {

        string connectionString = "Data Source=LAB109PC15\\SQLEXPRESS;Initial Catalog=DamsTrainSystem;Integrated Security=True";
        private DamsUsers authenticatedUser;
        public Form4()
        {
            InitializeComponent();
        }
        public Form4(DamsUsers user) : this()
        {
            authenticatedUser = user;
            welcome.Text = authenticatedUser.Username;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label5 = new Label();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            welcome = new Label();
            label6 = new Label();
            ((ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(225, 45);
            label1.Name = "label1";
            label1.Size = new Size(196, 25);
            label1.TabIndex = 0;
            label1.Text = "DAMS Railway System";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(252, 192);
            label2.Name = "label2";
            label2.Size = new Size(151, 15);
            label2.TabIndex = 1;
            label2.Text = "Where are you traveling to?";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Sofia", "Plovdiv", "Burgas", "Varna", "Ruse" });
            comboBox1.Location = new Point(51, 257);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(187, 23);
            comboBox1.TabIndex = 2;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Sofia", "Plovdiv", "Burgas", "Varna", "Ruse" });
            comboBox2.Location = new Point(269, 257);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(200, 23);
            comboBox2.TabIndex = 3;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(51, 237);
            label3.Name = "label3";
            label3.Size = new Size(121, 17);
            label3.TabIndex = 4;
            label3.Text = "Starting destination";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(269, 237);
            label4.Name = "label4";
            label4.Size = new Size(103, 17);
            label4.TabIndex = 5;
            label4.Text = "Final Destination";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(153, 326);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(190, 23);
            dateTimePicker1.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(153, 306);
            label5.Name = "label5";
            label5.Size = new Size(113, 17);
            label5.TabIndex = 8;
            label5.Text = "Date of departure";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(189, 380);
            button1.Name = "button1";
            button1.Size = new Size(120, 23);
            button1.TabIndex = 10;
            button1.Text = "Search";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.image;
            pictureBox1.Location = new Point(225, 73);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 116);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // welcome
            // 
            welcome.AutoSize = true;
            welcome.Font = new Font("Century", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            welcome.Location = new Point(39, 130);
            welcome.Name = "welcome";
            welcome.Size = new Size(86, 23);
            welcome.TabIndex = 12;
            welcome.Text = "welcome";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(39, 110);
            label6.Name = "label6";
            label6.Size = new Size(79, 20);
            label6.TabIndex = 13;
            label6.Text = "Welcome,";
            // 
            // Form4
            // 
            BackColor = Color.OldLace;
            ClientSize = new Size(510, 453);
            Controls.Add(label6);
            Controls.Add(welcome);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(dateTimePicker1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form4";
            Text = "Search for a trip";
            ((ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            // Assuming you have established a connection to your SQL database

            // Retrieve the selected values from comboBoxes and dateTimePickers
            string selectedStation1 = comboBox1.SelectedItem.ToString();
            string selectedStation2 = comboBox2.SelectedItem.ToString();

            if (comboBox1.SelectedItem.ToString() == comboBox2.SelectedItem.ToString())
            {
                MessageBox.Show("Please, choose different starting and final destinations.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DateTime departureDate1 = dateTimePicker1.Value;

                // Perform SQL query to retrieve the data based on the selected criteria
                string query = @"
        SELECT depTime.departureTime, dt.trainID, t.ticketID
        FROM DepartsTrain AS dt
        INNER JOIN Arrivals AS arr ON dt.trainID = arr.trainID
        INNER JOIN StationLocation AS depStation ON dt.stationID = depStation.stationID
        INNER JOIN StationLocation AS arrStation ON arr.stationID = arrStation.stationID
        INNER JOIN DepartureTime AS depTime ON dt.departureID = depTime.departureID
        LEFT JOIN Tickets AS t ON dt.trainID = t.trainID
        WHERE depStation.stationLocation = @Station1
        AND arrStation.stationLocation = @Station2;
    ";


                // Execute the query
                // Assume conn is your SqlConnection object
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@station1", selectedStation1);
                cmd.Parameters.AddWithValue("@station2", selectedStation2);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Pass the DataTable to Form5 and populate the DataGridView
                Form5 form5 = new Form5();
                form5.BindData(dt);
                form5.Show();
            }
        }

    }
}
