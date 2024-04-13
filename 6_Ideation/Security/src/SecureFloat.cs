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

namespace Alis.Core.Aspect.Security
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
                    _randomValue = SecureRandom.Random.Next(-1024, 1024);
                    _value = value + _randomValue;
                }
            }
        }
        
        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator SecureFloat(float value) => new SecureFloat(value);
        
        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator float(SecureFloat value) => value.Value;
        
        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(SecureFloat a, SecureFloat b) => a.Value == b.Value;
        
        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(SecureFloat a, SecureFloat b) => a.Value != b.Value;
        
        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static SecureFloat operator ++(SecureFloat a)
        {
            a.Value++;
            return a;
        }
        
        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static SecureFloat operator --(SecureFloat a)
        {
            a.Value--;
            return a;
        }
        
        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureFloat operator +(SecureFloat a, SecureFloat b) => new SecureFloat(a.Value + b.Value);
        
        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureFloat operator -(SecureFloat a, SecureFloat b) => new SecureFloat(a.Value - b.Value);
        
        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureFloat operator *(SecureFloat a, SecureFloat b) => new SecureFloat(a.Value * b.Value);
        
        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SecureFloat operator /(SecureFloat a, SecureFloat b) => new SecureFloat(a.Value / b.Value);
        
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
        public override bool Equals(object obj) => Value.Equals((obj as SecureFloat).Value);
    }
}