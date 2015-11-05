using Compiler.VirtualMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Nodes
{
    public abstract class Node
    {

        private Node prev;
        public Node Prev
        {
            get { return prev; }
            set { prev = value; }
        }
        private Node next;
        public Node Next
        {
            get { return next; }
            set { next = value; }
        }
        public abstract void Accept(NodeVisitor visitor);
    }
}
