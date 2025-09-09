using Level52TheFinalBattle.BattleEntities;

Console.Title = "The Final Battle";

TrueProgrammer trueProgrammer = new(CreateTrueProgrammer());

Console.WriteLine("What type of game do you want to play?");
Console.WriteLine("1. Player vs. Computer");
Console.WriteLine("2. Player vs. Player");
Console.WriteLine("3. Computer vs. Computer");
Console.Write("Choice: ");
int.TryParse(Console.ReadLine(), out int userChoice);

Player p1;
Player p2;

switch (userChoice)
{
    case 1:
        p1 = new HumanPlayer();
        p2 = new ComputerPlayer();
        Console.WriteLine("You chose Player vs. Computer");
        break;
    case 2:
        p1 = new HumanPlayer();
        p2 = new HumanPlayer();
        Console.WriteLine("You chose Player vs. Player");
        break;
    case 3:
        p1 = new ComputerPlayer();
        p2 = new ComputerPlayer();
        Console.WriteLine("You chose Computer vs. Computer");
        break;
    default:
        Console.WriteLine("Invalid choice. Default to Player vs. Computer.");
        p1 = new HumanPlayer();
        p2 = new ComputerPlayer();
        break;
}

Game game = new(trueProgrammer, p1, p2);

Console.Write("Press a key to begin!");
Console.ReadKey();
Console.Clear();

game.Run();

string CreateTrueProgrammer()
{
    string? name;
    do
    {
        Console.Write("What is the True Programmer's name? ");
        name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("A valid name is required. It cannot be blank.");
        }
    }
    while (string.IsNullOrEmpty(name));

    return name;
}
