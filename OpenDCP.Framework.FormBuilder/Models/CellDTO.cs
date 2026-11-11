namespace OpenDCP.Framework.FormBuilder.Models
{
    /// <summary>
    /// Represents an individual cell within a dynamic table, including its value and display metadata.
    /// </summary>
    public class CellDTO
    {
        /// <summary>
        /// Gets or sets the dynamic value stored in the cell.
        /// </summary>
        public dynamic Value { get; set; }

        /// <summary>
        /// Gets or sets the visual status or state associated with the cell (e.g., "Warning", "Success", "Critical").
        /// </summary>
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the display color or hex code for the cell (e.g., "red", "#FF0000").
        /// </summary>
        public string Color { get; set; } = string.Empty;
    }
}
