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

        public override NodeLinkedList Compile(ref LinkedListNode<Token> currentToken)
        {
            var variableName = currentToken.Value.Value;

            //var rightCompiled = CompilerFactory.Instance.CreateCompiledStatement(currentToken);

            //this.Compiled.Add(rightCompiled.Compiled);
            this.Compiled.Add(new DirectFunctionCall("ReturnToVariable", variableName));

            currentToken = currentToken.Next.Next;
            return Compiled;
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
