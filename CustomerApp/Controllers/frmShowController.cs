using EmployeeApp;
using System;
using MetroFramework.Forms;
using System.Data.OleDb;
using MetroFramework.Controls;

namespace CustomerApp
{
    class frmShowController
    {
        //Start variables
        private MetroForm form;
        private Database database;
        private Show show;
        private MetroGrid grid;
        private int showID;
        private int reservationID;
        //End variables

        //Constructor
        public frmShowController(MetroForm form, MetroGrid grid)
        {
            this.form = form;
            this.grid = grid;
            //Instantiate database.
            database = new Database(form);
        }

        public frmShowController(MetroForm form)
        {
            this.form = form;
            //Instantiate database
            database = new Database(form);
        }

        public frmShowController(MetroForm form, int showID)
        {
            this.form = form;
            this.showID = showID;

            //Instantiate database
            database = new Database(form);
        }

        public frmShowController(MetroForm form, MetroGrid grid, int reservationID)
        {
            this.form = form;
            this.grid = grid;
            this.reservationID = reservationID;

            database = new Database(form); //Instantiate database.
        }
        //End constructor

        //Creates a SHOW for the selected movie.
        public void createShow(int movieID, DateTime date, DateTime startTime, DateTime endTime)
        {
            show = new Show(movieID, date, startTime, endTime); //Instantiate show
            //SQL statement for inserting new data in the table show.
            string DDL = "insert into Show(Movie_ID, Show_Date, Show_StartTime, Show_EndTime) values('" + movieID + "','" + date + "','" + startTime + "','" + endTime + "')";
            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());
            database.runCommand(command); //Executes the SQL statement.
        }

        //Checks to see if a show for that particular movie at a certain date/time already exists.
        public bool checkUniqueShow(int movieID, DateTime date, DateTime startTime)
        {
            bool showExists = true;
            //SQL statement getting all values from the table show.
            string DDL = "SELECT * FROM SHOW";
            database.updateGrid(DDL, grid); //Update gridShow to have informations of all show. The grid is invisible.

            //Checks to see if there are any shows.
            if (grid.Rows.Count > 1)
            {
                //Loops through each row in the grid.
               for(int i = 0; i < grid.Rows.Count - 1; i++)
                {
                    //If the same show exists.
                    if (movieID == Convert.ToInt16(grid.Rows[i].Cells[1].Value) && date == Convert.ToDateTime(grid.Rows[i].Cells[2].Value) && startTime.Hour - Convert.ToDateTime(grid.Rows[i].Cells[3].Value).Hour == 0)
                    {
                        showExists = true;
                        //Break the loop
                        i = grid.Rows.Count - 1;
                    }
                    //A show with the selected date/time/movie does not exist.
                    else
                    {
                        showExists = false;
                    }
                }
            }

            //There are no shows.
            else
            {
                showExists =  false;
            }

            return showExists;
        }

        //Gets the show ID for a certain show.
        public int getShowID(int movieID, DateTime date, DateTime startTime)
        {
            //SQL statement getting Show ID from table show.
            string DDL = "SELECT Show_ID FROM Show WHERE Movie_ID = " + movieID + " AND Show_Date = #" + date.ToString("MM/dd/yyyy") + "# AND Show_StartTime = #" + startTime.ToString("MM/dd/yyyy H:mm:ss") + "#";
            
            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());
            return database.getShowID(command); //Executes SQL statement and returns the value.
        }

        //Gets show ID using reservation ID
        public int getShowID2()
        {
            //Gets show ID from the table ticket using reservation ID.
            string DDL = "select show_id from ticket where reservation_id = " + reservationID;
            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());
            return database.getShowID(command); //Executes the SQl statement and returns the value.
        }

        //Display show information in the grid.
        public void displayShow(MetroGrid grid)
        {
            //SQL Statement getting all values from show using show ID.
            string DDL = "select * from show where show_id = " + showID;
            database.updateGrid(DDL, grid); //Displays show information in the grid.
        }

        //Gets the rating of a movie depending on its movie ID.
        public char getMovieRating()
        {
            //Gets the movie rating
            string DDL = "select movie_rating from show, movie where show_id = " + showID + " and show.movie_id = movie.movie_id";
            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());
            return database.getMovieRating(command); //Executes the SQL statement and returns the movie rating.
        }

    }
}
