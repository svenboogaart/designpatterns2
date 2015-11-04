using Compiler.Nodes;
using Compiler.Tokenizer;
using Compiler.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Compiler
{
    public class CompiledWhile : CompiledStatement
    {

        public override CustomLinkedList<Node> Compile(ref CustomLLNode<Token> currentToken)
        {
            Compiled.InsertLast(new DoNothing());
            CompiledStatement condition = CompilerFactory.Instance.CreateCompiledStatement(currentToken.Next);
            CustomLLNode<Token> nextToken = currentToken.Next;
            Compiled.InsertList(condition.Compile(ref nextToken));

            return Compiled;
        }

        public override CompiledStatement clone()
        {
            return new CompiledWhile();
        }

        public override bool isMatch(Utility.CustomLLNode<Token> token)
        {
            return token.Value.TokenType == TokenType.WhileToken;
        }
    }
}
