using System.Collections.Generic;
using System.Linq;

namespace KataMinesweeper.Tests
{
    public class PlayerInput : IInputOutput
    {
       
        private readonly List<(int, int)> _turns = new List<(int, int)>();

        public PlayerInput(IEnumerable<(int, int)> turns)
        {
            foreach (var turn in turns)
            {
                _turns.Add(turn);
            }
        }
        
        public (int x, int y) AskQuestion(string answer)
        {
            var move = (0, 0);
            for (var i = 0; i <= _turns.Count;)
            {
                move = _turns.FirstOrDefault();
                _turns.Remove(move);
                return move;
            }
            return move;
        }

        public void Output(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}