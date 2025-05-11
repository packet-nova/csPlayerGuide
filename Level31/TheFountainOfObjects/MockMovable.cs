public class MockMovable : IMovable
{
    public int X { get; set; }
    public int Y { get; set; }

    public MockMovable(int startX = 0, int startY = 0)
    {
        X = startX;
        Y = startY;
    }
    public void Move(Direction direction, Map map)
    {
        int newX = X;
        int newY = Y;

        // Determine the new position based on the direction
        switch (direction)
        {
            case Direction.North:
                newX--;
                break;
            case Direction.South:
                newX++;
                break;
            case Direction.West:
                newY--;
                break;
            case Direction.East:
                newY++;
                break;
        }

        // Validate the movement using the map
        if (map.TryMoveTo(newX, newY, direction))
        {
            X = newX;
            Y = newY;
            Console.WriteLine($"Mock entity moved {direction} to ({X}, {Y}).");
        }
        else
        {
            Console.WriteLine($"Mock entity cannot move {direction}. Movement blocked or out of bounds.");
        }
    }
    //public void Move(Direction direction, Map map)
    //{
    //    Console.WriteLine($"Mock entity moved {direction}.");
    //}
}