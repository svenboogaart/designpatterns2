using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.VirtualMachine.Commands
{
    class PlusCommand : BaseCommand
    {
        public override void Execute(VirtualMachine vm, IList<string> parameterNames)
        {
            //Function calls bevatten namen van variablen (niet de waarden zelf)
            string variable1 = vm.GetVariable(parameterNames[1]);
            string variable2 = vm.GetVariable(parameterNames[2]);
            /*
            if(variable1.Type == VariableType.NUMBER && variable2.Type == VariableType.NUMBER)
            {
                vm.ReturnValue = (Int32.Parse(variable1.Value) + Int32.Parse(variable2.Value)).ToString();
            }
            else
            {
                vm.ReturnValue = variable1.Value + variable2.Value;
            }	        
             */
            vm.ReturnValue = variable1 + variable2;
        }
    }    
}
    

