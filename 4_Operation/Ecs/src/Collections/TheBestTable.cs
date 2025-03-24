// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TheBestTable.cs
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
using Alis.Core.Ecs.Buffers;
using Alis.Core.Ecs.Core.Memory;

namespace Alis.Core.Ecs.Collections
{
    /// <summary>
    /// The the best table
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TheBestTable<T> : IDisposable 
    {
        /// <summary>
        /// The array
        /// </summary>
        private T[] _array;
       
        /// <summary>
        /// The index
        /// </summary>
        public ref T this[int index]
        {
            get
            {
                if ((uint) index < (uint) _array)
                {
                    return ref ResizeFor(index);
                }

                return ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(_array), index);
            }
        }

        /// <summary>
        /// Unsafes the index no resize using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref T UnsafeIndexNoResize(int index) =>  ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(_array), index);

        /// <summary>
        /// Initializes a new instance of the <see cref="TheBestTable"/> class
        /// </summary>
        /// <param name="initialCapacity">The initial capacity</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidOperationException">Cannot store managed objects in native code</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TheBestTable(int initialCapacity = 32)
        {
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
            {
                throw new InvalidOperationException("Cannot store managed objects in native code");
            }

            if (initialCapacity < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(initialCapacity));
            }

            FastStackArrayPool<T>.ResizeArrayFromPool(ref _array, (int) BitOperations.RoundUpToPowerOf2((uint) (initialCapacity * 2)));
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose() => FastStackArrayPool<T>.Instance.Return(_array, true);

        /// <summary>
        /// Resizes the for using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ref T ResizeFor(int index)
        {
            FastStackArrayPool<T>.ResizeArrayFromPool(ref _array, (int) BitOperations.RoundUpToPowerOf2((uint) (index + 1)));
            return ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(_array), index);
        }

        /// <summary>
        /// Ensures the capacity using the specified new capacity
        /// </summary>
        /// <param name="newCapacity">The new capacity</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void EnsureCapacity(int size)
        {
            if (_array.Length >= size)
            {
                return;
            }
            
            FastStackArrayPool<T>.ResizeArrayFromPool(ref _array, size);
        }

        /// <summary>
        /// Converts the span
        /// </summary>
        /// <returns>A span of t</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<T> AsSpan() => _array.AsSpan();
    }
}