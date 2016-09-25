using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    public class Seat
    {
        //Start variables
        private int seatID;
        //THIS DOES NOT EXIST IN DATABASE.
        //neither is it INT in class diagrams
        private int showID;
        private string seatType;
        private bool seatAvailability;
        //End variables

        //Constructor
        public Seat(int seatID, int showID, string Type, bool availability)
        {
            this.seatID = seatID;
            this.showID = showID;
            this.seatType = Type;
            this.seatAvailability = availability;
        }
        //End constructor

        //Getter and setter for seat id
        public int getSetSeatID
        {
            set { this.seatID = value; }
            get { return this.seatID; }
        }

        //Getter and setter for show id
        public int getSetShowID
        {
            set { this.showID = value; }
            get { return this.showID; }
        }

        //Getter and setter for seat type
        public string getSetSeatType
        {
            set { this.seatType = value; }
            get { return this.seatType; }
        }

        //Getter and setter for seat availability
        public bool getSetSeatAvailability
        {
            set { this.seatAvailability = value; }
            get { return this.seatAvailability; }
        }
        
    }
}
