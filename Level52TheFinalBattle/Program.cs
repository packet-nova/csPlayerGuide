Player humanPlayer = new(PlayerType.Human);
Player computerPlayer = new(PlayerType.Computer);
Player computerPlayer2 = new(PlayerType.Computer);
TrueProgrammer trueProgrammer = new(CreateTrueProgrammer());

Game game = new(trueProgrammer, humanPlayer, computerPlayer);

game.Run();

string CreateTrueProgrammer()
{
    Console.Write("What is the True Programmer's name? ");
    return Console.ReadLine();
}


