using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Utility
{
    public class CustomLLNode<T>
    {
        public T Value { get; set; }
        public CustomLLNode<T> Previous { get; set; }
        public CustomLLNode<T> Next { get; set; }
    }
}
