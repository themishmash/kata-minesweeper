using System.Collections.Generic;

namespace KataMinesweeper.Tests
{
    public class MineGeneratorInput:IMineGenerator
    {
        private List<Coordinate> _mines;
        private readonly Board _board;
        
        public MineGeneratorInput(Board board)
        {
            _board = board;
        }
        public IEnumerable<Coordinate> GenerateMines(Coordinate playerCoordinate)
        {
            _mines = new List<Coordinate>
            {
                new Coordinate(0, 0), 
                new Coordinate(1, 0), 
                new Coordinate(2, 0), 
                new Coordinate(3, 0)
            };
            return _mines;
        }
        
        public void PlaceMinesToBoard(Coordinate playerCoordinate)
        {
            foreach (var coordinate in GenerateMines(playerCoordinate))
            {
                _board.GetSquare(coordinate).IsMine = true;
            }
        }
    }
}