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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SZB
{
    public partial class SuperUser : Form
    {
        public SuperUser()
        {
            InitializeComponent();
        }

        int LoginCounter = 0;
        int PasswordCounter = 0;
        int ConfirmCounter = 0;
        private void PasswordBTN_TextChanged(object sender, EventArgs e)
        {
            PasswordBTN.PasswordChar = '*';
        }

        private void LoginBTN_MouseClick(object sender, MouseEventArgs e)
        {
            if (LoginBTN.Text == "Login/Name" && LoginCounter == 0)
            {
                LoginBTN.Clear();
                LoginCounter++;
            }
        }

        private void PasswordBTN_MouseClick(object sender, MouseEventArgs e)
        {
            if (PasswordBTN.Text == "Password" && PasswordCounter == 0)
            {
                PasswordBTN.Clear();
                PasswordCounter++;
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Confirm" && ConfirmCounter == 0)
            {
                textBox1.Clear();
                ConfirmCounter++;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Show the password
                PasswordBTN.PasswordChar = '\0'; // Set the PasswordChar property to '\0' (null character)
            }
            else
            {
                // Hide the password
                PasswordBTN.PasswordChar = '*'; // Set the PasswordChar property to '*'
            }
        }

        private void SuperUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Restart();
            this.Hide();
        }

        private void RegisterBTN_Click(object sender, EventArgs e)
        {
            string sqlCommand = "INSERT INTO LoginTable (login, password) VALUES (@Login, @Password)";
            string connectionString = @"Data Source=librarymanagesystem.database.windows.net;Initial Catalog=SZB;User ID=adminXYZ;Password=GorzWlkp!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlCommand, connection))
                {
                    command.Parameters.AddWithValue("@Login", LoginBTN.Text);
                    command.Parameters.AddWithValue("@Password", PasswordBTN.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            MessageBox.Show("Dane zapisane", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
