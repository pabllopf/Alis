// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SecureDouble.cs
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
    ///     The secure double class
    /// </summary>
    public class SecureDouble
    {
        /// <summary>
        ///     The random value
        /// </summary>
        private double _randomValue;

        /// <summary>
        ///     The value
        /// </summary>
        private double _value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SecureDouble" /> class
        /// </summary>
        /// <param name="value">The value</param>
        public SecureDouble(double value = 0.0d) => Value = value;

        /// <summary>
        ///     Gets or sets the value of the value
        /// </summary>
        private double Value
        {
            get => _value - _randomValue;

            set
            {
                unchecked
                {
                    _randomValue = SecureRandom.NextDouble(-1024, 1024);
                    _value = value + _randomValue;
                }
            }
        }

        /// <summary>
        ///     Implicitly converts a double value to a SecureDouble
        /// </summary>
        /// <param name="value">The double value to convert</param>
        /// <returns>A SecureDouble instance wrapping the value</returns>
        public static implicit operator SecureDouble(double value) => new SecureDouble(value);

        /// <summary>
        ///     Implicitly converts a SecureDouble to its underlying double value
        /// </summary>
        /// <param name="value">The SecureDouble to convert</param>
        /// <returns>The decrypted double value</returns>
        public static implicit operator double(SecureDouble value) => value.Value;

        /// <summary>
        ///     Compares two SecureDouble instances for equality within epsilon tolerance
        /// </summary>
        /// <param name="a">The first SecureDouble</param>
        /// <param name="b">The second SecureDouble</param>
        /// <returns>True if the values are approximately equal; otherwise, false</returns>
        public static bool operator ==(SecureDouble a, SecureDouble b) => SecureRandom.Abs((float) (a.Value - b.Value)) < float.Epsilon;

        /// <summary>
        ///     Compares two SecureDouble instances for inequality within epsilon tolerance
        /// </summary>
        /// <param name="a">The first SecureDouble</param>
        /// <param name="b">The second SecureDouble</param>
        /// <returns>True if the values are not approximately equal; otherwise, false</returns>
        public static bool operator !=(SecureDouble a, SecureDouble b) => SecureRandom.Abs((float) (a.Value - b.Value)) > float.Epsilon;

        /// <summary>
        ///     Increments the SecureDouble value by one
        /// </summary>
        /// <param name="a">The SecureDouble to increment</param>
        /// <returns>The incremented SecureDouble</returns>
        public static SecureDouble operator ++(SecureDouble a)
        {
            a.Value++;
            return a;
        }

        /// <summary>
        ///     Decrements the SecureDouble value by one
        /// </summary>
        /// <param name="a">The SecureDouble to decrement</param>
        /// <returns>The decremented SecureDouble</returns>
        public static SecureDouble operator --(SecureDouble a)
        {
            a.Value--;
            return a;
        }

        /// <summary>
        ///     Adds two SecureDouble values
        /// </summary>
        /// <param name="a">The first SecureDouble</param>
        /// <param name="b">The second SecureDouble</param>
        /// <returns>A new SecureDouble containing the sum</returns>
        public static SecureDouble operator +(SecureDouble a, SecureDouble b) => new SecureDouble(a.Value + b.Value);

        /// <summary>
        ///     Subtracts one SecureDouble from another
        /// </summary>
        /// <param name="a">The SecureDouble to subtract from</param>
        /// <param name="b">The SecureDouble to subtract</param>
        /// <returns>A new SecureDouble containing the difference</returns>
        public static SecureDouble operator -(SecureDouble a, SecureDouble b) => new SecureDouble(a.Value - b.Value);

        /// <summary>
        ///     Multiplies two SecureDouble values
        /// </summary>
        /// <param name="a">The first SecureDouble</param>
        /// <param name="b">The second SecureDouble</param>
        /// <returns>A new SecureDouble containing the product</returns>
        public static SecureDouble operator *(SecureDouble a, SecureDouble b) => new SecureDouble(a.Value * b.Value);

        /// <summary>
        ///     Divides one SecureDouble by another
        /// </summary>
        /// <param name="a">The SecureDouble to divide</param>
        /// <param name="b">The SecureDouble to divide by</param>
        /// <returns>A new SecureDouble containing the quotient</returns>
        public static SecureDouble operator /(SecureDouble a, SecureDouble b) => new SecureDouble(a.Value / b.Value);

        /// <summary>
        ///     Returns the string representation of the decrypted value
        /// </summary>
        /// <returns>The decrypted double value as a string</returns>
        public override string ToString() => Value.ToString();

        /// <summary>
        ///     Computes the hash code of the decrypted value
        /// </summary>
        /// <returns>The hash code of the underlying double</returns>
        public override int GetHashCode() => Value.GetHashCode();

        /// <summary>
        ///     Determines whether the specified object equals the current SecureDouble
        /// </summary>
        /// <param name="obj">The object to compare</param>
        /// <returns>True if the values are equal; otherwise, false</returns>
        public override bool Equals(object obj) => Value.Equals((obj as SecureDouble).Value);
    }
}