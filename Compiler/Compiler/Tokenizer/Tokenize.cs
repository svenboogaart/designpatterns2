using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Compiler.Tokenizer
{
    public class Tokenize
    {
        public static int level = 1;

        LinkedList<Token> tokens;
        TokenFactory tokenFactory;

        public LinkedList<Token> Tokenizer(String input)
        {
            tokenFactory = new TokenFactory();
            Console.WriteLine(input);
            int line = 1;
            tokens = new LinkedList<Token>();
            using (StringReader reader = new StringReader(input))
            {
                string sline;
                while ((sline = reader.ReadLine()) != null)
                {
                    line++;
                    string[] parts = sline.Split(new string[] { " " }, StringSplitOptions.None);
                    foreach (string part in parts)
                    {
                        Token token;
                        if (tokens.Last != null)
                        {
                            token = tokenFactory.Create(part, tokens.Last.Value);
                        }
                        else
                        {
                            token = tokenFactory.Create(part, null);
                        }
                            
                            
                            
                        /*new Token(part,level,line,sline.IndexOf(part));
                        if (tokens.Last == null || tokens.Last.Value.TokenType == TokenType.EndStatement)
                        {
                            token = NewLoneToken(token);
                        }
                        else if (tokens.Last.Value.TokenType == TokenType.TypeNumber || tokens.Last.Value.TokenType == TokenType.TypeChar || tokens.Last.Value.TokenType == TokenType.TypeString)
                        {
                            token.TokenType = TokenType.Identifier;
                        }
                        else
                        {
                            token = NewLoneToken(token);
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
                        tokens.AddLast(token);
                    }
                }
            }

            return tokens;
        }

        /*public Token NewLoneToken(Token token)
        {
            TokenType type = checkToken(token.Value);
            /*if (type == TokenType.BracketsClose || type == TokenType.EndCode)
            {
                //level--;
                Token partner = partnerStack.Pop();
                partner.Partner = token;
                token.Partner = partner;
            }
            token.TokenType = type;
            /*if (type == TokenType.BracketsOpen || type == TokenType.StartCode)
            {
                level++;
                partnerStack.Push(token);
            }
            return token;
        }

        /*public TokenType CheckType(string input)
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
        }*/
    }
}
