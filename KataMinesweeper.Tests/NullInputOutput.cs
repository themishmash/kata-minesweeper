namespace KataMinesweeper.Tests
{
    public class NullInputOutput:IInputOutput
    {
        public (int x, int y) AskQuestion(string answer)
        {
            return (0, 0);
        }

        public void Output(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}