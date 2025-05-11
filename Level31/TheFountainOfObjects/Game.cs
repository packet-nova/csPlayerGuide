public class Game
{
    private Map _map;
    private Player _player;
    private ActionProcessor _actionProcessor;

    private bool _gameOver;
    private bool _suppressStatus;

    public Game()
    {
        //Prompt user for game options before generating map and constructing game
        GameOptions options = GameOptions.PromptGameOptions();

        _map = MapGenerator.GenerateMap(options.MapSize);
        _player = new Player(15);

        //Set player spawn location
        var (playerSpawnX, playerSpawnY) = MapGenerator.PlayerSpawnLocation;
        _player.SetPosition(playerSpawnX, playerSpawnY);
        _actionProcessor = new(_player, _map, this);
    }

    public void Run()
    {
        if (!_suppressStatus)
            GameUI.PlayerStatus(_player, _map);
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
