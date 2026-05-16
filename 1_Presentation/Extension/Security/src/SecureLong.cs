// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SecureLong.cs
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
    ///     The secure long class
    /// </summary>
    public class SecureLong
    {
        /// <summary>
        ///     The random value
        /// </summary>
        private long _randomValue;

        /// <summary>
        ///     The value
        /// </summary>
        private long _value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SecureLong" /> class
        /// </summary>
        /// <param name="value">The value</param>
        public SecureLong(long value = 0L) => Value = value;

        /// <summary>
        ///     Gets or sets the value of the value
        /// </summary>
        private long Value
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
                    _randomValue = SecureRandom.NextLong();
                    _value = value + _randomValue;
                }
            }
        }

        /// <summary>
        ///     Implicitly converts a long value to a SecureLong
        /// </summary>
        /// <param name="value">The long value to convert</param>
        /// <returns>A SecureLong instance wrapping the value</returns>
        public static implicit operator SecureLong(long value) => new SecureLong(value);

        /// <summary>
        ///     Implicitly converts a SecureLong to its underlying long value
        /// </summary>
        /// <param name="value">The SecureLong to convert</param>
        /// <returns>The decrypted long value</returns>
        public static implicit operator long(SecureLong value) => value.Value;

        /// <summary>
        ///     Compares two SecureLong instances for equality
        /// </summary>
        /// <param name="a">The first SecureLong</param>
        /// <param name="b">The second SecureLong</param>
        /// <returns>True if the values are equal; otherwise, false</returns>
        public static bool operator ==(SecureLong a, SecureLong b) => a.Value == b.Value;

        /// <summary>
        ///     Compares two SecureLong instances for inequality
        /// </summary>
        /// <param name="a">The first SecureLong</param>
        /// <param name="b">The second SecureLong</param>
        /// <returns>True if the values are not equal; otherwise, false</returns>
        public static bool operator !=(SecureLong a, SecureLong b) => a.Value != b.Value;

        /// <summary>
        ///     Increments the SecureLong value by one
        /// </summary>
        /// <param name="a">The SecureLong to increment</param>
        /// <returns>The incremented SecureLong</returns>
        public static SecureLong operator ++(SecureLong a)
        {
            a.Value++;
            return a;
        }

        /// <summary>
        ///     Decrements the SecureLong value by one
        /// </summary>
        /// <param name="a">The SecureLong to decrement</param>
        /// <returns>The decremented SecureLong</returns>
        public static SecureLong operator --(SecureLong a)
        {
            a.Value--;
            return a;
        }

        /// <summary>
        ///     Adds two SecureLong values
        /// </summary>
        /// <param name="a">The first SecureLong</param>
        /// <param name="b">The second SecureLong</param>
        /// <returns>A new SecureLong containing the sum</returns>
        public static SecureLong operator +(SecureLong a, SecureLong b) => new SecureLong(a.Value + b.Value);

        /// <summary>
        ///     Subtracts one SecureLong from another
        /// </summary>
        /// <param name="a">The SecureLong to subtract from</param>
        /// <param name="b">The SecureLong to subtract</param>
        /// <returns>A new SecureLong containing the difference</returns>
        public static SecureLong operator -(SecureLong a, SecureLong b) => new SecureLong(a.Value - b.Value);

        /// <summary>
        ///     Multiplies two SecureLong values
        /// </summary>
        /// <param name="a">The first SecureLong</param>
        /// <param name="b">The second SecureLong</param>
        /// <returns>A new SecureLong containing the product</returns>
        public static SecureLong operator *(SecureLong a, SecureLong b) => new SecureLong(a.Value * b.Value);

        /// <summary>
        ///     Divides one SecureLong by another
        /// </summary>
        /// <param name="a">The SecureLong to divide</param>
        /// <param name="b">The SecureLong to divide by</param>
        /// <returns>A new SecureLong containing the quotient</returns>
        public static SecureLong operator /(SecureLong a, SecureLong b) => new SecureLong(a.Value / b.Value);

        /// <summary>
        ///     Returns the string representation of the decrypted value
        /// </summary>
        /// <returns>The decrypted long value as a string</returns>
        public override string ToString() => Value.ToString();

        /// <summary>
        ///     Computes the hash code of the decrypted value
        /// </summary>
        /// <returns>The hash code of the underlying long</returns>
        public override int GetHashCode() => Value.GetHashCode();

        /// <summary>
        ///     Determines whether the specified object equals the current SecureLong
        /// </summary>
        /// <param name="obj">The object to compare</param>
        /// <returns>True if the values are equal; otherwise, false</returns>
        public override bool Equals(object obj) => Value.Equals((obj as SecureLong).Value);
    }
}