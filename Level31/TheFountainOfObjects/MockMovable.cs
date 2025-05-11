public class MockMovable : IMovable
{
    public int X { get; set; }
    public int Y { get; set; }
    //private readonly MovementHelper _movementHelper = new();

    public MockMovable(int startX = 0, int startY = 0)
    {
        X = startX;
        Y = startY;
    }
    public void Move(Direction direction, Map map)
    {
        MovementHelper.Move(this, direction, map);
    }
}