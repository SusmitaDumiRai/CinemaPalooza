using MetroFramework.Forms;
using System;
using System.Windows.Forms;
using MetroFramework;

namespace EmployeeApp
{
    public partial class frmLogin : MetroForm
    {

        //Start variables
        private frmLoginController loginController;
        //End variables

        public frmLogin()
        {
            InitializeComponent();
        }
        
        //Validations login info
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Checks to see if it is empty
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                //Instantiate login controller
                loginController = new frmLoginController(this, txtUsername.Text, txtPassword.Text);

                //Check to see if login details are correct
                if (loginController.authenticateLogin())
                {
                    this.Hide();
                    frmMain frmMain = new frmMain();
                    frmMain.ShowDialog(); //Display main form.

                    //Clear textboxes
                    txtPassword.Clear();
                    txtUsername.Clear();
                    this.Show();
                }
                //Invalid login details
                else
                {
                    //Invalid login details error message
                    MetroMessageBox.Show(this, "Unauthorised login details. Please re-enter your credentials.", "Invalid password/username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //No values entered in either username textbox or password textbox.
            else
            {
                MetroMessageBox.Show(this, "Please enter your login details", "Empty login details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Clears all values entered in the text boxes.
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }
    }
}
