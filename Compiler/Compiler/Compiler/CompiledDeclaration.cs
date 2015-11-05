using Compiler.Nodes;
using Compiler.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Compiler
{
    public class CompiledDeclaration : CompiledStatement
    {
        public override NodeLinkedList Compile(ref LinkedListNode<Token> currentToken, NodeLinkedList compiled)
        {
            currentToken = currentToken.Next;
            return compiled;
        }

        public override CompiledStatement clone()
        {
            return new CompiledDeclaration();
        }

        public override bool isMatch(LinkedListNode<Token> token)
        {
            return (token.Value.TokenType == TokenType.TypeNumber || token.Value.TokenType == TokenType.TypeChar || token.Value.TokenType == TokenType.TypeString) && token.Next.Value.TokenType == TokenType.Identifier;
        }
    }
}
