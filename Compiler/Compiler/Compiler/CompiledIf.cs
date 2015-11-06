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
        private NodeLinkedList _compiledStatement;
        private NodeLinkedList _condition;
        private NodeLinkedList _body;
        private bool conditionDone;
        private ConditionalJump conditionalJumpNode = new ConditionalJump();

        public CompiledIf()
        {
            _compiledStatement = new NodeLinkedList();
            _condition = new NodeLinkedList();
            _body = new NodeLinkedList();
            conditionDone = false;
        }

        public override NodeLinkedList Compile(ref LinkedListNode<Token> currentToken, NodeLinkedList compiled)
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
                        if (currentToken.Next != null)
                            currentToken = currentToken.Next;
                    }
                }
                else if (expectation.Level >= ifLevel)
                {
                    if (!conditionDone) 
                    {
                        var compiledCondition = new CompiledCondition();
                        
                        _condition = compiledCondition.Compile(ref currentToken, _condition);
                        conditionDone = true;
                        _compiledStatement.Add(_condition);
                        _compiledStatement.Add(conditionalJumpNode);
                    }
                    else
                    {
                        while (currentToken.Value.Level > ifLevel) 
                        {
                            var compiledBodyPart = CompilerFactory.Instance.CreateCompiledStatement(currentToken);
                            
                            _body = compiledBodyPart.Compile(ref currentToken, _body);
                        };
                    }
                }
            }
            _compiledStatement.Add(_body);
            conditionalJumpNode.JumpOnTrue = _body.First;
            DoNothing doNothing = new DoNothing();
            _compiledStatement.Add(doNothing);
            conditionalJumpNode.JumpOnFalse = doNothing;
            compiled.Add(_compiledStatement);    
            return compiled;
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
