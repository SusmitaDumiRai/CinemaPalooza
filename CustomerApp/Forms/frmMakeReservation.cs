using MetroFramework.Forms;
using System;
using System.Windows.Forms;
using EmployeeApp;
using MetroFramework;

namespace CustomerApp
{
    public partial class frmMakeReservation : MetroForm
    {

        //Start variables
        private frmMovieController movieController;
        private frmReservationController reserveController;
        private frmShowController showController;
        private frmSeatController seatController;
        private frmSelectSeat frmSelectSeat;
        //End variables

        //Constructor
        public frmMakeReservation()
        {
            InitializeComponent();
        }

        public frmMakeReservation(string username)
        {
            InitializeComponent();
        }
        //End constructor

        private void frmMakeReservation_Load(object sender, EventArgs e)
        {
            //Start instantiation
            movieController = new frmMovieController(this, gridMovie);
            reserveController = new frmReservationController(gridMovie, this);
            showController = new frmShowController(this, gridShow);
            seatController = new frmSeatController(this);
            //End instantiation

            //Display movie details in the grid
            movieController.displayGrid();

            //Format movie grid
            //Does not allow changes to be made.
            gridMovie.ReadOnly = true;
            //Hides column movie id
            gridMovie.Columns[0].Visible = false;

            //Formats the date time picker.
            formatDTP();

            //Disbale date time picker, button and combobox
            btnConfirmDateTime.Enabled = false;
            dtpDate.Enabled = false;
            cmbTime.Enabled = false;
      
            //Displays the first movie as being selected.
            lblSelectedMovie.Text = "Selected Movie: " + gridMovie.Rows[0].Cells[1].Value;
        }

        //Display the name of the movie they are selecting.
        private void gridMovie_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblSelectedMovie.Text = "Selected Movie: " + reserveController.movieSelectedName();
        }

        private void btnConfirmMovie_Click(object sender, EventArgs e)
        {
            //Disable the grid and the button.
            gridMovie.Enabled = false;
            btnConfirmMovie.Enabled = false;
            gridMovie.Style = MetroColorStyle.Silver;

            //Get the correct times for the selected movie.
            reserveController.setMovieTime(cmbTime);

            //Enable button, combobox and date time picker.
            btnConfirmDateTime.Enabled = true;
            dtpDate.Enabled = true;
            cmbTime.Enabled = true;

            //Set the selected item in combo box to be the first time.
            cmbTime.SelectedIndex = 0;
        }

        //Checks to see if a show for that date/time exists.
        //If so, continues to select seat form.
        //If not, creates a new show + the seats then continues to select seat form.
        private void btnConfirmDateTime_Click(object sender, EventArgs e)
        {
            DateTime date = dtpDate.Value; //date's value = the value selected on the date time picker.
            DateTime startTime = Convert.ToDateTime(cmbTime.Text); //Start time's value = value selected in combo box.
            startTime = date.AddHours(startTime.Hour); //Add one hour to start time
            DateTime endTime = startTime.AddHours(2); //Endtime's value =  start time + 2hours

            //Checks to see if a show exists.
            if (!showController.checkUniqueShow(reserveController.movieSelectedID(), date, startTime)) 
            {
                //Creates a show if the show does not exist.
                showController.createShow(reserveController.movieSelectedID(), date, startTime, endTime); //Create show
                seatController.createSeat(showController.getShowID(reserveController.movieSelectedID(), date, startTime)); //Create seat for that show.
            }

            //Displays the select seat form.
            frmSelectSeat = new frmSelectSeat(reserveController.movieSelectedID(), date, startTime, showController.getShowID(reserveController.movieSelectedID(), date, startTime));
            this.Hide();
            frmSelectSeat.ShowDialog(); //Display select seats form.
            this.Show();

        }

        //Resets all selections
        private void btnReset_Click(object sender, EventArgs e)
        {
            //Disable date time pickers and confirmation button for date/time.
            btnConfirmDateTime.Enabled = false;
            dtpDate.Enabled = false;
            cmbTime.Enabled = false;
            dtpDate.Value = DateTime.Today.AddDays(1);

            //Enable movie grid and movie confirmation button
            btnConfirmMovie.Enabled = true;
            gridMovie.Enabled = true;
            gridMovie.Style = MetroColorStyle.Yellow;

            //Reset the selected movie to the first movie displayed.
            gridMovie.CurrentCell = gridMovie.Rows[0].Cells[1];
            lblSelectedMovie.Text = "Selected Movie: " + gridMovie.CurrentCell.Value;

            cmbTime.Items.Clear(); //Clear all times in the time combo box.

            MetroMessageBox.Show(this, "All selections have been reset. Please start from STEP 1.", "Reset", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        //Format date time pickers.
        private void formatDTP()
        {
            //Format date time picker to show a month from tomorrow only.
            dtpDate.Value = DateTime.Today.AddDays(1);
            dtpDate.MinDate = dtpDate.Value;
            dtpDate.MaxDate = dtpDate.Value.AddMonths(1);
        }

        //Return to the previous form.
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); //Close this form
        }
    }
}
