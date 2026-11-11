namespace OpenDCP.Framework.FormBuilder.Models
{
    // <summary>
    /// Represents a filter criterion applied to a specific table column or property.
    /// </summary>
    public class FilterData
    {
        /// <summary>
        /// Gets or sets the target field/property name to filter by (e.g., "startTime").
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the comparison operator (e.g., "gt", "gte", "eq", "contains").
        /// </summary>
        public string Operator { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the filter value (e.g., string, number, array, or DateTime string).
        /// </summary>
        public string Value { get; set; }
    }
}
