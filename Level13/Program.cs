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

Console.Title = "Dominion of Kings";
Console.ForegroundColor = ConsoleColor.Cyan;

var estatePointValue = 1;
var duchyPointValue = 3;
var provincePointValue = 6;

// you can use this new "collection expression" syntax to make initializing arrays easier
string[] cardTypes = [
    // style points - I like to put each element of the array on its own line to be a bit more tidy
    $"Estate - {estatePointValue}", 
    $"Duchy - {duchyPointValue}", 
    $"Province - {provincePointValue}"
];

// changed the name of this method to be a bit more clear
// because generally I'm going to expect any function named "Get___" to return a value
PrintCardValues();

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

// since the `text` parameter of the `BuyCards` function
// was only used to print this line, I moved it out here.
// A good goal is to always try making our functions efficient,
// doing one thing and doing it well. It's known as the "single responsibility principle" 
Console.WriteLine("What card do you want to buy? ");
BuyCards(1, 10);

// Get total kingdom value but returning value
int GetKingdomValue(int estatePoints, int duchyPoints, int provincesPoints)
{
    return estatePoints + duchyPoints + provincesPoints;
}

void PrintCardValues()
{
    foreach (var cardType in cardTypes)
    {
        Console.WriteLine(cardType);
    }
}

void BuyCards(int min, int max)
{
    // another common preference is to prefix booleans with "is"
    bool isValidChoice = false;
    string choice = "";

    while (!isValidChoice)
    {
        PrintCardValues();
        choice = Console.ReadLine().Trim().ToLower();

        // another nice syntax change I personally prefer instead of
        // comparing the variable against each possible value with the `||` operator...
        // just reads a bit easier, more like our natural language
        
        // an alternative might also be to use an array of acceptable values and compare the input, like this:
        // string[] allowedChoices = ["estate", "duchy", "province"];
        // if (allowedChoices.Contains(choice)) {
        //     validChoice = true;
        // }
        
        // I also tend to prefer assigning the value like this instead of inside the `if` block
        isValidChoice = choice is "estate" or "duchy" or "province";
        
        if (!isValidChoice)
        {
            // here's an example of where that array of `allowedChoices` could be handy.
            // instead of repeating ourselves (and potentially misspelling or accidentally omitting an option)
            // we could re-use that `allowedChoices` array to say:
            // Console.WriteLine($"Incorrect option. Please choose one of: '{string.Join("', '", allowedChoices)}'");
            Console.WriteLine("Incorrect option. Please choose 'estate', 'duchy', or 'province'.");
        }
    }

    bool isValidCount = false;
    int choiceCount = 0;

    while (!isValidCount)
    {
        Console.WriteLine($"How many? Choose between {min} and {max}: ");
        
        // same recommendation here to assign the value like this instead of inside the `if` block: 
        isValidCount = int.TryParse(Console.ReadLine(), out choiceCount) &&
                       // I also tend to prefer putting each condition on its own line
                       choiceCount >= min && 
                       choiceCount <= max;
        
        // another syntax choice that I sometimes like better...
        // sometimes it can be easy to miss the `!` negation at the beginning,
        // reading it this way makes it more obvious we're checking for the `false` condition.
        
        // Though normally I would try to avoid this entirely by flipping the logic so that my
        // `if` statements are always checking for a `true` condition. So this would become `isInvalidCount`
        if (isValidCount is false)
        {
            Console.WriteLine("You've entered an invalid number. Try again.");
        }
    }
    
    // I find multiple if statements to be so ugly :) let's make it a switch!
    switch (choice)
    {
        case "estate":
            totalEstates += choiceCount;
            break;
        
        case "duchy":
            totalDuchies += choiceCount;
            break;
        
        case "province":
            totalProvinces += choiceCount;
            break;
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