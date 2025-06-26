public class MockMovable : IMovable
{
    public Location Location { get; set; }
    //private readonly MovementHelper _movementHelper = new();

    public MockMovable(int startX = 0, int startY = 0)
    {
        Location = new Location(startX, startY);
    }
    public void Move(Direction direction, Map map)
    {
        MovementHelper.Move(this, direction, map);
    }
}