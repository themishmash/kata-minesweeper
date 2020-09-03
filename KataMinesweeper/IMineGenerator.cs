using System.Collections.Generic;

namespace KataMinesweeper
{
    public interface IMineGenerator
    {
        void PlaceMinesToBoard(Board board);
        void SetFirstMove(Coordinate coordinate);
    }
}