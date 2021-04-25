using System;
using System.Collections.Generic;
namespace JsonParserCSharp
{
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
        }

        public JsonValue parse()
        {
            root = getValue();
            nextToken();
            if( currentToken != null)
            {
                throw new Exception("More than one JSON root object");
            }
            return root;
        }

        private void nextToken()
        {
            if ((Position + 1) < tokens.Count)
            {
                currentToken = tokens[++Position];

            }
            else
            {
                currentToken = null;
            }
        }

        private JsonValue getValue()
        {
            JsonValue value = null;

            if (currentToken != null)
            {
                switch (currentToken.Type)
                {
                    case TokenType.String:
                        value = new JsonString(currentToken.Value);
                        break;

                    case TokenType.Number:
                        value = new JsonNumber(currentToken.Value);
                        break;

                    case TokenType.Boolean:
                        value = new JsonBool(currentToken.Value);
                        break;

                    case TokenType.Null:
                        value = new JsonNull();
                        break;

                    case TokenType.ObjectOpening:
                        nextToken();
                        value = parseObject(new JsonObj());
                        break;

                    case TokenType.ArrayOpening:
                        nextToken();
                        value = parseArray(new JsonArr());
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

                return obj;
            }
            else
            {
                while (currentToken != null)
                {
                    string key = getKey();
                    if (key != null)
                    {
                        nextToken();
                        if (currentToken != null && currentToken.Type == TokenType.Colon)
                        {
                            nextToken();
                            JsonValue value = getValue();

                            obj.Value.Add(key, value);
                            nextToken();

                            if (currentToken != null && currentToken.Type == TokenType.Comma)
                            {
                                nextToken();
                                continue;
                            }
                            else if (currentToken != null && currentToken.Type == TokenType.ObjectClosing)
                            {
                                break;
                            }
                            else
                            {
                                throw new Exception("Parser error: unexpected end of object; expected ',' , '}' ");
                            }

                        }
                        else
                        {
                            throw new Exception("Parser error: unexpected end of object; expected ':' ");
                        }
                    }
                    else
                    {
                        throw new Exception("Parser error: unexpected end of object; expected key ");
                    }

                }
                return obj;
            }
        }

        private JsonArr parseArray(JsonArr array)
        {
            if (currentToken.Type == TokenType.ArrayClosing)
            {

                return array;
            }
            else
            {
                JsonValue value = null;
                while (currentToken != null)
                {
                    value = getValue();
                    array.value.Add(value);
                    nextToken();
                    if (currentToken != null && currentToken.Type == TokenType.Comma)
                    {
                        nextToken();
                        continue;
                    }
                    else if (currentToken != null && currentToken.Type == TokenType.ArrayClosing)
                    {

                        break;
                    }
                    else
                    {
                        throw new Exception("Parser error: unexpected end of array; expected ',' , ']' ");
                    }

                }
                return array;
            }
        }

        public override string ToString()
        {
            return root.ToString();
        }

    }


}