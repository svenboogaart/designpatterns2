using Compiler.Tokenizer.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Tokenizer
{
    public class TokenFactory
    {
        private List<Strategy> tokenStrategy;
        public TokenFactory() 
        {
            tokenStrategy = new List<Strategy>();
            tokenStrategy.Add(new AssignToken());
            tokenStrategy.Add(new CodeBlockToken());
            tokenStrategy.Add(new EndstatementToken());
            tokenStrategy.Add(new IfWhileToken());
            tokenStrategy.Add(new NumberToken());
            tokenStrategy.Add(new ConditionToken());
            tokenStrategy.Add(new PlusMinusToken());
            tokenStrategy.Add(new FunctionToken());
            tokenStrategy.Add(new TypeToken());
            tokenStrategy.Add(new IdentifierToken()); // moet de laatste zijn
        }

        public Token Create(string part,Token lastToken) 
        {
            Token token = null;
            foreach(Strategy strategy in tokenStrategy) 
            {
                token = strategy.Match(part,lastToken);
                if(token != null) 
                {
                    break;
                }
            }
            return token;
        }
    }
}