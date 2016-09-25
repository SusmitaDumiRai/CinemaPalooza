using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;

namespace CustomerApp
{
    public partial class frmSelectSeat : MetroForm
    {
        //Start variables
        private frmSeatController seatController;
        private frmShowController showController;
        private int movieID;
        private DateTime date;
        private DateTime startTime;
        private int showID;
        //End variables

        //Constructor
        public frmSelectSeat(int movieID, DateTime date, DateTime startTime, int showID)
        {
            InitializeComponent();

            this.movieID = movieID;
            this.date = date;
            this.startTime = startTime;
            this.showID = showID;

            //Start instantiation
            seatController = new frmSeatController(this);
            showController = new frmShowController(this);
            //End instantiation
        }
        //End constructor

        private void frmSelectSeat_Load(object sender, EventArgs e)
        {
          //Display seats for the show.
          seatController.displaySeat(showController.getShowID(movieID, date, startTime));
        }

        //Returns to the previous form.
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); //Close this form
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //Checks to see if they want to reset.
            DialogResult dialogResult = MetroMessageBox.Show(this, "Are you sure you want to reset your selections?", "Confirm reset", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if(dialogResult == DialogResult.OK)
            {
                seatController.resetButtons();   //Resets format of the buttons
                seatController.getSetNumberofSeat = 0;  //Sets number of selected seats back to 0
                seatController.getSeatID().Clear(); //Clears all seat IDs previously stored.
            }

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //Checks to see if they have selected atleast one seat.
            if(seatController.getSeatID().Count > 0)
            {
                //Checks to see if they are happy with their selections.
                DialogResult dialogResult = MetroMessageBox.Show(this, "Please confirm that you are happy with your desired seats.", "Confirm seat selection", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(dialogResult == DialogResult.Yes)
                {
                    this.Hide();
                    frmLoginRegister frmLogin = new frmLoginRegister(seatController.getSeatID(), showID); 
                    frmLogin.ShowDialog();//Display login form.
                    this.Show();
                   
                }
            }
            //No seats are selected.
            else
            {
                MetroMessageBox.Show(this, "You have not selected any seats. Please choose your seats before confirming.", "Invalid seat selection.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
