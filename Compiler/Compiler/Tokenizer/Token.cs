using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Tokenizer
{
    public class Token
    {
        public Token()
        {

        }

        public Token(string value, int level, int lineNumber, int position)
        {
            Value = value;
            Level = level;
            LineNumber = lineNumber;
            Position = position;
        }      

        public TokenType TokenType { get; set; }
        public string Value { get; set; }
        public Token Partner { get; set; }
        public int Level { get; set; }
        public int LineNumber { get; set; }
        public int Position { get; set; }

    }

    public enum TokenType
    {
        NoTokenType,
        Identifier,
        TypeNumber, //= getal
        TypeString, //= woord
        TypeChar,   //= letter
        Number, 
        String,
        Char,
        EndStatement,
        IfToken,
        IfelseToken,
        ElseToken,
        Assignment,
        WhileToken,
        BracketsOpen,
        BracketsClose,
        Equals,
        EqualsEquals,
        Increment,
        Decrement,
        Empty,
        EndCode,
        StartCode,
        Any,
        Print
    }
}
