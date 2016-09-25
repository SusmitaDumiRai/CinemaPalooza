namespace CustomerApp
{
    partial class frmHomepage
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
            this.btnMakeReservation = new MetroFramework.Controls.MetroButton();
            this.btnShowMovies = new MetroFramework.Controls.MetroButton();
            this.btnCheckReservation = new MetroFramework.Controls.MetroButton();
            this.pnlHomepage = new MetroFramework.Controls.MetroPanel();
            this.pnlHomepage.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMakeReservation
            // 
            this.btnMakeReservation.Location = new System.Drawing.Point(4, 82);
            this.btnMakeReservation.Margin = new System.Windows.Forms.Padding(4);
            this.btnMakeReservation.Name = "btnMakeReservation";
            this.btnMakeReservation.Size = new System.Drawing.Size(180, 69);
            this.btnMakeReservation.Style = MetroFramework.MetroColorStyle.Black;
            this.btnMakeReservation.TabIndex = 0;
            this.btnMakeReservation.Text = "Make Reservation";
            this.btnMakeReservation.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnMakeReservation.UseSelectable = true;
            this.btnMakeReservation.UseStyleColors = true;
            this.btnMakeReservation.Click += new System.EventHandler(this.btnMakeReservation_Click);
            // 
            // btnShowMovies
            // 
            this.btnShowMovies.Location = new System.Drawing.Point(4, 6);
            this.btnShowMovies.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowMovies.Name = "btnShowMovies";
            this.btnShowMovies.Size = new System.Drawing.Size(180, 69);
            this.btnShowMovies.Style = MetroFramework.MetroColorStyle.Black;
            this.btnShowMovies.TabIndex = 1;
            this.btnShowMovies.Text = "Show Movies";
            this.btnShowMovies.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnShowMovies.UseSelectable = true;
            this.btnShowMovies.UseStyleColors = true;
            this.btnShowMovies.Click += new System.EventHandler(this.btnShowMovies_Click);
            // 
            // btnCheckReservation
            // 
            this.btnCheckReservation.Location = new System.Drawing.Point(4, 159);
            this.btnCheckReservation.Margin = new System.Windows.Forms.Padding(4);
            this.btnCheckReservation.Name = "btnCheckReservation";
            this.btnCheckReservation.Size = new System.Drawing.Size(180, 69);
            this.btnCheckReservation.Style = MetroFramework.MetroColorStyle.Black;
            this.btnCheckReservation.TabIndex = 2;
            this.btnCheckReservation.Text = "Check Reservation";
            this.btnCheckReservation.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnCheckReservation.UseSelectable = true;
            this.btnCheckReservation.UseStyleColors = true;
            this.btnCheckReservation.Click += new System.EventHandler(this.btnCheckReservation_Click);
            // 
            // pnlHomepage
            // 
            this.pnlHomepage.Controls.Add(this.btnCheckReservation);
            this.pnlHomepage.Controls.Add(this.btnShowMovies);
            this.pnlHomepage.Controls.Add(this.btnMakeReservation);
            this.pnlHomepage.HorizontalScrollbarBarColor = true;
            this.pnlHomepage.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlHomepage.HorizontalScrollbarSize = 12;
            this.pnlHomepage.Location = new System.Drawing.Point(160, 78);
            this.pnlHomepage.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHomepage.Name = "pnlHomepage";
            this.pnlHomepage.Size = new System.Drawing.Size(189, 233);
            this.pnlHomepage.TabIndex = 3;
            this.pnlHomepage.VerticalScrollbarBarColor = true;
            this.pnlHomepage.VerticalScrollbarHighlightOnWheel = false;
            this.pnlHomepage.VerticalScrollbarSize = 13;
            // 
            // frmHomepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 340);
            this.Controls.Add(this.pnlHomepage);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmHomepage";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Yellow;
            this.Text = "Welcome to CINEMA PALOOZA";
            this.pnlHomepage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnMakeReservation;
        private MetroFramework.Controls.MetroButton btnShowMovies;
        private MetroFramework.Controls.MetroButton btnCheckReservation;
        private MetroFramework.Controls.MetroPanel pnlHomepage;
    }
}

