// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NativeStack.cs
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

using Alis.Core.Ecs.Core.Memory;

namespace Alis.Core.Ecs.Collections
{
    //Do not pass around this struct by value!!!
//You must use the constructor when initalizating!!!

#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
//As long as the user always uses the ctor, it would throw when managed type is used
/// <summary>
///     The native stack
/// </summary>
internal struct NativeStack<T> : IDisposable where T : struct
    {
        /// <summary>
        ///     Gets the value of the count
        /// </summary>
        public int Count => _nextIndex;

        /// <summary>
        ///     The array
        /// </summary>
        private T[] _array;

        /// <summary>
        ///     The next index
        /// </summary>
        private int _nextIndex;

        /// <summary>
        ///     The index
        /// </summary>
        public ref T this[int index]
        {
            get
            {
#if DEBUG
                if (index >= _nextIndex || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
#endif
                return ref _array.UnsafeArrayIndex(index);
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NativeStack" /> class
        /// </summary>
        /// <param name="initalCapacity">The inital capacity</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidOperationException">Cannot store managed objects in native code</exception>
        public NativeStack(int initalCapacity)
        {
            if (System.Runtime.CompilerServices.RuntimeHelpers.IsReferenceOrContainsReferences<T>())
            {
                throw new InvalidOperationException("Cannot store managed objects in native code");
            }

            if (initalCapacity < 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            _array = new T[initalCapacity];
        }

        /// <summary>
        ///     Pushes this instance
        /// </summary>
        /// <returns>The ref</returns>
        public ref T Push()
        {
            if (_nextIndex == _array.Length)
            {
                Resize();
            }

            return ref _array[_nextIndex++];
        }

        /// <summary>
        ///     Pops the value
        /// </summary>
        /// <param name="value">The value</param>
        public void Pop(out T value)
        {
            if (_nextIndex == 0)
            {
                FrentExceptions.Throw_InvalidOperationException("Stack is empty!");
            }

            value = _array[--_nextIndex];
        }

        /// <summary>
        ///     Cans the pop
        /// </summary>
        /// <returns>The bool</returns>
        public bool CanPop() => _nextIndex != 0;

        /// <summary>
        ///     Pops the unsafe
        /// </summary>
        /// <returns>The</returns>
        public T PopUnsafe() => _array[--_nextIndex];

        /// <summary>
        ///     Tries the pop using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        public bool TryPop(out T value)
        {
            if (_nextIndex == 0)
            {
                System.Runtime.CompilerServices.Unsafe.SkipInit(out value);
                MemoryHelpers.Poison(ref value);
                return false;
            }

            value = _array[--_nextIndex];
            return true;
        }

        /// <summary>
        ///     Removes the at using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        public void RemoveAt(int index)
        {
            if ((uint) index < (uint) _nextIndex)
            {
                _array[index] = _array[--_nextIndex];
                return;
            }

            FrentExceptions.Throw_InvalidOperationException("Invalid Index!");
        }

        /// <summary>
        ///     Resizes this instance
        /// </summary>
        private void Resize()
        {
            Array.Resize(ref _array, _array.Length << 1);
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        ///     Converts the span
        /// </summary>
        /// <returns>A span of t</returns>
        public Span<T> AsSpan() => _array.AsSpan(0, _nextIndex);
    }
}