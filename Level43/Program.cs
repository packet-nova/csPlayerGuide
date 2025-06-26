//Thread thread1 = new Thread(CountTo100);
//thread1.Start();

//Thread thread2 = new Thread(CountTo100);
//thread2.Start();

//thread1.Join();
//thread2.Join();
//Console.WriteLine("Main Thread Done");

//void CountTo100()
//{
//    for (int index = 0; index < 100; index++)
//        Console.WriteLine(index + 1);
//}


/* Sharing Data

MultiplicationProblem problem = new MultiplicationProblem { A = 2, B = 3 };
Thread thread = new Thread(Multiply);
thread.Start(problem);
thread.Join();
Console.WriteLine(problem.Result);
void Multiply(object? obj)
{
    if (obj == null) return; // Nothing to do if it is null.
    MultiplicationProblem problem = (MultiplicationProblem)obj;
    problem.Result = problem.A * problem.B;
}
class MultiplicationProblem
{
    public double A { get; set; }
    public double B { get; set; }
    public double Result { get; set; }
}

 */

/* Locking
 * 
 * SharedData sharedData = new SharedData();
Thread thread = new Thread(sharedData.Increment);
thread.Start();
sharedData.Increment();
thread.Join();
Console.WriteLine(sharedData.Number);
class SharedData
{
    private readonly object _numberLock = new object();
    private int _number;
    public int Number
    {
        get
        {
            lock (_numberLock)
            {
                return _number;
            }
        }
    }
    public void Increment()
    {
        lock (_numberLock)
    {
            _number++;
        }
    }
}
*/


/*
 Objectives:
• Make a RecentNumbers class that holds at least the two most recent numbers.
• Make a method that loops forever, generating random numbers from 0 to 9 once a second. Hint:
Thread.Sleep can help you wait.
• Write the numbers to the console window, put the generated numbers in a RecentNumbers object,
and update it as new numbers are generated.
• Make a thread that runs the above method
• Wait for the user to push a key in a second loop (on the main thread or another new thread). When
the user presses a key, check if the last two numbers are the same. If they are, tell the user that they
correctly identified the repeat. If they are not, indicate that they got it wrong.
• Use lock statements to ensure that only one thread accesses the shared data at a time.
 */

RecentNumbers recent = new();
Thread thread1 = new Thread(recent.GenerateRandom);

Console.WriteLine("Press any key when you see matching numbers.");

thread1.Start();

while (true)
{
    recent.DuplicateCheck();
    Thread.Sleep(100);
}

public class RecentNumbers
{
    private readonly object _numberLock = new object();
    private Random _random = new Random();

    private int _current;
    private int _previous;

    public int Current
    {
        get
        {
            lock (_numberLock)
            {
                return _current;
            }
        }
    }

    public int Previous
    {
        get
        {
            lock (_numberLock)
            {
                return _previous;
            }
        }
    }

    public void GenerateRandom()
    {
        while (true)
        {
            lock (_numberLock)
            {
                _previous = Current;
                _current = _random.Next(10);
            }
            Console.WriteLine($"""
                Previous: {Previous}
                Current:  {Current}
                """);
            Thread.Sleep(1000);
        }
    }

    public void DuplicateCheck()
    {
        Console.ReadLine();
        if (Current == Previous)
        {
            Console.WriteLine("You correctly detected a repeat.");
        }
        else
        {
            Console.WriteLine("This is incorrect.");
        }
    }
}