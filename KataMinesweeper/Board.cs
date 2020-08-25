using System;
using System.Collections.Generic;
using System.Linq;

namespace KataMinesweeper
{
    public class Board
    {
        public int Size;
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
        
        public Square GetSquare(int xCoordinate, int yCoordinate)
        {
            return _boardSquares[xCoordinate, yCoordinate];
        }
        
    }
}