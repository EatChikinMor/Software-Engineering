using System;
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
        #region Private members
        private LoginController mLC;
        #endregion
        public LoginForm(LoginController lc)
        {
            mLC = lc;
            InitializeComponent();
        }

        #region Login click
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = null;
            string password = null;

            if (tbxUserName.Text != null)
                userName = tbxUserName.Text;
            if (tbxPassword.Text != null)
                password = tbxPassword.Text;

            if (userName != null && password != null)
            { //send info to loginController
            }
        }
        #endregion
    }
}
