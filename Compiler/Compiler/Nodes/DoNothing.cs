using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Nodes
{
    public class DoNothing : Node
    {

        public override void Accept(VirtualMachine.NodeVisitor visitor)
        {
            
        }
    }
}
