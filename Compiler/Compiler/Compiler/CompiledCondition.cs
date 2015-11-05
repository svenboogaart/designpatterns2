using Compiler.Nodes;
using Compiler.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Compiler
{
    public class CompiledCondition : CompiledStatement
    {
        public override NodeLinkedList Compile(ref LinkedListNode<Token> currentToken)
        {
            Token leftToken = currentToken.Value;
            string leftName = leftToken.Value;
            currentToken = currentToken.Next;
            Token operatorToken = currentToken.Value;
            currentToken = currentToken.Next;
            Token rightToken = currentToken.Value;
            string rightName = rightToken.Value;

            if (leftToken.TokenType != TokenType.Identifier)
            {
                leftName = getUniqueId();
                Compiled.Add(new DirectFunctionCall("ConstantToReturn", leftToken.Value));
                Compiled.Add(new DirectFunctionCall("ReturnToVariable", leftName));
            }
            else
            {
                leftName = getUniqueId();
                Compiled.Add(new DirectFunctionCall("IdentifierToReturn", leftToken.Value));
                Compiled.Add(new DirectFunctionCall("ReturnToVariable", leftName));
            }
            if (rightToken.TokenType != TokenType.Identifier)
            {
                rightName = getUniqueId();
                Compiled.Add(new DirectFunctionCall("ConstantToReturn", rightToken.Value));
                Compiled.Add(new DirectFunctionCall("ReturnToVariable", rightName));
            }
            else
            {
                rightName = getUniqueId();
                Compiled.Add(new DirectFunctionCall("IdentifierToReturn", rightToken.Value));
                Compiled.Add(new DirectFunctionCall("ReturnToVariable", rightName));
            }

            switch (operatorToken.TokenType)
            {
                case TokenType.EqualsEquals: 
                    Compiled.Add(new FunctionCall("AreEqual", leftName, rightName));
                    break;
                // etc.
                default:
                    break;
            }
            return Compiled;
        }

        public override CompiledStatement clone()
        {
            return new CompiledCondition();
        }

        public override bool isMatch(LinkedListNode<Token> token)
        {
            return token.Next.Value.TokenType == TokenType.EqualsEquals;
        }
    }
}
