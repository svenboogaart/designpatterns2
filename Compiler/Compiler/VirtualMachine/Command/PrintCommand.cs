﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.VirtualMachine.Command
{
    class PrintCommand : BaseCommand
    {
        public override void Execute(VM vm, IList<string> parameters)
        {
            string toPrint = vm.GetVariable(parameters[1]);
            
            Console.WriteLine(toPrint);
        }
    }
}
