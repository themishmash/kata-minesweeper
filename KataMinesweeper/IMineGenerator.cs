using System.Collections.Generic;

namespace KataMinesweeper
{
    public interface IMineGenerator
    {
        IEnumerable<Coordinate> GenerateMines();
        void PlaceMinesToBoard();
    }
}