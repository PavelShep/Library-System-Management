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
        int rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnectionTry tr = new SqlConnectionTry();

            if ((dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null) && (e.ColumnIndex == 0))
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                cleaner();
                string sqlCommand = "SELECT * FROM Students WHERE stid=" + bid + " and accountId =" +accountId;
                
                SqlConnectionTry connectionTry = new SqlConnectionTry();
                DataSet filteredData = connectionTry.connectionForStudents(sqlCommand, accountId);
                dataGridView1.DataSource = filteredData.Tables[0];

                

                rowid = Convert.ToInt32(tr.connectionForStudents(sqlCommand, accountId).Tables[0].Rows[0][0].ToString());

                textBox2.Text = tr.connectionForStudents(sqlCommand, accountId).Tables[0].Rows[0][1].ToString();
                textBox3.Text = tr.connectionForStudents(sqlCommand, accountId).Tables[0].Rows[0][2].ToString();
                textBox4.Text = tr.connectionForStudents(sqlCommand, accountId).Tables[0].Rows[0][3].ToString();
            }
            else
            {
                MessageBox.Show("Click on the items in the bid column to change or delete the data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Dane will be updated, Confirm?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string stname = textBox2.Text;
                string stmobilephone = textBox3.Text;
                string stemail = textBox4.Text;
                
                string sqlCommand = "UPDATE Students SET stName = '" + stname + "', stMobilePhone = '" + stmobilephone + "', stEmail = '" + stemail + "', accountId = '" + accountId + "'  WHERE stid=" + rowid + "";
                
                SqlConnectionTry connectionTry = new SqlConnectionTry();
                DataSet filteredData = connectionTry.connectionForStudents(sqlCommand, accountId);
                dataGridView1.DataSource = filteredData.Tables[0];

                MessageBox.Show("Please Refresh to see changes", "Success", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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


    }
}
