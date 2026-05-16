// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SecureDecimal.cs
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

using System.Globalization;

namespace Alis.Extension.Security
{
    /// <summary>
    ///     The secure decimal class
    /// </summary>
    public class SecureDecimal
    {
        /// <summary>
        ///     The random value
        /// </summary>
        private decimal _randomValue;

        /// <summary>
        ///     The value
        /// </summary>
        private decimal _value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SecureDecimal" /> class
        /// </summary>
        /// <param name="value">The value</param>
        public SecureDecimal(decimal value = 0.0m) => Value = value;

        /// <summary>
        ///     Gets or sets the value of the value
        /// </summary>
        private decimal Value
        {
            get => _value - _randomValue;

            set
            {
                unchecked
                {
                    _randomValue = SecureRandom.NextDecimal(-1024, 1024);
                    _value = value + _randomValue;
                }
            }
        }

        /// <summary>
        ///     Implicitly converts a decimal value to a SecureDecimal
        /// </summary>
        /// <param name="value">The decimal value to convert</param>
        /// <returns>A SecureDecimal instance wrapping the value</returns>
        public static implicit operator SecureDecimal(decimal value) => new SecureDecimal(value);

        /// <summary>
        ///     Implicitly converts a SecureDecimal to its underlying decimal value
        /// </summary>
        /// <param name="value">The SecureDecimal to convert</param>
        /// <returns>The decrypted decimal value</returns>
        public static implicit operator decimal(SecureDecimal value) => value.Value;

        /// <summary>
        ///     Compares two SecureDecimal instances for equality
        /// </summary>
        /// <param name="a">The first SecureDecimal</param>
        /// <param name="b">The second SecureDecimal</param>
        /// <returns>True if the values are equal; otherwise, false</returns>
        public static bool operator ==(SecureDecimal a, SecureDecimal b) => a.Value == b.Value;

        /// <summary>
        ///     Compares two SecureDecimal instances for inequality
        /// </summary>
        /// <param name="a">The first SecureDecimal</param>
        /// <param name="b">The second SecureDecimal</param>
        /// <returns>True if the values are not equal; otherwise, false</returns>
        public static bool operator !=(SecureDecimal a, SecureDecimal b) => a.Value != b.Value;

        /// <summary>
        ///     Increments the SecureDecimal value by one
        /// </summary>
        /// <param name="a">The SecureDecimal to increment</param>
        /// <returns>The incremented SecureDecimal</returns>
        public static SecureDecimal operator ++(SecureDecimal a)
        {
            a.Value++;
            return a;
        }

        /// <summary>
        ///     Decrements the SecureDecimal value by one
        /// </summary>
        /// <param name="a">The SecureDecimal to decrement</param>
        /// <returns>The decremented SecureDecimal</returns>
        public static SecureDecimal operator --(SecureDecimal a)
        {
            a.Value--;
            return a;
        }

        /// <summary>
        ///     Adds two SecureDecimal values
        /// </summary>
        /// <param name="a">The first SecureDecimal</param>
        /// <param name="b">The second SecureDecimal</param>
        /// <returns>A new SecureDecimal containing the sum</returns>
        public static SecureDecimal operator +(SecureDecimal a, SecureDecimal b) => new SecureDecimal(a.Value + b.Value);


        /// <summary>
        ///     Subtracts one SecureDecimal from another
        /// </summary>
        /// <param name="a">The SecureDecimal to subtract from</param>
        /// <param name="b">The SecureDecimal to subtract</param>
        /// <returns>A new SecureDecimal containing the difference</returns>
        public static SecureDecimal operator -(SecureDecimal a, SecureDecimal b) => new SecureDecimal(a.Value - b.Value);

        /// <summary>
        ///     Multiplies two SecureDecimal values
        /// </summary>
        /// <param name="a">The first SecureDecimal</param>
        /// <param name="b">The second SecureDecimal</param>
        /// <returns>A new SecureDecimal containing the product</returns>
        public static SecureDecimal operator *(SecureDecimal a, SecureDecimal b) => new SecureDecimal(a.Value * b.Value);

        /// <summary>
        ///     Divides one SecureDecimal by another
        /// </summary>
        /// <param name="a">The SecureDecimal to divide</param>
        /// <param name="b">The SecureDecimal to divide by</param>
        /// <returns>A new SecureDecimal containing the quotient</returns>
        public static SecureDecimal operator /(SecureDecimal a, SecureDecimal b) => new SecureDecimal(a.Value / b.Value);

        /// <summary>
        ///     Returns the string representation of the decrypted value
        /// </summary>
        /// <returns>The decrypted decimal value as a string</returns>
        public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);

        /// <summary>
        ///     Computes the hash code of the decrypted value
        /// </summary>
        /// <returns>The hash code of the underlying decimal</returns>
        public override int GetHashCode() => Value.GetHashCode();

        /// <summary>
        ///     Determines whether the specified object equals the current SecureDecimal
        /// </summary>
        /// <param name="obj">The object to compare</param>
        /// <returns>True if the values are equal; otherwise, false</returns>
        public override bool Equals(object obj) => Value.Equals((obj as SecureDecimal).Value);
    }
}