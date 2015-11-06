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
        public override void Visit(DoNothing node)
        {
            NextNode = node.Next;
        }


        public override void Visit(Jump node)
        {
            NextNode = node.JumpTo;
        }



        //Zorg ervoor dat hij bij de returnvalue van de virtualmachine kan.
        public override void Visit(ConditionalJump node)
        {
            //
        }
        public override void Visit(DirectFunctionCall node)
        {
            //
        }
        public override void Visit(FunctionCall node)
        {
            //
        }
    }
}

