using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParserCSharp
{
    public class WhiteSpaceTokenizer : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            return Char.IsWhiteSpace(t.input.peek());
        }
        static bool isWhiteSpace(Input input)
        {
            return Char.IsWhiteSpace(input.peek());
        }
        public override Token tokenize(Tokenizer t)
        {
            return new Token(t.input.Position, t.input.LineNumber,
                "whitespace", t.input.loop(isWhiteSpace));
        }
    }
}
