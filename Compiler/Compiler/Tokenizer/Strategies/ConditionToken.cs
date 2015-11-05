using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Tokenizer.Strategies
{
    public class ConditionToken : Strategy
    {

        public Token Match(string value, Token lastToken)
        {
            Token token = null;
            if (value == "isgelijkaan")
            {
                token = new Token();
                token.TokenType = TokenType.EqualsEquals;
                token.Value = value;
                token.Level = Tokenize.level;
            }
            return token;
        }
    }
}
