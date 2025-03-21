// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UnsafeExtensions.cs
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

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Core.Memory
{
    /// <summary>
    ///     The unsafe extensions class
    /// </summary>
    internal static class UnsafeExtensions
    {
        /// <summary>
        ///     Unsafes the array index using the specified arr
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="arr">The arr</param>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        public static ref T UnsafeArrayIndex<T>(this T[] arr, nint index) =>
            ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(arr), index);

        /// <summary>
        ///     Unsafes the array index using the specified arr
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="arr">The arr</param>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        public static ref T UnsafeArrayIndex<T>(this T[] arr, int index) =>
            ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(arr), index);

        /// <summary>
        ///     Unsafes the array index using the specified arr
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="arr">The arr</param>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        public static ref T UnsafeArrayIndex<T>(this T[] arr, ushort index) =>
            ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(arr), index);

        /// <summary>
        ///     Unsafes the array index using the specified arr
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="arr">The arr</param>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        public static ref T UnsafeArrayIndex<T>(this T[] arr, uint index) =>
            ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(arr), index);

        /// <summary>
        ///     Unsafes the span index using the specified arr
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="arr">The arr</param>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        public static ref T UnsafeSpanIndex<T>(this Span<T> arr, int index) =>
            ref Unsafe.Add(ref MemoryMarshal.GetReference(arr), index);

        /// <summary>
        ///     Unsafes the span index using the specified arr
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="arr">The arr</param>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        public static ref T UnsafeSpanIndex<T>(this Span<T> arr, ushort index) =>
            ref Unsafe.Add(ref MemoryMarshal.GetReference(arr), index);

        /// <summary>
        ///     Unsafes the span index using the specified arr
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="arr">The arr</param>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        public static ref T UnsafeSpanIndex<T>(this Span<T> arr, uint index) =>
            ref Unsafe.Add(ref MemoryMarshal.GetReference(arr), index);

        /// <summary>
        ///     Unsafes the cast using the specified o
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="o">The </param>
        /// <returns>The</returns>
        public static T UnsafeCast<T>(object o) where T : class =>
            Unsafe.As<T>(o);
    }
}