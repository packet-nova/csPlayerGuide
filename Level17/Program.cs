Console.WriteLine(GetFoodInfo(Seasoning.Spicy, Ingredient.Mushroom, FoodType.Gumbo));

static (string food, string ingredient, string seasoning) GetFoodInfo(Seasoning seasoning, Ingredient ingredient, FoodType food)
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

enum FoodType
{
    Stew,
    Gumbo,
    Soup
}

enum Ingredient
{
    Carrot,
    Chicken,
    Mushroom,
    Potato
}

enum Seasoning
{
    Spicy,
    Sweet,
    Salty
}