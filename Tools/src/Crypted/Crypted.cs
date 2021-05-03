//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Crypted.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Tools
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>Control memory Security</summary>
    /// <typeparam name="T">object to pass the algorithm</typeparam>
    public class Crypted<T> : object
    {
        /// <summary>The data</summary>
        private byte[] data;

        /// <summary>The key</summary>
        private byte[] key = new byte[0];

        /// <summary>The vector</summary>
        private byte[] vector = new byte[0];

        /// <summary>Initializes a new instance of the <see cref="Crypted{T}" /> class.</summary>
        /// <param name="data">The data.</param>
        public Crypted(T data)
        {
            this.data = Encrypt(data); 
        }

        /// <summary>Sets the specified data.</summary>
        /// <param name="data">The data.</param>
        public void Set(T data) 
        {
            this.data = Encrypt(data);
        }

        /// <summary>Gets this instance.</summary>
        /// <returns>Return value</returns>
        public T Get() 
        {
            return Decrypt();
        }

        /// <summary>Encrypts the specified data.</summary>
        /// <param name="data">The data.</param>
        /// <returns>Return value.</returns>
        private byte[] Encrypt(T data) 
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

        /// <summary>Decrypts this instance.</summary>
        /// <returns>Return the value</returns>
        private T Decrypt() 
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
    }
}