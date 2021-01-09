//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Crypted.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Tools
{
    using System;
    using System.IO;
    using System.Security.Cryptography;

    /// <summary>Control memory Security</summary>
    /// <typeparam name="T">object to pass the algorithm</typeparam>
    public class Crypted<T> : object
    {
        /// <summary>create algorithm</summary>
        private Aes algorithm = Aes.Create();

        /// <summary>The data</summary>
        private byte[] data;

        /// <summary>Initializes a new instance of the <see cref="Crypted{T}" /> class.</summary>
        /// <param name="data">The data.</param>
        public Crypted(T data)
        {
            Value = (data == null) ? default : data;
        }

        /// <summary>Gets or sets the value.</summary>
        /// <value>The value.</value>
        public T Value
        {
            get
            {
                ICryptoTransform decryptor = algorithm.CreateDecryptor(algorithm.Key, algorithm.IV);

                using (MemoryStream memoryStream = new MemoryStream(data))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            return (T)Convert.ChangeType(streamReader.ReadToEnd(), typeof(T));
                        }
                    }
                }
            }

            set
            {
                ICryptoTransform encryptor = algorithm.CreateEncryptor(algorithm.Key, algorithm.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(value);
                        }

                        this.data = memoryStream.ToArray();
                    }
                }
            }
        }
    }
}