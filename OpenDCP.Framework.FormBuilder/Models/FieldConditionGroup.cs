using OpenDCP.Framework.FormBuilder.Constants;
using System.Collections.Generic;

namespace OpenDCP.Framework.FormBuilder.Models
{
    public class FieldConditionGroup
    {
        public LogicalOperator Operator { get; set; } = LogicalOperator.And;
        public List<FieldCondition> Conditions { get; set; } = new List<FieldCondition>();
        public FieldConditionAction Action { get; set; }
        public string LoadUrl { get; set; } = null;
        public bool LoadOnce { get; set; } = true;
    }
}
