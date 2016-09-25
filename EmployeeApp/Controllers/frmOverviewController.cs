using System;
using System.Collections.Generic;
using MetroFramework.Forms;
using System.Data.OleDb;
using MetroFramework.Controls;
using System.Windows.Forms;
using System.Drawing;

namespace EmployeeApp
{
    class frmOverviewController
    {
        //Start variables
        private MetroForm form;
        private Database database;
        private Button btnSeat;
        private int i = 1;
        private ComboBox comboBox;
        private List<bool> seatAvailability;
        //End variables

        //Constructor
        public frmOverviewController(MetroForm form, ComboBox comboBox)
        {
            this.form = form;
            this.comboBox = comboBox;

            //Start instantiation
            seatAvailability = new List<bool>();
            database = new Database(form);
            //End instantiation
        }
        //End constructor

        //Create 100 buttons to represent seats.
        public void createButtons(MetroTabPage tabPage)
        {
            seatAvailability = getSeatAvailability(); //Get seat availability of all seats for the show.

            //Organises the seats in a 10x10 grid.
            for (int y = 305; y > 10; y -= 32)
            {
                for (int x = 20; x < 520; x += 50)
                {

                    btnSeat = new Button(); //Instantiate a new button
                        
                    //Format the button
                    btnSeat.Location = new Point(x, y);
                    btnSeat.Width = 45;
                    btnSeat.Height = 30;
                    btnSeat.FlatStyle = FlatStyle.Flat;

                    //Appearance of OLD seats.
                    if (i % 10 == 1 || i % 10 == 0)
                    {
                        btnSeat.FlatAppearance.BorderColor = Color.FromArgb(255, 133, 0);
                    }

                    //Appearance of PREMIUM seats.
                    else if (i % 10 == 5 || i % 10 == 6)
                    {
                        btnSeat.FlatAppearance.BorderColor = Color.FromArgb(255, 186, 0);
                    }

                    if (seatAvailability[i - 1]) //Show seat is taken.
                    {
                        btnSeat.FlatStyle = FlatStyle.System;
                        btnSeat.Enabled = false; //Button is disabled.
                    }

                    btnSeat.Text = Convert.ToString(i); //Give the seat a seat number.
                    i++; //Increase seat number
                    tabPage.Controls.Add(btnSeat);  //Add button to the tab page.
                }
            }

            i = 1; //Reset seat number back to 1.
            seatAvailability.Clear(); //Reset seat availability.
        }
     
        //Gets all show times in the database.
        private List<DateTime> getAllShowTimes()
        {
            string DDL = "SELECT show_starttime from show"; //Gets all show start times in show.
            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());
            return database.getShowStartTime(command); //Executes the SQL statement and return show start time.
        }

        //Adds items to the combo box
        public void addItemsToCmb(MetroComboBox comboBox)
        {
            foreach(DateTime showTime in getAllShowTimes()) //Loops through each item in the list.
            {
                comboBox.Items.Add(showTime); //Adds the date and time.
            }
        }

        //Gets the show ID of a show. 
        private int getShowID(DateTime showTime)
        {
            //Get show ID using show start time.
            string DDL = "select show_id from show where show_starttime = #" + showTime.ToString("MM/dd/yyyy HH:mm:ss") + "#";
            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());
            return database.getShowID(command); //Return show ID.
        }

        //Gets the availability of all seats for a show.
        private List<bool> getSeatAvailability()
        {
            //Get availability of seat using show ID.
            string DDL = "Select seat_availability from showseat where show_ID = " + getShowID(Convert.ToDateTime(comboBox.SelectedItem));
            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());
            return database.getSeatAvailability(command); //Return seat availability.
        }

        //Display show details.
        public void displayShowDetails(MetroGrid grid)
        {
            //Get all show details.
            string DDL = "Select * from show where show_ID = " + getShowID(Convert.ToDateTime(comboBox.SelectedItem)); 
            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());
            database.updateGrid(DDL, grid); //Display information in the grid.
        }

    }
}
