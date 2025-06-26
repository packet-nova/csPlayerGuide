public class Game
{
    public Player CurrentPlayer { get; private set; }
    public bool IsGameOver { get; private set; }
    public List<int> PickedNumbers { get; private set; }
    public Player P1;
    public Player P2;

    private int cookie;

    public Game()
    {
        PickedNumbers = new();
        P1 = new("Player 1");
        P2 = new("Player 2");
        CurrentPlayer = P1;
        Random random = new();
        cookie = random.Next(10);
    }

    public void Run()
    {
        while (!IsGameOver)
        {
            try
            {
                AskForNumber();
            }
            catch (FormatException)
            {
                Console.WriteLine("It needs to be a number.");
            }
            CurrentPlayer = CurrentPlayer == P1 ? P2 : P1;
        }
    }

    public int AskForNumber()
    {
        Console.Write($"{CurrentPlayer.Name} - Pick a number between 0 and 9: ");
        int intChoice = int.Parse(Console.ReadLine());

        if (PickedNumbers.Contains(intChoice))
        {
            Console.WriteLine($"{intChoice} has already been used. Try another.");
        }

        else if (intChoice < 0 || intChoice > 9)
        {
            Console.WriteLine("Number must be between 0 and 9.");
        }

        else if (intChoice == cookie)
        {
            IsGameOver = true;
            Console.WriteLine($"You ate the oatmeal raisin cookie. You lose!");
        }

        else
        {
            PickedNumbers.Add(intChoice);
        }
        return intChoice;
    }
}