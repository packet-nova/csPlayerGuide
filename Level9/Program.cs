/* General Notes
string userInputScore = Console.ReadLine();
int score = Convert.ToInt32(userInputScore);
char grade = '?';

if  (score == 100)
{
    grade = 'A';
    Console.WriteLine("perfect score!");
}
else
{
    Console.WriteLine("Your score was not perfect.");
    string gradeString = grade.ToString();
    gradeString = "Not an A.";
    Console.WriteLine(gradeString);
}

Console.WriteLine(grade);
*/



// Repairing the Clocktower
// If number is even, clock ticks left
// If number is odd, clock ticks right

/*
Console.Write("Please enter a number: ");
int userInputNumber = Convert.ToInt32(Console.ReadLine());
string pendulumDirection;

if (userInputNumber % 2 == 0)
{
    pendulumDirection = "Tick.";
}
else
{
    pendulumDirection = "Tock.";
}

Console.Write($"Even or odd numbers determine the direction of the pendulum... {pendulumDirection}");
*/

// string hogwartsSchool = Console.WriteLine($"{userInputName} is in Gryffindor.");
// string ravenclaw = Console.WriteLine($"{userInputName} is in Ravenclaw.");
// string hufflepuff = Console.WriteLine($"{userInputName} is in Hufflepuff.");

/* Conditional Operator

Console.Write("What is the score? ");
int userInputScore = Convert.ToInt32(Console.ReadLine());

string evaluatedScore = userInputScore > 70 ? "You passed!" : "You failed.";
Console.WriteLine(evaluatedScore);
*/

/* Watchtower

string enemyDirection = "";

Console.Write("Enter the x-coordinate: ");
int xCoordinate = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter the y-coordinate: ");
int yCoordinate = Convert.ToInt32(Console.ReadLine());

if (xCoordinate > 0)
{
    if (yCoordinate > 0)
    {
        enemyDirection = "is to the northeast";
    }
    else if (yCoordinate == 0)
    {
        enemyDirection = "is to the east";
    }
    else if (yCoordinate < 0)
    {
        enemyDirection = "is to the southeast";
    }
}

else if (xCoordinate == 0)
{
    if (yCoordinate > 0)
    {
        enemyDirection = "is to the north";
    }
    else if (yCoordinate == 0)
    {
        enemyDirection = "is here";
    }
    else if (yCoordinate < 0)
    {
        enemyDirection = "is to the south";
    }
}

else if (xCoordinate < 0)
{
    if (yCoordinate > 0)
    {
        enemyDirection = "is to the northwest";
    }
    else if (yCoordinate == 0)
    {
        enemyDirection = "is to the west";
    }
    else if (yCoordinate < 0)
    {
        enemyDirection = "is to the southwest";
    }
}
Console.WriteLine($"The enemy {enemyDirection}!");
Console.WriteLine();
*/




