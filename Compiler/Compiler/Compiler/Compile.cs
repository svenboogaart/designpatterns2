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
    public class Compile
    {
        public static CustomLinkedList<Node> CompiledNodes;

        public static void compile(CustomLinkedList<Token> list)
        {
            CustomLLNode<Token> currentToken = list.First;
            //firstToken = firstToken.Next;
            while (currentToken != list.Last)
            {
                CompiledStatement cs = CompilerFactory.Instance.CreateCompiledStatement(currentToken);
                CompiledNodes = cs.Compile(ref currentToken);
            }    

            CustomLLNode<Node> node = CompiledNodes.First;
            while(node != null)
            {
                Console.WriteLine(node.Value.GetType());
                node = node.Next;
            }
        }
    }
}
