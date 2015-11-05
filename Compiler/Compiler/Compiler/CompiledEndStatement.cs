using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Compiler
{
    public class CompiledEndStatement:CompiledStatement
    {

        public override Nodes.NodeLinkedList Compile(ref LinkedListNode<Tokenizer.Token> currentToken, Nodes.NodeLinkedList compiled)
        {
            currentToken = currentToken.Next;
            return compiled;
        }

        public override CompiledStatement clone()
        {
            return new CompiledEndStatement();
        }

        public override bool isMatch(LinkedListNode<Tokenizer.Token> token)
        {
            return token.Value.TokenType == Tokenizer.TokenType.EndStatement;
        }
    }
}
