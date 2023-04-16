﻿using System;
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

        private Form activeForm = null;
        private void OpenMainForm(Form MainChildForm) 
        {
            if(activeForm!= null) 
            {
                activeForm.Close();
            }
            activeForm = MainChildForm;
            MainChildForm.TopLevel= false;
            MainChildForm.FormBorderStyle = FormBorderStyle.None;
            MainChildForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(MainChildForm);
            panelMain.Tag = MainChildForm;
            MainChildForm.BringToFront();
            MainChildForm.Show();

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
            OpenMainForm(new Books());
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


        private void button1_Click_3(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}