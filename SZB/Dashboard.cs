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
        int clcount = 0;
        private int accountId;

        public Dashboard(int accountId)
        {
            InitializeComponent();
            CustomizeDesing();
            this.accountId = accountId;
        }

//        private void dodawaćKsiążkiToolStripMenuItem_Click(object sender, EventArgs e)
//        {
//            //prevent Form(AddBooks) from opening multiple times(uniemożliwić wielokrotne otwieranie AddBooks)
//            if (restrict == 0)
//            {
//                restrict++;
//                AddBooks abs = new AddBooks();
//                abs.Show();
//            }
//            else
//            {
//                MessageBox.Show("Formularz jest już otwarty!");
//            }
//;
//        }

        //private void przeglądaćKsiążkiToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    //prevent Form(ViewBooks) from opening multiple times(uniemożliwić wielokrotne otwieranie AddBooks)
        //    if (restrict == 0)
        //    {
        //        restrict++;
        //        ViewBooks vb = new ViewBooks();
        //        vb.Show();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Formularz jest już otwarty!");
        //    }
        //}

        //private void dodaćStudentaToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    prevent Form(AddStudents) from opening multiple times(uniemożliwić wielokrotne otwieranie AddBooks)
        //    if (restrict == 0)
        //    {
        //        restrict++;
        //        AddStudents ass = new AddStudents();
        //        ass.Show();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Formularz jest już otwarty!");
        //    }
        //}

        //private void przeglądaćStudentówToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    prevent Form(AddStudents) from opening multiple times(uniemożliwić wielokrotne otwieranie AddBooks)
        //    if (restrict == 0)
        //    {
        //        restrict++;
        //        ViewStudents vs = new ViewStudents();
        //        vs.Show();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Formularz jest już otwarty!");
        //    }
        //}

        //private void issueBooksToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    prevent Form(AddStudents) from opening multiple times(uniemożliwić wielokrotne otwieranie AddBooks)
        //    if (restrict == 0)
        //    {
        //        restrict++;
        //        IssueBooks ib = new IssueBooks();
        //        ib.Show();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Formularz jest już otwarty!");
        //    }
        //}

        private void CustomizeDesing()
        {
            panelSubMenuBooks.Visible = false;
            panelSubMenuStudents.Visible = false;
        }

        private void HideMenu()
        {
            if (panelSubMenuBooks.Visible = false == true)
            {
                panelSubMenuBooks.Visible = false;
            }
            if (panelSubMenuStudents.Visible == true)
            {
                panelSubMenuStudents.Visible = false;
            }
        }

        private void ShowMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideMenu();
                subMenu.Visible = true;
            }
            else subMenu.Visible = false;

        }

        private Form activeForm = null;
        private void OpenMainForm(Form MainChildForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = MainChildForm;
            MainChildForm.TopLevel = false;
            MainChildForm.FormBorderStyle = FormBorderStyle.None;
            MainChildForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(MainChildForm);
            panelMain.Tag = MainChildForm;
            MainChildForm.BringToFront();
            MainChildForm.Show();

        }

        public void menu_hide()
        {
            this.Hide();
        }


        private void buttonBooks_Click(object sender, EventArgs e)
        {
            ShowMenu(panelSubMenuBooks);
        }

        private void buttonStudentss_Click(object sender, EventArgs e)
        {
            ShowMenu(panelSubMenuStudents);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // Замініть на ваш ID аккаунту
            OpenMainForm(new Books(accountId));
            

            
            HideMenu();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
            HideMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            menu_hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            menu_hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lgp = new Login();
            lgp.Show();
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
