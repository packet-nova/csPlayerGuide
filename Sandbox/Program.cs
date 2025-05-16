//Weapon weapon = new("Axe", 5, 10, Rarity.Common, 5, WeaponType.Axe);
//Character character = new("Jim", 1, 100);
//character.Inventory.Add(weapon);

//character.DisplayInventory();


Song bohemianRhapsody = new("Bohemian Rhapsody", "Queen");
Console.WriteLine($"Title: {bohemianRhapsody.Title}");
Console.WriteLine($"Artist: {bohemianRhapsody.Artist}");
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
public class Song
{
    public string Title { get; }
    public string Artist { get; }
    public Song(string title, string artist)
    {
        Title = title;
        Artist = artist;
    }
}

public enum Rarity { Common, Uncommon, Rare, Epic }
public enum WeaponType { Axe, Sword }