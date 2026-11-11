namespace OpenDCP.Framework.FormBuilder.Models
{
    public class FieldSettings
    {
        public dynamic DefaultValue { get; set; }
        public double StepSize { get; set; }
        public string DataUrl { get; set; }
        public bool IsRepeatable { get; set; } = false;
        public bool IsReadOnly { get; set; } = false;
    }
}
