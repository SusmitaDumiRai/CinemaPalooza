using System.Data.OleDb;
using MetroFramework.Forms;

namespace EmployeeApp
{
    class frmLoginController
    {
        //Start variables
        private string username;
        private string password;
        private MetroForm form;
        private Database database;
        private frmEncryptionController encryptionController;
        //End variables

        //Controller
        public frmLoginController(MetroForm form, string username, string password)
        {
            this.username = username;
            this.form = form;
            this.password = password;

            //Start instantiation
            database = new Database(form);
            encryptionController = new frmEncryptionController();
            //End instantiation
        }
        //End controller

        //Checks to see if the login details are correct.
        public bool authenticateLogin()
        {
            string encryptedPassword;
            //Get the password of the employee using their username.
            string DDL = "select employee_password from employee where employee_username = '" + username + "'";
            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());

            encryptedPassword = database.getEmployeePassword(command);  //Execute the SQL statement

            //Compares entered password with decrypted password stored in the database.
            if (password == encryptionController.encryptOrDecrypt(encryptedPassword))//Decrypts the password and compares.
            {
                return true;
            }
            //Password does not match.
            else
            {
                return false;
            }
        }
    }
}
