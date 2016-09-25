using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    class Employee
    {
        //Start variables
        private int employeeID;
        private string employeeForename;
        private string employeeSurname;
        private string employeeUsername;
        private string employeePassword;
        private string employeeTelephoneNumber;
        //End variables

        //Start constructor
        public Employee(int employeeID)
        {
            this.employeeID = employeeID;
        }
        
        public Employee(string Forename, string Surname, string Username, string Password, string TelephoneNumber)
        {
            this.employeeForename = Forename;
            this.employeeSurname = Surname;
            this.employeeUsername = Username;
            this.employeePassword = Password;
            this.employeeTelephoneNumber = TelephoneNumber;
        }
        //End constructor

        //Getter and setter for employee ID.
        public int getSetEmployeeID
        {
            set { this.employeeID = value; }
            get { return this.employeeID; }
        }

        //Getter and setter for employee forname.
        public string getSetEmployeeForename
        {
            set { this.employeeForename = value; }
            get { return this.employeeForename; }
        }

        //Getter and setter for employee surname.
        public string getSetEmployeeSurname
        {
            set { this.employeeSurname = value; }
            get { return this.employeeSurname; }
        }

        //Getter and setter for employee username.
        public string getSetEmployeeUsername
        {
            set { this.employeeUsername = value; }
            get { return this.employeeUsername; }
        }

        //Getter and setter for employee password.
        public string getSetEmployeePassword
        {
            set { this.employeePassword = value; }
            get { return this.employeePassword; }
        }

        //Getter and setter for employee telephone number.
        public string getSetEmployeeTelephoneNumber
        {
            set { this.employeeTelephoneNumber = value; }
            get { return this.employeeTelephoneNumber; }
        }
    }
}
