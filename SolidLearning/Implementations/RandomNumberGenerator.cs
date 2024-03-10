using System;
using SolidLearning.Abstractions;

namespace SolidLearning.Implementations
{
    internal class RandomNumberGenerator : IRandomNumberGenerator
    {
        private readonly Random _random;

        public RandomNumberGenerator()
        {
            _random = new Random();
        }

        public int GenerateNumber(int min, int max)
        {
            return _random.Next(min, max + 1);
        }
    }
}
