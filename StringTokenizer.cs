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
        private string valid = ",:]}";

        public override bool tokenizable(Tokenizer tokenizer)
        {
            count = 0;
            return tokenizer.input.peek() == '"';
        }

        public bool isString(Input input)
        {
            count++;

            bool endWithoutClosing = !input.hasMore(2) && input.peek() != '"';
            bool nextTokenInvalid = input.peek() == '"' && input.Character != '\\' && !valid.Contains(input.peek(2));

            if (input.peek() == '\n' || endWithoutClosing || nextTokenInvalid)
                throw new Exception("Unexpected token");

            return count == 1 || input.Character != '"';
        }

        public override Token tokenize(Tokenizer tokenizer)
        {
            Input input = tokenizer.input;
            char ch = input.step().Character;
            Token token = new Token(input.Position, input.LineNumber, "type", input.loop(isString));
            token.Value = ch + token.Value;
            Console.WriteLine(token.Value);

            return token;
        }
    }
}
