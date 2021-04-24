namespace JsonParserCSharp
{
    public class JsonString : JsonValue
    {
        public string Value { get; set; }

        public JsonString( string input)
        {
            Value = input;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}