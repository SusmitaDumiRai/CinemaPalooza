using MetroFramework.Controls;
using MetroFramework.Forms;
using System.Data;
using System.Data.OleDb;

namespace EmployeeApp
{
    class frmCustomerController
    {
        //Start variables
        private MetroForm form;
        private Database database;
        private MetroGrid grid;
        private frmEncryptionController encryptionController;
        //End variables

        //Constructor
        public frmCustomerController(MetroForm form, MetroGrid grid)
        {
            this.form = form;
            this.grid = grid;
            //Start instantiation
            database = new Database(this.form);
            encryptionController = new frmEncryptionController();
            //End instantiation
        }
        //End constructor
      
        //Fills the data grid view with information from the customer table in database.
        public void displayGrid()
        {
            string DDL = "select * from Customer"; //Get all values from the table customer
            database.updateGrid(DDL, grid); //Fill the grid with information from table customer.
        }
        
        //Allows changes to be made to customer data.
        public void updateData()
        {
            var dataTable = ((DataTable)grid.DataSource).GetChanges();

            //Ensures that there are data in the grid.
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                //Get all rows in the data table
                foreach (DataRow row in dataTable.Rows)
                {
                    switch (row.RowState)
                    {
                        //Checks for any data that is changed.
                        case DataRowState.Modified:
                            string DDL = "UPDATE Customer set customer_forename = @customer_forename, customer_surname = @customer_surname, customer_username = @customer_username, customer_password = @customer_password, customer_emailAddress = @Customer_EmailAddress, Customer_TelephoneNumber = @Customer_TelephoneNumber, Customer_DOB = @Customer_DOB, Customer_Address = @Customer_Address, Customer_Postcode = @Customer_Postcode where customer_id = @customer_id";
                            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());
                            //Add new parameters for all columns for customer.
                            command.Parameters.Add(new OleDbParameter("@customer_forename", row["customer_forename"]));
                            command.Parameters.Add(new OleDbParameter("@customer_surname", row["customer_surname"]));
                            command.Parameters.Add(new OleDbParameter("@customer_username", row["customer_username"]));
                            command.Parameters.Add(new OleDbParameter("@customer_password", row["customer_password"])); //Encrypt the password
                            command.Parameters.Add(new OleDbParameter("@Customer_EmailAddress", row["Customer_EmailAddress"]));
                            command.Parameters.Add(new OleDbParameter("@Customer_TelephoneNumber", row["Customer_TelephoneNumber"]));
                            command.Parameters.Add(new OleDbParameter("@Customer_DOB", row["Customer_DOB"]));
                            command.Parameters.Add(new OleDbParameter("@Customer_Address", row["Customer_Address"]));
                            command.Parameters.Add(new OleDbParameter("@Customer_Postcode", row["Customer_Postcode"]));
                            command.Parameters.Add(new OleDbParameter("@customer_id", row["customer_id"]));
                            database.runCommand(command);
                            break;
                    }
                }
                //Applies changes to the grid.
                ((DataTable)grid.DataSource).AcceptChanges();
            }
        }

        //Deletes a certain row in the grid.
        public void deleteData(Customer customer, int rowIndex)
        {
            //Removes the row from the grid.
            grid.Rows.RemoveAt(rowIndex);

            //Deletes a row from the movie database.
            string DDL = "DELETE FROM customer WHERE customer_id = " + customer.getSetCustomerID; //Delete customer using their ID
            OleDbCommand command = new OleDbCommand(DDL, database.getSetCon());
            database.runCommand(command); //Execute the SQL command
        }
    }
}
