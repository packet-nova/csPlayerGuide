//Console.Write("What do you want me to tell you next time? ");
//string? message = Console.ReadLine();
//File.WriteAllText("Message.txt", message);

//string previous = File.ReadAllText("Message.txt");
//Console.WriteLine("Last time, you said this: " + previous);

//Console.Write("What do you want me to tell you next time? ");
//string? message = Console.ReadLine();
//File.WriteAllText("Message.txt", message);

// For reading
//FileStream stream = File.Open("Settings.txt", FileMode.Open);
//StreamReader reader = new StreamReader(stream);
//while (!reader.EndOfStream)
//    Console.WriteLine(reader.ReadLine());
//reader.Close();


// For writing
//FileStream stream = File.Open("Settings.txt", FileMode.Create);
//StreamWriter writer = new StreamWriter(stream);
//writer.Write("IsFullScreen=");
//writer.WriteLine(true);
//writer.Close();


//SaveScores(MakeDefaultScores());
//void SaveScores(List<Score> scores)
//{
//    List<string> scoreStrings = new List<string>();
//    foreach (Score score in scores)
//        scoreStrings.Add($"{score.Name},{score.Points},{score.Level}");
//    File.WriteAllLines("Scores.csv", scoreStrings);
//}

//List<Score> MakeDefaultScores()
//{
//    return new List<Score>()
//    {
//        new Score("R2-D2", 12420, 15),
//        new Score("C-3PO", 8543, 9),
//        new Score("GONK", -1, 1)
//    };
//}

//public record Score(string Name, int Points, int Level);
//==================================================================================================
/*
 Objectives:
• When the program starts, ask the user to enter their name.
• By default, the player starts with a score of 0.
• Add 1 point to their score for every keypress they make.
• Display the player’s updated score after each keypress.
• When the player presses the Enter key, end the game. Hint: the following code reads a keypress and
checks whether it was the Enter key: Console.ReadKey().Key == ConsoleKey.Enter
• When the player presses Enter, save their score in a file. Hint: Consider saving this to a file named
[username].txt. For this challenge, you can assume the user doesn’t enter a name that would produce
an illegal file name (such as *).
• When a user enters a name at the start, if they already have a previously saved score, start with that
score instead.
 */

Player player = new(GetPlayerName());

if (File.Exists($"{player.Name}.txt"))
{
    player.Score = int.Parse(File.ReadAllText($"{player.Name}.txt"));
}
Console.WriteLine($"Score: {player.Score}");

while (true)
{
    if (Console.ReadKey().Key == ConsoleKey.Enter)
    {
        File.WriteAllText($"{player.Name}.txt", player.Score.ToString());
        break;
    }
    player.Score++;
    Console.Clear();
    Console.WriteLine($"Score: {player.Score}");
}
string GetPlayerName()
{
    Console.WriteLine("What is your name?");
    Console.Write("Name: ");
    string name = Console.ReadLine().Trim();
    return name;
}

public class Player
{
    public string Name { get; init; }
    public int Score { get; set; }

    public Player(string name)
    {
        Name = name;
    }
}