

namespace Alis.Extension.Security
{
    /// <summary>
    ///     The secure string class
    /// </summary>
    public class SecureString
    {
        /// <summary>
        ///     The key
        /// </summary>
        private readonly char secret;

        /// <summary>
        ///     The encrypted value
        /// </summary>
        private string encryptedValue;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SecureString" /> class
        /// </summary>
        /// <param name="value">The value</param>
        public SecureString(string value)
        {
            secret = GenerateKey();
            SetValue(value);
        }

        /// <summary>
        ///     Sets the value using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        internal void SetValue(string value)
        {
            encryptedValue = EncryptDecrypt(value, secret);
        }

        /// <summary>
        ///     Gets the value
        /// </summary>
        /// <returns>The string</returns>
        public string GetValue() => EncryptDecrypt(encryptedValue, secret);

        /// <summary>
        ///     Encrypts the decrypt using the specified text to encrypt
        /// </summary>
        /// <param name="textToEncrypt">The text to encrypt</param>
        /// <param name="key">The key</param>
        /// <returns>The string</returns>
        private static string EncryptDecrypt(string textToEncrypt, char key)
        {
            char[] buffer = textToEncrypt.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] ^= key;
            }

            return new string(buffer);
        }

        /// <summary>
        ///     Generates the key
        /// </summary>
        /// <returns>The char</returns>
        private static char GenerateKey() => SecureRandom.NextChar();
    }
}