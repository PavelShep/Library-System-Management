using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZB
{
    public partial class Books : Form
    {
        public Books()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            panel2.Visible = false;

            SqlConnection con = new SqlConnection(@"Data Source=librarymanagesystem.database.windows.net;Initial Catalog=SZB;User ID=adminXYZ;Password=GorzWlkp!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Books", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Dane will be updated, Confirm?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string bname = textBox2.Text;
                string bauthor = textBox3.Text;
                string publication = textBox4.Text;
                int bquantity = Convert.ToInt32(textBox5.Text);

                SqlConnection con = new SqlConnection(@"Data Source=librarymanagesystem.database.windows.net;Initial Catalog=SZB;User ID=adminXYZ;Password=GorzWlkp!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                SqlCommand cmd = new SqlCommand("UPDATE Books SET bName = '" + bname + "', bAuthor = '" + bauthor + "', bPublication = '" + publication + "', bQuantity = " + bquantity + " WHERE bid=" + rowid + "", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                MessageBox.Show("Please Refresh to see changes", "Success", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Dane will be deleted, Confirm?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection(@"Data Source=librarymanagesystem.database.windows.net;Initial Catalog=SZB;User ID=adminXYZ;Password=GorzWlkp!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                SqlCommand cmd = new SqlCommand("DELETE FROM Books WHERE bid=" + rowid + "", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                MessageBox.Show("Please Refresh to see changes", "Success", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        int bid;
        int rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null) && (e.ColumnIndex == 0))
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                panel2.Visible = true;
                SqlConnection con = new SqlConnection(@"Data Source=librarymanagesystem.database.windows.net;Initial Catalog=SZB;User ID=adminXYZ;Password=GorzWlkp!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                SqlCommand cmd = new SqlCommand("SELECT * FROM Books WHERE bid=" + bid + "", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                rowid = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

                textBox2.Text = ds.Tables[0].Rows[0][1].ToString();
                textBox3.Text = ds.Tables[0].Rows[0][2].ToString();
                textBox4.Text = ds.Tables[0].Rows[0][3].ToString();
                textBox5.Text = ds.Tables[0].Rows[0][4].ToString();
            }
            else
            {
                MessageBox.Show("Click on the items in the bid column to change or delete the data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
