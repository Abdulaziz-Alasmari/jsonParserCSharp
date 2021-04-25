using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParserCSharp
{
    public class BoolTokenizer : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            char currentCharacter = Char.ToLower(t.input.peek());
            return currentCharacter == 't' || currentCharacter == 'f';
        }

        static bool isTrueOrFalse(Input input)
        {
            char currentCharacter = input.peek();
            return Char.IsLetter(currentCharacter);
        }
        
        public override Token tokenize(Tokenizer t)
        {
            Token token = new Token(t.input.Position, t.input.LineNumber,
                TokenType.Boolean, t.input.loop(isTrueOrFalse).ToLower());

            if (token.Value != "true" && token.Value != "false")
                throw new Exception("Unexpected token");

            return token;
        }
    }
}
