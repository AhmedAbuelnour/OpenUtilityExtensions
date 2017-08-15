using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace OpenUtilityExtensions.FileExtensions
{
    /*
     * Example Of using 
     * Encryption=>  File.Open("Ahmed.txt", FileMode.Open).Encrypt("AhmedEncypt.txt", "Ahmed", "Test");
     * Dencryption=> File.Open("AhmedEncypt.txt",FileMode.Open).Decrypt("Ahmed", "Test");
     */
    public static class EncryptionExtension
    {
        /// <summary>
        /// Encrypt a file
        /// </summary>
        /// <param name="InputFile">The Current file to encrypt</param>
        /// <param name="NewPath">The path of the new encrypted file</param>
        /// <param name="Key">The Encryption Key</param>
        /// <param name="Salt">Makes the encryption more secure</param>
        public static void Encrypt(this FileStream InputFile,string NewPath ,string Key, string Salt)
        {
            // Locate a memory to write the bytes in. 
            using (MemoryStream MS = new MemoryStream())
            {
                // Advanced Encryption Standard Encryption Algorithm, it’s so powerful.
                AesManaged aes = new AesManaged();
                // Generate Encrypt Key, with a given key and pseudo byte array   
                using (PasswordDeriveBytes KeyGenerator = new PasswordDeriveBytes(Key, Encoding.UTF8.GetBytes(Salt)))
                {
                    aes.Padding = PaddingMode.PKCS7;  
                    aes.Key = KeyGenerator.GetBytes(aes.KeySize / 8);
                    aes.IV = KeyGenerator.GetBytes(aes.BlockSize / 8);
                }
                // Define a stream to link the data with Cryptographic transformation 
                using (CryptoStream cs = new CryptoStream(MS, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    InputFile.Close();
                    byte[] Buffer = File.ReadAllBytes(InputFile.Name);
                    cs.Write(Buffer, 0, Buffer.Length);
                }
                // Write the encrypted data into the text
                File.WriteAllBytes(NewPath, MS.ToArray());
            }
        }
        /// <summary>
        /// Dencrypt a file
        /// </summary>
        /// <param name="InputFile">The Current file to encrypt</param>
        /// <param name="NewPath">The path of the new encrypted file</param>
        /// <param name="Key">The Encryption Key</param>
        /// <param name="Salt">Needed for decryption</param>
        public static void Decrypt(this FileStream InputFile, string Key, string Salt)
        {
            // Locate a memory to write the bytes in. 
            using (MemoryStream MS = new MemoryStream())
            {
                // Advanced Encryption Standard Encryption Algorithm, it’s so powerful.
                AesManaged aes = new AesManaged();
                // Generate Encrypt Key, with a given key and pseudo byte array   
                using (PasswordDeriveBytes KeyGenerator = new PasswordDeriveBytes(Key, Encoding.UTF8.GetBytes(Salt)))
                {
                    aes.Padding = PaddingMode.PKCS7;
                    aes.Key = KeyGenerator.GetBytes(aes.KeySize / 8);
                    aes.IV = KeyGenerator.GetBytes(aes.BlockSize / 8);
                }
                // Define a stream to link the data with Cryptographic transformation 
                using (CryptoStream cs = new CryptoStream(MS, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    InputFile.Close();
                    byte[] Buffer = File.ReadAllBytes(InputFile.Name);
                    cs.Write(Buffer, 0, Buffer.Length);
                }
                File.WriteAllBytes(InputFile.Name, MS.ToArray());
            }
        }
    }
}
