using Compiler.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.VirtualMachine
{
    public interface RunNode
    {
        CustomLLNode<RunNode> NextNode(CustomLLNode<RunNode> runNode);
        void Show();
    }
}
