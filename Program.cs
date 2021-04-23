using System;
using System.Collections.Generic;

namespace JsonParserCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Tokenizer t = new Tokenizer(new Input("{}"), new Tokenizable[] {

            });

            List<Token> tokens = t.all();
        }
    }
}