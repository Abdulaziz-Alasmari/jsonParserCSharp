﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParserCSharp
{
    class StringTokenizer : Tokenizable
    {
        private string valid = ",:]}";

        public override bool tokenizable(Tokenizer tokenizer)
        {
            return tokenizer.input.peek() == '"';
        }

        public bool isString(Input input)
        {
            bool endWithoutClosing = !input.hasMore(2) && input.peek() != '"';
            bool nextTokenInvalid = input.peek() == '"' && input.Character != '\\' && !valid.Contains(input.peek(2));

            if (input.peek() == '\n' || endWithoutClosing || nextTokenInvalid)
                throw new Exception("Unexpected token");

            return input.Character != '"';
        }

        public override Token tokenize(Tokenizer tokenizer)
        {
            Input input = tokenizer.input;
            return new Token(input.Position, input.LineNumber, "type", input.loop(isString));
        }
    }
}