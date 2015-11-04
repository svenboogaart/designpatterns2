using Compiler.Utility;
using Compiler.VirtualMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Nodes
{
    public abstract class Node
    {
        public abstract void Accept(NodeVisitor visitor);
    }
}
