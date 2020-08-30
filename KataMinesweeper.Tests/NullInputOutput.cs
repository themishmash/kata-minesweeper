namespace KataMinesweeper.Tests
{
    public class NullInputOutput:IInputOutput
    {
        public (int x, int y) AskQuestion(string answer)
        {
            return (1, 2);
        }

        public void Output(string message)
        {
            
        }
    }
}