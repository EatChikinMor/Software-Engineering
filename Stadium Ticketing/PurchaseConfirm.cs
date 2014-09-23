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
    public partial class PurchaseConfirm : Form
    {
        public PurchaseConfirm(string OrderNumber, string TicketNumber, string CardNumber)
        {
            InitializeComponent();
            lblCard.Text = CardNumber;
            lblOrderNumber.Text = OrderNumber;
            lblTicketNumber.Text = TicketNumber;

        }

        private void PurchaseConfirm_Load(object sender, EventArgs e)
        {

        }
    }
}
