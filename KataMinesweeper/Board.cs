using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace KataMinesweeper
{
    public class Board
    {
        public int Size;
        private static Square[,] _boardSquares;


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
        private void GenerateMines()
        {
            for (var i = 0; i < Size; i++)
            {
                var mine = new Square(i, 0);
                _boardSquares[mine.XCoordinate, mine.YCoordinate].SquareStatus = SquareStatus.True;
            }
        }
        
        //hardcode for 1 square
        //todo this will need to be moved - maybe to move class? and need to be refactored too!! majorly. 
        private void GenerateHints()
        {
            foreach (var square in _boardSquares)
            {
                var neighbourSquares = new List<Square>();
                   
                    for (var xCoordinate = square.XCoordinate-1; xCoordinate <= square.XCoordinate + 1; xCoordinate++)
                    {
                        for (var yCoordinate = square.YCoordinate-1; yCoordinate <= square.YCoordinate + 1; yCoordinate++)
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
                    var hint = neighbourSquares.Count(x => x.SquareStatus == SquareStatus.True);
                    // switch (hint)
                    // {
                    //     case 0 when square.SquareStatus == SquareStatus.False:
                    //         _boardSquares[square.XCoordinate, square.YCoordinate].SquareStatus = SquareStatus.Hint0;
                    //         break;
                    //     case 1 when square.SquareStatus == SquareStatus.False:
                    //         _boardSquares[square.XCoordinate, square.YCoordinate].SquareStatus = SquareStatus.Hint1;
                    //         break;
                    //     case 2 when square.SquareStatus == SquareStatus.False:
                    //         _boardSquares[square.XCoordinate, square.YCoordinate].SquareStatus = SquareStatus.Hint2;
                    //         break;
                    //     case 3 when square.SquareStatus == SquareStatus.False:
                    //         _boardSquares[square.XCoordinate, square.YCoordinate].SquareStatus = SquareStatus.Hint3;
                    //         break;
                    // }
            }
        }

         

         private static bool IsValid(int xCoordinate, int yCoordinate)
        {
            return xCoordinate >= 0 && xCoordinate < 3 && yCoordinate >= 0 && yCoordinate < 3;
        }

         private static bool NotCurrentSquare(int xCoordinate, int yCoordinate, Square square)
         {
             return xCoordinate != square.XCoordinate || yCoordinate != square.YCoordinate;
         }

         private static bool IsMine(int xCoordinate, int yCoordinate)
         {
             //return square.SquareStatus == SquareStatus.True;
             return _boardSquares[xCoordinate, yCoordinate].SquareStatus == SquareStatus.True;
         }

        public int CountMines()
        {
            return _boardSquares.Cast<Square>().Count(square => square.SquareStatus == SquareStatus.True);
        }

        public IEnumerable<Square> GetMines()
        {
            return _boardSquares.Cast<Square>().Where(square => square.SquareStatus == SquareStatus.True).ToList();
        }

        public SquareStatus GetSquare(int xCoordinate, int YCoordinate)
        {
            return _boardSquares[xCoordinate, YCoordinate].SquareStatus;
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