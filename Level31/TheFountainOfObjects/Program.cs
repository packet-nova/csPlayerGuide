Game game = new();
game.TitleScreen();

while (!game.IsGameOver())
{
    game.Run();
}

public interface IMovable
{
    void Move(Direction direction, Map map);
}

public interface IInteractable
{
    void Interact();
}
public enum Direction { North, South, East, West }
public enum RoomType { Empty, Entrance, Fountain, Encounter, MapBoundary }