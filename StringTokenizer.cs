using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParserCSharp
{
    class StringTokenizer : Tokenizable
    {
        private static int count = 0;

        public override bool tokenizable(Tokenizer tokenizer)
        {
            count = 0;
            return tokenizer.input.peek() == '"';
        }

        public bool isString(Input input)
        {
            count++;

            if (input.peek() == '\n' || !input.hasMore(2) && input.peek() != '"')
                throw new Exception("Unexpected token");

            return count == 1 || input.Character != '"';
        }

        public override Token tokenize(Tokenizer tokenizer)
        {
            Input input = tokenizer.input;
            input.step();
            Token token = new Token(input.Position, input.LineNumber, TokenType.String, input.loop(isString));

            string val = "";

            for(int i = 0; i < token.Value.Length - 1; i++)
            {
                val += token.Value[i];
            }

            token.Value = val;

            return token;
        }
    }
}
