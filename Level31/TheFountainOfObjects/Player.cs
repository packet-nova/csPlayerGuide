public class Player : IMovable
{
    public Location Location { get; set; }
    public int MaxHealth { get; private set; }
    public int CurrentHealth {  get; private set; }
    public int PlayerLevel { get; private set; }

    private bool _isDead;
    public bool IsDead => _isDead || CurrentHealth <= 0;

    public Player(Location location, int maxHealth = 15, int level = 1)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        PlayerLevel = level;
        Location = location;
    }

    public void Look(Map map, Maelstrom maelstrom)
    {
        Location northLocation = new(Location.x - 1, Location.y);
        Location southLocation = new(Location.x + 1, Location.y);
        Location eastLocation = new(Location.x, Location.y + 1);
        Location westLocation = new(Location.x, Location.y - 1);

        Console.WriteLine("You spend a turn using heightenend sense.");

        // Check to the North
        if (!map.IsOutOfBounds(northLocation.x, northLocation.y))
        {
            Console.WriteLine($"To the North: {map.GetRoomAt(northLocation)} - ");
            if (northLocation.Equals(maelstrom.Location))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(maelstrom.SenseDescription);
                Console.ResetColor();
            }
        }

        // Check to the South
        if (!map.IsOutOfBounds(southLocation.x, southLocation.y))
        {
            Console.WriteLine($"To the South: {map.GetRoomAt(southLocation)} - ");
            if (southLocation.Equals(maelstrom.Location))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(maelstrom.SenseDescription);
                Console.ResetColor();
            }
        }

        // Check to the East
        if (!map.IsOutOfBounds(eastLocation.x, eastLocation.y))
        {
            Console.WriteLine($"To the East: {map.GetRoomAt(eastLocation)} - ");
            if (eastLocation.Equals(maelstrom.Location))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(maelstrom.SenseDescription);
                Console.ResetColor();
            }
        }

        // Check to the West
        if (!map.IsOutOfBounds(westLocation.x, westLocation.y))
        { 
            Console.WriteLine($"To the West: {map.GetRoomAt(westLocation)} - ");
            if (westLocation.Equals(maelstrom.Location))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(maelstrom.SenseDescription);
                Console.ResetColor();
            }
        }

    }

    public void Move(Direction direction, Map map)
    {
        MovementHelper.Move(this, direction, map);
    }

    public void KillPlayer()
    {
        _isDead = true;
    }

    public string LivingStatus()
    {
        if (IsDead)
            Console.ForegroundColor = ConsoleColor.Red;
        else 
            Console.ForegroundColor = ConsoleColor.Green;
        string status = IsDead ? "Dead" : "Alive";
        Console.ResetColor();
        return status;
    }
}