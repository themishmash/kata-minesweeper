using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

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
            GenerateHints();
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
        //todo make Mine class?
        private void GenerateMines()
        {
            for (var i = 0; i < Size; i++)
            {
                var mine = new Square(i, 0);
                _boardSquares[mine.XCoordinate, mine.YCoordinate].MineStatus = MineStatus.True;
            }
        }
        
        
        //todo make Hint class?
        //todo refactor this method
        private void GenerateHints()
        {
            foreach (var square in _boardSquares)
            {
                var neighbourSquares = new List<Square>();
                GetNeighbouringSquares(square, neighbourSquares);
                var hint = neighbourSquares.Count(x => x.MineStatus == MineStatus.True);
                GetMineStatus(hint, square);
            }
        }
        
        private void GetNeighbouringSquares(Square square, List<Square> neighbourSquares)
        {
            for (var xCoordinate = square.XCoordinate - 1; xCoordinate <= square.XCoordinate + 1; xCoordinate++)
            {
                for (var yCoordinate = square.YCoordinate - 1; yCoordinate <= square.YCoordinate + 1; yCoordinate++)
                {
                    if (IsCurrentSquare(square, xCoordinate, yCoordinate) || IsNotNeighbour(xCoordinate, yCoordinate))
                    {
                        continue;
                    }

                    neighbourSquares.Add(_boardSquares[xCoordinate, yCoordinate]);
                }
            }
        }

        private static bool IsCurrentSquare(Square square, int xCoordinate, int yCoordinate)
        {
            return xCoordinate == square.XCoordinate && yCoordinate == square.YCoordinate;
        }
        
        private static bool IsNotNeighbour(int xCoordinate, int yCoordinate)
        {
            return xCoordinate < 0 || xCoordinate > 3 || yCoordinate < 0 || yCoordinate > 3;
        }
        
        private void GetMineStatus(int hint, Square square)
        {
            switch (hint)
            {
                case 0 when square.MineStatus == MineStatus.False:
                    _boardSquares[square.XCoordinate, square.YCoordinate].MineStatus = MineStatus.Hint0;
                    break;
                case 1 when square.MineStatus == MineStatus.False:
                    _boardSquares[square.XCoordinate, square.YCoordinate].MineStatus = MineStatus.Hint1;
                    break;
                case 2 when square.MineStatus == MineStatus.False:
                    _boardSquares[square.XCoordinate, square.YCoordinate].MineStatus = MineStatus.Hint2;
                    break;
                case 3 when square.MineStatus == MineStatus.False:
                    _boardSquares[square.XCoordinate, square.YCoordinate].MineStatus = MineStatus.Hint3;
                    break;
            }
        }


        public int CountMines()
        {
            return _boardSquares.Cast<Square>().Count(square => square.MineStatus == MineStatus.True);
        }

        public IEnumerable<Square> GetMines()
        {
            return _boardSquares.Cast<Square>().Where(square => square.MineStatus == MineStatus.True).ToList();
        }

        public MineStatus GetMineStatus(int xCoordinate, int yCoordinate)
        {
            return _boardSquares[xCoordinate, yCoordinate].MineStatus;
        }
        
        public string DisplayBoard()
        {
            var board = "";
            var rows = new string[Size];
            for (var currentRow = 0; currentRow < Size; currentRow++)
            {
                var columns = new string[Size];
                for (var currentCol = 0; currentCol < Size; currentCol++)
                {
                    columns[currentCol] = _boardSquares[currentRow, currentCol].ToString();
                }
                rows[currentRow] = string.Join("", columns);
            }
            board += string.Join("\n", rows);
            return board;
        }
    }
}