using Compiler.Tokenizer;
using Compiler.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Compiler
{
    public abstract class Compiler
    {
        public abstract void Compile(LinkedListNode<Token> currentToken);

        public abstract void Clone();

        public abstract bool IsMatch(LinkedListNode<Token> currentToken);
    }
}
