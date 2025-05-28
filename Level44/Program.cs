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

Task<int> AddOnEuropa(int a, int b)
{
    return Task.Run(() =>
    {
        Thread.Sleep(3000);
        return a + b;
    });
}

