# Setup a simple command line program with parameters and help

1. Create a Console application
2. Import the nuget packages:- System.CommandLine and System.CommandLine.DragonFruit.
   These nuget packages are in Prerelease.
3. Change the main program to the following:-
    ```c#
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
    ```
 4. The xml comments above the Main function are the documented help section
 5. Execute the following command:-
    ```text
        SimpleCmdLineWithHelpText.exe --help
    ```
 6. It will give the following output:-
    ```text
        SimpleCmdLineWithHelpText:
          Takes an input string, an output string and a bool value
        
        Usage:
          SimpleCmdLineWithHelpText [options]
        
        Options:
          --input <input>      A sample input. Default is String.Empty [default: ]
          --output <output>    A sample output. default is String.Empty [default: ]
          --is-test            isTest [default: False]
          --version            Show version information
          -?, -h, --help       Show help and usage information
    ```