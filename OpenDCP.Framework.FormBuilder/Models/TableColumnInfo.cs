using OpenDCP.Framework.FormBuilder.Constants;

namespace OpenDCP.Framework.FormBuilder.Models
{
    /// <summary>
    /// Represents configuration and metadata for a single table column.
    /// </summary>
    public class TableColumnInfo
    {
        /// <summary>
        /// Gets or sets the key matching the property name in the row data dictionary (e.g., "area").
        /// </summary>
        public string Key { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the header label displayed on the FE (e.g., "Area", "RSD").
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the data type for FE rendering (e.g., "string", "number", "dropdown").
        /// </summary>
        public string DataType { get; set; } = "string";

        /// <summary>
        /// Gets or sets a value indicating whether the column is visible in the frontend table.
        /// </summary>
        public bool IsVisible { get; set; } = true;

        /// <summary>
        /// Gets or sets the display order index of the column in the table layout.
        /// </summary>
        public int OrderIndex { get; set; }

        /// <summary>
        /// Gets or sets the functional category of the column (Metadata or Metric).
        /// </summary>
        public ColumnType ColumnType { get; set; }
    }
}
