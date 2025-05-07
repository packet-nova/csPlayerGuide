var cookedDish = GetFoodInfo(ChooseFoodType(), ChooseIngredient(), ChooseSeasoning());
Console.WriteLine($"You cooked a delicious {cookedDish.seasoning} {cookedDish.ingredient} {cookedDish.food}.");

static FoodType ChooseFoodType()
{
    int i = 1;
    
    foreach (string j in Enum.GetNames(typeof(FoodType)))
    {
        Console.WriteLine($"{i}. {j}");
        i++;
    }
    
    Console.Write("Pick a food: ");
    int choice = Convert.ToInt32(Console.ReadLine());
    
    FoodType food = choice switch
    {
        1 => (FoodType)(0),
        2 => (FoodType)(1),
        3 => (FoodType)(2),
        _ => FoodType.Soup
    };
    
    Console.WriteLine($"You selected {food}.");
    Console.WriteLine();
    return food;
}

static Seasoning ChooseSeasoning()
{
    int i = 1;
    
    foreach (string j in Enum.GetNames(typeof(Seasoning)))
    {
        Console.WriteLine($"{i}. {j}");
        i++;
    }
    
    Console.Write("Pick a seasoning: ");
    int choice = Convert.ToInt32(Console.ReadLine());
    
    Seasoning seasoning = choice switch
    {
        1 => (Seasoning)(0),
        2 => (Seasoning)(1),
        3 => (Seasoning)(2),
        _ => Seasoning.Spicy
    };
    
    Console.WriteLine($"You selected {seasoning}.");
    Console.WriteLine();
    return seasoning;
}

static Ingredient ChooseIngredient()
{
    int i = 1;
    
    foreach (string j in Enum.GetNames(typeof(Ingredient)))
    {
        Console.WriteLine($"{i}. {j}");
        i++;
    }
   
    Console.Write("Pick an ingredient: ");
    int choice = Convert.ToInt32(Console.ReadLine());
    
    Ingredient ingredient = choice switch
    {
        1 => (Ingredient)(0),
        2 => (Ingredient)(1),
        3 => (Ingredient)(2),
        4 => (Ingredient)(3),
        _ => Ingredient.Potato
    };

    Console.WriteLine($"You selected {ingredient}.");
    Console.WriteLine();
    return ingredient;
}

static (string food, string ingredient, string seasoning) GetFoodInfo(FoodType food, Ingredient ingredient, Seasoning seasoning)
{
    string foodType = food switch
    {
        FoodType.Stew => "stew",
        FoodType.Gumbo => "gumbo",
        FoodType.Soup => "soup",
        _ => "unknown"
    };
    
    string ingredientType = ingredient switch
    {
        Ingredient.Carrot => "carrot",
        Ingredient.Chicken => "chicken",
        Ingredient.Mushroom => "mushroom",
        Ingredient.Potato => "potato",
        _ => "unknown"
    };
    
    string seasoningType = seasoning switch
    {
        Seasoning.Spicy => "spicy",
        Seasoning.Salty => "salty",
        Seasoning.Sweet => "sweet",
        _ => "unknown"
    };
    
    return (foodType, ingredientType, seasoningType);
}

enum FoodType { Stew, Gumbo, Soup }
enum Ingredient { Carrot, Chicken, Mushroom, Potato }
enum Seasoning { Spicy, Sweet, Salty }