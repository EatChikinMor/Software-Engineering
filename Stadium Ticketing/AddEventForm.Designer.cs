namespace Stadium_Ticketing
{
    partial class AddEventForm
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
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnReturns = new System.Windows.Forms.Button();
            this.tbxEventName = new System.Windows.Forms.TextBox();
            this.tbxBasePrice = new System.Windows.Forms.TextBox();
            this.lblEventName = new System.Windows.Forms.Label();
            this.lblBasePrice = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.tbxFloorPrice = new System.Windows.Forms.TextBox();
            this.tbxLevel2Price = new System.Windows.Forms.TextBox();
            this.tbxLevel3Price = new System.Windows.Forms.TextBox();
            this.ckbxFloor = new System.Windows.Forms.CheckBox();
            this.ckbxLevel2 = new System.Windows.Forms.CheckBox();
            this.ckbxLevel3 = new System.Windows.Forms.CheckBox();
            this.lblCalendar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(76, 265);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.Location = new System.Drawing.Point(176, 265);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(75, 23);
            this.btnAddEvent.TabIndex = 1;
            this.btnAddEvent.Text = "Add Event";
            this.btnAddEvent.UseVisualStyleBackColor = true;
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(271, 265);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnReturns
            // 
            this.btnReturns.Location = new System.Drawing.Point(376, 265);
            this.btnReturns.Name = "btnReturns";
            this.btnReturns.Size = new System.Drawing.Size(75, 23);
            this.btnReturns.TabIndex = 3;
            this.btnReturns.Text = "Returns";
            this.btnReturns.UseVisualStyleBackColor = true;
            this.btnReturns.Click += new System.EventHandler(this.btnReturns_Click);
            // 
            // tbxEventName
            // 
            this.tbxEventName.Location = new System.Drawing.Point(37, 54);
            this.tbxEventName.Name = "tbxEventName";
            this.tbxEventName.Size = new System.Drawing.Size(214, 20);
            this.tbxEventName.TabIndex = 4;
            // 
            // tbxBasePrice
            // 
            this.tbxBasePrice.Location = new System.Drawing.Point(37, 96);
            this.tbxBasePrice.Name = "tbxBasePrice";
            this.tbxBasePrice.Size = new System.Drawing.Size(214, 20);
            this.tbxBasePrice.TabIndex = 5;
            this.tbxBasePrice.TextChanged += new System.EventHandler(this.tbxBasePrice_TextChanged);
            // 
            // lblEventName
            // 
            this.lblEventName.AutoSize = true;
            this.lblEventName.Location = new System.Drawing.Point(34, 38);
            this.lblEventName.Name = "lblEventName";
            this.lblEventName.Size = new System.Drawing.Size(117, 13);
            this.lblEventName.TabIndex = 6;
            this.lblEventName.Text = "Enter new event name:";
            // 
            // lblBasePrice
            // 
            this.lblBasePrice.AutoSize = true;
            this.lblBasePrice.Location = new System.Drawing.Point(34, 80);
            this.lblBasePrice.Name = "lblBasePrice";
            this.lblBasePrice.Size = new System.Drawing.Size(116, 13);
            this.lblBasePrice.TabIndex = 7;
            this.lblBasePrice.Text = "Enter base ticket price:";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(283, 67);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 8;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // tbxFloorPrice
            // 
            this.tbxFloorPrice.Location = new System.Drawing.Point(140, 122);
            this.tbxFloorPrice.Name = "tbxFloorPrice";
            this.tbxFloorPrice.Size = new System.Drawing.Size(111, 20);
            this.tbxFloorPrice.TabIndex = 9;
            // 
            // tbxLevel2Price
            // 
            this.tbxLevel2Price.Location = new System.Drawing.Point(140, 161);
            this.tbxLevel2Price.Name = "tbxLevel2Price";
            this.tbxLevel2Price.Size = new System.Drawing.Size(111, 20);
            this.tbxLevel2Price.TabIndex = 10;
            // 
            // tbxLevel3Price
            // 
            this.tbxLevel3Price.Location = new System.Drawing.Point(140, 200);
            this.tbxLevel3Price.Name = "tbxLevel3Price";
            this.tbxLevel3Price.Size = new System.Drawing.Size(111, 20);
            this.tbxLevel3Price.TabIndex = 11;
            // 
            // ckbxFloor
            // 
            this.ckbxFloor.AutoSize = true;
            this.ckbxFloor.Location = new System.Drawing.Point(37, 122);
            this.ckbxFloor.Name = "ckbxFloor";
            this.ckbxFloor.Size = new System.Drawing.Size(52, 17);
            this.ckbxFloor.TabIndex = 13;
            this.ckbxFloor.Text = "Floor:";
            this.ckbxFloor.UseVisualStyleBackColor = true;
            // 
            // ckbxLevel2
            // 
            this.ckbxLevel2.AutoSize = true;
            this.ckbxLevel2.Location = new System.Drawing.Point(37, 161);
            this.ckbxLevel2.Name = "ckbxLevel2";
            this.ckbxLevel2.Size = new System.Drawing.Size(64, 17);
            this.ckbxLevel2.TabIndex = 14;
            this.ckbxLevel2.Text = "Level 2:";
            this.ckbxLevel2.UseVisualStyleBackColor = true;
            // 
            // ckbxLevel3
            // 
            this.ckbxLevel3.AutoSize = true;
            this.ckbxLevel3.Location = new System.Drawing.Point(37, 200);
            this.ckbxLevel3.Name = "ckbxLevel3";
            this.ckbxLevel3.Size = new System.Drawing.Size(64, 17);
            this.ckbxLevel3.TabIndex = 15;
            this.ckbxLevel3.Text = "Level 3:";
            this.ckbxLevel3.UseVisualStyleBackColor = true;
            // 
            // lblCalendar
            // 
            this.lblCalendar.AutoSize = true;
            this.lblCalendar.Location = new System.Drawing.Point(283, 47);
            this.lblCalendar.Name = "lblCalendar";
            this.lblCalendar.Size = new System.Drawing.Size(94, 13);
            this.lblCalendar.TabIndex = 16;
            this.lblCalendar.Text = "Select event date:";
            // 
            // AddEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 321);
            this.Controls.Add(this.lblCalendar);
            this.Controls.Add(this.ckbxLevel3);
            this.Controls.Add(this.ckbxLevel2);
            this.Controls.Add(this.ckbxFloor);
            this.Controls.Add(this.tbxLevel3Price);
            this.Controls.Add(this.tbxLevel2Price);
            this.Controls.Add(this.tbxFloorPrice);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.lblBasePrice);
            this.Controls.Add(this.lblEventName);
            this.Controls.Add(this.tbxBasePrice);
            this.Controls.Add(this.tbxEventName);
            this.Controls.Add(this.btnReturns);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnAddEvent);
            this.Controls.Add(this.btnClear);
            this.Name = "AddEventForm";
            this.Text = "Add Event";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAddEvent;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnReturns;
        private System.Windows.Forms.TextBox tbxEventName;
        private System.Windows.Forms.TextBox tbxBasePrice;
        private System.Windows.Forms.Label lblEventName;
        private System.Windows.Forms.Label lblBasePrice;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.TextBox tbxFloorPrice;
        private System.Windows.Forms.TextBox tbxLevel2Price;
        private System.Windows.Forms.TextBox tbxLevel3Price;
        private System.Windows.Forms.CheckBox ckbxFloor;
        private System.Windows.Forms.CheckBox ckbxLevel2;
        private System.Windows.Forms.CheckBox ckbxLevel3;
        private System.Windows.Forms.Label lblCalendar;
    }
}