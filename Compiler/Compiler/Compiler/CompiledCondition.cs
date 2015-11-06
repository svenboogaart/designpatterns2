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
        public override NodeLinkedList Compile(ref LinkedListNode<Token> currentToken, NodeLinkedList compiled)
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
                compiled.Add(new DirectFunctionCall("ConstantToReturn", leftToken.Value));
                compiled.Add(new DirectFunctionCall("ReturnToVariable", leftName));
            }
            if (rightToken.TokenType != TokenType.Identifier)
            {
                rightName = getUniqueId();
                compiled.Add(new DirectFunctionCall("ConstantToReturn", rightToken.Value));
                compiled.Add(new DirectFunctionCall("ReturnToVariable", rightName));
            }

            switch (operatorToken.TokenType)
            {
                case TokenType.EqualsEquals:
                    compiled.Add(new FunctionCall("IsIs", leftName, rightName));
                    break;
                // etc.
                default:
                    break;
            }
            currentToken = currentToken.Next;
            Console.WriteLine("condition");
            return compiled;
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
