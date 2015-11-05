using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Nodes
{
    public class DirectFunctionCall : AbstractFunctionCall
    {
        
        public DirectFunctionCall(string name, string value) {
            parameters = new string[2] { name, value };
        }
        public override void Accept(VirtualMachine.NodeVisitor visitor)
        {
            
        }
    }
}
