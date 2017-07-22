using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GenericAsymethricCipher
{
    public static class CipherUtility
    {
        #region public properties

        private const string Password = "put your password here";
        private const string Salt = "put your salt here";
        #endregion
        /// <summary>
        /// Inheritance Hierarchy
        /// System.Object
        /// System.Security.Cryptography.SymmetricAlgorithm
        /// System.Security.Cryptography.Aes
        /// System.Security.Cryptography.DES
        /// System.Security.Cryptography.RC2
        /// System.Security.Cryptography.Rijndael
        /// System.Security.Cryptography.TripleDES
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string Encrypt<T>(string value, string password = Password, string salt = Salt)
            where T : SymmetricAlgorithm, new()
        {
            DeriveBytes rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt));

            SymmetricAlgorithm algorithm = new T();

            var rgbKey = rgb.GetBytes(algorithm.KeySize >> 3);
            var rgbIV = rgb.GetBytes(algorithm.BlockSize >> 3);

            var transform = algorithm.CreateEncryptor(rgbKey, rgbIV);

            using (var buffer = new MemoryStream())
            {
                using (var stream = new CryptoStream(buffer, transform, CryptoStreamMode.Write))
                {
                    using (var writer = new StreamWriter(stream, Encoding.Unicode))
                    {
                        writer.Write(value);
                    }
                }

                return Convert.ToBase64String(buffer.ToArray());
            }
        }

        public static string Decrypt<T>(string text, string password = Password, string salt = Salt)
            where T : SymmetricAlgorithm, new()
        {
            DeriveBytes rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt));

            SymmetricAlgorithm algorithm = new T();

            var rgbKey = rgb.GetBytes(algorithm.KeySize >> 3);
            var rgbIV = rgb.GetBytes(algorithm.BlockSize >> 3);

            var transform = algorithm.CreateDecryptor(rgbKey, rgbIV);

            using (var buffer = new MemoryStream(Convert.FromBase64String(text)))
            {
                using (var stream = new CryptoStream(buffer, transform, CryptoStreamMode.Read))
                {
                    using (var reader = new StreamReader(stream, Encoding.Unicode))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
    }
}