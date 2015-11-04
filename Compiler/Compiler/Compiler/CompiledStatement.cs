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
    public abstract class CompiledStatement
    {
        public CustomLinkedList<Node> Compiled;

        public CompiledStatement()
        {
            Compiled = new CustomLinkedList<Node>();
        }

        public abstract CustomLinkedList<Node> Compile(ref CustomLLNode<Token> currentToken);

        public CustomLLNode<Node> GetLastNode()
        {
            return Compiled.Last;
        }

        public abstract CompiledStatement clone();
        public abstract bool isMatch(CustomLLNode<Token> token);

        /*public static string getUniqueId()
        {
            return Guid.NewGuid().ToString();
        }*/
    }
}
