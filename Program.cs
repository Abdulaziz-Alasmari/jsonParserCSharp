using System;
using System.Collections.Generic;
using System.IO;

namespace JsonParserCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // important change this to your local file path
            var input = File.ReadAllText(@"C:\Users\WinDows\source\repos\jsonParserCSharp\jsonParserCSharp\input.json");
            Console.WriteLine($"input: {input}");

            Tokenizer t = new Tokenizer(new Input(input), new Tokenizable[] {
                new WhiteSpaceTokenizer(),
                new NullTokenizer(),
                new NumberTokenizer(),
                new StringTokenizer(),
                new BoolTokenizer(),
                new SymbolTokenizer()
            });

            List<Token> tokens = t.all();



            foreach (var token in tokens)
                Console.WriteLine(token.Value);
        }
    }
}