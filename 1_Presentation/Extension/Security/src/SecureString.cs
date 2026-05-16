// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SecureString.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

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
        ///     Sets the encrypted value using XOR cipher with the secret key
        /// </summary>
        /// <param name="value">The plain text value to encrypt and store</param>
        internal void SetValue(string value)
        {
            encryptedValue = EncryptDecrypt(value, secret);
        }

        /// <summary>
        ///     Gets the decrypted plain text value
        /// </summary>
        /// <returns>The decrypted string value</returns>
        public string GetValue() => EncryptDecrypt(encryptedValue, secret);

        /// <summary>
        ///     Encrypts or decrypts a string using XOR cipher with the given key
        /// </summary>
        /// <param name="textToEncrypt">The text to encrypt or decrypt</param>
        /// <param name="key">The XOR key character</param>
        /// <returns>The transformed string</returns>
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
        ///     Generates a random key character for XOR encryption
        /// </summary>
        /// <returns>A random char to use as encryption key</returns>
        private static char GenerateKey() => SecureRandom.NextChar();
    }
}