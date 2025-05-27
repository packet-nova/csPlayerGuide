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

TestEnum.

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