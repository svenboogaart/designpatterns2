using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Tokenizer.Strategies
{
    public class IfToken : Strategy
    {
        public Token Match(string value, Token lastToken)
        {
            if (value.StartsWith("als"))
            { 
                Token token = null;
                token = new Token();
                token.TokenType = TokenType.IfToken;
                token.Value = "als";
                token.Level = Tokenize.level;
                return token;
            }
            else
            {
                return null;
            }
        }
    }
}
