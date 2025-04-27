// Have player pick a symbol (X or O)
// Ask player where they want to place a mark
// End game if all 9 squares are occupied with no winner (draw)
// Render the game board after each player turn
// Detect and display when a player has won
// How to display player symbol? Ma
// Player cannot place symbol in square if already occupied

/*char[,] symbols = new char[3, 3] { { 'X', 'O', ' ' }, { 'X', 'O', ' ' }, { 'X', 'O', ' ' } };
symbols[0, 0] = 'A';
*/



Board board = new Board();
Player p1 = new(CellType.X);
Player p2 = new(CellType.O);
Renderer renderer = new Renderer();

TicTacToeGame game = new(p1, p2, board, renderer);
game.Run();


public class TicTacToeGame
{
    public Board Board { get; }
    public Player CurrentPlayer { get; private set; }

    private readonly Player _p1;
    private readonly Player _p2;
    private readonly Renderer _renderer;

    public TicTacToeGame(Player p1, Player p2, Board board, Renderer renderer)
    {
        Board = board;
        _p1 = p1;
        _p2 = p2;
        CurrentPlayer = _p1;
        _renderer = renderer;
    }
    public void Run()
    {
        while (!IsGameOver())
        {
            _renderer.Draw(this);
            var location = CurrentPlayer.PickLocation(Board);
            Board.SetCellAt(location.Row, location.Column, CurrentPlayer.CellType);
            CurrentPlayer = CurrentPlayer == _p1 ? _p2 : _p1;
        }
        _renderer.Draw(this);
        if (IsDraw(Board)) Console.WriteLine("The game is a draw.");
        else if (HasWon(Board, _p1.CellType)) Console.WriteLine($"{_p1.CellType} won!");
        else if (HasWon(Board, _p2.CellType)) Console.WriteLine($"{_p2.CellType} won!");
    }

    private bool IsGameOver()
    {
        if (HasWon(Board, CellType.X)) return true;
        if (HasWon(Board, CellType.O)) return true;
        if (IsDraw(Board)) return true;
        return false;
    }

    private bool HasWon(Board board, CellType cellType)
    {
        if (AreSame(cellType, board.GetCellAt(0, 0), board.GetCellAt(0, 1), board.GetCellAt(0, 2))) return true;
        if (AreSame(cellType, board.GetCellAt(1, 0), board.GetCellAt(1, 1), board.GetCellAt(1, 2))) return true;
        if (AreSame(cellType, board.GetCellAt(2, 0), board.GetCellAt(2, 1), board.GetCellAt(2, 2))) return true;

        if (AreSame(cellType, board.GetCellAt(0, 0), board.GetCellAt(1, 0), board.GetCellAt(2, 0))) return true;
        if (AreSame(cellType, board.GetCellAt(0, 1), board.GetCellAt(1, 1), board.GetCellAt(2, 1))) return true;
        if (AreSame(cellType, board.GetCellAt(0, 2), board.GetCellAt(1, 2), board.GetCellAt(2, 2))) return true;

        if (AreSame(cellType, board.GetCellAt(0, 0), board.GetCellAt(1, 1), board.GetCellAt(2, 2))) return true;
        if (AreSame(cellType, board.GetCellAt(0, 2), board.GetCellAt(1, 1), board.GetCellAt(2, 0))) return true;

        return false;
    }

    private bool AreSame(CellType a, CellType b, CellType c, CellType d)
    {
        if (a == b && a ==c && a == d) return true;
        return false;
    }

    private bool IsDraw(Board board)
    {
        for (int row = 0; row < 3; row++)
            for (int column = 0; column < 3; column++)
                if (board.GetCellAt(row, column) == CellType.Empty)
                    return false;
        return true;
    }
}

public class Player
{
    public CellType CellType { get; }
    
    public Player(CellType cellType)
    {
        CellType = cellType;
    }

    public Location PickLocation(Board board)
    {
        while (true)
        {
            Console.WriteLine("What square do you want to play in? ");
            Console.WriteLine();
            int locationNumber = Convert.ToInt32(Console.ReadLine());
            Location location = locationNumber switch
            {
                1 => new Location(2, 0),
                2 => new Location(2, 1),
                3 => new Location(2, 2),
                4 => new Location(1, 0),
                5 => new Location(1, 1),
                6 => new Location(1, 2),
                7 => new Location(0, 0),
                8 => new Location(0, 1),
                9 => new Location(0, 2)
            };
            
            if (!board.IsOccupied(location)) return location;
            
            Console.WriteLine("That spot is already taken.");
        }
    }
}

public class Location
{
    public int Row { get; }
    public int Column { get; }
    public Location(int row, int column)
    {
        Row = row;
        Column = column;
    }
}

public class Renderer
{
    public void Draw(TicTacToeGame game)
    {
        Board board = game.Board;

        Console.WriteLine($"It is {ToChar(game.CurrentPlayer.CellType)}'s turn.");
        Console.WriteLine();
        Console.WriteLine($" {ToChar(board.GetCellAt(0, 0))} | {ToChar(board.GetCellAt(0, 1))} | {ToChar(board.GetCellAt(0, 2))}");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {ToChar(board.GetCellAt(1, 0))} | {ToChar(board.GetCellAt(1, 1))} | {ToChar(board.GetCellAt(1, 2))}");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {ToChar(board.GetCellAt(2, 0))} | {ToChar(board.GetCellAt(2, 1))} | {ToChar(board.GetCellAt(2, 2))}");
        Console.WriteLine();
    }

    private char ToChar(CellType cellType) => cellType switch
    {
        CellType.Empty => ' ',
        CellType.X => 'X',
        CellType.O => 'O',
        _ => '?'
    };
}

public class Board
{
    private readonly CellType[,] _cells = new CellType[3, 3]; //2-D array of enum CellType

    public CellType GetCellAt(int row, int column) => _cells[row, column]; // return value inside the cell
    public bool SetCellAt(int row, int column, CellType cellType) // set the value inside a cell
    {
        if (_cells[row, column] != CellType.Empty) return false;
        _cells[row, column] = cellType;
        return true;
    }
    
    public bool IsOccupied(Location location) => _cells[location.Row, location.Column] != CellType.Empty;
}

public enum CellType { Empty, X, O }