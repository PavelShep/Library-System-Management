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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SZB
{
    public partial class AddStudents : Form
    {
        int accountId;
        public AddStudents(int accountId)
        {
            InitializeComponent();
            this.accountId = accountId;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Puste pole niedozwolone.", "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string stname = textBox1.Text;
                string stmobilephone = textBox2.Text;
                string stemail = textBox3.Text;

                SqlConnection con = new SqlConnection(@"Data Source=librarymanagesystem.database.windows.net;Initial Catalog=SZB;User ID=adminXYZ;Password=GorzWlkp!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Students (stName, stMobilePhone, stEmail , accountId) VALUES ('" + stname + "','" + stmobilephone + "', '" + stemail + "','" + accountId + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Dane zapisane.", "Sukces!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
