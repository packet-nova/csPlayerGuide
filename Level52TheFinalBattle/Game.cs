public class Game
{
    private readonly List<ICombat> _playerParty;
    private readonly List<ICombat> _monsterParty;

    public List<ICombat> CurrentTurn { get; private set; }

    public Game()
    {
        Console.Write("What is the True Programmer's name? ");
        string trueProgrammer = Console.ReadLine();
        TrueProgrammer player = new(trueProgrammer);
        Skeleton s1 = new("SKELETON");

        _playerParty = new List<ICombat>();
        _monsterParty = new List<ICombat>();

        _playerParty.Add(player);
        _monsterParty.Add(s1);

        CurrentTurn = _playerParty;
    }

    public void Run()
    {
        while (true)
        {
            if (CurrentTurn == _playerParty)
            {
                PlayerPartyTurn();
            }
            else
            {
                MonsterPartyTurn();
            }

            CurrentTurn = CurrentTurn == _playerParty ? _monsterParty : _playerParty;
        }
    }

    public void PlayerPartyTurn()
    {
        foreach (var member in _playerParty)
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
