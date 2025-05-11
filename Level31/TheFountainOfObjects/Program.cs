Console.Title = "The Fountain of Objects";
GameUI.TitleScreen();

// testing block
//MockMovable newEntity = new();
//Map testMap = new(4, 4);

//newEntity.Move(Direction.North, testMap);
//newEntity.Move(Direction.South, testMap);
//newEntity.Move(Direction.East, testMap);
//newEntity.Move(Direction.West, testMap);


//Actual Game
Game game = new();

while (!game.IsGameOver())
{
    game.Run();
}

public interface IMovable
{
    int X { get; set; }
    int Y { get; set; }
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