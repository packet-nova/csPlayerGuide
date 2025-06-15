public class Game
{
    private readonly List<ICombat> _heroParty;
    private readonly List<ICombat> _monsterParty;

    public List<ICombat> CurrentTurn { get; private set; }

    public Game()
    {
        Console.Write("What is the True Programmer's name? ");
        string trueProgrammer = Console.ReadLine();
        TrueProgrammer player = new(trueProgrammer);
        Skeleton skeleton1 = new("SKELETON");

        _heroParty = new List<ICombat>();
        _monsterParty = new List<ICombat>();

        _heroParty.Add(player);
        _monsterParty.Add(skeleton1);

        CurrentTurn = _heroParty;
    }

    public void Run()
    {
        while (true)
        {
            if (CurrentTurn == _heroParty)
            {
                PlayerPartyTurn();
            }
            else
            {
                MonsterPartyTurn();
            }

            CurrentTurn = CurrentTurn == _heroParty ? _monsterParty : _heroParty;
        }
    }

    public void PlayerPartyTurn()
    {
        foreach (var member in _heroParty)
        {
            Console.WriteLine($"It is {member.Name}'s turn.");
            Console.Write("Action? ");
            Console.ReadLine();
            member.DoNothing();
        }
    }

    public void MonsterPartyTurn()
    {
        foreach (var member in _monsterParty)
        {
            Console.WriteLine($"It is {member.Name}'s turn.");
            Console.Write("Action? ");
            Console.ReadLine();
            member.DoNothing();
        }
    }
}
