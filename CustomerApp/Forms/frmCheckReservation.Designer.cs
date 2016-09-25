namespace CustomerApp
{
    partial class frmCheckReservation
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
            this.pnlCheckReservation = new MetroFramework.Controls.MetroPanel();
            this.btnHome = new MetroFramework.Controls.MetroButton();
            this.btnReset = new MetroFramework.Controls.MetroButton();
            this.btnCheck = new MetroFramework.Controls.MetroButton();
            this.txtReservationID = new MetroFramework.Controls.MetroTextBox();
            this.lblReservationID = new MetroFramework.Controls.MetroLabel();
            this.lblInstructions = new MetroFramework.Controls.MetroLabel();
            this.pnlCheckReservation.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCheckReservation
            // 
            this.pnlCheckReservation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCheckReservation.Controls.Add(this.btnHome);
            this.pnlCheckReservation.Controls.Add(this.btnReset);
            this.pnlCheckReservation.Controls.Add(this.btnCheck);
            this.pnlCheckReservation.Controls.Add(this.txtReservationID);
            this.pnlCheckReservation.Controls.Add(this.lblReservationID);
            this.pnlCheckReservation.HorizontalScrollbarBarColor = true;
            this.pnlCheckReservation.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlCheckReservation.HorizontalScrollbarSize = 12;
            this.pnlCheckReservation.Location = new System.Drawing.Point(32, 129);
            this.pnlCheckReservation.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCheckReservation.Name = "pnlCheckReservation";
            this.pnlCheckReservation.Size = new System.Drawing.Size(682, 136);
            this.pnlCheckReservation.TabIndex = 15;
            this.pnlCheckReservation.Theme = MetroFramework.MetroThemeStyle.Light;
            this.pnlCheckReservation.VerticalScrollbarBarColor = true;
            this.pnlCheckReservation.VerticalScrollbarHighlightOnWheel = false;
            this.pnlCheckReservation.VerticalScrollbarSize = 13;
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(444, 80);
            this.btnHome.Margin = new System.Windows.Forms.Padding(4);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(172, 31);
            this.btnHome.TabIndex = 16;
            this.btnHome.Text = "Home";
            this.btnHome.UseSelectable = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(238, 80);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(172, 31);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "Reset";
            this.btnReset.UseSelectable = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(18, 80);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(4);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(172, 31);
            this.btnCheck.TabIndex = 10;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseSelectable = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // txtReservationID
            // 
            // 
            // 
            // 
            this.txtReservationID.CustomButton.Image = null;
            this.txtReservationID.CustomButton.Location = new System.Drawing.Point(395, 2);
            this.txtReservationID.CustomButton.Margin = new System.Windows.Forms.Padding(5);
            this.txtReservationID.CustomButton.Name = "";
            this.txtReservationID.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtReservationID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtReservationID.CustomButton.TabIndex = 1;
            this.txtReservationID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtReservationID.CustomButton.UseSelectable = true;
            this.txtReservationID.CustomButton.Visible = false;
            this.txtReservationID.Lines = new string[0];
            this.txtReservationID.Location = new System.Drawing.Point(195, 19);
            this.txtReservationID.Margin = new System.Windows.Forms.Padding(4);
            this.txtReservationID.MaxLength = 32767;
            this.txtReservationID.Name = "txtReservationID";
            this.txtReservationID.PasswordChar = '\0';
            this.txtReservationID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtReservationID.SelectedText = "";
            this.txtReservationID.SelectionLength = 0;
            this.txtReservationID.SelectionStart = 0;
            this.txtReservationID.Size = new System.Drawing.Size(421, 28);
            this.txtReservationID.TabIndex = 8;
            this.txtReservationID.UseSelectable = true;
            this.txtReservationID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtReservationID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblReservationID
            // 
            this.lblReservationID.AutoSize = true;
            this.lblReservationID.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblReservationID.Location = new System.Drawing.Point(18, 19);
            this.lblReservationID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReservationID.Name = "lblReservationID";
            this.lblReservationID.Size = new System.Drawing.Size(113, 20);
            this.lblReservationID.TabIndex = 7;
            this.lblReservationID.Text = "Reservation ID";
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblInstructions.Location = new System.Drawing.Point(32, 78);
            this.lblInstructions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(549, 25);
            this.lblInstructions.TabIndex = 16;
            this.lblInstructions.Text = "Please enter you reservation ID to check details for your reservation";
            // 
            // frmCheckReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 294);
            this.ControlBox = false;
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.pnlCheckReservation);
            this.Name = "frmCheckReservation";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Yellow;
            this.Text = "Check Reservation";
            this.pnlCheckReservation.ResumeLayout(false);
            this.pnlCheckReservation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel pnlCheckReservation;
        private MetroFramework.Controls.MetroButton btnCheck;
        private MetroFramework.Controls.MetroTextBox txtReservationID;
        private MetroFramework.Controls.MetroLabel lblReservationID;
        private MetroFramework.Controls.MetroButton btnReset;
        private MetroFramework.Controls.MetroButton btnHome;
        private MetroFramework.Controls.MetroLabel lblInstructions;
    }
}