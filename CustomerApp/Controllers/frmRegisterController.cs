using System;
using System.Collections.Generic;
using EmployeeApp;
using MetroFramework.Forms;
using System.Data.OleDb;
using System.Net.Mail;

namespace CustomerApp
{
    class frmRegisterController
    {
        //Start variables
        private Customer customer;
        private Database database;
        private MetroForm form;
        private frmEncryptionController encryptionController;
        //End variables

        //Constructor
        public frmRegisterController(Customer customer, MetroForm form)
        {
            this.customer = customer;
            this.form = form;

            //Start instantiations
            database = new Database(form);
            encryptionController = new frmEncryptionController();
            //End instantiations
        }
        //End constructor
        
        //Validates forename
        public bool validateForename()
        {   
            //Checks to see if it is empty
            if(customer.getSetCustomerForename != "")
            {   
                //Checks to see if the length is 30 or less.
                if(customer.getSetCustomerForename.Length <= 30)
                {
                    return true;
                }
                //Length is greater than 30
                else
                {
                    return false;
                }
            }
            //Field is empty
            else
            {
                return false;
            }
        }

        //Validates surname
        public bool validateSurname()
        {
            //Checks to see if it is empty
            if (customer.getSetCustomerSurname != "")
            {
                //Checks to see if the length is 30 or less.
                if (customer.getSetCustomerSurname.Length <= 30)
                {
                    return true;
                }
                //Surname is greater than 30.
                else
                {
                    return false;
                }
            }
            //Field is empty
            else
            {
                return false;
            }
        }

        //Validates username
        public bool validateUsername()
        {
            //Checks to see if it is empty
            if (customer.getSetCustomerUsername != "")
            {
                //Checks to see if the length is 30 or less.
                if (customer.getSetCustomerUsername.Length <= 30)
                {
                    return true;
                }
                //Username is greater than 30.
                else
                {
                    return false;
                }
            }
            //Field is empty
            else
            {
                return false;
            }
        }

        //Validates password
        public bool validatePassword()
        {
            //Checks to see if it is empty
            if (customer.getSetCustomerPassword != "")
            {
                //Checks to see if the length is 30 or less.
                if (customer.getSetCustomerPassword.Length <= 30)
                {
                    return true;
                }
                //Password is greater than 30.
                else
                {
                    return false;
                }
            }
            //Field is empty
            else
            {
                return false;
            }
        }

        //Validates email address
        public bool validateEmailAddress()
        {
            //Checks to see if it is empty
            if (customer.getSetCustomerEmailAddress != "")
            {
                //Checks to see if the length is 40 or less.
                if (customer.getSetCustomerEmailAddress.Length <= 40)
                {
                    //Checks to see if the email is in a valid format.
                    try
                    {
                        var address = new MailAddress(customer.getSetCustomerEmailAddress).Address;
                        return true;
                    }
                    //Email address is not in the valid format
                    catch
                    {
                        return false;
                    }
                  
                }
                //Length is greater than 40.
                else
                {
                    return false;
                }
            }
            //Field is empty.
            else
            {
                return false;
            }
        }

        //Validates telephone number
        public bool validateTelephoneNumber()
        {
            //Checks to see if it is empty
            if(customer.getSetCustomerTelephoneNumber != "")
            {
                //Checks to see its length
                if(customer.getSetCustomerTelephoneNumber.Length == 11)  //Mobile numbers can only be 11 digits long. (starting with 0)
                {
                    //Attempts to convert telephone number to integer
                    try
                    {
                        Int64.Parse(customer.getSetCustomerTelephoneNumber);
                        return true;
                    }
                    //Telephone number does not contain only numeric characters.
                    catch
                    {
                        return false;
                    }
                }
                return false;
            }
            return false;
        }

        //Validates address
        public bool validateAddress()
        {
            //Checks to see if it is empty
            if (customer.getSetCustomerAddress != "")
            {
                //Checks to see if the length is 50 or less.
                if (customer.getSetCustomerAddress.Length <= 50)
                {
                    return true;
                }
                //Length is greater than 50.
                else
                {
                    return false;
                }
            }
            //Field is empty.
            else
            {
                return false;
            }
        }

        //Validates postcode
        public bool validatePostcode()
        {
            //Checks to see if it is empty
            if (customer.getSetCustomerPostcode != "")
            {
                //Validates length - UK postcodes can only be 6 or 7 digits long.
                if (customer.getSetCustomerPostcode.Length <= 7 && customer.getSetCustomerPostcode.Length >= 6)
                {
                    return true;
                }
                //Postcode's length is not either 6 or 7.
                else
                {
                    return false;
                }
            }
            //Empty field.
            else
            {
                return false;
            }
        }

        //Registers a new customer
        public void registerCustomer()
        {
            //Encrypt the password
            string encryptedPassword = encryptionController.encryptOrDecrypt(customer.getSetCustomerPassword);

            //SQL for inserting into a customer table
            string DDL = "INSERT INTO CUSTOMER(customer_forename, customer_surname, customer_username, customer_password, customer_emailaddress, customer_telephonenumber, customer_dob, customer_address, customer_postcode) values('" + customer.getSetCustomerForename+ "','" + customer.getSetCustomerSurname + "','" + customer.getSetCustomerUsername +"','" + encryptedPassword + "','" + customer.getSetCustomerEmailAddress + "','" +customer.getSetCustomerTelephoneNumber + "',#" + customer.getSetCustomerDOB.Date + "#,'" + customer.getSetCustomerAddress + "','" + customer.getSetCustomerPostcode + "')";
           
            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());
            database.runCommand(command); //Executes the SQL.


        }

        //Checks to see if the username already exists
        public bool checkDuplicateUsername()
        {
            List<string> usernames = new List<string>();
            string DDL = "SELECT customer_username from customer"; //Gets all customer usernames
            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());
            usernames = database.getCustomerUsername(command); //Adds all customer usernames to the list.

            //Loops through all username in the list.
            foreach (string username in usernames)
            {
                if (username == customer.getSetCustomerUsername) //Checks to see if any usernames in the list match the username entered.
                {
                    return false;
                }
            }

            return true;
        }
    }
}
