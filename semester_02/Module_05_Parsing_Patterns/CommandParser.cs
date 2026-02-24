using System.Data;
using System.Text;
using Semester2.Core;
namespace Semester2.Parsing;

public static class CommandParser
{
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

            if (char.IsWhiteSpace(c) && !inQuotes)
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

        string clean = input?.Trim() ?? "";

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

        if (!TryParseEnum<ActionVerb>(verb, out ActionVerb actionVerb) || actionVerb == ActionVerb.None)
        {
            return ValidationResult.Failure("NONE", $"'{verb} ist kein bekannter Befehl");
        }

        switch(actionVerb)
        {
            case ActionVerb.Go:

            if (args.Length < 1)
                {
                    return ValidationResult.Failure("MISSING_ARG", "Wohin willst du gehen?");
                }
            if (!TryParseEnum<Direction>(args[0], out Direction dir) || dir == Direction.None)
                {
                    return ValidationResult.Failure("INVALID_DIRECTION", $"{args[0]} ist keine gültige Richtung.");
                }

                action = $"GO:{dir}";
                return ValidationResult.Success();

            case ActionVerb.Take:
            if (args.Length < 1)
                {
                    return ValidationResult.Failure("MISSING_ARG", "Was willst du aufnehmen?");
                }
            
            int amount = 1;

            if (args.Length >= 2)
            {
                if(!int.TryParse(args[1], out amount) || amount <= 0)
                {
                    return ValidationResult.Failure("INVALID_AMOUNT", $"'{args[1]}' ist keine gültige ganze Zahl. amount > 0");
                }
            }

            action = $"TAKE:{args[0].ToLowerInvariant()}:{amount}";
            return ValidationResult.Success();

            case ActionVerb.Say:
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

    public static bool TryParseEnum<T>(string raw, out T result) where T : struct, Enum
    {
        result = default;

        if (string.IsNullOrWhiteSpace(raw)) return false;

        return Enum.TryParse<T>(raw, ignoreCase: true, out result);
    }
}