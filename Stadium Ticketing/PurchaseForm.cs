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

        private Ticketing _TDH = new Ticketing();

        private static DataTable _EventTable = new DataTable();

        Event _Event;
        

        #endregion

        public frmTicketing()
        {
            InitializeComponent();

            ddlEvent_Populate();

            lblTicketPrice.Text = lblTax.Text = lblTotal.Text = "";

            ddlExpMonth.Items.Add(String.Empty);
            for (int i=1; i<13; i++)
            {
                ddlExpMonth.Items.Add(i);
            }
        }

        private void frmTicketing_Load(object sender, EventArgs e)
        {

        }

        #region Dropdown Event Flow

        private void ddlEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLevel.Items.Clear();
            ddlSection.Items.Clear();
            ddlRow.Items.Clear();
            ddlSeat.Items.Clear();
            DataRow Row = _EventTable.AsEnumerable().Where(row => row["ID"].ToString() == (((ComboboxItem)ddlEvent.SelectedItem).Value)).FirstOrDefault();

            _Event = new Event()
            {
                ID = Convert.ToInt32(Row["ID"].ToString()),
                Name = Row["Name"].ToString(),
                Date = Convert.ToDateTime(Row["Date"].ToString()),
                Floor = Convert.ToBoolean(Row["Floor"].ToString()),
                Level1 = Convert.ToBoolean(Row["Level1"].ToString()),
                Level2 = Convert.ToBoolean(Row["Level2"].ToString()),
                BasePrice = Convert.ToDecimal(Row["BasePrice"].ToString()),
                MaxPrice = Convert.ToDecimal(Row["MaxPrice"].ToString())
            };

            if (_Event.Floor)
            {
                ddlLevel.Items.Add("Floor");
            }
            if (_Event.Level1)
            {
                ddlLevel.Items.Add("Level 1");
            }
            if (_Event.Level2)
            {
                ddlLevel.Items.Add("Level 2");
            }

            ddlLevel.Enabled = true;
            ddlSection.Enabled = false;
            ddlRow.Enabled = false;
            ddlSeat.Enabled = false;
        }

        private void ddlLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSection.Items.Clear();
            ddlRow.Items.Clear();
            ddlSeat.Items.Clear();

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

            DataTable dt = _TDH.GetUnavailableSections(Convert.ToInt32(((ComboboxItem)ddlEvent.SelectedItem).Value), ddlLevel.SelectedIndex);

            //Remove Full Sections
            foreach (DataRow row in dt.Rows)
            {
                ddlSection.Items.Remove(row["Section"]);
            }

            ddlSection.Enabled = true;
            ddlRow.Enabled = false;
            ddlSeat.Enabled = false;
        }

        private void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlRow.Items.Clear();
            ddlSeat.Items.Clear();

            for (int i = 1; i < 26; i++)
            {
                ddlRow.Items.Add(i);
            }

            DataTable dt = _TDH.GetUnavailableRows(_Event.ID, ddlLevel.SelectedIndex, ddlSection.SelectedItem.ToString());

            foreach (DataRow row in dt.Rows)
            {
                ddlRow.Items.Remove(Convert.ToInt32(row["Row"]));
            }

            ddlRow.Enabled = true;

            //if (ddlRow.Enabled)
            //{                   
            //    Sort out logic to see if previously selected row is available in newly selected section
            //    If(Yes)
            //        lblTicketPrice.Text = GenerateTicketPrice(_Event.BasePrice, _Event.MaxPrice, ddlLevel.SelectedIndex, ddlSection.SelectedItem.ToString(), Convert.ToInt32(ddlRow.SelectedItem)).ToString();
            //    Else
            //        Clear Price, SelectedIndex = 0
            //}
            //else
            //{
            //    ddlRow.Enabled = true;
            //}

            ddlSeat.Enabled = false;
        }

        private void ddlRow_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSeat.Items.Clear();
            for (int i = 1; i < 26; i++)
            {
                ddlSeat.Items.Add(i);
            }

            DataTable dt = _TDH.GetUnavailableSeats(_Event.ID, ddlLevel.SelectedIndex, ddlSection.SelectedItem.ToString(), (int)ddlRow.SelectedItem);

            foreach (DataRow row in dt.Rows)
            {
                ddlSeat.Items.Remove(Convert.ToInt32(row["Seat"]));
            }

            ddlSeat.Enabled = true;
        }

        private void ddlSeat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Decimal ticketPrice = GenerateTicketPrice(_Event.BasePrice, _Event.MaxPrice, ddlLevel.SelectedIndex, ddlSection.SelectedItem.ToString(), Convert.ToInt32(ddlRow.SelectedItem)),
            tax = Math.Round((ticketPrice * 0.08m), 2);
            lblTicketPrice.Text = ticketPrice.ToString();
            lblTax.Text = tax.ToString();
            lblTotal.Text = (ticketPrice + tax).ToString();
        }

        #endregion

        #region Purchase

        private void ddlExpMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlExpYear.Items.Clear();
            if (ddlExpMonth.SelectedValue != String.Empty)
            {
                ddlExpYear.Enabled = true;

                DateTime year = DateTime.Now;

                for (int i = 0; i < 5; i++)
                {
                    ddlExpYear.Items.Add(year.AddYears(i).Year);
                }
            }
            else
                ddlExpYear.Enabled = false;
        }

        private void ddlExpYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPurchase.Enabled = true;
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            if (cardCheck(txtCreditCard.Text))
            {
                DateTime Expiration = new DateTime(Convert.ToInt32(ddlExpYear.SelectedItem), Convert.ToInt32(ddlExpMonth.SelectedItem), 1);

                if (Expiration.AddMonths(1) > DateTime.Now)
                {
                    Ticket ticket = new Ticket()
                    {
                        TicketNo = Guid.NewGuid(),
                        EventID = _Event.ID,
                        Level = ddlLevel.SelectedIndex,
                        Row = Convert.ToInt32(ddlRow.SelectedItem.ToString()),
                        Section = Convert.ToChar(ddlSection.SelectedItem.ToString()),
                        Seat = Convert.ToInt32(ddlSeat.SelectedItem.ToString())
                    };
                    int count = 0;

                    string LastFour = txtCreditCard.ToString().Substring(txtCreditCard.ToString().Length - 4, 4);

                    string orderNumber = _TDH.GenerateTicket(ticket, ref count);

                    _TDH.GenerateOrder(ticket.TicketNo, orderNumber, LastFour);

                    if ( count > 1)
                    {
                        MessageBox.Show(String.Format("Error:{0} Tickets Affected. Look into issue", count));
                    }

                    PurchaseConfirm confirm = new PurchaseConfirm(orderNumber, ticket.TicketNo.ToString(), String.Format("XXXX-XXXX-XXXX-{0}", LastFour));

                    confirm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Invalid Credit Card. Check Card number and/or Expiration.");
            }

        }

        #endregion

        private void lnkAdminLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Navigate to Login
        }

        private void ddlEvent_Populate()
        {
            _EventTable = _TDH.GetEvents();

            List<Tuple<int, string>> Events = new List<Tuple<int, string>>();
            for (int i = 0; i < _EventTable.Rows.Count; i++)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = _EventTable.Rows[i]["Name"].ToString() + " - " + _EventTable.Rows[i]["Date"].ToString();
                item.Value = _EventTable.Rows[i]["ID"].ToString();

                ddlEvent.Items.Add(item);
            }
        }

        protected Decimal GenerateTicketPrice(decimal BasePrice, decimal MaxPrice, int LevelIndex, string Section, int Row)
        {
            Decimal price, increment;

            Dictionary<string, int> section = new Dictionary<string, int>()
	        {
	            {"A", 1},
	            {"B", 1},
	            {"C", 2},
	            {"D", 2},
                {"E", 3},
                {"F", 3},
                {"G", 4},
                {"H", 4},
                {"I", 5},
                {"J", 5}
	        };

            int seatPriceRange = (ddlLevel.Items.Count * section.Keys.Count * 25)/2; //A = B, C = D etc, so divide by two

            increment = (MaxPrice - BasePrice) / (seatPriceRange - 1);

            BasePrice = BasePrice - increment;

                                                                //125x + 25(y-1) + z-1 => Alternate => 125x + 25y + z - 26
            price = BasePrice + (increment * (seatPriceRange - ((125 * LevelIndex) + (25 * (section[Section] - 1)) + (Row - 1))));

            return Math.Round(price, 2);
        }

        protected bool cardCheck(string creditCardNumber)
        {
            if (string.IsNullOrEmpty(creditCardNumber))
            {
                return false;
            }
            else if(creditCardNumber.Length > 19 || creditCardNumber.Length < 12)
            {
                return false;
            }

            int sumOfDigits = creditCardNumber.Where((e) => e >= '0' && e <= '9')
                            .Reverse()
                            .Select((e, i) => ((int)e - 48) * (i % 2 == 0 ? 1 : 2))
                            .Sum((e) => e / 10 + e % 10);
         
            return sumOfDigits % 10 == 0;
        }
    }
}
