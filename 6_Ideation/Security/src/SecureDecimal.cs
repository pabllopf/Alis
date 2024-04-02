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

namespace Alis.Core.Aspect.Security
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
                    _randomValue = SecureRandom.Random.Next(-1024, 1024);
                    _value = value + _randomValue;
                }
            }
        }

        public static implicit operator SecureDecimal(decimal value) => new SecureDecimal(value);

        public static implicit operator decimal(SecureDecimal value) => value.Value;

        public static bool operator ==(SecureDecimal a, SecureDecimal b) => a.Value == b.Value;

        public static bool operator !=(SecureDecimal a, SecureDecimal b) => a.Value != b.Value;

        public static SecureDecimal operator ++(SecureDecimal a)
        {
            a.Value++;
            return a;
        }

        public static SecureDecimal operator --(SecureDecimal a)
        {
            a.Value--;
            return a;
        }

        public static SecureDecimal operator +(SecureDecimal a, SecureDecimal b) => new SecureDecimal(a.Value + b.Value);

        public static SecureDecimal operator -(SecureDecimal a, SecureDecimal b) => new SecureDecimal(a.Value - b.Value);

        public static SecureDecimal operator *(SecureDecimal a, SecureDecimal b) => new SecureDecimal(a.Value * b.Value);

        public static SecureDecimal operator /(SecureDecimal a, SecureDecimal b) => new SecureDecimal(a.Value / b.Value);

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
        public override bool Equals(object obj) => Value.Equals((obj as SecureDecimal).Value);
    }
}