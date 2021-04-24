namespace JsonParserCSharp
{
    public class JsonNull : TokenValue
    {
        public object value
        {
            get { return null; }
        }
    }
}