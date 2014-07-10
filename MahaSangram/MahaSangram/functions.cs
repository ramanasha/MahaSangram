﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MahaSangram
{
    static class functions
    {
        public static void closeapp()
        {
            DialogResult close = MessageBox.Show("Are you sure you want to exit the application?", "Maha Sangram 2014", MessageBoxButtons.YesNo);
            if (close == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (close == DialogResult.No)
            {
                //continue
            }
        } //end closeapp

        public static void closeapp(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                dynamic close = MessageBox.Show("Are you sure you want to exit the application?", "Maha Sangram 2014", MessageBoxButtons.YesNo);
                if (close == DialogResult.Yes)
                {
                    e.Cancel = false;
                    Application.Exit();
                }
                else if (close == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }

        } //end closeapp overloaded method for formclosing event

        //third function here
    }
}