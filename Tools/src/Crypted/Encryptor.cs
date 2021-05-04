//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Encryptor.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Tools
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>Util to encrypt data</summary>
    public static class Encryptor
    {
        /// <summary>The keysize</summary>
        private static int Keysize = 256;

        /// <summary>The derivation iterations</summary>
        private static int DerivationIterations = 1000;

        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "abc123";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "abc123";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        /// <summary>Decrypts this instance.</summary>
        /// <returns>Return the value</returns>
        public static T Decrypt<T>(byte[] key, byte[] vector, byte[] data)
        {
            Aes algorithm = Aes.Create();

            algorithm.Key = key;
            algorithm.IV = vector;

            ICryptoTransform crypto = algorithm.CreateDecryptor(algorithm.Key, algorithm.IV);
            using (MemoryStream memoryStream = new MemoryStream(data))
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, crypto, CryptoStreamMode.Read))
                {
                    using (StreamReader streamReader = new StreamReader(cryptoStream))
                    {
                        return (T)Convert.ChangeType(streamReader.ReadToEnd(), typeof(T)) ?? throw new NullReferenceException(typeof(T).GetType().FullName);
                    }
                }
            }
        }

        /// <summary>Encrypts the specified data.</summary>
        /// <param name="data">The data.</param>
        /// <returns>Return value.</returns>
        public static byte[] Encrypt<T>(T data, byte[] key, byte[] vector)
        {
            Aes algorithm = Aes.Create();

            if (key.Length == 0 || vector.Length == 0)
            {
                key = algorithm.Key;
                vector = algorithm.IV;
            }

            algorithm.Key = key;
            algorithm.IV = vector;

            ICryptoTransform crypto = algorithm.CreateEncryptor(algorithm.Key, algorithm.IV);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, crypto, CryptoStreamMode.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                    {
                        streamWriter.Write(data);
                    }

                    return memoryStream.ToArray();
                }
            }
        }

        /// <summary>Generate256s the bits of random entropy.</summary>
        /// <returns>return bytes</returns>
        private static byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[32];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(randomBytes);
            }

            return randomBytes;
        }
    }
}