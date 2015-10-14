using Compiler.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Compiler
{
    public class CompileAssignment : Compiler
    {
        public override void Compile(LinkedListNode<Token> currentToken)
        {
            string variableName = currentToken.Previous.Value.Value;
            LinkedListNode<Token> nextToken = currentToken.Next;
            

        }
    }
}
