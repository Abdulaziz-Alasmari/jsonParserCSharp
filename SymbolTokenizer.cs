using System;
using System.Collections.Generic;
using System.Linq;

namespace JsonParserCSharp
{
    public class SymbolTokenizer : Tokenizable
    {
        private static readonly Dictionary<char, string> valid = new();

        static SymbolTokenizer()
        {
            valid.Add('{', "object");
            valid.Add('[', "array");
            valid.Add(',', "comma");
            valid.Add(':', "colon");
            valid.Add(']', "array");
            valid.Add('}', "object");
        }

        public override bool tokenizable(Tokenizer t)
        {
            return valid.ContainsKey(t.input.peek());
        }

        public override Token tokenize(Tokenizer t)
        {
            char ch = t.input.step().Character;
            string type = valid.GetValueOrDefault(ch);

            return new Token(t.input.Position, t.input.LineNumber,
                type, ch.ToString());
        }
    }
}