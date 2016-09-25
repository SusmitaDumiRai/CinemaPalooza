using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    public class Customer
    {
        //Start variables
        private int customerID;
        private string customerForename;
        private string customerSurname;
        private string customerUsername;
        private string customerPassword;
        private string customerEmailAddress;
        private string customerTelephoneNumber;
        private DateTime customerDOB;
        private string customerAddress;
        private string customerPostcode;
        //End variables

        //Start constructor
        public Customer(int customerID)
        {
            this.customerID = customerID;
        }
        
        public Customer(string forename, string surname, string username, string password, string emailAddress, string telephoneNumber, DateTime dateOfBirth, string address, string postcode) 

        {
            this.customerForename = forename;
            this.customerSurname = surname;
            this.customerUsername = username;
            this.customerPassword = password;
            this.customerEmailAddress = emailAddress;
            this.customerTelephoneNumber = telephoneNumber;
            this.customerDOB = dateOfBirth;
            this.customerAddress = address;
            this.customerPostcode = postcode;
        }
        //End constructor

        //Getter and setter for customer ID.
        public int getSetCustomerID
        {
            set { this.customerID = value; }
            get { return this.customerID; }
        }

        //Getter and setter for customer forename.
        public string getSetCustomerForename
        {
            set { this.customerForename = value; }
            get { return this.customerForename; }

        }

        //Getter and setter for customer surname.
        public string getSetCustomerSurname
        {
            set { this.customerSurname = value; }
            get { return this.customerSurname; }
        }

        //Getter and setter for customr username.
        public string getSetCustomerUsername
        {
            set { this.customerUsername = value; }
            get { return this.customerUsername; }
        }

        //Getter and setter for customer password.
        public string getSetCustomerPassword
        {
            set { this.customerPassword = value; }
            get { return this.customerPassword; }
        }

        //Getter and setter for customer email address.
        public string getSetCustomerEmailAddress
        {
            set { this.customerEmailAddress = value; }
            get { return this.customerEmailAddress; }
        }

        //Getter and setter for customer telephone number.
        public string getSetCustomerTelephoneNumber
        {
            set { this.customerTelephoneNumber = value; }
            get { return this.customerTelephoneNumber; }
        }
        
        //Getter and setter for customer DOB.
        public DateTime getSetCustomerDOB
        {
            set { this.customerDOB = value; }
            get { return this.customerDOB; }
        }

        //Getter and setter for customer address.
        public string getSetCustomerAddress
        {
            set { this.customerAddress = value; }
            get { return this.customerAddress; }
        }

        //Getter and setter for customer postcode.
        public string getSetCustomerPostcode
        {
            set { this.customerPostcode = value; }
            get { return this.customerPostcode; }
        }
    }
}
