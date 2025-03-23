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

namespace Alis.Core.Ecs.Collections
{
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && !NET6_0_OR_GREATER
//Do not pass around this struct by value!!!
//You must use the constructor when initalizating!!!

#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
//As long as the user always uses the ctor, it would throw when managed type is used
    internal struct NativeTable<T> : IDisposable where T : struct
    {
        private T[] _array;
        private int _length;

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

        public ref T UnsafeIndexNoResize(int index) => ref _array[index];

        public NativeTable(int initalCapacity)
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
            _array = new T[initalCapacity];
        }

        public void Dispose()
        {
        }

        private ref T ResizeFor(int index)
        {
            _length = checked((int) BitOperations.RoundUpToPowerOf2((uint) (index + 1)));
            Array.Resize(ref _array, _length);
            return ref _array[index];
        }

        public void EnsureCapacity(int newCapacity)
        {
            _length = checked((int) BitOperations.RoundUpToPowerOf2((uint) newCapacity));
            Array.Resize(ref _array, _length);
        }

        public Span<T> AsSpan() => _array.AsSpan(0, _length);

        internal Span<T> Span => AsSpan();
    }
#else

    using System;
    using System.Collections.Generic;

    
    /// <summary>
    /// The native table class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    internal class NativeTable<T> : IDisposable where T : struct
    {
        /// <summary>
        /// The list that holds the elements.
        /// </summary>
        private List<T> _array;

        /// <summary>
        /// The length (current capacity) of the table.
        /// </summary>
        private int _length;

        /// <summary>
        /// Indexer to access elements.
        /// </summary>
        /// <param name="index">The index of the element.</param>
        /// <returns>The element at the specified index.</returns>
        public T this[int index]
        {
            get
            {
                if (index >= _length)
                    EnsureCapacity(index + 1);
                return _array[index];
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeTable{T}"/> class.
        /// </summary>
        /// <param name="initialCapacity">The initial capacity of the table.</param>
        public NativeTable(int initialCapacity)
        {
            if (initialCapacity < 1)
                throw new ArgumentOutOfRangeException(nameof(initialCapacity), "Capacity must be greater than zero.");

            _array = new List<T>(initialCapacity);
            _length = initialCapacity;
        }

        /// <summary>
        /// Disposes the instance and clears the list.
        /// </summary>
        public void Dispose()
        {
            _array.Clear();
        }

        /// <summary>
        /// Ensures that the table has at least the specified capacity.
        /// </summary>
        /// <param name="newCapacity">The new capacity.</param>
        public void EnsureCapacity(int newCapacity)
        {
            if (newCapacity > _length)
            {
                _length = Math.Max(newCapacity, _length * 2);
                _array.Capacity = _length;
            }
        }

        /// <summary>
        /// Converts the list into a span representation.
        /// </summary>
        /// <returns>A span representing the elements in the table.</returns>
        public Span<T> AsSpan() => _array.ToArray().AsSpan();

        /// <summary>
        /// The elements of the table as a span.
        /// </summary>
        internal Span<T> Span => AsSpan();
    }

#endif
}