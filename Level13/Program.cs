//=============================================
/*
CountToTen();
CountAscending(20);

void CountToTen()
{
    for (int current = 1; current <= 10; current++)
        Console.WriteLine(current);
}

void CountAscending(int numberToCountTo)
{
    for (int current = 1; current <= numberToCountTo; current++)
        Console.WriteLine(current);
}
*/

//=============================================
// Returning a value from a method
//=============================================
/*
Console.Write("How high should I count? ");
int chosenNumber = ReadNumber();
Count(chosenNumber);

void Count(int numberToCountTo)
{
    for (int current = 1; current <= numberToCountTo; current++)
        Console.WriteLine(current);
}

int ReadNumber()
{
    string input = Console.ReadLine();
    int number = Convert.ToInt32(input);
    return number;
}
*/

//=============================================
// Taking a Number
//=============================================

//Console.WriteLine(AskForNumber());

//int AskForNumber()
//{
//    while (true)
//    {
//        Console.Write("Enter a number between 1 and 100: ");
//        int number = Convert.ToInt32(Console.ReadLine());

//        if (number >= 1 && number <= 100)
//        {
//            return number;
//        }
//        Console.WriteLine("You've entered an invalid number. Try again.");
//    }
//}


// With parameters 
/*
Console.WriteLine(AskForNumber("Enter a number between 1 and 100", 1, 100));
int AskForNumber(string text, int min, int max)
{
    while (true)
    {
        Console.Write($"{text}: ");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number >= 1 && number <= 100)
        {
            return number;
        }
        Console.WriteLine("You've entered an invalid number. Try again.");
    }
}
*/

// Using methods to improve previous programs
// The Dominion of Kings (chapter 7)

var estatePointValue = 1;
var duchyPointValue = 3;
var provincePointValue = 6;

string[] cardTypes = new string[3] { $"Estate - {estatePointValue}", $"Duchy - {duchyPointValue}", $"Province - {provincePointValue}" };

GetCardValues();

Console.WriteLine("How many estates do you own?");
var totalEstates = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("How many duchies do you own?");
var totalDuchies = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("How many provinces do you own?");
var totalProvinces = Convert.ToInt32(Console.ReadLine());

var estatePoints = estatePointValue * totalEstates;
var duchyPoints = duchyPointValue * totalDuchies;
var provincePoints = provincePointValue * totalProvinces;

int totalKingdomValue = GetKingdomValue(estatePoints, duchyPoints, provincePoints);

Console.WriteLine($"Your kingdom's value is {totalKingdomValue}.");

BuyCards("What card do you want to buy? ", 1, 10);

// Get total kingdom value but returning value
int GetKingdomValue(int estatePoints, int duchyPoints, int provincesPoints)
{
    return estatePoints + duchyPoints + provincesPoints;
}

void GetCardValues()
{
    foreach (var cardType in cardTypes)
    {
        Console.WriteLine(cardType);
    }
}

void BuyCards(string text, int min, int max)
{
    bool validChoice = false;
    string choice = "";

    while (!validChoice)
    {
        GetCardValues();
        Console.WriteLine(text);
        choice = Console.ReadLine().Trim().ToLower();

        if (choice == "estate" || choice == "duchy" || choice == "province")
        {
            validChoice = true;  // Exit loop once a valid card type is selected
        }
        else
        {
            Console.WriteLine("Incorrect option. Please choose 'estate', 'duchy', or 'province'.");
        }
    }

    bool validCount = false;
    int choiceCount = 0;

    while (!validCount)
    {
        Console.WriteLine($"How many? Choose between {min} and {max}: ");
        if (int.TryParse(Console.ReadLine(), out choiceCount) && choiceCount >= min && choiceCount <= max)
        {
            validCount = true;
        }
        else
        {
            Console.WriteLine("You've entered an invalid number. Try again.");
        }
    }

    if (choice == "estate")
    {
        totalEstates += choiceCount;
    }
    else if (choice == "duchy")
    {
        totalDuchies += choiceCount;
    }
    else if (choice == "province")
    {
        totalProvinces += choiceCount;
    }

    estatePoints = estatePointValue * totalEstates;
    duchyPoints = duchyPointValue * totalDuchies;
    provincePoints = provincePointValue * totalProvinces;

    totalKingdomValue = GetKingdomValue(estatePoints, duchyPoints, provincePoints);

    Console.WriteLine($"You purchased {choiceCount} {choice}(s).");
    Console.WriteLine($"Your updated totals are: Estates: {totalEstates}, Duchies: {totalDuchies}, Provinces: {totalProvinces}.");
    Console.WriteLine($"Your kingdom's value is: {totalKingdomValue}.");
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();