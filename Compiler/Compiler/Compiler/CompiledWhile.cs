using Compiler.Nodes;
using Compiler.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Compiler
{
    public class CompiledWhile : CompiledStatement
    {
        private NodeLinkedList _compiledStatement;
        private NodeLinkedList _condition;
        private NodeLinkedList _body;
        private ConditionalJump conditionalJumpNode;
        private bool conditionDone;
        private Jump jumpBackNode;

        public CompiledWhile()
        {
            _compiledStatement = new NodeLinkedList();
            _condition = new NodeLinkedList();
            _body = new NodeLinkedList();
            conditionalJumpNode = new ConditionalJump();
            jumpBackNode = new Jump();
            conditionDone = false;
        }

        public override NodeLinkedList Compile(ref LinkedListNode<Token> currentToken, NodeLinkedList compiled)
        {
            int whileLevel = currentToken.Value.Level;

            List<TokenExpectation> expected = new List<TokenExpectation>()
            {
                new TokenExpectation(whileLevel, TokenType.WhileToken), 
                new TokenExpectation(whileLevel, TokenType.BracketsOpen),
                new TokenExpectation(whileLevel + 1, TokenType.Any),
                new TokenExpectation(whileLevel, TokenType.BracketsClose),
                new TokenExpectation(whileLevel, TokenType.StartCode), 
                new TokenExpectation(whileLevel + 1, TokenType.Any),
                new TokenExpectation(whileLevel, TokenType.EndCode)
            };

            foreach (var expectation in expected)
            {
                if (expectation.Level == whileLevel)
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
                else if (expectation.Level >= whileLevel)
                {
                    if (!conditionDone) 
                    {
                        var compiledCondition = new CompiledCondition();
                        _condition = compiledCondition.Compile(ref currentToken,_condition);
                        _compiledStatement.Add(_condition);
                        _compiledStatement.Add(conditionalJumpNode);
                        conditionDone = true;
                    }
                    else
                    {
                        while (currentToken.Value.Level > whileLevel) 
                        {
                            var compiledBodyPart = CompilerFactory.Instance.CreateCompiledStatement(currentToken);
                            _body = compiledBodyPart.Compile(ref currentToken,_body);
                        }
                    }
                }
            }
            Console.WriteLine("while");
            
            _compiledStatement.Add(_body);
            _compiledStatement.Add(jumpBackNode);
            conditionalJumpNode.JumpOnTrue = _body.First;
            conditionalJumpNode.JumpOnFalse = _compiledStatement.Last;
            jumpBackNode.JumpTo = _compiledStatement.First; 
            compiled.Add(_compiledStatement);       
            return compiled;
        }

        public override CompiledStatement clone()
        {
            return new CompiledWhile();
        }

        public override bool isMatch(LinkedListNode<Token> token)
        {
            return token.Value.TokenType == TokenType.WhileToken;
        }
    }

    public struct TokenExpectation
    {
        public int Level;
        public TokenType TokenType;

        public TokenExpectation(int level, TokenType tokenType)
        {
            Level = level;
            TokenType = tokenType;
        }
    }
}
