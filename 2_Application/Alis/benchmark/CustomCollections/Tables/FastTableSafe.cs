// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastTableSafe.cs
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
using System.Buffers;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Buffers;
using Alis.Core.Ecs.Core.Archetype;

namespace Alis.Core.Ecs.Collections
{
    /// <summary>
    /// The fast table safe
    /// </summary>
    [StructLayout(LayoutKind.Auto)]
    public struct FastTableSafe<T>
    {
        /// <summary>
        /// The internal buffer that stores the elements.
        /// </summary>
        internal T[] _buffer;

        /// <summary>
        /// Initializes a new instance of the <see cref="FastTableSafe{T}"/> struct with the specified size.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FastTableSafe(int size)
        {
            _buffer = size > 0 ? FastStackArrayPool<T>.Instance.Rent(size) : Array.Empty<T>();
        }

        /// <summary>
        /// Gets an empty instance of <see cref="FastTableSafe{T}"/>.
        /// </summary>
        public static FastTableSafe<T> Empty => new FastTableSafe<T>(0);

        /// <summary>
        /// Provides index access with automatic resizing.
        /// If the index is within the current bounds, returns a reference to the element.
        /// Otherwise, resizes the internal array to the next power of 2 that covers the index.
        /// </summary>
        public ref T this[int index]
        {
            get
            {
                if ((uint) index < (uint) _buffer.Length)
                    return ref _buffer[index];

                return ref ResizeGet(index);
            }
        }

        /// <summary>
        /// Resizes the array to the next power of 2 that covers the requested index and returns the element reference.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ref T ResizeGet(int index)
        {
            int newSize = (int) BitOperations.RoundUpToPowerOf2((uint) (index + 1));
            FastStackArrayPool<T>.ResizeArrayFromPool(ref _buffer, newSize);
            return ref _buffer[index];
        }

        /// <summary>
        /// Returns a reference to the element at the specified index without resizing.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref T UnsafeIndexNoResize(int index) => ref _buffer[index];

        /// <summary>
        /// Ensures that the internal array has at least the specified capacity.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void EnsureCapacity(int size)
        {
            if (_buffer.Length < size)
                FastStackArrayPool<T>.ResizeArrayFromPool(ref _buffer, size);
        }

        /// <summary>
        /// Returns the internal array as a Span&lt;T&gt;.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<T> AsSpan() => _buffer.AsSpan();

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose() => FastStackArrayPool<T>.Instance.Return(_buffer, true);
    }
}