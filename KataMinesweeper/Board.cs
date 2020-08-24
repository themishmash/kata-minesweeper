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
        
        private void GenerateMines()
        {
            //todo generating random ones - need to do a check. if minestatus is false - then set to true. new mine only created with those that are false. 
            for (var i = 0; i < Size; i++)
            {
                var mine = new Square(i, 0);
                var square = GetSquare(mine.XCoordinate, mine.YCoordinate);
                square.MineStatus = MineStatus.True;
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
            var neighbours = new List<Square>();

            GetNeighbourSquares(square, neighbours);
            
            var hint = neighbours.Count(x => x.MineStatus == MineStatus.True);

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
                var neighbours = new List<Square>();
                GetNeighbourSquares(square, neighbours);
                var hint = neighbours.Count(x => x.MineStatus == MineStatus.True);

                if (square.MineStatus == MineStatus.False)
                {
                    _boardSquares[square.XCoordinate, square.YCoordinate].Value = " " + hint + " ";
                }
            }
        }

        private void GetNeighbourSquares(Square square, ICollection<Square> neighbours)
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

                    neighbours.Add(_boardSquares[xCoordinate, yCoordinate]);
                }
            }
        }

        private IEnumerable<Square> GetMines()
        {
            return _boardSquares.Cast<Square>().Where(square => square.MineStatus == MineStatus.True).ToList();
        }
        
        public Square GetSquare(int xCoordinate, int yCoordinate)
        {
            return _boardSquares[xCoordinate, yCoordinate];
        }

        public bool IsSquareBlank(Coordinate coordinate)
        {
            return _boardSquares.Cast<Square>().Any(square => square.XCoordinate == coordinate
                .XCoordinate && square.YCoordinate == coordinate.YCoordinate && square.IsRevealed == false);
        }
    }
}