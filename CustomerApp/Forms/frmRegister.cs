using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using EmployeeApp;
using MetroFramework;

namespace CustomerApp
{
    public partial class frmRegister : MetroForm
    {
        //Start variables
        frmRegisterController registerController;
        
        //Constructor
        public frmRegister()
        {
            InitializeComponent();
        }
        //End constructor
        
        private void btnRegister_Click(object sender, EventArgs e)
        {
            //Instantiate register controller
            registerController = new frmRegisterController(new Customer(txtForename.Text, txtSurname.Text, txtUsername.Text, txtPassword.Text, txtEmailAddress.Text, txtTelephoneNo.Text, dtpDOB.Value, txtAddress.Text, txtPostcode.Text), this);
           
            //validate forename
            if (registerController.validateForename())
            {
                //Validate surname
                if (registerController.validateSurname())
                {
                    //Validate username
                    if (registerController.validateUsername())
                    {
                        //Checks to see if a duplicate user name already exists.
                        if (registerController.checkDuplicateUsername())
                        {
                            //Validate password
                            if (registerController.validatePassword())
                            {
                                //Validate email address
                                if (registerController.validateEmailAddress())
                                {
                                    //Validate telephone number
                                    if (registerController.validateTelephoneNumber())
                                    {
                                        //Validate address
                                        if (registerController.validateAddress())
                                        {
                                            //Validate postcode
                                            if (registerController.validatePostcode())
                                            {
                                                registerController.registerCustomer(); //Registers a new customer
                                                MetroMessageBox.Show(this, "You are now registered with Cinema Palooza.\nPlease return back to the login page and login to confirm your reservation.", "Thank you for registering", MessageBoxButtons.OK, MessageBoxIcon.Question);
                                                //Clear all boxes.
                                                txtForename.Clear();
                                                txtSurname.Clear();
                                                txtUsername.Clear();
                                                txtPassword.Clear();
                                                txtTelephoneNo.Clear();
                                                txtEmailAddress.Clear();
                                                txtAddress.Clear();
                                                txtPostcode.Clear();
                                                dtpDOB.Value = DateTime.Now.Date; //set DOB to today's date.
                                            }
                                            //Invalid postcode
                                            else
                                            {
                                                MetroMessageBox.Show(this, "Please enter a valid postcode.\n- Postcode may be empty\n- Postcode may be too long", "Invalid postcode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                        //Invalid address
                                        else
                                        {
                                            MetroMessageBox.Show(this, "Please enter a valid address.\n- Address may be empty\n- Address may be too long", "Invalid address", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    //Invalid telephone number
                                    else
                                    {
                                        MetroMessageBox.Show(this, "Please enter a telephone number.\n- Telephone number may be empty\n- Telephone number must be 11 digits long\n- Telephone number must be numbers only.", "Invalid telephone number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                }
                                //Invalid email address
                                else
                                {
                                    MetroMessageBox.Show(this, "Please enter a valid email address.\n- Email Address may be empty\n- Email address may be too long\n- Email address may not be in correct format", "Invalid email address", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            //Invalid password
                            else
                            {
                                MetroMessageBox.Show(this, "Please enter a valid password.\n- Password may be empty\n- Password may be too long", "Invalid password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        //Duplicate username entered.
                        else
                        {
                            MetroMessageBox.Show(this, "Sorry but that username already exists. Please enter a new username", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    //Invalid username
                    else
                    {
                        MetroMessageBox.Show(this, "Please enter a valid username\n- Username may be empty\n- Username may be too long", "Invalid username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //Invalid surname
                else
                {
                    MetroMessageBox.Show(this, "Please enter a valid surname\n- Surname may be empty\n- Surname may be too long", "Invalid surname", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //Invalid forename
            else
            {
                MetroMessageBox.Show(this, "Please enter a valid forename\n- Forename may be empty\n- Forename may be too long", "Invalid forename", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Return to the previous page
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); //Close this form
        }

        //Clears all values entered in the textboxes
        //Resets value chosen in the date time picker
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtForename.Clear();
            txtSurname.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtEmailAddress.Clear();
            txtTelephoneNo.Clear();
            txtAddress.Clear();
            txtPostcode.Clear();

            dtpDOB.Value = DateTime.Today; //Resets date of birth's selected value.
        }
    }
}
