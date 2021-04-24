using System;
using System.Collections.Generic;
namespace JsonParserCSharp
{
    // class JsonValue { }

    public class Parser
    {
        List<Token> tokens;
        JsonValue root;
        Token currentToken = null;
        private int Position { get; set; }

        public Parser(List<Token> tokens)
        {
            this.tokens = tokens;
            Position = 0;
            currentToken = tokens[Position];
            root = null;
            System.Console.WriteLine("Current token -> " + currentToken.Value);
            foreach (var token in tokens)
                Console.WriteLine("current token " + token.Type + " " + token.Value);

        }

        public JsonValue parse()
        {
            root = getValue();
            System.Console.WriteLine(root);
            return root;
        }

        private void moveCursor()
        {
            if ((Position + 1) < tokens.Count)
            {
                currentToken = tokens[++Position];

            }
            currentToken = null;
        }

        private JsonValue getValue()
        {
            JsonValue value = null;

            if (currentToken != null)
            {
                switch (currentToken.Type)
                {
                    case TokenType.String:
                        value = new JsonString();
                        moveCursor();
                        break;

                    case TokenType.Number:
                        value = new JsonNumber();
                        moveCursor();
                        break;

                    case TokenType.Boolean:
                        value = new JsonBool();
                        moveCursor();
                        break;

                    case TokenType.Null:
                        value = new JsonNull();
                        moveCursor();
                        break;

                    case TokenType.ObjectOpening:
                        moveCursor();
                        value = parseObject( new JsonObj() );
                        break;

                    case TokenType.ArrayOpening:
                        moveCursor();
                        value = parseArray( new JsonArr() );
                        break;

                    default:
                        throw new Exception("Invalid json");
                }
            }


            return value;
        }


        private string getKey()
        {
            if (currentToken.Type == TokenType.String)
            {
                return currentToken.Value;
            }
            return null;
        }

        private JsonObj parseObject(JsonObj obj)
        {
            if (currentToken.Type == TokenType.ObjectClosing) 
            {
                moveCursor();
                return obj;
            }
            else
            {

                while (currentToken != null)
                {
                    string key = getKey();
                    if (key != null)
                    {
                        moveCursor(); // move from key to colon

                        if (currentToken != null && currentToken.Type == TokenType.Colon)
                        {
                            moveCursor(); // move from colon to value
                            JsonValue value = getValue();
                            obj.value.Add(key, value);
                            moveCursor(); // mvoe from value to ',' or '}' else exception
                            if (currentToken != null && currentToken.Type == TokenType.Comma)
                            {
                                moveCursor();
                                continue;
                            }
                            else if (currentToken != null && currentToken.Type == TokenType.ObjectClosing)
                            {
                                moveCursor();
                                break;
                            }
                            else
                            {
                                throw new Exception("did not find , or } ");
                            }

                        }
                        else
                        {
                            throw new Exception("did not find colon");
                        }
                    }
                    else
                    {
                        throw new Exception("did not find key");
                    }

                }
                return obj;
            }
        }

        private JsonArr parseArray(JsonArr array)
        {
            if (currentToken.Type == TokenType.ArrayClosing) 
            {
                moveCursor();
                return array;
            }
            else
            {
                JsonValue value = null;
                while( currentToken != null)
                {
                    value = getValue();
                    array.arr.Add(value);
                    moveCursor();
                    if( currentToken != null && currentToken.Type == TokenType.Comma)
                    {
                        moveCursor();
                        continue;
                    }
                    else if (currentToken != null && currentToken.Type == TokenType.ArrayClosing)
                    {
                        moveCursor();
                        break;
                    }
                    else
                    {
                        throw new Exception("did not find , or ]");
                    }

                }
                return array;
            }
        }

    }


}