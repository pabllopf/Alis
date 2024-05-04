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

using System;

namespace Alis.Core.Aspect.Security
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