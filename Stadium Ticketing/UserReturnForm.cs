using DataHelpers;
using DataHelpers.Objects;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stadium_Ticketing
{
    public partial class UserReturnForm : Form
    {
        #region Class Level Variables

        private ReturnController _RC = new ReturnController();

        private DBConnector _TDH = new DBConnector();

        private static DataTable _EventTable = new DataTable();

        #endregion

        public UserReturnForm()
        {
            InitializeComponent();
        }

        private static Regex isGuid = new Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", RegexOptions.Compiled);

        private static bool IsGuid(string candidate)
        {
            if (candidate != null)
            {
                if (isGuid.IsMatch(candidate))
                {
                    return true;
                }
            }

            return false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
           if(IsGuid(textBox1.Text) == true )
           {
               Guid ticketNo = new Guid(textBox1.Text);
               _RC.SubmitRequest(ticketNo);
               MessageBox.Show("Your request has been submitted");
           }
           else
           {
               MessageBox.Show("The number you entered is not a ticket number.");
           }

        }

    }
}
