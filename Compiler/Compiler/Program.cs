﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    class Program
    {
        static void Main(string[] args)
        {

            string fileName = Console.ReadLine();
            if (fileName.Equals(""))
                fileName = "C:\\CompilerText.txt";

            try
            {
                string textFromFile = System.IO.File.ReadAllText(@fileName);
                Tokenizer tokenizer = new Tokenizer();
                tokenizer.Tokenize(textFromFile);
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Kan bestand niet openen:");
                Console.WriteLine(e.Message);
            }

            

            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();


            
        }
    }
}
