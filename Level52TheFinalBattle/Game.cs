using System.Runtime.CompilerServices;

public class Game
{
    private readonly List<ICombat> _heroParty = new List<ICombat>();
    private readonly List<ICombat> _monsterParty = new List<ICombat>();

    public CombatMenu Menu { get; private set; }
    public TrueProgrammer TrueProgrammer { get; private set; }
    public List<ICombat> CurrentTurn { get; private set; }

    public Game()
    {
        TrueProgrammer = new(CreateTrueProgrammer());
        Menu = new CombatMenu();
        Skeleton skeleton1 = new("SKELETON");

        _heroParty.Add(TrueProgrammer);
        _monsterParty.Add(skeleton1);

        CurrentTurn = _heroParty;
    }

    public void Run()
    {
        while (true)
        {
            if (CurrentTurn == _heroParty)
            {
                Thread.Sleep(500);
                PlayerPartyTurn(Menu);
            }
            else
            {
                Thread.Sleep(500);
                MonsterPartyTurn(Menu);
            }

            CurrentTurn = CurrentTurn == _heroParty ? _monsterParty : _heroParty;
        }
    }

    public void PlayerPartyTurn(CombatMenu menu)
    {
        foreach (var member in _heroParty)
        {
            Console.WriteLine($"It is {member.Name}'s turn.");
            Menu.DisplayMenu();
        }
    }

    public void MonsterPartyTurn(CombatMenu menu)
    {
        foreach (var member in _monsterParty)
        {
            Console.WriteLine($"It is {member.Name}'s turn.");
            Menu.DisplayMenu();
        }
    }

    public string CreateTrueProgrammer()
    {
        Console.Write("What is the True Programmer's name? ");
        return Console.ReadLine();
    }
}
