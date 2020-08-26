using System.Collections.Generic;
using System.Linq;

namespace KataMinesweeper.Tests
{
    public class MineGeneratorInput:IMineGenerator
    {
        private readonly int _xCoordinate;
        private readonly int _yCoordinate;
        private List<Square> _mines = new List<Square>();


        public MineGeneratorInput(IEnumerable<Square> mines)
        {
            foreach (var mine in mines)
            {
                _mines.Add(mine);
            }
        }
        
        public int GetXCoordinate()
        {
            return _xCoordinate;
        }

        public int GetYCoordinate()
        {
            return _yCoordinate;
        }
        
        // public MineGeneratorInput(IEnumerable<(int, int)> mines)
        // {
        //     foreach (var mine in mines)
        //     {
        //        _mines.Add(mine);
        //     }
        // }
        //
        // public (int x, int y) GetMineCoordinates()
        // {
        //     var mine = (0, 0);
        //     for (var i = 0; i <= _mines.Count;)
        //     {
        //         mine = _mines.FirstOrDefault();
        //         _mines.Remove(mine);
        //         return mine;
        //     }
        //     return mine;
        // }
        
        public Square CreateMines()
        {
            var mine = new Square(0,0);
            for (var i = 0; i <= _mines.Count;)
            {
                mine = _mines.FirstOrDefault();
                _mines.Remove(mine);
                return mine;
            }

            return mine;
        }


        public IEnumerable<Square> GenerateMines()
        {
            _mines = new List<Square>();
            for (var i = 0; i <= 3; i++)
            {
                var mine = new Square(GetXCoordinate(), GetYCoordinate()){IsMine = true};
                if (!_mines.Contains(mine))
                {
                    _mines.Add(mine);
                }
            }

            return _mines;
        }
    }
}