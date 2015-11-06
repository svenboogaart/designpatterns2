﻿using Compiler.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Compiler
{
    public class CompiledPrint : CompiledStatement
    {
        public override Nodes.NodeLinkedList Compile(ref LinkedListNode<Tokenizer.Token> currentToken, Nodes.NodeLinkedList compiled)
        {
            compiled.Add(new FunctionCall("Print",currentToken.Next.Value.Value));
            currentToken = currentToken.Next.Next;
            return compiled;
        }

        public override CompiledStatement clone()
        {
            return new CompiledPrint();
        }

        public override bool isMatch(LinkedListNode<Tokenizer.Token> token)
        {
            return token.Value.TokenType == Tokenizer.TokenType.Print;
        }
    }
}
