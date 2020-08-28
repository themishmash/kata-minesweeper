using System.Collections.Generic;
using System.Linq;

namespace KataMinesweeper
{
    public class Board
    {
        public readonly int Size;
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
                    _boardSquares[x,y] = new Square(x,y);
                }
            }
        }
        
        public Square GetSquare(Coordinate coordinate)
        {
            return _boardSquares[coordinate.XCoordinate, coordinate.YCoordinate];
        }

        public bool IsSquareUnrevealed(Coordinate coordinate)
        {
            var squares = _boardSquares.Cast<Square>().ToList();
            return squares.Any(s => s.XCoordinate == coordinate.XCoordinate && s.YCoordinate == coordinate.YCoordinate && s.IsRevealed == false);
        }
        
        // //todo move out to another class
        // public bool AreAllHintsRevealed()
        // {
        //     //var countMine = 0;
        //     var countHint = 0;
        //     foreach (var square in _boardSquares)
        //     {
        //         // if (square.IsMine && !square.IsRevealed)
        //         // {
        //         //     countMine++;
        //         // }
        //
        //         if (!square.IsMine && square.IsRevealed)
        //         {
        //             countHint++;
        //         }
        //     }
        //     return countHint == Size*Size-Size;
        // }
    }
}