using System.Text;

namespace Semester2.Parsing;

public static class CommandParser
{
    public static readonly string[] ValidDirections = { "north","south","east","west" };

    public static bool TryTokenize(string input, out List<string> tokens, out string error)
    {
        tokens = new List<string>();
        error = "";
        
        if (string.IsNullOrWhiteSpace(input))
            return false;

        input = input.Trim();

        var current = new StringBuilder();
        bool inQuotes = false;

        foreach (char c in input)
        {
            if (c == '"')
            {
                inQuotes = !inQuotes;
                continue;
            }

            if (c == ' ' && !inQuotes)
            {
                if (current.Length > 0)
                {
                    tokens.Add(current.ToString());
                    current.Clear();
                }
                continue;
            }

            current.Append(c);
        }

        if (current.Length > 0)
        {
            tokens.Add(current.ToString());
        }

        if (inQuotes)
        {
            error = "Unclosed Quotes: \" nicht geschlossen.";
            tokens.Clear();
            return false;
        }

        return tokens.Count > 0;
    }

    public static bool TryParseCommand(string input, out string verb, out string[] args, out string error)
    {
        verb = "";
        args = [];
        error = "";

        string clean = input?.Trim().ToLowerInvariant() ?? "";

        if (!TryTokenize(clean, out var tokens, out error))
            return false;
        
        verb = tokens[0];
        args = tokens.Count > 1 ? tokens.Skip(1).ToArray() : Array.Empty<string>();
        return true;
    }

    public static bool TryBuildAction(string input, out string action, out string error)
    {
        action = "";
        error = "";

        if (!TryParseCommand(input, out string verb, out string[] args, out error))
        {
            return false;
        }

        switch(verb)
        {
            case "go":
            if (args.Length < 1)
                {
                    error = "keine Richtung angegeben.";
                    return false;
                }
            if (!ValidDirections.Contains(args[0]))
                {
                    error = $"'{args[0]}' ist keine gültige Richtung.";
                    return false;
                }

                action = $"GO:{args[0].ToUpperInvariant()}";
                return true;

            case "take":
            if (args.Length < 1)
                {
                    error = "Kein Item vorhanden";
                    return false;
                }
            
            int amount = 1;

            if (args.Length >= 2)
            {
                if(!int.TryParse(args[1], out amount) || amount <= 0)
                {
                    error = $"'{args[1]}'ist keine Zahl.";
                    return false;
                }
            }

            action = $"TAKE:{args[0]}:{amount}";
            return true;

            case "say":
            if (args.Length < 1)
                {
                    error = "Nichts zu sagen";
                    return false;
                }

            action = $"SAY:{string.Join(" ", args)}";
            return true;

            default:
            error = $"Befehl '{verb}' unbekannt.";
            return false;
        }
    }
}