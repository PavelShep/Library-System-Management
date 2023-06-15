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
            SqlCommand cmd = new SqlCommand("SELECT * FROM IRBook WHERE st_id = '" + textBox1.Text + "' AND book_return_date IS NULL and accountId =" + accountId, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Invalid ID");
            }
            con.Close();
        }


        string bname;
        string bdate;
        int rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true;
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                rowid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                bname = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                bdate = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            textBox3.Text = bname;
            textBox2.Text = bdate;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=librarymanagesystem.database.windows.net;Initial Catalog=SZB;User ID=adminXYZ;Password=GorzWlkp!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE IRBook SET book_return_date = @returnDate WHERE st_id = @stId AND id = @rowId AND accountId = @accountId", con))
                {
                    cmd.Parameters.AddWithValue("@returnDate", dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@stId", textBox1.Text);
                    cmd.Parameters.AddWithValue("@rowId", rowid);
                    cmd.Parameters.AddWithValue("@accountId", accountId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Update successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No rows were updated.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            MessageBox.Show("Success");
        }
    }
}
