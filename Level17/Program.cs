//CookFood(FoodType.Soup, Ingredient.Mushroom, Seasoning.Salty);


CookFood(FoodType.Gumbo, Ingredient.Potato, Seasoning.Spicy);

void CookFood(FoodType food, Ingredient ingredient, Seasoning seasoning)
{
    Console.WriteLine($"You cooked a {seasoning} {ingredient} {food}.");
}


enum FoodType { Soup, Stew, Gumbo };
enum Ingredient { Mushroom, Chicken, Carrot, Potato };
enum Seasoning { Spicy, Salty, Sweet};
