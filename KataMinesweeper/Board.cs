using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace KataMinesweeper
{
    public class Board
    {
        public readonly int Size;
        private static Square[,] _boardSquares;


        public Board(int size)
        {
            Size = size;
            CreateBoard();
            GenerateMines();
            //GenerateHints();
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
        
        //hardcode for 1 square
        public static string GenerateHints()
        {
            var neighbourSquares = new List<Square>();
            var hint = 0;
            var square = _boardSquares[1, 1];
            //get neighbours 
            // var neighbour1 = _boardSquares[square.XCoordinate - 1, square.YCoordinate - 1];
            // var neighbour2 = _boardSquares[square.XCoordinate - 1, square.YCoordinate];
            // var neighbour3 = _boardSquares[square.XCoordinate - 1, square.YCoordinate + 1];

            for (var i = 0; i < square.XCoordinate + 1; i++)
            {
                neighbourSquares.Add(_boardSquares[0, i]); 
            }
            
            
            // var neighbour4 = _boardSquares[square.XCoordinate, square.YCoordinate - 1];
            // var neighbour5 = _boardSquares[square.XCoordinate, square.YCoordinate + 1];

            for (var i = 0; i < square.XCoordinate || i > square.XCoordinate; i++)
            {
                neighbourSquares.Add(_boardSquares[1, i]);
            }
            // var neighbour6 = _boardSquares[square.XCoordinate + 1, square.YCoordinate -1];
            // var neighbour7 = _boardSquares[square.XCoordinate + 1, square.YCoordinate];
            // var neighbour8 = _boardSquares[square.XCoordinate + 1, square.YCoordinate + 1];

            for (var i = 0; i < square.XCoordinate + 1; i++)
            {
                neighbourSquares.Add(_boardSquares[2, i]);
            }

            // neighbourSquares.Add(neighbour1);
            // neighbourSquares.Add(neighbour2);
            // neighbourSquares.Add(neighbour3);
            // neighbourSquares.Add(neighbour4);
            // neighbourSquares.Add(neighbour5);
            // neighbourSquares.Add(neighbour6);
            // neighbourSquares.Add(neighbour7);
            // neighbourSquares.Add(neighbour8);

            foreach (var item in neighbourSquares)
            {
                if (item.MineStatus == MineStatus.True)
                {
                    hint++;
                }
            }

            return hint.ToString();
        }
        
        

        public int CountMines()
        {
            return _boardSquares.Cast<Square>().Count(square => square.MineStatus == MineStatus.True);
        }

        public IEnumerable<Square> GetMines()
        {
            return _boardSquares.Cast<Square>().Where(square => square.MineStatus == MineStatus.True).ToList();
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