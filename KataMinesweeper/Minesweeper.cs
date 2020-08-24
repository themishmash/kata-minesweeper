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
            

        }

       

        


        public void PlayGame()
        {
            _iio.Output("Let's begin");
        }
    }
}