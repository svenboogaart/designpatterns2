using Compiler.Nodes;
using Compiler.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Compiler
{
    public class CompiledConstant : CompiledStatement
    {

        public override Nodes.NodeLinkedList Compile(ref LinkedListNode<Token> currentToken, NodeLinkedList compiled)
        {
            compiled.Add(new DirectFunctionCall("ConstantToReturn", currentToken.Value.Value));
            compiled.Add(new DirectFunctionCall("ReturnToVariable", getUniqueId()));
            currentToken = currentToken.Next;
            return compiled;
        }

        public override CompiledStatement clone()
        {
            return new CompiledConstant();
        }

        public override bool isMatch(LinkedListNode<Token> token)
        {
            return token.Value.TokenType == TokenType.Number && token.Next.Value.TokenType == TokenType.EndStatement;
        }
    }
}
