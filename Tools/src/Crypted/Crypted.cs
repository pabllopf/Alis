//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Crypted.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Tools
{
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
        public Crypted(T data) => this.data = Encryptor.Encrypt<T>(data, ref key, ref vector);

        /// <summary>Sets the specified data.</summary>
        /// <param name="data">The data.</param>
        public void Set(T data) => this.data = Encryptor.Encrypt<T>(data, ref key, ref vector);

        /// <summary>Gets this instance.</summary>
        /// <returns>Return value</returns>
        public T Get() => Encryptor.Decrypt<T>(ref key, ref vector, data);
    }
}