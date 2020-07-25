using System;
using ScriptBuilder;

namespace Startup
{
    class Program
    {
        static void Main(string[] args)
        {
            IScriptBuilder scriptBuilder = new EfCoreScriptBuilder(@"C:\Users\kotoh\Desktop\Names.txt", @"C:\Users\kotoh\Desktop\Surnames.txt");
            Console.WriteLine(scriptBuilder.BuildScript(5));
        }
    }
}
