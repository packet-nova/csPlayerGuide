using Level52TheFinalBattle.Battle;
using Level52TheFinalBattle.BattleEntities;
using Level52TheFinalBattle.Item;

public class Game
{
    private readonly Player _heroPlayer;
    private readonly Player _monsterPlayer;
    private readonly TrueProgrammer _trueProgrammer;
    private Battle? _currentBattle;
    private int _battleTier = 1;

    public Game(TrueProgrammer trueProgrammer, Player heroPlayer, Player monsterPlayer)
    {
        _trueProgrammer = trueProgrammer;
        _heroPlayer = heroPlayer;
        _monsterPlayer = monsterPlayer;
    }

    public void Run()
    {
        BattleGenerator battleGenerator = new();
        BattleParty heroParty = new([_trueProgrammer], _heroPlayer);
        heroParty.Items.Add(new LesserHealingPotion());
        heroParty.Items.Add(new LesserHealingPotion());
        heroParty.Items.Add(new LesserHealingPotion());

        while (_battleTier <= 3)
        {
            BattleData data = battleGenerator.GenerateBattle(heroParty, _heroPlayer, _monsterPlayer, _battleTier);
            _currentBattle = new Battle(data.HeroParty, data.MonsterParty, new ConsoleLogger());

            LoadBattleText();

            while (_currentBattle.IsActive)
            {
                _currentBattle.ExecuteTurn();
            }

            if (_currentBattle.HeroEntities.Count == 0)
            {
                Console.WriteLine("You lose! Press any key to exit...");
                Console.ReadKey();
                break;
            }

            _battleTier++;
        }
        Console.WriteLine("You won the game. There are no more battles.");
    }

    public void LoadBattleText()
    {
        Console.Write($"Loading battle {_battleTier}");
        Thread.Sleep(250);
        Console.Write(".");
        Thread.Sleep(250);
        Console.Write(".");
        Thread.Sleep(250);
        Console.Write(".");
        Console.Clear();
    }
}
