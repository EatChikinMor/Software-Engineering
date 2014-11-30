using DataHelpers;
using DataHelpers.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Stadium_Ticketing
{
    public partial class frmTicketing : Form
    {
        #region Class Level Variables

        private PurchasingController _PC = new PurchasingController();

        private TicketingDBConnector _TDH = new TicketingDBConnector();

        private static DataTable _EventTable = new DataTable();

        private static string[] _sections = new string[10] {"A","B","C","D","E","F","G","H","I","J"};

        #endregion

        public frmTicketing()
        {
            InitializeComponent();

            ddlEvent_Populate();

            ddlExpMonth.Items.Add(String.Empty);

            for (int i = 1; i < 13; i++)
            {
                ddlExpMonth.Items.Add(i);
            }
            ddlExpYear.Enabled = false;

            lblTicketPrice.Text = lblTax.Text = lblTotal.Text = "";
        }

        private void ddlEvent_Populate()
        {
            _EventTable = _TDH.GetEvents();

            List<Tuple<int, string>> Events = new List<Tuple<int, string>>();
            for (int i = 0; i < _EventTable.Rows.Count; i++)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = _EventTable.Rows[i]["Name"].ToString() + " - " + String.Format("{0:h tt MM/dd/yy}", Convert.ToDateTime(_EventTable.Rows[i]["Date"]));
                item.Value = _EventTable.Rows[i]["ID"].ToString();

                ddlEvent.Items.Add(item);
            }
        }

        #region Dropdown Event Flow
        
        private void ddlEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLevel.ResetText();
            ddlLevel.Items.Clear();
            ddlSection.ResetText();
            ddlSection.Items.Clear();
            ddlRow.ResetText();
            ddlRow.Items.Clear();
            ddlRow.ResetText();
            ddlSeat.Items.Clear();

            DataRow Row = _EventTable
                .AsEnumerable()
                .Where(row => row["ID"].ToString() == (((ComboboxItem)ddlEvent.SelectedItem).Value))
                .FirstOrDefault();

            _PC.buildEvent(Row);

            Event Event = _PC.buildEvent(Row);

            if (Event.Floor)
            {
                ddlLevel.Items.Add("Floor");
            }
            if (Event.Level1)
            {
                ddlLevel.Items.Add("Level 1");
            }
            if (Event.Level2)
            {
                ddlLevel.Items.Add("Level 2");
            }

            foreach (string section in _sections)
            {
                ddlSection.Items.Add(section);
            }

            for (int i = 1; i < 26; i++)
            {
                ddlRow.Items.Add(i);
            }

            ddlLevel.Enabled = true;
            ddlSection.Enabled = true;
            ddlRow.Enabled = true;
            ddlSeat.Enabled = false;
        }

        private void ddlLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ddlSeat.Enabled)
            {
                // Not Implemented
                //        ddlSection.Items.Clear();
                //        ddlRow.Items.Clear();
                //        ddlSeat.Items.Clear();

                //        #region Populate all

                //        ddlSection.Items.Add("A");
                //        ddlSection.Items.Add("B");
                //        ddlSection.Items.Add("C");
                //        ddlSection.Items.Add("D");
                //        ddlSection.Items.Add("E");
                //        ddlSection.Items.Add("F");
                //        ddlSection.Items.Add("G");
                //        ddlSection.Items.Add("H");
                //        ddlSection.Items.Add("I");
                //        ddlSection.Items.Add("J");

                //        #endregion

                //        DataTable dt = _TDH.GetUnavailableSections(Convert.ToInt32(((ComboboxItem)ddlEvent.SelectedItem).Value), ddlLevel.SelectedIndex);

                //        //Remove Full Sections
                //        foreach (DataRow row in dt.Rows)
                //        {
                //            ddlSection.Items.Remove(row["Section"]);
                //        }

                //        ddlSection.Enabled = true;
                //        ddlRow.Enabled = false;
                //        ddlSeat.Enabled = false;
            }
            else
            {
                Decimal ticketPrice = _PC.GenerateTicketPrice(ddlLevel.SelectedIndex, ddlSection.SelectedItem.ToString(), Convert.ToInt32(ddlRow.SelectedItem)),
                tax = Math.Round((ticketPrice * 0.08m), 2);
                lblTicketPrice.Text = ticketPrice.ToString();
                lblTax.Text = tax.ToString();
                lblTotal.Text = (ticketPrice + tax).ToString();
            }
        }

        private void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ddlSeat.Enabled)
            {
                // Not Implemented
                //        ddlRow.Items.Clear();
                //        ddlSeat.Items.Clear();

                //        for (int i = 1; i < 26; i++)
                //        {
                //            ddlRow.Items.Add(i);
                //        }

                //        DataTable dt = _TDH.GetUnavailableRows(_Event.ID, ddlLevel.SelectedIndex, ddlSection.SelectedItem.ToString());

                //        foreach (DataRow row in dt.Rows)
                //        {
                //            ddlRow.Items.Remove(Convert.ToInt32(row["Row"]));
                //        }

                //        ddlRow.Enabled = true;
                //        ddlSeat.Enabled = false;
            }
            else
            {
                Decimal ticketPrice = _PC.GenerateTicketPrice(ddlLevel.SelectedIndex, ddlSection.SelectedItem.ToString(), Convert.ToInt32(ddlRow.SelectedItem)),
                tax = Math.Round((ticketPrice * 0.08m), 2);
                lblTicketPrice.Text = ticketPrice.ToString();
                lblTax.Text = tax.ToString();
                lblTotal.Text = (ticketPrice + tax).ToString();
            }
        }

        private void ddlRow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ddlSeat.Enabled)
            {
                ddlSeat.Items.Clear();

                int[] seats = _PC.getSeats(ddlLevel.SelectedIndex, Convert.ToChar(ddlSection.SelectedIndex.ToString()), Convert.ToInt32(ddlRow.SelectedItem));

                foreach (int seat in seats)
                {
                    ddlSeat.Items.Add(seat);
                }

                ddlSeat.Enabled = true;
            }
            else if (ddlSeat.SelectedItem != null)
            {
                Decimal ticketPrice = _PC.GenerateTicketPrice(ddlLevel.SelectedIndex, ddlSection.SelectedItem.ToString(), Convert.ToInt32(ddlRow.SelectedItem)),
                tax = Math.Round((ticketPrice * 0.08m), 2);
                lblTicketPrice.Text = ticketPrice.ToString();
                lblTax.Text = tax.ToString();
                lblTotal.Text = (ticketPrice + tax).ToString();
            }
        }

        private void ddlSeat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Decimal ticketPrice = _PC.GenerateTicketPrice(ddlLevel.SelectedIndex, ddlSection.SelectedItem.ToString(), Convert.ToInt32(ddlRow.SelectedItem)),
            tax = Math.Round((ticketPrice * 0.08m), 2);
            lblTicketPrice.Text = ticketPrice.ToString();
            lblTax.Text = tax.ToString();
            lblTotal.Text = (ticketPrice + tax).ToString();
            if (ddlExpYear.Enabled)
            {
                btnPurchase.Enabled = true;
            }
        }

        #endregion

        #region Purchase Flow

        private void ddlExpMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlExpYear.Items.Clear();
            if ((string)ddlExpMonth.SelectedValue != String.Empty)
            {
                ddlExpYear.Enabled = true;

                DateTime year = DateTime.Now;

                for (int i = 0; i < 10; i++)
                {
                    ddlExpYear.Items.Add(year.AddYears(i).Year);
                }
            }
            else
                ddlExpYear.Enabled = false;
        }

        private void ddlExpYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Int32)ddlSeat.SelectedItem > 0)
            {
                btnPurchase.Enabled = true;
            }
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            if (_PC.cardCheck(txtCreditCard.Text))
            {
                DateTime Expiration = new DateTime(Convert.ToInt32(ddlExpYear.SelectedItem), Convert.ToInt32(ddlExpMonth.SelectedItem), 1);

                if (Expiration.AddMonths(1) > DateTime.Now)
                {
                    string orderNumber = "", 
                    LastFour = txtCreditCard.ToString().Substring(txtCreditCard.ToString().Length - 4, 4);;

                    Guid ticketNo = _PC.SubmitOrder
                                    (
                                        ddlLevel.SelectedIndex,
                                        Convert.ToChar(ddlSection.SelectedItem.ToString()),
                                        Convert.ToInt32(ddlRow.SelectedItem.ToString()),
                                        Convert.ToInt32(ddlSeat.SelectedItem.ToString()),
                                        LastFour,
                                        ref orderNumber
                                    );

                    PurchaseConfirm confirm = new PurchaseConfirm(orderNumber, ticketNo.ToString(), String.Format("XXXX-XXXX-XXXX-{0}", LastFour));

                    confirm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Invalid Credit Card. Check Card number and/or Expiration.");
            }

        }

        #endregion

        #region Additional Functionality Navigation

        private void lnkAdminLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Admin Login Form
            LoginForm loginform = new LoginForm();
            loginform.Show();
            //this.Close();
            //loginform.Show();
        }

        private void btnReturns_Click(object sender, EventArgs e)
        {
            //User Returns Form
        }

        #endregion

       
    }
}
