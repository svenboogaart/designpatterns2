using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Tokenizer.Strategies
{
    public class PlusMinusToken : Strategy
    {
        public Token Match(string value, Token lastToken)
        {
            Token token = null;
            if (value == "verhogen")
            {
                token = new Token();
                token.TokenType = TokenType.Increment;
                token.Value = value;
                token.Level = Tokenize.level;
            }
            return token;
        }
    }
}
