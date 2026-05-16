// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SecureChar.cs
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
    ///     The secure char class
    /// </summary>
    public class SecureChar
    {
        /// <summary>
        ///     The random value
        /// </summary>
        private char _randomValue;

        /// <summary>
        ///     The value
        /// </summary>
        private char _value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SecureChar" /> class
        /// </summary>
        /// <param name="value">The value</param>
        public SecureChar(char value = '\x0000') => Value = value;

        /// <summary>
        ///     Gets or sets the value of the value
        /// </summary>
        private char Value
        {
            get
            {
                unchecked
                {
                    return (char) (_value - _randomValue);
                }
            }

            set
            {
                unchecked
                {
                    _randomValue = SecureRandom.NextChar();
                    _value = (char) (value + _randomValue);
                }
            }
        }

        /// <summary>
        ///     Implicitly converts a char value to a SecureChar
        /// </summary>
        /// <param name="value">The char value to convert</param>
        /// <returns>A SecureChar instance wrapping the value</returns>
        public static implicit operator SecureChar(char value) => new SecureChar(value);

        /// <summary>
        ///     Implicitly converts a SecureChar to its underlying char value
        /// </summary>
        /// <param name="value">The SecureChar to convert</param>
        /// <returns>The decrypted char value</returns>
        public static implicit operator char(SecureChar value) => value.Value;

        /// <summary>
        ///     Compares two SecureChar instances for equality
        /// </summary>
        /// <param name="a">The first SecureChar</param>
        /// <param name="b">The second SecureChar</param>
        /// <returns>True if the values are equal; otherwise, false</returns>
        public static bool operator ==(SecureChar a, SecureChar b) => a.Value == b.Value;

        /// <summary>
        ///     Compares two SecureChar instances for inequality
        /// </summary>
        /// <param name="a">The first SecureChar</param>
        /// <param name="b">The second SecureChar</param>
        /// <returns>True if the values are not equal; otherwise, false</returns>
        public static bool operator !=(SecureChar a, SecureChar b) => a.Value != b.Value;

        /// <summary>
        ///     Adds two SecureChar values
        /// </summary>
        /// <param name="a">The first SecureChar</param>
        /// <param name="b">The second SecureChar</param>
        /// <returns>A new SecureChar containing the sum</returns>
        public static SecureChar operator +(SecureChar a, SecureChar b) => new SecureChar((char) (a.Value + b.Value));

        /// <summary>
        ///     Subtracts one SecureChar from another
        /// </summary>
        /// <param name="a">The SecureChar to subtract from</param>
        /// <param name="b">The SecureChar to subtract</param>
        /// <returns>A new SecureChar containing the difference</returns>
        public static SecureChar operator -(SecureChar a, SecureChar b) => new SecureChar((char) (a.Value - b.Value));

        /// <summary>
        ///     Multiplies two SecureChar values
        /// </summary>
        /// <param name="a">The first SecureChar</param>
        /// <param name="b">The second SecureChar</param>
        /// <returns>A new SecureChar containing the product</returns>
        public static SecureChar operator *(SecureChar a, SecureChar b) => new SecureChar((char) (a.Value * b.Value));

        /// <summary>
        ///     Divides one SecureChar by another
        /// </summary>
        /// <param name="a">The SecureChar to divide</param>
        /// <param name="b">The SecureChar to divide by</param>
        /// <returns>A new SecureChar containing the quotient</returns>
        public static SecureChar operator /(SecureChar a, SecureChar b) => new SecureChar((char) (a.Value / b.Value));

        /// <summary>
        ///     Returns the string representation of the decrypted value
        /// </summary>
        /// <returns>The decrypted char value as a string</returns>
        public override string ToString() => Value.ToString();

        /// <summary>
        ///     Computes the hash code of the decrypted value
        /// </summary>
        /// <returns>The hash code of the underlying char</returns>
        public override int GetHashCode() => Value.GetHashCode();

        /// <summary>
        ///     Determines whether the specified object equals the current SecureChar
        /// </summary>
        /// <param name="obj">The object to compare</param>
        /// <returns>True if the values are equal; otherwise, false</returns>
        public override bool Equals(object obj) => Value.Equals((obj as SecureChar).Value);
    }
}