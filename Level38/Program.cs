Sieve sieve = GetSieveType();

while (true)
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
        1 => new Sieve(n => n % 2 == 0),
        2 => new Sieve(n => n % 10 == 0),
        3 => new Sieve(n => n > 0),
        _ => new Sieve(n => n % 2 == 0),
    };
}

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