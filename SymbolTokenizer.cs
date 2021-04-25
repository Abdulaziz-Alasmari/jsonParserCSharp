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
            valid.Add('{', TokenType.ObjectOpening);
            valid.Add('[', TokenType.ArrayOpening);
            valid.Add(',', TokenType.Comma);
            valid.Add(':', TokenType.Colon);
            valid.Add(']', TokenType.ArrayClosing);
            valid.Add('}', TokenType.ObjectClosing);
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