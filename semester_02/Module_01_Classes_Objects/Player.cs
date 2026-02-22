namespace Semester2.Fundamentals;
public class Player
{
    public string Name {get; private set;}
    public int Gold {get; private set;}

    public Player(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        throw new ArgumentException("Name darf nicht leer sein.", nameof(name));

        Name = name;
        Gold = 0;
    }

    public bool TryAddGold(int amount)
    {
        if (amount <= 0) return false;

        Gold += amount;
        return true;
    }

    public void AddGold(int amount)
    {
        if (!TryAddGold(amount))
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount muss > 0 sein.");
    }

    public bool TrySpendGold(int amount)
    {
        if (amount <= 0) return false;
        if (amount > Gold) return false;

        Gold -= amount;
        return true;
    }

    public void SpendGold(int amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount muss > 0 sein.");

        if (!TrySpendGold(amount))
            throw new InvalidOperationException("Nicht genug Gold.");
    }
}