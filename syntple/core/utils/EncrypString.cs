using System.Security.Cryptography;
using System.Text;

namespace syntple.core.utils
{
    public class EncrypString
    {
        /// <summary>
        /// Ecnrypt string with key (32 byte)
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string encrypt(string plainText, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key.PadRight(32, ' '));  // a key of 32 byte
                aesAlg.IV = new byte[16];  // IV initialize all byte to 0 

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        /// <summary>
        /// decrypt string with key (32 byte)
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string decrypt(string cipherText, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key.PadRight(32, ' '));  // use key to 32 byte
                aesAlg.IV = new byte[16];  // IV initialize with all byte to 0 

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                {
                    return srDecrypt.ReadToEnd();
                }
            }
        }

    }
}
