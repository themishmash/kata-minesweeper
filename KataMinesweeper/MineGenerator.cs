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
        
        //board could take in mine gen.
        //mine gen could gen mines during constructor of board. when new square created, whether mine or not set at that stage. 
        //ismine is read only. 
        
        public void PlaceMinesToBoard(Coordinate playerCoordinate)
        {
            foreach (var coordinate in GenerateMines(playerCoordinate))
            {
               _board.GetSquare(coordinate).IsMine = true;
               // var mine = _board.GetSquare(coordinate);
               // mine = new Square(new Coordinate(coordinate.X, coordinate.Y)) {IsMine = true};
            }
        }
        
        public IEnumerable<Coordinate> GenerateMines(Coordinate playerCoordinate)
        {
            _mines = new List<Coordinate>();
            while (_mines.Count != _board.Size)
            {
                var coordinate = new Coordinate(GetXCoordinate(), GetYCoordinate());//get square instead var ssquare = new square (new coord (getxcoord,)) {ismine=}
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