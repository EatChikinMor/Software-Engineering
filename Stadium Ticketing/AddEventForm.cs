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
using DataHelpers.Objects;
using System.Text.RegularExpressions;

namespace Stadium_Ticketing
{
    public partial class AddEventForm : Form
    {
        private AddEventController mAEC;
        private string mName;
        private bool mFloor = false;
        private bool mLevel1 = false;
        private bool mLevel2 = false;        
        private DateTime mDate = DateTime.Now;
        Decimal mBtp; //base ticket price
        Decimal mFtp; //floor ticket price
        private string mUser; //for logout functionality

        public AddEventForm(string user)
        {
            mAEC = new AddEventController();
            mUser = user;
            InitializeComponent();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void clear()
        {
            tbxBasePrice.Clear();
            tbxEventName.Clear();
            monthCalendar1.SelectionRange.Start = DateTime.Now;
            monthCalendar1.SelectionRange.End = DateTime.Now;            
            ckbxFloor.Checked = false;
            ckbxLevel2.Checked = false;
            ckbxLevel3.Checked = false;
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            if (mAEC.addEvent(mName, mDate, mFloor, mLevel1, mLevel2, mBtp, mFtp))
            {
                AddEventConfirmForm confirm = new AddEventConfirmForm();
                confirm.Show();
                clear();
            }            
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginController lc = new LoginController();
            lc.logout(this, mUser);
        }

        private void btnReturns_Click(object sender, EventArgs e)
        {
            AdminReturnForm1 form = new AdminReturnForm1(mUser);
            this.Close();
            form.Show();
        }

        private void tbxBasePrice_TextChanged(object sender, EventArgs e)
        {
            if (tbxBasePrice.Text != "")
            {
                mBtp = Convert.ToDecimal(decimal.Parse(tbxBasePrice.Text.ToString()));
                mFtp = Math.Round(mBtp * 10, 2);
            }
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            
            mDate = monthCalendar1.SelectionStart;
            
        }

        private void ckbxFloor_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbxFloor.Checked)
            {
                mFloor = true;
                tbxFloorPrice.Text = "Floor pricing generated...";
            }
            else
            {
                mFloor = false;
                tbxFloorPrice.Text = "";
            }
        }
        private void ckbxLevel2_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbxLevel2.Checked)
            {
                mLevel1 = true;
                tbxLevel2Price.Text = "Level 1 pricing generated...";
            }
            else 
            {
                mLevel1 = false;
                tbxLevel2Price.Text = "";
            }
        }

        private void ckbxLevel3_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbxLevel3.Checked)
            {
                mLevel2 = true;
                tbxLevel3Price.Text = "Level 2 pricing generated...";
            }
            else 
            {
                mLevel2 = false;
                tbxLevel3Price.Text = "";
            }
        }

        private void tbxEventName_TextChanged(object sender, EventArgs e)
        {
            mName = tbxEventName.Text;
        }

        private void tbxBasePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //allow only digits in tbxBasePrice, only one decimal point, and only two decimal places

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;

            if (Regex.IsMatch(tbxBasePrice.Text, @"\.\d\d"))
                e.Handled = true;
        }
    }
}
