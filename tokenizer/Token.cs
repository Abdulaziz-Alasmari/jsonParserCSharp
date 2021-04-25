using System;
namespace JsonParserCSharp
{
    public class Token
    {
        public int Position { set; get; }
        public int LineNumber { set; get; }
        public TokenType Type { set; get; }
        public string Value { set; get; }

        public Token(int position, int lineNumber, TokenType type, string value)
        {
            this.Position = position;
            this.LineNumber = lineNumber;
            this.Type = type;
            this.Value = value;
        }

        public override string ToString()
        {
            return $"\nType: {Type}\nValue: {Value}\n";
        }
    }
}