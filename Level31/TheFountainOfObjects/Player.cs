public class Player : IMovable
{
    public int X { get; set; }
    public int Y { get; set; }
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
        MovementHelper.Move(this, direction, map);
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