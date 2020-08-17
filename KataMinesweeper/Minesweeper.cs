namespace KataMinesweeper
{
    public class Minesweeper
    {
        private readonly Board _board;
        private readonly Player _player;
       
        public GameStatus GameStatus { get; set; }

        public Minesweeper(Board board, Player player)
        {
            _board = board;
            _player = player;
            GameStatus = GameStatus.Playing;

        }

        public void PlayGame()
        {
            _board.DisplayBoard();
        }
    }
}