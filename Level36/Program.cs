Console.WriteLine(Double(20));




int SubtractOne(int number) => number - 1;
int Double(int number) => number * 2;
int AddOne(int number) => number + 1;

ChangeArrayElements(new int[] { 1, 2, 3, 4, 5 }, AddOne);

int[] ChangeArrayElements(int[] numbers, NumberDelegate operation) {}
public delegate int NumberDelegate(int number);


