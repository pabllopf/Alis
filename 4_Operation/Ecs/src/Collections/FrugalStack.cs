using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Collections
{
    /// <summary>
    ///     The frugal stack
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    
    public struct FrugalStack<T>()
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
            T[] buffer = _buffer;
            if ((uint)_nextIndex < (uint)buffer.Length)
                buffer[_nextIndex++] = comp;
            else
                ResizeAndPush(comp);
        }

        /// <summary>
        ///     Resizes the and push using the specified comp
        /// </summary>
        /// <param name="comp">The comp</param>
        private void ResizeAndPush(in T comp)
        {
            FastestArrayPool<T>.ResizeArrayFromPool(ref _buffer,
                _buffer.Length > 16 ? _buffer.Length << 1 : _buffer.Length + 2);
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
                value = default!;
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
                _buffer[_nextIndex] = default!;
            return next;
        }

        public void Remove(T item)
        {
            for (int i = 0; i < _nextIndex; i++)
                if (EqualityComparer<T>.Default.Equals(_buffer[i], item))
                {
                    _buffer[i] = Pop();
                    break;
                }
        }


        /// <summary>
        ///     DO NOT ALTER WHILE SPAN IS IN USE
        /// </summary>
        public readonly Span<T> AsSpan()
        {
            return _buffer.AsSpan(0, _nextIndex);
        }
    }
}