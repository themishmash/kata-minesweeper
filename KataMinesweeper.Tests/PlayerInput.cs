namespace KataMinesweeper.Tests
{
    public class PlayerInput : IInputOutput
    {
        private readonly (int x, int y) _turn;
        private int _counter;
        public PlayerInput((int, int) turn)
        {
            _turn = turn;
        }

        public (int x, int y) AskQuestion(string answer)
        {
            _counter++;
            switch (_counter)
            {
                case 1:
                    return _turn;
                default:
                    return (1, 1);
            }
        }

        public void Output(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}