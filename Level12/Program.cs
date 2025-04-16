// ===========================================================
// The Replicator of D'To
// ===========================================================
/*
Console.Title = "The Replicator of D'To";

int[] array1 = new int[5];
int[] array2 = new int[5];

for  (int index = 0; index < array1.Length; index++)
{
    Console.Write($"Enter a number. You've entered {index} numbers out of {array1.Length}: ");
    array1[index] = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine($"{array1[index]} has been added.");
}

for (int index = 0; index < array1.Length; index++)
{
    array2[index] = array1[index];
}

Console.WriteLine();
Console.WriteLine($"Array 1 Values\t\tArray 2 Values");
Console.WriteLine($"{array1[0]}\t\t\t{array2[0]}");
Console.WriteLine($"{array1[1]}\t\t\t{array2[1]}");
Console.WriteLine($"{array1[2]}\t\t\t{array2[2]}");
Console.WriteLine($"{array1[3]}\t\t\t{array2[3]}");
Console.WriteLine($"{array1[4]}\t\t\t{array2[4]}");
*/

// ===========================================================
// The Laws of Freach
// ===========================================================
/*
Console.Title = "The Laws of Freach";
Console.ForegroundColor = ConsoleColor.Yellow;

int[] array1 = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };

int currentSmallest = int.MaxValue;
int total = 0;


// Sum of array integers
foreach (int number in array1)
{
    total += number;
}

// Calculate the average in the array
foreach (int number in array1)
{
    if (number < currentSmallest)
    {
        currentSmallest = number;
    }
    Console.WriteLine(number);
}

float average = (float)total / array1.Length;

Console.WriteLine($"\nThe smallest number is {currentSmallest}.");
Console.WriteLine($"The total is {total}.");
Console.WriteLine($"The average is {average}.");
Console.ResetColor();
*/