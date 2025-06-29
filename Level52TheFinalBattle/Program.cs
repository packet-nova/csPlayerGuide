HumanPlayer p1 = new();
ComputerPlayer p2 = new();
TrueProgrammer trueProgrammer = new(CreateTrueProgrammer());

Game game = new(trueProgrammer, p1, p2);

game.Run();

string CreateTrueProgrammer()
{
    Console.Write("What is the True Programmer's name? ");
    return Console.ReadLine();
}
