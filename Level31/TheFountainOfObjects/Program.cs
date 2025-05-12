Console.Title = "The Fountain of Objects";
GameUI.TitleScreen();

//Actual Game
Game game = new();

while (!game.IsGameOver())
{
    game.Run();
    if (game.IsGameOver())
    {
        Console.Write("Do you want to play again? [Y]/N: ");
        string response = Console.ReadLine();
        
        if (response.ToLower() == "y" || response.ToLower() == "")
        {
            game = new();
        }
        else
        {
            Console.WriteLine("Thanks for playing!");
            break;
        }
    }
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

public record struct Location(int x, int y);

public enum Direction { North, South, East, West }
public enum RoomType { Empty, Entrance, Fountain, Encounter, Pit, MapBoundary }
public enum GameDifficulty { Easy, Medium, Hard }
public enum MapSize { Small, Medium, Large }