# Setup a simple command line program with parameters

1. Create a Console application
2. Import the nuget packages:- System.CommandLine and System.CommandLine.DragonFruit.
   These nuget packages are in Prerelease.
3. Change the main program to the following:-
    ```c#
       static void Main(string input, string output)
       {
           Console.WriteLine("Input:- " + input);
           Console.WriteLine("Output:- " + output);

       }
    ```
4. You can now call the program using the following command and the parameters will be populated
    ```text
       SimpleCmdLineSample.exe --input "Sample Input" --output "Sample Output"
    ```
5. Output will be:-
    ```text
       Input:- Sample Input
       Output:- Sample Output
    ```