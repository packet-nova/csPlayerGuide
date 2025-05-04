public abstract class RobotCommand
{
    public abstract void Run(Robot robot);
}

public class OnCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.Y++;
    }
}

public class SouthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.Y--;
    }
}

public class WestCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.X--;
    }
}

public class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.X++;
    }
}