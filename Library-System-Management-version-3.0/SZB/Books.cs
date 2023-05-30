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
        private int accountId; // Змінна для збереження ID аккаунту


        public Books(int accountId)
        {
            InitializeComponent();
            this.accountId = accountId;
            LoadBooks();
        }



        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadBooks()
        {
            
            string x = "SELECT * FROM Books WHERE accountId = "+@accountId;
            SqlConnectionTry connectionTry = new SqlConnectionTry();
            //connectionTry.FilterBooksByAccountId(accountId,x );
            //dataGridView1.DataSource = connectionTry.FilterBooksByAccountId(accountId,x).Tables[0];

            DataSet filteredData = connectionTry.FilterBooksByAccountId(accountId, x);
            dataGridView1.DataSource = filteredData.Tables[0];
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void buttonCl_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Puste pole niedozwolone", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string bname = textBox2.Text;
                string bauthor = textBox3.Text;
                string bpublication = textBox5.Text;
                int price = Convert.ToInt32(textBox4.Text);

                SqlConnection con = new SqlConnection(@"Data Source=librarymanagesystem.database.windows.net;Initial Catalog=SZB;User ID=adminXYZ;Password=GorzWlkp!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Books (bName, bAuthor, bPublication, bQuantity , accountId) VALUES ('" + bname + "','" + bauthor + "', '" + bpublication + "'," + price + "," + accountId + ")", con);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Dane zapisane", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
        }


        private void Books_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sZBDataSet.Books' table. You can move, or remove it, as needed.
            this.booksTableAdapter.Fill(this.sZBDataSet.Books);

        }

        private void First_timer_Try_Tick(object sender, EventArgs e)
        {
            network_connection connection = new network_connection();
            connection.nConnection();
        }

    }
}
