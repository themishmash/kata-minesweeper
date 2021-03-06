using System;
using System.Linq;

namespace KataMinesweeper
{
    public class ConsoleInputOutput : IInputOutput
    {
        public (int x, int y) AskQuestion(string question)
        {
            Console.WriteLine(question);
            var answer = Console.ReadLine();
            var coordinates = ParseStringCoordinatesToInt(answer);
            return (coordinates[0], coordinates[1]);
        }
    
        public void Output(string message)
        {
            Console.WriteLine(message);
        }
        
        private int[] ParseStringCoordinatesToInt(string number)
        {
            var stringCoordinates = number.Split(',');
            return stringCoordinates.Select(int.Parse).ToArray();
        }
    }
}