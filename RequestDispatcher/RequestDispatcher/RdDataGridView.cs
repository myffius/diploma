using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace RequestDispatcher.Components
{
    public class RdDataGridViewCell : DataGridViewTextBoxCell
    {
        protected override void Paint(
            Graphics graphics,
            Rectangle clipBounds,
            Rectangle cellBounds,
            int rowIndex,
            DataGridViewElementStates cellState,
            object value,
            object formattedValue,
            string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            advancedBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
            advancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
            
            // Call the base class method to paint the default cell appearance.
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState,
                value, formattedValue, errorText, cellStyle,
                advancedBorderStyle, paintParts);
        }

    }
    
    public class RdDataGridViewCellColumn : DataGridViewColumn
    {
        public RdDataGridViewCellColumn()
        {
            this.CellTemplate = new RdDataGridViewCell();
        }
    }
}
