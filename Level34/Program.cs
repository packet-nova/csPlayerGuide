Random random = new Random();

for (int i = 0; i < 10; i++)
{
    Console.WriteLine(random.NextDouble(10));
    Console.WriteLine(random.NextString("red", "orange", "yellow", "green", "blue", "indigo"));
    Console.WriteLine(random.CoinClip(90));
    Console.WriteLine();
}
public static class RandomExtension
{
    public static double NextDouble(this Random random, int maxNumber)
    {
        return random.NextDouble() * maxNumber;
    }

    public static string NextString(this Random random, params string[] words)
    {
        int index = random.Next(words.Length);
        return words[index];
    }

    public static bool CoinClip(this Random random, int headsBias = 50)
    {
        bool heads = true;
        bool tails = false;
        {
            return (random.Next(0, 100) < headsBias) ? heads : tails;
        }
    }
}