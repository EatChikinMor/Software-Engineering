using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataHelpers
{
    public class LoginController
    {
        #region Private members
        private string lastUser = null;
        private TicketingDBConnector mDBC;
        #endregion

        public LoginController()
        {
            mDBC = new TicketingDBConnector();
        }

        #region submit method called from LoginForm, gets stored password from DB
        public void submit(string user, string pass, Form form)
        {
            //will use this when my DB query works
            string Result = mDBC.getPass(user);
            if (verify(Result, pass, user))
                form.Show();

            //form.Show();
        }
        #endregion

        #region private verify method called to verify password
        private bool verify(string dbPass, string userPass, string userName)
        {
            if (dbPass == userPass)
            {
                mDBC.setSession(userName, true);
                return true;
            }
            else
                return false;
        }
        #endregion

        #region Logout method updates db session
        public void logout(Form form)
        {
            if (lastUser != null)
                mDBC.setSession(lastUser, false);

            form.Close();            
        }
        #endregion
    }
}
