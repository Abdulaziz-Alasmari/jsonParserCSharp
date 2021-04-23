using System;
using System.Collections.Generic;

namespace JsonParserCSharp
{

    public delegate bool InputCondition(Input input); 
    class Program
    {
        static void Main(string[] args)
        {
            Tokenizer t = new Tokenizer(new Input("{}"), new Tokenizable[] {

            }); ; Token token = t.tokenize();
            while (token != null)
            {
                Console.WriteLine(token.Value);
                token = t.tokenize();
            }
        }
    }


}