namespace Semester2.LookupSystem;

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

    public bool TryRemove(string itemId, int amount = 1)
    {
        if (string.IsNullOrWhiteSpace(itemId)) return false;
        if (amount <= 0) return false;
        if (!_counts.TryGetValue(itemId, out int current) || current < amount) return false;
        
        _counts[itemId] -= amount;

        if (_counts[itemId] == 0)
        _counts.Remove(itemId);
        
        return true;
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