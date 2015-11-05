using Compiler.Nodes;
using Compiler.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Compiler
{
    public class CompiledPlus : CompiledStatement
    {
        public override Nodes.NodeLinkedList Compile(ref LinkedListNode<Token> currentToken, NodeLinkedList compiled)
        {
            throw new NotImplementedException();
        }

        public override CompiledStatement clone()
        {
            return new CompiledPlus();
        }

        public override bool isMatch(LinkedListNode<Tokenizer.Token> token)
        {
            throw new NotImplementedException();
        }
    }
}
