using MetroFramework;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace EmployeeApp
{
    //Controls data for employee.
    class frmEmployeeController
    {
        //Start variables
        private MetroForm form;
        private Database database;
        private MetroGrid grid;
        private frmEncryptionController encryptionController;
        //End variables

        //Constructor
        public frmEmployeeController(MetroForm form, MetroGrid grid)
        {
            this.form = form;
            this.grid = grid;
            //Start instantiation
            database = new Database(this.form);
            encryptionController = new frmEncryptionController();
            //End instantiation
        }
        //End constructor

        //Fills the data grid view with information from the employee table in database.
        public void displayGrid()
        {
            string DDL = "select * from Employee"; //Get all values from the table employee
            database.updateGrid(DDL, grid); //Fill the grid with employee information
        }

        //Add new employee to the database.
        public bool addEmployee(Employee employee)
        {
            //SQL to add a new employee to the database.
            string DDL = "insert into Employee(Employee_Forename, Employee_Surname, Employee_Username, Employee_Password, Employee_TelephoneNumber) values('" + employee.getSetEmployeeForename + "','" + employee.getSetEmployeeSurname + "','" + employee.getSetEmployeeUsername + "','" + encryptionController.encryptOrDecrypt(employee.getSetEmployeePassword) + "','" +employee.getSetEmployeeTelephoneNumber + "')";
            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());
           
            //Checks to see if it passes validations.
            if (validateForename(employee) && validateSurname(employee) && validateUsername(employee) && validatePassword(employee) && validateTelephoneNumber(employee))
            {
                //Checks to see if the username already exists
                if (checkDuplicateUsername(employee))
                {
                    database.runCommand(command); //Executes the DDL and adds the employee.
                    return true;
                }
                //Username exists
                else
                {
                    return false;
                }
            }
            //Validation failed
            else
            {
                return false;
            }
        }

        //Validate employee forename.
        private bool validateForename(Employee employee)
        {
            //Ensures that it the field isn't empty.
            if (employee.getSetEmployeeForename != "")
            {
                //Checks to see the length isn't greater than 30.
                if (employee.getSetEmployeeForename.Length > 30)
                {
                    MetroMessageBox.Show(form, "Employee forename can only be 30 characters long.\nPlease refer to the user manual for guidelines.", "Invalid Forename", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //Length is greater than 30
                else
                {
                    return true;
                }
            }
            //Empty field.
            else
            {
                MetroMessageBox.Show(form, "Enter a forename.\nPlease refer to the user manual for guidelines.", "Invalid Forename", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //Validate employee surname.
        private bool validateSurname(Employee employee)
        {
            //Ensures that it the field isn't empty.
            if (employee.getSetEmployeeSurname != "")
            {
                //Checks to see the length isn't greater than 30.
                if (employee.getSetEmployeeSurname.Length > 30)
                {
                    MetroMessageBox.Show(form, "Employee surname can only be 30 characters long.\nPlease refer to the user manual for guidelines.", "Invalid Forename", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //Length is greater than 30.
                else
                {
                    return true;
                }
            }
            //Empty field
            else
            {
                MetroMessageBox.Show(form, "Enter a surname.\nPlease refer to the user manual for guidelines.", "Invalid surname", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //Validate employee username.
        private bool validateUsername(Employee employee)
        {
            //Ensures that it the field isn't empty.
            if (employee.getSetEmployeeUsername != "")
            {
                //Checks to see the length isn't greater than 30.
                if (employee.getSetEmployeeUsername.Length > 30)
                {
                    MetroMessageBox.Show(form, "Employee username can only be 30 characters long.\nPlease refer to the user manual for guidelines.", "Invalid Forename", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //Length is greater than 30
                else
                {
                    return true;
                }
            }
            //Empty field
            else
            {
                MetroMessageBox.Show(form, "Enter a username. \nPlease refer to the user manual for guidelines.", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        
        //Validate employee password.
        private bool validatePassword(Employee employee)
        {
            //Ensures that it the field isn't empty.
            if (employee.getSetEmployeePassword != "")
            { 
                //Checks to see the length isn't greater than 30.
                if (employee.getSetEmployeePassword.Length > 30)
                {
                    MetroMessageBox.Show(form, "Employee password can only be 30 characters long.\nPlease refer to the user manual for guidelines.", "Invalid Forename", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //Length is greater than 30
                else
                {
                    return true;
                }
            }
            //Empty field
            else
            {
                MetroMessageBox.Show(form, "Enter a password\nPlease refer to user manual for guidelines.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
            
        //Validate employee telephone number.
        private bool validateTelephoneNumber(Employee employee)
        {
            //Ensures that it the field isn't empty.
            if (employee.getSetEmployeeTelephoneNumber != "")
            {
                //Checks to see if the telephone number is 11 digits long..
                if(employee.getSetEmployeeTelephoneNumber.Length != 11)
                {
                    MetroMessageBox.Show(form, "Telephone number has to be 11 digits long. Please re-enter your telephone number.\nPlease refer to the user manual for guidelines.", "Invalid telephone number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //Length is exactly 11 digits long
                else
                {
                    //Checks to see if it is numbers only.
                    try
                    {
                        Int64.Parse(employee.getSetEmployeeTelephoneNumber);
                        return true;
                    }
                    //Telephone number is not only integers.
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message) ;
                        MetroMessageBox.Show(form, "Telephone number has to be numbers. Please re-enter your telephone number.\nPlease refer to the user manual for guidelines.", "Invalid telephone number", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                }
            }
            //Empty telephone number
            else
            {
                MetroMessageBox.Show(form, "Enter a telephone number. \nPlease refer to the user manual for guidelines.", "Invalid telephone number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //Allows changes to be made to employee data.
        public void updateData()
        {
            var dataTable = ((DataTable)grid.DataSource).GetChanges();

            //Ensures that there are data in the grid.
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    switch (row.RowState)
                    {
                        //Checks for any data that is changed.
                        case DataRowState.Modified:
                            string DDL = "UPDATE Employee set employee_forename = @employee_forename, employee_surname = @employee_surname, employee_username = @employee_username, employee_password = @employee_password, employee_telephonenumber = @employee_telephonenumber where employee_id = @employee_id";
                            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());

                            //Add to command.
                            command.Parameters.Add(new OleDbParameter("@employee_forename", row["employee_forename"]));
                            command.Parameters.Add(new OleDbParameter("@employee_surname", row["employee_surname"]));
                            command.Parameters.Add(new OleDbParameter("@employee_username", row["employee_username"]));
                            command.Parameters.Add(new OleDbParameter("@employee_password", row["employee_password"])); //Encrypt the password
                            command.Parameters.Add(new OleDbParameter("@employee_telephonenumber", row["employee_telephonenumber"]));
                            command.Parameters.Add(new OleDbParameter("@employee_id", row["employee_id"]));

                            //Saves changes to the database.
                            database.runCommand(command);
                            break;
                    }
                }
                //Accept changes
                ((DataTable)grid.DataSource).AcceptChanges();
            }
        }

        //Deletes a certain row in the grid.
        public void deleteData(Employee employee, int rowIndex)
        {
            //Removes the row from the grid.
            grid.Rows.RemoveAt(rowIndex);

            //Deletes a row from the employee database.
            string DDL = "DELETE FROM employee where employee_id = " + employee.getSetEmployeeID;
            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());
            database.runCommand(command); //Execute the SQL statement
        }

        //Checks to see if the username is unique
        private bool checkDuplicateUsername(Employee employee)
        {

            List<string> usernames = new List<string>();
            string DDL = "SELECT employee_username from employee"; //Gets all employee usernames
            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());
            usernames = database.getEmployeeUsername(command); //Adds all employee usernames to the list.

            //Loop through each item in the list
            foreach (string username in usernames)
            {
                //Checks to see if any usernames in the list match the username entered.
                if (username == employee.getSetEmployeeUsername)  
                {
                    //Username exists in the list.
                    MetroMessageBox.Show(form, "Duplicate user name entered. Please enter another username.", "Duplicate username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            //Username is unique
            return true;
        }
    }
}
