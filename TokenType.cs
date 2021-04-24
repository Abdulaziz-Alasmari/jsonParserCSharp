using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParserCSharp
{
    public enum TokenType
    {
        ObjectOpening, 
        ObjectClosing, 
        ArrayOpening, 
        ArrayClosing, 
        Comma, 
        Colon, 
        String, 
        Boolean, 
        Number, 
        Null, 
        WhiteSpace
    }
}
