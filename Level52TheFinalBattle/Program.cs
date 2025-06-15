Game game = new();
game.Run();


public class Game
{
    private readonly List<Skeleton> _playerParty;
    private readonly List<Skeleton> _monsterParty;


    public Game()
    {
        Skeleton s1 = new("SKELETON");
        Skeleton s2 = new("SKELETON");
        _playerParty = new List<Skeleton>();
        _monsterParty = new List<Skeleton>();
        _playerParty.Add(s1);
        _monsterParty.Add(s2);
    }
    public void Run()
    {
        while (true)
        {
            Thread.Sleep(500);
            Console.WriteLine($"It is SKELETON's turn.");
            PlayerPartyTurn();
            Thread.Sleep(500);
            Console.WriteLine($"It is SKELETON's turn.");
            MonsterPartyTurn();
        }
    }

    public void PlayerPartyTurn()
    {
        foreach (var member in _playerParty)
        {
            Console.Write("Action? ");
            Console.ReadLine();
            member.DoNothing();
        }
    }
    public void MonsterPartyTurn()
    {
        foreach (var member in _monsterParty)
        {
            Console.Write("Action? ");
            Console.ReadLine();
            member.DoNothing();
        }
    }


    public void ClearParty<T>(List<T> list)
    {
        list.Clear();
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
    public string Name { get; init; }

    public Skeleton(string name)
    {
        Name = name;
    }   

    public void DoNothing()
    {
        Console.WriteLine($"{Name} did NOTHING.");
        Console.WriteLine();
    }
}