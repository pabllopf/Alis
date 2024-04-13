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

namespace Alis.Core.Aspect.Security
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
                    _randomValue = SecureRandom.Random.Next();
                    _value = value + _randomValue;
                }
            }
        }
        
        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator SecureLong(long value) => new SecureLong(value);
        
        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator long(SecureLong value) => value.Value;
        
        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(SecureLong a, SecureLong b) => a.Value == b.Value;
        
        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(SecureLong a, SecureLong b) => a.Value != b.Value;
        
        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static SecureLong operator ++(SecureLong a)
        {
            a.Value++;
            return a;
        }
        
        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static SecureLong operator --(SecureLong a)
        {
            a.Value--;
            return a;
        }
        
        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureLong operator +(SecureLong a, SecureLong b) => new SecureLong(a.Value + b.Value);
        
        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureLong operator -(SecureLong a, SecureLong b) => new SecureLong(a.Value - b.Value);
        
        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureLong operator *(SecureLong a, SecureLong b) => new SecureLong(a.Value * b.Value);
        
        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureLong operator /(SecureLong a, SecureLong b) => new SecureLong(a.Value / b.Value);
        
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
        public override bool Equals(object obj) => Value.Equals((obj as SecureLong).Value);
    }
}