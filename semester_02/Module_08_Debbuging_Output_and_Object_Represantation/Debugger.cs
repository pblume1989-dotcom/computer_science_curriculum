using Semester2.Fundamentals;
using Semester2.Parsing;

namespace Semester2.Debug;

public static class GameDebugger
{
    public static bool isEnabled {get; set;} = true;

    public static void DisplaySystemSnapshot(object? info, ValidationResult result)
    {
        if (!isEnabled) return;

        string typeName = info?.GetType().Name.ToUpper() ?? "ENTITY";
        string player = info?.ToString() ?? "NONE";

        string displayAction = string.IsNullOrWhiteSpace(result.Message)
            ? "NONE"
            : result.Message;

        string errorCode = string.IsNullOrWhiteSpace(result.ErrorCode)
            ? "NONE"
            : result.ErrorCode;
        
        if (displayAction.Length > 35)
        {
        displayAction = displayAction.Substring(0, 32) + "...";
        }

        Console.WriteLine("\n" + new string('=', 40));
        Console.WriteLine("       [ GAME DEBUG SNAPSHOT ]");
        Console.WriteLine(new string('-', 40));

        Console.WriteLine($" {typeName}: {player}");
        Console.WriteLine($" ACTION: {displayAction}");

        if (!result.Ok)
        {
        Console.WriteLine($" ERROR : [{errorCode}]");
        }

        Console.WriteLine(new string('=', 40) + "\n");
    }
}