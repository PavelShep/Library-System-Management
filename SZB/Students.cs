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
    public partial class Students : Form
    {


        int accountId;
        public Students(int accountId)
        {
            InitializeComponent();
            this.accountId = accountId;
        }



        private void cleaner() 
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cleaner();
        }

        int bid;
        int rowid = 0;


        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be updated. Confirm?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string stname = textBox2.Text;
                string stmobilephone = textBox3.Text;
                string stemail = textBox4.Text;

                string sqlCommand = "UPDATE Students SET stName = @stName, stMobilePhone = @stMobilePhone, stEmail = @stEmail WHERE accountId ="+ @accountId+ " AND stid =" + @rowid;

                using (SqlConnection connection = new SqlConnection(@"Data Source=librarymanagesystem.database.windows.net;Initial Catalog=SZB;User ID=adminXYZ;Password=GorzWlkp!;Connect Timeout=10;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlCommand, connection))
                    {
                        command.Parameters.AddWithValue("@stName", stname);
                        command.Parameters.AddWithValue("@stMobilePhone", stmobilephone);
                        command.Parameters.AddWithValue("@stEmail", stemail);
                        command.Parameters.AddWithValue("@accountId", accountId);
                        command.Parameters.AddWithValue("@rowid", rowid);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data updated successfully. Please refresh to see the changes.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No rows were updated.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            SqlConnectionTry tr = new SqlConnectionTry();
            textBox1.Clear();
            cleaner();
            string sqlCommand = "SELECT * FROM Students where accountId =" + accountId;

            SqlConnectionTry connectionTry = new SqlConnectionTry();
            DataSet filteredData = connectionTry.connectionForStudents(sqlCommand, accountId);

            dataGridView1.DataSource = tr.connectionForStudents(sqlCommand , accountId).Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sqlCommand = "DELETE FROM Students WHERE stid=" + rowid + "and accountId =" + accountId;

            if (MessageBox.Show("Dane will be deleted, Confirm?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SqlConnectionTry connectionTry = new SqlConnectionTry();
                DataSet filteredData = connectionTry.connectionForStudents(sqlCommand, accountId);

                MessageBox.Show("Please Refresh to see changes", "Success", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnectionTry tr = new SqlConnectionTry();
            string sqlCommand = "SELECT * FROM Students WHERE stName LIKE '" + textBox1.Text + "%' and accountId =" + accountId;
            
            if (textBox1.Text != "")
            {


                SqlConnectionTry connectionTry = new SqlConnectionTry();
                DataSet filteredData = connectionTry.connectionForStudents(sqlCommand, accountId);

                dataGridView1.DataSource = tr.connectionForStudents(sqlCommand, accountId).Tables[0];
            }
            else
            {
                SqlConnectionTry connectionTry = new SqlConnectionTry();
                DataSet filteredData = connectionTry.connectionForStudents(sqlCommand, accountId);

                dataGridView1.DataSource = tr.connectionForStudents(sqlCommand, accountId).Tables[0];
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshDataGridView()
        {
            string sqlCommand = "SELECT * FROM Students WHERE accountId = " + accountId;

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

        private void Students_Load(object sender, EventArgs e)
        {
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'sZBDataSet1.Students' . Możesz go przenieść lub usunąć.
            this.studentsTableAdapter.Fill(this.sZBDataSet1.Students);
            RefreshDataGridView(); // Call the RefreshDataGridView method to initially populate the DataGridView
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            SqlConnectionTry tr = new SqlConnectionTry();
            

            if ((dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null) && (e.ColumnIndex == 0))
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                cleaner();
                string sqlCommand = "SELECT * FROM Students WHERE stid=" + bid + " and accountId =" + accountId;

                SqlConnectionTry connectionTry = new SqlConnectionTry();
                DataSet filteredData = connectionTry.connectionForStudents(sqlCommand, accountId);
                dataGridView1.DataSource = filteredData.Tables[0];

                if (filteredData.Tables[0].Rows.Count > 0)
                {
                    if (filteredData.Tables[0].Rows[0][0] != DBNull.Value)
                    {
                        rowid = Convert.ToInt32(filteredData.Tables[0].Rows[0][0].ToString());
                    }
                    else
                    {
                        rowid = 0; // Set a default value if the rowid is null
                    }

                    textBox2.Text = filteredData.Tables[0].Rows[0][1].ToString();
                    textBox3.Text = filteredData.Tables[0].Rows[0][2].ToString();
                    textBox4.Text = filteredData.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    MessageBox.Show("No data found for the selected item", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Click on the items in the bid column to change or delete the data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        //private void RefreshDataGridView()
        //{
        //    //SqlConnection con = new SqlConnection(@"Data Source=librarymanagesystem.database.windows.net;Initial Catalog=SZB;User ID=adminXYZ;Password=GorzWlkp!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //    dataGridView1.DataSource = null; // Clear the current data source


        //    string sqlCommand = "SELECT * FROM Students WHERE stid=" + bid + " and accountId =" + accountId;

        //    SqlConnectionTry connectionTry = new SqlConnectionTry();
        //    DataSet filteredData = connectionTry.connectionForStudents(sqlCommand, accountId);

        //    dataGridView1.DataSource = filteredData.Tables[0]; // Reassign the updated data source
        //    dataGridView1.Refresh(); // Refresh the DataGridView display
        //}
        private void dataGridView1_ReadOnlyChanged(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
        }
    }
}
