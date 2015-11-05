using Compiler.Nodes;
using Compiler.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Compiler
{
    public class Compile
    {
        public static NodeLinkedList CompiledNodes;

        public static void compile(LinkedList<Token> list)
        {
            LinkedListNode<Token> currentToken = list.First;
            //firstToken = firstToken.Next;
            while (currentToken != list.Last)
            {
                CompiledStatement cs = CompilerFactory.Instance.CreateCompiledStatement(currentToken);
                CompiledNodes = cs.Compile(ref currentToken);
            }

            Node node = CompiledNodes.First;
            while(node != null)
            {
                Console.WriteLine(node.GetType());
                node = node.Next;
            }
        }
    }
}
