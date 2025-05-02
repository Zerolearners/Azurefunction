using System.Security.Cryptography;
using CCA.Util;
namespace ai_finder_be_schedulers_donetcore.Common
{
    public class CommonFunctions
    {
        public byte[] Encrypt(byte[] plainBytes, byte[] key)
        {
            byte[] encryptedBytes = null;

            // Set up the encryption objects
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;

                // Encrypt the input plaintext using the AES algorithm
                using (ICryptoTransform encryptor = aes.CreateEncryptor())
                {
                    encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
                }
            }

            return encryptedBytes;
        }

        public byte[] Decrypt(byte[] cipherBytes, byte[] key)
        {
            byte[] decryptedBytes = null;

            // Set up the encryption objects
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;

                // Decrypt the input ciphertext using the AES algorithm
                using (ICryptoTransform decryptor = aes.CreateDecryptor())
                {
                    decryptedBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                }
            }

            return decryptedBytes;
        }

    }
}