
using System.ComponentModel.Design;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.XPath;
using Semester2.Parsing;
class Program
{
   static void Main()
    {
            string[] testCase = {"go","go up", "take \"iron sword\" 2","take sword -1", "say \"hello world\"", "say", " take sword "};

            foreach (string test in testCase)
        {
            var result = CommandParser.TryBuildAction(test, out string action);

            if (!result.Ok)
            {
                Console.WriteLine($"Fehler: [{result.ErrorCode}]: {result.Message}");
                continue;
            }

                Console.WriteLine($"Aktion ausgeführt: {action}");
        }
    }
}