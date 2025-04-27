// Have player pick a symbol (X or O)
// Ask player where they want to place a mark
// End game if all 9 squares are occupied with no winner (draw)
// Render the game board after each player turn
// Detect and display when a player has won
// How to display player symbol? Ma
// Player cannot place symbol in square if already occupied

char[,] symbols = new char[3, 3] { { 'X', 'O', ' ' }, { 'X', 'O', ' ' }, { 'X', 'O', ' ' } };
symbols[0, 0] = 'A';

Console.WriteLine($" {symbols[0, 0]} | {symbols[0, 0]} | {symbols[0, 0]} ");
Console.WriteLine("---+---+---");
Console.WriteLine($" {symbols[0, 0]} | {symbols[0, 0]} | {symbols[0, 0]} ");
Console.WriteLine("---+---+---");
Console.WriteLine($" {symbols[0, 0]} | {symbols[0, 0]} | {symbols[0, 0]} ");

public class Player
{
    char _playerSymbol { get; set; }
}


public class BoardState
{

}