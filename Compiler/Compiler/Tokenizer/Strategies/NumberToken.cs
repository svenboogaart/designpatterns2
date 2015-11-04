using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Compiler.Tokenizer.Strategies
{
    public class NumberToken : Strategy
    {
        Regex numberRegex = new Regex(@"^\d");

        public Token Match(string value, Token lastToken)
        {
            Token token = null;
            Match m = numberRegex.Match(value);
            if (m.Success)
            {
                token = new Token();
                token.TokenType = TokenType.Number;
                token.Value = m.Value;
                token.Level = Tokenize.level;
            }
            return token;
        }
    }
}
