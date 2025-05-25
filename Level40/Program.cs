/*
 The island of Pattren is home to skilled potion masters in need of some help. Potions are mixed by adding
one ingredient at a time until they produce a valuable potion type. The potion masters will give you the
Patterned Medallion if you help them make a program to build potions according to the rules below:
• All potions start as water.
• Adding stardust to water turns it into an elixir.
• Adding snake venom to an elixir turns it into a poison potion.
• Adding dragon breath to an elixir turns it into a flying potion.
• Adding shadow glass to an elixir turns it into an invisibility potion.
• Adding an eyeshine gem to an elixir turns it into a night sight potion.
• Adding shadow glass to a night sight potion turns it into a cloudy brew.
• Adding an eyeshine gem to an invisibility potion turns it into a cloudy brew.
• Adding stardust to a cloudy brew turns it into a wraith potion.
• Anything else results in a ruined potion.

Objectives:
• Create enumerations for the potion and ingredient types.
• Tell the user what type of potion they currently have and what ingredient choices are available.
• Allow them to enter an ingredient choice. Use a pattern to turn the user’s response into an
ingredient.
• Change the current potion type according to the rules above using a pattern.
• Allow them to choose whether to complete the potion or continue before adding an ingredient. If
the user decides to complete the potion, end the program.
• When the user creates a ruined potion, tell them and start over with water.
 */

Potion potion = Potion.Water;

Console.WriteLine($"Your current potion is {potion}");
SelectIngredient();
Console.WriteLine($"Your potion is now {potion}");



//Console.WriteLine("Which ingredients do you want to add?");
//Ingredient choice = (Ingredient)Enum.Parse<Ingredient>(Console.ReadLine());
//if (choice == Ingredient.Stardust) potion = Potion.Elixir;
//if (choice == Ingredient.LacewingFly) potion = Potion.Polyjuice;



Ingredient SelectIngredient()
{
    PrintIngredients();
    Console.WriteLine("Which ingredients do you want to add?");
    int choice = int.Parse(Console.ReadLine());
    return choice switch
    {
        1 => Ingredient.ShadowGlass,
        _ => Ingredient.Stardust
    };
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

void PrintPotions()
{
    int i = 1;
    foreach (string j in Enum.GetNames<Potion>())
    {
        Console.WriteLine($"{i}. {j}");
        i++;
    }
}


public enum Potion
{
    Water,
    Elixir,
    Poison,
    Flying,
    Invisibility,
    NightSight,
    Wraith,
    CloudyBrew,
    Polyjuice,
    Ruined
}
public enum Ingredient
{
    Stardust,
    SnakeVenom,
    DragonBreath,
    ShadowGlass,
    Eyeshine,
    LacewingFly
}