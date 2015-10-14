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
        Dictionary<string, TokenType> tokenDictionairy;
        Stack<Token> partnerStack;

        public CustomLinkedList<Token> Tokenizer(String input)
        {
            fillDictionairy();
            Console.WriteLine(input);
            int level = 1;
            int line = 1;
            tokens = new CustomLinkedList<Token>();
            partnerStack = new Stack<Token>();
            using (StringReader reader = new StringReader(input))
            {
                string sline;
                while ((sline = reader.ReadLine()) != null)
                {
                    line++;
                    string[] parts = sline.Split(new string[] { " " }, StringSplitOptions.None);
                    foreach (string part in parts)
                    {
                        Token token = new Token(part,level,line,sline.IndexOf(part));
                        if (tokens.Last == null || tokens.Last.Value.TokenType == TokenType.EndStatement)
                        {
                            token = NewLoneToken(token);
                        }
                        else if (tokens.Last.Value.TokenType == TokenType.TypeNumber || tokens.Last.Value.TokenType == TokenType.TypeChar || tokens.Last.Value.TokenType == TokenType.TypeString)
                        {
                            token.TokenType = TokenType.Identifier;
                        }

                        /*TokenType type = checkToken(part.Trim());
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
                        }*/
                        tokens.InsertLast(token);
                    }
                }
            }

            return tokens;
        }

        public Token NewLoneToken(Token token)
        {
            TokenType type = checkToken(token.Value);
            /*if (type == TokenType.BracketsClose || type == TokenType.EndCode)
            {
                //level--;
                Token partner = partnerStack.Pop();
                partner.Partner = token;
                token.Partner = partner;
            }*/
            token.TokenType = type;
            /*if (type == TokenType.BracketsOpen || type == TokenType.StartCode)
            {
                level++;
                partnerStack.Push(token);
            }*/
            return token;
        }

        public void fillDictionairy()
        {
            tokenDictionairy = new Dictionary<string, TokenType>();
            tokenDictionairy.Add("begincode", TokenType.StartCode);
            tokenDictionairy.Add("eindcode", TokenType.EndCode);
            tokenDictionairy.Add("als", TokenType.IfToken);
            tokenDictionairy.Add("andersals", TokenType.IfelseToken);
            tokenDictionairy.Add("anders", TokenType.ElseToken);
            tokenDictionairy.Add("woord", TokenType.TypeString);
            tokenDictionairy.Add("getal", TokenType.TypeNumber);
            tokenDictionairy.Add("letter", TokenType.TypeChar);
            tokenDictionairy.Add("wordt", TokenType.Equals);
            tokenDictionairy.Add("is", TokenType.EqualsEquals);
            tokenDictionairy.Add("verhogen", TokenType.Increment);
            tokenDictionairy.Add("verlagen", TokenType.Decrement);
            tokenDictionairy.Add("einde", TokenType.EndStatement);
            tokenDictionairy.Add("haakjeopen", TokenType.BracketsOpen);
            tokenDictionairy.Add("haakjesluiten", TokenType.BracketsClose);
        }

        public TokenType checkToken(string token)
        {
            if (tokenDictionairy.ContainsKey(token))
            {
                return tokenDictionairy[token];
            }
            else
            {
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
