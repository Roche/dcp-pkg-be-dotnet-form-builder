using OpenDCP.Framework.FormBuilder.Constants;
using OpenDCP.Framework.FormBuilder.Models;
using System;
using System.Linq;
using System.Text.Json.Nodes;

namespace OpenDCP.Framework.FormBuilder.Extensions
{
    internal static class FieldConditionGroupExtensions
    {
        internal static bool IsValid(this FieldConditionGroup cond, JsonObject values, string fieldPath = null)
        {
            bool result;

            switch (cond.Operator)
            {
                case LogicalOperator.And:
                    result = cond.Conditions.All(c => c.IsValid(values, fieldPath));
                    break;

                case LogicalOperator.Or:
                    result = cond.Conditions.Any(c => c.IsValid(values, fieldPath));
                    break;

                default:
                    throw new ArgumentException("Unknown logical operator");
            }

            switch (cond.Action)
            {
                case FieldConditionAction.Show:
                    return result;

                case FieldConditionAction.Hide:
                    return !result;

                default:
                    return true;
            }
        }
    }
}
