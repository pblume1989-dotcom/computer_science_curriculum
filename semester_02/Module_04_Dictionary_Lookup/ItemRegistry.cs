namespace Semester2.LookupSystem;
public class ItemRegistry
{
     private Dictionary<string, ItemDefinition> _defs = new Dictionary<string, ItemDefinition>();

    public bool TryAdd(ItemDefinition def)
    {
        if (def == null || string.IsNullOrWhiteSpace(def.Id)) return false;
        return _defs.TryAdd(def.Id, def);
    }

    public bool TryGet(string id, out ItemDefinition? def)
    {
        def = null;

        if (string.IsNullOrWhiteSpace(id)) return false;

        return _defs.TryGetValue(id, out def);
    }

    public IEnumerable<ItemDefinition> All => _defs.Values;
}