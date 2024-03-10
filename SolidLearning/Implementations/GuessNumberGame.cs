using SolidLearning.Abstractions;
using System;

namespace SolidLearning.Implementations
{
    internal class GuessNumberGame : IGame
    {
        private int minNumber;
        private int maxNumber;
        private int targetNumber;
        private int attempts;
        private IRandomNumberGenerator randomNumberGenerator;
        public GuessNumberGame()
        {
            randomNumberGenerator = new RandomNumberGenerator();
            attempts = 0;
        }

        public void RunGame()
        {
            Console.WriteLine(@"Привет, это игра ""Угадай число""!");

            InputNumbersInterval();

            targetNumber = randomNumberGenerator.GenerateNumber(minNumber, maxNumber);

            Console.WriteLine($"Отлчно, теперь попробуйте отгадать число в интервале {minNumber} - {maxNumber}!");
            int guessedNumber;
            do
            {
                Console.Write("Введите число: ");
                if (ValidateIntInput(out guessedNumber))
                {
                    CompareNumber(guessedNumber);
                }

            } while (guessedNumber != targetNumber);

            Console.WriteLine("Поздравляю! Вы угадали число!");
            Console.WriteLine($"Вы потратили {attempts} попыток.");
        }
        private void CompareNumber(int number)
        {
            attempts++;

            if (number < minNumber || number > maxNumber)
            {
                Console.WriteLine("Будте внимательней! Вы ввели число вне интервала.");
            }
            else if (number < targetNumber)
            {
                Console.WriteLine("Загаданное число больше.");
            }
            else if (number > targetNumber)
            {
                Console.WriteLine("Загаданное число меньше.");
            }
        }

        private void InputNumbersInterval()
        {
            Console.WriteLine("Вам необходимо указать интервал в котором будете угадывать число.");

            bool isValid;
            do
            {
                Console.WriteLine("Укажите минимальное число:");
                isValid = ValidateIntInput(out minNumber);
            } while (!isValid);

            do
            {
                Console.WriteLine("Укажите максимальное число:");
                isValid = ValidateIntInput(out maxNumber);
                if(maxNumber < minNumber)
                {
                    Console.WriteLine("Максимальное число не может быть меньше минимального!");
                    isValid = false;
                }
            } while (!isValid);
        }
        private bool ValidateIntInput(out int guessedNumber)
        {
            if (int.TryParse(Console.ReadLine(), out guessedNumber))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Неккоректный ввод! Пожалуйста, введите целое число.");
                return false;
            }
        }
    }
}
