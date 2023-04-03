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

namespace SZB
{
    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Dashboard.restrict = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string bname = textBox1.Text;
            string bauthor = textBox2.Text;
            string bpublication = textBox3.Text;
            int price = Convert.ToInt32(textBox4.Text);

            SqlConnection con = new SqlConnection(@"Data Source=librarymanagesystem.database.windows.net;Initial Catalog=SZB;User ID=adminXYZ;Password=GorzWlkp!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Books (bName, bAuthor, bPublication, bQuantity) VALUES ('" + bname + "','" + bauthor+"', '" + bpublication + "','" + price + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Dane zapisane", "sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
