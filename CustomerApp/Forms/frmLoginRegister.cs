using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MetroFramework.Forms;
using EmployeeApp;
using MetroFramework;

namespace CustomerApp
{
    public partial class frmLoginRegister : MetroForm
    {
        //Start variables
        private frmEncryptionController encryptionController;
        private frmLoginController loginController;
        private frmReservationConfirmed frmReservationConfirmed;
        private frmReservationController reservationController;
        private List<int> seatID;
        private int showID;
        //End variables

        //Constructor
        public frmLoginRegister(List<int> seatID, int showID)
        {
            InitializeComponent();
            this.seatID = seatID;
            this.showID = showID;
        }
        //End constructor

        private void frmLoginRegister_Load(object sender, EventArgs e)
        {
            //Start instantations
            encryptionController = new frmEncryptionController();
            reservationController = new frmReservationController(this);
            //End instantiations
        }

        //Login button click
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Checks to see if the textboxes are empty.
            if (txtPassword.Text != "" && txtUsername.Text != "")
            {
                loginController = new frmLoginController(txtUsername.Text, txtPassword.Text, this); //Instantiate login controller

                if (loginController.authenticateLogin()) //Checks to see if the username and password match
                {
                    MetroMessageBox.Show(this, "Logging in...", "Login successful", MessageBoxButtons.OK, MessageBoxIcon.Question);

                    //Display reservation detail screen.
                    frmReservationConfirmed = new frmReservationConfirmed(seatID, reservationController.getCustomerID(txtUsername.Text), showID); //Passes all seats' IDs clicked and the ID of the customer.
                    this.Hide();
                    frmReservationConfirmed.ShowDialog(); //Display reservation confirmed form
                }
                //Invalid/mismatch username and/or password.
                else
                {
                    MetroMessageBox.Show(this, "Incorrect password or username.\nPlease re-enter your login details.", "Failed authentication", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //Empty textboxes
            else
            {
                MetroMessageBox.Show(this, "Please enter your username and\nor password.", "Failed authentication", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //Returns to the previous page
            this.Close();
        }

        //Display register form.
        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRegister frmRegister = new frmRegister();
            frmRegister.ShowDialog(); //Display register form.
            this.Show();
        }

        //Clears all values entered in the textboxes
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
            txtUsername.Clear();
        }
    }
}
