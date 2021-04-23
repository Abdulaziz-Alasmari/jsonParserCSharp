using System;
using System.Collections.Generic;

namespace JsonParserCSharp
{
    public class Tokenizer
    {
        public List<Token> tokens;
        public bool enableHistory;
        public Input input;
        
        public Tokenizable[] handlers; public Tokenizer(string source, Tokenizable[] handlers)
        {
            this.input = new Input(source);
            this.handlers = handlers;
        }
        
        public Tokenizer(Input source, Tokenizable[] handlers)
        {
            this.input = source;
            this.handlers = handlers;
        }

        public Token tokenize()
        {
            foreach (var handler in this.handlers)
                if (handler.tokenizable(this)) return handler.tokenize(this); return null;
        }

        public List<Token> all()
        {
            Token token = this.tokenize();
            List<Token> tokens = new();

            if (token != null)
                tokens.Add(token);

            while (token != null)
            {
                Console.WriteLine(token.Value);
                token = this.tokenize();

                if(token != null)
                    tokens.Add(token);
            }

            return tokens;
        }
    }
}