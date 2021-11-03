// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   NotNull.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

#region

using System;

#endregion

namespace Alis.FluentApi.Validations
{
    /// <summary>
    ///     The not null class
    /// </summary>
    public class NotNull<T>
    {
        /// <summary>
        ///     the value
        /// </summary>
        /// <param name="value">the value</param>
        public NotNull(T value)
        {
            Value = value;
        }

        /// <summary>
        ///     Gets or sets the value of the value
        /// </summary>
        public T Value { get; set; }

        public static implicit operator NotNull<T>(T value)
        {
            return new NotNull<T>(value ?? throw new ArgumentNullException(typeof(T).FullName));
        }
    }
}