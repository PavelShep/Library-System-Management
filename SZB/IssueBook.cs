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
    public partial class IssueBooks : Form
    {
        int accountId;
        public IssueBooks(int accountId)
        {
            InitializeComponent();
            this.accountId = accountId;
        }

        private void IssueBooks_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string st_id = textBox4.Text;
                string st_name = textBox1.Text;
                string st_phone = textBox2.Text;
                string st_email = textBox3.Text;
                string book_name = comboBox1.Text;
                string book_issue_date = dateTimePicker1.Text;

                SqlConnection con = new SqlConnection(@"Data Source=librarymanagesystem.database.windows.net;Initial Catalog=SZB;User ID=adminXYZ;Password=GorzWlkp!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into IRBook (st_id, std_name, std_phone, std_email, book_name, book_issue_date , accountId) values ('" + st_id + "','" + st_name + "','" + st_phone + "','" + st_email + "','" + book_name + "','" + book_issue_date + "','" +accountId + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Book Issued");
            }
            else
            {
                MessageBox.Show("Incorrect data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                string id_search = textBox4.Text;
                SqlConnection con = new SqlConnection(@"Data Source=librarymanagesystem.database.windows.net;Initial Catalog=SZB;User ID=adminXYZ;Password=GorzWlkp!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                SqlCommand cmd = new SqlCommand("SELECT * FROM Students WHERE stid = '" + id_search + "' and accountId =" + accountId , con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    textBox1.Text = ds.Tables[0].Rows[0][1].ToString();
                    textBox2.Text = ds.Tables[0].Rows[0][2].ToString();
                    textBox3.Text = ds.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    MessageBox.Show("Icorrect id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void IssueBooks_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sZBDataSet3.Books' table. You can move, or remove it, as needed.
            this.booksTableAdapter1.Fill(this.sZBDataSet3.Books);
            // TODO: This line of code loads data into the 'sZBDataSetForDisplayIssueBooks.Books' table. You can move, or remove it, as needed.
            this.booksTableAdapter.Fill(this.sZBDataSetForDisplayIssueBooks.Books);
            // TODO: This line of code loads data into the 'sZBDataSetFor_IssueBooks.IRBook' table. You can move, or remove it, as needed.
            this.iRBookTableAdapter.Fill(this.sZBDataSetFor_IssueBooks.IRBook);

        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Close();

        }
    }
}
