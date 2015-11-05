using Compiler.Nodes;
using Compiler.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Compiler
{
    public abstract class CompiledStatement
    {

        public CompiledStatement()
        {
        }

        public abstract NodeLinkedList Compile(ref LinkedListNode<Token> currentToken, NodeLinkedList compiled);

        /*public Node GetLastNode()
        {
            return Compiled.Last;
        }*/

        public abstract CompiledStatement clone();
        public abstract bool isMatch(LinkedListNode<Token> token);

        public static string getUniqueId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
