using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParserCSharp
{
   

    public class NumberTokenizer : Tokenizable
    {
        static int count = 0;
        public override bool tokenizable(Tokenizer t)
        {
            bool tokenizable = Char.IsDigit(t.input.peek()) || t.input.peek() == '-';


            count = 0;

            return tokenizable;
        }

        static bool isDigit(Input input)
        {

            char currentCharacter = input.peek();
            bool checkExponent = ((currentCharacter == 'E' || currentCharacter == 'e') && (input.peek(2) == '-' || input.peek(2) == '+' || Char.IsDigit(input.peek(2))));



            if (currentCharacter == '-' && (input.Character != 'e'))
            {
                if (currentCharacter == '-' && (input.Character != 'E'))
                {
                    if (currentCharacter == '-' && Char.IsDigit(input.Character))
                    {

                        throw new Exception("invalid value");
                    }
                }

            }

            if (currentCharacter == '.')
            {
                count++;

                if (count >= 2)
                    throw new Exception("invalid value");
            }

            return Char.IsDigit(currentCharacter) || currentCharacter == '.' || checkExponent || input.peek() == '-' || input.peek() == '+';
        }

        public override Token tokenize(Tokenizer t)
        {
            return new Token(t.input.Position, t.input.LineNumber,
                "number", t.input.loop(isDigit));
        }
    }
}
