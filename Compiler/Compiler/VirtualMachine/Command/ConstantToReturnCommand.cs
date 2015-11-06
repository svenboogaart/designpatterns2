
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.VirtualMachine.Command
{
    public class ConstantToReturnCommand : BaseCommand
    {
        public override void Execute(VM vm, IList<string> parameters)
        {
            vm.ReturnValue = parameters[1];
        }
    }
}
