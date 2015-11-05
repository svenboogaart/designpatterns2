using Compiler.Nodes;
using Compiler.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Compiler
{
    public class CompiledIf : CompiledStatement
    {
        public override NodeLinkedList Compile(ref LinkedListNode<Token> currentToken)
        {
            throw new NotImplementedException();
        }

        public override CompiledStatement clone()
        {
            throw new NotImplementedException();
        }

        public override bool isMatch(LinkedListNode<Token> token)
        {
            throw new NotImplementedException();
        }
    }
}
