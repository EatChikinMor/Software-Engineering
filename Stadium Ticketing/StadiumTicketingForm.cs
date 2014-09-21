using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataHelpers;
using DataHelpers.Objects;

namespace Stadium_Ticketing
{
    public partial class frmTicketing : Form
    {
        private Ticketing _TDH = new Ticketing();

        private DataTable _EventTable = new DataTable();

        public frmTicketing()
        {
            InitializeComponent();

            _EventTable = _TDH.GetEvents();

            List<Tuple<int, string>> Events = new List<Tuple<int,string>>();
            for (int i = 0; i < _EventTable.Rows.Count + 1; i++)
            {


                ComboboxItem item = new ComboboxItem();             //Zeroes for testing, Replace with i 
                                            //i                                              //i
                item.Text = _EventTable.Rows[0]["Name"].ToString() + " - " + _EventTable.Rows[0]["Date"].ToString();
                                            //i
                item.Value = _EventTable.Rows[0]["ID"].ToString();

                ddlEvent.Items.Add(item);
            }
        }

        private void frmTicketing_Load(object sender, EventArgs e)
        {

        }

        #region Dropdown Flow

        private void ddlEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow Row = _EventTable.AsEnumerable().Where(row => row["ID"].ToString() == (((ComboboxItem)ddlEvent.SelectedItem).Value)).FirstOrDefault();

            if (Convert.ToBoolean(Row["Floor"].ToString()))
            {
                ddlLevel.Items.Add("Floor");
            }
            if (Convert.ToBoolean(Row["Level1"].ToString()))
            {
                ddlLevel.Items.Add("Level 1");
            }
            if (Convert.ToBoolean(Row["Level2"].ToString()))
            {
                ddlLevel.Items.Add("Level 2");
            }

            ddlLevel.Enabled = true;
            ddlSection.Enabled = false;
            ddlRow.Enabled = false;
        }

        private void ddlLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Populate all

                ddlSection.Items.Add("A");
                ddlSection.Items.Add("B");
                ddlSection.Items.Add("C");
                ddlSection.Items.Add("D");
                ddlSection.Items.Add("E");
                ddlSection.Items.Add("F");
                ddlSection.Items.Add("G");
                ddlSection.Items.Add("H");
                ddlSection.Items.Add("I");
                ddlSection.Items.Add("J");

            #endregion

            DataTable dt = _TDH.GetAvailableSections(Convert.ToInt32(((ComboboxItem)ddlEvent.SelectedItem).Value), ddlLevel.SelectedIndex);


            foreach (DataRow row in dt.Rows)
            {
                ddlSection.Items.Remove(row["Section"]);
            }

            ddlSection.Enabled = true;
        }

        private void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get Available Rows
            //Populate ddlRow

            ddlRow.Enabled = true;
        }

        #endregion

        private void lnkAdminLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Navigate to Login
        }

        private void ddlEvent_Populate()
        {
            
        }
    }
}
