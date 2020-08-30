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
        
        public void PlaceMinesToBoard(Coordinate playerCoordinate)
        {
            foreach (var coordinate in GenerateMines(playerCoordinate))
            {
                _board.GetSquare(coordinate).IsMine = true;
            }
        }
        
        public IEnumerable<Coordinate> GenerateMines(Coordinate playerCoordinate)
        {
            _mines = new List<Coordinate>();
            while (_mines.Count != _board.Size)
            {
                var coordinate = new Coordinate(GetXCoordinate(), GetYCoordinate());
                var matchingMine =_mines.FirstOrDefault(mine => mine.XCoordinate == coordinate.XCoordinate && mine
                        .YCoordinate ==
                    coordinate.YCoordinate);
                var matchingPlayerCoordinate = _mines.FirstOrDefault(mine => mine.XCoordinate == playerCoordinate
                     .XCoordinate && mine.YCoordinate == playerCoordinate.YCoordinate);
                if (!_mines.Contains(matchingMine))
                {
                    _mines.Add(coordinate);
                }

                if (_mines.Contains(matchingPlayerCoordinate))
                {
                    _mines.Remove(matchingPlayerCoordinate);
                }
            }
            return _mines;
        }
    }
}