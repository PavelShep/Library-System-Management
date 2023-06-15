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
    public partial class EditInfoBooks : Form
    {
        int accountId;
        public EditInfoBooks(int accountId)
        {
            InitializeComponent();
            this.accountId = accountId;
        }


        string bName;
        int rowid;


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null) && (e.ColumnIndex == 0))
            {
                string bName = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                panel2.Visible = true;
                SqlConnection con = new SqlConnection(@"Data Source=librarymanagesystem.database.windows.net;Initial Catalog=SZB;User ID=adminXYZ;Password=GorzWlkp!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                SqlCommand cmd = new SqlCommand("SELECT * FROM Books WHERE bName = @bName AND accountId = @accountId", con);
                cmd.Parameters.AddWithValue("@bName", bName);
                cmd.Parameters.AddWithValue("@accountId", accountId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    rowid = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                    textBox2.Text = ds.Tables[0].Rows[0][1].ToString();
                    textBox3.Text = ds.Tables[0].Rows[0][2].ToString();
                    textBox4.Text = ds.Tables[0].Rows[0][3].ToString();
                    textBox5.Text = ds.Tables[0].Rows[0][4].ToString();
                }
                else
                {
                    MessageBox.Show("No data found for the selected item", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Click on the items in the bName column to change or delete the data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }



        private void deleteBTN (object sender, EventArgs e)
        {
            if (MessageBox.Show("Dane will be deleted, Confirm?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection(@"Data Source=librarymanagesystem.database.windows.net;Initial Catalog=SZB;User ID=adminXYZ;Password=GorzWlkp!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                SqlCommand cmd = new SqlCommand("DELETE FROM Books WHERE bid=" + rowid + "and accountId = "+ accountId + "", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                MessageBox.Show("Please Refresh to see changes", "Success", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void clearFuntion() 
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
        private void clearBTN(object sender, EventArgs e) 
        {
           clearFuntion();
        }

        private void UpdateBTN(object sender, EventArgs e)
        {
            if (MessageBox.Show("Dane will be updated, Confirm?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                 string bname = textBox2.Text;
                string bauthor = textBox3.Text;
                string bpublication = textBox4.Text;
                if (Convert.ToInt32(textBox5.Text) > 100)
                {
                    textBox4.Text = "100";
                }
                else if (Convert.ToInt32(textBox5.Text) < 0)
                {
                    textBox4.Text = "0";
                }
                int quality = Convert.ToInt32(textBox5.Text);

                SqlConnection con = new SqlConnection(@"Data Source=librarymanagesystem.database.windows.net;Initial Catalog=SZB;User ID=adminXYZ;Password=GorzWlkp!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                SqlCommand cmd = new SqlCommand("UPDATE Books SET bName = '" + bname + "', bAuthor = '" + bauthor + "', bPublication = '" + bpublication + "', bQuantity = " + quality + " WHERE bid=" + rowid + " and accountId ="+ accountId + "" , con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                MessageBox.Show("Please Refresh to see changes", "Success", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void addBTN(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Puste pole niedozwolone", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string bname = textBox2.Text;
                string bauthor = textBox3.Text;
                string bpublication = textBox4.Text;
                
                if (int.TryParse(textBox5.Text, out int value))
                {
                    if (value > 100)
                    {
                        textBox5.Text = "100";
                    }
                    else if (value < 0)
                    {
                        textBox5.Text = "0";
                    }

                    int quality = value;              
                } // not mine
                    

                SqlConnection con = new SqlConnection(@"Data Source=librarymanagesystem.database.windows.net;Initial Catalog=SZB;User ID=adminXYZ;Password=GorzWlkp!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Books (bName, bAuthor, bPublication, bQuantity , accountId  ) VALUES ('" + bname + "','" + bauthor + "', '" + bpublication + "'," + value + "," + accountId + ")", con);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Dane zapisane", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearFuntion();
            }
        }

        private void refreshAllBTN(object sender, EventArgs e)
        {

                SqlConnection con = new SqlConnection(@"Data Source=librarymanagesystem.database.windows.net;Initial Catalog=SZB;User ID=adminXYZ;Password=GorzWlkp!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                SqlCommand cmd = new SqlCommand("SELECT * FROM Books where accountId =" + accountId, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshDataGridView()
        {
            string sqlCommand = "SELECT * FROM Books where accountId =" + accountId;

            using (SqlConnection con = new SqlConnection(@"Data Source=librarymanagesystem.database.windows.net;Initial Catalog=SZB;User ID=adminXYZ;Password=GorzWlkp!;Connect Timeout=10;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                using (SqlCommand cmd = new SqlCommand(sqlCommand, con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataSet filteredData = new DataSet();
                        adapter.Fill(filteredData);

                        dataGridView1.DataSource = filteredData.Tables[0]; // Reassign the updated data source
                        dataGridView1.Refresh(); // Refresh the DataGridView display
                    }
                }
            }
        }

        private void EditInfoBooks_Load(object sender, EventArgs e)
        {
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'sZBDataSet2.Books' . Możesz go przenieść lub usunąć.
            this.booksTableAdapter.Fill(this.sZBDataSet2.Books);
            RefreshDataGridView();
        }
    }
}
