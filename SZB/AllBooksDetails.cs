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
    public partial class AllBooksDetails : Form
    {
        int accountId;
        public AllBooksDetails(int accountId)
        {
            InitializeComponent();
            this.accountId = accountId;
        }


        private void CompleteBookDetail_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sZBDataSet12.IRBook' table. You can move, or remove it, as needed.
            this.iRBookTableAdapter1.Fill(this.sZBDataSet12.IRBook);
            // TODO: This line of code loads data into the 'sZBDataSet11.IRBook' table. You can move, or remove it, as needed.
            this.iRBookTableAdapter.Fill(this.sZBDataSet11.IRBook);
            using (SqlConnection con = new SqlConnection(@"Data Source=librarymanagesystem.database.windows.net;Initial Catalog=SZB;User ID=adminXYZ;Password=GorzWlkp!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM IRBook WHERE book_return_date IS NULL AND accountId = @accountId; SELECT * FROM IRBook WHERE book_return_date IS NOT NULL AND accountId = @accountId", con);
                cmd.Parameters.AddWithValue("@accountId", accountId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView2.DataSource = ds.Tables[1];
            }

        }




        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_ReadOnlyChanged(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;
        }
    }

}