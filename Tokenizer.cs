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

            string openings = "[{";
            Stack<string> openingsStack = new();

            if (token != null)
            {
                if (openings.Contains(token.Value))
                    openingsStack.Push(token.Value);

                tokens.Add(token);
            }

            while (token != null)
            {
                Console.WriteLine(token.Value);
                token = this.tokenize();

                if(token != null)
                {
                    if (openings.Contains(token.Value))
                        openingsStack.Push(token.Value);

                    if (openingsStack.Peek() == token.Value)
                        openingsStack.Pop();

                    tokens.Add(token);
                }
            }

            if (openingsStack.Count != 0)
                throw new Exception("Unexpected token");

            return tokens;
        }
    }
}