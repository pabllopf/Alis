// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastArraySafe.cs
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
using System.Runtime.InteropServices;

namespace Alis.Benchmark.CustomCollections.Arrays
{
    /// <summary>
    ///     A high-performance, safe array wrapper with span support and manual memory management.
    /// </summary>
    /// <typeparam name="T">The element type of the array.</typeparam>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FastArraySafe<T> : IDisposable
    {
        /// <summary>
        ///     The underlying array storage.
        /// </summary>
        private T[] _array = [];

        /// <summary>
        ///     Gets the number of elements in the array.
        /// </summary>
        public int Length => _array.Length;

        /// <summary>
        ///     Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        public ref T this[int index] => ref _array[index];

        /// <summary>
        ///     Initializes a new instance of the <see cref="FastArraySafe{T}"/> struct with the specified length.
        /// </summary>
        /// <param name="length">The number of elements in the array. Must be greater than zero.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="length"/> is less than 1.</exception>
        public FastArraySafe(int length)
        {
            if (length < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "La longitud debe ser mayor a 0.");
            }

            _array = new T[length];
        }

        /// <summary>
        ///     Returns the underlying array as a <see cref="Span{T}"/> for fast iteration.
        /// </summary>
        /// <returns>A span wrapping the entire array.</returns>
        public Span<T> AsSpan() => _array;

        /// <summary>
        ///     Clears the array by setting each element to its default value.
        /// </summary>
        public void Clear() => Array.Clear(_array, 0, _array.Length);

        /// <summary>
        ///     Resizes the array to the specified new length, copying existing elements up to the smaller of the two lengths.
        /// </summary>
        /// <param name="newLength">The new length of the array.</param>
        public void Resize(int newLength)
        {
            if (newLength == _array.Length)
            {
                return;
            }

            T[] newArray = new T[newLength];
            int count = Math.Min(_array.Length, newLength);
            Array.Copy(_array, newArray, count);
            _array = newArray;
        }

        /// <summary>
        ///     Releases the underlying array by setting it to null.
        /// </summary>
        public void Dispose() => _array = null;

        /// <summary>
        ///     Returns a span covering the first <paramref name="arraySize"/> elements of the array.
        /// </summary>
        /// <param name="arraySize">The number of elements to include in the span.</param>
        /// <returns>A span containing the specified number of elements from the start of the array.</returns>
        public Span<T> AsSpanLen(int arraySize) => _array.AsSpan(0, arraySize);
    }
}