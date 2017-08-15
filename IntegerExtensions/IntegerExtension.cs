using System;

namespace OpenUtilityExtensions.IntegerExtensions
{
    public static class IntegerExtension
    {
        // Must use the same Instance of Random class to ensure getting trully random number
        // Using different instance each time results the same random number multiple times
        static readonly Random appRandom = new Random();
        /// <summary>
        /// Generate a random number between two numbers
        /// </summary>
        /// <param name="From">The Current Value, represents the minimum value that you can reach</param>
        /// <param name="To">The maximum value that you can reach </param>
        /// <returns>The Random Generated Number</returns>
        public static int Random(this int From, int To)
        {
            return appRandom.Next(Math.Min(From, To), Math.Max(From, To));
        }
        /// <summary>
        /// Checks if the current value is one of a given list of numbers
        /// </summary>
        /// <param name="Value">The Current Value</param>
        /// <param name="Numbers">An Array of numbers</param>
        /// <returns>bool that indicate the state of the check process</returns>
        public static bool IsInRangeOf(this int Value, params int[] Numbers)
        {
            foreach (int item in Numbers)
            {
                if (Value.Equals(item)) return true;
            }
            return false;
        }
    }
}
