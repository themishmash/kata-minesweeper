using System.Collections.Generic;

namespace KataMinesweeper
{
    public interface IMineGenerator
    {
        IEnumerable<Coordinate> GenerateMines(Coordinate coordinate);
        void PlaceMinesToBoard(Coordinate coordinate);
    }
}