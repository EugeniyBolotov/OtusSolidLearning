using System;
using SolidLearning.Abstractions;
using SolidLearning.Implementations;

namespace SolidLearning
{
    public class Program
    {
        public static void Main(string[] args)
        {

            IGame guessingGame = new GuessNumberGame();
            guessingGame.RunGame();

            Console.ReadLine();
        }
    }
}
