using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Nodes
{
    public class FunctionCall : AbstractFunctionCall
    {
        public FunctionCall(string name, string left, string right) 
        {
            parameters = new string[3] { name, left, right };
        }

        public FunctionCall(string name, string left)
        {
            parameters = new string[2] { name, left };
        }

        public override void Accept(VirtualMachine.NodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
