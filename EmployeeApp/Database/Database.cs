using System;
using System.Collections.Generic;
using MetroFramework;
using MetroFramework.Controls;
using System.Data.OleDb;
using System.Data;
using MetroFramework.Forms;
using System.Windows.Forms;

namespace EmployeeApp
{
    public class Database
    {
        //Start variables
        private OleDbConnection con = new OleDbConnection();
        private MetroForm form;
        //End variables

        //Constructor
        public Database(MetroForm form)
        {
            this.form = form;
        }
        //End constructor

        //Creates the connection and returns it.
        public OleDbConnection getSetCon()
        {
            string DBLocation = @"../../../CinemaPalooza.mdb"; //Database location.
            //Connection string
            con.ConnectionString = ("Provider = Microsoft.Jet.OLEDB.4.0;Data Source =" + DBLocation); 
            return con;
        }

        //Fills the grid with data using the SQL statement.
        public void updateGrid(string DDL, MetroGrid grid)
        {
            //Start instantiation
            OleDbDataAdapter DA = new OleDbDataAdapter(DDL, getSetCon());
            DataTable DT = new DataTable();
            //End instantiation

            try
            {
                getSetCon().Open(); //Opens connection
                DA.Fill(DT);
            }
          
            catch (Exception ex)
            {
                MetroMessageBox.Show(form, "Unsuccessful \n" + ex.Message);
            }
            grid.DataSource = DT; //Sets the data source.
            DA.Update(DT); //Updates the data adpapter.

            con.Close(); //Closes con.
        }

        //Executes the SQL statement.
        public void runCommand(OleDbCommand command)
        {
            try
            {
                getSetCon().Open(); //Open connection
                command.ExecuteNonQuery(); //Executes the command
            }
           
            catch (Exception ex)
            {
                //Error message
                MetroMessageBox.Show(form, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Clean up
                command.Dispose();
                con.Close(); 
            }
        }

        //Gets the value of the show id. 
        public int getShowID(OleDbCommand command)
        {
            int showID = 0;
            try
            {
                getSetCon().Open(); //Open con
                using (OleDbDataReader reader = command.ExecuteReader()) 
                {
                    //Reads all values.
                    while (reader.Read())
                    {
                        showID = Convert.ToInt32(reader["Show_ID"].ToString()); //Get the ID
                    }
                }
            }
            
            catch(Exception ex)
            {
                //Error message
                MetroMessageBox.Show(form, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Clean up
                command.Dispose();
                con.Close();
            }
            //Return the ID
            return showID;

        }

        //Gets the seat availability for all seats for a certain show.
        public List<bool> getSeatAvailability(OleDbCommand command)
        {
            List<bool> seatAvailability = new List<bool>(); //Instantiate seat taken
            try
            {
                getSetCon().Open(); //Open con
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) //Values being read
                    {
                        seatAvailability.Add(Convert.ToBoolean(reader["seat_availability"].ToString())); //Get all seat availabilties.
                    }
                }
            }
            catch (Exception ex)
            {
                //Error message
                MetroMessageBox.Show(form, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Clean up
                command.Dispose();
                con.Close();
            }

            //return list of seat availability.
            return seatAvailability;
        }

        //Retrieves all customer usernames registered in the database.
        public List<string> getCustomerUsername(OleDbCommand command)
        {
            List<string> customerUsername = new List<string>(); //Instantiate customer username

            try
            {
                getSetCon().Open(); //Open con
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) //Values being read
                    {
                        customerUsername.Add(reader["customer_username"].ToString()); //Adds all usernames to the list
                    }
                }
            }
            catch (Exception ex)
            {
                //Error message
                MetroMessageBox.Show(form, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Clean up
            finally
            {
                command.Dispose();
                con.Close();
            }
            //Returns the list of usernames
            return customerUsername;

        }

        //Retrieves all employee usernames registered in the database.
        public List<string> getEmployeeUsername(OleDbCommand command)
        {
            List<string> employeeUsername = new List<string>(); //Instantiate employee username

            try
            {
                getSetCon().Open(); //Open con
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) //Values being read
                    {
                        employeeUsername.Add(reader["employee_username"].ToString()); //Adds all usernames to the list
                    }
                }
            }
            catch (Exception ex)
            {
                //Error message
                MetroMessageBox.Show(form, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Clean up
            finally
            {
                command.Dispose();
                con.Close();
            }
            //Returns the list of usernames
            return employeeUsername;

        }

        //Gets the password of a certain customer.
        public string getCustomerPassword(OleDbCommand command)
        {
            string customerPassword = "";
            try
            {
                getSetCon().Open(); //Open con
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())//Values being read
                    {
                        customerPassword = reader["customer_password"].ToString(); //Gets the password
                    }
                }
            }
            
            catch (Exception ex)
            {
                //Error message
                MetroMessageBox.Show(form, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Clean up
            finally
            {
                command.Dispose();
                con.Close();
            }
            //Returns the password
            return customerPassword;
        }

        //Gets the ID of the customer.
        public int getCustomerID(OleDbCommand command)
        {
            int customerID = 0;
            try
            {
                getSetCon().Open(); //Open con
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())//Values being read
                    {
                        customerID = Convert.ToInt32(reader["customer_ID"].ToString()); //Gets the ID
                    }
                }
            }
            catch (Exception ex)
            {
                //Error message
                MetroMessageBox.Show(form, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Clean up
            finally
            {
                command.Dispose();
                con.Close();
            }
            //Returns the ID
            return customerID;
        }

        //Gets the ID of a reservation.
        public int getReservationID(OleDbCommand command)
        {
            int reservationID = 0;
            try
            {
                getSetCon().Open();//open con
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())//Values being read
                    {
                        reservationID = Convert.ToInt32(reader["Reservation_ID"].ToString()); //Gets the ID
                    }
                }
            }
            catch (Exception ex)
            {
                //Error
                MetroMessageBox.Show(form, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Clean up
            finally
            {
                command.Dispose();
                con.Close();
            }
            //Returns the ID
            return reservationID;
        }

        //Gets all ID of reservations.
        public List<int> getAllReservationID(OleDbCommand command)
        {
            List<int> allReservationID = new List<int>(); //instantiate reservation id
            try
            {
                getSetCon().Open(); //open con
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())//Values being read
                    {
                        allReservationID.Add(Convert.ToInt32(reader["Reservation_ID"].ToString())); //Gets the ID
                    }
                }
            }
            catch (Exception ex)
            {
                //error message
                MetroMessageBox.Show(form, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Clean up
            finally
            {
                command.Dispose();
                con.Close();
            }
            //Returns the list reservation ID
            return allReservationID;
        }
        
        //Gets the name of the movie
        public string getMovieName(OleDbCommand command)
        {
            string movieName = "";
            try
            {
                getSetCon().Open(); //open con
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())//Values being read
                    {
                        movieName = reader["movie_name"].ToString(); //Gets the name of the movie
                    }
                }
            }
            catch (Exception ex)
            {
                //error message
                MetroMessageBox.Show(form, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Clean up
            finally
            {
                command.Dispose();
                con.Close();
            }
            //Returns the movie name
            return movieName;
        }

        //Gets seat IDs
        public List<int> getSeatID(OleDbCommand command)
        {
            List<int> seatID = new List<int>(); //instantiate seat ID

            try
            {
                getSetCon().Open(); //open con
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())//Values being read
                    {
                        seatID.Add(Convert.ToInt32(reader["seat_id"].ToString())); //Adds all seat IDs to the list
                    }
                }
            }
            catch (Exception ex)
            {
                //Error message
                MetroMessageBox.Show(form, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Clean up
            finally
            {
                command.Dispose();
                con.Close();
            }
            //Returns the list of seat IDs.
            return seatID;
        }

        //Gets the password of a certain employee.
        public string getEmployeePassword(OleDbCommand command)
        {
            string employeePassword = "";
            try
            {
                getSetCon().Open(); //open con
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())//Values being read
                    {
                        employeePassword = reader["employee_password"].ToString(); //Gets the password
                    }
                }
            }
            catch (Exception ex)
            {
                //error message
                MetroMessageBox.Show(form, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Clean up
            finally
            {
                command.Dispose();
                con.Close();
            }
            //Returns the password
            return employeePassword;
        }

        //Gets the ID of the customer.
        public int getMovieID(OleDbCommand command)
        {
            int movieID = 0;
            try
            {
                getSetCon().Open(); //open con
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())//Values being read
                    {
                        movieID = Convert.ToInt32(reader["movie_id"].ToString()); //Gets the ID
                    }
                }
            }
            catch (Exception ex)
            {
                //Error message
                MetroMessageBox.Show(form, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Clean up
            finally
            {
                command.Dispose();
                con.Close();
            }
            //Returns the ID
            return movieID;
        }

           //Gets the rating of a movie.
        public char getMovieRating(OleDbCommand command)
        {
            char movieRating = ' ';
            try
            {
                getSetCon().Open(); //Open con
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())//Values being read
                    {
                        movieRating = Convert.ToChar(reader["movie_rating"].ToString()); //Gets the movie rating
                    }
                }
            }
            catch (Exception ex)
            {
                //Error message
                MetroMessageBox.Show(form, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Clean up
            finally
            {
                command.Dispose();
                con.Close();
            }
            //Returns the movie rating
            return movieRating;
        }

        //Gets seat IDs
        public List<DateTime> getShowStartTime(OleDbCommand command)
        {
            List<DateTime> showStartTime = new List<DateTime>(); //Instantiate show start time
            try
            {
                getSetCon().Open(); //Open con
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())//Values being read
                    {
                        showStartTime.Add(Convert.ToDateTime(reader["show_Starttime"].ToString())); //Adds all show start times to the list
                    }
                }
            }
            catch (Exception ex)
            {
                //Error message
                MetroMessageBox.Show(form, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Clean up
            finally
            {
                command.Dispose();
                con.Close();
            }
            //Returns the list of start times.
            return showStartTime;
        }
    }
}
