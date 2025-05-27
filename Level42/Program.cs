/*List<GameObject> objects = new List<GameObject>();
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
foreach (var health in healthStatus)
    Console.WriteLine(health);

IEnumerable<Ship> ships = from Ship s in objects
                          select s;
foreach (var ship in ships)
    Console.WriteLine(ship);



*//*
//Consider this keyword-based query
var results = from o in objects
              where o.HP > 0
              orderby o.HP
              select o.HP / o.MaxHP;

//With method call syntax, it would look like this
var results = objects
.Where(o => o.HP > 0)
.OrderBy(o => o.HP)
.Select(o => o.HP / o.MaxHP);
//These methods typically have delegate parameters, so lambda expressions are common
*//*

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
public record Player(int ID, string UserName, string TeamColor);*/

//================================================
//              The Three Lenses
//================================================
/*
Lennik gives you the following array of positive numbers: [1, 9, 2, 8, 3, 7, 4, 6, 5]. He asks you to make a new collection from this data where:
• All the odd numbers are filtered out, and only the even should be considered.
• The numbers are in order.
• The numbers are doubled.
For example, with the array above, the odd/even filter should result in 2, 8, 4, 6. The ordering step should
result in 2, 4, 6, 8. The doubling step should result in 4, 8, 12, 16 as the final answer.
Objectives:
• Write a method that will take an int[] as input and produce an IEnumerable<int> (it could be
a list or array if you want) that meets all three of the conditions above using only procedural code—
if statements, switches, and loops. Hint: the static Array.Sort method might be a useful tool
here.
• Write a method that will take an int[] as input and produce an IEnumerable<int> that meets
the three above conditions using a keyword-based query expression (from x, where x, select x,
etc.).
• Write a method that will take an int[] as input and produce an IEnumerable<int> that meets
the three above conditions using a method-call-based query expression. (x.Select(n => n + 1),
x.Where(n => n < 0), etc.)
• Run all three methods and display the results to ensure they all produce good answers.
 */

int[] numbers = new int[] { 1, 9, 2, 8, 3, 7, 4, 6, 5 };

DoubleEvensProcedural(numbers);
Console.WriteLine();
DoubleEvensKeyword(numbers);
Console.WriteLine();
DoubleEvensMethodCall(numbers);

IEnumerable<int> DoubleEvensProcedural(int[] array)
{
    Array.Sort(array);
    List<int> result = new List<int>();
    
    foreach (int i in array)
        if (i % 2 == 0)
        {
            result.Add(i * 2);
        }

    Console.WriteLine("Procedural: ");
    foreach (var n in result)
    {
        Console.WriteLine(n);
    }
    return result;
}


IEnumerable<int> DoubleEvensKeyword(int[] array)
{
    var evenNumbers = from n in array
                      where n % 2 == 0
                      orderby n
                      select n * 2;
    List<int> result = evenNumbers.ToList();

    Console.WriteLine("Keyword: ");
    foreach (var n in result)
    {
        Console.WriteLine(n);
    }
    return result;
}

IEnumerable<int> DoubleEvensMethodCall(int[] array)
{
    var evenNumbers = array
        .Where(n => n % 2 == 0)
        .OrderBy(n => n)
        .Select(n => n * 2)
        .ToList();

    Console.WriteLine("Method-Call: ");
    foreach (var n in evenNumbers)
    {
        Console.WriteLine(n);
    }
    return evenNumbers;
}
