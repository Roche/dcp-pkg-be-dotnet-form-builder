namespace OpenDCP.Framework.FormBuilder.Models
{
    public class InputFieldOption
    {
        public string Label { get; set; }
        public string Category { get; set; }
        public string Description { get; set; } = null;
        public dynamic Value { get; set; }
    }
}
