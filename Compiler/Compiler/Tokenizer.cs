using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    class Tokenizer
    {
        public void Tokenize(String input)
        {
            input = input.Replace(System.Environment.NewLine, "");
            Console.WriteLine("TOKENIZE");
            Console.WriteLine();
            string[] words = input.Split(new string[] { "einde" }, StringSplitOptions.None);
            foreach (string word in words)
            {

                Console.WriteLine("-- "+word.Trim());
                string[] parts = word.Split(new string[] { " " }, StringSplitOptions.None);
                foreach (string part in parts)
                {
                    checkToken(part.Trim());
                }
            }
            Console.WriteLine();
            Console.WriteLine("END TOKENIZE");
            Console.WriteLine();
        }

        public void checkToken(String token)
        {
            switch (token)
            {
                case "begincode":
                    Console.WriteLine("{");
                    break;
                case "eindcode":
                    Console.WriteLine("}");
                    break;
                case "als":
                    Console.WriteLine("if");
                    break;
                case "andersals":
                    Console.WriteLine("else if");
                    break;
                case "anders":
                    Console.WriteLine("else");
                    break;
                case "woord":
                    Console.WriteLine("string");
                    break;
                case "getal":
                    Console.WriteLine("int");
                    break;
                case "letter":
                    Console.WriteLine("string");
                    break;
                case "wordt":
                    Console.WriteLine("=");
                    break;
                case "is":
                    Console.WriteLine("==");
                    break;
                case "verhogen":
                    Console.WriteLine("++");
                    break;
                case "verlagen":
                    Console.WriteLine("--");
                    break;
                default:
                    Console.WriteLine(token);
                    break;
            }
        }
    }
}
