//public class Character
//{
//    public string Name { get; private set; }
//    public int Level { get; private set; }
//    public double MaxInventoryWeight { get; private set; }
//    public double CurrentInventoryWeight => GetInventoryWeight();
//    public List<Item> Inventory { get; private set; }
//    public Character(string name, int level, double maxInventoryWeight)
//    {
//        Name = name;
//        Level = level;
//        MaxInventoryWeight = maxInventoryWeight;
//        Inventory = new List<Item>();
//    }

//    public double GetInventoryWeight()
//    {
//        double currentWeight = 0;
//        foreach (Item item in Inventory)
//        {
//            currentWeight += item.Weight;
//        }
//        return currentWeight;
//    }

//    public bool TryAddItem(Item item)
//    {
//        if (item.Weight + CurrentInventoryWeight > MaxInventoryWeight)
//        {
//            return false;
//        }

//        Inventory.Add(item);
//        return true;
//    }

//    public bool TryRemoveItemByName(string name)
//    {
//        return Inventory.Remove(FindItemByName(name));
//    }

//    public void DisplayInventory()
//    {
//        foreach (Item item in Inventory)
//        {
//            Console.WriteLine($"{item.Name} | {item.Value} | {item.Weight}");
//        }
//    }

//    public Item FindItemByName(string name)
//    {
//        foreach (Item item in Inventory)
//        {
//            if (name == item.Name)
//            {
//                return item;
//            }
//        }
//        return null;
//    }

//    public void SortInventory(List<Item> sorter)
//    {
//        if (sorter.Sort(Name))
//            inventory.Name.Sort();
//    }
//}
