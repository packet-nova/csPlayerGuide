Robot robot = new(0, 0, false);

while (!robot.IsPowered)
{
    Console.Write("The robot is currently powered off. Do you want to power it on? (Y/N): ");
    string? choice = Console.ReadLine();
    if (choice?.ToLower() == "y" || choice?.ToLower() == "yes")
    {
        robot.IsPowered = true;
    }
}

if (robot.IsPowered)
{
    for (int i = 0; i < robot.Commands.Length; i++)
    {
        Console.Write("Enter a command: ");
        IRobotCommand? command = UserCommands(robot);
        robot.Commands[i] = command;
    }
    robot.Run();
}

static IRobotCommand? UserCommands(Robot robot)
{
    string? choice = Console.ReadLine();
    IRobotCommand? response = choice switch
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
    public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3];
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
}

public interface IRobotCommand
{
     void Run(Robot robot);
}

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.Y++;
    }
}

public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.Y--;
    }
}

public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.X--;
    }
}

public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.X++;
    }
}
