using System;
using System.Collections.Generic;
using EmployeeApp;
using System.Data.OleDb;
using MetroFramework.Forms;
using System.Windows.Forms;
using System.Drawing;
using MetroFramework;

namespace CustomerApp
{
    class frmSeatController
    {
        //Start variable
        private Seat seat;
        private Show show;
        private Database database;
        private MetroForm form;
        private int numberOfSeats = 0;
        private List<Button> listOfButtons = new List<Button>();
        private List<int> seatID = new List<int>();
        private List<bool> seatAvailability = new List<bool>();
        private int showID;
        private int reservationID;
        //End variables

        //Constructor
        public frmSeatController(MetroForm form)
        {
            this.form = form;

            //Start instantiations
            database = new Database(form);
            show = new Show();
            //End instantiations
        }

        public frmSeatController(MetroForm form, List<int> seatID, int showID)
        {
            this.seatID = seatID;
            this.showID = showID;
            this.form = form;

            //Instantiate database
            database = new Database(form);
        }

        public frmSeatController(MetroForm form, int reservationID)
        {
            this.form = form;
            this.reservationID = reservationID;
            database = new Database(form);//Instantiate database
        }
        //End constructor

        //Creates 100 seats for a certain show.
        public void createSeat(int showID)
        {
            //Loops 100 times.
            for (int i = 1; i < 101; i++)
            {
                //If the seat is on the outside, the seat type is OLD.
                if (i % 10 == 1 || i % 10 == 0)
                {
                    seat = new Seat(i, showID, "OLD", true);

                }
                //If the seat is in the middle 2 rows, the seat type is PREMIUM.
                else if (i % 10 == 5 || i % 10 == 6)
                {
                    seat = new Seat(i, showID, "PREMIUM", true);
                }
                //Any other seats are considered NORMAL.
                else
                {
                    seat = new Seat(i, showID, "NORMAL", true);
                }

                //Adds the seat to the database.
                string DDL = "insert into ShowSeat(Seat_ID, Seat_Type, Seat_Availability, Show_ID) values('" + i + "','" + seat.getSetSeatType + "','" + 0 + "','" + showID + "')";
                OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());
                database.runCommand(command); //Executes the SQL.
            }

        }

        //Gets the availability of all seats for a show.
        public void getSeatAvailability(int showID)
        {
            //Gets availability of all seats for a certain show.
            string DDL = "Select seat_availability from showseat where show_ID = " + showID;
            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());
            seatAvailability = database.getSeatAvailability(command); //Executes the SQL statement.
        }

        //Creates 100 seat at run time. Formats the "seats" to show their availability and seat type.
        public void displaySeat(int showID)
        {
            int i = 1;
            Button btnSeat;

            getSeatAvailability(showID); //Get availability


            //Organises the seats in a 10x10 grid.
            for (int y = 450; y > 50; y -= 40)
            {
                for (int x = 30; x < 500; x += 50)
                {
                   
                    btnSeat = new Button(); //Instantiate new button.

                    //Format the button
                    btnSeat.Location = new Point(x, y);
                    btnSeat.Width = 40;
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
                    
                    //If seats are UNAVAILABLE, they are disabled.
                    if (seatAvailability[i - 1])
                    {
                        btnSeat.FlatStyle = FlatStyle.System;
                        btnSeat.Enabled = false; //Button is disabled.
                    }

                    //Event handler
                    btnSeat.Click += new EventHandler(btnSeat_Click);

                    btnSeat.Text = Convert.ToString(i); //Set the text of the button as a number.

                    //Add to list.
                    listOfButtons.Add(btnSeat);
                    i++; //Increase i by one

                    //Add button to the form.
                    form.Controls.Add(btnSeat);
                }
            }
        }

        //Returns seat ID.
        public List<int> getSeatID()
        {
            return seatID;
        }

        //btnSeat click event
        protected void btnSeat_Click(object sender, EventArgs e)
        {

            Button btnSeat = sender as Button; //Gets the selected button.

            //Checks to see how many seats have been selected.
            if(numberOfSeats < 10)
            {
                //Checks to see if they are deselecting.
                if (btnSeat.BackColor == Color.FromArgb(255, 200, 127))
                {
                    //Resets format of button and removes the ID from the list seatID.
                    btnSeat.BackColor = Color.White;
                    numberOfSeats--;//Decreares number of seats selected.
                    seatID.Remove(Convert.ToInt16(btnSeat.Text)); //Removes the seat's ID from the list.

                }
                //Button is being selected.
                else
                {
                    //Changes the backcolour to show that it is selected.
                    btnSeat.BackColor = Color.FromArgb(255, 200, 127);
                    numberOfSeats++;    //Increases number of selected seats.
                    seatID.Add(Convert.ToInt16(btnSeat.Text));
                    //Adds the ID of the button to the list seatID.
                }
            }
            //Exceeded number of seats allowed to select.
            else
            {
                //Checks to see if they are deselecting.
                if (btnSeat.BackColor == Color.FromArgb(255, 200, 127))
                {
                    //Resets the format (deselecting.)
                    btnSeat.BackColor = Color.White;
                    numberOfSeats--; //Decrease number of selected seats.
                    seatID.Remove(Convert.ToInt16(btnSeat.Text));//Removes the seat's ID from the list.

                }
                //They are not deselecting
                //Display error message.
                else
                {
                    //Too many seats selected.
                    MetroMessageBox.Show(form, "You have selected too many seats. Please reset/de-select seats.", "Exceeding seat limit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //Getter and setter for number of seats.
        public int getSetNumberofSeat
        {
            set { this.numberOfSeats = value; }
            get { return this.numberOfSeats; }
        }

        //Resets the format of the buttons.
        public void resetButtons()
        {
            //Loops through all items in the list.
            foreach (Button btn in listOfButtons)
            {
                btn.BackColor = Color.White;  //Change back colour back to white.
            } 
        }

        //Change the seats' availability to taken for each seat selected.
        public void changeSeatAvailabilityTaken()
        {
            //Changes each seat selected to taken.
            //Loops through each item in the list.
            foreach (int seatID in this.seatID)
            {
                //Updates the seat's availability to taken in the table.
                string DDL = "UPDATE ShowSeat set seat_availability = 1 where show_id = " + showID + " and seat_id = " + seatID;
                OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());
                database.runCommand(command); //Executes the SQL.
            }
        }

        //Gets the number of seats reserved.
        public int getNumberOfSeatsReserved()
        {
            //Gets the number of seats reserved.
            return seatID.Count;
        }

        //Changes the seats' availabity to empty.
        public void changeSeatAvailabilityEmpty()
        {
            //Gets all seats' ID that were reserved in the reservation.
            string DDL = "select seat_ID from ticket where reservation_ID = " + reservationID;
            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());
            seatID = database.getSeatID(command); //Execute the statement and get seat IDs.

            //Gets the show id using reservation ID.
            DDL = "select show_ID from ticket where reservation_id = " + reservationID;
            command = new OleDbCommand(DDL, database.getSetCon());
            showID = database.getShowID(command);//Execute the statement and get show ID.

            //Change seat availability to empty for the cancelled reservation.
            //Loop through each item in the list.
            foreach (int ID in seatID)
            {
                //Changes seat's availability to empty for a certain seat for a show.
                DDL = "UPDATE ShowSeat set seat_availability = 0 where show_id = " + showID + " and seat_id = " + ID;
                command = new OleDbCommand(DDL, database.getSetCon());
                database.runCommand(command); //Executes the statement. Change seats to empty
            }
        }

       
    }
}
