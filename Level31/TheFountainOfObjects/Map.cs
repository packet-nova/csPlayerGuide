public class Map
{
    private readonly RoomType[,] _rooms;
    public int XSize => _rooms.GetLength(0);
    public int YSize => _rooms.GetLength(1);
    

    public Map(int x, int y)
    {
        _rooms = new RoomType[x, y];
    }

    /// <summary>
    /// Displays a description of the room at the specified location based on its type.
    /// </summary>
    /// <remarks>The description is displayed in the console with color-coded text to indicate the type of
    /// room. Room types include Empty, Entrance, Encounter, and Fountain. If the room type is not set, a default
    /// message is displayed indicating a potential issue.</remarks>
    /// <param name="location">The coordinates of the room to describe.</param>
    /// <param name="maelstrom">The current state of the Maelstrom, which may influence the room's context.</param>
    public void GetRoomDescription(Location location, Maelstrom maelstrom)
    {
        RoomType room = _rooms[location.x, location.y];

        switch (room)
        {
            case RoomType.Empty:
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("This room is empty and unremarkable.");
                Console.ResetColor();
                break;

            case RoomType.Entrance:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Sunlight pierces the darkness. This must be the entrance.");
                Console.ResetColor();
                break;

            case RoomType.Encounter:
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Something lurks about here...");
                Console.ResetColor();
                break;

            case RoomType.Fountain:
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("You hear a faint trickle of water. The Fountain of Objects is here!");
                Console.ResetColor();
                break;

            default:
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("NO ROOM SET. MOST LIKELY BUG");
                Console.ResetColor();
                break;
        }
    }

    public bool TryMoveTo(int newX, int newY, Direction direction)
    {
        if (IsOutOfBounds(newX, newY))
            return false;
        else return true;
    }

    public RoomType GetRoomAt(Location location) => _rooms[location.x, location.y];

    public void SetRoomAt(int x, int y, RoomType roomType)
    {
        _rooms[x, y] = roomType;
    }

    public bool IsOutOfBounds(int x, int y)
    {
        if (x < 0 || x >= XSize) return true;
        if (y < 0 || y >= YSize) return true;
        return false;
    }
}
