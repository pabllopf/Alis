// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SecureInt.cs
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
    ///     The secure int class
    /// </summary>
    public class SecureInt
    {
        /// <summary>
        ///     The random value
        /// </summary>
        private int _randomValue;

        /// <summary>
        ///     The value
        /// </summary>
        private int _value;


        /// <summary>
        ///     Initializes a new instance of the <see cref="SecureInt" /> class
        /// </summary>
        /// <param name="value">The value</param>
        public SecureInt(int value = 0) => Value = value;

        /// <summary>
        ///     Gets or sets the value of the value
        /// </summary>
        private int Value
        {
            get
            {
                unchecked
                {
                    return _value - _randomValue;
                }
            }

            set
            {
                unchecked
                {
                    _randomValue = SecureRandom.NextInt();
                    _value = value + _randomValue;
                }
            }
        }

        /// <summary>
        ///     Implicitly converts an int value to a SecureInt
        /// </summary>
        /// <param name="value">The int value to convert</param>
        /// <returns>A SecureInt instance wrapping the value</returns>
        public static implicit operator SecureInt(int value) => new SecureInt(value);

        /// <summary>
        ///     Implicitly converts a SecureInt to its underlying int value
        /// </summary>
        /// <param name="value">The SecureInt to convert</param>
        /// <returns>The decrypted int value</returns>
        public static implicit operator int(SecureInt value) => value.Value;

        /// <summary>
        ///     Compares two SecureInt instances for equality
        /// </summary>
        /// <param name="a">The first SecureInt</param>
        /// <param name="b">The second SecureInt</param>
        /// <returns>True if the values are equal; otherwise, false</returns>
        public static bool operator ==(SecureInt a, SecureInt b) => a.Value == b.Value;

        /// <summary>
        ///     Compares two SecureInt instances for inequality
        /// </summary>
        /// <param name="a">The first SecureInt</param>
        /// <param name="b">The second SecureInt</param>
        /// <returns>True if the values are not equal; otherwise, false</returns>
        public static bool operator !=(SecureInt a, SecureInt b) => a.Value != b.Value;

        /// <summary>
        ///     Increments the SecureInt value by one
        /// </summary>
        /// <param name="a">The SecureInt to increment</param>
        /// <returns>The incremented SecureInt</returns>
        public static SecureInt operator ++(SecureInt a)
        {
            a.Value++;
            return a;
        }

        /// <summary>
        ///     Decrements the SecureInt value by one
        /// </summary>
        /// <param name="a">The SecureInt to decrement</param>
        /// <returns>The decremented SecureInt</returns>
        public static SecureInt operator --(SecureInt a)
        {
            a.Value--;
            return a;
        }

        /// <summary>
        ///     Adds two SecureInt values
        /// </summary>
        /// <param name="a">The first SecureInt</param>
        /// <param name="b">The second SecureInt</param>
        /// <returns>A new SecureInt containing the sum</returns>
        public static SecureInt operator +(SecureInt a, SecureInt b) => new SecureInt(a.Value + b.Value);

        /// <summary>
        ///     Subtracts one SecureInt from another
        /// </summary>
        /// <param name="a">The SecureInt to subtract from</param>
        /// <param name="b">The SecureInt to subtract</param>
        /// <returns>A new SecureInt containing the difference</returns>
        public static SecureInt operator -(SecureInt a, SecureInt b) => new SecureInt(a.Value - b.Value);

        /// <summary>
        ///     Multiplies two SecureInt values
        /// </summary>
        /// <param name="a">The first SecureInt</param>
        /// <param name="b">The second SecureInt</param>
        /// <returns>A new SecureInt containing the product</returns>
        public static SecureInt operator *(SecureInt a, SecureInt b) => new SecureInt(a.Value * b.Value);

        /// <summary>
        ///     Divides one SecureInt by another
        /// </summary>
        /// <param name="a">The SecureInt to divide</param>
        /// <param name="b">The SecureInt to divide by</param>
        /// <returns>A new SecureInt containing the quotient</returns>
        public static SecureInt operator /(SecureInt a, SecureInt b) => new SecureInt(a.Value / b.Value);

        /// <summary>
        ///     Returns the string representation of the decrypted value
        /// </summary>
        /// <returns>The decrypted int value as a string</returns>
        public override string ToString() => Value.ToString();

        /// <summary>
        ///     Computes the hash code of the decrypted value
        /// </summary>
        /// <returns>The hash code of the underlying int</returns>
        public override int GetHashCode() => Value.GetHashCode();

        /// <summary>
        ///     Determines whether the specified object equals the current SecureInt
        /// </summary>
        /// <param name="obj">The object to compare</param>
        /// <returns>True if the values are equal; otherwise, false</returns>
        public override bool Equals(object obj) => Value.Equals((obj as SecureInt).Value);
    }
}