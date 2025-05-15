Robot robot = new(0, 0, false);

while (!robot.IsPowered)
{
    Console.Write("The robot is currently powered off. Do you want to power it on? (Y/N): ");
    string? choice = Console.ReadLine();
    if (choice?.ToLower() == "y" || choice?.ToLower() == "yes")
    {
        robot.PowerOn();
    }
}

if (robot.IsPowered)
{
    bool stopRequested = false;
    while (!stopRequested)
    {
        Console.Write("Enter a command: ");
        IRobotCommand? command = UserCommands(robot);
        if (command != null)
        {
            robot.Commands.Add(command);
        }
        if (command.GetType() == typeof(StopCommand))
            stopRequested = true;
    }
    robot.Run();
}

List<IRobotCommand> robotCommands = new List<IRobotCommand>();

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
        "stop" => new StopCommand(),
        _ => null
    };

    if (response == null)
    {
        Console.WriteLine("I don't recognize that command.");
    }

    return response;
}

public interface IRobotCommand
{
    void Run(Robot robot);
}

public class StopCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
    }
}

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.PowerOn();
    }
}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.PowerOff();
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
