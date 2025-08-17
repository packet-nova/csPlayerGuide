using Level52TheFinalBattle.Battle;
using Level52TheFinalBattle.BattleEntities;

public class Game
{
    private readonly Player _heroPlayer;
    private readonly Player _monsterPlayer;
    private readonly TrueProgrammer _trueProgrammer;
    private Battle? _currentBattle;  // null is handled in Run()
    private int _battleTier = 1;

    public Game(TrueProgrammer trueProgrammer, Player heroPlayer, Player monsterPlayer)
    {
        _trueProgrammer = trueProgrammer;
        _heroPlayer = heroPlayer;
        _monsterPlayer = monsterPlayer;
    }

    public void Run()
    {
        while (_battleTier <= 3)
        {
            _currentBattle = _battleTier switch
            {
                1 => Battle.SingleSkeletonBattle(_trueProgrammer, _heroPlayer, _monsterPlayer),
                2 => Battle.TwoSkeletonBattle(_trueProgrammer, _heroPlayer, _monsterPlayer),
                3 => Battle.CodedOneBattle(_trueProgrammer, _heroPlayer, _monsterPlayer),
                _ => throw new InvalidOperationException($"No battle implemented for battle tier: {_battleTier}.")
            };

            LoadBattleText();

            while (_currentBattle.IsActive)
            {
                _currentBattle.ExecuteTurn();
            }

            // Check to see if player lost the game
            if (_currentBattle.HeroEntities.Count == 0)
            {
                Console.WriteLine("You lose! Press any key to exit...");
                Console.ReadKey();
                break;
            }

            // Player won battle. Go to next battle (tier).
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
