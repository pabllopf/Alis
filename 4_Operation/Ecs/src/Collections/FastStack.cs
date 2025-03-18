using System;
using Frent.Buffers;
using Frent.Core;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Frent.Collections
{
    /// <summary>
    /// The fast stack
    /// </summary>
    internal struct FastStack<T>(int initalComponents) : IEnumerable<T>
    {
        /// <summary>
        /// Creates the inital components
        /// </summary>
        /// <param name="initalComponents">The inital components</param>
        /// <returns>A fast stack of t</returns>
        [DebuggerStepThrough]
        public static FastStack<T> Create(int initalComponents) => new FastStack<T>(initalComponents);
        /// <summary>
        /// Creates the inital buffer
        /// </summary>
        /// <param name="initalBuffer">The inital buffer</param>
        /// <returns>A fast stack of t</returns>
        public static FastStack<T> Create(T[] initalBuffer) => new FastStack<T>()
        {
            _buffer = initalBuffer
        };

        /// <summary>
        /// The inital components
        /// </summary>
        private T[] _buffer = new T[initalComponents];
        /// <summary>
        /// The next index
        /// </summary>
        private int _nextIndex = 0;

        /// <summary>
        /// Gets the value of the count
        /// </summary>
        public readonly int Count => _nextIndex;
        /// <summary>
        /// Gets the value of the top
        /// </summary>
        public readonly T Top => _buffer[_nextIndex - 1];
        /// <summary>
        /// Gets the value of the has elements
        /// </summary>
        public readonly bool HasElements => _nextIndex > 0;

        /// <summary>
        /// The 
        /// </summary>
        public readonly ref T this[int i] => ref _buffer[i];


        /// <summary>
        /// Pushes the comp
        /// </summary>
        /// <param name="comp">The comp</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Push(T comp)
        {
            var buffer = _buffer;
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
            FastStackArrayPool<T>.ResizeArrayFromPool(ref _buffer, _buffer.Length * 2);
            _buffer[_nextIndex++] = comp;
        }

        /// <summary>
        /// Compacts this instance
        /// </summary>
        public void Compact() => Array.Resize(ref _buffer, _nextIndex);

        /// <summary>
        /// Pops this instance
        /// </summary>
        /// <returns>The next</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Pop()
        {
            var buffer = _buffer;
            var next = buffer[--_nextIndex];
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
                buffer[_nextIndex] = default!;
            return next;
        }

        /// <summary>
        /// Tries the pop using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns>The bool</returns>
        [DebuggerStepThrough]
        public bool TryPop(out T? value)
        {
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
                throw new NotImplementedException();

            if (_nextIndex == 0)
            {
                value = default;
                return false;
            }

            //we can ignore - as the as the user doesn't push null onto the stack
            //they won't get null from the stack
            value = _buffer.UnsafeArrayIndex(--_nextIndex)!;
            return true;
        }

        /// <summary>
        /// Removes the at replace using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        public void RemoveAtReplace(int index)
        {
            Debug.Assert(Count > 0);

            var buffer = _buffer;
            if (index < buffer.Length)
            {
                buffer[index] = buffer[--_nextIndex];
                if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
                    buffer[_nextIndex] = default!;
            }
        }


        /// <summary>
        /// DO NOT ALTER WHILE SPAN IS IN USE
        /// </summary>
        public readonly Span<T> AsSpan() => _buffer.AsSpan(0, _nextIndex);

        /// <summary>
        /// Clears this instance
        /// </summary>
        public void Clear()
        {
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
                AsSpan().Clear();
            _nextIndex = 0;
        }

        /// <summary>
        /// Clears the without clearing gc references
        /// </summary>
        public void ClearWithoutClearingGCReferences() => _nextIndex = 0;

        /// <summary>
        /// Gets the enumerator
        /// </summary>
        /// <returns>An enumerator of t</returns>
        readonly IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();
        /// <summary>
        /// Gets the enumerator
        /// </summary>
        /// <returns>The enumerator</returns>
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        /// <summary>
        /// Gets the enumerator
        /// </summary>
        /// <returns>The fast stack enumerator</returns>
        public readonly FastStackEnumerator GetEnumerator() => new(this);

        /// <summary>
        /// The fast stack enumerator
        /// </summary>
        public struct FastStackEnumerator(FastStack<T> stack) : IEnumerator<T>
        {
            /// <summary>
            /// The buffer
            /// </summary>
            private T[] _elements = stack._buffer;
            /// <summary>
            /// The next index
            /// </summary>
            private int _max = stack._nextIndex;
            /// <summary>
            /// The index
            /// </summary>
            private int _index = -1;
            /// <summary>
            /// Gets the value of the current
            /// </summary>
            public readonly T Current => _elements[_index];
            /// <summary>
            /// Gets the value of the current
            /// </summary>
            readonly object? IEnumerator.Current => _elements[_index];
            /// <summary>
            /// Disposes this instance
            /// </summary>
            public void Dispose() => _elements = null!;
            /// <summary>
            /// Moves the next
            /// </summary>
            /// <returns>The bool</returns>
            public bool MoveNext() => ++_index < _max;
            /// <summary>
            /// Resets this instance
            /// </summary>
            public void Reset() => _index = -1;
        }
    }
}
