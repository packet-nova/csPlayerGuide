Console.Title = "The Fountain of Objects";


MapSize mapSize = GameOptions.PromptMapSize();
GameOptions options = new(mapSize);

Game game = new(options);
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
public enum GameDifficulty { Easy, Medium, Hard }
public enum MapSize { Small, Medium, Large }