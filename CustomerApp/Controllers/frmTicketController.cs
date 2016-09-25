using EmployeeApp;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using MetroFramework.Controls;

namespace CustomerApp
{
    class frmTicketController
    {
        //Start variables
        private Ticket ticket;
        private int showID;
        private List<int> seatID;
        private frmReservationController reservationController;
        private Reservation reservation;
        private int customerID;
        private MetroForm form;
        private Database database;  
        private MetroGrid grid;
        private double totalTicketPrice;
        //End variables

        //Constructor
        public frmTicketController(MetroForm form, List<int> seatID, int showID, int customerID, MetroGrid grid)
        {
            this.showID = showID;
            this.seatID = seatID;
            this.form = form;
            this.grid = grid;
            this.customerID = customerID;

            //Start instantiations
            reservationController = new frmReservationController(form, customerID, seatID, showID);
            reservation = new Reservation(customerID, DateTime.Now.Date);
            database = new Database(form);
            ticket = new Ticket();
            //End instantiations
        }

        public frmTicketController(MetroForm form, MetroGrid grid, int reservationID)
        {
            this.form = form;
            this.grid = grid;
            
            //Start instantiation
            ticket = new Ticket();
            database = new Database(form);
            //End instantiation

            ticket.getSetReservationID = reservationID;
        }
        //End constructor

        //Returns a ticket with details of the ticket.
        public Ticket createTicket(int seatID, double ticketPrice)
        {
            ticket.getSetShowID = showID;
            ticket.getSetSeatID = seatID;
            ticket.getSetSeatPrice = ticketPrice;
            ticket.getSetReservationID = reservationController.getReservationID(); //Gets the ID of the reservation

            saveTicket(); //Adds the ticket into the database.
            return ticket;
        }

        //Calculates the price of a ticket.
        public void calculateTicketPrice()
        {
            double ticketPrice;
            foreach (int seatID in this.seatID)
            {
                if (seatID % 10 == 1 || seatID % 10 == 0) //If the seat is considered OLD
                {
                    ticketPrice = 10; //Price is £10
                }
                else if (seatID % 10 == 5 || seatID % 10 == 6) //If the seat is considered PREMIUM
                {
                    ticketPrice = 15; //Price is £15
                }
                else //If the seat is considered NORMAL
                {
                    ticketPrice = 12.50; //Price is 12.50
                }
                //Adds the prices together.
                totalTicketPrice += ticketPrice;

                //Adds the ticket to the list of all the tickets in reservation.
                reservation.getSetReservationTicket.Add(createTicket(seatID, ticketPrice));

            }
        }

        //Saves the ticket in the database.
        public void saveTicket()
        {
            //SQL statement inserting values into the table ticket.
            string DDL = "INSERT INTO TICKET values(" + ticket.getSetShowID +"," + ticket.getSetSeatID + "," + ticket.getSetSeatPrice+ "," + ticket.getSetReservationID + ")";
            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());
            database.runCommand(command); //Executes the SQL statement
        }

        //Displays tickets in the grid.
        public void displayTickets()
        {
            //Gets all values from the table ticket.
            string DDL = "SELECT * from ticket where reservation_id =" + ticket.getSetReservationID; //Gets all tickets for a reservation.
            database.updateGrid(DDL, grid); //Displays ticket information in the grid.
        }

        //Deletes tickets for a certain reservation.
        public void deleteTicket()
        {
            //SQL statement that deletes the ticket
            string DDL = "DELETE from ticket where reservation_id =  " + ticket.getSetReservationID;
            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());
            database.runCommand(command); //Executes the SQL statement
        }

        //Gets the total ticket price.
        public double getTotalTicketPrice()
        {
            return totalTicketPrice;
        }
    }
}
