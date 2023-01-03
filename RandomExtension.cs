using System;

namespace SnapProblem
{
    static class RandomExtensions
    {
        /// <summary>
        /// Shuffle the card in an array based on it's length with the help of Random
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rng"></param>
        /// <param name="array"></param>
        public static void Shuffle<T>(this Random rng, T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
}
