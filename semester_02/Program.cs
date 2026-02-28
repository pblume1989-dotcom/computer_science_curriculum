using Semester2.Fundamentals;
using Semester2.Parsing;
using Semester2.Debug;

class Program
{
    static void Main()
    {
        // 1. System-Setup
        Player hero = new Player("Patrick");
        Monster orc = new Monster("Ugluk", 20);
        
        string[] testCommands = { 
            "go north", 
            "take sword 2", 
            "say \"Hello World\"", 
            "fly away", // Fehler: Unbekanntes Verb
            "go nowhere" // Fehler: Ungültige Richtung
        };

        Console.WriteLine("--- STARTE SYSTEM-TEST MODUL 08 ---");

        foreach (string cmd in testCommands)
        {
            
            var result = CommandParser.TryBuildAction(cmd, out string action);

            GameDebugger.DisplaySystemSnapshot(hero, result);

            if (result.Ok)
            {
                action = result.Message;
                Console.WriteLine($"[LOGIK] Führe aus: {action}");
            }
        }

        Console.WriteLine("\n--- MONSTER KAMPF TEST ---");
        orc.TakeDamage(20);

        GameDebugger.DisplaySystemSnapshot(orc, ValidationResult.Success("Monster besiegt!"));
    }
}