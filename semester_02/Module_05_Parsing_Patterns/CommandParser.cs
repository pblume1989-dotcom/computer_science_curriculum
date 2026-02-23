using System.Text;
using Semester2.Core;
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

    public static ValidationResult TryBuildAction(string input, out string action)
    {
        action = "";

        if (!TryParseCommand(input, out string verb, out string[] args, out string tokenizeError))
        {
            return ValidationResult.Failure("PARSING_ERROR", tokenizeError);
        }

        switch(verb)
        {
            case "go":
            if (args.Length < 1)
                {
                    return ValidationResult.Failure("MISSING_ARG", "Wohin willst du gehen?");
                }
            if (!ValidDirections.Contains(args[0]))
                {
                    return ValidationResult.Failure("INVALID_DIRECTION", $"{args[0]} ist keine gültige Richtung.");
                }

                action = $"GO:{args[0].ToUpperInvariant()}";
                return ValidationResult.Success();

            case "take":
            if (args.Length < 1)
                {
                    return ValidationResult.Failure("MISSING_ARG", "Was willst du aufnehmen?");
                }
            
            int amount = 1;

            if (args.Length >= 2)
            {
                if(!int.TryParse(args[1], out amount) || amount <= 0)
                {
                    return ValidationResult.Failure("INVALID_AMOUNT", $"'{args[1]}'ist keine gültige ganze Zahl. amount > 0");
                }
            }

            action = $"TAKE:{args[0]}:{amount}";
            return ValidationResult.Success();

            case "say":
            if (args.Length < 1)
                {
                    return ValidationResult.Failure("MISSING_ARG", "Was möchtest du sagen");
                }

            action = $"SAY:{string.Join(" ", args)}";
            return ValidationResult.Success();

            default:
            return ValidationResult.Failure("UNKNOWN_COMMAND", $"Befehl '{verb}' unbekannt.");
        }
    }

    public static bool TryParseDirection(string raw, out Direction dir)
    {
        dir = default;

        if (string.IsNullOrWhiteSpace(raw)) return false;

        return Enum.TryParse<Direction>(raw, ignoreCase: true, out dir);
    }
}