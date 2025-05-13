public class ActionProcessor
{
    private readonly Game _game;
    private readonly Map _map;
    private readonly Player _player;
    private readonly FountainOfObjects _fountain;
    private readonly Maelstrom _maelstrom;

    public ActionProcessor(Game game, Map map, Player player, FountainOfObjects fountain, Maelstrom maelstrom)
    {
        _player = player;
        _map = map;
        _game = game;
        _fountain = fountain;
        _maelstrom = maelstrom;
    }

    /// <summary>
    /// Processes the player's action based on the input string.
    /// </summary>
    public void ProcessAction(string input)
    {
        // Process movement commands
        if (input == "move north" || input == "n" || input == "north")
            _player.Move(Direction.North, _map);
        else if (input == "move south" || input == "s" || input == "south")
            _player.Move(Direction.South, _map);
        else if (input == "move east" || input == "e" || input == "east")
            _player.Move(Direction.East, _map);
        else if (input == "move west" || input == "w" || input == "west")
            _player.Move(Direction.West, _map);

        // Player look command
        else if (input == "look" || input == "l")
            _player.Look(_map, _maelstrom);

        // Process additional commands
        else if (input == "help" || input == "h") GameUI.HelpMessage();
        else if (input == "debug")
        {
            Debug.Enabled = !Debug.Enabled;
            Console.WriteLine($"Debug mode: {Debug.Enabled}");
        }
        else if (input == "activate" || input == "a")
        {
            // Check if player is at the fountain
            if (_map.GetRoomAt(_player.Location) == RoomType.Fountain)
            {
                _fountain.Interact();
                _game.SuppressNextStatus();
            }
        }

        else Console.WriteLine("Invalid command.");

        _game.CheckForEncounter();

        if (((_fountain.Activated) && _map.GetRoomAt(_player.Location) == RoomType.Entrance))
        {
            GameUI.WinScreen();
            _game.GameOver();
            return;
        }
    }
}
