using System;
using MetroFramework.Forms;
using EmployeeApp;

namespace CustomerApp
{
    public partial class frmShowMovie : MetroForm
    {

        //Start variables
        Database database;
        frmMovieController movieController;
        frmDesignController designController;
        //End variables

        public frmShowMovie()
        {
            InitializeComponent();
        }

        private void frmShowMovie_Load(object sender, EventArgs e)
        {
            database = new Database(this);
            movieController = new frmMovieController(this, gridMovie);
            designController = new frmDesignController();

            //Displays information in the movie grid.
            movieController.displayGrid();

            //Hide column movie id.
            gridMovie.Columns[0].Visible = false;

            //Does not allow changes to be made.
            gridMovie.ReadOnly = true;

            //Formats the design of the grid.
            designController.changeFont(gridMovie);
        }

        //Return back to home page.
        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close(); //Close this form.
        }
    }
}
