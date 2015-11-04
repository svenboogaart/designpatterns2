using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Compiler.Tokenizer.Strategies
{
    public class IdentifierToken : Strategy
    {
        private Regex alphanumeric = new Regex(@"^[a-zA-Z]+");

        public Token Match(string value, Token lastToken)
        {
            Token token = null;
            Match m = alphanumeric.Match(value);
            if (m.Success)
            {
                token = new Token();
                token.TokenType = TokenType.Identifier;
                token.Value = m.Value;
                token.Level = Tokenize.level;
            }
            return token;
        }
    }
}
