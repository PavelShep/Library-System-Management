using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZB
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        public static int restrict = 0;

        private void dodawaćKsiążkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //prevent Form(AddBooks) from opening multiple times(uniemożliwić wielokrotne otwieranie AddBooks)
            if (restrict == 0)
            {
                restrict++;
                AddBooks abs = new AddBooks();
                abs.Show();
            }
            else
            {
                MessageBox.Show("Formularz jest już otwarty!");
            }
;        }

        private void przeglądaćKsiążkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //prevent Form(ViewBooks) from opening multiple times(uniemożliwić wielokrotne otwieranie AddBooks)
            if (restrict == 0)
            {
                restrict++;
                ViewBooks vb = new ViewBooks();
                vb.Show();
            }
            else
            {
                MessageBox.Show("Formularz jest już otwarty!");
            }
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        { 
            Application.Exit();
        }

        private void dodaćStudentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //prevent Form(AddStudents) from opening multiple times(uniemożliwić wielokrotne otwieranie AddBooks)
            if (restrict == 0)
            {
                restrict++;
                AddStudents ass = new AddStudents();
                ass.Show();
            }
            else
            {
                MessageBox.Show("Formularz jest już otwarty!");
            }
        }

        private void przeglądaćStudentówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //prevent Form(AddStudents) from opening multiple times(uniemożliwić wielokrotne otwieranie AddBooks)
            if (restrict == 0)
            {
                restrict++;
                ViewStudents vs = new ViewStudents();
                vs.Show();
            }
            else
            {
                MessageBox.Show("Formularz jest już otwarty!");
            }
        }

        private void issueBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //prevent Form(AddStudents) from opening multiple times(uniemożliwić wielokrotne otwieranie AddBooks)
            if (restrict == 0)
            {
                restrict++;
                IssueBooks ib = new IssueBooks();
                ib.Show();
            }
            else
            {
                MessageBox.Show("Formularz jest już otwarty!");
            }
        }

        private void returnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (restrict == 0)
            {
                restrict++;
                ReturnBook rb = new ReturnBook();
                rb.Show();
            }
            else
            {
                MessageBox.Show("Formularz jest już otwarty!");
            }
        }

        private void completeBookDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (restrict == 0)
            {
                restrict++;
                CompleteBookDetail cb = new CompleteBookDetail();
                cb.Show();
            }
            else
            {
                MessageBox.Show("Formularz jest już otwarty!");
            }
        }
    }
}
