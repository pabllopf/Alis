// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SecureFloat.cs
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
    ///     The secure float class
    /// </summary>
    public class SecureFloat
    {
        /// <summary>
        ///     The random value
        /// </summary>
        private float _randomValue;

        /// <summary>
        ///     The value
        /// </summary>
        private float _value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SecureFloat" /> class
        /// </summary>
        /// <param name="value">The value</param>
        public SecureFloat(float value = 0.0f) => Value = value;

        /// <summary>
        ///     Gets or sets the value of the value
        /// </summary>
        private float Value
        {
            get => _value - _randomValue;

            set
            {
                unchecked
                {
                    _randomValue = SecureRandom.NextFloat(-1024, 1024);
                    _value = value + _randomValue;
                }
            }
        }

        /// <summary>
        ///     Implicitly converts a float value to a SecureFloat
        /// </summary>
        /// <param name="value">The float value to convert</param>
        /// <returns>A SecureFloat instance wrapping the value</returns>
        public static implicit operator SecureFloat(float value) => new SecureFloat(value);

        /// <summary>
        ///     Implicitly converts a SecureFloat to its underlying float value
        /// </summary>
        /// <param name="value">The SecureFloat to convert</param>
        /// <returns>The decrypted float value</returns>
        public static implicit operator float(SecureFloat value) => value.Value;

        /// <summary>
        ///     Compares two SecureFloat instances for equality within 0.01 tolerance
        /// </summary>
        /// <param name="a">The first SecureFloat</param>
        /// <param name="b">The second SecureFloat</param>
        /// <returns>True if the values are approximately equal; otherwise, false</returns>
        public static bool operator ==(SecureFloat a, SecureFloat b) => SecureRandom.Abs(a.Value - b.Value) < 0.01f;

        /// <summary>
        ///     Compares two SecureFloat instances for inequality within 0.01 tolerance
        /// </summary>
        /// <param name="a">The first SecureFloat</param>
        /// <param name="b">The second SecureFloat</param>
        /// <returns>True if the values are not approximately equal; otherwise, false</returns>
        public static bool operator !=(SecureFloat a, SecureFloat b) => SecureRandom.Abs(a.Value - b.Value) > 0.01f;

        /// <summary>
        ///     Increments the SecureFloat value by one
        /// </summary>
        /// <param name="a">The SecureFloat to increment</param>
        /// <returns>The incremented SecureFloat</returns>
        public static SecureFloat operator ++(SecureFloat a)
        {
            a.Value++;
            return a;
        }

        /// <summary>
        ///     Decrements the SecureFloat value by one
        /// </summary>
        /// <param name="a">The SecureFloat to decrement</param>
        /// <returns>The decremented SecureFloat</returns>
        public static SecureFloat operator --(SecureFloat a)
        {
            a.Value--;
            return a;
        }

        /// <summary>
        ///     Adds two SecureFloat values
        /// </summary>
        /// <param name="a">The first SecureFloat</param>
        /// <param name="b">The second SecureFloat</param>
        /// <returns>A new SecureFloat containing the sum</returns>
        public static SecureFloat operator +(SecureFloat a, SecureFloat b) => new SecureFloat(a.Value + b.Value);

        /// <summary>
        ///     Subtracts one SecureFloat from another
        /// </summary>
        /// <param name="a">The SecureFloat to subtract from</param>
        /// <param name="b">The SecureFloat to subtract</param>
        /// <returns>A new SecureFloat containing the difference</returns>
        public static SecureFloat operator -(SecureFloat a, SecureFloat b) => new SecureFloat(a.Value - b.Value);

        /// <summary>
        ///     Multiplies two SecureFloat values
        /// </summary>
        /// <param name="a">The first SecureFloat</param>
        /// <param name="b">The second SecureFloat</param>
        /// <returns>A new SecureFloat containing the product</returns>
        public static SecureFloat operator *(SecureFloat a, SecureFloat b) => new SecureFloat(a.Value * b.Value);

        /// <summary>
        ///     Divides one SecureFloat by another
        /// </summary>
        /// <param name="a">The SecureFloat to divide</param>
        /// <param name="b">The SecureFloat to divide by</param>
        /// <returns>A new SecureFloat containing the quotient</returns>
        public static SecureFloat operator /(SecureFloat a, SecureFloat b) => new SecureFloat(a.Value / b.Value);

        /// <summary>
        ///     Returns the string representation of the decrypted value
        /// </summary>
        /// <returns>The decrypted float value as a string</returns>
        public override string ToString() => Value.ToString();

        /// <summary>
        ///     Computes the hash code of the decrypted value
        /// </summary>
        /// <returns>The hash code of the underlying float</returns>
        public override int GetHashCode() => Value.GetHashCode();

        /// <summary>
        ///     Determines whether the specified object equals the current SecureFloat
        /// </summary>
        /// <param name="obj">The object to compare</param>
        /// <returns>True if the values are equal; otherwise, false</returns>
        public override bool Equals(object obj) => Value.Equals((obj as SecureFloat).Value);
    }
}