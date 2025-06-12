/*
 Objectives:
• Modify your program from the previous challenge to allow the main thread to keep waiting for the
user to enter more words. 
For every new word entered, create and run a task to compute the attempt
count and the time elapsed and display the result, but then let that run asynchronously while you
wait for the next word. You can generate many words in parallel this way. Hint: Moving the elapsed
time and output logic to another async method may make this easier.
 */

while (true)
{
    ProcessWord(UserInputWord());
}

async Task ProcessWord(string word)
{
    DateTime startTime = DateTime.Now;
    int attempts = await RandomlyRecreateAsync(word);
    DateTime endTime = DateTime.Now;
    TimeSpan elapsedTime = endTime - startTime;
    Console.WriteLine($"The word '{word}' was generated after {attempts:N0} attempts in {elapsedTime} seconds.");
}

string UserInputWord()
{
    Console.Write("Enter a word (6 or less characters): ");
    return Console.ReadLine().ToLower().Trim();
}

async Task<int> RandomlyRecreateAsync(string word)
{
    return await Task.Run(() =>
    {
        int attempts = 0;
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
            attempts++;
        }
        while (randomWord != word);
        return attempts;
    });
}