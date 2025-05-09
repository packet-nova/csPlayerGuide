public class Game
{
    private Map _map;
    private Player _player;

    private bool _gameOver = false;
    private bool _suppressStatus = false;

    public Game(GameOptions options)
    {
        _player = new Player();

        var (map, playerStart) = MapGenerator.GenerateMap(options.MapSize);
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
            PlayerStatus();
        else
            _suppressStatus = false;

        string input = PromptUserForAction();
        ProcessAction(input);
    }

    public void TitleScreen()
    {
        Console.Write("""
            The Fountain of Objects

            You've wandered into a dark cave to find and reactivate the Fountain of Objects.
            Navigate to locate and activate the fountain.
            Then make your way to the exit.
            
            Press any key to continue, and good luck!
            """);
        Console.ReadKey();
        Console.Clear();
        for (int i = 0; i < 5; i++)
        {
            Console.Write(". ");
            Thread.Sleep(400);
        }
        Console.Clear();
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
        else if (input == "activate" && _map.GetRoomAt(_player.X, _player.Y) == RoomType.Fountain)
        {
            FountainOfObjects.Interact();
            _suppressStatus = true;
        }

        else Console.WriteLine("Invalid command.");

        if (FountainOfObjects.Activated == true && _player.Location == (0, 0))
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You activated the fountain and made a safe exit. You win!");
            Console.ForegroundColor = previousColor;
            _gameOver = true;
            return;
        }
    }

    public void PlayerStatus()
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"-------------------------------------------------------------------------");
        Console.WriteLine($"You are in the room at {_player.Location}.");
        _map.GetRoomDescription(_player.X, _player.Y);
        Console.ForegroundColor = previousColor;
    }
}