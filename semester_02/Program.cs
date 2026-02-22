
using System.ComponentModel.Design;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Semester2.Parsing;
class Program
{
   static void Main()
    {
            string[] testCase = {"go","go up", "take \"iron sword\" 2","take sword -1", "say \"hello world\"", "say", " take sword "};

            foreach (string test in testCase)
        {
            if (CommandParser.TryBuildAction(test, out string action, out string error))
            {
                Console.WriteLine($"Input: '{test}' -> Action-String: {action}");
            }
            else
            {
                Console.WriteLine($"Input: '{test}' -> Fehler: {error}");
            }
        }
    }
}