/*
Task<int> AddOnEuropa(int a, int b)
{
    Task<int> task = new Task<int>(() =>
    {
        Thread.Sleep(3000);
        return a + b;
    });
    task.Start();
    return task;
}
*/


Task<int> additionTask = AddOnEuropa(2, 3);
Task addAndDisplay = additionTask.ContinueWith(t => Console.WriteLine(t.Result));

additionTask.Wait();
int result = additionTask.Result;
Console.WriteLine(result);

Task<int> AddOnEuropa(int a, int b)
{
    return Task.Run(() =>
    {
        Thread.Sleep(3000);
        return a + b;
    });
}

