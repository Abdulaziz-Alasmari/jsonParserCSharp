using System.Collections.Generic;

namespace JsonParserCSharp
{
    public class JsonObj: JsonValue
    {
        public Dictionary<string, JsonValue> value { get; set; }
    }
}