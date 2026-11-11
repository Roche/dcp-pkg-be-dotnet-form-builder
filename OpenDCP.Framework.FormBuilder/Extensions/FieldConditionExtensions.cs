using OpenDCP.Framework.FormBuilder.Constants;
using OpenDCP.Framework.FormBuilder.Models;
using System;
using System.Linq;
using System.Text.Json.Nodes;

namespace OpenDCP.Framework.FormBuilder.Extensions
{
    internal static class FieldConditionExtensions
    {
        internal static bool IsValid(this FieldCondition cond, JsonObject values, string fieldPath = null)
        {
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values), "Missing connection string values");
            }

            if (fieldPath == null || !TryFindValue(values, $"{fieldPath}.{cond.DependentOn}", out var val))
            {
                if (!TryFindValue(values, cond.DependentOn, out val))
                {
                    throw new ArgumentException($"Missing dependent field '{cond.DependentOn}'");
                }
            }

            var value = ExtractValue(val);

            switch (cond.Operator)
            {
                case FieldConditionOperator.Equal:
                    return EqualsIgnoreCase(value, cond.Values[0]);

                case FieldConditionOperator.NotEqual:
                    return !EqualsIgnoreCase(value, cond.Values[0]);

                case FieldConditionOperator.In:
                    return cond.Values.Any(v => EqualsIgnoreCase(value, v));

                case FieldConditionOperator.HasValue:
                    return value != null;

                case FieldConditionOperator.CountEqualTo:
                    return GetCount(value, cond.DependentOn) == Convert.ToInt32(cond.Values[0]);

                case FieldConditionOperator.CountLessOrEqualTo:
                    return GetCount(value, cond.DependentOn) <= Convert.ToInt32(cond.Values[0]);

                case FieldConditionOperator.CountGreaterOrEqualTo:
                    return GetCount(value, cond.DependentOn) >= Convert.ToInt32(cond.Values[0]);

                default:
                    throw new NotSupportedException($"Unsupported condition operator '{cond.Operator}'.");
            }
        }

        private static bool EqualsIgnoreCase(object left, object right)
        {
            var l = left?.ToString();
            var r = right?.ToString();

            return string.Equals(l, r, StringComparison.OrdinalIgnoreCase);
        }

        private static int GetCount(object node, string fieldName)
        {
            if (node is JsonArray arr)
                return arr.Count;

            throw new InvalidOperationException($"Field '{fieldName}' must be an array to evaluate count-based condition");
        }

        private static bool TryFindValue(
            JsonObject obj,
            string key,
            out JsonNode value)
        {
            var parts = key.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

            return TryFindValueInternal(obj, parts, 0, out value);
        }

        private static bool TryFindValueInternal(
            JsonNode node,
            string[] parts,
            int index,
            out JsonNode value)
        {
            value = null;

            var obj = node as JsonObject;
            if (obj == null)
                return false;

            foreach (var kvp in obj)
            {
                if (!kvp.Key.Equals(parts[index], StringComparison.OrdinalIgnoreCase))
                    continue;

                var current = kvp.Value;

                if (index == parts.Length - 1)
                {
                    value = current;
                    return true;
                }

                var childObj = current as JsonObject;
                if (childObj != null)
                {
                    return TryFindValueInternal(childObj, parts, index + 1, out value);
                }

                var arr = current as JsonArray;
                if (arr != null)
                {
                    foreach (var item in arr)
                    {
                        if (TryFindValueInternal(item, parts, index + 1, out value))
                            return true;
                    }
                }
            }

            return false;
        }

        private static object ExtractValue(JsonNode node)
        {
            if (node == null)
                return null;

            var v = node as JsonValue;
            if (v != null)
                return v.GetValue<object>();

            return node;
        }
    }
}
