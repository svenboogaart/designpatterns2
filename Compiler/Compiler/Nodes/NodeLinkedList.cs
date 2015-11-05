using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Nodes
{
    public class NodeLinkedList
    {
        private Node first;
        public Node First
        {
            get { return first; }
            private set { first = value; }
        }
        private Node last;
        public Node Last
        {
            get { return last; }
            private set { last = value; }
        }
        public NodeLinkedList()
        {
            last = new DoNothing();
            first = new DoNothing();
            first.Next = last;
            last.Prev = first;
        }
        public void Add(Node node)
        {
            Node foreLast = last.Prev;
            last.Prev = node;
            node.Next = last;
            foreLast.Next = node;
            node.Prev = foreLast;
        }

        public void Add(NodeLinkedList nll)
        {
            last.Next = nll.first;
            nll.first.Prev = last;
            last = nll.last;
        }
    }
}
