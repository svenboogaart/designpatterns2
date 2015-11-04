using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Nodes
{
    public class DirectFunctionCall : AbstractFunctionCall
    {
        private string name;
        private string value;

        public DirectFunctionCall(string name, string value) {
            this.name = name;
            this.value = value;
        }
        public override void Accept(VirtualMachine.NodeVisitor visitor)
        {
            
        }
    }
}
