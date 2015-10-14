using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Tokenizer;

namespace Compiler
{
    class Program
    {
        static void Main(string[] args)
        {

            string fileName = Console.ReadLine();
            string textFromFile = "getal x wordt 3 einde";
            if (fileName.Equals(""))
                fileName = "C:\\CompilerText.txt";

            try
            {
                textFromFile = System.IO.File.ReadAllText(@fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Kan bestand niet openen:");
                Console.WriteLine(e.Message);
            }
            Tokenize tokenizer = new Tokenize();
            tokenizer.Tokenizer(textFromFile);   

            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();


            
        }
    }
}
