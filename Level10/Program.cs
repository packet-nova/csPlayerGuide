/* Switch statements
Console.WriteLine("Please make a choice:");
Console.WriteLine("1. Option 1");
Console.WriteLine("2. Option 2");
Console.WriteLine("3. Option 3");

Console.Write("Your choice: ");
int choice = Convert.ToInt32(Console.ReadLine());

switch (choice)
{
    case 1:
        Console.WriteLine("You picked Option 1.");
        break;
    case 2:
        Console.WriteLine("You picked option 2.");
        break;
    case 3:
        Console.WriteLine("You picked Option 3.");
        break;
    default:
        Console.WriteLine("You didn't pick a valid option.");
        break;
}
*/


/* Switch expressions
int choice = Convert.ToInt32(Console.ReadLine());

string response = choice switch
{
    1 => "dinosaur",
    2 => "candy",
    3 => "rabbit",
    _ => "not valid."
};

Console.WriteLine(response);
*/

// Buying Inventory

int ropeCost = 10;
int torchCost = 15;
int climbingEquipmentCost = 25;
int cleanWaterCost = 1;
int macheteCost = 20;
int canoeCost = 200;
int foodSupplyCost = 1;

Console.Write("Shopkeeper's Stock:\n1 - Rope\n2 - Torches\n3 - Climbing Equipment\n4 - Clean Water\n5 - Machete\n6 - Canoe\n7 - Food Supplies\n");
Console.Write("Which item number do you want to see the price of? ");
int userInputNumber = Convert.ToInt32(Console.ReadLine());

Console.Write("Oh, sorry. I forgot to ask for your name. What is your first name? ");
string userInputName = Console.ReadLine();

if (userInputName == "Bob")
{
    ropeCost /= 2;
    torchCost /= 2;
    climbingEquipmentCost /= 2;
    cleanWaterCost /= 2;
    macheteCost /= 2;
    canoeCost /= 2;
    foodSupplyCost /= 2;

    Console.WriteLine($"{userInputName}! Welcome back, and thank you for helping me find my pricelist. As a token of gratitude, everything is half off for you!");
}

string shopkeeperResponse = userInputNumber switch
{
    1 => $"Ropes cost {ropeCost} gold.",
    2 => $"Torches cost {torchCost} gold.",
    3 => $"Climbing Equipment costs {climbingEquipmentCost} gold.",
    4 => $"Clean Water costs {cleanWaterCost} gold.",
    5 => $"Machetes cost {macheteCost} gold.",
    6 => $"Canoes cost {canoeCost} gold.",
    7 => $"Food Supplies cost {foodSupplyCost} gold.",
    _ => "Please enter a valid option."
};

Console.WriteLine(shopkeeperResponse);

if (userInputName != "Bob")
{
    Console.WriteLine($"Thanks for stopping by, {userInputName}.");
}
Console.WriteLine();