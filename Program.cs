using System;
using System.Collections.Generic;

namespace JsonParserCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Tokenizer t = new Tokenizer(new Input("{}"), new Tokenizable[] {
                new WhiteSpaceTokenizer(),
                new nullTokenizer(),
                new NumberTokenizer(),
                new StringTokenizer(),
                new SymbolTokenizer()
            });

            List<Token> tokens = t.all();

            foreach(var token in tokens)
            {
                Console.WriteLine(token.Value);
            }
        }
    }
}