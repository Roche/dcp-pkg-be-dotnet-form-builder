namespace OpenDCP.Framework.FormBuilder.Constants
{
    /// <summary>
    /// Defines the category or type of table column.
    /// </summary>
    public enum ColumnType : byte
    {
        /// <summary>
        /// Represents non-metric descriptive data (e.g., area, category, site).
        /// </summary>
        Metadata = 1,

        /// <summary>
        /// Represents calculated or measured numerical values (e.g., RSD, mean, duration).
        /// </summary>
        Metric = 2,

        /// <summary>
        /// Represents user-submitted or assessment answer data.
        /// </summary>
        Answer = 3
    }
}
