using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    public class Movie
    {
        //Start variables
        private int movieID;
        private string movieName;
        private string movieRating;
        //End variables

        //Start constructor
        public Movie(int movieID)
        {
            this.movieID = movieID;
        }

        public Movie(string Name, string Rating)
        {
            this.movieName = Name;
            this.movieRating = Rating;
        }
        //End constructor
    
        //Getter and setter for movie id
        public int getSetMovieID
        {
            set { this.movieID = value; }
            get { return this.movieID; }
        }

        //Getter and setter for movie name
        public string getSetMovieName
        {
            set { this.movieName = value; }
            get { return this.movieName; }
        }

        //Getter and setter for movie rating
        public string getSetMovieRating
        {
            set { this.movieRating = value; }
            get { return this.movieRating; }
        }
    }
}
