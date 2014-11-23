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
    public partial class AddEventForm : Form
    {
        #region private members
        private AddEventController mAEC;
        private bool mFloor = false;
        private bool mLevel1 = false;
        private bool mLevel2 = false;
        private bool mLevel3 = false;
        private DateTime mDate;
        Decimal mBtp; //base ticket price
        Decimal mFtp; //floor ticket price
        Decimal mL1tp; //level 1
        Decimal mL2tp; //level 2
        Decimal mL3tp; //level 3
        #endregion

        public AddEventForm(AddEventController c)
        {
            mAEC = c;
            InitializeComponent();
        }

        #region btnClear click clears text boxes of user-entered text
        private void buttonClear_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void clear()
        {
            tbxBasePrice.Clear();
            tbxEventName.Clear();
            tbxFloorPrice.Clear();
            tbxLevel2Price.Clear();
            tbxLevel3Price.Clear();
        }
        #endregion

        #region btnAddEvent on click saves event data to database
        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            //get data from filled out form fields, call mAEC.addEvent(...)
            string name = tbxEventName.Text;
            DateTime date = mDate;

            mAEC.addEvent(name, mDate, mFloor, mLevel1, mLevel2, mBtp, mFtp);
            
        }
        #endregion        

        #region btnLogout click activates logout sequence
        private void btnLogout_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region btnReturns click activates returns sequence
        private void btnReturns_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region upon changing base ticket price textbox, should autogenerate ticket prices
        private void tbxBasePrice_TextChanged(object sender, EventArgs e)
        {
            //Generate ticket price based on base ticket price
            mBtp = Convert.ToDecimal(tbxBasePrice.Text);
            //stupidly simple modifier multiplicands for generating prices
            int mod1 = 6, mod2 = 4, mod3 = 2; 
            mFtp = mBtp * mod1;
            mL1tp = mFtp;
            mL2tp = mBtp * mod2;
            mL3tp = mBtp * mod3;

            //fill associated text box if checkbox is checked
            if (ckbxFloor.Checked)
            {
                mFloor = true;
                mLevel1 = true;
                tbxFloorPrice.Text = Convert.ToString(Math.Round(mFtp, 2));
            }
            if (ckbxLevel2.Checked)
            {
                mLevel2 = true;
                tbxLevel2Price.Text = Convert.ToString(Math.Round(mL2tp, 2)); 
            }
            if (ckbxLevel3.Checked)
            {
                mLevel3 = true;
                tbxLevel3Price.Text = Convert.ToString(Math.Round(mL3tp, 2));
            }
        }
        #endregion

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            mDate = monthCalendar1.SelectionStart;
        }  
    }
}
