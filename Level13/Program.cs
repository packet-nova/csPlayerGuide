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

