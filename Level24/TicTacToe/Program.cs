// Have player pick a symbol (X or O)
// Ask player where they want to place a mark
// End game if all 9 squares are occupied with no winner (draw)
// Render the game board after each player turn
// Detect and display when a player has won
// How to display player symbol? Ma
// Player cannot place symbol in square if already occupied

/*char[,] symbols = new char[3, 3] { { 'X', 'O', ' ' }, { 'X', 'O', ' ' }, { 'X', 'O', ' ' } };
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
*/

Board board = new Board();

Console.WriteLine(board.GetCellAt(2,2));

public class Board
{
    private readonly CellType[,] _cells = new CellType[3, 3]; //2-D array of enum CellType

    public CellType GetCellAt(int row, int column) => _cells[row, column]; // return value inside the cell
    public void SetCellAt(int row, int column, CellType cellType) // set the value inside a cell
    {
        if (_cells[row, column] != CellType.Empty) return;
        _cells[row, column] = cellType;
    }
}

public enum CellType { Empty, X, O }