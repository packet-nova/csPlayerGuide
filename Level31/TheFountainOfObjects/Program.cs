Console.Title = "The Fountain of Objects";
GameUI.TitleScreen();

//Actual Game
Game game = new();

while (!game.IsGameOver())
{
    game.Run();
}

public interface IMovable
{
    Location Location { get; set; }
    void Move(Direction direction, Map map);
}

public interface IInteractable
{
    void Interact();
}

public enum Direction { North, South, East, West }
public enum RoomType { Empty, Entrance, Fountain, Encounter, Pit, MapBoundary }
public enum GameDifficulty { Easy, Medium, Hard }
public enum MapSize { Small, Medium, Large }