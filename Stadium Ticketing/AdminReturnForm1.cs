using DataHelpers;
using DataHelpers.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Stadium_Ticketing
{
    public partial class AdminReturnForm1 : Form
        //Admin Return Form
    {
        public AdminReturnForm1()
        {
            InitializeComponent();

            ddlTicket_Populate();
        }

        #region Class Level Variables

        private TicketingDBConnector _TDH = new TicketingDBConnector();

        private ReturnController _RC = new ReturnController();

        private static DataTable _ReturnsTable = new DataTable();

        #endregion


        private void ddlTicket_Populate()
            //Populate combobox with tickets the User has requested to return
        {
            _ReturnsTable = _TDH.GetTickets();


            for (int i = 0; i < _ReturnsTable.Rows.Count; i++)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = _ReturnsTable.Rows[i]["Name"].ToString() + " - " + _ReturnsTable.Rows[i]["TicketNo"].ToString();
                item.Value = _ReturnsTable.Rows[i]["TicketNo"].ToString();

                comboBox1.Items.Add(item);
            }
        }

        private void Approvebtn_Click_1(object sender, EventArgs e)
            //Press approve button and remove ticketNo from Returns and Events_Tickets tables
        {
            Guid selected = new Guid((((ComboboxItem)comboBox1.SelectedItem).Value).ToString());
            _RC.ApproveRequest(selected);

        }

        private void Rejectedbtn_Click(object sender, EventArgs e)
        //Press reject button and remove ticketNo from Return table
        {
            Guid selected = new Guid((((ComboboxItem)comboBox1.SelectedItem).Value).ToString());
            _RC.RejectRequest(selected);
        }

        #region Additional Functionality Navigation

        private void logoutbtn_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
            //press and return to Purchase Screen
        {
            // logout button
            frmTicketing purchaseForm = new frmTicketing();
            purchaseForm.Show();
        }
        
        //Put in Add Event btn functionality 

       
        #endregion
        
        
    }
}

