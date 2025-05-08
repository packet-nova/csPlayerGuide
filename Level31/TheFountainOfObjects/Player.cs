public class Player : IMovable
{
    public int X { get; private set; } = 0;
    public int Y { get; private set; } = 0;
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

        if (map.IsOutOfBounds(newX, newY))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"You attempt to move {direction}, but there is no where to go. Damp, jagged rock blocks your path.");
            Console.ResetColor();
        }

        else
        {
            X = newX;
            Y = newY;
            Console.WriteLine($"You have moved {direction}.");
        }
    }
}