using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHelpers
{
    public class LoginController
    {
        #region Private members
        private string mUserName;
        private string mPassword;
        private string Result;
        private int mDestination; //0=returns, 1=addEvent
        private TicketingDBConnector mDBC;        
        #endregion

        //constructor
        public LoginController()
        {
            mDBC = new TicketingDBConnector();
        }

        #region submit method called from LoginForm, gets data from DB
        public void submit(string user, string pass, int dest = 0)
        {
            mUserName = user;
            mPassword = pass;
            Result = mDBC.getPass(user);
            mDestination = dest;

            if (verify(Result))
            {
                switch (mDestination)
                {
                    case 0:
                        //destroy LoginForm
                        //show ReturnsForm
                        break;
                    case 1:
                        //destroy LoginForm
                        //show AddEventForm
                        break;
                    default:
                        break;
                }
            }
            else
            { 
                //show LoginForm
            }

        }
        #endregion

        #region Logout method updates db session
        public void logout()
        {
            if (mDBC.kill(mUserName))
            {
                //destroy requesting form
                //show purchasing form
            }
            else
            {
                //show purchasing form
            }
        }
        #endregion

        #region private verify method called to verify password
        private bool verify(string dbPass)
        {
            if (mPassword != null && dbPass != null)
            {
                if (dbPass == mPassword)
                {
                    mDBC.setSession(mUserName);
                    return true;
                }
                else return false;
            }
            else
                return false;
        }
        #endregion

    }
}
