namespace KataMinesweeper
{
    public static class MoveValidator
    {
        public static bool IsValidMove(Coordinate coordinate, Board board)
        {
            return board.IsSquareUnrevealed(coordinate) && IsNumberWithinBoundary(coordinate.XCoordinate, coordinate.YCoordinate, 
            board);
        }

        private static bool IsNumberWithinBoundary(int xCoordinate, int yCoordinate, Board board)
        {
            return xCoordinate >= 0 && xCoordinate < board.Size && yCoordinate >= 0 && yCoordinate < board.Size;
        }
        
    }
}