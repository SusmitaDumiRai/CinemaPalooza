using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;
using EmployeeApp;

namespace CustomerApp
{
    public partial class frmReservationConfirmed : MetroForm
    { 
        //Start variables
        private frmReservationController reservationController;
        private frmTicketController ticketController;
        private frmSeatController seatController;
        private frmShowController showController;
        private frmMovieController movieController;
        private List<int> seatID;
        private int customerID;
        private int showID;
        //End variables

        //Constructor
        public frmReservationConfirmed(List<int> seatID, int customerID, int showID)
        {
            InitializeComponent();
           
            this.seatID = seatID;
            this.customerID = customerID;
            this.showID = showID;

            //Start instantiations
            reservationController = new frmReservationController(this, customerID, seatID, showID);
            ticketController = new frmTicketController(this, seatID, showID, customerID, gridTicket);
            seatController = new frmSeatController(this, seatID, showID);
            showController = new frmShowController(this, showID);
            //End instantiations
        }
        //End Constructor

        private void frmReservationConfirmed_Load(object sender, EventArgs e)
        {
            reservationController.createReservation(); //Creates the reservation
            seatController.changeSeatAvailabilityTaken(); //Changes availability of the selected seats to taken
            ticketController.calculateTicketPrice(); //Calculates individual prices of the seats.
            ticketController.displayTickets();  //Displays information of the tickets in the grid ticket
            showController.displayShow(gridShow); //Display show details in the grid show.

            //Gets the total price for the reservation.
            double totalPrice = reservationController.calculateTotalPrice(ticketController.getTotalTicketPrice(), seatController.getNumberOfSeatsReserved(), showController.getMovieRating());

            lblPrice.Text += totalPrice.ToString("c"); //Formats price to currency

            gridTicket.Columns[2].DefaultCellStyle.Format = "£0.00#"; //Formats column "price".

            formatGrid(); //Formats the grids

            //Instantiate movie controller
            movieController = new frmMovieController(this, Convert.ToInt16(gridShow.Rows[0].Cells[1].Value));

            //Displays name of the movie selected.
            lblMovieName.Text = "Movie selected: " + movieController.getMovieName();
        }

        //Closes the application.
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MetroMessageBox.Show(this, "Are you sure you want to log out?", "Confirm logout", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK) //Logs out if they press OK and closes the application.
            {
                MetroMessageBox.Show(this, "Thank you for making your reservation. Have a good day.", "Logging out", MessageBoxButtons.OK, MessageBoxIcon.Question);
                Environment.Exit(0);
            }
        }

        //Formats the grids
        private void formatGrid()
        {
            //Makes the selected columns invisible
            gridTicket.Columns[0].Visible = false; //Show ID
            gridShow.Columns[0].Visible = false; //Show ID
            gridShow.Columns[1].Visible = false; //Movie ID
        }
    }
}
