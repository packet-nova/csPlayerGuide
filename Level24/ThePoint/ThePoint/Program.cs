Point positionOne = new(2, 3);
Point positionTwo = new(-4, 0);
Point origin = new Point();

Console.WriteLine($"The position of point one is: ({positionOne.PositionX}, {positionOne.PositionY})");
Console.WriteLine($"The position of point two is: ({positionTwo.PositionX}, {positionTwo.PositionY})");
Console.WriteLine($"The origin is: ({origin.PositionX}, {origin.PositionY})");

public class Point
{
    public int PositionX { get; }
    public int PositionY { get; }

    public Point(int positionX, int positionY)
    {
        PositionX = positionX;
        PositionY = positionY;
    }

    public Point()
    {
        PositionX = 0;
        PositionY = 0;
    }
}
