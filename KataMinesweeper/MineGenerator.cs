using System;
using System.Collections.Generic;
using System.Linq;

namespace KataMinesweeper
{
    public class MineGenerator: IMineGenerator
    {
        private Board _board;
        private List<Coordinate> _mines;
        private Coordinate _playerFirstMove;

        public void PlaceMinesToBoard(Board board)
        {
            _board = board;
            foreach (var coordinate in GenerateMines(_playerFirstMove))
            {
                _board.GetSquare(coordinate).IsMine = true;
            }
        }

        public void SetFirstMove(Coordinate coordinate)
        {
            _playerFirstMove = coordinate;
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

        private IEnumerable<Coordinate> GenerateMines(Coordinate playerCoordinate)
        {
            _mines = new List<Coordinate>();
            while (_mines.Count != _board.Size)
            {
                var coordinate = new Coordinate(GetXCoordinate(), GetYCoordinate());
                var matchingMine =_mines.FirstOrDefault(mine => mine.X == coordinate.X && mine
                        .Y ==
                    coordinate.Y);
                
                //this checks for player coord in mines list and any new ones being generated
                var matchingPlayerCoordinate = _mines.FirstOrDefault(mine => mine.X == playerCoordinate
                     .X && mine.Y == playerCoordinate.Y || coordinate.X == 
                     playerCoordinate.X && coordinate.Y == playerCoordinate.Y);
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