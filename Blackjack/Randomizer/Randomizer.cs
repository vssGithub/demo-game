using System;
using System.Security.Cryptography;

namespace RandomizerLibrary
{
    public class Randomizer
    {
        private Random random;

        public Randomizer()
        {
            random = new Random();
        }

        //TODO - change to uint
        public int GetSecureRng(int maxValue)
        {
            return RandomNumberGenerator.GetInt32(maxValue);
        }
    }
}
