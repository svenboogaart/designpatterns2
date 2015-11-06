using Compiler.Nodes;
using Compiler.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Compiler
{
    class CompiledUnairyOperator : CompiledStatement
    {
        public override NodeLinkedList Compile(ref LinkedListNode<Token> currentToken, NodeLinkedList compiled)
        {
            string left;
            string right;
            Token leftToken = currentToken.Value;
            left = leftToken.Value;

            currentToken = currentToken.Next;
            Token rightToken = currentToken.Value;
            right = getUniqueId();

            compiled.Add(new DirectFunctionCall("ConstantToReturn", "1"));
            compiled.Add(new DirectFunctionCall("ReturnToVariable", right));

            if (currentToken.Value.TokenType == TokenType.Increment)
            {
                compiled.Add(new FunctionCall("Add", left, right));
            }

            compiled.Add(new DirectFunctionCall("ReturnToVariable", left));
            currentToken = currentToken.Next;
            return compiled;
        }

        public override CompiledStatement clone()
        {
            return new CompiledUnairyOperator();
        }

        public override bool isMatch(LinkedListNode<Token> token)
        {
            return token.Value.TokenType == TokenType.Identifier && token.Next.Value.TokenType == TokenType.Increment;
        }
    }
}
