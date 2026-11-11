using OpenDCP.Framework.FormBuilder.Models;
using System.Linq;
using System.Text.Json.Nodes;


namespace OpenDCP.Framework.FormBuilder.Extensions
{
    public static class InputFieldExtensions
    {
        public static bool IsVisible(this InputField field, JsonObject values, string fieldPath = null)
        {
            return field.ConditionGroups.All(cg => cg.IsValid(values, fieldPath));
        }
    }
}
