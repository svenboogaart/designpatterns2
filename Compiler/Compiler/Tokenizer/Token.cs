using Compiler.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Tokenizer
{
    public class Token
    {
        public Token(TokenType type,string value)
        {
            TokenType = type;
        }      

        TokenType TokenType { get; set; }
        string Value { get; set; }
        CustomLLNode<Token> partner { get; set; }
    }

    public enum TokenType
    {
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
        Empty
    }
}
