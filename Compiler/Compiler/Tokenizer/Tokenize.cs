using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Utility;
using System.IO;

namespace Compiler.Tokenizer
{
    public class Tokenize
    {
        CustomLinkedList<Token> tokens;
        public CustomLinkedList<Token> Tokenizer(String input)
        {
            Console.WriteLine(input);
            int level = 1;
            int line = 1;
            tokens = new CustomLinkedList<Token>();
            Stack<Token> partnerStack = new Stack<Token>();
            using (StringReader reader = new StringReader(input))
            {
                string sline;
                while ((sline = reader.ReadLine()) != null)
                {
                    line++;
                    string[] parts = sline.Split(new string[] { " " }, StringSplitOptions.None);
                    foreach (string part in parts)
                    {
                        TokenType type = checkToken(part.Trim());
                        Token token = new Token();
                        if (type == TokenType.BracketsClose || type == TokenType.EndCode)
                        {
                            level--;
                            Token partner = partnerStack.Pop();
                            partner.Partner = token;
                            token.Partner = partner;
                        }

                        token.TokenType = type;
                        token.Value = part.Trim();
                        token.Level = level;
                        token.LineNumber = line;
                        token.Position = sline.IndexOf(part);
                        tokens.InsertLast(token);

                        if (type == TokenType.BracketsOpen || type == TokenType.StartCode)
                        {
                            level++;
                            partnerStack.Push(token);
                        }

                    }
                }
            }

            return tokens;
        }

        public TokenType checkToken(String token)
        {
            switch (token)
            {
                case "begincode":
                    return TokenType.StartCode;
                case "eindcode":
                    return TokenType.EndCode;
                case "als":
                    return TokenType.IfToken;
                case "andersals":
                    return TokenType.IfelseToken;
                case "anders":
                    return TokenType.ElseToken;
                case "woord":
                    return TokenType.TypeString;
                case "getal":
                    return TokenType.TypeNumber;
                case "letter":
                    return TokenType.TypeChar;
                case "wordt":
                    return TokenType.Equals;
                case "is":
                    return TokenType.EqualsEquals;
                case "verhogen":
                    return TokenType.Increment;
                case "verlagen":
                    return TokenType.Decrement;
                case "einde":
                    return TokenType.EndStatement;
                case "haakjeopen":
                    return TokenType.BracketsOpen;
                case "haakjesluiten":
                    return TokenType.BracketsClose;
                default:
                    return CheckType(token);
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
                if (Char.IsDigit(input,0))
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
