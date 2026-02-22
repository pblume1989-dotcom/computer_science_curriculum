namespace Semester2.Fundamentals;
public class Item
{
    public string Name {get; private set;}
    public int Value {get; private set;}
    public string Description {get; private set;}

    public Item(string name, string description, int value)
    {
        if (string.IsNullOrWhiteSpace(name))
        throw new ArgumentException("Name darf nicht leer sein.", nameof(name));

        if (value < 0)
        throw new ArgumentOutOfRangeException(nameof(value), "Value muss >= 0 sein.");

        if (string.IsNullOrWhiteSpace(description))
        throw new ArgumentException("Description darf nicht leer oder null sein.", nameof(description));

        Name = name;
        Value = value;
        Description = description;
    }

    public string Inspect()
    {
        return
$@"----------
Name: {Name}
Wert: {Value}
Info: {Description}
----------";
    }
}