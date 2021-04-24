using System;
using System.Collections.Generic;
using System.Linq;

namespace JsonParserCSharp
{
    public class SymbolTokenizer : Tokenizable
    {
        private static readonly Dictionary<char, TokenType> valid = new();

        static SymbolTokenizer()
        {
            valid.Add('{', TokenType.Object);
            valid.Add('[', TokenType.Array);
            valid.Add(',', TokenType.Comma);
            valid.Add(':', TokenType.Colon);
            valid.Add(']', TokenType.Array);
            valid.Add('}', TokenType.Object);
        }

        public override bool tokenizable(Tokenizer t)
        {
            return valid.ContainsKey(t.input.peek());
        }

        public override Token tokenize(Tokenizer t)
        {
            char ch = t.input.step().Character;
            TokenType type = valid.GetValueOrDefault(ch);

            return new Token(t.input.Position, t.input.LineNumber,
                type, ch.ToString());
        }
    }
}