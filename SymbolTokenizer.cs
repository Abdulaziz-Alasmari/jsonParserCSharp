using System;
using System.Linq;

namespace Tokenizer
{
    public class SymbolTokenizer : Tokenizable
    {
        private Char[] valid = new[] {'[','{',',',':','}',']'};
        public override bool tokenizable(Tokenizer t)
        {
            return valid.Contains(t.input.peek());
        }
        public override Token tokenize(Tokenizer t)
        {
            return new Token(t.input.Position, t.input.LineNumber,
                "Symbol", t.input.step().Character.ToString());
        }
    }
}