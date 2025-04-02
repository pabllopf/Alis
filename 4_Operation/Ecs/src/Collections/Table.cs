// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Table.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Buffers;
using Alis.Core.Ecs.Core.Memory;
using Alis.Core.Ecs.Redefinition;

namespace Alis.Core.Ecs.Collections
{
    /// <summary>
    ///     The table
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Table<T>(int size)
    {
        /// <summary>
        ///     The size
        /// </summary>
        internal T[] _buffer = new T[size];

        /// <summary>
        ///     The index
        /// </summary>
        public ref T this[int index]
        {
           
            get
            {
                T[] buffer = _buffer;
                if ((uint) index < (uint) buffer.Length)
                {
                    return ref buffer.UnsafeArrayIndex(index);
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
            ComponentArrayPool<T>.ResizeArrayFromPool(ref _buffer, (int) BitOperations.RoundUpToPowerOf2((uint) (index + 1)));
            return ref _buffer.UnsafeArrayIndex(index);
        }

        /// <summary>
        ///     Unsafes the index no resize using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        
        public ref T UnsafeIndexNoResize(int index) => ref _buffer.UnsafeArrayIndex(index);

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

            ComponentArrayPool<T>.ResizeArrayFromPool(ref _buffer, size);
        }

        /// <summary>
        ///     Converts the span
        /// </summary>
        /// <returns>A span of t</returns>
        
        public Span<T> AsSpan() => _buffer.AsSpan();
    }
}