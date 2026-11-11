using OpenDCP.Framework.FormBuilder.Constants;
using OpenDCP.Framework.FormBuilder.Models;
using System.Collections.Generic;

namespace OpenDCP.Framework.FormBuilder.Helpers
{
    public static class ConditionHelper
    {
        public static List<FieldConditionGroup> CreateShowCondition(
            string dependentOn,
            dynamic expectedValue,
            string conditionOperator = FieldConditionOperator.Equal)
        {
            return new List<FieldConditionGroup>
            {
                new FieldConditionGroup
                {
                    Action = FieldConditionAction.Show,
                    Operator = LogicalOperator.And,
                    Conditions = new List<FieldCondition>
                    {
                        new FieldCondition
                        {
                            DependentOn = dependentOn,
                            Operator = conditionOperator,
                            Values = new List<dynamic> { expectedValue }
                        }
                    }
                }
            };
        }
    }
}
