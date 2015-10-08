using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Utility;

namespace Compiler.Tokenizer
{
    public class Tokenize
    {
        CustomLinkedList<Token> tokens;
        public CustomLinkedList<Token> Tokenizer(String input)
        {
            tokens = new CustomLinkedList<Token>();
            input = input.Replace(System.Environment.NewLine, " ");
            string[] parts = input.Split(new string[] { " " }, StringSplitOptions.None);
            foreach (string part in parts)
            {
                checkToken(part.Trim());
            }
            return null;
        }

        public void checkToken(String token)
        {
            switch (token)
            {
                case "begincode":
                    tokens.InsertLast(new Token(TokenType.BracketsOpen,token));
                    Console.WriteLine(token + " " + TokenType.BracketsOpen);
                    break;
                case "eindcode":
                    tokens.InsertLast(new Token(TokenType.BracketsClose, token));
                    Console.WriteLine(token + " " + TokenType.BracketsClose);
                    break;
                case "als":
                    tokens.InsertLast(new Token(TokenType.IfToken, token));
                    Console.WriteLine(token + " " + TokenType.IfToken);
                    break;
                case "andersals":
                    tokens.InsertLast(new Token(TokenType.IfelseToken, token));
                    Console.WriteLine(token + " " + TokenType.IfelseToken);
                    break;
                case "anders":
                    tokens.InsertLast(new Token(TokenType.ElseToken, token));
                    Console.WriteLine(token + " " + TokenType.ElseToken);
                    break;
                case "woord":
                    tokens.InsertLast(new Token(TokenType.TypeString, token));
                    Console.WriteLine(token + " " + TokenType.TypeString);
                    break;
                case "getal":
                    tokens.InsertLast(new Token(TokenType.TypeNumber, token));
                    Console.WriteLine(token + " " + TokenType.TypeNumber);
                    break;
                case "letter":
                    tokens.InsertLast(new Token(TokenType.TypeChar, token));
                    Console.WriteLine(token + " " + TokenType.TypeChar);
                    break;
                case "wordt":
                    tokens.InsertLast(new Token(TokenType.Equals, token));
                    Console.WriteLine(token + " " + TokenType.Equals);
                    break;
                case "is":
                    tokens.InsertLast(new Token(TokenType.EqualsEquals, token));
                    Console.WriteLine(token + " " + TokenType.EqualsEquals);
                    break;
                case "verhogen":
                    tokens.InsertLast(new Token(TokenType.Increment, token));
                    Console.WriteLine(token + " " + TokenType.Increment);
                    break;
                case "verlagen":
                    tokens.InsertLast(new Token(TokenType.Decrement, token));
                    Console.WriteLine(token + " " + TokenType.Decrement);
                    break;
                case "einde":
                    tokens.InsertLast(new Token(TokenType.EndStatement, token));
                    Console.WriteLine(token + " " + TokenType.EndStatement);
                    break;
                default:
                    tokens.InsertLast(new Token(CheckType(token), token));
                    Console.WriteLine(token + " " + CheckType(token));
                    break;
            }
        }

        public TokenType CheckType(string input)
        {
            if (input.Length == 0)
            {
                Console.WriteLine("LEGE INPUT: -" + input + "-");
                return TokenType.Empty;
            }
            if (input.Length == 1)
            {
                if (input[0] < '0' || input[0] > '9')
                {
                    return TokenType.Number;
                }
                else
                {
                    return TokenType.Char;
                }
            }
            for (int i = 0; i < input.Length; i ++ )
            {
                if (!(input[i] < '0') || !(input[i] > '9'))
                {
                    return TokenType.String;
                }
            }
            return TokenType.Number;
        }
    }
}
