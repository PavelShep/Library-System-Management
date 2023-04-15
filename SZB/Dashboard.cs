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
            CustomizeDesing();
        }

        private void CustomizeDesing() 
        {
            panelSubMenuBooks.Visible= false;
            panelSubMenuStudents.Visible= false;
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
            else  subMenu.Visible = false;  
            
        }

       

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

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
            HideMenu();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            HideMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HideMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HideMenu();
        }
    }
}
