﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.VirtualMachine.Command
{
    class ReturnToVariableCommand : BaseCommand
    {
        public override void Execute(VM vm, IList<string> parameters)
        {
            //parameters 0 overslaan, dit is de naam van de functie.
            vm.SetVariable(parameters[1], vm.ReturnValue);

        }
    }
}
