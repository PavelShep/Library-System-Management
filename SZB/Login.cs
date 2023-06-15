using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace SZB
{

    public partial class Login : Form
    {
        public int LoginCounter = 0;
        public int PasswordCounter = 0;
        public Login()
        {
            InitializeComponent();
            this.AcceptButton = button2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            network_connection network_Connection = new network_connection();
            if (network_Connection.nConnection() == 1)
            {
                if (textBox1.Text == "SuperUser" && textBox2.Text == "Super5623")
                {
                    SuperUser form = new SuperUser();
                    this.Hide();
                    form.ShowDialog();
                }
                else
                {
                    string sqlCommand = "SELECT * FROM LoginTable WHERE login = '" + textBox1.Text + "' AND password = '" + textBox2.Text + "'";
                    SqlConnectionTry connectionTry = new SqlConnectionTry();
                    DataSet filteredData = connectionTry.loginConnection(sqlCommand);

                    if (filteredData.Tables[0].Rows.Count != 0)
                    {
                        this.Hide();
                        int accountId = Convert.ToInt32(filteredData.Tables[0].Rows[0]["Id"]);
                        Dashboard dsa = new Dashboard(accountId);
                        dsa.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Login" && LoginCounter == 0)
            {
                textBox1.Clear();
                LoginCounter++;
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {

            if (textBox2.Text == "Password" && PasswordCounter == 0)
            {
                textBox2.Clear();
                PasswordCounter++;
            }
        }

        private void checkBoxVisible_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle password visibility based on the checkbox state
            textBox2.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    button2.PerformClick();
                }
            }
        }

        private bool isPasswordVisible = false;
        private Image visibleImage = Properties.Resources.visible; // Replace with your visible image
        private Image hiddenImage = Properties.Resources.hidden; // Replace with your hidden image

        private void checkPSWD(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            pictureBox1.Image = isPasswordVisible ? visibleImage : hiddenImage;
            textBox2.PasswordChar = isPasswordVisible ? '\0' : '*';
        }
    }
}
