namespace JsonParserCSharp
{
    public class JsonNull : JsonValue
    {
        public object value
        {
            get { return null; }
        }

        public override string ToString()
        {
            return "null";
        }
    }
}