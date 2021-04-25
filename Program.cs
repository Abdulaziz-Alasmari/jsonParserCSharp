using System;
using System.Collections.Generic;
using System.IO;

namespace JsonParserCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText(@"/home/z/tuwaiq/jsonParserCSharp/input.json");
            Console.WriteLine($"input: {input}");
            Console.WriteLine();

            Tokenizer t = new Tokenizer(new Input(input), new Tokenizable[] {
                new WhiteSpaceTokenizer(),
                new NullTokenizer(),
                new NumberTokenizer(),
                new StringTokenizer(),
                new BoolTokenizer(),
                new SymbolTokenizer()
            });

            List<Token> tokens = t.all();

            Parser parser = new(tokens);
            parser.parse();
            System.Console.WriteLine(parser.ToString());
        }
    }
}