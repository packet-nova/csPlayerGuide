public class Game
{
    public MapData MapData { get; private set; }
    public Map Map { get; private set; }
    public Player Player { get; private set; }
    public FountainOfObjects Fountain { get; private set; }
    public Maelstrom Maelstrom { get; private set; }
    
    private ActionProcessor _actionProcessor;
    private bool _gameOver;
    private bool _suppressStatus;

    public Game()
    {
        //Prompt user for game options before generating map and constructing game
        GameOptions options = GameOptions.PromptGameOptions();

        MapGenerator mapGenerator = new();
        MapData = mapGenerator.GenerateMap(options.MapSize);
        Map = MapData.Map;
        Player = new(MapData.PlayerSpawn);
        Fountain = new(MapData.FountainSpawn);
        Maelstrom = new(MapData.MaelstromSpawn);

        _actionProcessor = new(this);
    }

    public void Run()
    {
        if (!_suppressStatus)
            GameUI.PlayerStatus(this);
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
            Map.GetRoomDescription(Player.Location, Maelstrom);
            KillPlayerByEntity();
        }
    }

    public void KillPlayerByEntity()
    {
        Player.KillPlayer();
        SuppressNextStatus();
        GameUI.LoseScreen();
        GameOver();
    }

    public bool HasDeadlyEncounter()
    {
        return (Player.Location.Equals(Maelstrom.Location));
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
}
