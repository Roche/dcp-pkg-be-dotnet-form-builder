using System.Linq;
using System.Text.Json;

namespace OpenDCP.Framework.FormBuilder.Helpers
{
    public static class JsonHelper
    {
        public static object NormalizeJsonValue(object value)
        {
            if (value is JsonElement element)
            {
                switch (element.ValueKind)
                {
                    case JsonValueKind.String:
                        return element.GetString();

                    case JsonValueKind.Number:
                        if (element.TryGetInt64(out long l))
                            return l;
                        return element.GetDouble();

                    case JsonValueKind.True:
                        return true;

                    case JsonValueKind.False:
                        return false;

                    case JsonValueKind.Array:
                        return element.EnumerateArray()
                                      .Select(e => NormalizeJsonValue(e))
                                      .ToList();

                    case JsonValueKind.Null:
                    case JsonValueKind.Undefined:
                        return null;

                    case JsonValueKind.Object:
                        return element.EnumerateObject()
                                      .ToDictionary(
                                          p => p.Name,
                                          p => NormalizeJsonValue(p.Value)
                                      );

                    default:
                        return element.GetRawText();
                }
            }
            return value;
        }
    }
}
