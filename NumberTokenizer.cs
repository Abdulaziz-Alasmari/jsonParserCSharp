using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParserCSharp
{
    public class NumberTokenizer : Tokenizable
    {
        private static int countDot = 0;
        

        public override bool tokenizable(Tokenizer t)
        {
            countDot = 0;
            
            return Char.IsDigit(t.input.peek()) || t.input.peek() == '-';
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
                countDot++;

                if (countDot++ >= 2)
                    throw new Exception("invalid value");
            }



            

            return Char.IsDigit(currentCharacter) || currentCharacter == '.' || checkExponent || input.peek() == '-' || input.peek() == '+';
        }

        public override Token tokenize(Tokenizer t)
        {
            Token token = new Token(t.input.Position, t.input.LineNumber,
                "number", t.input.loop(isDigit));

            
            if(token.Value[0]== '0' && token.Value.Length > 1 && (token.Value[1] != '.'))
             {
                throw new Exception("invalid value");
             }
            else
            {
                return token;
            }
            

            
        }
    }
}
