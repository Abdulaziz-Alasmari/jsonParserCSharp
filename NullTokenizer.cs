using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParserCSharp
{
    public class NullTokenizer : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            char currentCharacter = Char.ToLower(t.input.peek());
            return currentCharacter == 'n';
        }

        static bool isNull(Input input)
        {
            char currentCharacter = input.peek();
            return Char.IsLetter(currentCharacter);
        }

        public override Token tokenize(Tokenizer t)
        {
            Token token = new Token(t.input.Position, t.input.LineNumber,
                "Null", t.input.loop(isNull).ToLower());

            if (token.Value != "null")
                throw new Exception("invalid value");

            return token;
        }
    }
}
