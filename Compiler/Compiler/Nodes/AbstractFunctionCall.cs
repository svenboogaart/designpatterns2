using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Nodes
{
    public abstract class AbstractFunctionCall : Node
    {
        public string[] parameters;
        public override void Accept(VirtualMachine.NodeVisitor visitor)
        {

        }
    }
}
