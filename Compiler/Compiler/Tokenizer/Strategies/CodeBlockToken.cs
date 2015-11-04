using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Tokenizer.Strategies
{
    public class CodeBlockToken : Strategy
    {
        private static Stack<Token> partnerStack;

        public CodeBlockToken() :base()
        {
            partnerStack = new Stack<Token>();
        }
        public Token Match(string value, Token lastToken)
        {
            Token token = null;
            if (value == "begincode")
            {
                token = new Token();
                token.TokenType = TokenType.StartCode;
                token.Value = value;
                token.Level = Tokenize.level;
                partnerStack.Push(token);
            }
            else if (value == "eindcode")
            {
                token = new Token();
                Tokenize.level--;
                Token partner = partnerStack.Pop();
                partner.Partner = token;
                token.Partner = partner;
                token.TokenType = TokenType.EndCode;
                token.Value = value;
                token.Level = Tokenize.level;
            }
            else if (value == "haakjeopen")
            {
                token = new Token();
                token.TokenType = TokenType.BracketsOpen;
                token.Value = value;
                token.Level = Tokenize.level;
                Tokenize.level++;
                partnerStack.Push(token);
            }
            else if (value == "haakjessluiten")
            {
                token = new Token();
                Tokenize.level--;
                Token partner = partnerStack.Pop();
                partner.Partner = token;
                token.Partner = partner;
                token.TokenType = TokenType.BracketsClose;
                token.Value = value;
                token.Level = Tokenize.level;
            }
            return token;
        }
    }
}
