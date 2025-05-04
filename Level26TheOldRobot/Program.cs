Robot robot = new(0, 0, true);


if (robot.IsPowered)
{
    for (int i = 0; i < robot.Commands.Length; i++)
    {
        Console.Write("Enter a command: ");
        RobotCommand? command = UserCommands(robot);
        robot.Commands[i] = command;
    }
    robot.Run();
}


static RobotCommand? UserCommands(Robot robot)
{
    string? choice = Console.ReadLine();
    RobotCommand? response = choice switch
    {
        "north" => new NorthCommand(),
        "south" => new SouthCommand(),
        "west" => new WestCommand(),
        "east" => new EastCommand(),
        "on" => new OnCommand(),
        "off" => new OffCommand(),
        _ => null
    };

    if (response == null)
    {
        Console.WriteLine("I don't recognize that command.");
    }

    return response;
}

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public RobotCommand?[] Commands { get; } = new RobotCommand?[3];
    public Robot(int x, int y, bool powerState)
    {
        X = x;
        Y = y;
        IsPowered = powerState;
    }
    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}
