using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.VirtualMachine.Command
{
    public abstract class BaseCommand
    {
        public abstract void Execute(VM vm, IList<string> parameters);
    }
}
