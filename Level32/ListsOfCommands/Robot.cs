public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public List<IRobotCommand> Commands { get; } = new List<IRobotCommand>();
    public Robot(int x, int y, bool powerState)
    {
        X = x;
        Y = y;
        IsPowered = powerState;
    }
    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }

    public void PowerOn()
    {
        IsPowered = true;
    }
    public void PowerOff()
    {
        IsPowered = false;
    }
}