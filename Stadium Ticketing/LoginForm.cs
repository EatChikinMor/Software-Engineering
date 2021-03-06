﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataHelpers;

namespace Stadium_Ticketing
{
    public partial class LoginForm : Form
    {
        private LoginController mLC;

        public LoginForm()
        {
            mLC = new LoginController();
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = null;
            string password = null;

            if (tbxUserName.Text != null)
                userName = tbxUserName.Text;
            if (tbxPassword.Text != null)
                password = tbxPassword.Text;
            Form form = new AddEventForm(userName);
            if (cboDestination.SelectedIndex != 0)
                form = new AdminReturnForm1(userName);

            if (userName != null && password != null)
            {
                if (!mLC.submit(userName, password, form, this))
                { 
                    tbxPassword.Text = "";
                    lblPassError.Visible = true;
                }
            }
        }
    }
}
