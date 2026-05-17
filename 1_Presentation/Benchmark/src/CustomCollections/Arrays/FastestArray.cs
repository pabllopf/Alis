// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastestArray.cs
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

namespace Alis.Benchmark.CustomCollections.Arrays
{
    /// <summary>
    ///     A high-performance array wrapper backed by <see cref="ArrayPool{T}"/> with memory and span support.
    /// </summary>
    /// <typeparam name="T">The element type of the array.</typeparam>
    public struct FastestArray<T> : IDisposable
    {
        /// <summary>
        ///     The underlying rented array from the array pool.
        /// </summary>
        private T[] _array;

        /// <summary>
        ///     The memory wrapper around the underlying array.
        /// </summary>
        private Memory<T> _memory;

        /// <summary>
        ///     Gets the number of elements in the array.
        /// </summary>
        public int Length => _array.Length;

        /// <summary>
        ///     Gets a span over the entire array.
        /// </summary>
        public Span<T> Span => _memory.Span;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FastestArray{T}"/> struct, renting an array from the shared pool.
        /// </summary>
        /// <param name="length">The number of elements to rent from the array pool.</param>
        public FastestArray(int length)
        {
            _array = ArrayPool<T>.Shared.Rent(length);
            _memory = new Memory<T>(_array);
        }

        /// <summary>
        ///     Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        public T this[int index]
        {
            get => _memory.Span[index];
            set => _memory.Span[index] = value;
        }

        /// <summary>
        ///     Clears all elements in the span by setting them to their default values.
        /// </summary>
        public void Clear() => _memory.Span.Clear();

        /// <summary>
        ///     Returns the rented array to the shared pool and releases memory.
        /// </summary>
        public void Dispose()
        {
            if (_array is not null)
            {
                ArrayPool<T>.Shared.Return(_array);
            }

            _memory = Memory<T>.Empty;
        }

        /// <summary>
        ///     Resizes the array by renting a new block from the pool and copying existing elements.
        /// </summary>
        /// <param name="arraySize">The new size of the array.</param>
        public void Resize(int arraySize)
        {
            if (arraySize == _array.Length)
            {
                return;
            }

            T[] newArray = ArrayPool<T>.Shared.Rent(arraySize);
            _memory.Span.Slice(0, Math.Min(_array.Length, arraySize)).CopyTo(newArray.AsSpan());

            ArrayPool<T>.Shared.Return(_array);
            _array = newArray;
            _memory = new Memory<T>(_array, 0, arraySize);
        }

        /// <summary>
        ///     Returns a span over the entire array.
        /// </summary>
        /// <returns>A span containing all elements of the array.</returns>
        public Span<T> AsSpan() => _memory.Span;

        /// <summary>
        ///     Returns a span containing the first <paramref name="arraySize"/> elements of the array.
        /// </summary>
        /// <param name="arraySize">The number of elements to include in the span.</param>
        /// <returns>A span containing the specified number of elements from the start of the array.</returns>
        public Span<T> AsSpanLen(int arraySize) => _memory.Span.Slice(0, arraySize);
    }
}