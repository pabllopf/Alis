// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NativeStackUnsafe.cs
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

namespace Alis.Benchmark.NativeCollections.NativeStack
{
   /// <summary>
   /// The native stack unsafe
   /// </summary>
   internal unsafe struct NativeStackUnsafe<T> : IDisposable where T : struct
    {
        /// <summary>
        /// Gets the value of the count
        /// </summary>
        public int Count => _nextIndex;

        /// <summary>
        /// The 
        /// </summary>
        private static readonly nuint Size = (nuint)Unsafe.SizeOf<T>();
        /// <summary>
        /// The array
        /// </summary>
        private T* _array;
        /// <summary>
        /// The capacity
        /// </summary>
        private int _capacity;
        /// <summary>
        /// The next index
        /// </summary>
        private int _nextIndex;

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
        /// Initializes a new instance of the <see cref="NativeStack"/> class
        /// </summary>
        /// <param name="initalCapacity">The inital capacity</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidOperationException">Cannot store managed objects in native code</exception>
        public NativeStackUnsafe(int initalCapacity)
        {
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
                throw new InvalidOperationException("Cannot store managed objects in native code");
            if (initalCapacity < 1)
                throw new ArgumentOutOfRangeException();

            _capacity = initalCapacity;
            _array = (T*)NativeMemory.Alloc((nuint)initalCapacity * Size);
        }

        /// <summary>
        /// Pushes this instance
        /// </summary>
        /// <returns>The ref</returns>
        public ref T Push()
        {
            if (_nextIndex == _capacity)
                Resize();
            return ref _array[_nextIndex++];
        }

        /// <summary>
        /// Pops the value
        /// </summary>
        /// <param name="value">The value</param>
        public void Pop(out T value)
        {
            if (_nextIndex == 0)
                throw new InvalidOperationException("Stack is empty!");
            value = _array[--_nextIndex];
        }

        /// <summary>
        /// Cans the pop
        /// </summary>
        /// <returns>The bool</returns>
        public bool CanPop() => _nextIndex != 0;

        /// <summary>
        /// Pops the unsafe
        /// </summary>
        /// <returns>The</returns>
        public T PopUnsafe() => _array[--_nextIndex];

        /// <summary>
        /// Tries the pop using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        public bool TryPop(out T value)
        {
            if (_nextIndex == 0)
            {
                Unsafe.SkipInit(out value);
                return false;
            }

            value = _array[--_nextIndex];
            return true;
        }

        /// <summary>
        /// Removes the at using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        public void RemoveAt(int index)
        {
            if ((uint)index < (uint)_nextIndex)
            {
                _array[index] = _array[--_nextIndex];
                return;
            }
           throw new InvalidOperationException("Invalid Index!");
        }

        /// <summary>
        /// Resizes this instance
        /// </summary>
        private void Resize()
        {
            _capacity = checked(_capacity * 2);
            _array = (T*)NativeMemory.Realloc(_array, Size * (nuint)_capacity);
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            NativeMemory.Free(_array);
            _array = (T*)0;
        }

        /// <summary>
        /// Converts the span
        /// </summary>
        /// <returns>A span of t</returns>
        public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref Unsafe.AsRef<T>(_array), _nextIndex);
    }
}