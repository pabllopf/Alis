// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NativeArrayUnsafe.cs
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

namespace Alis.Benchmark.CustomCollections.Arrays
{
    /// <summary>
    /// The native array unsafe
    /// </summary>
    public unsafe struct NativeArrayUnsafe<T> : IDisposable
    {
        /// <summary>
        /// Gets the value of the length
        /// </summary>
        public int Length => _length;

        /// <summary>
        /// The 
        /// </summary>
        private static readonly nuint Size = (nuint)Unsafe.SizeOf<T>();
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
                return ref _array[index];
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeArray"/> class
        /// </summary>
        /// <param name="length">The length</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidOperationException">Cannot store managed objects in native code</exception>
        public NativeArrayUnsafe(int length)
        {
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
            {
                throw new InvalidOperationException("Cannot store managed objects in native code");
            }

            if (length < 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            _length = length;
            _array = (T*)NativeMemory.Alloc((nuint)length * Size);
        }

        /// <summary>
        /// Resizes the size
        /// </summary>
        /// <param name="size">The size</param>
        public void Resize(int size)
        {
            _length = size;
            _array = (T*)NativeMemory.Realloc(_array, Size * (nuint)size);
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            NativeMemory.Free(_array);
            //null reference isnt as bad as a use after free, right?
            _array = (T*)0;
        }

        /// <summary>
        /// Converts the span
        /// </summary>
        /// <returns>A span of t</returns>
        public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref Unsafe.AsRef<T>(_array), _length);
        
        /// <summary>
        /// Converts the span len using the specified len
        /// </summary>
        /// <param name="len">The len</param>
        /// <returns>A span of t</returns>
        public Span<T> AsSpanLen(int len)
        {
            return MemoryMarshal.CreateSpan(ref Unsafe.AsRef<T>(_array), len);
        }
    }
}