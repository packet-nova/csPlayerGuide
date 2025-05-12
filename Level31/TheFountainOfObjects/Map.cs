public class Map
{
    private readonly RoomType[,] _rooms;

    public Map(int x, int y)
    {
        _rooms = new RoomType[x, y];
    }

    public void GetRoomDescription(Location location)
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

        if (location.Equals(MapGenerator.CatLocation))
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("There's a small, fluffy cat in this room. It looks at you curiously.");
            Console.ResetColor();
        }
        if (location.Equals(MapGenerator.MaelstromLocation))
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("There's a maelstrom here!");
            Console.ResetColor();
        }
    }

    public bool TryMoveTo(int newX, int newY, Direction direction)
    {
        if (IsOutOfBounds(newX, newY))
            return false;
        else return true;
    }

    public int GetXSize() // get boundaries of East/West
    {
        return _rooms.GetLength(0);
    }

    public int GetYSize() // Get boundaries of North/South
    {
        return _rooms.GetLength(1);
    }

    public RoomType GetRoomAt(Location location) => _rooms[location.x, location.y];

    public void SetRoomAt(int x, int y, RoomType roomType)
    {
        _rooms[x, y] = roomType;
    }

    public bool IsOutOfBounds(int x, int y)
    {
        if (x < 0 || x >= GetXSize()) return true;
        if (y < 0 || y >= GetYSize()) return true;
        return false;
    }
}
