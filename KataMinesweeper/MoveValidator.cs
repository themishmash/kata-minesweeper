namespace KataMinesweeper
{
    public static class MoveValidator
    {
        public static bool IsValidMove(Coordinate coordinate, Board board)
        {
            var square = board.GetSquare(coordinate);
            return !square.IsRevealed && IsNumberWithinBoundary(coordinate.XCoordinate, coordinate.YCoordinate, board);
        }

        private static bool IsNumberWithinBoundary(int xCoordinate, int yCoordinate, Board board)
        {
            
            return xCoordinate >= 0 && yCoordinate >= 0;
        }
        
        
        
    }
}