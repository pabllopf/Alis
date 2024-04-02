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

namespace Alis.Core.Aspect.Security
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
                    _randomValue = SecureRandom.Random.Next();
                    _value = value + _randomValue;
                }
            }
        }

        public static implicit operator SecureInt(int value) => new SecureInt(value);

        public static implicit operator int(SecureInt value) => value.Value;

        public static bool operator ==(SecureInt a, SecureInt b) => a.Value == b.Value;

        public static bool operator !=(SecureInt a, SecureInt b) => a.Value != b.Value;

        public static SecureInt operator ++(SecureInt a)
        {
            a.Value++;
            return a;
        }

        public static SecureInt operator --(SecureInt a)
        {
            a.Value--;
            return a;
        }

        public static SecureInt operator +(SecureInt a, SecureInt b) => new SecureInt(a.Value + b.Value);

        public static SecureInt operator -(SecureInt a, SecureInt b) => new SecureInt(a.Value - b.Value);

        public static SecureInt operator *(SecureInt a, SecureInt b) => new SecureInt(a.Value * b.Value);

        public static SecureInt operator /(SecureInt a, SecureInt b) => new SecureInt(a.Value / b.Value);

        /// <summary>
        ///     Returns the string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString() => Value.ToString();

        /// <summary>
        ///     Gets the hash code
        /// </summary>
        /// <returns>The int</returns>
        public override int GetHashCode() => Value.GetHashCode();

        /// <summary>
        ///     Describes whether this instance equals
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <returns>The bool</returns>
        public override bool Equals(object obj) => Value.Equals((obj as SecureInt).Value);
    }
}