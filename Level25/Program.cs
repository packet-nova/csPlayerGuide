Pack pack = new(10, 20, 30);
pack.StartItemSelection();

public class Pack
{
    private int _maxItems;
    private double _maxWeight;
    private double _maxVolume;
    private InventoryItem[] carriedItems;

    private int _currentItemCount = 0;
    private double _currentWeight = 0;
    private double _currentVolume = 0;

    public Pack(int maxItems, double maxWeight, double maxVolume)
    {
        _maxItems = maxItems;
        _maxWeight = maxWeight;
        _maxVolume = maxVolume;
        carriedItems = new InventoryItem[maxItems];
    }

    public int MaxItems => _maxItems;
    public double MaxWeight => _maxWeight;
    public double MaxVolume => _maxVolume;
    public int CurrentItemCount => _currentItemCount;
    public double CurrentWeight => _currentWeight;
    public double CurrentVolume => _currentVolume;

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

        for (int i = 0; i < carriedItems.Length; i++)
        {
            if (carriedItems[i] == null)
            {
                carriedItems[i] = item;
                _currentWeight += item.Weight;
                _currentVolume += item.Volume;
                _currentItemCount++;
                break;
            }
        }
        return true;
    }

    public InventoryItem PickItem()
    {
        int remainingItems = _maxItems - _currentItemCount;
        double remainingWeight = _maxWeight - _currentWeight;
        double remainingVolume = _maxVolume - _currentVolume;

        Console.WriteLine("Which item would you like to add to your pack? ");
        Console.WriteLine($"1. Arrow");
        Console.WriteLine($"2. Bow");
        Console.WriteLine($"3. Rope");
        Console.WriteLine($"4. Water");
        Console.WriteLine($"5. Food Rations");
        Console.WriteLine($"6. Sword");
        Console.Write("Select an option: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        InventoryItem response = choice switch
        {
            1 => new Arrow(),
            2 => new Bow(),
            3 => new Rope(),
            4 => new Water(),
            5 => new FoodRations(),
            6 => new Sword(),
            _ => new Arrow()
        };
        return response;
    }

    public void StartItemSelection()
    {
        while (true)
        {
            InventoryItem item = PickItem();
            if (Add(item))
            {
                Console.WriteLine($"{item.GetType()} added to the pack.\n");
                GetBackpackStatus();
            }
            else
            {
                Console.WriteLine("Pack is full or cannot hold more items.");
                break;
            }
        }
        GetBackpackStatus();
    }

    public void GetBackpackStatus()
    {
        Console.WriteLine("Your pack contains:");
        foreach (InventoryItem item in carriedItems)
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
}

public class Arrow : InventoryItem
{
    public Arrow() : base(0.1, 0.05) { }
}

public class Bow : InventoryItem
{
    public Bow() : base(1, 4) { }
}

public class Rope : InventoryItem
{
    public Rope() : base(1, 1.5) { }
}

public class Water : InventoryItem
{
    public Water() : base(2, 3) { }
}

public class FoodRations : InventoryItem
{
    public FoodRations() : base(1, 0.5) { }
}

public class Sword : InventoryItem
{
    public Sword() : base(5, 3) { }

}
public class InventoryItem
{
    public double Weight { get; }
    public double Volume { get; }
    public InventoryItem(double weight, double volume)
    {
        Weight = weight;
        Volume = volume;
    }
}