using Level52TheFinalBattle.BattleEntities;

TrueProgrammer trueProgrammer = new(CreateTrueProgrammer());

Console.WriteLine("What type of game do you want to play?");
Console.WriteLine("1. Player vs. Computer");
Console.WriteLine("2. Player vs. Player");
Console.WriteLine("3. Computer vs. Computer");
Console.Write("Choice: ");
int userChoice = Convert.ToInt32(Console.ReadLine());

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

game.Run();

string CreateTrueProgrammer()
{
    Console.Write("What is the True Programmer's name? ");
    string? name = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(name))
    {
        throw new InvalidOperationException("Name cannot be null or empty.");
    }
    return name;
}
