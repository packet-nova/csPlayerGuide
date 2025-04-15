Subtraction(10);

int Subtraction(int number)
{
    if (number < 0)
    {
        return 0;
    }
    Console.WriteLine(number);
    return Subtraction(number - 1);
}