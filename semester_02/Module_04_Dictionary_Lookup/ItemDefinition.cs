namespace Semester2.LookupSystem;
public class ItemDefinition
{
    public string Id{get;}
    public string Name{get;}
    public string Description{get;}
    public int Value{get;}

    public ItemDefinition(string id, string name, string description, int value)
    {
        if (string.IsNullOrWhiteSpace(id))
        throw new ArgumentException("Id darf nicht leer sein.", nameof(id));

        if (string.IsNullOrWhiteSpace(name))
        throw new ArgumentException("Name darf nicht leer sein.", nameof(name));

        if (value < 0)
        throw new ArgumentOutOfRangeException(nameof(value), "Value muss >= 0 sein.");

        if (string.IsNullOrWhiteSpace(description))
        throw new ArgumentException("Description darf nicht leer oder null sein.", nameof(description));

        Id = id;
        Name = name;
        Description = description;
        Value = value;
    }
}