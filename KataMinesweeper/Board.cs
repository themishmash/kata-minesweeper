using System.Linq;

namespace KataMinesweeper
{
    public class Board
    {
        public int Size { get; private set; }
        private Square[,] _boardSquares; 
        
        public Board(int size)
        {
            Size = size;
            CreateBoard();
        }
        
        private void CreateBoard()
        {
            _boardSquares = new Square[Size, Size];
            for (var x = 0; x < Size; x++)
            {
                for (var y = 0; y < Size; y++)
                {
                    _boardSquares[x,y] = new Square(new Coordinate(x,y));
                }
            }
        }
        public Square GetSquare(Coordinate coordinate)
        {
            return _boardSquares[coordinate.X, coordinate.Y];
        }

        public bool IsSquareUnrevealed(Coordinate coordinate)
        {
            var squares = _boardSquares.Cast<Square>().ToList();
            return squares.Any(s => s.Coordinate.X == coordinate.X && s.Coordinate.Y == coordinate.Y && s.IsRevealed == false);
        }

        public bool NoSquareRevealed()
        {
            var squares = _boardSquares.Cast<Square>().ToList();
            return squares.TrueForAll(s => !s.IsRevealed);
        }
        
        public int GetNumberOfMines()
        {
            var squares = _boardSquares.Cast<Square>().ToList();
            return squares.Count(s => s.IsMine);
        }
        
    }
}