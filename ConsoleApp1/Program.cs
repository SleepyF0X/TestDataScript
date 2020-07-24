using System;
using ScriptBuilder;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IScriptBuilder scriptBuilder = new EFCoreScriptBuilder(@"C:\Users\kotoh\Desktop\Names.txt", @"C:\Users\kotoh\Desktop\Surnames.txt");
            Console.WriteLine(scriptBuilder.BuildScript(5));
        }
    }
}
