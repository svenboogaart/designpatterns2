﻿using Compiler.Utility;
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

        public TokenType TokenType { get; set; }
        public string Value { get; set; }
        public Token Partner { get; set; }
        public int Level { get; set; }
        public int LineNumber { get; set; }
        public int Position { get; set; }
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
        Empty,
        EndCode,
        StartCode
    }
}
