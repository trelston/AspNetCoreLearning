using System;

namespace SimpleCmdLineWithHelpText
{
    class Program
    {
        /// <summary>
        /// Takes an input string, an output string and a bool value
        /// </summary>
        
        /// <param name="input">A sample input. Default is String.Empty</param>
        /// <param name="output">A sample output. default is String.Empty</param>
        /// <param name="--is-Test">Default is false</param>
        static void Main(string input = "", string output = "", bool isTest = false)
        {
            Console.WriteLine("Console input:- " + input);
            Console.WriteLine("Console output:- " + output);
            Console.WriteLine("Console isTest:- " + isTest);
        }
    }
}