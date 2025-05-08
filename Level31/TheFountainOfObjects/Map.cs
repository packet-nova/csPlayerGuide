public class Map
{
    private readonly int _x;
    private readonly int _y;

    private readonly RoomType[,] _rooms;

    public int X => _x;
    public int Y => _y;

    public Map(int row, int column)
    {
        _x = row;
        _y = column;
        _rooms = new RoomType[row, column];
    }

    public RoomType GetRoomAt(int x, int y) => _rooms[x, y];
    public void GetRoomDescription(int x, int y)
    {
        RoomType room = _rooms[x, y];
        
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
                Console.ForegroundColor = ConsoleColor.Red;
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
                Console.WriteLine("This room is unremarkable.");
                Console.ResetColor();
                break;
        }
    }

    public int GetXSize()
    {
        return _rooms.GetLength(0);
    }

    public int GetYSize()
    {
        return _rooms.GetLength(1);
    }

    public void SetRoomAt(int row, int column, RoomType roomType)
    {
        _rooms[row, column] = roomType;
    }

    public bool IsOutOfBounds(int x, int y)
    {
        if (x < 0 || x >= GetXSize()) return true;
        if (y < 0 || y >= GetYSize()) return true;
        return false;
    }
}
