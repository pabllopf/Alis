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
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator SecureDouble(double value) => new SecureDouble(value);

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator double(SecureDouble value) => value.Value;

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(SecureDouble a, SecureDouble b) => SecureRandom.Abs((float) (a.Value - b.Value)) < float.Epsilon;

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(SecureDouble a, SecureDouble b) => SecureRandom.Abs((float) (a.Value - b.Value)) > float.Epsilon;

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static SecureDouble operator ++(SecureDouble a)
        {
            a.Value++;
            return a;
        }

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static SecureDouble operator --(SecureDouble a)
        {
            a.Value--;
            return a;
        }

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureDouble operator +(SecureDouble a, SecureDouble b) => new SecureDouble(a.Value + b.Value);

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureDouble operator -(SecureDouble a, SecureDouble b) => new SecureDouble(a.Value - b.Value);

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureDouble operator *(SecureDouble a, SecureDouble b) => new SecureDouble(a.Value * b.Value);

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureDouble operator /(SecureDouble a, SecureDouble b) => new SecureDouble(a.Value / b.Value);

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
        public override bool Equals(object obj) => Value.Equals((obj as SecureDouble).Value);
    }
}