// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   GrowableStack.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Alis.Core.Physics2D.Common
{
    /// <summary>
    ///     This is a growable LIFO stack with an initial capacity of N.
    ///     If the stack size exceeds the initial capacity, the heap is used
    ///     to increase the size of the stack.
    /// </summary>
    /// <remarks>
    ///     You MUST call <see cref="Dispose" /> when you are done with this stack or else you will have a memory leak.
    /// </remarks>
    /// <typeparam name="T">The type of elements in the stack.</typeparam>
    internal unsafe ref struct GrowableStack<T> where T : unmanaged
    {
        // TODO: Switch to managed arrays for the on-heap alloc when we have .NET 5.
        // Because with .NET 5 we can use the Pinned Object Heap.
        /// <summary>
        /// The stack
        /// </summary>
        private T* _stack;
        /// <summary>
        /// The was reallocated
        /// </summary>
        private bool _wasReallocated;
        /// <summary>
        /// The count
        /// </summary>
        internal int _count;
        /// <summary>
        /// The capacity
        /// </summary>
        private int _capacity;

        /// <summary>
        ///     Creates the growable stack with the allocated space as stack space.
        /// </summary>
        /// <remarks>
        ///     <paramref name="stackSpace" /> MUST BE A PIECE OF PINNED MEMORY,
        ///     OR ELSE YOU HAVE A MASSIVE GC BUG ON YOUR HANDS.
        /// </remarks>
        internal GrowableStack(Span<T> stackSpace)
        {
            fixed (T* ap = stackSpace)
            {
                _stack = ap;
            }

            _capacity = stackSpace.Length;
            _wasReallocated = false;
            _count = 0;
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        internal void Dispose()
        {
            if (_wasReallocated)
            {
                Marshal.FreeHGlobal((IntPtr) _stack);
                _stack = null;
            }
        }

        /// <summary>
        /// Pushes the element
        /// </summary>
        /// <param name="element">The element</param>
        internal void Push(in T element)
        {
            if (_count == _capacity)
            {
                T* old = _stack;
                _capacity *= 2;
                int dstSize = _capacity * sizeof(T);
                _stack = (T*) Marshal.AllocHGlobal(dstSize);
                Buffer.MemoryCopy(old, _stack, dstSize, _count * sizeof(T));
                if (_wasReallocated)
                {
                    Marshal.FreeHGlobal((IntPtr) old);
                }

                _wasReallocated = true;
            }

            _stack[_count] = element;
            ++_count;
        }

        /// <summary>
        /// Pops this instance
        /// </summary>
        /// <returns>The</returns>
        internal T Pop()
        {
            Debug.Assert(_count > 0);
            --_count;
            return _stack[_count];
        }
    }
}