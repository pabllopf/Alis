// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NormalTable.cs
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
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Benchmark.CustomCollections.ArrayPools.Elements;

namespace Alis.Benchmark.CustomCollections.Tables.Elements
{
    /// <summary>
    ///     The table
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NormalTable<T>(int size)
    {
        /// <summary>
        ///     Gets the value of the empty
        /// </summary>
        public static NormalTable<T> Empty => new()
        {
            Buffer = []
        };

        /// <summary>
        ///     The size
        /// </summary>
        internal T[] Buffer = new T[size];

        /// <summary>
        ///     The index
        /// </summary>
        public ref T this[int index]
        {
            get
            {
                T[] buffer = Buffer;
                if ((uint) index < (uint) buffer.Length)
                {
                    return ref buffer[index];
                }

                return ref ResizeGet(index);
            }
        }

        /// <summary>
        ///     Resizes the get using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        private ref T ResizeGet(int index)
        {
            FastArrayPool<T>.ResizeArrayFromPool(ref Buffer, (int) BitOperations.RoundUpToPowerOf2((uint) (index + 1)));
            return ref Unsafe.Add(ref Buffer[0], index);
        }

        /// <summary>
        ///     Unsafes the index no resize using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        public ref T UnsafeIndexNoResize(int index) => ref Unsafe.Add(ref Buffer[0], index);

        /// <summary>
        ///     Ensures the capacity using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        public void EnsureCapacity(int size)
        {
            if (Buffer.Length >= size)
            {
                return;
            }

            FastArrayPool<T>.ResizeArrayFromPool(ref Buffer, size);
        }

        /// <summary>
        ///     Converts the span
        /// </summary>
        /// <returns>A span of t</returns>
        public Span<T> AsSpan() => Buffer.AsSpan();
    }
}