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

                var tokens = Tokenize(input);
                if (tokens.Count == 0) continue;

                string cmd = tokens[0].ToLower();
        
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
                string repeat = tokens.Count > 1 && !string.IsNullOrWhiteSpace(tokens[1]) ? tokens[1] : "Fehler: echo braucht Text.";
                Console.WriteLine(repeat);
                break;

                case "upper":
                string up = tokens.Count > 1 && !string.IsNullOrWhiteSpace(tokens[1]) ? tokens[1].ToUpper() : "Fehler: Kein Text";
                Console.WriteLine(up);
                break;

                case "len":
                int length = tokens.Count > 1 && !string.IsNullOrWhiteSpace(tokens[1]) ? tokens[1].Length : 0;
                Console.WriteLine($"Dein Text hat {length} Zeichen");
                break;

                case "repeat":
                if (tokens.Count < 3)
                    {
                        Console.WriteLine("Fehler: Nutze [command] [Zahl] [Text]");
                        break;
                    }
                if (!int.TryParse(tokens[1], out int num))
                    {
                        Console.WriteLine("Keine Zahl - Nutze [Command] [Zahl] [Text] ");
                        break;
                    }
                if (num < 1)
                    {
                        Console.WriteLine("Bitte Zahl > 0");
                        break;
                    }
                
                    for (int i = 0; i < num; i++)
                    {
                        Console.Write($"{tokens[2]} ");
                    }
                    Console.WriteLine();
                break;

                default:
                Console.WriteLine("Unbekannter Befehl, nutze help");
                break;

            }


        }    
        
    }

private static List<string> Tokenize(string input)
    {
        List<string> tokens = new List<string>();
        StringBuilder currentToken = new StringBuilder();
        bool inQuotes = false;
        input= input.Trim();

        foreach (char c in input)
        {
            if(c == '"')
            {
                inQuotes = !inQuotes;
            }
            else if (c == ' ' && inQuotes == false)
            {
                if (currentToken.Length > 0)
                {
                tokens.Add(currentToken.ToString());
                currentToken.Clear();
                }
            }
            else
                currentToken.Append(c);
        }
        if (currentToken.Length > 0)
            tokens.Add(currentToken.ToString());

        if (inQuotes == true)
        {
            Console.WriteLine("Du hast Quotes am Ende vergessen.");
            tokens.Clear();
        }
            return tokens;
    }

    private static void Help()
    {
        string tb = @"
Menü:
help - zeigt Hilfe
echo ""Text"" - Text wiedergeben
upper ""Text"" - Großbuchstaben
len ""Text"" - Zeichenanzahl
repeat <Zahl> ""Text"" - Wiederholung x mal
exit - beendet";
        Console.WriteLine(tb);
    }