public class Player : IMovable
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public (int x, int y) Location => (X, Y);

    public void Move(Direction direction, Map map)
    {
        int newX = X;
        int newY = Y;

        switch (direction) // decrement X to move south, decrement Y to move west
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

        if (map.TryMoveTo(newX, newY, direction)) // prevent movement if direction is out of bounds
        {
            X = newX;
            Y = newY;
            Console.WriteLine($"You have moved {direction}.");
        }
    }
    public void SetPosition(int x, int y)
    {
        X = x;
        Y = y;
    }
}