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
        private static int localCounter = 0;

        public CustomLLNode<Token> GetLastNode(CustomLinkedList<Token> tokenList, CustomLLNode<Token> current)
        {
            return current;
        }

        /*public abstract void Compile(CustomLinkedList<Token> tokenList
                                , CustomLLNode<Token> begin
                                , CustomLLNode<Token> end
                                , CustomLinkedList<RunNode> runList
                                , CustomLLNode<RunNode> before);*/
        
        protected static string GetNextLocalVariableName()
        {
            return " " + (++localCounter);
        }
    }
}
