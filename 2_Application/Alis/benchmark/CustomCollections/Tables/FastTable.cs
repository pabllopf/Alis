// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastTable.cs
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
    /// The fast table
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct FastTable<T>
    {
        /// <summary>
        /// The buffer
        /// </summary>
        public T[] _buffer;

        /// <summary>
        /// Initializes a new instance of the <see cref="FastTable"/> class
        /// </summary>
        /// <param name="size">The size</param>
        public FastTable(int size)
        {
#if NET6_0_OR_GREATER
            _buffer = GC.AllocateUninitializedArray<T>((int)BitOperations.RoundUpToPowerOf2((uint)size));
#else
            _buffer = new T[(int)BitOperations.RoundUpToPowerOf2((uint)size)];
#endif
        }
        
        /// <summary>
        /// The index
        /// </summary>
        public ref T this[int index]
        {
            
            get
            {
                if ((uint)index >= (uint)_buffer.Length)
                {
                    return ref ResizeGet(index); 
                }
                
                return ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(_buffer), index);
            }
        }
        
        /// <summary>
        /// Resizes the get using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        
        private ref T ResizeGet(int index)
        {
            int newSize = (int)BitOperations.RoundUpToPowerOf2((uint)(index + 1));

#if NET6_0_OR_GREATER
            T[] newArray = GC.AllocateUninitializedArray<T>(newSize);
#else
            T[] newArray = new T[newSize];
#endif
            _buffer.AsSpan().CopyTo(newArray);
            _buffer = newArray;

            return ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(_buffer), index);
        }

        /// <summary>
        /// Unsafes the index no resize using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        
        public ref T UnsafeIndexNoResize(int index) => ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(_buffer), index);

        /// <summary>
        /// Ensures the capacity using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        
        public void EnsureCapacity(int size)
        {
            if (_buffer.Length < size)
            {
                int newSize = (int)BitOperations.RoundUpToPowerOf2((uint)size);
#if NET6_0_OR_GREATER
                T[] newArray = GC.AllocateUninitializedArray<T>(newSize);
#else
                T[] newArray = new T[newSize];
#endif
                _buffer.AsSpan().CopyTo(newArray);
                _buffer = newArray;
            }
        }

        /// <summary>
        /// Converts the span
        /// </summary>
        /// <returns>A span of t</returns>
        
        public Span<T> AsSpan()
        {
#if NET6_0_OR_GREATER
            return MemoryMarshal.CreateSpan(ref _buffer[0], _buffer.Length);
#else
            return _buffer.AsSpan();
#endif
        }
    }
}