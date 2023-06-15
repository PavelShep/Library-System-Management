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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


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

        //int bid;
        //int rowid;
        //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if ((e.ColumnIndex == 0) && (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null))
        //    {
        //        bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

        //        SqlConnection con = new SqlConnection(@"Data Source=librarymanagesystem.database.windows.net;Initial Catalog=SZB;User ID=adminXYZ;Password=GorzWlkp!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //        SqlCommand cmd = new SqlCommand("SELECT * FROM Books WHERE bid=" + bid + " and accountId = " + accountId + "", con);
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataSet ds = new DataSet();
        //        da.Fill(ds);
        //        rowid = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

        //    }
        //    else
        //    {
        //        MessageBox.Show("Click on the items in the bid column to change or delete the data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadBooks()
        {
            //connectionTry.FilterBooksByAccountId(accountId,x );
            //dataGridView1.DataSource = connectionTry.FilterBooksByAccountId(accountId,x).Tables[0];

            string x = "SELECT * FROM Books WHERE accountId = "+@accountId;
            SqlConnectionTry connectionTry = new SqlConnectionTry();
            DataSet filteredData = connectionTry.connectionForStudents(x ,accountId);
            dataGridView1.DataSource = filteredData.Tables[0];
        }

        private void clearBTN_Function(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void Books_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sZBDataSet.Books' table. You can move, or remove it, as needed.
            this.booksTableAdapter.Fill(this.sZBDataSet.Books);

        }

        private void SearchingInLive(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {


                string sqlCommand = "SELECT * FROM Books WHERE bName LIKE '" + textBox1.Text + "%' and accountId = " + @accountId + "";
                SqlConnectionTry connectionTry = new SqlConnectionTry();
                DataSet filteredData = connectionTry.connectionForStudents( sqlCommand , accountId);

                dataGridView1.DataSource = connectionTry.connectionForStudents(sqlCommand, accountId).Tables[0];
            }
            else
            {
                string sqlCommand = "SELECT * FROM Books where accountId =" + @accountId + "";

                SqlConnectionTry connectionTry = new SqlConnectionTry();
                DataSet filteredData = connectionTry.connectionForStudents(sqlCommand, accountId);

                dataGridView1.DataSource = connectionTry.connectionForStudents(sqlCommand, accountId).Tables[0];
            }
        }

        private void dataGridView1_ReadOnlyChanged_1(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
        }
    }
}
