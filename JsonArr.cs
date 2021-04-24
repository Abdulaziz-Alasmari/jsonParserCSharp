using System.Collections.Generic;

namespace JsonParserCSharp
{
    public class JsonArr : JsonValue
    {
        public List<JsonValue> value = new List<JsonValue>();

        public override string ToString( )
        {
            string stringArr = "[";
            for (var i = 0; i < value.Count ; i++)
            {
                if( (i + 1) == value.Count )
                {
                    stringArr += value[i].ToString();
                    break;
                }
                stringArr += value[i].ToString() + ", ";
            }
            stringArr += "]";
            return stringArr;
        }
    }
}