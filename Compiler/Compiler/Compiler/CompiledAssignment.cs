using Compiler.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Utility;
using Compiler.Nodes;

namespace Compiler.Compiler
{
    public class CompiledAssignment : CompiledStatement
    {

        public override CustomLinkedList<Node> Compile(ref CustomLLNode<Token> currentToken)
        {
            var variableName = currentToken.Value.Value;
            

            //var rightCompiled = CompilerFactory.Instance.CreateCompiledStatement(currentToken);

            //this.Compiled.InsertLastList(rightCompiled.Compiled);
            this.Compiled.InsertLast(new DirectFunctionCall("ReturnToVariable", variableName));

            currentToken = currentToken.Next.Next;
            return Compiled;
        }

        public override CompiledStatement clone()
        {
            return new CompiledAssignment();
        }

        public override bool isMatch(CustomLLNode<Token> token)
        {
            return token.Value.TokenType == TokenType.Identifier && token.Next.Value.TokenType == TokenType.Equals;
        }
    }
}
