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
        private NodeLinkedList _condition;
        private NodeLinkedList _body;

        public CompiledWhile()
        {
            Compiled = new NodeLinkedList();
            _condition = new NodeLinkedList();
            _body = new NodeLinkedList();

            var conditionalJumpNode = new ConditionalJump();
            var jumpBackNode = new Jump();

            Compiled.Add(new DoNothing());
            Compiled.Add(_condition);
            Compiled.Add(conditionalJumpNode);
            Compiled.Add(_body);
            Compiled.Add(jumpBackNode);
            Compiled.Add(new DoNothing());


            jumpBackNode.JumpTo = Compiled.First; 
            conditionalJumpNode.JumpOnTrue = _body.First; 
            conditionalJumpNode.JumpOnFalse = Compiled.Last;
        }
        public override NodeLinkedList Compile(ref LinkedListNode<Token> currentToken)
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
                        currentToken = currentToken.Next;
                    }
                }
                else if (expectation.Level >= whileLevel)
                {
                    if (_condition == null) 
                    {
                        var compiledCondition = new CompiledCondition();
                        compiledCondition.Compile(ref currentToken);
                        _condition.Add(compiledCondition.Compiled);
                    }
                    else
                    {
                        while (currentToken.Value.Level > whileLevel) 
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
