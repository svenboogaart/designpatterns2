using Compiler.Nodes;
using Compiler.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Compiler
{
    public class CompiledIf : CompiledStatement
    {
        private NodeLinkedList _condition;
        private NodeLinkedList _body;

        public CompiledIf():base()
        {
            _condition = new NodeLinkedList();
            _body = new NodeLinkedList();

            var conditionalJumpNode = new ConditionalJump();

            Compiled.Add(_condition);
            Compiled.Add(conditionalJumpNode);
            Compiled.Add(_body);

            conditionalJumpNode.JumpOnTrue = _body.First; 
            conditionalJumpNode.JumpOnFalse = Compiled.Last;
        }
        public override NodeLinkedList Compile(ref LinkedListNode<Token> currentToken)
        {
            int ifLevel = currentToken.Value.Level;

            List<TokenExpectation> expected = new List<TokenExpectation>()
            {
                new TokenExpectation(ifLevel, TokenType.IfToken), 
                new TokenExpectation(ifLevel, TokenType.BracketsOpen),
                new TokenExpectation(ifLevel + 1, TokenType.Any),
                new TokenExpectation(ifLevel, TokenType.BracketsClose),
                new TokenExpectation(ifLevel, TokenType.StartCode), 
                new TokenExpectation(ifLevel + 1, TokenType.Any),
                new TokenExpectation(ifLevel, TokenType.EndCode)
            };

            foreach (var expectation in expected)
            {
                if (expectation.Level == ifLevel)
                {
                    if (currentToken.Value.TokenType != expectation.TokenType)
                    {
                        throw new Exception(String.Format("Unexpected end of statement, expected {0}", expectation.TokenType));
                    }
                    else
                    {
                        currentToken = currentToken.Next;
                    }
                }
                else if (expectation.Level >= ifLevel)
                {
                    if (_condition == null) 
                    {
                        var compiledCondition = new CompiledCondition();
                        compiledCondition.Compile(ref currentToken);
                        _condition.Add(compiledCondition.Compiled);
                    }
                    else
                    {
                        while (currentToken.Value.Level > ifLevel) 
                        {
                            var compiledBodyPart = CompilerFactory.Instance.CreateCompiledStatement(currentToken);
                            compiledBodyPart.Compile(ref currentToken);
                            _body.Add(compiledBodyPart.Compiled);
                        };
                    }
                }
            }

            return Compiled;
        }

        public override CompiledStatement clone()
        {
            return new CompiledIf();
        }

        public override bool isMatch(LinkedListNode<Token> token)
        {
            return token.Value.TokenType == TokenType.IfToken;
        }
    }
}
