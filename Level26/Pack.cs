public class Pack
{
    private int _maxItems;
    private double _maxWeight;
    private double _maxVolume;
    private InventoryItem[] _currentItems;

    private int _currentItemCount = 0;
    private double _currentWeight = 0;
    private double _currentVolume = 0;

    public Pack(int maxItems, double maxWeight, double maxVolume)
    {
        _maxItems = maxItems;
        _maxWeight = maxWeight;
        _maxVolume = maxVolume;
        _currentItems = new InventoryItem[maxItems];
    }

    public int MaxItems => _maxItems;
    public double MaxWeight => _maxWeight;
    public double MaxVolume => _maxVolume;
    public int CurrentItemCount => _currentItemCount;
    public double CurrentWeight => _currentWeight;
    public double CurrentVolume => _currentVolume;
    public int RemainingItems => _maxItems - _currentItemCount;
    public double RemainingWeight => _maxWeight - _currentWeight;
    public double RemainingVolume => _maxVolume - _currentVolume;

    public bool Add(InventoryItem item)
    {
        if (_currentItemCount >= _maxItems)
        {
            return false;
        }

        if (_currentWeight + item.Weight > _maxWeight || _currentVolume + item.Volume > _maxVolume)
        {
            return false;
        }

        for (int i = 0; i < _currentItems.Length; i++)
        {
            if (_currentItems[i] == null)
            {
                _currentItems[i] = item;
                _currentWeight += item.Weight;
                _currentVolume += item.Volume;
                _currentItemCount++;
                break;
            }
        }
        return true;
    }

    public void GetPackStatus()
    {
        Console.WriteLine("Your pack contains:");
        foreach (InventoryItem item in _currentItems)
        {
            if (item != null)
            {
                Console.WriteLine($"{item.GetType()} (Weight: {item.Weight} Volume: {item.Volume})");
            }
        }
        Console.WriteLine("\nCategory\tCurrent / Max");
        Console.WriteLine($"Items:\t\t{_currentItemCount} / {_maxItems}");
        Console.WriteLine($"Weight:\t\t{_currentWeight:0.00} / {MaxWeight}");
        Console.WriteLine($"Volume:\t\t{_currentVolume:0.00} / {MaxVolume}");
        Console.WriteLine();
    }

    public string PackContents()
    {
        string itemList = "";
        foreach (InventoryItem item in _currentItems)
        {
            if (item != null)
            {
                itemList += item + " ";
            }
        }
        return itemList;
    }

    public override string ToString()
    {
        return $"Your pack contains: {PackContents()}\n";
    }
}