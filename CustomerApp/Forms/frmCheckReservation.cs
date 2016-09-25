using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;

namespace CustomerApp
{
    public partial class frmCheckReservation : MetroForm
    {
        //Start variables
        private frmLogin frmLogin;
        private frmReservationController reservationController;
        //End variables
        
        //Constructor
        public frmCheckReservation()
        {
            InitializeComponent();
        }
        //End constructor

        //Validate reservation ID
        private void btnCheck_Click(object sender, EventArgs e)
        {
            //Checks to see if it is emtpy
            if(txtReservationID.Text != "")
            {
                try
                {
                    //Checks to see if it is a number
                    int.Parse(txtReservationID.Text);
                    reservationController = new frmReservationController(this, Convert.ToInt32(txtReservationID.Text));

                    //Checks to see if the reservation ID exists.
                    if (reservationController.checkReservationID())
                    {
                        this.Hide();
                        frmLogin = new frmLogin(Convert.ToInt32(txtReservationID.Text));
                        frmLogin.ShowDialog(); //Display login form
                        txtReservationID.Clear(); //Clears all values entered in the reservation ID text box
                        this.Show();
                    }
                    //Reservation ID does not exist
                    else
                    {
                        MetroMessageBox.Show(this, "Please re-enter your reservation ID.\nThat reservation ID does not exist.", "Invalid reservation ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtReservationID.Clear();
                    }
                }
                //Reservation ID is not a number
                catch
                {
                    MetroMessageBox.Show(this, "Please re-enter your reservation ID.\n- Reservation ID has to be a number.", "Invalid reservation ID.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //Empty textbox
            else
            {
                MetroMessageBox.Show(this, "Please re-enter your reservation ID.\n- Reservation ID is empty.", "Invalid reservation ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //Returns to the previous form
        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Clear all values entered in the textbox.
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtReservationID.Clear();
        }
    }
}
