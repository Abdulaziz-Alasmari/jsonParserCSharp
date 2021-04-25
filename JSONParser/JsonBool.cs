using System;
namespace JsonParserCSharp
{
    public class JsonBool : JsonValue
    {
        public bool Value { get; set; }

        public JsonBool( string input)
        {
            Value = Convert.ToBoolean(input);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}