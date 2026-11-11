using System.Collections.Generic;

namespace OpenDCP.Framework.FormBuilder.Models
{
    /// <summary>
    /// Represents the dynamic configuration and data structure for a table field.
    /// </summary>
    public class TableField
    {
        /// <summary>
        /// Gets or sets the list of column metadata definitions for the table.
        /// </summary>
        public List<TableColumnInfo> Columns { get; set; } = new List<TableColumnInfo>();

        /// <summary>
        /// Gets or sets the list of data rows, where each row is represented as a list of cell DTOs matching the column order.
        /// </summary>
        public List<TableRowDTO> Rows { get; set; } = new List<TableRowDTO>();
    }
}
