using System.Collections.Generic;

namespace JsonParserCSharp
{
    public class JsonObj: JsonValue
    {
        public Dictionary<string, JsonValue> Value = new Dictionary<string, JsonValue>();

        public override string ToString()
        {
            var counter = Value.Count;
            string stringObject = "\n{\n";
            foreach (var jval  in Value)
            {
                if( (counter - 1) == 0 )
                {
                    stringObject += "   \"" + jval.Key +"\" : "+ jval.Value.ToString() + "\n";
                    break;
                }
                stringObject += "   \"" + jval.Key +"\" : "+ jval.Value.ToString() + ", \n";
                counter--;
            }
            stringObject += "}\n";
            return stringObject;
        }
    }
}