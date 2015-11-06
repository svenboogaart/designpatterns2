using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Nodes
{
    public class ConditionalJump : Node
    {
        public Node JumpOnFalse { get; set; }
        public Node JumpOnTrue { get; set; }
        public override void Accept(VirtualMachine.NodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
