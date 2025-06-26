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
        Console.WriteLine("You spend a turn using heightenend sense.");

        CheckDirection(game, Direction.North, new Location(Location.x - 1, Location.y));
        CheckDirection(game, Direction.South, new Location(Location.x + 1, Location.y));
        CheckDirection(game, Direction.East, new Location(Location.x, Location.y + 1));
        CheckDirection(game, Direction.West, new Location(Location.x, Location.y - 1));
    }

    /// <summary>
    /// Checks what's in a specific direction and reports it to the player.
    /// </summary>
    /// <param name="game">The current game state</param>
    /// <param name="direction">The direction to check</param>
    /// <param name="locationToCheck">The location coordinates to examine</param>
    private void CheckDirection(Game game, Direction direction, Location locationToCheck)
    {
        if (!game.Map.IsOutOfBounds(locationToCheck.x, locationToCheck.y))
        {
            Console.WriteLine($"To the {direction}: {game.Map.GetRoomAt(locationToCheck)} - ");

            if (locationToCheck.Equals(game.Maelstrom.Location))
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