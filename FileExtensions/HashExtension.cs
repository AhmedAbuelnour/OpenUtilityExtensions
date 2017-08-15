using System;
using System.IO;
using System.Security.Cryptography;

namespace OpenUtilityExtensions.FileExtensions
{
    public static class HashExtentsion
    {
        /// <summary>
        /// Compute the hash of a file 
        /// </summary>
        /// <param name="Value">The Current file to get its hash</param>
        /// <returns>
        /// A strong hash (128 Letter) 
        /// </returns>
        public static string GetStrongHash128(this FileStream Value)
        {
            return BitConverter.ToString(SHA512.Create().ComputeHash(Value ?? throw new ArgumentNullException("File Stream"))).Replace("-", string.Empty);
        }
        /// <summary>
        /// Compute the hash of a file 
        /// </summary>
        /// <param name="Value">The Current file to get its hash</param>
        /// <returns>
        /// A strong hash (64 Letter) 
        /// </returns>
        public static string GetIntermediateHash64(this FileStream Value)
        {
            return BitConverter.ToString(SHA256.Create().ComputeHash(Value ?? throw new ArgumentNullException("File Stream"))).Replace("-", string.Empty);
        }
        /// <summary>
        /// Compute the hash of a file 
        /// </summary>
        /// <param name="Value">The Current file to get its hash</param>
        /// <returns>
        /// A strong hash (40 Letter) 
        /// </returns>
        public static string GetWeakHash40(this FileStream Value)
        {
            return BitConverter.ToString(SHA1.Create().ComputeHash(Value ?? throw new ArgumentNullException("File Stream"))).Replace("-", string.Empty);
        }
    }
}
