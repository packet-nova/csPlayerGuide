public class Game
{
    public MapData MapData { get; private set; }
    public Map Map { get; private set; }
    public Player Player { get; private set; }
    public FountainOfObjects Fountain { get; private set; }
    public Maelstrom Maelstrom { get; private set; }
    public DateTime StartTime { get; } = DateTime.Now;

private ActionProcessor _actionProcessor;
    private bool _gameOver;
    private bool _suppressStatus;
    

    /// <summary>
    /// Initializes a new instance of the <see cref="Game"/> class, setting up the game environment based on
    /// user-specified options.
    /// </summary>
    /// <remarks>This constructor prompts the user to configure game options, generates the game map, and
    /// initializes key game components such as the player, fountain, and maelstrom. It also prepares the action
    /// processor to handle player actions during gameplay.</remarks>
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

    /// <summary>
    /// Prompts the user for an action by displaying a message and reading their input.
    /// </summary>
    /// <remarks>The user's input is converted to lowercase and trimmed of leading and trailing whitespace
    /// before being returned. The console text color is temporarily changed to enhance readability during the
    /// prompt.</remarks>
    /// <returns>A string containing the user's input, converted to lowercase and trimmed of whitespace.</returns>
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
        /// Kill the player if they encounter a maelstrom.
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
        GameUI.LoseScreen(this);
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

    /// <summary>
    /// Calculates and returns the total run duration as a formatted string.
    /// </summary>
    /// <remarks>The total run duration is calculated as the difference between the current time and the  <see
    /// cref="StartTime"/> property. The result is formatted as "Total run duration:
    /// {hours}h:{minutes}m:{seconds}.".</remarks>
    /// <returns>A string representing the total run duration in hours, minutes, and seconds.</returns>
    public string FormattedTotalRunDuration()
    {
        DateTime endTime = DateTime.Now;
        TimeSpan runDuration= endTime - StartTime;
        Console.ForegroundColor = ConsoleColor.Yellow;
        return $"Total run duration: {runDuration.Hours}h:{runDuration.Minutes}m:{runDuration.Seconds}s.";
        Console.ResetColor();
    }
}
