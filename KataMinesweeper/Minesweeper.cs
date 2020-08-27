using System;

namespace KataMinesweeper
{
    public class Minesweeper
    {
        
        private readonly Board _board;
        private readonly Player _player;
        private readonly IInputOutput _iio;
        private readonly HintCalculator _hintCalculator;
        private readonly MineGenerator _mineGenerator;

        public GameStatus GameStatus { get; set; }
        
        public Minesweeper(Board board, Player player, IInputOutput iio)
        {
            _board = board;
            _player = player;
            _iio = iio;
            _hintCalculator = new HintCalculator(board);
           _mineGenerator = new MineGenerator(board);
           
            GameStatus = GameStatus.Playing;
            
        }

        public void PlayGame()
        {
            
            _mineGenerator.PlaceMinesToBoard();
           _iio.Output(DisplayBoard());
           
            while (true)
            {
                var coordinate = _player.PlayTurn();
                var square = _board.GetSquare(coordinate);
                if (!square.IsMine)
                {
                    square.IsRevealed = true;
                    square.Hint = _hintCalculator.Calculate(coordinate);
                    _iio.Output(RevealSquareForPlayerMove(coordinate));
                }
                if (square.IsMine)
                {
                    square.IsRevealed = true;
                    GameStatus = GameStatus.Lost;
                    _iio.Output(DisplayBoard());
                    return;
                }

                if (!HasPlayerWon()) continue;
                GameStatus = GameStatus.Won;
                return;
            }
        }

        private string DisplayBoard()
        {
            var board = "";
            for (var i = 0; i < _board.Size; i++)
            {
                for (var j = 0; j < _board.Size; j++)
                {
                    var coordinate = new Coordinate(i, j);
                    var hint = _hintCalculator.Calculate(coordinate);
                    var square = _board.GetSquare(coordinate);
                    
                    if (square.IsMine)
                        board += " * ";
                    
                    if(!square.IsMine)
                        board += " " + hint + " ";
                }
                board += Environment.NewLine;
            }
            return board;
        }

        private string RevealSquareForPlayerMove(Coordinate playerCoordinate)
        {
            var board = "";
            for (var i = 0; i < _board.Size; i++)
            {
                for (var j = 0; j < _board.Size; j++)
                {
                    var square = _board.GetSquare(new Coordinate(i,j));
                    var playerSquare = _board.GetSquare(playerCoordinate);
                    if (square.IsRevealed == false)
                    {
                        board += " . ";
                    }
                    if (square.IsRevealed && !square.IsMine && playerSquare.IsRevealed && !playerSquare.IsMine)
                    {
                        board += " " + square.Hint + " ";
                    }
                }
                board += Environment.NewLine;
            }
            return board;
                
        }
        
        private bool HasPlayerWon()
        {
            return _board.AreAllHintsRevealed();
        }
        
        
    }
}