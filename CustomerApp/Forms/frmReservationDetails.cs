using System;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace CustomerApp
{
    public partial class frmReservationDetails : MetroForm
    {
        //Start variables
        private int reservationID;
        private frmReservationController reservationController;
        private frmTicketController ticketController;
        private frmShowController showController;
        private frmMakeReservation frmMakeReservation;
        private frmSeatController seatController;
        //End variables

        //Constructor
        public frmReservationDetails(int reservationID)
        {
            InitializeComponent();

            this.reservationID = reservationID;

            //Start instantiation
            reservationController = new frmReservationController(this, reservationID);
            ticketController = new frmTicketController(this, gridTicket, reservationID);
            showController = new frmShowController(this, gridShow, reservationID);
            seatController = new frmSeatController(this, reservationID);
            //End instantiation
        }
        //End constructor

        private void frmReservationDetails_Load(object sender, EventArgs e)
        {
            //Displays details in the grids.
            reservationController.displayReservation(gridReservation); //reservation details
            ticketController.displayTickets(); // ticket details
            showController = new frmShowController(this, showController.getShowID2()); //Get show ID
            showController.displayShow(gridShow); //Show details

            //Make certain columns in the grids invisible
            gridShow.Columns[0].Visible = false; //Show ID
            gridShow.Columns[1].Visible = false; //Movie ID
            gridTicket.Columns[0].Visible = false; //Show ID


            gridTicket.Columns[2].DefaultCellStyle.Format = "£0.00#"; //Formats column "price" in the grid ticket.

        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            //Checks to see if the movie hass already been shown.
            if (Convert.ToDateTime(gridShow.Rows[0].Cells[3].Value) < DateTime.Now)
            {
                //Message saying they cannot change.
                MetroMessageBox.Show(this, "You cannot change your reservation as this movie has already been shown.", "Unable to change reservation", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
            else
            {
                //Checks to see if the customer really wants to change their reservation.
                DialogResult dialogResult = MetroMessageBox.Show(this, "Are you sure you want to change your reservation? If you press yes this reservation will be deleted.", "Reservation deletion warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.OK)
                {
                    seatController.changeSeatAvailabilityEmpty(); //Makes the seat they reserved available
                    ticketController.deleteTicket(); //Deletes the tickets that they had originally reserved.
                    reservationController.deleteReservation(); //Deletes the reservation.


                    MetroMessageBox.Show(this, "Please select the reservation details again", "Changing reservation", MessageBoxButtons.OK, MessageBoxIcon.Question);

                    this.Hide();
                    frmMakeReservation = new frmMakeReservation(); 
                    frmMakeReservation.ShowDialog(); //Display make reservation form
                    this.Show();
                }
                //Reservation change cancelled.
                else
                {
                    MetroMessageBox.Show(this, "Reservation has not been deleted.", "Changing reservation cancelled.", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Checks to see if the movie hass already been shown.
            if (Convert.ToDateTime(gridShow.Rows[0].Cells[3].Value) < DateTime.Today)
            {
                //Message saying they cannot change.
                MetroMessageBox.Show(this, "You cannot cancel your reservation as this movie has already been shown.", "Unable to cancel reservation", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                //Checks to see if the customer really wants to cancel their reservation.
                DialogResult dialogResult = MetroMessageBox.Show(this, "Are you sure you want to cancel your reservation? If you press yes this reservation will be deleted.", "Reservation deletion warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.OK)
                {
                    seatController.changeSeatAvailabilityEmpty(); //Change the selected seats' availability to empty.
                    ticketController.deleteTicket(); //Delete the tickets they had booked
                    reservationController.deleteReservation(); //Delete the reservation they had made.

                    //Make the grids invisible
                    gridReservation.Visible = false;
                    gridShow.Visible = false;
                    gridTicket.Visible = false;

                    //Disable the buttons.
                    btnChange.Enabled = false;
                    btnCancel.Enabled = false;

                    MetroMessageBox.Show(this, "Reservation has been deleted.", "Reservation cancellation successful.", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    
                }
                //Customer cancelled cancellation of reservation.
                else
                {
                    MetroMessageBox.Show(this, "Reservation has not been deleted.", "Reservation cancellation aborted.", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }

        //Close the application.
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MetroMessageBox.Show(this, "Are you sure you want to log out?", "Confirm logout", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK) //Logs out if they press OK and closes the application.
            {
                MetroMessageBox.Show(this, "Thank you for coming to Cinema Palooza. Have a good day.", "Logging out", MessageBoxButtons.OK, MessageBoxIcon.Question);
                Environment.Exit(0);
            }
        }
    }
}
