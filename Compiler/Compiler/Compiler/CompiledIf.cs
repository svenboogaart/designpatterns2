using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Compiler
{
    public class CompiledIf : CompiledStatement
    {
        public override Utility.CustomLinkedList<Nodes.Node> Compile(ref Utility.CustomLLNode<Tokenizer.Token> currentToken)
        {
            throw new NotImplementedException();
        }

        public override CompiledStatement clone()
        {
            throw new NotImplementedException();
        }

        public override bool isMatch(Utility.CustomLLNode<Tokenizer.Token> token)
        {
            throw new NotImplementedException();
        }
    }
}
