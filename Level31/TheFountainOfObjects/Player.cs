public class Player : IMovable
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public (int x, int y) Location => (X, Y);
    public int MaxHealth { get; private set; }
    public int CurrentHealth {  get; private set; }
    public int PlayerLevel { get; private set; }
    public bool IsDead => CurrentHealth <= 0;

    public Player(int maxHealth = 15, int level = 1)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        PlayerLevel = level;
    }

    public void Move(Direction direction, Map map)
    {
        int newX = X;
        int newY = Y;

        switch (direction) // decrement X to move south, decrement Y to move west
        {
            case Direction.North:
                newX--;
                break;
            case Direction.South:
                newX++;
                break;
            case Direction.West:
                newY--;
                break;
            case Direction.East:
                newY++;
                break;
        }

        if (map.TryMoveTo(newX, newY, direction)) // prevent movement if direction is out of bounds
        {
            X = newX;
            Y = newY;
            Console.WriteLine($"You have moved {direction}.");
        }
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

    public void SetPosition(int x, int y)
    {
        X = x;
        Y = y;
    }
}