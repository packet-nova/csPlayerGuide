var foodInfo = GetFoodInfo(FoodType.Gumbo, Ingredient.Chicken, Seasoning.Spicy);
Console.WriteLine($"{foodInfo.seasoning} {foodInfo.ingredient} {foodInfo.food}");
Console.WriteLine(FoodType.Gumbo);


//testing
string soup = FoodType.Soup.ToString().ToLower();
Console.WriteLine(soup);

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