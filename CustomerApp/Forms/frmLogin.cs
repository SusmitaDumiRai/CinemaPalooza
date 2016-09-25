using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;

namespace CustomerApp
{
    public partial class frmLogin : MetroForm
    {

        //Start variables
        private int reservationID;
        private frmLoginController loginController;
        private frmReservationController reservationController;
        private frmReservationDetails frmReservationDetails;
        //End variables

        //Constructor
        public frmLogin(int reservationID)
        {
            InitializeComponent();
            this.reservationID = reservationID;
        }
        //End constructor

        private void frmLogin_Load(object sender, EventArgs e)
        {
            reservationController = new frmReservationController(this); //Instantiate reservation controller.
        }

        //Returns to the previous form
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); //Close this form
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            loginController = new frmLoginController(txtUsername.Text, txtPassword.Text, this); //Instantiate login controller
            //Checks to see if values are entered in the textboxes.
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                //Checks to see if correct login details are entered.
                if (loginController.authenticateLogin())
                {
                    //Checks to see if they have made the reservation entered.
                    if (reservationController.confirmCustomerToReservationID(txtUsername.Text, reservationID))
                    {
                        //Proceeds to show them the reservation details.
                        MetroMessageBox.Show(this, "Logging in...", "Login successful", MessageBoxButtons.OK, MessageBoxIcon.Question);

                        this.Hide();
                        //Display form reservation details
                        frmReservationDetails = new frmReservationDetails(reservationID);
                        frmReservationDetails.ShowDialog(); //Display reservation details form
                        this.Show();
                    }
                    //Correct login details however the customer did not make that reservation.
                    else
                    {
                        MetroMessageBox.Show(this, "You have not made this reservation. Please ensure you enter your reservation ID.", "Wrong reservation ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close(); //Returns user back to check reservation form.
                    }

                }
                //Invalid login details
                else
                {
                    MetroMessageBox.Show(this, "Incorrect password or username. Please re-enter your login details.", "Login unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //Empty textboxes
            else
            {
                MetroMessageBox.Show(this, "Please enter your username and/or password.", "Invalid username and/or password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
