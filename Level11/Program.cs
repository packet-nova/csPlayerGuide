/* while loops
int x = 1;
while (x <= 5)
{
    Console.WriteLine(x);
    x++;
}  
*/

/* do/while loop
int playersNumber;

do
{
    Console.WriteLine("Enter a number between 0 and 10: ");
    string playerResponse = Console.ReadLine();
    playersNumber = Convert.ToInt32(playerResponse);
}
while (playersNumber < 0 || playersNumber > 10);
*/

/* for loops
for (int x = 1; x <= 5; x++)
{
    Console.WriteLine(x);
}
*/

// The Prototype
/*
int number;
int guess;

do
{
    Console.Write("User 1, enter a number between 0 and 100: ");
    number = Convert.ToInt32(Console.ReadLine());
}
while (number < 0 || number > 100);

Console.Clear();

do
{
    Console.Write("User 2, guess the number between 0 and 100: ");
    guess = Convert.ToInt32(Console.ReadLine());
    if (guess == number)
    {
        Console.WriteLine($"{guess} is correct!");
    }
    else if (guess < number)
    {
        Console.WriteLine($"{guess} is too low. Try again.\n");
    }
    else if (guess > number)
    {
        Console.WriteLine($"{guess} is too high. Try again.\n");
    }
}
while (guess != number);
*/

// The Magic Cannon

Console.Title = "The Magic Cannon";

string cannonType = "";
int cannonDamage = 0;
int baseCannonDamage = 1;
int totalCannonDamage = 0;

for (int crankTurns = 1; crankTurns <= 45; crankTurns++)
{
    if ((crankTurns % 3 == 0) && (crankTurns % 5 == 0))
    {
        cannonDamage = baseCannonDamage + 9;
        Console.ForegroundColor = ConsoleColor.Magenta;
        cannonType = "Plasma Blast";
    }
    else if (crankTurns % 3 == 0)
    {
        cannonDamage = baseCannonDamage + 2;
        Console.ForegroundColor = ConsoleColor.Red;
        cannonType = "Fire";
    }
    else if (crankTurns % 5 == 0)
    {
        cannonDamage = baseCannonDamage + 4;
        Console.ForegroundColor = ConsoleColor.Blue;
        cannonType = "Electric";
    }
    else
    {
        cannonDamage = baseCannonDamage;
        Console.ForegroundColor = ConsoleColor.Gray;
        cannonType = "Normal";
    }
    if (cannonType == "Plasma Blast")
    {
        Console.WriteLine($"{crankTurns}: {cannonType} cannon hits for {cannonDamage} damage!".ToUpper());
    }
    else
    {
        Console.WriteLine($"{crankTurns}: {cannonType} cannon hits for {cannonDamage} damage.");
    }
    totalCannonDamage += cannonDamage;
}
Console.ForegroundColor = ConsoleColor.White;

Console.WriteLine($"There was a total of {totalCannonDamage} damage done!");




