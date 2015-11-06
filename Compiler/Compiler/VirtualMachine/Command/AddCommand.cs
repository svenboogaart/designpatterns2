using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.VirtualMachine.Command
{
    public class AddCommand : BaseCommand
    {

        public override void Execute(VM vm, IList<string> parameters)
        {
            string variable1 = vm.GetVariable(parameters[1]);
            string variable2 = vm.GetVariable(parameters[2]);
            
            int leftHand = Int32.Parse(variable1);
            int rightHand = Int32.Parse(variable2);

            string value = (leftHand + rightHand).ToString();

            vm.ReturnValue = value;
        }
    }
}
