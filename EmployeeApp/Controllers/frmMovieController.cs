using System;
using MetroFramework;
using MetroFramework.Controls;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using MetroFramework.Forms;

namespace EmployeeApp
{
    //Controls data for movie.
    public class frmMovieController
    {
        //Start variables
        private MetroForm form;
        private Database database;
        private MetroGrid grid;
        private int movieID;
        //End variables

        //Constructor
        public frmMovieController(MetroForm form, MetroGrid grid)
        {
            this.form = form;
            this.grid = grid;
            database = new Database(this.form); //Instantiate database
        }

        public frmMovieController(MetroForm form, int movieID)
        {
            this.form = form;
            this.movieID = movieID;
            database = new Database(form);//Instantiate database
        }
        //End constructor

        //Fills the data grid view with information from the movie table in database.
        public void displayGrid()
        {
            string DDL = "select * from Movie"; //Get all values from the table movie
            database.updateGrid(DDL, grid); //Fill the grid with movie information
        }

        //Add new movie to the database.
        public bool addMovie(Movie movie, MetroComboBox cmbMovieRating)
        {
            //Inserts information to movie.
            string DDL = "insert into Movie(Movie_Name, Movie_Rating) values('" + movie.getSetMovieName + "','" + movie.getSetMovieRating + "')";
            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());

            //Validates the variables first.
            if (validateName(movie) && validateRating(cmbMovieRating) && validateListing())
            {
                database.runCommand(command); //Executes the SQL statement - adds new movie
                return true;
            }
            //Validation failed
            else
            {
                return false;
            }

        }

        //Validate movie name.
        private bool validateName(Movie movie)
        {
            //Ensures that it the field isn't empty.
            if (movie.getSetMovieName != "")
            {
                //Checks to see if the length is greater than 50.
                if(movie.getSetMovieName.Length > 50)
                {
                    MetroMessageBox.Show(form, "Movie name can only be 50 characters long.", "Invalid Movie Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //Length is less than 50.
                else
                {
                    return true;
                }
            }
            //Field is empty
            else
            {
                MetroMessageBox.Show(form, "Please enter the name of the movie", "Invalid Movie Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //Validate movie rating.
        private bool validateRating(ComboBox cmbMovieRating)
        {
            //Ensures it is not empty.
            if (cmbMovieRating.SelectedIndex != -1)
            {
                return true;
            }
            //Movie rating not selected.
            else
            {
                MetroMessageBox.Show(form, "Please select a movie rating", "Invalid Movie Rating", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //Validate number of currently listed movies.
        private bool validateListing()
        {
            //Finds how many movies are currently being listed.
            //The cinema can only host 3 movies at one time.
            if (grid.RowCount < 3)
            {
                return true;
            }
            //3 movies already listed.
            else
            {
                MetroMessageBox.Show(form, "There can only be 3 movie showings at one time.\nPlease delete an old movie if you wish to add a new one.", "Exceeded number of movies.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        //Allows changes to be made to movie data.
        public void updateData()
        {
            var dataTable = ((DataTable)grid.DataSource).GetChanges();

            //Ensures that there are data in the grid.
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    switch (row.RowState)
                    {
                        //Checks for any data that is changed.
                        case DataRowState.Modified:
                            //SQL statement to update movie details.
                            string DDL = "UPDATE Movie set movie_name = @movie_name, movie_rating = @movie_rating where movie_id = @movie_id";
                            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());

                            //Add to command.
                            command.Parameters.Add(new OleDbParameter("@Movie_Name", row["movie_name"]));
                            command.Parameters.Add(new OleDbParameter("@movie_rating", row["movie_rating"]));
                            //Converts movie rating to capitals.
                            command.Parameters["@movie_rating"].Value = Convert.ToString(command.Parameters["@movie_rating"].Value).ToUpper();
                            command.Parameters.Add(new OleDbParameter("@movie_id", row["movie_id"]));

                            //Saves changes to the database.
                            database.runCommand(command);
                            break;
                    }
                }

                ((DataTable)grid.DataSource).AcceptChanges();
            }
        }

        //Validates changes made to movie rating.
        //Ensures that they have followed the movie rating regulations in the grid.
        public bool validateRatingEdit()
        {
            string movieRating;
            bool validateRating = false;
            //Loops through each row in the grid.
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                movieRating = Convert.ToString(grid.Rows[i].Cells[2].Value); //Get movie rating.
                //Value has to be A, B or C (capitalisation doesn't matter).
                if ((Convert.ToString(movieRating)).ToUpper() == "A" || (Convert.ToString(movieRating)).ToUpper() == "B" || (Convert.ToString(movieRating)).ToUpper() == "C")
                {
                    validateRating = true;
                }
                //Value was NOT A, B or C.
                else
                {
                    return false;
                }
            }
            return validateRating;
        }

        //Deletes a certain row in the grid.
         public void deleteData(Movie movie, int rowIndex)
        {
            //Removes the row from the grid.
            grid.Rows.RemoveAt(rowIndex);

            //Deletes a row from the movie database.
            string DDL = "DELETE FROM movie WHERE movie_id = " + movie.getSetMovieID;
            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());
            database.runCommand(command); //Execute SQL statement
        }

        //Adds A, B and C to a combo box.
        public void addItemsToCmb(ComboBox cmbMovieRating)
        {
            cmbMovieRating.Items.Add("A");
            cmbMovieRating.Items.Add("B");
            cmbMovieRating.Items.Add("C");
        }

        //Gets the name of the movie using movie ID.
        public string getMovieName()
        {
            string DDL = "select movie_name from movie where movie_id = " + movieID; //Get movie name using movie ID
            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());
            return database.getMovieName(command); //Execute SQL statement and return movie name.
        }
    }
}
