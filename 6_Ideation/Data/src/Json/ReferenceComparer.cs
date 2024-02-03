// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ReferenceComparer.cs
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

using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    ///     A utility class to compare object by their reference.
    /// </summary>
    public sealed class ReferenceComparer : IEqualityComparer<object>
    {
        /// <summary>
        ///     Gets the instance of the ReferenceComparer class.
        /// </summary>
        public static readonly ReferenceComparer Instance = new ReferenceComparer();

        /// <summary>
        ///     Initializes a new instance of the <see cref="ReferenceComparer" /> class
        /// </summary>
        internal ReferenceComparer()
        {
        }

        /// <summary>
        ///     Describes whether this instance equals
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The bool</returns>
        bool IEqualityComparer<object>.Equals(object x, object y) => ReferenceEquals(x, y);

        /// <summary>
        ///     Gets the hash code using the specified obj
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <returns>The int</returns>
        int IEqualityComparer<object>.GetHashCode(object obj) => RuntimeHelpers.GetHashCode(obj);
    }
}