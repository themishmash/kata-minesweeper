using System;
using System.Collections.Generic;
using System.Linq;

namespace KataMinesweeper
{
    public class Board
    {
        public int Size;
        private Square[,] _boardSquares; //real board
        
        
        //list of player moves
        //checks if there is a match with the _boardSquares 
        
        // (0,0) -> stored in a list of playerMoves
        // find matching move with _boardsquare x and y coordinates
        // if matching = true, then .value = " * " or "hint" 
        
        public Board(int size)
        {
            Size = size;
            CreateBoard();
            GenerateMines();
            GetHints();
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
                
              //_boardSquares[mine.XCoordinate, mine.YCoordinate].Value = " * ";
            }
        }
        
        
        

        

        public void GetHints()
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
                var hint = neighbourSquares.Count(x => x.MineStatus == MineStatus.True);

                // if (square.MineStatus == MineStatus.False)
                // {
                //     _boardSquares[square.XCoordinate, square.YCoordinate].Value = hint + " ";
                // }
            }
        }
        
        public void GetHintsForEndGame()
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
                var hint = neighbourSquares.Count(x => x.MineStatus == MineStatus.True);

                if (square.MineStatus == MineStatus.False)
                {
                    _boardSquares[square.XCoordinate, square.YCoordinate].Value = " " + hint + " ";
                }
            }
        }

        public string GenerateHintForSingleSquare(Coordinate coordinate)
        {
            var square = GetSquare(coordinate.XCoordinate, coordinate.YCoordinate);
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
            var hint = neighbourSquares.Count(x => x.MineStatus == MineStatus.True);

            if (square.MineStatus == MineStatus.False)
            {
                return _boardSquares[square.XCoordinate, square.YCoordinate].Value = " " + hint + " ";
            }

            if (square.MineStatus == MineStatus.True)
            {
                foreach (var mine in GetMines())
                {
                    mine.Value = " * ";
                }
                GetHintsForEndGame();
            }

            return "";
        }
        
        public int CountMines()
        {
            return _boardSquares.Cast<Square>().Count(square => square.MineStatus == MineStatus.True);
        }

        public IEnumerable<Square> GetMines()
        {
            return _boardSquares.Cast<Square>().Where(square => square.MineStatus == MineStatus.True).ToList();
        }
        

        public Square GetSquare(int xCoordinate, int YCoordinate)
        {
            return _boardSquares[xCoordinate, YCoordinate];
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
        
       
        
    }
}