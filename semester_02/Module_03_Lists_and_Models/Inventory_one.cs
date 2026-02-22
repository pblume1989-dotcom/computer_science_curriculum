namespace Semester2.Fundamentals;
public class Inventory1
{
    private List<Item> _items = new List<Item>();

    public bool RemoveByName(string name)
    {
        Item? found = FindByName(name);
        if(found == null) return false;

        _items.Remove(found);
        return true;
    }

    public Item? FindByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return null;
        

        for(int i = 0; i < _items.Count; i++)
        {
            if(string.Equals(_items[i].Name, name, StringComparison.OrdinalIgnoreCase)) return _items[i];
        }

        return null;
    }
    public int RemoveAllByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return 0;

        int removed = 0;

        for (int i = _items.Count - 1; i >= 0; i--)
        {
            if (string.Equals(_items[i].Name, name, StringComparison.OrdinalIgnoreCase))
            {
                _items.RemoveAt(i);
                removed++;
            }
        }
        return removed;
    }

    public int TotalValue
    {
        get
        {
            int sum = 0;

            foreach(Item item in _items)
            {
                sum += item.Value;
            }
            return sum;
        }
    }

    public Item? MostValuable()
    {
            Item? mostValue = null;
            int rankedHighest = 0;

            foreach (Item item in _items)
            {
                if (item.Value >= rankedHighest)
                {
                rankedHighest = item.Value;
                mostValue = item;
                }
            }
            return mostValue;
    }

    public int Count
    {
        get
        {
            return _items.Count;
        }
    }

    public void Add(Item item)
    {
        if (item == null) return;

        _items.Add(item);
    }

}