using System.Collections.Generic;

namespace KataMinesweeper
{
    public interface IMineGenerator
    {
        // int GetXCoordinate();
        //
        // int GetYCoordinate();
        IEnumerable<Square> GenerateMines();
    }
}