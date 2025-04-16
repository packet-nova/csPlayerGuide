Console.Title = "The Replicator of D'To";

int[] arrayNew = new int[5];
int[] arrayOld = new int[5];

Console.WriteLine("Time to fill the array. Please pick 5 numbers. ");
for (int index = 0; index < arrayOld.Length; index++)
{
    Console.Write($"{index + 1} of {arrayOld.Length}: ");
    arrayNew[index] = Convert.ToInt32(Console.ReadLine());
}

for (int transfer = 0; transfer < arrayNew.Length; transfer++)
{
    arrayOld[transfer] = arrayNew[transfer];
}

Console.WriteLine("\nThis is the original array");
for (int i = 0; i < arrayNew.Length; i++) Console.Write($"{arrayNew[i]}, ");

Console.WriteLine("\nThis is the new array ");
for (int i = 0; i < arrayOld.Length; i++) Console.Write($"{arrayOld[i]}, ");

Console.Read();
