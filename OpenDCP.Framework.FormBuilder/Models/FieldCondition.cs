using OpenDCP.Framework.FormBuilder.Constants;
using System.Collections.Generic;

namespace OpenDCP.Framework.FormBuilder.Models
{
    public class FieldCondition
    {
        public string DependentOn { get; set; }
        public string Operator { get; set; } = FieldConditionOperator.Equal;
        public List<dynamic> Values { get; set; } = new List<dynamic>();
    }
}
