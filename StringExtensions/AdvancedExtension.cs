using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenUtilityExtensions.StringExtensions
{
    public static class AdvancedExtension
    {
        public static IEnumerable<string> Spliter(this string Value, int BlockSize)
        {
            for (int i = 0; i < Value.Length; i += BlockSize)
                yield return Value.Substring(i, Math.Min(BlockSize, Value.Length - i));
        }
        /// <summary>
        /// Calculate percentage similarity of two strings
        /// <param name="source">The current String to Compare with</param>
        /// <param name="target">Targeted String to Compare</param>
        /// <returns>Return Similarity between two strings from 0 to 1.0</returns>
        /// </summary>
        public static async Task<double> CalculateSimilarityAsync(this string source, string target)
        {
            if ((source == null) || (target == null)) return 0.0;
            if ((source.Length == 0) || (target.Length == 0)) return 0.0;
            if (source == target) return 1.0;
            int ComputeLevenshteinDistance(string sourceLocal, string targetLocal)
            {
                if ((source == null) || (target == null)) return 0;
                if ((source.Length == 0) || (target.Length == 0)) return 0;
                if (source == target) return source.Length;

                int sourceWordCount = source.Length;
                int targetWordCount = target.Length;

                // Step 1
                if (sourceWordCount == 0)
                    return targetWordCount;

                if (targetWordCount == 0)
                    return sourceWordCount;

                int[,] distance = new int[sourceWordCount + 1, targetWordCount + 1];

                // Step 2
                for (int i = 0; i <= sourceWordCount; distance[i, 0] = i++) ;
                for (int j = 0; j <= targetWordCount; distance[0, j] = j++) ;

                for (int i = 1; i <= sourceWordCount; i++)
                {
                    for (int j = 1; j <= targetWordCount; j++)
                    {
                        // Step 3
                        int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                        // Step 4
                        distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
                    }
                }

                return distance[sourceWordCount, targetWordCount];
            }

            int stepsToSame = await Task.Run(() => { return ComputeLevenshteinDistance(source, target); });
            return (1.0 - ((double)stepsToSame / (double)Math.Max(source.Length, target.Length)));
        }
    }
}
