using MetroFramework.Forms;
using System;

namespace CustomerApp
{
    public partial class frmHomepage : MetroForm
    {
        //Start variables
        private frmShowMovie frmShowMovie;
        private frmMakeReservation frmMakeReservation;
        private frmCheckReservation frmCheckReservation;
        //End variables

        public frmHomepage()
        {
            InitializeComponent();
        }

        //Display show movie form.
        private void btnShowMovies_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmShowMovie = new frmShowMovie();
            frmShowMovie.ShowDialog(); //Display show movie form
            this.Show();
        }

        //Display make reservation form.
        private void btnMakeReservation_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMakeReservation = new frmMakeReservation();
            frmMakeReservation.ShowDialog(); //Display make reservation form
            this.Show();
        }

        //Display check reservation form.
        private void btnCheckReservation_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCheckReservation = new frmCheckReservation();
            frmCheckReservation.ShowDialog(); //Display check reservation form
            this.Show();
        }
    }
}
