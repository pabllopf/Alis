// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SecureByte.cs
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
    ///     The secure byte class
    /// </summary>
    public class SecureByte
    {
        /// <summary>
        ///     The random value
        /// </summary>
        private byte _randomValue;

        /// <summary>
        ///     The value
        /// </summary>
        private byte _value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SecureByte" /> class
        /// </summary>
        /// <param name="value">The value</param>
        public SecureByte(byte value = 0) => Value = value;

        /// <summary>
        ///     Gets or sets the value of the value
        /// </summary>
        private byte Value
        {
            get
            {
                unchecked
                {
                    return (byte) (_value - _randomValue);
                }
            }

            set
            {
                unchecked
                {
                    _randomValue = SecureRandom.NextByte();
                    _value = (byte) (value + _randomValue);
                }
            }
        }

        /// <summary>
        ///     Implicitly converts a byte value to a SecureByte
        /// </summary>
        /// <param name="value">The byte value to convert</param>
        /// <returns>A SecureByte instance wrapping the value</returns>
        public static implicit operator SecureByte(byte value) => new SecureByte(value);

        /// <summary>
        ///     Implicitly converts a SecureByte to its underlying byte value
        /// </summary>
        /// <param name="value">The SecureByte to convert</param>
        /// <returns>The decrypted byte value</returns>
        public static implicit operator byte(SecureByte value) => value.Value;

        /// <summary>
        ///     Compares two SecureByte instances for equality
        /// </summary>
        /// <param name="a">The first SecureByte</param>
        /// <param name="b">The second SecureByte</param>
        /// <returns>True if the values are equal; otherwise, false</returns>
        public static bool operator ==(SecureByte a, SecureByte b) => a.Value == b.Value;

        /// <summary>
        ///     Compares two SecureByte instances for inequality
        /// </summary>
        /// <param name="a">The first SecureByte</param>
        /// <param name="b">The second SecureByte</param>
        /// <returns>True if the values are not equal; otherwise, false</returns>
        public static bool operator !=(SecureByte a, SecureByte b) => a.Value != b.Value;

        /// <summary>
        ///     Increments the SecureByte value by one
        /// </summary>
        /// <param name="a">The SecureByte to increment</param>
        /// <returns>The incremented SecureByte</returns>
        public static SecureByte operator ++(SecureByte a)
        {
            a.Value++;
            return a;
        }

        /// <summary>
        ///     Decrements the SecureByte value by one
        /// </summary>
        /// <param name="a">The SecureByte to decrement</param>
        /// <returns>The decremented SecureByte</returns>
        public static SecureByte operator --(SecureByte a)
        {
            a.Value--;
            return a;
        }

        /// <summary>
        ///     Adds two SecureByte values
        /// </summary>
        /// <param name="a">The first SecureByte</param>
        /// <param name="b">The second SecureByte</param>
        /// <returns>A new SecureByte containing the sum</returns>
        public static SecureByte operator +(SecureByte a, SecureByte b) => new SecureByte((byte) (a.Value + b.Value));

        /// <summary>
        ///     Subtracts one SecureByte from another
        /// </summary>
        /// <param name="a">The SecureByte to subtract from</param>
        /// <param name="b">The SecureByte to subtract</param>
        /// <returns>A new SecureByte containing the difference</returns>
        public static SecureByte operator -(SecureByte a, SecureByte b) => new SecureByte((byte) (a.Value - b.Value));


        /// <summary>
        ///     Multiplies two SecureByte values
        /// </summary>
        /// <param name="a">The first SecureByte</param>
        /// <param name="b">The second SecureByte</param>
        /// <returns>A new SecureByte containing the product</returns>
        public static SecureByte operator *(SecureByte a, SecureByte b) => new SecureByte((byte) (a.Value * b.Value));

        /// <summary>
        ///     Divides one SecureByte by another
        /// </summary>
        /// <param name="a">The SecureByte to divide</param>
        /// <param name="b">The SecureByte to divide by</param>
        /// <returns>A new SecureByte containing the quotient</returns>
        public static SecureByte operator /(SecureByte a, SecureByte b) => new SecureByte((byte) (a.Value / b.Value));

        /// <summary>
        ///     Returns the string representation of the decrypted value
        /// </summary>
        /// <returns>The decrypted byte value as a string</returns>
        public override string ToString() => Value.ToString();

        /// <summary>
        ///     Computes the hash code of the decrypted value
        /// </summary>
        /// <returns>The hash code of the underlying byte</returns>
        public override int GetHashCode() => Value.GetHashCode();

        /// <summary>
        ///     Determines whether the specified object equals the current SecureByte
        /// </summary>
        /// <param name="obj">The object to compare</param>
        /// <returns>True if the values are equal; otherwise, false</returns>
        public override bool Equals(object obj) => Value.Equals(((SecureByte) obj)!.Value);
    }
}