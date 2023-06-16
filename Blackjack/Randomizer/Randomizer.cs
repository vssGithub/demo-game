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

        public int Next(int maxValue)
        {
            return random.Next(maxValue);
        }

        public int GetSecureRandom()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[1000];
                rng.GetBytes(randomNumber);
                int value = BitConverter.ToInt32(randomNumber, 0);
                return value % 52;
            }
        }

        public int GetSecureRng(int maxValue)
        {
            return RandomNumberGenerator.GetInt32(maxValue);
        }
    }
}
