using System;
using System.Collections.Generic;
using System.Linq;

namespace KataMinesweeper
{
    public class MineGenerator: IMineGenerator
    {
        private readonly Board _board;
        private List<Coordinate> _mines;
        public MineGenerator(Board board)
        {
            _board = board;
            //GenerateMines();
        }

        private int GetXCoordinate()
        {
           var random = new Random();
           var randomCoordinate = random.Next(0, _board.Size);
           return randomCoordinate;
        }

        private int GetYCoordinate()
        {
            var random = new Random();
            var randomCoordinate = random.Next(0, _board.Size);
            return randomCoordinate;
        }
        
        public IEnumerable<Coordinate> GenerateMines()
        {
            _mines = new List<Coordinate>();
            while (_mines.Count != _board.Size)
            {
                var coordinate = new Coordinate(GetXCoordinate(), GetYCoordinate());
                var matchingMine =_mines.FirstOrDefault(mine => mine.XCoordinate == coordinate.XCoordinate && mine
                        .YCoordinate ==
                    coordinate.YCoordinate);
                if (!_mines.Contains(matchingMine))
                {
                    _mines.Add(coordinate);
                }
            }
            return _mines;
        }

        public void PlaceMinesToBoard()
        {
            foreach (var coordinate in GenerateMines())
            {
                _board.GetSquare(coordinate).IsMine = true;
            }
        }
    }
}