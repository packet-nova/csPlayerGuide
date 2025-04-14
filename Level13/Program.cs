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
//The Dominion of Kings (chapter 7)

var estatePointValue = 1;
var duchyPointValue = 3;
var provincePointValue = 6;

string[] cardTypes = new string[3] {$"Estate - {estatePointValue}", $"Duchy - {duchyPointValue}", $"Province - {provincePointValue}" };

GetCardValues();

Console.WriteLine("How many estates do you own?");
var totalEstates = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("How many duchies do you own?");
var totalDuchies = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("How many provinces do you own?");
var totalProvinces = Convert.ToInt32(Console.ReadLine());

var estatePoints = estatePointValue * totalEstates;
var duchyPoints = duchyPointValue * totalDuchies;
var provincesPoints = provincePointValue * totalProvinces;

int intKingdomValue = GetKingdomIntValue();

var totalKingdomValue = estatePoints + duchyPoints + provincesPoints;
//Console.WriteLine($"The value of your kingdom is {totalKingdomValue}.");

Console.WriteLine($"Using return int method: Your kingdom's value is {intKingdomValue}.");
GetKingdomValue();

// Get total kingdom value
void GetKingdomValue()
{
    var totalKingdomValue = estatePoints + duchyPoints + provincesPoints;
    Console.WriteLine($"Using void method: Your kingdom's value is {totalKingdomValue}.");
}

// Get total kingdom value but returning value
int GetKingdomIntValue()
{
    var totalKingdomValue = estatePoints + duchyPoints + provincesPoints;
    return totalKingdomValue;
}

void GetCardValues()
{
    foreach (var cardType in cardTypes)
    {
        Console.WriteLine(cardType);
    }
}