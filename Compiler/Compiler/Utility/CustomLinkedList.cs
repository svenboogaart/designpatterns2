using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Utility
{
    public class CustomLinkedList<T>
    {
        private CustomLLNode<T> first;
        public CustomLLNode<T> First { get { return first; } }

        private CustomLLNode<T> last;
        public CustomLLNode<T> Last { get { return last; } }

        private int count;
        public int Count { get { return count; } }

        public CustomLLNode<T> InsertFirst(T value)
        {
            CustomLLNode<T> node = new CustomLLNode<T>();
            node.Value = value;
            count += 1;

            if (first == null)
            {
                this.first = this.last = node;
            }
            else
            {
                this.first.Previous = node;
                node.Next = this.first;
                this.first = node;
            }

            return node;
        }

        public CustomLLNode<T> InsertLast(T value)
        {
            CustomLLNode<T> node = new CustomLLNode<T>();
            node.Value = value;
            count += 1;

            if (first == null)
            {
                this.first = this.last = node;
            }
            else
            {
                this.last.Next = node;
                node.Previous = this.last;
                this.last = node;
            }

            return node;
        }

        public CustomLLNode<T> InsertList(CustomLinkedList<T> list)
        {
            count += list.Count;

            if (first == null)
            {
                this.first = list.First;
                this.last = list.Last;
            }
            else
            {
                this.last.Next = list.First;
                list.First.Previous = this.last;
                this.last = list.Last;
            }

            return last;
        }

        public CustomLLNode<T> InsertBefore(CustomLLNode<T> right, T value)
        {
            if (right == null)
            {
                return this.InsertLast(value);
            }
            else
            {
                CustomLLNode<T> node = new CustomLLNode<T>();
                CustomLLNode<T> left = right.Previous;

                node.Value = value;
                count += 1;

                node.Next = right;
                right.Previous = node;

                if (left == null)
                {
                    this.first = node;
                }
                else
                {
                    left.Next = node;
                    node.Previous = left;
                }
                return node;
            }
        }
    }
}
