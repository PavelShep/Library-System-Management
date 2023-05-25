﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZB
{
    internal class network_connection
    {
        
        public int nConnection()
        {
            bool networkUp = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            if (networkUp == false)
            {
                MessageBox.Show("No internet connection , try again");
                Application.Restart();
                return Convert.ToInt32(networkUp);
           
            }
            else
            {
                networkUp = true;
                return Convert.ToInt32(networkUp);
            }
        }
    }
}
