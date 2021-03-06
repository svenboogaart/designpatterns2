﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Tokenizer;
using Compiler.Compiler;
using Compiler.VirtualMachine;

namespace Compiler
{
    class Program
    {
        static void Main(string[] args)
        {

            string fileName = Console.ReadLine();
            string textFromFile = "getal x wordt 3 einde als haakjeopen x isgelijkaan 3 haakjesluiten begincode x wordt 2 einde eindcode";
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
            LinkedList<Token> tokens = tokenizer.Tokenizer(textFromFile);

            Compile.compile(tokens);

            VM vm = new VM();
            vm.Run(Compile.CompiledNodes);

            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();


            
        }
    }
}
