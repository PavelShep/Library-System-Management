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
            OpenMainForm(new IssueBooks(accountId));
            HideMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenMainForm(new Students(accountId));
            HideMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenMainForm(new AddStudents(accountId));  
            HideMenu();
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

        int time_counter = 0;
        private void First_timer_Try_Tick(object sender, EventArgs e)
        {
            if (time_counter == 0)
            { 
            network_connection connection = new network_connection();
            connection.nConnection();
            time_counter++;
            if(connection.nConnection() == 1) 
                {
                    time_counter= 0;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenMainForm(new EditInfoBooks(accountId));
            HideMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenMainForm(new ReturnBook(accountId));
            HideMenu();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenMainForm(new AllBooksDetails(accountId));
            HideMenu();
        }
    }
}
