using System.Collections.Generic;

namespace Tokenizer
{
    public class JsonObj: First.TokenValue
    {
        public Dictionary<string,First.TokenValue> value { get; set; }
    }

}