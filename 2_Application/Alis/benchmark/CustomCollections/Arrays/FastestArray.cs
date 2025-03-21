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
    /// The fastest array
    /// </summary>
    public struct FastestArray<T>
    {
        /// <summary>
        /// The array
        /// </summary>
        private T[] _array;
        
        /// <summary>
        /// The memory
        /// </summary>
        private Memory<T> _memory;

        /// <summary>
        /// Gets the value of the length
        /// </summary>
        public int Length => _array.Length;
        /// <summary>
        /// Gets the value of the span
        /// </summary>
        public Span<T> Span => _memory.Span;

        /// <summary>
        /// Initializes a new instance of the <see cref="FastestArray"/> class
        /// </summary>
        /// <param name="length">The length</param>
        public FastestArray(int length)
        {
            _array = ArrayPool<T>.Shared.Rent(length);
            _memory = new Memory<T>(_array);
        }

        /// <summary>
        /// The value
        /// </summary>
        public T this[int index]
        {
            get => _memory.Span[index];
            set => _memory.Span[index] = value;
        }

        /// <summary>
        /// Clears this instance
        /// </summary>
        public void Clear() => _memory.Span.Clear();

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            _array = null;
            _memory = Memory<T>.Empty;
        }

        /// <summary>
        /// Resizes the array size
        /// </summary>
        /// <param name="arraySize">The array size</param>
        public void Resize(int arraySize)
        {
            if (arraySize == _array.Length)
                return;

            T[] newArray = ArrayPool<T>.Shared.Rent(arraySize);
            _memory.Span.Slice(0, Math.Min(_array.Length, arraySize)).CopyTo(newArray.AsSpan());

            ArrayPool<T>.Shared.Return(_array);
            _array = newArray;
            _memory = new Memory<T>(_array, 0, arraySize);
        }

        /// <summary>
        /// Converts the span
        /// </summary>
        /// <returns>A span of t</returns>
        public Span<T> AsSpan() => _memory.Span;

        /// <summary>
        /// Converts the span len using the specified array size
        /// </summary>
        /// <param name="arraySize">The array size</param>
        /// <returns>A span of t</returns>
        public Span<T> AsSpanLen(int arraySize) => _memory.Span.Slice(0, arraySize);
    }
}