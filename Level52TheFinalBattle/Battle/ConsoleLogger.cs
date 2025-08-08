public class ConsoleLogger : IBattleLogger
{
    public void LogMessage(string message)
    {
        Console.WriteLine(message);
    }
    public void TurnNotification(IBattleEntity entity)
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"It is {entity.Name}'s turn.");
        Console.WriteLine();
        Console.ForegroundColor = previousColor;
    }

    public void LogKill(IBattleEntity entity)
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{entity.Name} has been defeated!");
        Console.WriteLine();
        Console.ForegroundColor = previousColor;
    }

    public void PlayerWin()
    {
        Console.WriteLine("You won.");
    }
    public void PlayerLose()
    {
        Console.WriteLine("You lose.");
    }
}