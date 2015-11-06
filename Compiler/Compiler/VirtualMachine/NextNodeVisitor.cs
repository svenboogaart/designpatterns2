using Compiler.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.VirtualMachine
{
    public class NextNodeVisitor : NodeVisitor
    {
        public Node NextNode { get; private set; }
        public void Visit(DoNothing node)
        {
            NextNode = node.Next;
        }


        public void Visit(Jump node)
        {
            NextNode = node.JumpTo;
        }

        public override void Visit(Node node)
        {

        }


        //Zorg ervoor dat hij bij de returnvalue van de virtualmachine kan.
        public void Visit(ConditionalJump node)
        {
            //
        }
        public void Visit(DirectFunctionCall node)
        {
            //
        }
        public void Visit(FunctionCall node)
        {
            //
        }
    }
}

