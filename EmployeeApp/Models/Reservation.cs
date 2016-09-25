using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    public class Reservation
    {
        //Start variables
        private int reservationID;
        private int customerID;
        private DateTime reservationDate;
        private List<Ticket> reservationTicket = new List<Ticket>();
        //End variables

        //Constructor
        public Reservation(int customerID, DateTime reservationDate)
        {
            this.customerID = customerID;
            this.reservationDate = reservationDate;

        }
        //End constructors

        //Getter and setter for reservation id
        public int getSetReservationID
        {
            set { this.reservationID = value; }
            get { return this.reservationID; }
        }

        //Getter and setter for customer ID
        public int getSetCustomerID
        {
            set { this.customerID = value; }
            get { return this.customerID; }
        }

        //Getter and setter for reservation date
        public DateTime getSetReservationDate
        {
            set { this.reservationDate = value; }
            get { return this.reservationDate; }
        }

        //Getter and setter for reservation ticket
        public List<Ticket> getSetReservationTicket
        {
            set { this.reservationTicket = value; }
            get { return this.reservationTicket; }
        }
    }
}
