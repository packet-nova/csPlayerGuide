public class Map
{
    private readonly int _row;
    private readonly int _column;

    private readonly RoomType[,] _rooms;

    public RoomType GetRoomAt(int row, int column) => _rooms[row, column];
    public void SetRoomAt(int row, int column, RoomType roomType)
    {
        _rooms[row, column] = roomType;
    }

    public Map(int row, int column)
    {
        _row = row;
        _column = column;
        _rooms = new RoomType[row, column];
    }
}
