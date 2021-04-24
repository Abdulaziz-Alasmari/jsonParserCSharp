using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParserCSharp
{
    public enum TokenType
    {
        /*valid.Add('{', "object");
        valid.Add('[', "array");
        valid.Add(',', "comma");
        valid.Add(':', "colon");
        valid.Add(']', "array");
        valid.Add('}', "object");*/
        ObjectOpening, ObjectClosing, ArrayOpening, ArrayClosing, Comma, Colon, String, Boolean, Number, Null, WhiteSpace
    }
}
