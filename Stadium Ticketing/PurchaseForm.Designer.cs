namespace Stadium_Ticketing
{
    partial class frmTicketing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ddlEvent = new System.Windows.Forms.ComboBox();
            this.lblEvent = new System.Windows.Forms.Label();
            this.ddlLevel = new System.Windows.Forms.ComboBox();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblSection = new System.Windows.Forms.Label();
            this.ddlSection = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlRow = new System.Windows.Forms.ComboBox();
            this.lblReturn = new System.Windows.Forms.Label();
            this.btnReturns = new System.Windows.Forms.Button();
            this.lblTicketPriceStatic = new System.Windows.Forms.Label();
            this.lblTaxStatic = new System.Windows.Forms.Label();
            this.lblTicketPrice = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalStatic = new System.Windows.Forms.Label();
            this.txtCreditCard = new System.Windows.Forms.TextBox();
            this.lblCreditCard = new System.Windows.Forms.Label();
            this.ddlExpMonth = new System.Windows.Forms.ComboBox();
            this.lblExpiration = new System.Windows.Forms.Label();
            this.ddlExpYear = new System.Windows.Forms.ComboBox();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.lnkAdminLogin = new System.Windows.Forms.LinkLabel();
            this.lblSeat = new System.Windows.Forms.Label();
            this.ddlSeat = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ddlEvent
            // 
            this.ddlEvent.FormattingEnabled = true;
            this.ddlEvent.Location = new System.Drawing.Point(12, 40);
            this.ddlEvent.Name = "ddlEvent";
            this.ddlEvent.Size = new System.Drawing.Size(297, 22);
            this.ddlEvent.TabIndex = 0;
            this.ddlEvent.SelectedIndexChanged += new System.EventHandler(this.ddlEvent_SelectedIndexChanged);
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.Font = new System.Drawing.Font("Calibri", 14F);
            this.lblEvent.Location = new System.Drawing.Point(13, 14);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(53, 23);
            this.lblEvent.TabIndex = 1;
            this.lblEvent.Text = "Event";
            // 
            // ddlLevel
            // 
            this.ddlLevel.Enabled = false;
            this.ddlLevel.FormattingEnabled = true;
            this.ddlLevel.Location = new System.Drawing.Point(12, 98);
            this.ddlLevel.Name = "ddlLevel";
            this.ddlLevel.Size = new System.Drawing.Size(95, 22);
            this.ddlLevel.TabIndex = 1;
            this.ddlLevel.SelectedIndexChanged += new System.EventHandler(this.ddlLevel_SelectedIndexChanged);
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Calibri", 14F);
            this.lblLevel.Location = new System.Drawing.Point(14, 72);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(49, 23);
            this.lblLevel.TabIndex = 3;
            this.lblLevel.Text = "Level";
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.Font = new System.Drawing.Font("Calibri", 14F);
            this.lblSection.Location = new System.Drawing.Point(109, 72);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(67, 23);
            this.lblSection.TabIndex = 5;
            this.lblSection.Text = "Section";
            // 
            // ddlSection
            // 
            this.ddlSection.Enabled = false;
            this.ddlSection.FormattingEnabled = true;
            this.ddlSection.Location = new System.Drawing.Point(113, 98);
            this.ddlSection.Name = "ddlSection";
            this.ddlSection.Size = new System.Drawing.Size(55, 22);
            this.ddlSection.TabIndex = 2;
            this.ddlSection.SelectedIndexChanged += new System.EventHandler(this.ddlSection_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14F);
            this.label1.Location = new System.Drawing.Point(182, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Row";
            // 
            // ddlRow
            // 
            this.ddlRow.Enabled = false;
            this.ddlRow.FormattingEnabled = true;
            this.ddlRow.Location = new System.Drawing.Point(178, 98);
            this.ddlRow.Name = "ddlRow";
            this.ddlRow.Size = new System.Drawing.Size(58, 22);
            this.ddlRow.TabIndex = 3;
            this.ddlRow.SelectedIndexChanged += new System.EventHandler(this.ddlRow_SelectedIndexChanged);
            // 
            // lblReturn
            // 
            this.lblReturn.AutoSize = true;
            this.lblReturn.Font = new System.Drawing.Font("Calibri", 12F);
            this.lblReturn.Location = new System.Drawing.Point(61, 165);
            this.lblReturn.Name = "lblReturn";
            this.lblReturn.Size = new System.Drawing.Size(175, 19);
            this.lblReturn.TabIndex = 8;
            this.lblReturn.Text = "Need to request a return?";
            // 
            // btnReturns
            // 
            this.btnReturns.Location = new System.Drawing.Point(102, 187);
            this.btnReturns.Name = "btnReturns";
            this.btnReturns.Size = new System.Drawing.Size(88, 23);
            this.btnReturns.TabIndex = 9;
            this.btnReturns.Text = "Click here";
            this.btnReturns.UseVisualStyleBackColor = true;
            // 
            // lblTicketPriceStatic
            // 
            this.lblTicketPriceStatic.AutoSize = true;
            this.lblTicketPriceStatic.Font = new System.Drawing.Font("Calibri", 14F);
            this.lblTicketPriceStatic.Location = new System.Drawing.Point(375, 14);
            this.lblTicketPriceStatic.Name = "lblTicketPriceStatic";
            this.lblTicketPriceStatic.Size = new System.Drawing.Size(101, 23);
            this.lblTicketPriceStatic.TabIndex = 10;
            this.lblTicketPriceStatic.Text = "Ticket Price:";
            // 
            // lblTaxStatic
            // 
            this.lblTaxStatic.AutoSize = true;
            this.lblTaxStatic.Font = new System.Drawing.Font("Calibri", 14F);
            this.lblTaxStatic.Location = new System.Drawing.Point(436, 50);
            this.lblTaxStatic.Name = "lblTaxStatic";
            this.lblTaxStatic.Size = new System.Drawing.Size(40, 23);
            this.lblTaxStatic.TabIndex = 11;
            this.lblTaxStatic.Text = "Tax:";
            // 
            // lblTicketPrice
            // 
            this.lblTicketPrice.AutoSize = true;
            this.lblTicketPrice.Font = new System.Drawing.Font("Calibri", 14F);
            this.lblTicketPrice.Location = new System.Drawing.Point(477, 14);
            this.lblTicketPrice.Name = "lblTicketPrice";
            this.lblTicketPrice.Size = new System.Drawing.Size(122, 23);
            this.lblTicketPrice.TabIndex = 12;
            this.lblTicketPrice.Text = "PLACEHOLDER";
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Font = new System.Drawing.Font("Calibri", 14F);
            this.lblTax.Location = new System.Drawing.Point(477, 50);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(122, 23);
            this.lblTax.TabIndex = 13;
            this.lblTax.Text = "PLACEHOLDER";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Calibri", 14F);
            this.lblTotal.Location = new System.Drawing.Point(477, 87);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(122, 23);
            this.lblTotal.TabIndex = 15;
            this.lblTotal.Text = "PLACEHOLDER";
            // 
            // lblTotalStatic
            // 
            this.lblTotalStatic.AutoSize = true;
            this.lblTotalStatic.Font = new System.Drawing.Font("Calibri", 14F);
            this.lblTotalStatic.Location = new System.Drawing.Point(425, 87);
            this.lblTotalStatic.Name = "lblTotalStatic";
            this.lblTotalStatic.Size = new System.Drawing.Size(51, 23);
            this.lblTotalStatic.TabIndex = 14;
            this.lblTotalStatic.Text = "Total:";
            // 
            // txtCreditCard
            // 
            this.txtCreditCard.Location = new System.Drawing.Point(334, 141);
            this.txtCreditCard.Name = "txtCreditCard";
            this.txtCreditCard.Size = new System.Drawing.Size(265, 22);
            this.txtCreditCard.TabIndex = 5;
            // 
            // lblCreditCard
            // 
            this.lblCreditCard.AutoSize = true;
            this.lblCreditCard.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblCreditCard.Location = new System.Drawing.Point(331, 121);
            this.lblCreditCard.Name = "lblCreditCard";
            this.lblCreditCard.Size = new System.Drawing.Size(120, 17);
            this.lblCreditCard.TabIndex = 17;
            this.lblCreditCard.Text = "Credit Card Number";
            // 
            // ddlExpMonth
            // 
            this.ddlExpMonth.FormattingEnabled = true;
            this.ddlExpMonth.Location = new System.Drawing.Point(334, 185);
            this.ddlExpMonth.Name = "ddlExpMonth";
            this.ddlExpMonth.Size = new System.Drawing.Size(52, 22);
            this.ddlExpMonth.TabIndex = 6;
            this.ddlExpMonth.SelectedIndexChanged += new System.EventHandler(this.ddlExpMonth_SelectedIndexChanged);
            // 
            // lblExpiration
            // 
            this.lblExpiration.AutoSize = true;
            this.lblExpiration.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblExpiration.Location = new System.Drawing.Point(331, 165);
            this.lblExpiration.Name = "lblExpiration";
            this.lblExpiration.Size = new System.Drawing.Size(96, 17);
            this.lblExpiration.TabIndex = 19;
            this.lblExpiration.Text = "Expiration Date";
            // 
            // ddlExpYear
            // 
            this.ddlExpYear.FormattingEnabled = true;
            this.ddlExpYear.Location = new System.Drawing.Point(392, 185);
            this.ddlExpYear.Name = "ddlExpYear";
            this.ddlExpYear.Size = new System.Drawing.Size(69, 22);
            this.ddlExpYear.TabIndex = 7;
            this.ddlExpYear.SelectedIndexChanged += new System.EventHandler(this.ddlExpYear_SelectedIndexChanged);
            // 
            // btnPurchase
            // 
            this.btnPurchase.Enabled = false;
            this.btnPurchase.Font = new System.Drawing.Font("Calibri", 14F);
            this.btnPurchase.Location = new System.Drawing.Point(477, 182);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(121, 37);
            this.btnPurchase.TabIndex = 8;
            this.btnPurchase.Text = "Purchase";
            this.btnPurchase.UseVisualStyleBackColor = true;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // lnkAdminLogin
            // 
            this.lnkAdminLogin.AutoSize = true;
            this.lnkAdminLogin.LinkColor = System.Drawing.Color.Black;
            this.lnkAdminLogin.Location = new System.Drawing.Point(249, 210);
            this.lnkAdminLogin.Name = "lnkAdminLogin";
            this.lnkAdminLogin.Size = new System.Drawing.Size(114, 14);
            this.lnkAdminLogin.TabIndex = 10;
            this.lnkAdminLogin.TabStop = true;
            this.lnkAdminLogin.Text = "Administrator Login";
            this.lnkAdminLogin.VisitedLinkColor = System.Drawing.Color.Black;
            this.lnkAdminLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAdminLogin_LinkClicked);
            // 
            // lblSeat
            // 
            this.lblSeat.AutoSize = true;
            this.lblSeat.Font = new System.Drawing.Font("Calibri", 14F);
            this.lblSeat.Location = new System.Drawing.Point(248, 72);
            this.lblSeat.Name = "lblSeat";
            this.lblSeat.Size = new System.Drawing.Size(43, 23);
            this.lblSeat.TabIndex = 24;
            this.lblSeat.Text = "Seat";
            // 
            // ddlSeat
            // 
            this.ddlSeat.Enabled = false;
            this.ddlSeat.FormattingEnabled = true;
            this.ddlSeat.Location = new System.Drawing.Point(252, 98);
            this.ddlSeat.Name = "ddlSeat";
            this.ddlSeat.Size = new System.Drawing.Size(56, 22);
            this.ddlSeat.TabIndex = 4;
            this.ddlSeat.SelectedIndexChanged += new System.EventHandler(this.ddlSeat_SelectedIndexChanged);
            // 
            // frmTicketing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 231);
            this.Controls.Add(this.lblSeat);
            this.Controls.Add(this.ddlSeat);
            this.Controls.Add(this.lnkAdminLogin);
            this.Controls.Add(this.btnPurchase);
            this.Controls.Add(this.ddlExpYear);
            this.Controls.Add(this.lblExpiration);
            this.Controls.Add(this.ddlExpMonth);
            this.Controls.Add(this.lblCreditCard);
            this.Controls.Add(this.txtCreditCard);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblTotalStatic);
            this.Controls.Add(this.lblTax);
            this.Controls.Add(this.lblTicketPrice);
            this.Controls.Add(this.lblTaxStatic);
            this.Controls.Add(this.lblTicketPriceStatic);
            this.Controls.Add(this.btnReturns);
            this.Controls.Add(this.lblReturn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlRow);
            this.Controls.Add(this.lblSection);
            this.Controls.Add(this.ddlSection);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.ddlLevel);
            this.Controls.Add(this.lblEvent);
            this.Controls.Add(this.ddlEvent);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmTicketing";
            this.Text = "Stadium Ticketing";
            //this.Load += new System.EventHandler(this.frmTicketing_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlEvent;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.ComboBox ddlLevel;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.ComboBox ddlSection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlRow;
        private System.Windows.Forms.Label lblReturn;
        private System.Windows.Forms.Button btnReturns;
        private System.Windows.Forms.Label lblTicketPriceStatic;
        private System.Windows.Forms.Label lblTaxStatic;
        private System.Windows.Forms.Label lblTicketPrice;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalStatic;
        private System.Windows.Forms.TextBox txtCreditCard;
        private System.Windows.Forms.Label lblCreditCard;
        private System.Windows.Forms.ComboBox ddlExpMonth;
        private System.Windows.Forms.Label lblExpiration;
        private System.Windows.Forms.ComboBox ddlExpYear;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.LinkLabel lnkAdminLogin;
        private System.Windows.Forms.Label lblSeat;
        private System.Windows.Forms.ComboBox ddlSeat;

    }
}

