using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Tokenizer.Strategies
{
    public class IfWhileToken : Strategy
    {
        public Token Match(string value, Token lastToken)
        {
            if (value.StartsWith("als"))
            { 
                Token token = null;
                token = new Token();
                token.TokenType = TokenType.IfToken;
                token.Value = value;
                token.Level = Tokenize.level;
                return token;
            }
            else if (value.StartsWith("zolang"))
            {
                Token token = null;
                token = new Token();
                token.TokenType = TokenType.WhileToken;
                token.Value = value;
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
