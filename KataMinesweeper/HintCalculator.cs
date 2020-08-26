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
            var squareToCheck = _board.GetSquare(coordinate.XCoordinate, coordinate.YCoordinate);
            var count = 0;
            for (var xCoordinate = squareToCheck.XCoordinate - 1; xCoordinate <= squareToCheck.XCoordinate + 1; xCoordinate++)
            {
                for (var yCoordinate = squareToCheck.YCoordinate - 1; yCoordinate <= squareToCheck.YCoordinate + 1; yCoordinate++)
                {
                    //continue if square being checked
                    
                    if (xCoordinate == squareToCheck.XCoordinate && yCoordinate == squareToCheck.YCoordinate) continue;
                    
                    //continue if out of bounds
                    //3 - is the three points square is touching in a row or column. so don't want to iterate more than 3
                    if (xCoordinate < 0 || xCoordinate > 3 || yCoordinate < 0 || yCoordinate > 3) continue;
                    
                    if (_board.GetSquare(xCoordinate, yCoordinate).IsMine)
                    {
                        count++;
                    }
                }
            }
            //_board.GetSquare(squareToCheck.XCoordinate, squareToCheck.YCoordinate).Hint = count; // this should be taken out as this method doing two things. 
           return count;
        }
    }
}