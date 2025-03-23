// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NativeTable.cs
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

namespace Alis.Benchmark.CustomCollections.Tables
{
    /// <summary>
    /// The native table unsafe
    /// </summary>
    public unsafe struct NativeTableUnsafe<T> : IDisposable where T : struct
    {
        /// <summary>
        /// The 
        /// </summary>
        private static readonly nuint Size = (nuint) Unsafe.SizeOf<T>();

        /// <summary>
        /// The array
        /// </summary>
        private T* _array;

        /// <summary>
        /// The length
        /// </summary>
        private int _length;

        /// <summary>
        /// The index
        /// </summary>
        public ref T this[int index]
        {
            get
            {
                if (index >= _length)
                {
                    return ref ResizeFor(index);
                }

                return ref _array[index];
            }
        }

        /// <summary>
        /// Unsafes the index no resize using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        public ref T UnsafeIndexNoResize(int index)
        {
            return ref _array[index];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeTableUnsafe{T}"/> class
        /// </summary>
        /// <param name="initalCapacity">The inital capacity</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidOperationException">Cannot store managed objects in native code</exception>
        public NativeTableUnsafe(int initalCapacity)
        {
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
            {
                throw new InvalidOperationException("Cannot store managed objects in native code");
            }

            if (initalCapacity < 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            _length = initalCapacity;
            _array = (T*) NativeMemory.Alloc((nuint) initalCapacity * Size);
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            NativeMemory.Free(_array);
            //null reference isnt as bad as a use after free, right?
            _array = (T*) 0;
        }

        /// <summary>
        /// Resizes the for using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        public ref T ResizeFor(int index)
        {
            _length = checked((int) BitOperations.RoundUpToPowerOf2((uint) (index + 1)));
            _array = (T*) NativeMemory.Realloc(_array, (nuint) _length * Size);
            return ref _array[index];
        }

        /// <summary>
        /// Ensures the capacity using the specified new capacity
        /// </summary>
        /// <param name="newCapacity">The new capacity</param>
        public void EnsureCapacity(int newCapacity)
        {
            _length = checked((int) BitOperations.RoundUpToPowerOf2((uint) newCapacity));
            _array = (T*) NativeMemory.Realloc(_array, (nuint) _length * Size);
        }

        /// <summary>
        /// Converts the span
        /// </summary>
        /// <returns>A span of t</returns>
        
        public Span<T> AsSpan() => System.Runtime.InteropServices.MemoryMarshal.CreateSpan(ref Unsafe.AsRef<T>(_array), _length);

        /// <summary>
        /// Gets the value of the span
        /// </summary>
        internal Span<T> Span => AsSpan();
    }
}