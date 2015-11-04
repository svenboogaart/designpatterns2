using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Tokenizer.Strategies
{
    public class TypeToken : Strategy
    {

        public Token Match(string value, Token lastToken)
        {
            Token token = null;
            if (value == "getal")
            {
                token = new Token();
                token.TokenType = TokenType.TypeNumber;
                token.Value = value;
                token.Level = Tokenize.level;
            }
            else if (value == "letter")
            {
                token = new Token();
                token.TokenType = TokenType.TypeChar;
                token.Value = value;
                token.Level = Tokenize.level;
            }
            else if (value == "woord")
            {
                token = new Token();
                token.TokenType = TokenType.TypeString;
                token.Value = value;
                token.Level = Tokenize.level;
            }
            return token;
        }
    }
}
