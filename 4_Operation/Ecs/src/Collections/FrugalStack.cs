using System;
using System.Collections.Generic;
using Frent.Buffers;
using System.Runtime.CompilerServices;

namespace Frent.Collections
{
    /// <summary>
    /// The frugal stack
    /// </summary>
    internal struct FrugalStack<T>()
    {
        /// <summary>
        /// The buffer
        /// </summary>
        private T[] _buffer = [];
        /// <summary>
        /// The next index
        /// </summary>
        private int _nextIndex = 0;

        /// <summary>
        /// Gets the value of the any
        /// </summary>
        public bool Any => _nextIndex != 0;


        /// <summary>
        /// Pushes the comp
        /// </summary>
        /// <param name="comp">The comp</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Push(T comp)
        {
            T[]? buffer = _buffer;
            if ((uint)_nextIndex < (uint)buffer.Length)
                buffer[_nextIndex++] = comp;
            else
                ResizeAndPush(comp);
        }

        /// <summary>
        /// Resizes the and push using the specified comp
        /// </summary>
        /// <param name="comp">The comp</param>
        private void ResizeAndPush(in T comp)
        {
            FastStackArrayPool<T>.ResizeArrayFromPool(ref _buffer, _buffer.Length > 16 ? _buffer.Length << 1 : _buffer.Length + 2);
            _buffer[_nextIndex++] = comp;
        }

        /// <summary>
        /// Tries the pop using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        public bool TryPop(out T value)
        {
            if (_nextIndex == 0)
            {
                value = default!;
                return false;
            }

            value = Pop();
            return true;
        }

        /// <summary>
        /// Pops this instance
        /// </summary>
        /// <returns>The next</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Pop()
        {
            T? next = _buffer[--_nextIndex];
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
                _buffer[_nextIndex] = default!;
            return next;
        }

        /// <summary>
        /// Removes the item
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
        /// DO NOT ALTER WHILE SPAN IS IN USE
        /// </summary>
        public readonly Span<T> AsSpan() => _buffer.AsSpan(0, _nextIndex);
    }
}
