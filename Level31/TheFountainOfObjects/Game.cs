public class Game
{
    private MapData _mapData;
    private Map _map;
    private Player _player;
    private FountainOfObjects _fountain;
    private Maelstrom _maelstrom;
    private ActionProcessor _actionProcessor;

    private bool _gameOver;
    private bool _suppressStatus;

    public Game()
    {
        //Prompt user for game options before generating map and constructing game
        GameOptions options = GameOptions.PromptGameOptions();

        MapGenerator mapGenerator = new();
        _mapData = mapGenerator.GenerateMap(options.MapSize);
        _map = _mapData.Map;
        _player = new(_mapData.PlayerSpawn);
        _fountain = new(_mapData.FountainSpawn);
        _maelstrom = new(_mapData.MaelstromSpawn);

        _actionProcessor = new(this, _map, _player, _fountain, _maelstrom);
    }

    public void Run()
    {
        if (!_suppressStatus)
            GameUI.PlayerStatus(_player, _map, _mapData, _maelstrom);
        else
            _suppressStatus = false;

        string input = PromptUserForAction();
        _actionProcessor.ProcessAction(input);
    }

    public string PromptUserForAction()
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("What do you want to do? ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        string input = Console.ReadLine();
        Console.ForegroundColor = previousColor;
        return input.ToLower().Trim();
    }

    public void CheckForEncounter()
    {
        // Kill the player if there's a deadly encounter (one shot).
        if (HasDeadlyEncounter())
        {
            _map.GetRoomDescription(_player.Location, _maelstrom);
            KillPlayerByEntity();
        }
    }

    public void KillPlayerByEntity()
    {
        _player.KillPlayer();
        SuppressNextStatus();
        GameUI.LoseScreen();
        GameOver();
    }

    public bool HasDeadlyEncounter()
    {
        return (_player.Location.Equals(_maelstrom.Location));
    }

    public void SuppressNextStatus()
    {
        _suppressStatus = true;
    }
    public bool IsGameOver()
    {
        return _gameOver;
    }

    public void GameOver()
    {
        _gameOver = true;
    }

    public void MoveEntitiy(IMovable entity, Direction direction, Map map)
    {
        entity.Move(direction, map);
    }
}
