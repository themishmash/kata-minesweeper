using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace KataMinesweeper
{
    public class Board
    {
        public static int Size;
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
        public void GenerateMines()
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
            
            var square = _boardSquares[0, 2];
            
                var neighbourSquares = new List<Square>();
                for (var i = square.XCoordinate-1; i <= square.XCoordinate + 1; i++)
                {
                    for (var j = square.YCoordinate-1; j <= square.YCoordinate + 1; j++)
                    {
                        //ignore square being checked
                        if (i == square.XCoordinate && j == square.YCoordinate)
                        {
                            continue;
                        }

                        //ignore if out of bounds
                        if (i < 0 || i > Size || j < 0 || j > Size)
                        {
                            continue;
                        }
                      
                        neighbourSquares.Add(_boardSquares[i, j]); 
                    }
                
                }

                var hint = neighbourSquares.Count(item => item.MineStatus == MineStatus.True);

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