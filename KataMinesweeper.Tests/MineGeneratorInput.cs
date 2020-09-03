using System.Collections.Generic;

namespace KataMinesweeper.Tests
{
    public class MineGeneratorInput:IMineGenerator
    {
        private List<Coordinate> _mines;


        private IEnumerable<Coordinate> GenerateMines()
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
        
        public void PlaceMinesToBoard(Board board)
        {
            foreach (var coordinate in GenerateMines())
            {
                board.GetSquare(coordinate).IsMine = true;
            }
        }

        public void SetFirstMove(Coordinate coordinate)
        {
            
        }
    }
}