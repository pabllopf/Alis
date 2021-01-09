//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Crypted.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Tools
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Security;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>Crypted var in memory</summary>
    /// <typeparam name="T"></typeparam>
    public class Crypted<T> : object
	{
        /// <summary>The aes alg</summary>
        private Aes aesAlg = Aes.Create();

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
				// Create a decryptor to perform the stream transform.
				ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

				// Create the streams used for decryption.
				using (MemoryStream msDecrypt = new MemoryStream(data))
				{
					using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
					{
						using (StreamReader srDecrypt = new StreamReader(csDecrypt))
						{
							return (T)Convert.ChangeType(srDecrypt.ReadToEnd(), typeof(T));
						}
					}
				}
			}

			set 
			{
				// Create an encryptor to perform the stream transform.
				ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

				// Create the streams used for encryption.
				using (MemoryStream msEncrypt = new MemoryStream())
				{
					using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
					{
						using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
						{
							swEncrypt.Write(value);
						}

						this.data = msEncrypt.ToArray();
					}
				}
			}
		}
    }
}
/*

		#region VALUE

		/// <summary>
		/// Gets or sets the crypted value.
		/// </summary>
		/// <value>The value.</value>
		public T Value
		{
			get
			{
				if (Data == null)
					return default(T);
				else
					return (T)ByteArrayToObject(XOR(this.Data, this.Key));
			}

			set
			{
				if (value == null)
					value = default(T);

				this.Key = new byte[ObjectToByteArray(value).Length];
				new Random().NextBytes(Key);

				this.Data = XOR(ObjectToByteArray(value), this.Key);
			}
		}

		#endregion

		#region PRIVATE_PROPERTIES

		private byte[] Data;
		private byte[] Key;

		#endregion

		#region CONSTRUCTOR

		/// <summary>
		/// Initializes a new instance of the <see cref="CryptedData"/> class with the default value.
		/// </summary>
		public Crypted()
		{
			Value = default(T);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CryptedData"/> class with a value.
		/// </summary>
		/// <param name="data">T</param>
		public Crypted(T data)
		{
			if (data == null)
				Value = default(T);
			else
				Value = data;
		}

		#endregion

		#region OPERATOR_OVERRIDE

		public static bool operator == (Crypted<T> v1, T v2)
		{
			return v1.Value.Equals(v2);
		}

		public static bool operator != (Crypted<T> v1, T v2)
		{
			return !v1.Value.Equals(v2);
		}

		#endregion

		#region OBJECT_OVERRIDE

		public override string ToString()
		{
			return Value.ToString();
		}

		public override bool Equals(object obj)
		{
			return Value.Equals((T)obj);
		}

		public new Type GetType()
		{
			return typeof(T);
		}

		public override int GetHashCode()
		{
			return Value.GetHashCode();
		}

		#endregion

		#region private methods

		/// <summary>
		/// Object to byte array.
		/// </summary>
		/// <returns>The byte array</returns>
		/// <param name="obj">Object</param>
		private byte[] ObjectToByteArray(Object obj)
		{
			if (obj == null)
				return null;

			BinaryFormatter bf = new BinaryFormatter();
			using (MemoryStream ms = new MemoryStream())
			{
				bf.Serialize(ms, obj);
				return ms.ToArray();
			}
		}

		/// <summary>
		/// Byte array to object.
		/// </summary>
		/// <returns>The object conversion.</returns>
		/// <param name="arrBytes">Byte Array.</param>
		private Object ByteArrayToObject(byte[] bytes)
		{
			if (bytes == null)
				return null;

			BinaryFormatter bf = new BinaryFormatter();
			using (MemoryStream ms = new MemoryStream())
			{
				ms.Write(bytes, 0, bytes.Length);
				ms.Seek(0, SeekOrigin.Begin);
				return (Object)bf.Deserialize(ms);
			}
		}

		/// <summary>
		/// XOR Crypt
		/// </summary>
		/// <param name="data">Data.</param>
		/// <param name="key">Key.</param>
		private byte[] XOR(byte[] data, byte[] key)
		{
			byte[] xor = new byte[data.Length];

			for (int i = 0; i < data.Length; i++)
				xor[i] = (byte)(data[i] ^ key[i]);

			return xor;
		}

		/// <summary>
		/// Gets the new key.
		/// </summary>
		/// <param name="value">Value.</param>
		private void GetNewKey(object value)
		{
			this.Key = new byte[ObjectToByteArray(value).Length];
			new Random().NextBytes(Key);
		}

		#endregion
	}
}*/