using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    public class Ticket
    {
        //Start variables
        private int showID;
        private int seatID;
        private double seatPrice;
        private int reservationID;
        //End variables

        //Getter and setter for show id.
        public int getSetShowID
        {
            set { this.showID = value; }
            get { return this.showID; }
        }

        //Getter and setter for seat id
        public int getSetSeatID
        {
            set { this.seatID = value; }
            get { return this.seatID; }
        }

        //Getter and setter for seat price
        public double getSetSeatPrice
        {
            set { this.seatPrice = value; }
            get { return this.seatPrice; }
        }

        //Getter and setter for reservation ID
        public int getSetReservationID
        {
            set { this.reservationID = value; }
            get { return this.reservationID; }
        }
    }
}
