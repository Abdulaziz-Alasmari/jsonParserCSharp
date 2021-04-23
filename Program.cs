using System;
using System.Collections.Generic;

namespace JsonParserCSharp
{

    public delegate bool InputCondition(Input input); 
    class Program
    {
        static void Main(string[] args)
        {
            Tokenizer t = new Tokenizer(new Input("5.5 True null False -5.5e+5 5e+2 -5e+2 5e5 -5e5 5.5E+5 -5.5E+5 5E+2 -5E+2 5E5 -5E5  "), new Tokenizable[] {
                new NumberTokenizer(),
                new WhiteSpaceTokenizer(),
                new boolTokenizer(new List<string>
                {
                    "true","false"
                }),
                new nullTokenizer(new List<string>
                {
                    "null"
                })
            }) ; 
            Token token = t.tokenize();
            while (token != null)
            {
                Console.WriteLine(token.Value);
                token = t.tokenize();
            }
        }
    }


}