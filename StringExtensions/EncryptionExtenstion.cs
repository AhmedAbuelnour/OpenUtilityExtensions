using OpenUtilityExtensions.ByteExtensions;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace OpenUtilityExtensions.StringExtensions
{
    public static class EncryptionExtenstion
    {
        /// <summary>
        /// Encrypt a string with a given Key and Salt.
        /// </summary>
        /// <param name="input">The Current String to Encrypt</param>
        /// <param name="Key">The Encryption Key</param>
        /// <param name="Salt">Makes the encryption more secure</param>
        /// <returns>
        /// Encrypted String
        /// </returns>
        public static string Encrypt(this string input, string Key, string Salt)
        {
            // Locate a memory to write the bytes in. 
            using (MemoryStream MS = new MemoryStream())
            {
                // Advanced Encryption Standard Encryption Algorithm, it’s so powerful.
                AesManaged aes = new AesManaged();
                // Generate Encrypt Key, with a given key and pseudo byte array   
                using (PasswordDeriveBytes KeyGenerator = new PasswordDeriveBytes(Key, Encoding.UTF8.GetBytes(Salt)))
                {
                    aes.Key = KeyGenerator.GetBytes(aes.KeySize / 8);
                    aes.IV = KeyGenerator.GetBytes(aes.BlockSize / 8);
                }
                // Define a stream to link the data with Cryptographic transformation 
                using (CryptoStream cs = new CryptoStream(MS, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] InputeByte = input.ConvertStringToByteArray();
                    cs.Write(InputeByte, 0, InputeByte.Length);
                }
                // Base-64 encoding is a way of taking binary data and turning it into text so that it's more easily 
                // transmitted in things like e-mail and HTML form data
                return MS.ToArray().ConvertByteArrayToBase64();
            }
        }
        /// <summary>
        /// Decrypt a string with a given Key and Salt.
        /// </summary>
        /// <param name="input">The Current String to Decrypt</param>
        /// <param name="Key">The Encryption Key</param>
        /// <param name="Salt">Needed for decryption</param>
        /// <returns>
        /// Decrypted String
        /// </returns>
        public static string Decrypt(this string input, string Key, string Salt)
        {
            // Locate a memory to write the bytes in. 
            using (MemoryStream MS = new MemoryStream())
            {
                // Advanced Encryption Standard Encryption Algorithm, it’s so powerful.
                AesManaged aes = new AesManaged();
                // Generate Encrypt Key, with a given key and pseudo byte array   
                using (PasswordDeriveBytes KeyGenerator = new PasswordDeriveBytes(Key, Encoding.UTF8.GetBytes(Salt)))
                {
                    aes.Key = KeyGenerator.GetBytes(aes.KeySize / 8);
                    aes.IV = KeyGenerator.GetBytes(aes.BlockSize / 8);
                }
                // Define a stream to link the data with Cryptographic transformation 
                using (CryptoStream cs = new CryptoStream(MS, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    // Convert from the Base64 text byte[] represention to it's byte[] again.
                    byte[] InputeByte = input.ConvertBase64ToByteArray();
                    cs.Write(InputeByte, 0, InputeByte.Length);
                }
                return MS.ToArray().ConvertByteArrayToUTF8String();
            }
        }
    }
}
