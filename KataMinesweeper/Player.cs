namespace KataMinesweeper
{
    public class Player
    {
        public Move MakeMove(int xCoordinate, int yCoordinate)
        {
            return new Move(xCoordinate, yCoordinate);
        }
    }
}