namespace KataMinesweeper
{
    public class Player
    {
        private readonly IInputOutput _iio;

        public Player(IInputOutput iio)
        {
            _iio = iio;
        }
        public Coordinate PlayTurn()
        {
            var (x, y) = _iio.AskQuestion("Please enter a coordinate to play: ");
            var coordinate = new Coordinate(x,y);
            return coordinate;
        }

        // public Coordinate SetFlag()
        // {
        //     var (x, y) = _iio.AskQuestion("Please enter a coordinate to flag: ");
        //     var coordinate = new Coordinate(x,y);
        //     return coordinate;
        // }
    }
}