Console.Write("Enter a word (6 or less characters): ");
string userWord = Console.ReadLine().ToLower().Trim();
await RandomlyRecreateAsync(userWord);

Task<int> RandomlyRecreateAsync(string word)
{
    return Task.Run(() =>
    {
        int attempts = 0;
        string randomWord;
        Random random = new Random();

        DateTime startTime = DateTime.Now;
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

        DateTime endTime = DateTime.Now;
        TimeSpan timeSpan = endTime - startTime;
        Console.WriteLine($"The word '{word}' was generated after {attempts:N0} attempts in {timeSpan} seconds.");

        return attempts;
    });
}