Potion potion = new();
bool keepBrewing = true;

while (keepBrewing && potion.Kind != PotionType.Ruined)
{
    Console.Write("Do you want to keep brewing your potion? y/N: ");
    
    if (Console.ReadKey().Key == ConsoleKey.Y)
    {
        Console.WriteLine();
        potion.AddIngredient(SelectIngredient());
        if (potion.Kind == PotionType.Ruined)
        {
            Console.WriteLine("Whoops! You ruined your potion. Dumping out the ruined potion and starting with fresh water...");
            potion = new();
            continue;
        }
        Console.WriteLine($"Your potion currently is a(n): {potion.Kind} potion.");
    }
    
    else
    {
        Console.WriteLine();
        Console.WriteLine($"Your finished potion is a(n) {potion.Kind}");
        keepBrewing = false;
    }
}

Ingredient SelectIngredient()
{
    PrintIngredients();
    Console.Write("Which ingredients do you want to add? ");
    int choice = int.Parse(Console.ReadLine());
    Console.WriteLine($"You selected: {(Ingredient)(choice - 1)}");
    return (Ingredient)(choice - 1);
}

void PrintIngredients()
{
    int i = 1;
    foreach (string j in Enum.GetNames<Ingredient>())
    {
        Console.WriteLine($"{i}. {j}");
        i++;
    }
}

public class Potion
{
    public PotionType Kind { get; private set; }
    public Potion()
    {
        Kind = PotionType.Water;
    }
    public PotionType AddIngredient(Ingredient ingredient)
    {
        Console.WriteLine($"Your current potion is {this.Kind}");
        Console.WriteLine($"You've added {ingredient}.");
        return (Kind, ingredient) switch
        {
            (PotionType.Water, Ingredient.Stardust) => this.Kind = PotionType.Elixir,
            (PotionType.Elixir, Ingredient.SnakeVenom) => this.Kind = PotionType.Poison,
            (PotionType.Elixir, Ingredient.DragonBreath) => this.Kind = PotionType.Flying,
            (PotionType.Elixir, Ingredient.ShadowGlass) => this.Kind = PotionType.Invisibility,
            (PotionType.Elixir, Ingredient.Eyeshine) => this.Kind = PotionType.NightSight,
            (PotionType.NightSight, Ingredient.ShadowGlass) => this.Kind = PotionType.CloudyBrew,
            (PotionType.Invisibility, Ingredient.Eyeshine) => this.Kind = PotionType.CloudyBrew,
            (PotionType.CloudyBrew, Ingredient.Stardust) => this.Kind = PotionType.Wraith,
            _ => this.Kind = PotionType.Ruined
        };
    }
}

public enum PotionType
{
    Water,
    Elixir,
    Poison,
    Flying,
    Invisibility,
    NightSight,
    Wraith,
    CloudyBrew,
    Ruined
}
public enum Ingredient
{
    Stardust,
    SnakeVenom,
    DragonBreath,
    ShadowGlass,
    Eyeshine,
}