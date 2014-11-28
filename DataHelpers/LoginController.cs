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
        private TicketingDBConnector mDBC;

        public LoginController()
        {
            mDBC = new TicketingDBConnector();
        }

        public void submit(string user, string pass, Form form)
        {
            string Result = mDBC.getPass(user);
            if (verify(Result, pass, user))
            {
                
                form.Show();
            }
        }

        private bool verify(string dbPass, string userPass, string userName)
        {
            if (dbPass == userPass)
                return mDBC.setSession(userName, true);
            else
                return false;
        }

        public void logout(Form form, string user)
        {
            if (user != null)
            {
                if (mDBC.setSession(user, false))
                    form.Close();
            }
        }
    }
}
