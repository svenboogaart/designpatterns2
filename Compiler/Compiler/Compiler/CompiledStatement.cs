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
        public NodeLinkedList Compiled;

        public CompiledStatement()
        {
            Compiled = new NodeLinkedList();
        }

        public abstract NodeLinkedList Compile(ref LinkedListNode<Token> currentToken);

        public Node GetLastNode()
        {
            return Compiled.Last;
        }

        public abstract CompiledStatement clone();
        public abstract bool isMatch(LinkedListNode<Token> token);

        public static string getUniqueId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
