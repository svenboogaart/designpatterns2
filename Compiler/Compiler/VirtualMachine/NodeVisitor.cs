using Compiler.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.VirtualMachine
{
    public abstract class NodeVisitor
    {
        protected VM vm;

        public NodeVisitor(VM vm)
        {
            this.vm = vm;
        }

        public abstract void Visit(Jump node);

        public abstract void Visit(DoNothing node);

        public abstract void Visit(ConditionalJump node);

        public abstract void Visit(DirectFunctionCall node);

        public abstract void Visit(FunctionCall node);
    }
}
