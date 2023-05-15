using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZB
{
    
    public partial class Login : Form
    {
        public int LoginCounter = 0;
        public int PasswordCounter = 0;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=librarymanagesystem.database.windows.net;Initial Catalog=SZB;User ID=adminXYZ;Password=GorzWlkp!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand cmd = new SqlCommand("SELECT * FROM LoginTable WHERE login = '" + textBox1.Text + "' AND password = '" + textBox2.Text + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                this.Hide();
                Dashboard dsa = new Dashboard();
                dsa.Show();    
            }
            else
            {
                MessageBox.Show("Nieprawidłowa nazwa użytkownika lub nieprawidłowe hasło", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if(textBox1.Text == "Login" && LoginCounter == 0) 
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }
}
