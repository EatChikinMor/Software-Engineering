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
    public partial class AddEventConfirmForm : Form
    {
        private AddEventController mAEC;
        public AddEventConfirmForm( AddEventController c)
        {
            mAEC = c;
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            mAEC.close();
            this.Close();
        }
    }
}
