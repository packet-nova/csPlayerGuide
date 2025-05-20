//int[] array1 = new[] { 1, 2, 3, 4, 5 };

////foreach (int number in ChangeArrayElements(array1, Double))
////    Console.WriteLine(number);

//int SubtractOne(int number) => number - 1;
//int Double(int number) => number * 2;
//int AddOne(int number) => number + 1;

//ChangeArrayElements(new int[] { 1, 2, 3, 4, 5 }, AddOne);

//int[] ChangeArrayElements(int[] numbers, NumberDelegate operation)
//{
//    int[] result = new int[numbers.Length];

//    for (int index = 0; index < numbers.Length; index++)
//        result[index] = operation(numbers[index]);

//    return result;
//}
//public delegate int NumberDelegate(int number);


//=============================================================================================

Sieve sieve = GetSieveType();

while(true)
{
    Console.Write("Enter number: ");
    int n = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine(sieve.IsGood(n));
}

Sieve GetSieveType()
{
    Console.WriteLine("""
    1. Check for even number
    2. Check for multiple of ten
    3. Check for positive number
    """);
    int choice = Convert.ToInt32(Console.ReadLine());
    return choice switch
    {
        1 => sieve = new(IsEven),
        2 => sieve = new(IsMultipleOfTen),
        3 => sieve = new(IsPositive),
        _ => sieve = new(IsEven)
    };

}
bool IsEven(int number) => number % 2 == 0;
bool IsMultipleOfTen(int number) => number % 10 == 0;
bool IsPositive(int number) => number > 0;

public class Sieve
{
    public Func<int, bool> Operation { get; }
    public Sieve(Func<int, bool> operation)
    {
        Operation = operation;
    }
    public bool IsGood(int number)
    {
        return Operation(number);
    }
}
