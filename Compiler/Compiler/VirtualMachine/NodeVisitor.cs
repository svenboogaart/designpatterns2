﻿using Compiler.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.VirtualMachine
{
    public abstract class NodeVisitor
    {
        public abstract void Visit(Node node);
    }
}
