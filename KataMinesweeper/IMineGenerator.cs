using System.Collections.Generic;

namespace KataMinesweeper
{
    public interface IMineGenerator
    {
        void PlaceMinesToBoard(Coordinate coordinate);
        IEnumerable<Coordinate> GenerateMines(Coordinate coordinate);
        // void PlaceMinesToBoard();
        // IEnumerable<Coordinate> GenerateMines();
    }
}