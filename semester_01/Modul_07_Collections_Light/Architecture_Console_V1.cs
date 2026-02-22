using System;

class Programm
{
    static void Main()
    {
        Console.WriteLine("Willkommen in der Command Console v1\nUm dir die Commands anzuschauen, nutze: help!\nViel Spaß!");
        bool isRunning = true;
        while(isRunning)
        {
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Keine Eingabe");
                continue;
            }

                string [] parts = ParseInput(input, 2);
                string cmd = parts[0].ToLower();
        
            switch(cmd)
            {
                case "help":
                Help();
                break;

                case "exit":
                Console.WriteLine("Console schließen");
                isRunning = false;
                break;

                case "echo":
                string repeat = parts.Length > 1 && string.IsNullOrWhiteSpace(parts[1]) ? parts[1] : "Fehler: echo braucht Text.";
                Console.WriteLine(repeat);
                break;

                case "upper":
                string up = parts.Length > 1 && string.IsNullOrWhiteSpace(parts[1]) ? parts[1].ToUpper() : "Fehler: Kein Text";
                Console.WriteLine(up);
                break;

                case "len":
                int length = parts.Length > 1 && string.IsNullOrWhiteSpace(parts[1]) ? parts[1].Length : 0;
                Console.WriteLine($"Dein Text hat {length} Zeichen");
                break;

                case "repeat":
                string [] rParts = ParseInput(input, 3);
                int rNum = 
                break;

                default:
                Console.WriteLine("Unbekannter Befehl, nutze help");
                break;

            }


        }    
        
    }

    private static string[] ParseInput(string rawInput, int count)
    {
        return rawInput.Trim().Split(' ', count);
    }

    private static void Help()
    {
        string tb = @"
Menü:
help - zeigt Hilfe
echo <Text> - Text wiedergeben
upper <Text> - Großbuchstaben
len <Text> - Zeichenanzahl
exit - beendet";
        Console.WriteLine(tb);
    }
}