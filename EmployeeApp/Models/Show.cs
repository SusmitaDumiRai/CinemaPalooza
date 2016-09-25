using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    public class Show
    {
        //Start variables
        private int showID;
        //Changed this from MOVIE TO INT. Change in DOCUMENTATION
        private int movieID;
        private DateTime showDate;
        private DateTime showStartTime;
        private DateTime showEndTime;
        //This isnt needed..
        //private List<Seat> seat = new List<Seat>();
        //End variables

        //Constructor
        public Show(int movieID, DateTime Date, DateTime startTime, DateTime endTime)
        {
            this.movieID = movieID;
            this.showDate = Date;
            this.showStartTime = startTime;
            this.showEndTime = endTime;
        }

       
        public Show()
        {

        }
        //End constructor

        //Getter and setter for show id.
        public int getSetShowID
        {
            set { this.showID = value; }
            get { return this.showID; }
        }

        //Getter and setter for movie id.
        public int getSetMovieID
        {
            set { this.movieID = value; }
            get { return this.movieID; }
        }
        
        //Getter and setter for show date.
        public DateTime getSetShowDate
        {
            set { this.showDate = value; }
            get { return this.showDate; }
        }

        //Getter and setter for show start time.
        public DateTime getSetShowStartTime
        {
            set { this.showStartTime = value; }
            get { return this.showStartTime; }
        }

        //Getter and setter for show end time.
        public DateTime getSetShowEndTime
        {
            set { this.showEndTime = value; }
            get { return this.showEndTime; }
        }

        
    }
}
