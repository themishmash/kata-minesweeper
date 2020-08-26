using System.Collections.Generic;
using System.Linq;

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
        public IEnumerable<Coordinate> GenerateMines()
        {
            _mines = new List<Coordinate>
            {
                new Coordinate(0, 0), 
                new Coordinate(0, 1), 
                new Coordinate(0, 2), 
                new Coordinate(0, 3)
            };
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