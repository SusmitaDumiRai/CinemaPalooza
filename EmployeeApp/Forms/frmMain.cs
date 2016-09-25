using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;

namespace EmployeeApp
{
    public partial class frmMain : MetroForm
    {
        //Start variables
        private frmMovieController movieController;
        private frmDesignController designController;
        private frmEmployeeController employeeController;
        private frmCustomerController customerController;
        private frmValidationController validationController;
        private frmDatePickerController datePickerController;
        private frmLogin frmLogin;
        private frmOverviewController overviewController;
        //End variables

        public frmMain()
        {
            InitializeComponent();
        }

        //Form load event
        private void frmMain_Load(object sender, EventArgs e)
        {
            //Start instantiation
            movieController = new frmMovieController(this, gridMovie);
            designController = new frmDesignController();
            employeeController = new frmEmployeeController(this, gridEmployee);
            customerController = new frmCustomerController(this, gridCustomer);
            validationController = new frmValidationController();
            datePickerController = new frmDatePickerController(gridCustomer);
            frmLogin = new frmLogin();
            overviewController = new frmOverviewController(this, cmbShowTimes);
            //End instantiation

            //Displays information in the grids.
            movieController.displayGrid();
            employeeController.displayGrid();
            customerController.displayGrid();

            //Does not allow changes to be made to certain columns.
            gridMovie.Columns[0].ReadOnly = true; //Movie ID
            gridEmployee.Columns[0].ReadOnly = true; //Employee ID
            gridEmployee.Columns[4].ReadOnly = true; //Employee password
            gridCustomer.Columns[0].ReadOnly = true; //Customer ID
            gridCustomer.Columns[4].ReadOnly = true; //Customer password

            //Format the design of grids.
            designController.changeFont(gridMovie); //Movie grid
            designController.changeFont(gridEmployee); //Employee grid
            designController.changeFont(gridCustomer);  //Customer grid

            //Add items to combo box
            movieController.addItemsToCmb(cmbMovieRating); //Add A, B and C to combo box in movie page.
            overviewController.addItemsToCmb(cmbShowTimes); //Add show times to the combo box in overview page.

            //Add date picker to the grid.
            datePickerController.addDatePicker();

            //Puts focus on first page of tab control.
            tabControl.SelectedTab = tabControl.TabPages["tabPageOverview"];

        }

        //Start overview page
        private void cmbShowTimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Removes all buttons that may have been added.
            List<Button> itemsToRemove = new List<Button>();
            foreach (Button Button in tabPageOverview.Controls.OfType<Button>())
            {
                itemsToRemove.Add(Button); //Adds button to the list
            }

            //Remove buttons in the list
            foreach (Button Button in itemsToRemove)
            {
                tabPageOverview.Controls.Remove(Button);
                Button.Dispose();
            }

            overviewController.createButtons(tabPageOverview); //Display buttons representing seats.

            overviewController.displayShowDetails(gridShow); //Displays show details in the grid.
        }
        //End overview page

        //Start movie page
        //Adds a new movie to the database.
        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            //Add a movie
            if (movieController.addMovie(new Movie(txtMovieName.Text, cmbMovieRating.Text), cmbMovieRating))
            {
                MetroMessageBox.Show(this, "New movie has been added.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Question);
                //Clears all selected and entered values in the textbox and combo box
                txtMovieName.Clear();
                cmbMovieRating.SelectedIndex = -1;
                movieController.displayGrid(); //Refreshes the grid.
            }
        }
        
        //Updates any changes made if they have editted it correctly in movie grid.
        private void btnUpdateMovie_Click(object sender, EventArgs e)
        {
            //Validates movie name
            if (validationController.validateEdit50(gridMovie, 1))
            {
                //Validates movie rating
                if (movieController.validateRatingEdit())
                {
                    movieController.updateData(); //Executes the procedure to update data.
                    MetroMessageBox.Show(this, "Any changes have been saved.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    movieController.displayGrid(); //Refreshes the grid.
                }
                else
                {
                    //Invalid movie rating
                    MetroMessageBox.Show(this, "You have entered an invalid movie rating. This could be because\n- You have entered nothing\n- You have not entered A, B or C\nPlease refer to the user manual for guidelines.", "Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //Invalid movie name
                MetroMessageBox.Show(this, "You have entered an invalid movie name. This could be because\n- You have selected nothing\n- The length is wrong\nPlease refer to the user manual for guidelines.", "Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //Clear all values entered/chosen in textbox/combobox in movies.
        private void btnAddMovieReset_Click(object sender, EventArgs e)
        {
            txtMovieName.Clear();
            cmbMovieRating.SelectedIndex = -1; //Reset value selected in combo box
        }

        //Allows the user to delete rows in the movie grid.
        private void btnDeleteMovie_Click(object sender, EventArgs e)
        {
            //Get the row index of selected row.
            int rowIndex = gridMovie.CurrentCell.RowIndex;

            //Executes procedure to delete data.
            movieController.deleteData(new Movie(Convert.ToInt16(gridMovie.Rows[rowIndex].Cells[0].Value)), rowIndex); 
            MetroMessageBox.Show(this, "Data has been deleted", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Question);
            movieController.displayGrid(); //Refreshes the grid.
        }
        //End movie page

        //Start employee page
        //Updates any changes made if they have editted it correctly in employee grid.
        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            //Validates columns in grid employee
            //Forename
            if (validationController.validateEdit30(gridEmployee, 1))
            {
                //Surname
                if (validationController.validateEdit30(gridEmployee, 2))
                {
                    //Username
                    if (validationController.validateEdit30(gridEmployee, 3))
                    {
                        //Checks to see if the username is unique
                        if (validationController.distinctUsername(gridEmployee))
                        {
                            //Password
                            if (validationController.validateEdit30(gridEmployee, 4))
                            {
                                //TelephoneNumber
                                if (validationController.validateEdit11(gridEmployee, 5))
                                {
                                    employeeController.updateData(); //Executes procedure to update data.
                                    MetroMessageBox.Show(this, "Any changes have been saved.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Question);
                                    employeeController.displayGrid(); //Refreshes grid.
                                }
                                else
                                {
                                    //Invalid telephone number
                                    MetroMessageBox.Show(this, "You have entered an invalid telephone number. This could be because\n- You have entered nothing\n- The length is incorrect\n- It is not a number\nPlease refer to the user manual for guidelines.", "Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                //Invalid password
                                MetroMessageBox.Show(this, "You have entered an invalid password. This could be because\n- You have entered nothing\n- The length is incorrect\nPlease refer to the user manual for guidelines.", "Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            //Duplicate username
                            MetroMessageBox.Show(this, "You have entered a duplicate username.\nPlease refer to the user manual for guidelines.", "Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    else
                    {
                        //Invalid username
                        MetroMessageBox.Show(this, "You have entered an invalid username. This could be because\n- You have entered nothing\n- The length is incorrect\nPlease refer to the user manual for guidelines.", "Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    //Invalid surname
                    MetroMessageBox.Show(this, "You have entered an invalid surname. This could be because\n- You have entered nothing\n- The length is incorrect\nPlease refer to the user manual for guidelines.", "Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //Invalid forename
                MetroMessageBox.Show(this, "You have entered an invalid forename. This could be because\n- You have entered nothing\n- The length is incorrect\nPlease refer to the user manual for guidelines.", "Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        //Allows the user to delete rows in the employee grid.
        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            //Get the row index of selected row.
            int rowIndex = gridEmployee.CurrentCell.RowIndex;

            //Delete employee
            employeeController.deleteData(new Employee(Convert.ToInt16(gridEmployee.Rows[rowIndex].Cells[0].Value)), rowIndex); //Executes the procedure to delete data.
            MetroMessageBox.Show(this, "Data has been deleted", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Question);

            employeeController.displayGrid(); //Refreshes the grid.
        }

        //Allows a new employee to register
        private void btnRegisterEmployee_Click(object sender, EventArgs e)
        {
            //Validates employee information
            if(employeeController.addEmployee(new Employee(txtForename.Text, txtSurname.Text, txtUsername.Text, txtPassword.Text, txtTelephoneNumber.Text))) //Adds an employee
            {
                MetroMessageBox.Show(this, "New employee has been registered.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Question);
                employeeController.displayGrid(); //Refresh grid.

                //Clears all values in the textboxes.
                txtForename.Clear();
                txtSurname.Clear();
                txtUsername.Clear();
                txtPassword.Clear();
                txtTelephoneNumber.Clear();
            }

        }

        //Clears all values entered in textbox
        private void btnResetRegister_Click(object sender, EventArgs e)
        {
            txtForename.Clear();
            txtSurname.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtTelephoneNumber.Clear();
        }
        //End employee page

        //Start customer page
        //Changes column 7 (Customer DOB) to a date time picker.
        private void gridCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Displays date time picker if they have selected customerDOB column.
            if (e.ColumnIndex == 7)
            {
                //Customise size and location of the date picker.
                Rectangle cellRectangle = gridCustomer.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                datePickerController.getSetDatePicker.Location = cellRectangle.Location;
                datePickerController.getSetDatePicker.Width = cellRectangle.Width;

                try
                {
                    //Set date time picker's value to the value in the selected cell.
                    datePickerController.getSetDatePicker.Value = DateTime.Parse(gridCustomer.CurrentCell.Value.ToString());
                }
                //If value cannot be converted to date/time - set the value to now.
                catch
                {
                    datePickerController.getSetDatePicker.Value = DateTime.Now;
                }

                datePickerController.getSetDatePicker.Visible = true; //Display date time picker
            }
            //Column 7 was not selected.
            else
            {
                datePickerController.getSetDatePicker.Visible = false; //Hide date time picker
            }
        }

        //Updates any changes made if they have editted it correctly in customer grid.
        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            //Validates columns in grid customer
            //Forename
            if (validationController.validateEdit30(gridCustomer, 1))
            {
                //Surname
                if(validationController.validateEdit30(gridCustomer, 2))
                {
                    //Username
                    if(validationController.validateEdit30(gridCustomer, 3))
                    {
                        //Duplicate username check
                        if (validationController.distinctUsername(gridCustomer))
                        {
                            //Password
                            if (validationController.validateEdit30(gridCustomer, 4))
                            {
                                //Email address
                                if (validationController.validateEdit40(gridCustomer, 5))
                                {
                                    //Telephone number
                                    if (validationController.validateEdit11(gridCustomer, 6))
                                    {
                                        //Address
                                        if (validationController.validateEdit50(gridCustomer, 8))
                                        {
                                            //Postcode
                                            if (validationController.validateEdit7(gridCustomer, 9))
                                            {
                                                //Reflect the changes in the database.
                                                customerController.updateData();
                                                //Refresh the grid.
                                                customerController.displayGrid();
                                                MetroMessageBox.Show(this, "Any changes have been saved.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Question);

                                            }
                                            else
                                            {
                                                //invalid postcode
                                                MetroMessageBox.Show(this, "You have entered an invalid postcode. This could be because\n- You have entered nothing\n- The length is incorrect\nPlease refer to the user manual for guidelines.", "Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                            }
                                        }
                                        else
                                        {
                                            //invalid address
                                            MetroMessageBox.Show(this, "You have entered an invalid address. This could be because\n- You have entered nothing\n- The length is incorrect\nPlease refer to the user manual for guidelines.", "Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                        }
                                    }
                                    else
                                    {
                                        //invalid telephone number
                                        MetroMessageBox.Show(this, "You have entered an invalid telephone number. This could be because\n- You have entered nothing\n- The length is incorrect\n- It is not a number\nPlease refer to the user manual for guidelines.", "Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    }
                                }
                                else
                                {
                                    //invalid email address
                                    MetroMessageBox.Show(this, "You have entered an invalid email address. This could be because\n- You have entered nothing\n- The length is incorrect\n- The format is wrong\nPlease refer to the user manual for guidelines.", "Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }
                            }
                            else
                            {
                                //invalid password
                                MetroMessageBox.Show(this, "You have entered an invalid password. This could be because\n- You have entered nothing\n- The length is incorrect\nPlease refer to the user manual for guidelines.", "Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                        else
                        {
                            //Duplicate username entered.
                            MetroMessageBox.Show(this, "You have entered a duplicate username.\nPlease refer to the user manual for guidelines.", "Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    else
                    {
                        //invalid username
                        MetroMessageBox.Show(this, "You have entered an invalid username. This could be because\n- You have entered nothing\n- The length is incorrect\nPlease refer to the user manual for guidelines.", "Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    //invalid surname
                    MetroMessageBox.Show(this, "You have entered an invalid surname. This could be because\n- You have entered nothing\n- The length is incorrect\nPlease refer to the user manual for guidelines.", "Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                //invalid forename
                MetroMessageBox.Show(this, "You have entered an invalid forename. This could be because\n- You have entered nothing\n- The length is incorrect\nPlease refer to the user manual for guidelines.", "Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        //Allows the user to delete rows in the customer grid.
        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            //Get the row index of selected row.
            int rowIndex = gridCustomer.CurrentCell.RowIndex;

            //Delete customer.
            customerController.deleteData(new Customer(Convert.ToInt16(gridCustomer.Rows[rowIndex].Cells[0].Value)), rowIndex);
            MetroMessageBox.Show(this, "Data has been deleted", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Question);
            customerController.displayGrid(); //Refresh the grid.
        }
        //End customer page

        //Start logout page
        //Checks to see if they press logout.
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl.SelectedTab == tabControl.TabPages["tabPageLogout"]) //If they are logging out.
            {
                DialogResult dialogResult = MetroMessageBox.Show(this, "Are you sure you want to log out?", "Thank you", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                //Logout confirmed - returns back to login page.
                if (dialogResult == DialogResult.Yes)
                {
                    MetroMessageBox.Show(this, "Logging out..", "");
                    this.Close(); //Closes this form
                }
                
                else
                {
                    //Redirect to first page of tab control - Overview
                    tabControl.SelectedTab = tabControl.TabPages["tabPageOverview"];
                }
            }
        }
        //End logout page

        
    }
}
