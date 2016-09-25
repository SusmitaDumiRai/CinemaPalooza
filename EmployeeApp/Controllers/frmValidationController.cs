using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace EmployeeApp
{
    class frmValidationController
    {
        //Validates the column of a certain grid with a field size of 11.
        //Checks to see if it is empty
        //Checks its length - it has to be 11.
        //Checks if it is a number
        public bool validateEdit11(MetroGrid grid, int column)
        {
            string value;
            bool validateValue = false;
            //Loop through each row in the grid.
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                value = Convert.ToString(grid.Rows[i].Cells[column].Value); //Get value of cell[i, column]
                //Value cannot be empty.
                if (value != "")
                {
                    //Value needs to be 11
                    if (value.Length != 11)
                    {
                        //Value's length is not 11.
                        return false;
                    }
                    //Value's length is 11
                    else
                    {
                        //Checks to see if it is a number
                        try
                        {
                            Int64.Parse(value);
                            validateValue = true;
                        }
                        //Value is not a number
                        catch
                        {
                            return false;
                        }
                    }
                }
                //Value is empty.
                else
                {
                    return false;
                }
            }
            
            return validateValue;
        }

        //Validates the column of a certain grid with a field size of 30.
        //Checks to see if it is empty
        //Checks its length
        public bool validateEdit30(MetroGrid grid, int column)
        {
            string value;
            bool validateValue = false;
            //Loop through each row in the list.
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                value = Convert.ToString(grid.Rows[i].Cells[column].Value);//Get value of cell[i, column]
                //Value cannot be empty.
                if (value != "")
                {
                    //Value cannot exceed over 30.
                    if (value.Length > 30)
                    {
                        //Value's length is greater than 30.
                        return false;
                    }
                    //Value is less than 30.
                    else
                    {
                        validateValue = true;
                    }
                }
                
                //Value is empty  
                else
                {                 
                    return false;
                }
            }
            return validateValue;
        }

        //Validates the column of a certain grid with a field size of 50.
        //Checks to see if it is empty
        //Checks its length
        public bool validateEdit50(MetroGrid grid, int column)
        {
            string value;
            bool validateValue = false;
            //Loop through each row in the grid.
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                value = Convert.ToString(grid.Rows[i].Cells[column].Value);  //Get value of cell[i, column]
                //Value cannot be empty.
                if (value != "")
                {
                    //Value cannot exceed over 50.
                    if (value.Length > 50)
                    {
                        //Vlaue is greater than 50.
                        return false;
                    }
                    //Value does not exceed 50 length.
                    else
                    {
                        validateValue = true;
                    }
                }
                //Value is empty
                else
                {
                    return false;
                }
            }
            return validateValue;
        }

        //Validates the column of a certain grid with a field size of 40.
        //Checks to see if it is empty
        //Checks its length
        //Checks to see if it has "@"
        public bool validateEdit40(MetroGrid grid, int column)
        {
            string value;
            bool validateValue = false;
            //Loop through each row in the grid.
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                value = Convert.ToString(grid.Rows[i].Cells[column].Value);//Get value of cell[i, column]
                //Value cannot be empty.
                if (value != "")
                {
                    //Value cannot exceed over 40.
                    if (value.Length > 40)
                    {
                        //Value is greater than 40.
                        return false;
                    }
                    //Value does no exceed 40 characters.
                    else
                    {
                        try
                        {
                            //Checks to see if the value has correct email format.
                            var address = new MailAddress(value).Address;
                            validateValue = true;
                        }
                        //address is invalid
                        catch (FormatException)
                        {
                            return false;
                        }
                    }
                }
                //Value is empty
                else
                {
                    return false;
                }
            }
            return validateValue;
        }

        //Validates the column of a certain grid with a field size of 7.
        //Checks to see if it is empty
        //Checks its length
        public bool validateEdit7(MetroGrid grid, int column)
        {
            string value;
            bool validateValue = false;
            //Loop through each row in the grid.
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                value = Convert.ToString(grid.Rows[i].Cells[column].Value); //Get value of cell[i, column]
                //Value cannot be empty.
                if (value != "")
                {
                    //Value cannot exceed over 7.
                    if (value.Length > 7 && value.Length < 6)
                    {
                        //Value's length is less than 6 and greater than 7.
                        return false;
                    }
                    //Value does not exceed 7
                    else
                    {
                        validateValue = true;
                    }
                }
                //Value is empty
                else
                {
                    return false;
                }
            }
            return validateValue;
        }

        //Checks to see if they are entering a duplicate username
        public bool distinctUsername(MetroGrid grid)
        {
            List<string> usernames = new List<string>(); //Create new list
            //Loop through each row in the grid.
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                //Adds all usernames to the list
                usernames.Add(Convert.ToString(grid.Rows[i].Cells[3].Value)); //Both customer and employee the usernames are in column "3"
            }

            //Creates a copy of the list with only distinct values
            if (usernames.Count != usernames.Distinct().Count()) //Checks to see if they both have the same amount of items.
            {
                return false;
            }
            //Unique username
            else
            {
                return true;
            }
        }
    }
}
