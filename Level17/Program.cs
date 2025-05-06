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
    Console.WriteLine();
    FoodType food = choice switch
    {
        1 => (FoodType)(0),
        2 => (FoodType)(1),
        3 => (FoodType)(2),
        _ => FoodType.Soup
    };
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
    Console.WriteLine();
    Seasoning seasoning = choice switch
    {
        1 => (Seasoning)(0),
        2 => (Seasoning)(1),
        3 => (Seasoning)(2),
        _ => Seasoning.Spicy
    };
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
    Console.WriteLine();
    Ingredient ingredient = choice switch
    {
        1 => (Ingredient)(0),
        2 => (Ingredient)(1),
        3 => (Ingredient)(2),
        4 => (Ingredient)(3),
        _ => Ingredient.Potato
    };
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