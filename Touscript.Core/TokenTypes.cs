using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touscript.Core
{

    static class TokenTypes
    {
        public const string EOF = "EOF";
        public const string LOOP = "LOOP";
        public const string IF = "IF";
        public const string ELSEIF = "ELSE";
        public const string NUMBER = "NUM";
        public const string VARIABLE = "VAR";
        public const string ASSIGNMENT = "ASSIGN";
        public const string PLUS = "PLUS";
        public const string MINUS = "MINUS";
        public const string MUL = "MUL";
        public const string DIV = "DIV";
        public const string MOD = "MOD";
        public const string LPAREN = "LPAREN";
        public const string RPAREN = "RPAREN";
        public const string EQ = "EQ";
    }
}
