public class ActionProcessor
{
    private readonly Player _player;
    private readonly Map _map;
    private readonly Game _game;
    
    public ActionProcessor(Player player, Map map, Game game)
    {
        _player = player;
        _map = map;
        _game = game;
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

        // Process additional commands
        else if (input == "help" || input == "h") GameUI.HelpMessage();
        else if (input == "debug")
        {
            Debug.Enabled = !Debug.Enabled;
            Console.WriteLine($"Debug mode: {Debug.Enabled}");
        }
        else if (input == "activate" && _map.GetRoomAt(_player.Location) == RoomType.Fountain)
        {
            FountainOfObjects.Interact();
            _game.SuppressNextStatus();
        }

        else Console.WriteLine("Invalid command.");

        if (FountainOfObjects.Activated == true && _map.GetRoomAt(_player.Location) == RoomType.Entrance)
        {
            GameUI.WinScreen();
            _game.GameOver();
            return;
        }
    }
}
