using System;
using System.Text;

namespace OpenUtilityExtensions.ByteExtensions
{
    public static class ByteExtension
    {
        /// <summary>
        /// Convert the current string to byte[]
        /// </summary>
        /// <param name="Value">The current string value</param>
        /// <returns>byte[] representation of the string</returns>
        public static  byte[] ConvertStringToByteArray(this string Value)
        {
            return Encoding.UTF8.GetBytes(Value ?? throw new ArgumentNullException("String Value"));
        }
        /// <summary>
        /// Convert the current byte[] to string
        /// </summary>
        /// <param name="Value">The current byte[] value</param>
        /// <returns>string representation of byte[]</returns>
        public static string ConvertByteArrayToUTF8String(this byte[] Value)
        {
            return Encoding.UTF8.GetString(Value);
        }

        /// <summary>
        /// Convert byte array to its equivalent base-64 string, it is used when you want to send byte array in a message or store it in the database.
        /// </summary>
        /// <param name="Value">The Current byte[] Value</param>
        /// <returns>equivalent base-64 string of the byte[]</returns>
        public static string ConvertByteArrayToBase64(this byte[] Value)
        {
            return Convert.ToBase64String(Value);
        }

        /// <summary>
        /// Convert the base-64 string to the original Byte[] again
        /// </summary>
        /// <param name="Value">The Current base-64 string value</param>
        /// <returns>the original byte[]</returns>
        public static byte[] ConvertBase64ToByteArray(this string Value)
        {
            return Convert.FromBase64String(Value ?? throw new ArgumentNullException("String Value"));
        }
    }
}
