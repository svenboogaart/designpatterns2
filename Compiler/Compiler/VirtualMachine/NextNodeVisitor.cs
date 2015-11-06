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
        public NextNodeVisitor(VM vm) : base(vm)
        {

        }
        public Node NextNode { get; private set; }
        public override void Visit(DoNothing node)
        {
            NextNode = node.Next;
        }

        public override void Visit(Jump node)
        {
            NextNode = node.JumpTo;
        }

        public override void Visit(ConditionalJump node)
        {
            if (Convert.ToBoolean(vm.ReturnValue))
            {
                NextNode = node.JumpOnTrue;
            }
            else
            {
                NextNode = node.JumpOnFalse;
            }
        }
        public override void Visit(DirectFunctionCall node)
        {
            NextNode = node.Next;
        }
        public override void Visit(FunctionCall node)
        {
            NextNode = node.Next;
        }
    }
}

