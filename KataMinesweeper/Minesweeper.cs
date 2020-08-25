namespace KataMinesweeper
{
    public class Minesweeper
    {
        private readonly Board _board;
        private readonly Player _player;
        private readonly IInputOutput _iio;

        public GameStatus GameStatus { get; set; }
        

        public Minesweeper(Board board, Player player, IInputOutput iio)
        {
            _board = board;
            _player = player;
            _iio = iio;
            GameStatus = GameStatus.Playing;
            GenerateMines();
            

        }

        private void GenerateMines()
        {
            //todo generating random ones - need to do a check. if minestatus is false - then set to true. new mine only created with those that are false. 
            for (var i = 0; i < _board.Size; i++)
            {
                var mine = new Square(i, 0);
                var square = _board.GetSquare(mine.XCoordinate, mine.YCoordinate);
                square.IsMine = true;
            }
        }
    }
}