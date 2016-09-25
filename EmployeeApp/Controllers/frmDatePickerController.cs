using MetroFramework.Controls;
using System;

using System.Windows.Forms;

namespace EmployeeApp
{
    class frmDatePickerController
    {
        //Start variable
        private MetroGrid grid;
        private DateTimePicker datePicker = new DateTimePicker();
        //End variable

        //Constructor
        public frmDatePickerController(MetroGrid grid)
        {
            this.grid = grid;
        }
        //End constructor

        //Adds the date picker to the grid and changes the value shown.
        public void addDatePicker()
        {
            datePicker.Visible = false; //Hide the date time picker

            //Formats the date time picker.
            datePicker.CustomFormat = "dd/mm/yyyy";
            datePicker.ValueChanged += datePickerValueChanged;
            grid.Controls.Add(datePicker); //Add date time picker to the grid

        }

        //Getter for date picker.
        public DateTimePicker getSetDatePicker
        {
            get { return datePicker;}
        }

        //Shows the value selected once they pick an alternative date.
        private void datePickerValueChanged(object sender, EventArgs e)
        {
            grid.CurrentCell.Value = datePicker.Value.ToString("dd/MM/yyyy"); //Set it to date time picker's value
            datePicker.Visible = false; //Hide the picker
        }

    }
}
