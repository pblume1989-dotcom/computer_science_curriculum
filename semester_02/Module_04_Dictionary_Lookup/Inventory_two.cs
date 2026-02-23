namespace Semester2.LookupSystem;
using Semester2.Parsing;
public class Inventory
{
    private Dictionary<string, int> _counts;

    public Inventory()
    {
        _counts = new Dictionary<string, int>();
    }

    public void Add(string itemId, int amount = 1)
    {
        if (itemId == null || string.IsNullOrWhiteSpace(itemId))
        throw new ArgumentException("Item Id darf nicht leer/null sein.", nameof(itemId));
        if (amount <= 0)
        throw new ArgumentOutOfRangeException(nameof(amount), "amount > 0");

        if (_counts.TryGetValue(itemId, out int current))
        {
            _counts[itemId] = current + amount;
        }
        else
            _counts.Add(itemId, amount);
    }

    public ValidationResult TryRemove(string itemId, int amount = 1)
    {
        if (string.IsNullOrWhiteSpace(itemId))
        {
            return ValidationResult.Failure("INVALID_ID", "Item-ID darf nicht leer sein.");
        }

        if (amount <= 0)
        {
            return ValidationResult.Failure("INVALID_AMOUNT", "Amount > 0.");
        }
        if (!_counts.TryGetValue(itemId, out int current))
        {
            return ValidationResult.Failure("ITEM_NOT_FOUND", $"Du besitzt kein '{itemId}'");
        }
        if (current < amount)
        {
            return ValidationResult.Failure("INSUFFICIENT_STOCK", $"Nicht genug {itemId} vorhande. Besitz: {current}");
        }
        
        _counts[itemId] -= amount;

        if (_counts[itemId] == 0)
        _counts.Remove(itemId);
        
        return ValidationResult.Success();
    }

    public int CountOf(string itemId)
    {
        if (string.IsNullOrWhiteSpace(itemId)) return 0;
        if(_counts.TryGetValue(itemId, out int amount)) return amount;

        return 0;
    }

    public int TotalItems
    {
        get
        {
            int sum = 0;
            foreach (int amount in _counts.Values)
            {
                sum += amount;
            }

            return sum;
        }
    }

    public int TotalValue(ItemRegistry reg)
    {
        int sumValue = 0;
        foreach (var entry in _counts)
        {
            if (reg.TryGet(entry.Key, out var def))
            {
                sumValue += entry.Value * def!.Value;
            }
        }

        return sumValue;
    }
}