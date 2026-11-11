using System.Collections.Generic;

namespace OpenDCP.Framework.FormBuilder.Models
{
    public class InputField
    {
        public string Label { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte FieldType { get; set; }
        public List<FieldValidationDTO> FieldValidations { get; set; } = new List<FieldValidationDTO>();
        public List<InputFieldOption> FieldOptions { get; set; } = new List<InputFieldOption>();
        public FieldSettings FieldSettings { get; set; } = new FieldSettings();
        public List<InputField> Children { get; set; } = new List<InputField>();
        public List<FieldConditionGroup> ConditionGroups { get; set; } = new List<FieldConditionGroup>();
    }
}
