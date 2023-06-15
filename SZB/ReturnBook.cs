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
    public partial class ReturnBook : Form
    {
        int accountId;
        public ReturnBook(int accountId)
        {
            InitializeComponent();
            this.accountId = accountId;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=librarymanagesystem.database.windows.net;Initial Catalog=SZB;User ID=adminXYZ;Password=GorzWlkp!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM IRBook WHERE std_name= '" + textBox1.Text + "' AND book_return_date IS NULL and accountId =" + accountId, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Brak wyników");
            }
            con.Close();
        }


        string bname;
        string bdate;
        string sname;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
 
            panel2.Visible = true;
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                sname = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); // Error there  'Input string was not in a correct format' after click the object
                //bname = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(); // error : 'Index was out of range. Must be non-negative and less than the size of the collection.
                //bdate = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                if (!string.IsNullOrEmpty(sname))
                {
                    bname = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    bdate = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                }

                else
                {
                    // Handle the case where a cell is clicked outside the valid range.
                    // You might want to reset the values or display an error message.
                    sname = "-1";
                    bname = "";
                    bdate = "";
                }
            }
            else
            {
                // Handle the case where a cell is clicked outside the valid range.
                // You might want to reset the values or display an error message.
                sname = "-1";
                bname = "";
                bdate = "";
            }
            textBox3.Text = bname;
            textBox2.Text = bdate;
        }


    

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=librarymanagesystem.database.windows.net;Initial Catalog=SZB;User ID=adminXYZ;Password=GorzWlkp!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE IRBook SET book_return_date = @returnDate", con);
                    cmd.Parameters.AddWithValue("@returnDate", dateTimePicker1.Value);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Aktualizowano pomyślnie.", "Sukces!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Żadne dane nie zostały zaktualizowane.", "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd: " + ex.Message, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }

        }

        private void ReturnBook_Load(object sender, EventArgs e)
        {
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'sZBDataSet4.IRBook' . Możesz go przenieść lub usunąć.
            //this.iRBookTableAdapter.Fill(this.sZBDataSet4.IRBook);
            string x = "SELECT * FROM IRBook WHERE accountId = " + @accountId + " and book_return_date is NULL";
            SqlConnectionTry connectionTry = new SqlConnectionTry();
            DataSet filteredData = connectionTry.FilterBooksByAccountId(accountId , x);
            dataGridView1.DataSource = filteredData.Tables[0];

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_ReadOnlyChanged(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
        }
    }
}
