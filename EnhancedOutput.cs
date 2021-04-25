using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParserCSharp
{
    class EnhancedOutput
    {
        public enum Type { None, Key, Value, Separator }

        public bool isKey = false;
        public bool isArray = false;

        public void print(List<Token> tokens)
        {
            for(int i = 0; i < tokens.Count; i++)
            {
                Token token = tokens[i];
                Type type = findType(token.Type);

                switch(type)
                {
                    case Type.Value:
                        break;
                    case Type.Key:
                        break;
                    case Type.Separator:
                        break;
                }
            }
        }

        public Type findType(TokenType tokenType)
        {
            switch (tokenType)
            {
                case TokenType.ObjectOpening:
                case TokenType.ObjectClosing:
                case TokenType.Null:
                case TokenType.Number:
                case TokenType.Boolean:
                    return Type.Value;

                case TokenType.String:
                    return isKey ? Type.Key : Type.Value;

                case TokenType.Comma:
                    isKey = !isArray;
                    return Type.Separator;

                case TokenType.Colon:
                    isKey = false;
                    return Type.Separator;

                case TokenType.ArrayOpening:
                    isArray = true;
                    return Type.Value;

                case TokenType.ArrayClosing:
                    isArray = false;
                    return Type.Value;
            }

            return Type.None;
        }
    }
}
