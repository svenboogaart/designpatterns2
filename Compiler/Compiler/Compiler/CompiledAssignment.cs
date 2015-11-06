using Compiler.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Nodes;

namespace Compiler.Compiler
{
    public class CompiledAssignment : CompiledStatement
    {

        public override NodeLinkedList Compile(ref LinkedListNode<Token> currentToken, NodeLinkedList compiled)
        {
            var variableName = currentToken.Value.Value;
            currentToken = currentToken.Next.Next;

            CompiledStatement rightCompiled = CompilerFactory.Instance.CreateCompiledStatement(currentToken);
            compiled = rightCompiled.Compile(ref currentToken,compiled);


            compiled.Add(new DirectFunctionCall("ReturnToVariable", variableName));   
            return compiled;
        }

        public override CompiledStatement clone()
        {
            return new CompiledAssignment();
        }

        public override bool isMatch(LinkedListNode<Token> token)
        {
            return token.Value.TokenType == TokenType.Identifier && token.Next.Value.TokenType == TokenType.Equals;
        }
    }
}
