// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FrugalStack.cs
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
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Alis.Core.Ecs.Buffers;

namespace Alis.Core.Ecs.Collections
{
    /// <summary>
    ///     The frugal stack
    /// </summary>
    internal struct FrugalStack<T>()
    {
        /// <summary>
        ///     The buffer
        /// </summary>
        private T[] _buffer = [];

        /// <summary>
        ///     The next index
        /// </summary>
        private int _nextIndex = 0;

        /// <summary>
        ///     Gets the value of the any
        /// </summary>
        public bool Any => _nextIndex != 0;


        /// <summary>
        ///     Pushes the comp
        /// </summary>
        /// <param name="comp">The comp</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Push(T comp)
        {
            T[]? buffer = _buffer;
            if ((uint) _nextIndex < (uint) buffer.Length)
            {
                buffer[_nextIndex++] = comp;
            }
            else
            {
                ResizeAndPush(comp);
            }
        }

        /// <summary>
        ///     Resizes the and push using the specified comp
        /// </summary>
        /// <param name="comp">The comp</param>
        private void ResizeAndPush(in T comp)
        {
            FastStackArrayPool<T>.ResizeArrayFromPool(ref _buffer, _buffer.Length > 16 ? _buffer.Length << 1 : _buffer.Length + 2);
            _buffer[_nextIndex++] = comp;
        }

        /// <summary>
        ///     Tries the pop using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        public bool TryPop(out T value)
        {
            if (_nextIndex == 0)
            {
                value = default(T)!;
                return false;
            }

            value = Pop();
            return true;
        }

        /// <summary>
        ///     Pops this instance
        /// </summary>
        /// <returns>The next</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Pop()
        {
            T next = _buffer[--_nextIndex];
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
            {
                _buffer[_nextIndex] = default(T)!;
            }

            return next;
        }

        /// <summary>
        ///     Removes the item
        /// </summary>
        /// <param name="item">The item</param>
        public void Remove(T item)
        {
            int nextIndex = _nextIndex;
            Span<T> items = _buffer.AsSpan()[..nextIndex];
            for (int i = 0; i < nextIndex; i++)
            {
                if (EqualityComparer<T>.Default.Equals(items[i], item))
                {
                    items[i] = Pop();
                    break;
                }
            }
        }


        /// <summary>
        ///     DO NOT ALTER WHILE SPAN IS IN USE
        /// </summary>
        public readonly Span<T> AsSpan() => _buffer.AsSpan(0, _nextIndex);
    }
}