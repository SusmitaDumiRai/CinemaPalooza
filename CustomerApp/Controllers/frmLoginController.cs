using MetroFramework.Forms;
using EmployeeApp;
using System.Data.OleDb;

namespace CustomerApp
{
    class frmLoginController
    {
        //Start variables
        private string username;
        private string password;
        private MetroForm form;
        Database database;
        frmEncryptionController encryptionController;
        //End variables

        //Constructor
        public frmLoginController(string username, string password, MetroForm form)
        { 
            this.username = username;
            this.password = password;
            this.form = form;

            //Start instantiations
            database = new Database(form);
            encryptionController = new frmEncryptionController();
            //End instantiations
        }
        //End constructor

        //Checks to see if the login details are correct.
        public bool authenticateLogin()
        {
            string encryptedPassword;
            //Gets customer password using their username.
            string DDL = "select customer_password from customer where customer_username = '" + username + "'";
            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());

            encryptedPassword = database.getCustomerPassword(command);  //Executes the SQL statement.

            //Decrypts the password.
            //Compares entered password with decrypted password stored in the database.
            if(password == encryptionController.encryptOrDecrypt(encryptedPassword)) 
            {
                return true;
            }
            //Password and decrypted password do not match.
            else
            {
                return false;
            }
        }
    }
}
