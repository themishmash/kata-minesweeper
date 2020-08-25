namespace KataMinesweeper
{
    public class HintCalculator
    {
        private readonly Board _board;

        public HintCalculator(Board board)
        {
            _board = board;
        }

        public int GetHintFromPlayerMove(Coordinate coordinate)
        {
            var square = _board.GetSquare(coordinate.XCoordinate, coordinate.YCoordinate);
            var count = 0;
            for (var xCoordinate = square.XCoordinate - 1; xCoordinate <= square.XCoordinate + 1; xCoordinate++)
            {
                for (var yCoordinate = square.YCoordinate - 1; yCoordinate <= square.YCoordinate + 1; yCoordinate++)
                {
                    //ignore square being checked
                    if (xCoordinate == square.XCoordinate && yCoordinate == square.YCoordinate)
                    {
                        continue;
                    }
        
                    //ignore if out of bounds
                    //3 - is the three points square is touching in a row or column. so don't want to iterate more than 3
                    if (xCoordinate < 0 || xCoordinate > 3 || yCoordinate < 0 || yCoordinate > 3)
                    {
                        continue;
                    }
                   
                    if (_board.GetSquare(xCoordinate, yCoordinate).IsMine)
                    {
                        count++;
                    }
                }
            }
            _board.GetSquare(square.XCoordinate, square.YCoordinate).Hint = count;
           return count;
        }
    }
}