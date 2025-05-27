List<GameObject> objects = new List<GameObject>();
objects.Add(new Ship { ID = 1, X = 0, Y = 0, HP = 50, MaxHP = 100, PlayerID = 1 });
objects.Add(new Ship { ID = 2, X = 4, Y = 2, HP = 75, MaxHP = 100, PlayerID = 1 });
objects.Add(new Ship { ID = 3, X = 9, Y = 3, HP = 0, MaxHP = 100, PlayerID = 2 });

List<Player> players = new List<Player>();
players.Add(new Player(1, "Player 1", "Red"));
players.Add(new Player(2, "Player 2", "Blue"));

IEnumerable<GameObject> everything = from o in objects
                                     select o;
var ids = from o in objects
          select o.ID;

var healthStatus = from o in objects
                   select (o, $"{o.HP}/{o.MaxHP}");

Console.WriteLine(healthStatus);



public class GameObject
{
    public int ID { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public float MaxHP { get; set; }
    public float HP { get; set; }
    public int PlayerID { get; set; }
}

public class Ship : GameObject { }
public record Player(int ID, string UserName, string TeamColor);