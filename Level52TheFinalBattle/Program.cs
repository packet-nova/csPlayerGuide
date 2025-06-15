Game game = new();

List<Skeleton> playerParty = new List<Skeleton>();
List<Skeleton> monsterParty = new List<Skeleton>();

Skeleton s1 = new();
Skeleton s2 = new();

playerParty.Add(s1);
monsterParty.Add(s2);

game.Run(s1, s2);


public class Game
{
    public Skeleton SkeletonTurn { get; private set; } 
    public Game()
    {

    }
    public void Run(Skeleton s1, Skeleton s2)
    {
        while (true)
        {
            SkeletonTurn = s1;
            Thread.Sleep(500);
            s1.DoNothing();
            Console.WriteLine($"It is {Skeleton.Name}'s turn.");
            Thread.Sleep(500);
            s2.DoNothing();
            SkeletonTurn = SkeletonTurn == s1 ? s2 : s1;
            Console.WriteLine($"It is {Skeleton.Name}'s turn.");
        }
    }
}

public class Player
{
    public string Name { get; private set; }

    public Player(string name)
    {
        Name = name;
    }
}

public class Skeleton
{
    public static string Name = "SKELETON";

    public void DoNothing()
    {
        Console.WriteLine($"{Name} did NOTHING.");
        Console.WriteLine();
    }
}

public class CombatLog
{

}