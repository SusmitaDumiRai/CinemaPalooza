using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EmployeeApp;
using MetroFramework.Forms;
using System.Data.OleDb;

namespace CustomerApp
{
    class frmReservationController
    {
        //Start variabls
        private MetroGrid grid;
        private MetroForm form;
        private Database database;
        private int customerID;
        private List<int> seatID;
        private int showID;
        private Reservation reservation;
        private int reservationID;
        //End variables

        //Constructor
        public frmReservationController(MetroGrid grid, MetroForm form)
        {
            this.grid = grid;
            this.form = form;

            //Instantiate database
            database = new Database(form);
        }

        public frmReservationController(MetroForm form)
        {
            this.form = form;

            database = new Database(form); //Instantiate database.
        }

        public frmReservationController(MetroForm form, int customerID, List<int> seatID, int showID)
        {
            this.form = form;
            this.customerID = customerID;
            this.seatID = seatID;
            this.showID = showID;

            //Start instantiation
            reservation = new Reservation(customerID, DateTime.Now.Date);
            database = new Database(form);
            //End instantiation
        }

        public frmReservationController(MetroForm form, int reservationID)
        {
            this.reservationID = reservationID;
            this.form = form;

            //Instantiate database
            database = new Database(form);
        }
        //End Constructor

        //Get the movie ID of the selected movie in the grid.
        public int movieSelectedID()
        {
            //Currently selected row's first column = movie ID.
            int movieID = Convert.ToInt32(grid.CurrentRow.Cells[0].Value);
            return movieID;
        }

        //Get the movie name of the selected movie in the grid.
        public string movieSelectedName()
        {
            //Currently selected row's second column = movie name.
            string movieName = Convert.ToString(grid.CurrentRow.Cells[1].Value);
            return movieName;
        }

        //Gets the customer's ID
        public int getCustomerID(string username)
        {
            int customerID;

            //Gets the customer ID using their username
            string DDL = "select customer_ID from customer where customer_username = '" + username + "'";
            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());
            customerID = database.getCustomerID(command); //Execute the SQL statement.

            return customerID; // returns the ID.
        }

        //Set movie times depending on what movie is selected.
        public void setMovieTime(ComboBox cmb)
        {
            //First movie showing.
            if(grid.CurrentCell.RowIndex == 0)
            {
                cmb.Items.Add("09:00:00");
                cmb.Items.Add("15:00:00");
            }
            //Second movie showing.
            else if (grid.CurrentCell.RowIndex == 2)
            {
                cmb.Items.Add("11:00:00");
                cmb.Items.Add("17:00:00");
            }
            //Third movie showing.
            else
            {
                cmb.Items.Add("13:00:00");
                cmb.Items.Add("19:00:00");
            }
        }

        //Create a new reservation
        public void createReservation()
        {
            //Adds new information in the reservation table.
            string DDL = "INSERT into reservation(customer_id, reservation_date) values(" + reservation.getSetCustomerID + ",#" +reservation.getSetReservationDate + "#)";
            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());
            database.runCommand(command); //Executes the SQL statement.
        }

        //Gets the reservation ID of a customer.
        public int getReservationID()
        {
            //Gets reservation ID of a customer
            string DDL = "select reservation_id from reservation where customer_id = "+ reservation.getSetCustomerID + " and reservation_date = #" + reservation.getSetReservationDate + "#";
            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());
            return database.getReservationID(command); //Executes the SQL statement and returns the value.
        }
        
        //Checks to see if the reservation ID exists.
        public bool checkReservationID()
        {
            //Gets reservation ID from the table reservation
            string DDL = "SELECT reservation_id from reservation where reservation_id =" + reservationID ;
            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());

            //Checks to see if the reservation exists.
            if (database.getReservationID(command) > 0)
            {
                //Reservation exists.
                return true; 
            }
            //Reservation does not exist.
            else
            {
                return false; 
            }
        }

        //Checks to see if the customer had made the reservation
        public bool confirmCustomerToReservationID(string username, int reservationID)
        {
            //Get the ID of the customer.
            int customerID = getCustomerID(username);

            //Gets all reservations of the customer from their ID.
            string DDL = "select reservation_id from reservation where customer_id = " + customerID;
            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());
            List<int> allReservationID = database.getAllReservationID(command); //Executes the SQL statement.

            //Loops through all items in the list.
            foreach (int ID in allReservationID)
            {
                //Checks to see if any of their reservation ID matches the reservation ID entered.
                if (ID == reservationID) //If the reservation ID entered matches their reservation
                {
                    return true;
                }
            }

            //The reservation ID entered does not match theirs
            return false;
        }

        //Displays reservation details.
        public void displayReservation(MetroGrid grid)
        {
            //Gets all information from the reservation table depending on the reservation ID.
            string DDL = "Select * from reservation where reservation_id = " + reservationID;
            database.updateGrid(DDL, grid); //Adds information in the grid.
        }

        //Delete reservation
        public void deleteReservation()
        {
            //Delete row of information from the table reservation using it's ID
            string DDL = "delete from reservation where reservation_id = " + reservationID;
            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());
            database.runCommand(command); //Executes the SQL statement
        }

        //Calculates the total price for the reservation.
        public double calculateTotalPrice(double ticketTotal, int numberOfSeats, char movieRating)
        {
            //4 or more seats selected.
            if(numberOfSeats >= 4)
            {
                //10% Discount if the number of seats reserved is 4 or more.
                ticketTotal *= 0.9;
            }

            //Increases price depending on the rating of the movie.
            if(movieRating == 'A') 
            {
                ticketTotal *= 1.5;
            }
            else if (movieRating == 'B')
            {
                ticketTotal *= 1.25;
            }

            return ticketTotal;
        }

    }
}
