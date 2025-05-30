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

//Task<int> AddOnEuropa(int a, int b)
//{
//    return Task.Run(() =>
//    {
//        Thread.Sleep(3000);
//        return a + b;
//    });
//}

//async Task DoWork()
//{
//    int result = await AddOnEuropa(2, 3);
//    Console.WriteLine(result);
//}

/*
 Objectives:
• Make the method int RandomlyRecreate(string word). It should take the string’s length and
generate an equal number of random characters. It is okay to assume all words only use lowercase
letters. One way to randomly generate a lowercase letter is (char)('a' + random.Next(26)).
This method should loop until it randomly generates the target word, counting the required
attempts. The return value is the number of attempts.
• Make the method Task<int> RandomlyRecreateAsync(string word) that schedules the
above method to run asynchronously (Task.Run is one option).
• Have your main method ask the user for a word. Run the RandomlyRecreateAsync method and
await its result and display it. Note: Be careful about long words! For me, a five-letter word took
several seconds, and my math indicates that a 10-letter word may take nearly two years.
• Use DateTime.Now before and after the async task runs to measure the wall clock time it took.
Display the time elapsed (Level 32)
 */

DateTime programStart= DateTime.Now;
Console.WriteLine($"Total Attempts: {(RandomlyCreate("bananas")):N0}");


int RandomlyCreate(string word)
{
    int attempts = 0;
    word = word.ToLower().Trim();
    string randomWord;
    Random random = new Random();

    do
    {
        char[] chars = new char[word.Length];

        for (int i = 0; i < word.Length; i++)
        {
            chars[i] = (char)('a' + random.Next(26));
        }
        randomWord = new string(chars);
        //Console.WriteLine(randomWord);
        attempts++;
    }

    while (randomWord != word);
    return attempts;
}