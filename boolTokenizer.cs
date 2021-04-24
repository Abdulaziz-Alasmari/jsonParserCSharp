using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParserCSharp
{
    public class boolTokenizer : Tokenizable
    {
        private List<string> keywords;
        public boolTokenizer(List<string> keywords)
        {
            this.keywords = keywords;
        }
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
                "TrueOrFalse", t.input.loop(isTrueOrFalse));
            string trueOrfalseString = token.Value.ToLower();
            if (keywords.Contains(trueOrfalseString))
            {
                return token;
            }
            else
            {
                throw new Exception("invalid value");
            }
        }
    }
}
