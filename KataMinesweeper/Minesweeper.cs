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

        private readonly IMineGenerator _iMineGenerator;
        //todo make mine gen be iminegenerator
        //feed it minegenerator

        public GameStatus GameStatus { get; private set; }
        
        public Minesweeper(Board board, Player player, IInputOutput iio, IMineGenerator iMineGenerator)
        {
            _board = board;
            _player = player;
            _iio = iio;
            _hintCalculator = new HintCalculator(board);
            _iMineGenerator = iMineGenerator;
           //_mineGenerator = new MineGenerator(board);
           GameStatus = GameStatus.Playing;

          // InitGame();
        }

        // void InitGame()
        // {
        //     generateMines();
        //     calculateHints();
        // }

        public void PlayGame()
        {
            _iMineGenerator.PlaceMinesToBoard();
           _iio.Output(RevealAllMinesAndHints());
           _iio.Output(DisplayBlankBoard());
            while (true)
            {
                var coordinate = _player.PlayTurn();
                while (!MoveValidator.IsValidMove(coordinate, _board))
                {
                    _iio.Output("Please enter a valid move.");
                    coordinate = _player.PlayTurn();
                }
                
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
                    _iio.Output(RevealAllMinesAndHints());
                    return;
                }

                if (!HasPlayerWon()) continue;
                GameStatus = GameStatus.Won;
                return;
            }
        }
        
        private string DisplayBlankBoard()
        {
            var board = "";
            for (var i = 0; i < _board.Size; i++)
            {
                for (var j = 0; j < _board.Size; j++)
                {
                    board += " . ";
                }
                board += Environment.NewLine;
            }
            return board;
        }

        private string RevealAllMinesAndHints()
        {
            var board = "";
            for (var i = 0; i < _board.Size; i++)
            {
                for (var j = 0; j < _board.Size; j++)
                {
                    var coordinate = new Coordinate(i, j);
                    var hint = _hintCalculator.Calculate(coordinate);
                    var square = _board.GetSquare(new Coordinate(i,j));
                    
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