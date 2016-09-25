using System.Drawing;
using MetroFramework.Controls;

namespace EmployeeApp
{
    //Controls how objects look likes.
    public class frmDesignController
    {
        //Changes the font size of grids.
        public void changeFont(MetroGrid grid)
        {
            //Changes grid's column's header's font size to 10. 
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("", 10.0f);
            //Changes grid's data's font size to 8.
            grid.Font = new Font("", 8.0f); 

        }
    }
}
