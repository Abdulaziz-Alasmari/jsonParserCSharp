using System;
namespace JsonParserCSharp
{
    public class JsonNumber : JsonValue
    {
        public double Value
        {get; set; }

        public JsonNumber( string input)
        {
            Value = Convert.ToDouble(input);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}