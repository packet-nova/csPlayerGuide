public class Game
{
    private Map _map;
    private Player _player;

    private bool _gameOver = false;
    private bool _suppressStatus = false;

    public Game(GameOptions options)
    {
        var (map, playerStart) = MapGenerator.GenerateMap(options.MapSize);
        _player = new Player(15);
        _map = map;
        _player.SetPosition(playerStart.x, playerStart.y);
    }

    public bool IsGameOver()
    {
        return _gameOver;
    }

    public void Run()
    {
        if (!_suppressStatus)
            GameUI.PlayerStatus(_player, _map);
        else
            _suppressStatus = false;

        string input = PromptUserForAction();
        ProcessAction(input);
        Console.WriteLine(_map.GetXSize());
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

    public void ProcessAction(string input)
    {
        if (input == "move north" || input == "n" || input == "north") _player.Move(Direction.North, _map);
        else if (input == "move south" || input == "s" || input == "south") _player.Move(Direction.South, _map);
        else if (input == "move east" || input == "e" || input == "east") _player.Move(Direction.East, _map);
        else if (input == "move west" || input == "w" || input == "west") _player.Move(Direction.West, _map);
        else if (input == "help" || input == "h") GameUI.HelpMessage();
        else if (input == "activate" && _map.GetRoomAt(_player.Location) == RoomType.Fountain)
        {
            FountainOfObjects.Interact();
            _suppressStatus = true;
        }

        else Console.WriteLine("Invalid command.");

        //if (FountainOfObjects.Activated == true && _map.GetRoomAt(_player.X, _player.Y) == RoomType.Entrance)
        if (FountainOfObjects.Activated == true && _map.GetRoomAt(_player.X, _player.Y) == RoomType.Entrance)
        {
            GameUI.WinScreen();
            _gameOver = true;
            return;
        }
    }
}