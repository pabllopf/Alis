// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastestTable.cs
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
    ///     The fastest table combining optimal performance traits, safe version.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FastestTable<T>
    {
        /// <summary>
        ///     The buffer
        /// </summary>
        public T[] _buffer;

        /// <summary>
        ///     Gets the value of the empty
        /// </summary>
        public static FastestTable<T> Empty => new() {_buffer = Array.Empty<T>()};

        /// <summary>
        ///     Initializes a new instance of the <see cref="FastestTable" /> class
        /// </summary>
        /// <param name="size">The size</param>
        public FastestTable(int size)
        {
#if NET6_0_OR_GREATER
            _buffer = GC.AllocateUninitializedArray<T>((int) BitOperations.RoundUpToPowerOf2((uint) size));
#else
            _buffer = new T[(int) BitOperations.RoundUpToPowerOf2((uint) size)];
#endif
        }

        /// <summary>
        ///     The index
        /// </summary>
        public ref T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (index >= _buffer.Length)
                {
                    return ref ResizeGet(index);
                }

                ref T r0 = ref MemoryMarshal.GetArrayDataReference(_buffer);
                return ref Unsafe.Add(ref r0, index);
            }
        }

        /// <summary>
        ///     Resizes the get using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        private ref T ResizeGet(int index)
        {
            FastArrayPool<T>.ResizeArrayFromPool(ref _buffer, (int) BitOperations.RoundUpToPowerOf2((uint) (index + 1)));
            return ref Unsafe.Add(ref _buffer[0], index);
        }

        /// <summary>
        ///     Unsafes the index no resize using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref T UnsafeIndexNoResize(int index)
        {
            ref T r0 = ref MemoryMarshal.GetArrayDataReference(_buffer);
            return ref Unsafe.Add(ref r0, index);
        }

        /// <summary>
        ///     Ensures the capacity using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        public void EnsureCapacity(int size)
        {
            if (_buffer.Length >= size)
            {
                return;
            }

            FastArrayPool<T>.ResizeArrayFromPool(ref _buffer, size);
        }

        /// <summary>
        ///     Converts the span
        /// </summary>
        /// <returns>A span of t</returns>
        public Span<T> AsSpan()
        {
#if NET6_0_OR_GREATER
            return MemoryMarshal.CreateSpan(ref MemoryMarshal.GetArrayDataReference(_buffer), _buffer.Length);
#else
            return _buffer.AsSpan();
#endif
        }


        /// <summary>
        ///     Gets the value of the length
        /// </summary>
        public int Length => _buffer.Length;
    }
}