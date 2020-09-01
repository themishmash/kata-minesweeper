namespace KataMinesweeper
{
    public class HintCalculator
    {
        private readonly Board _board;

        public HintCalculator(Board board)
        {
            _board = board;
        }
        
        public int Calculate(Coordinate coordinate) 
        {
            var squareToCheck = _board.GetSquare(coordinate);
            var count = 0;
            for (var xCoordinate = squareToCheck.Coordinate.X - 1; xCoordinate <= squareToCheck.Coordinate.X + 1; xCoordinate++)
            {
                for (var yCoordinate = squareToCheck.Coordinate.Y - 1; yCoordinate <= squareToCheck.Coordinate.Y + 1; yCoordinate++)
                {
                    if (IsCurrentSquare(xCoordinate, yCoordinate, squareToCheck)) continue;
                    
                    if (IsOutOfBoundary(xCoordinate, yCoordinate)) continue;
                    
                    var neighbourCoordinate = new Coordinate(xCoordinate, yCoordinate);
                    if (_board.GetSquare(neighbourCoordinate).IsMine)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        
        private static bool IsCurrentSquare(int xCoordinate, int yCoordinate, Square squareToCheck)
        {
            return xCoordinate == squareToCheck.Coordinate.X && yCoordinate == squareToCheck.Coordinate.Y;
        }
        
        private bool IsOutOfBoundary(int xCoordinate, int yCoordinate)
        {
            return xCoordinate < 0 || xCoordinate > _board.Size-1 || yCoordinate < 0 || yCoordinate > _board.Size-1;
        }
    }
}