namespace Stadium_Ticketing
{
    partial class AdminReturnForm1
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Rejectedbtn = new System.Windows.Forms.Button();
            this.Approvebtn = new System.Windows.Forms.Button();
            this.logoutbtn = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(62, 94);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(337, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tickets Awaiting Approval:";
            // 
            // Rejectedbtn
            // 
            this.Rejectedbtn.Location = new System.Drawing.Point(405, 107);
            this.Rejectedbtn.Name = "Rejectedbtn";
            this.Rejectedbtn.Size = new System.Drawing.Size(75, 23);
            this.Rejectedbtn.TabIndex = 2;
            this.Rejectedbtn.Text = "Rejected";
            this.Rejectedbtn.UseVisualStyleBackColor = true;
            this.Rejectedbtn.Click += new System.EventHandler(this.Rejectedbtn_Click);
            // 
            // Approvebtn
            // 
            this.Approvebtn.Location = new System.Drawing.Point(405, 78);
            this.Approvebtn.Name = "Approvebtn";
            this.Approvebtn.Size = new System.Drawing.Size(75, 23);
            this.Approvebtn.TabIndex = 3;
            this.Approvebtn.Text = "Approved";
            this.Approvebtn.UseVisualStyleBackColor = true;
            this.Approvebtn.Click += new System.EventHandler(this.Approvebtn_Click_1);
            // 
            // logoutbtn
            // 
            this.logoutbtn.Location = new System.Drawing.Point(451, 4);
            this.logoutbtn.Name = "logoutbtn";
            this.logoutbtn.Size = new System.Drawing.Size(75, 23);
            this.logoutbtn.TabIndex = 4;
            this.logoutbtn.Text = "Logout";
            this.logoutbtn.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(451, 33);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Add Event";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // AdminReturnForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 243);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.logoutbtn);
            this.Controls.Add(this.Approvebtn);
            this.Controls.Add(this.Rejectedbtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "AdminReturnForm1";
            this.Text = "AdminReturnForm1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Rejectedbtn;
        private System.Windows.Forms.Button Approvebtn;
        private System.Windows.Forms.Button logoutbtn;
        private System.Windows.Forms.Button button4;
    }
}