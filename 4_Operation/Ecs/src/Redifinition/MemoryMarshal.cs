// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MemoryMarshal.cs
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

#if (NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
// ReSharper disable once CheckNamespace
namespace System.Runtime.InteropServices
{
    /// <summary>
    /// Provides methods for accessing and manipulating memory in a low-level manner.
    /// </summary>
    public static class MemoryMarshal
    {
        /// <summary>
        /// Gets a reference to the first element of a <see cref="Span{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the span.</typeparam>
        /// <param name="span">The span to get the reference from.</param>
        /// <returns>A reference to the first element of the span.</returns>
        public static ref T GetReference<T>(Span<T> span)
        {
            return ref span.GetPinnableReference();
        }

        /// <summary>
        /// Gets a reference to the first element of an array.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="arr">The array to get the reference from.</param>
        /// <returns>A reference to the first element of the array.</returns>
        public static ref T GetArrayDataReference<T>(T[] arr)
        {
            return ref GetReference(arr.AsSpan());
        }

        /// <summary>
        /// Gets a reference to the first element of a non-generic array.
        /// </summary>
        /// <param name="arr">The array to get the reference from.</param>
        /// <returns>A reference to the first element of the array.</returns>
        /// <exception cref="NotSupportedException">Thrown when this method is called.</exception>
        public static ref byte GetArrayDataReference(Array arr)
        {
            throw new NotSupportedException();
        }
    }
}

#endif