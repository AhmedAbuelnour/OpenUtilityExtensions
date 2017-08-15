using System;
using System.Security.Cryptography;
using System.Text;

namespace OpenUtilityExtensions.StringExtensions
{
    public static class HashExtentsion
    {
        /// <summary>
        /// Compute the hash of a string 
        /// </summary>
        /// <param name="Value">The Current String value to get its hash</param>
        /// <returns>
        /// A strong hash (128 Letter) 
        /// </returns>
        public static string GetStrongHash128(this string Value)
        {
            return BitConverter.ToString(SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes(Value ?? throw new ArgumentNullException("String Value")))).Replace("-", string.Empty);
        }
        /// <summary>
        /// Compute the hash of a string 
        /// </summary>
        /// <param name="Value">The Current String value to get its hash</param>
        /// <returns>
        /// A strong hash (64 Letter) 
        /// </returns>
        public static string GetIntermediateHash64(this string Value)
        {
            return BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(Value ?? throw new ArgumentNullException("String Value")))).Replace("-", string.Empty);
        }
        /// <summary>
        /// Compute the hash of a string 
        /// </summary>
        /// <param name="Value">The Current String value to get its hash</param>
        /// <returns>
        /// A strong hash (40 Letter) 
        /// </returns>
        public static string GetWeakHash40(this string Value)
        {
            return BitConverter.ToString(SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(Value ?? throw new ArgumentNullException("String Value")))).Replace("-", string.Empty);
        }
    }
}
