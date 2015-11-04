using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Nodes
{
    public class FunctionCall : AbstractFunctionCall
    {
        private string name;
        private string left;
        private string right;
        public FunctionCall(string name, string left, string right) 
        {
            this.name = name;
            this.left = left;
            this.right = right;
        }
        public override void Accept(VirtualMachine.NodeVisitor visitor)
        {

        }
    }
}
