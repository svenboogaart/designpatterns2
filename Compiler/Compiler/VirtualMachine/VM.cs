using Compiler.Nodes;
using Compiler.VirtualMachine.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.VirtualMachine
{
    public class VM
    {

        private Dictionary<string, BaseCommand> myCommands;
        public string ReturnValue;
        public Dictionary<string, string> myVariables;
       
        public VM()
        {
            myCommands = new Dictionary<string,BaseCommand>();
            myVariables = new Dictionary<string, string>();
            loadCommands();
        }

        public void Run(NodeLinkedList list)
        {
            Node currentNode = list.First;
            NextNodeVisitor visitor = new NextNodeVisitor(this);

            while(currentNode != null)
            {
                AbstractFunctionCall actionNode = currentNode as AbstractFunctionCall;
                if(actionNode != null)
                {
                    string name = actionNode.parameters[0];
                    myCommands[name].Execute(this, actionNode.parameters);

                }
                // Bepaal de volgende node
                currentNode.Accept(visitor);
                currentNode = visitor.NextNode;
            }
        }

        public void SetVariable(string key, string value)
        {
            if (!myVariables.ContainsKey(key))
            {
                myVariables.Add(key, value); 
            }
            else
            {
                myVariables[key] = value;
            }
           
        }

        public string GetVariable(string key)
        {
            if (myVariables.ContainsKey(key))
                return myVariables[key];
            return null;
        }

        private void loadCommands()
        {
            myCommands.Add("ReturnToVariable", new ReturnToVariableCommand());
            myCommands.Add("Print", new PrintCommand());
            myCommands.Add("Add", new AddCommand());
            myCommands.Add("ConstantToReturn", new ConstantToReturnCommand());
            myCommands.Add("IsIs", new IsIsCommand());
        }
    }
}
