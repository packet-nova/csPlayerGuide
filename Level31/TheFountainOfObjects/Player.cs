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

    public void Look(Game game)
    {
        Location northLocation = new(Location.x - 1, Location.y);
        Location southLocation = new(Location.x + 1, Location.y);
        Location eastLocation = new(Location.x, Location.y + 1);
        Location westLocation = new(Location.x, Location.y - 1);

        Console.WriteLine("You spend a turn using heightenend sense.");

        // Check to the North
        if (!game.Map.IsOutOfBounds(northLocation.x, northLocation.y))
        {
            Console.WriteLine($"To the North: {game.Map.GetRoomAt(northLocation)} - ");
            if (northLocation.Equals(game.Maelstrom.Location))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(game.Maelstrom.SenseDescription);
                Console.ResetColor();
            }
        }

        // Check to the South
        if (!game.Map.IsOutOfBounds(southLocation.x, southLocation.y))
        {
            Console.WriteLine($"To the South: {game.Map.GetRoomAt(southLocation)} - ");
            if (southLocation.Equals(game.Maelstrom.Location))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(game.Maelstrom.SenseDescription);
                Console.ResetColor();
            }
        }

        // Check to the East
        if (!game.Map.IsOutOfBounds(eastLocation.x, eastLocation.y))
        {
            Console.WriteLine($"To the East: {game.Map.GetRoomAt(eastLocation)} - ");
            if (eastLocation.Equals(game.Maelstrom.Location))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(game.Maelstrom.SenseDescription);
                Console.ResetColor();
            }
        }

        // Check to the West
        if (!game.Map.IsOutOfBounds(westLocation.x, westLocation.y))
        { 
            Console.WriteLine($"To the West: {game.Map.GetRoomAt(westLocation)} - ");
            if (westLocation.Equals(game.Maelstrom.Location))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(game.Maelstrom.SenseDescription);
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
        CurrentHealth = 0;
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