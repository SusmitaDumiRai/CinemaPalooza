namespace CustomerApp
{
    partial class frmShowMovie
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlShowMovie = new MetroFramework.Controls.MetroPanel();
            this.gridMovie = new MetroFramework.Controls.MetroGrid();
            this.btnHome = new MetroFramework.Controls.MetroButton();
            this.pnlShowMovie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMovie)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlShowMovie
            // 
            this.pnlShowMovie.Controls.Add(this.gridMovie);
            this.pnlShowMovie.HorizontalScrollbarBarColor = true;
            this.pnlShowMovie.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlShowMovie.HorizontalScrollbarSize = 12;
            this.pnlShowMovie.Location = new System.Drawing.Point(31, 94);
            this.pnlShowMovie.Margin = new System.Windows.Forms.Padding(4);
            this.pnlShowMovie.Name = "pnlShowMovie";
            this.pnlShowMovie.Size = new System.Drawing.Size(748, 196);
            this.pnlShowMovie.TabIndex = 0;
            this.pnlShowMovie.VerticalScrollbarBarColor = true;
            this.pnlShowMovie.VerticalScrollbarHighlightOnWheel = false;
            this.pnlShowMovie.VerticalScrollbarSize = 13;
            // 
            // gridMovie
            // 
            this.gridMovie.AllowUserToAddRows = false;
            this.gridMovie.AllowUserToDeleteRows = false;
            this.gridMovie.AllowUserToResizeColumns = false;
            this.gridMovie.AllowUserToResizeRows = false;
            this.gridMovie.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridMovie.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridMovie.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridMovie.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridMovie.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(37)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(201)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMovie.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridMovie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(201)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridMovie.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridMovie.EnableHeadersVisualStyles = false;
            this.gridMovie.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridMovie.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridMovie.Location = new System.Drawing.Point(1, 4);
            this.gridMovie.Margin = new System.Windows.Forms.Padding(4);
            this.gridMovie.MultiSelect = false;
            this.gridMovie.Name = "gridMovie";
            this.gridMovie.ReadOnly = true;
            this.gridMovie.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(37)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(201)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMovie.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridMovie.RowHeadersVisible = false;
            this.gridMovie.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridMovie.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMovie.Size = new System.Drawing.Size(743, 188);
            this.gridMovie.Style = MetroFramework.MetroColorStyle.Yellow;
            this.gridMovie.TabIndex = 2;
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(31, 308);
            this.btnHome.Margin = new System.Windows.Forms.Padding(4);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(141, 31);
            this.btnHome.TabIndex = 11;
            this.btnHome.Text = "Home";
            this.btnHome.UseSelectable = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // frmShowMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 355);
            this.ControlBox = false;
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.pnlShowMovie);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmShowMovie";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Yellow;
            this.Text = "Currently Showing Movies";
            this.Load += new System.EventHandler(this.frmShowMovie_Load);
            this.pnlShowMovie.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMovie)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel pnlShowMovie;
        private MetroFramework.Controls.MetroGrid gridMovie;
        private MetroFramework.Controls.MetroButton btnHome;
    }
}