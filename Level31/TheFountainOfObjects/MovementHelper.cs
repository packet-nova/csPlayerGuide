public class MovementHelper
{
    public static void Move(IMovable movable, Direction direction, Map map)
    {
        int newX = movable.Location.x;
        int newY = movable.Location.y;
        
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
            movable.Location = new(newX, newY);
            Console.WriteLine($"{movable} moved {direction} to {movable.Location}.");
        }
       // if (map.TryMoveTo(newX, newY, direction))
        //{
        //    movable.X = newX;
        //    movable.Y = newY;
        //    Console.WriteLine($"{movable} moved {direction} to ({movable.X}, {movable.Y}).");
        //}
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"You attempt to move {direction}, but there is nowhere to go. Damp, jagged rock blocks your path.");
            Console.ResetColor();
        }
    }
}