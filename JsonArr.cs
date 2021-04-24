using System.Collections.Generic;

namespace JsonParserCSharp
{
    public class JsonArr : JsonValue
    {
        public List<JsonValue> value = new List<JsonValue>();
    }
}