using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Nodes
{
    public class Jump : Node
    {
        public Node JumpTo { get; set; }
        public override void Accept(VirtualMachine.NodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
