using System;
using System.Collections.Generic;

namespace JsonParserCSharp
{
    public class Tokenizer
    {
        public List<Token> tokens;
        public bool enableHistory;
        public Input input;

        private static readonly string openings = "[{";
        private static readonly string closings = "}]";

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
                if (handler.tokenizable(this))
                {
                    Token token = handler.tokenize(this);

                    if (handler.isOptional)
                        continue;

                    return token;
                }
            
            return null;
        }

        public List<Token> all()
        {
            Token token = this.tokenize();
            List<Token> tokens = new();

            Stack<string> openingsStack = new();

            if (token != null)
            {
                if (openings.Contains(token.Value))
                    openingsStack.Push(token.Value);

                tokens.Add(token);
            }

            while (token != null)
            {
                token = this.tokenize();

                if(token != null)
                {
                    if (openings.Contains(token.Value))
                        openingsStack.Push(token.Value);

                    if (openingsStack.Count > 0 && closings.Contains(token.Value))
                        openingsStack.Pop();
                    else if (openingsStack.Count == 0 && closings.Contains(token.Value))
                        throw new Exception("Unexpected token");

                    tokens.Add(token);
                }
            }

            if (openingsStack.Count != 0)
                throw new Exception("Unexpected token");

            return tokens;
        }
    }
}