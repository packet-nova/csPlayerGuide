Pack pack = new(10, 20, 30);

StartItemSelection();

void StartItemSelection()
{
    while (true)
    {
        InventoryItem item = PickItem();
        if (pack.Add(item))
        {
            Console.Write($"{item.GetType()} added to the pack.\n");
            Console.WriteLine(pack.ToString());
        }
        else
        {
            Console.WriteLine("Pack is full or cannot hold more items.");
            break;
        }
    }
}

InventoryItem PickItem()
{
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