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
            GenerateMines();
           // GenerateHints();
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
        
        //todo make this method generate random x and y coordinates according to the Size property of board
        private void GenerateMines()
        {
            for (var i = 0; i < Size; i++)
            {
                var mine = new Square(i, 0);
                _boardSquares[mine.XCoordinate, mine.YCoordinate].MineStatus = MineStatus.True;
            }
        }
        
        public int CountMines()
        {
            return _boardSquares.Cast<Square>().Count(square => square.MineStatus == MineStatus.True);
        }
        
        public string DisplayBoard()
        {
            var board = "";
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    board += _boardSquares[i, j].Value;
                }
                board += Environment.NewLine;
            }
            return board;
        }
        
        public void GetHintForPlayerMove(Coordinate coordinate)
        {
            var square = GetSquare(coordinate.XCoordinate, coordinate.YCoordinate);
            var neighbourSquares = new List<Square>();

            GetNeighbourSquares(square, neighbourSquares);
            
            var hint = neighbourSquares.Count(x => x.MineStatus == MineStatus.True);

            if (square.MineStatus == MineStatus.False)
            {
                _boardSquares[square.XCoordinate, square.YCoordinate].Value = " " + hint + " ";
                _boardSquares[square.XCoordinate, square.YCoordinate].IsRevealed = true;
            }

            if (square.MineStatus == MineStatus.True)
            {
                foreach (var mine in GetMines())
                {
                    mine.Value = " * ";
                }
                RevealAllHints();
            }
        }

        private void RevealAllHints()
        {
            foreach (var square in _boardSquares)
            {
                var neighbourSquares = new List<Square>();
                GetNeighbourSquares(square, neighbourSquares);
                var hint = neighbourSquares.Count(x => x.MineStatus == MineStatus.True);

                if (square.MineStatus == MineStatus.False)
                {
                    _boardSquares[square.XCoordinate, square.YCoordinate].Value = " " + hint + " ";
                }
            }
        }

        private void GetNeighbourSquares(Square square, List<Square> neighbourSquares)
        {
            for (var xCoordinate = square.XCoordinate - 1; xCoordinate <= square.XCoordinate + 1; xCoordinate++)
            {
                for (var yCoordinate = square.YCoordinate - 1; yCoordinate <= square.YCoordinate + 1; yCoordinate++)
                {
                    //ignore square being checked
                    if (xCoordinate == square.XCoordinate && yCoordinate == square.YCoordinate)
                    {
                        continue;
                    }

                    //ignore if out of bounds
                    //3 - is the three points square is touching in a row or column. so don't want to iterate more than 3
                    if (xCoordinate < 0 || xCoordinate > 3 || yCoordinate < 0 || yCoordinate > 3)
                    {
                        continue;
                    }

                    neighbourSquares.Add(_boardSquares[xCoordinate, yCoordinate]);
                }
            }
        }

        private IEnumerable<Square> GetMines()
        {
            return _boardSquares.Cast<Square>().Where(square => square.MineStatus == MineStatus.True).ToList();
        }
        
        public Square GetSquare(int xCoordinate, int YCoordinate)
        {
            return _boardSquares[xCoordinate, YCoordinate];
        }

    }
}