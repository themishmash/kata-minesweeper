using System.Collections.Generic;
using System.Linq;

namespace KataMinesweeper
{
    public class WinLose
    {
        private readonly Board _board;

        public WinLose(Board board)
        {
            _board = board;
            GenerateMines(); //move to minesweeper class
        }
        
        private void GenerateMines()
        {
            //todo generating random ones - need to do a check. if minestatus is false - then set to true. new mine only created with those that are false. 
            for (var i = 0; i < _board.Size; i++)
            {
                var mine = new Square(i, 0);
                var square = _board.GetSquare(mine.XCoordinate, mine.YCoordinate);
                square.IsMine = true;
            }
        }
        
        
        public void RevealSquareForPlayerMove(Coordinate coordinate)
        {
            var square = _board.GetSquare(coordinate.XCoordinate, coordinate.YCoordinate);
            var neighbours = new List<Square>();
        
            GetNeighbourSquares(square, neighbours);
            
            var hint = neighbours.Count(x => x.IsMine == true);
        
            if (square.IsMine == false)
            {
                _board.GetSquare(square.XCoordinate, square.YCoordinate).Hint = hint;
                _board.GetSquare(square.XCoordinate, square.YCoordinate).IsRevealed = true;
            }
            else
            {
                square.IsMine = true;
            }
        
            //reveal everything should be moved out. display contents of board.
            //refactor to show just single mine. and only reveal all mines and all hints with the dis
            // if (square.MineStatus == MineStatus.True)
            // {
                // foreach (var mine in _board.GetMines())
                // {
                //     mine.Value = " * ";
                // }
                //RevealAllHints(); this doesn't belong here. if over - then reveal all sqaures
            //}
        }

        public void CheckMine()
        {
            
        }
        
        //maybe move into board class
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
        
                    neighbours.Add(_board.GetSquare(xCoordinate, yCoordinate));
                }
            }
        }
        
        
        //todo not sure how to include this here
        //this probably in game class //or maybe board if can't get rid of _boardSquares. 
        //maybe do a get all hints method
        // private void RevealAllHints()
        // {
        //     foreach (var square in _boardSquares)
        //     {
        //         var neighbours = new List<Square>();
        //         GetNeighbourSquares(square, neighbours);
        //         var hint = neighbours.Count(x => x.MineStatus == MineStatus.True);
        //
        //         if (square.MineStatus == MineStatus.False)
        //         {
        //             _board.GetSquare(square.XCoordinate, square.YCoordinate).Value = " " + hint + " ";
        //         }
        //     }
        // }
        
    }
}