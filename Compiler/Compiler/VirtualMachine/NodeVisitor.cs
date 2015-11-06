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
        public abstract void Visit(Jump node);

        public abstract void Visit(DoNothing node);


        //Zorg ervoor dat hij bij de returnvalue van de virtualmachine kan.
        public abstract void Visit(ConditionalJump node);

        public abstract void Visit(DirectFunctionCall node);

        public abstract void Visit(FunctionCall node);
    }
}
