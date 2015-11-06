using Compiler.Nodes;
using Compiler.VirtualMachine.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.VirtualMachine
{
    public class VirtualMachine
    {

        private Dictionary<string, BaseCommand> myCommands;
        public string ReturnValue;
        public Dictionary<string, string> myVariables;


       
        public VirtualMachine()
        {
            myCommands = new Dictionary<string,BaseCommand>();
            loadCommands();
        }

        public void Run(NodeLinkedList list)
        {
            Node currentNode = list.First;
            NextNodeVisitor visitor = new NextNodeVisitor();

            while(currentNode != null)
            {
                // doe iets met de huidige node swa
                //  Command pattern je weet zelf

                // Bepaal de volgende node
                currentNode.Accept(visitor);
                currentNode = visitor.NextNode;
            }
        }

        public void SetVariable(string key, string value)
        {
            myVariables.Add(key, value); 
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
            myCommands.Add("Plus", new PlusCommand());;
        }
    }
}
